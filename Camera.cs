using System;
using System.Windows.Forms;
using HalconDotNet;
using TIS.Imaging;
using csMotion;
using System.Drawing ;

namespace PrintInterface
{
    [Serializable ]
    public class CameraDMK
    {
        [NonSerialized] public bool m_CamInited = false;
        [NonSerialized ]public HImage m_hi_Image = new HImage();
        public HTuple m_ht_ImgWidth = 0;
        public HTuple m_ht_ImgHeight = 0;
        public double m_MmPerPixel=0;
        public PointF m_SampleCenter; //取样点中心
        public double m_SampleArea=0;  //取样点面积,用以筛选region
        public double m_SampleWidth = 0;//取样点外接宽度，用以筛选region
        public double m_AngleCalib=0;// 标定后的角度
       [NonSerialized ] public PointF m_MarkCenter; //Mark点的位置,以mm为单位
        public bool m_AngleCalibrated = false;//Angle has been calibarated
        public bool m_LenCalibrated = false; //长度已经标定
        public bool m_Sampled = false; //已经取样
     
       [NonSerialized ] private ushort m_modeShow = 1; // 0 为实际显示，1为 拉伸显示
       [NonSerialized ] private HWindowControl hWhindowCtl; //图像缺省显示控件
        //private HTuple picWindow;
        [NonSerialized ]private ICImagingControl tis = new ICImagingControl();
        [NonSerialized ]private bool FirstFrame;

        public CameraDMK()
        {
        }
        public CameraDMK(HWindowControl m_hWhindow)
        {
            hWhindowCtl = m_hWhindow;
            FirstFrame = true;
            try
            {
                tis.LoadDeviceStateFromFile("device.xml", true);
            }
            catch (Exception e1)
            {
                tis.ShowDeviceSettingsDialog();
                if (tis.DeviceValid)
                    tis.SaveDeviceStateToFile("device.xml");
                else
                {
                    Global.Print1.PrintingExcptInfo.Add("初始化相机发生错误" + e1.Message);
                    this.m_CamInited = false;
                    return ;
                }
            }
            try
            {
                tis.LiveDisplayDefault = false;
                tis.LiveCaptureContinuous = true;
                tis.MemoryCurrentGrabberColorformat = TIS.Imaging.ICImagingControlColorformats.ICY800;
                tis.ImageAvailable += new EventHandler<ICImagingControl.ImageAvailableEventArgs>(tis_ImageAvailable);
            }
            catch (Exception e1)
            {
                Global.Print1.PrintingExcptInfo.Add("初始化相机发生错误" + e1.Message ); 
                this.m_CamInited = false;
            }
        }

        private void tis_ImageAvailable(object sender, TIS.Imaging.ICImagingControl.ImageAvailableEventArgs e)
        {
            m_CamInited = true;
            if (hWhindowCtl == null) return;
            m_hi_Image.GenImage1("byte", e.ImageBuffer.Size.Width, e.ImageBuffer.Size.Height, e.ImageBuffer.GetImageDataPtr());

            if (FirstFrame)
            {
                HOperatorSet.GetImageSize(m_hi_Image, out m_ht_ImgWidth, out m_ht_ImgHeight);
                this.SetShowMode(m_modeShow);
                FirstFrame = false;
            }
            //HOperatorSet.DispObj(m_hi_Image, hWhindowCtl.HalconWindow);
        }

        public bool ShowSettings()
        {
            Close();
            try
            {
                if (tis.ShowDeviceSettingsDialog() == DialogResult.OK) tis.SaveDeviceStateToFile("device.xml");
                return true;
            }
            catch (Exception e1)
            {
                Global.Print1.PrintingExcptInfo.Add(e1.Message);
                return false;
            }
        }

        public void StartGrab()
        {
            if(m_CamInited )    tis.LiveStart();
        }
        public bool IsValid()
        {
            return tis.DeviceValid;
        }
        public void StopGrab()
        {
            if (m_CamInited) tis.LiveStop();
        }

        public void Close()
        {
            try
            {
                if (tis.DeviceValid)
                    tis.LiveStop();
            }
            catch (Exception e1)
            {
                Global.Print1.PrintingExcptInfo.Add(e1.Message);
            }
        }

