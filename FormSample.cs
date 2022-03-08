using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using HalconDotNet;

namespace PrintInterface
{
    
    public partial class FormSample : Form
    {
        public HImage m_Image;
        private Rectangle m_RectSample;
        public int m_result; //-1 表示返回，0 表示成功， 1 表示失败
        public PointF m_pCenter;
        public double m_Area;

        private HTuple winSmall;
        private HTuple winBig;
        private Point StartP=new Point (0,0);
        private int imgWidth, imgHeight;
        
        private int MoveStep=10;
        
        public FormSample()
        {
            InitializeComponent();
             
        }

      
        private void FormSample_Load(object sender, EventArgs e)
        {
            HOperatorSet.OpenWindow(0, 0, picSmall.Width, picSmall.Height, picSmall.Handle, "visible", "", out winSmall);
            HOperatorSet.OpenWindow(0, 0, picBig.Width, picBig.Height, picBig.Handle, "visible", "", out winBig);
            HTuple imgW =0, imgH =0;
            if (m_Image == null)
            {
                m_result = 1;
                this.Close();
                return;
            }
            HOperatorSet.GetImageSize(m_Image , out imgW , out imgH );
            
            imgWidth = imgW;
            imgHeight = imgH;
            m_RectSample = new Rectangle(100, 100, 400, 400);
            HOperatorSet.SetPart(winSmall  ,0,0,imgH-1 ,imgW-1 );
            HOperatorSet.SetPart(winBig, 0, 0, picBig.Height-1, picBig.Width  - 1);
            DrawSampleFrame();
            LineSelected.Visible = false;
            
        }
       
        private void SelectLine()
        {
            //设置选择线的大小
            if (this.rdoUp.Checked || rdoBottom.Checked  )
                LineSelected.Size= new Size (m_RectSample.Width ,1); 
            else
                LineSelected.Size = new Size(1, m_RectSample.Height );
            //设置选择线位置
            if (this.rdoUp.Checked || rdoLeft.Checked)
                LineSelected.Location = new Point (m_RectSample.X - StartP.X , m_RectSample.Y -StartP.Y  );
            else if (rdoRight.Checked)
                LineSelected.Location = new Point(m_RectSample.X - StartP.X + m_RectSample.Width, m_RectSample.Y - StartP.Y);
            else
                LineSelected.Location = new Point(m_RectSample.X - StartP.X, m_RectSample.Y + m_RectSample.Height - StartP.Y);
           //选择线可见
            LineSelected.Visible = true; 
        }
       


      
        private void btnExit_Click(object sender, EventArgs e)
        {
            m_Image.Dispose(); 
            m_result = -1;
            this.Close();
        }


        private void btnOK_Click(object sender, EventArgs e)
        {
            if (!GetSampleAreaCenter())return;
            m_Image.Dispose(); 
            m_result = 0; 
            this.Close();
        }

        private bool GetSampleAreaCenter()
        {
            if (m_Image == null) return false;
            // Local iconic variables 

            HObject ho_ROI_0, ho_ImageReduced, ho_ImagePart, ho_Thresholed, ho_RegionClosing, ho_ConnectedRegions, ho_SelectedRegions,ho_CrossRegion;

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
            HOperatorSet.GenEmptyObj(out ho_CrossRegion); 

            hv_ROI_row1 = (HTuple)(m_RectSample.Y);
            hv_ROI_col1 = (HTuple)(m_RectSample.X);
            hv_ROI_row2 = (HTuple)(m_RectSample.Bottom);
            hv_ROI_col2 = (HTuple)(m_RectSample.Right);

            ho_ROI_0.Dispose();
            HOperatorSet.GenRectangle1(out ho_ROI_0, hv_ROI_row1, hv_ROI_col1, hv_ROI_row2, hv_ROI_col2);

            ho_ImageReduced.Dispose();
            HOperatorSet.ReduceDomain(m_Image, ho_ROI_0, out ho_ImageReduced);
            ho_ImagePart.Dispose();
            HOperatorSet.CropDomain(ho_ImageReduced, out ho_ImagePart);

            ho_Thresholed.Dispose();
            HOperatorSet.Threshold(ho_ImagePart, out ho_Thresholed, 0, 128);

            ho_RegionClosing.Dispose();
            HOperatorSet.ClosingCircle(ho_Thresholed, out ho_RegionClosing, 5);
            ho_ConnectedRegions.Dispose();
            HOperatorSet.Connection(ho_RegionClosing, out ho_ConnectedRegions);
            ho_SelectedRegions.Dispose();
            HOperatorSet.SelectShapeStd(ho_ConnectedRegions, out ho_SelectedRegions, "max_area", 0);
            HOperatorSet.AreaCenter(ho_SelectedRegions, out hv_area, out hv_Row1, out hv_ROI_col1);
            HOperatorSet.DispObj(ho_SelectedRegions, winSmall);
            HOperatorSet.DispObj(ho_SelectedRegions, winBig);
            //HOperatorSet.SmallestRectangle1(ho_SelectedRegions, out hv_Row1, out hv_Column1, out hv_Row2, out hv_Column2);
            
            HOperatorSet.GenCrossContourXld(out ho_CrossRegion ,hv_Row1 , hv_Column1 ,20 ,0);//用十字显示中心位置
            HOperatorSet.DispObj(ho_CrossRegion, winSmall);
            HOperatorSet.DispObj(ho_CrossRegion, winBig);
            ho_ROI_0.Dispose();
            ho_ImageReduced.Dispose();
            ho_ImagePart.Dispose();
            ho_Thresholed.Dispose();
            ho_RegionClosing.Dispose();
            ho_ConnectedRegions.Dispose();
            ho_SelectedRegions.Dispose();
            ho_CrossRegion.Dispose();
             
            DialogResult rst = MessageBox.Show(this, "图中是否采样图像的中心和边界？", "采样", MessageBoxButtons.YesNo);
            if (rst == DialogResult.Yes)
            {
                PointF pCenter = new PointF();
                pCenter.Y = hv_Row1.TupleReal();
                pCenter.X = hv_Column1.TupleReal();
                m_pCenter = pCenter;
                m_Area = hv_area;
                this.Close();
                return true;
            }
            return false ;
        }



