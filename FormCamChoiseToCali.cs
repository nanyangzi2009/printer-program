using System;
//using System.Collections.Generic;
//using System.ComponentModel;
//using System.Data;
//using System.Drawing;
//using System.Linq;
//using System.Text;
using System.Windows.Forms;
//using TIS.Imaging;
using csMotion;


namespace PrintInterface
{
    public partial class FormChoiceToCali : Form
    {
        public int m_result; // bit0表示左，bit1表示长度标定, -1表示没有选
        // -1，没有选； 0左相机标定长度；1右相机标定长度；2左相机标定方向；3 右相机标定方向
        //ICImagingControl tis = new ICImagingControl();

        public FormChoiceToCali()
        {
            InitializeComponent();
            
        }

       
        private void btnCancel_Click(object sender, EventArgs e)
        {
            m_result = -1;
            this.Close();
        }

       

        private void frmCameraSelect_Load(object sender, EventArgs e)
        {
            Global.CenterForm(this); 

        }

        private void btnOK_Click(object sender, EventArgs e)
        {
            if (rdoLeftCam.Checked)
            {
                if (rdoLength.Checked)
                    m_result = 0;
                else
                    m_result = 2;
            }
            else 
            {
                if (rdoLength.Checked)
                    m_result= 1;
                else
                    m_result= 3;
            }
            this.Close();
        }

        private void rdoLeftCam_CheckedChanged(object sender, EventArgs e)
        {
            if(rdoLeftCam.Checked )
                if(!Global.MainPage.CameraLeft.m_LenCalibrated)
                {
                    rdoLength.Checked = true; 
                    rdoDirection.Enabled = false;
                }
           
        }

        private void rdoRightCam_CheckedChanged(object sender, EventArgs e)
        {
            if (rdoRightCam.Checked)
                if (!Global.MainPage.CameraRight.m_LenCalibrated)
                {
                    rdoLength.Checked = true;
                    rdoDirection.Enabled = false;
                }
        }
  }
}
