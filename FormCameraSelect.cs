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
    public partial class frmCameraSelect : Form
    {
        public int m_SelectedCam; // 0表示左，1，表示右, -1表示没有选
        //ICImagingControl tis = new ICImagingControl();

        public frmCameraSelect()
        {
            InitializeComponent();
            
        }

        private void button1_Click(object sender, EventArgs e)
        {
            m_SelectedCam = 0;
            this.Close();
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            m_SelectedCam = -1;
            this.Close();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            m_SelectedCam = 1;
            this.Close();
        }

        private void frmCameraSelect_Load(object sender, EventArgs e)
        {
            Global.CenterForm(this); 
        }
  }
}