        private void btnLeft_Click(object sender, EventArgs e)
        {
            int step = MoveStep;
            Point p = LineSelected.Location;

            if (rdoMoveImg.Checked)
            {
                if (StartP.X - MoveStep < 0)
                {
                    step = StartP.X;
                }
                if (step < 1) return;
                StartP.X -= step;
                ResetBigImg();
            }
            else if (rdoMoveFrm.Checked || rdoLeft.Checked)
            {
                if (this.m_RectSample.X - MoveStep < 0)
                {
                    step = m_RectSample.X;
                    if (step < 1) return;
                    m_RectSample.X = 0;
                }
                m_RectSample.X -= step;
                if (!rdoMoveFrm.Checked) //如果移动左边
                {
                    m_RectSample.Width += step;
                    p.X  -=  step;
                    LineSelected.Location = p;
                }
            }
            else //move right side
            {
                m_RectSample.Width -= step;
                p.X -=  step;
                LineSelected.Location = p;
            }
            DrawSampleFrame();
        }

        private void btnRight_Click(object sender, EventArgs e)
        {
            int step = MoveStep;
            Point p = new Point(LineSelected.Location.X, LineSelected.Location.Y);
           
            if (rdoMoveImg.Checked)
            {
                if (StartP.X + MoveStep > imgWidth - picBig.Width)step = imgWidth - picBig.Width - StartP.X;
                if (step < 1) return;
                StartP.X += step;
                ResetBigImg();
            }
            else if (rdoMoveFrm.Checked || rdoRight.Checked)
            {
                if (this.m_RectSample.Y + MoveStep > imgHeight - m_RectSample.Height)
                {
                    step = imgHeight - m_RectSample.Height - m_RectSample.Y;
                    if (step < 1) return;
                }

                if (rdoMoveFrm.Checked) // move right the selected rectangle
                    m_RectSample.X += step;
                else//如果移动右边
                {
                    m_RectSample.Width += step;
                    p.X += step;
                    LineSelected.Location = p;
                }
            }
            else// move left side
            {
                m_RectSample.X += step;
                m_RectSample.Width -= step;
                p.X += step;
                LineSelected.Location = p;
            }
            DrawSampleFrame();
        }

        private void rdoMoveFrm_CheckedChanged(object sender, EventArgs e)
        {
            if(rdoMoveFrm.Checked ) 
                PrepareToMove(); 
        }

        private void PrepareToMove()
        {
            LineSelected.Visible = false;
            grpSelect.Enabled = false;
            DrawSampleFrame();
            btnLeft.Enabled = true;
            btnRight.Enabled = true;
            btnUp.Enabled = true;
            btnDown.Enabled = true;
        }

        
        private void DrawSampleFrame() 
        {
            HObject rect = new HObject();
            if (rdoMoveFrm.Checked)
                HOperatorSet.SetColor(winBig, "red");
            else
                HOperatorSet.SetColor(winBig, "green");
            HOperatorSet.SetColor(winSmall, "blue");
            HOperatorSet.GenRectangle2ContourXld(out rect, (HTuple)(this.m_RectSample.Y + m_RectSample.Height * 0.5), (HTuple)(m_RectSample.X + m_RectSample.Width * 0.5), 0, (HTuple)(m_RectSample.Width / 2), (HTuple)(m_RectSample.Height / 2));
            HOperatorSet.DispObj(m_Image , winBig);
            HOperatorSet.DispObj(rect, winBig);
            HOperatorSet.DispObj(m_Image, winSmall);
            HOperatorSet.DispObj(rect, winSmall); 
            rect.Dispose();
        }