        public void SetShowMode(ushort mode)//0实际大小显示，1为拉伸显示
        {
            m_modeShow = mode;
            if (mode == 0)
            {
                HOperatorSet.SetPart(hWhindowCtl.HalconWindow, 0, 0, hWhindowCtl.Height - 1, hWhindowCtl.Width - 1);
            }
            else if (mode == 1)//拉伸显示
                HOperatorSet.SetPart(hWhindowCtl.HalconWindow, 0, 0, m_ht_ImgHeight - 1, m_ht_ImgWidth - 1);
        }

        public bool ShowInPictureBox(PictureBox pb, uint mode) // mode为显示方式
        {
            if (m_ht_ImgWidth == 0 || m_ht_ImgHeight == 0) return false;
            HTuple pb_Window;
            HOperatorSet.OpenWindow(0, 0, pb.Width, pb.Height, pb.Handle, "visible", "", out pb_Window);
            int  row1 = 0, col1 = 0;
            int  row2 = pb.Height - 1, col2 = pb.Width - 1; //缺省是实际大小显示
            if (mode == 1) //拉伸显示
            {
                row2 = (int)m_ht_ImgHeight - 1;
                col2 = (int)m_ht_ImgWidth - 1;
            }

            if (mode == 4) //原大小显示图像中心
            {
                row1 = (int)m_ht_ImgHeight / 2 - pb.Height / 2;
                col1 = (int)m_ht_ImgWidth / 2 - pb.Width  / 2;
                row2 = row1 + pb.Height;
                col2 = col1+ pb.Width; 
            }
           
            HOperatorSet.SetPart(pb_Window, row1, col1, row2, col2);
            HOperatorSet.DispObj(m_hi_Image, pb_Window);
            return true;
        }

        public bool ShowLenCalibrate()
        {
            StopGrab();
            FormCalibrate frmCali = new FormCalibrate();
            if (!ShowInPictureBox(frmCali.pictureBox1, 4))//4是实际像素显示图像中心
            {
                frmCali.Dispose(); 
                StartGrab();
                return false;
            }
            frmCali.ShowDialog();
            if (frmCali.m_result == 0)
            {
                this.m_MmPerPixel = frmCali.m_MmPerPixel;
                this.m_LenCalibrated = true;
                StartGrab();
                return true;
            }
            else
            {
                StartGrab();
                return false ;
            }
        }
        
