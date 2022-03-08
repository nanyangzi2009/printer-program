using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Diagnostics;
using csMotion;

namespace PrintInterface
{
    public partial class frmAdjustCamera : Form
    {
        
        public frmAdjustCamera()
        {
            InitializeComponent();
            //m_ScrewLen = 150;
            this.txtLeftStep.Enter += new EventHandler(textBox_Enter);
            this.txtRightStep.Enter += new EventHandler(textBox_Enter);
            txtPltAngle.Enter += new EventHandler(textBox_Enter);
            txtPltStep.Enter += new EventHandler(textBox_Enter);
        }
        private void textBox_Enter(object sender, EventArgs e)
        {
            Global.GetKeyboardNum(sender); 
        }

        private void frmAdjustCamera_Load(object sender, EventArgs e)
        {
            lblLCamPos.Text = Global.Platform1.m_LeftCam.GetCurrentPos().ToString("f3");
            lblRCamPos.Text = Global.Platform1.m_RightCam.GetCurrentPos().ToString("f3");

            //先平台归零
            foreach (Control ctl in this.Controls)
            {
                if (ctl.Name == "btnPltZero" || ctl.Name == "grpPlt")
                    ctl.Enabled = true;
                else
                    ctl.Enabled = false;
            }
            Global.Print1.PrintingInfo = "请先把平台归零";
         }

        private void btnLeftZero_Click(object sender, EventArgs e)
        {
            Global.Card0.InvalidNegLimit(Global.Platform1.m_LeftCam.m_ScrewIdx);   //相机的负限位无效
            Global.Platform1.m_LeftCam.MoveToHome();
            Global.Platform1.m_LeftCam.m_OrgCalibrated = true;
            Global.Card0.ResetLimitsMode(Global.Platform1.m_LeftCam.m_ScrewIdx); //恢复相机负限位有效
            Global.Print1.PrintingInfo = "请把右相机归零";
            grpRCam.Enabled = true;
            foreach (Control ctl in this.grpRCam.Controls)
            {
                if (ctl.Name == "btnRightZero")
                    ctl.Enabled = true;
                else
                    ctl.Enabled = false;
            }
        }

        private void btnRightZero_Click(object sender, EventArgs e)
        {
            Global.Card0.InvalidNegLimit(Global.Platform1.m_RightCam.m_ScrewIdx);//相机的负限位无效
            Global.Platform1.m_RightCam.MoveToHome();
            Global.Platform1.m_LeftCam.m_OrgCalibrated = true;
            Global.Card0.ResetLimitsMode(Global.Platform1.m_RightCam.m_ScrewIdx); //恢复相机负限位有效
            Global.Print1.PrintingInfo = "请把两相机调整到图像中心最接近网板mark点的位置";
            foreach (Control ctl in this.Controls)
            {
                ctl.Enabled = true;
            }
        }
        

        private void btnOK_Click(object sender, EventArgs e)
        {
            Global.Platform1.SetCurrentToWorkPostion() ;
            Global.Platform1.m_LeftCam.SetCurrentToWorkPos() ;
            Global.Platform1.m_RightCam.SetCurrentToWorkPos() ;
            Global.WritePltToFile();
            MessageBox.Show("相机调整成功！");
         }

        private void btnPltZero_Click(object sender, EventArgs e)
        {
            Global.Platform1.MoveToHome();
            grpLCam.Enabled = true;
            foreach (Control ctl in this.grpLCam.Controls)
            {
                if (ctl.Name == "btnLeftZero")
                    ctl.Enabled = true;
                else
                    ctl.Enabled = false;
            }
            Global.Print1.PrintingInfo = "请把左相机归零";   
        }

        private void btnLCamLeft_Click(object sender, EventArgs e)
        {
            if (Global.Platform1.m_LeftCam == null) return;
            if(Global.Platform1.m_LeftCam.IsStop ())
                Global.Platform1.m_LeftCam.Move(- double.Parse (txtLeftStep.Text ));   
        }

        private void btnLCamRgiht_Click(object sender, EventArgs e)
        {
            if (Global.Platform1.m_LeftCam == null) return;
            if (Global.Platform1.m_LeftCam.IsStop())
                Global.Platform1.m_LeftCam.Move(double.Parse(txtLeftStep.Text));      
        }

        private void btnRCamLeft_Click(object sender, EventArgs e)
        {
            if (Global.Platform1.m_LeftCam == null) return;
            if (Global.Platform1.m_RightCam.IsStop())
                Global.Platform1.m_RightCam.Move(double.Parse(txtRightStep.Text));   
        }

        private void btnRCamRight_Click(object sender, EventArgs e)
        {
            if (Global.Platform1.m_LeftCam == null) return;
            if (Global.Platform1.m_RightCam.IsStop())
                Global.Platform1.m_RightCam.Move(- double.Parse(txtRightStep.Text)); 
        }

        private void btnPltUp_Click(object sender, EventArgs e)
        {
            if (Global.Platform1.PltIsStop())
                Global.Platform1.TranslateMove(0, double.Parse(txtPltStep.Text  ));
        }

        private void btnPltDown_Click(object sender, EventArgs e)
        {
            if (Global.Platform1.PltIsStop())
                Global.Platform1.TranslateMove(0, - double.Parse(txtPltStep.Text));
        }

        private void btnPltLeft_Click(object sender, EventArgs e)
        {
            if (Global.Platform1.PltIsStop())
                Global.Platform1.TranslateMove(double.Parse(txtPltStep.Text),0);
        }

        private void btnPltRight_Click(object sender, EventArgs e)
        {
            if (Global.Platform1.PltIsStop())
                Global.Platform1.TranslateMove(-double.Parse(txtPltStep.Text), 0);
        }

        private void btnPltRotate_Click(object sender, EventArgs e)
        {
            if (!Global.Platform1.PltIsStop()) return ;
            double angle= double.Parse (txtPltAngle.Text )*2 *3.1415926 /360;
            if(rdoCW.Checked ) angle = -angle;
            PointF pCenter = new PointF();
            pCenter.X = (float )(Global.Platform1.m_LeftCam.m_ZeroPoint.X - Global.Platform1.m_LeftCam.GetCurrentPos() + Global.Platform1.m_RightCam.m_ZeroPoint.X + Global.Platform1.m_LeftCam.GetCurrentPos()) / 2;
            pCenter.Y = (float)(Global.Platform1.m_LeftCam.m_ZeroPoint.Y + Global.Platform1.m_RightCam.m_ZeroPoint.Y ) / 2; 
            Global.Platform1.RotateMove(pCenter ,angle );
        }

        private void btnExit_Click(object sender, EventArgs e)
        {
            this.Close();
        }

    }
}