        private void rdoAjustFrm_CheckedChanged(object sender, EventArgs e)
        {
            if (rdoAjustFrmBorder.Checked)
            {
                grpSelect.Enabled = true;
                SelectLine();
                if (rdoUp.Checked || rdoBottom.Checked)
                {
                    SetUpdownEnabel(true);
                }
                else
                {
                    SetUpdownEnabel(false);
                }
                DrawSampleFrame();
            }
        }

        private void rdoUp_CheckedChanged(object sender, EventArgs e)
        {
            if (rdoUp.Checked)
            {
                SelectLine();
                SetUpdownEnabel(true);
            }
        }

        private void SetUpdownEnabel(bool on)
        {
            btnLeft.Enabled = !on;
            btnRight.Enabled = !on;
            btnUp.Enabled = on ;
            btnDown.Enabled = on;
        }

        private void rdoLeft_CheckedChanged(object sender, EventArgs e)
        {
            if (rdoLeft.Checked)
            {
                SelectLine();
                SetUpdownEnabel(false);
            }
        }

        private void rdoRight_CheckedChanged(object sender, EventArgs e)
        {
            if (rdoRight.Checked)
            {
                SelectLine();
                SetUpdownEnabel(false);
            }
        }

        private void rdoBottom_CheckedChanged(object sender, EventArgs e)
        {
            if (rdoBottom.Checked)
            {
                SelectLine();
                SetUpdownEnabel(true);
            }
        }

        private void rdoRough_CheckedChanged(object sender, EventArgs e)
        {
            this.MoveStep = 10;
        }

        private void rdoFine_CheckedChanged(object sender, EventArgs e)
        {
            this.MoveStep = 1;
        }
        private void ResetBigImg()
        {
            HOperatorSet.SetPart(winBig, StartP.Y, StartP.X, StartP.Y + picBig.Height - 1, StartP.X + picBig.Width - 1);
        }
        private void btnUp_Click(object sender, EventArgs e)
        {
            int step = MoveStep;
            Point p = LineSelected .Location;
 
            if (rdoMoveImg.Checked) //移动图像
            {
                if (StartP.Y - MoveStep < 0) step = StartP.Y;
                if (step < 1) return;
                StartP.Y -= step;
                ResetBigImg();
            }
            else if (rdoMoveFrm.Checked || rdoUp.Checked)
            {
                if (this.m_RectSample.Y - MoveStep < 0)
                {
                    step = m_RectSample.Y;
                    if (step < 1) return;
                }
                m_RectSample.Y -= step;
                if (!rdoMoveFrm.Checked) //如果移动上边
                {
                    m_RectSample.Height += step;
                    p.Y -= step;
                    LineSelected.Location = p;
                }
            }
            else //移动下边
            {
                m_RectSample.Height -= step;
                p.Y -= step;
                LineSelected.Location = p;
            }
            DrawSampleFrame();
        }

        private void btnDown_Click(object sender, EventArgs e)
        {
            int step = MoveStep;
            Point p = LineSelected.Location;
                    
            if (rdoMoveImg.Checked)
            {
                if (StartP.Y + MoveStep > imgHeight - picBig.Height) step = imgHeight - picBig.Height - StartP.Y;
                if (step < 1) return;
                StartP.Y += step;
                ResetBigImg();
            }
            else if (rdoMoveFrm.Checked || rdoBottom.Checked)
            {
                if (this.m_RectSample.Y + MoveStep > imgHeight - m_RectSample.Height)
                {
                    step = imgHeight - m_RectSample.Height - m_RectSample.Y;
                    if (step < 1) return;
                }

                if (rdoMoveFrm.Checked) //如果总体下移
                {
                    m_RectSample.Y += step;
                }
                else//如果移动下边
                {
                    m_RectSample.Height += step;
                    p.Y += step  ;
                    LineSelected.Location = p;
                }
            }
            else//move the upper side
            {
                m_RectSample.Height -= step;
                m_RectSample.Y += step;
                p.Y += step;
                LineSelected.Location = p;
            }
            DrawSampleFrame();
        }

        private void rdoMoveImg_CheckedChanged(object sender, EventArgs e)
        {
            if(rdoMoveImg.Checked )
                PrepareToMove();
        }
    }
}