        public bool ShowSample()
        {
            if (!m_LenCalibrated ) return false;
            if (m_hi_Image == null) return false;
            FormSample frmSmpl = new FormSample();
            frmSmpl.m_Image = new HalconDotNet.HImage(m_hi_Image);
            frmSmpl.ShowDialog();
            if (frmSmpl.m_result == 0) //代表成功
            {
                this.m_SampleArea = frmSmpl.m_Area ;
                this.m_SampleCenter = new PointF();
                m_SampleCenter.X  =(float )( frmSmpl.m_pCenter.X * m_MmPerPixel );
                m_SampleCenter.Y = (float)(frmSmpl.m_pCenter.Y * m_MmPerPixel);
                m_Sampled = true; 
                return true;
            }
            else
                return false;
        }
        public bool GetMarkCenter()
        {
            if (m_MmPerPixel == 0) return false;
            StopGrab();
            bool rst = _GetMarkCenter();
            StartGrab();
            return rst;
        }
        private bool _GetMarkCenter()
        {
            if (m_hi_Image  == null) return false;
            HImage image = new HImage(m_hi_Image);
            // Local iconic variables 

            HObject ho_ROI_0, ho_ImageReduced, ho_ImagePart, ho_Thresholed, ho_RegionClosing, ho_ConnectedRegions, ho_SelectedRegions, ho_TargetRegion;

            HTuple hv_ROI_row1 = null, hv_ROI_col1 = null, hv_ROI_row2 = null, hv_ROI_col2 = null;

            HTuple hv_Row1 = new HTuple(), hv_Column1 = new HTuple(), hv_area = new HTuple();

            // Initialize local and output iconic variables 

            HOperatorSet.GenEmptyObj(out ho_ROI_0);
            HOperatorSet.GenEmptyObj(out ho_ImageReduced);
            HOperatorSet.GenEmptyObj(out ho_ImagePart);
            HOperatorSet.GenEmptyObj(out ho_Thresholed);
            HOperatorSet.GenEmptyObj(out ho_RegionClosing);
            HOperatorSet.GenEmptyObj(out ho_ConnectedRegions);
            HOperatorSet.GenEmptyObj(out ho_SelectedRegions);
            HOperatorSet.GenEmptyObj(out ho_TargetRegion); 

            hv_ROI_row1 = 1;
            hv_ROI_col1 = 1;
            hv_ROI_row2 = (HTuple)(m_ht_ImgHeight - 2);
            hv_ROI_col2 = (HTuple)(m_ht_ImgWidth -2);

            ho_ROI_0.Dispose();
            HOperatorSet.GenRectangle1(out ho_ROI_0, hv_ROI_row1, hv_ROI_col1, hv_ROI_row2, hv_ROI_col2);

            ho_ImageReduced.Dispose();
            HOperatorSet.ReduceDomain(image, ho_ROI_0, out ho_ImageReduced);
            ho_ImagePart.Dispose();
            HOperatorSet.CropDomain(ho_ImageReduced, out ho_ImagePart);

            ho_Thresholed.Dispose();
            HOperatorSet.Threshold(ho_ImagePart, out ho_Thresholed, 0, 128);

            ho_RegionClosing.Dispose();
            HOperatorSet.ClosingCircle(ho_Thresholed, out ho_RegionClosing, 5);
            ho_ConnectedRegions.Dispose();
            HOperatorSet.Connection(ho_RegionClosing, out ho_ConnectedRegions);
            ho_SelectedRegions.Dispose();
            ho_ROI_0.Dispose();
            ho_ImageReduced.Dispose();
            ho_ImagePart.Dispose();
            ho_Thresholed.Dispose();
            ho_RegionClosing.Dispose();
           
            HTuple numOfRegion = new HTuple ();
            double min =0.95,max = 1.05;
            do  //首先根据region的面积进行筛选
            {
                HOperatorSet.SelectShape(ho_ConnectedRegions, out ho_SelectedRegions, "area", "and", (HTuple)(m_SampleArea * 0.95), (HTuple)(m_SampleArea * 0.105));
                HOperatorSet.CountObj(ho_SelectedRegions, out numOfRegion);
                if (numOfRegion > 0 || min < 0.5)
                    break;
                else
                {
                    min -= 0.05;
                    max += 0.05;
                }
            } while (true);
            if(numOfRegion == 0) //如果没有选出来报错退出
            {
                 ho_ConnectedRegions.Dispose();
                 ho_SelectedRegions.Dispose();
                 return false;
            }
            else if (numOfRegion > 1)
            {
                min = 0.95;
                max = 1.05;
                do
                {
                    HOperatorSet.SelectShape(ho_SelectedRegions, out ho_TargetRegion, "width", "and", (HTuple)(m_SampleWidth * 0.95), (HTuple)(m_SampleWidth * 0.105));
                    HOperatorSet.CountObj(ho_SelectedRegions, out numOfRegion);
                    if (numOfRegion > 0 || min < 0.5)
                        break;
                    else
                    {
                        min -= 0.05;
                        max += 0.05;
                    }
                } while (true);
                if (numOfRegion != 1)// 如果根据面积选出来的多个region并没有一个符合宽度特征
                {
                    ho_ConnectedRegions.Dispose();
                    ho_SelectedRegions.Dispose();
                    ho_TargetRegion.Dispose();
                    return false;
                }
                HOperatorSet.AreaCenter(ho_TargetRegion, out hv_area, out hv_Row1, out hv_Column1); //求选出的region中心
                      
            }
            else // 如果直接筛选出一个
            {
                HOperatorSet.AreaCenter(ho_SelectedRegions, out hv_area, out hv_Row1, out hv_Column1); //求选出的region中心
            }
            
            PointF pCenter = new PointF();
            pCenter.Y = hv_Row1.TupleReal() * m_MmPerPixel ;
            pCenter.X = hv_Column1.TupleReal() * m_MmPerPixel;
            m_MarkCenter = pCenter;
            return true;
       }
    }
}