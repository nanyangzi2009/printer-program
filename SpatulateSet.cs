using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using csMotion;
namespace PrintInterface
{
    public partial class SpatulateSet : Form
    {
        private bool m_SptModified=false ;
        public SpatulateSet()
        {
            InitializeComponent();
            this.txtAccT.Enter += new EventHandler(textBox_Enter);  //获得焦点事件
            this.txtDecT.Enter += new EventHandler(textBox_Enter);
            this.txtDiameter.Enter += new EventHandler(textBox_Enter);
            this.txtMaxV.Enter += new EventHandler(textBox_Enter);
            this.txtReduceRatio.Enter += new EventHandler(textBox_Enter);
            this.txtST.Enter += new EventHandler(textBox_Enter);
            this.txtStartV.Enter += new EventHandler(textBox_Enter);
            this.txtStopV.Enter += new EventHandler(textBox_Enter);
            this.txtBackV.Enter += new EventHandler(textBox_Enter);
            this.txtManualV.Enter += new EventHandler(textBox_Enter);
            this.txtPulsePRev.Enter += new EventHandler(textBox_Enter);
            this.txtToBackTime.Enter += new EventHandler(textBox_Enter); 
        }

        private void textBox_Enter(object sender, EventArgs e)
        {
            Global.GetKeyboardNum(sender); 
        }

        private void btnSetV_Click(object sender, EventArgs e)
        {
            double dStartVel;//起始速度
            double dMaxVel;//运行速度
            double dTacc;//加速时间
            double dTdec;//减速时间
            double dStopVel;//停止速度
            double dS_para;//S段时间
            double dBack;//回墨刀速度
            double dManual;//手动速度

            //ushort sPosi_mode; //运动模式0：相对坐标模式，1：绝对坐标模式

            dStartVel = double.Parse(this.txtStartV.Text);
            dMaxVel = double.Parse(this.txtMaxV.Text);
            dTacc = double.Parse(this.txtAccT.Text);
            dTdec = double.Parse(this.txtDecT.Text);
            dStopVel = double.Parse(this.txtStopV.Text);
            dS_para = double.Parse(this.txtST.Text);
            dBack = double.Parse(this.txtBackV.Text);
            dManual = double.Parse(this.txtManualV.Text);

            Global.Spatula1.SetSptVel(dStartVel, dMaxVel, dTacc, dTdec, dStopVel, dS_para,dBack,dManual );
            Global.Spatula1.m_SptToBackTime = int.Parse(txtToBackTime.Text );
            m_SptModified = true;
        }

        private void SpatulateSet_Load(object sender, EventArgs e)
        {
            Global.CenterForm(this);
            //以下处理速度参数
            double dStartVel;//起始速度
            double dMaxVel;//运行速度
            double dTacc;//加速时间
            double dTdec;//减速时间
            double dStopVel;//停止速度
            double dS_para;//S段时间
            double dBack;//回墨刀速度
            double dManual;//手动速度
            Global.Spatula1.GetSpeedRef(out dStartVel, out dMaxVel, out dTacc, out dTdec, out dStopVel, out dS_para,out dBack ,out dManual );
            txtAccT.Text = dTacc.ToString("f3");
            txtDecT.Text = dTdec.ToString("f3");
            txtMaxV.Text = dMaxVel.ToString("f3");
            txtST.Text = dS_para.ToString("f3");
            txtStartV.Text = dStartVel.ToString("f3");
            txtStopV.Text = dStopVel.ToString("f3");
            txtBackV.Text = dBack.ToString("f3");
            txtManualV.Text = dManual.ToString("f3");
            txtToBackTime.Text = Global.Spatula1.m_SptToBackTime.ToString ();  

            //以下处理基本参数
            ushort pulsemode = Global.Spatula1.GetPulseMode();
            bool screwDirection = Global.Spatula1.m_Motor.GetDirection() ; 
            if (pulsemode == 0 || pulsemode == 1)
                radioPulseP.Checked = true;
            else
                radioPulseN.Checked = true;
            if (screwDirection)
                radioXP.Checked = true;
            else
                radioXN.Checked = true;
            
            txtDiameter.Text = Global.Spatula1.m_Motor.m_Diameter.ToString("f3");
            txtReduceRatio.Text = Global.Spatula1.m_Motor.m_ReduceRatio.ToString("f3");
            txtPulsePRev.Text = Global.Spatula1.m_Motor.m_PulsePerRev.ToString();

            //以下处理刮刀归零参数
            bool dir,highspeed;
            ushort mode;
            
            Global.Spatula1.m_Motor.GetHomeRef(out dir, out highspeed, out mode);
            if (mode == 0)
                radioMOnce.Checked = true;
            else if (mode == 1)
                radioMBack.Checked = true;
            else if (mode == 2)
                radioMTwice.Checked = true;
            else if (mode ==3)
                radioM1EZ.Checked = true;
            else
                radioMEZ.Checked = true;

            if(!dir)
                radioHDirN.Checked = true;
            else
                radioHDirP.Checked = true;

            if(!highspeed )
                radioHVLow.Checked = true;
            else
                radioHVHigh.Checked = true; 
        }

        private void btnDiaDec_Click(object sender, EventArgs e)
        {
            MicroAjust(txtDiameter , false );
        }

        private void btnDiaInc_Click(object sender, EventArgs e)
        {
            MicroAjust(txtDiameter, true);
        }

        private void MicroAjust(TextBox tb, bool inc)
        {
            try
            {
                double dia = double.Parse(tb.Text);
                if (inc)
                    dia += 0.01;
                else
                    dia -= 0.01;
                tb.Text = dia.ToString("f3");
            }
            catch (Exception e1)
            {
                MessageBox.Show(e1.Message);
            }
        }

        private void btnRatioDec_Click(object sender, EventArgs e)
        {
            MicroAjust(txtReduceRatio, false);
        }

        private void btnRatioInc_Click(object sender, EventArgs e)
        {
            MicroAjust(txtReduceRatio, true);
        }

        private void btnSetBasic_Click(object sender, EventArgs e)
        {
            try
            {
                if (radioPulseP.Checked)
                    Global.Spatula1.SetMotorPulseMode(0);
                else
                    Global.Spatula1.SetMotorPulseMode(2);

                Global.Spatula1.m_Motor.m_Diameter = double.Parse(txtDiameter.Text);
                Global.Spatula1.m_Motor.m_ReduceRatio = double.Parse(txtReduceRatio.Text);
                Global.Spatula1.m_Motor.m_PulsePerRev = int.Parse(txtPulsePRev.Text);
                Global.Spatula1.m_Motor.SetDirection(radioXP.Checked);
                Global.Spatula1.m_Motor.ResetCoMmToPulse();
 
                m_SptModified = true;
            }
            catch(Exception e1)
            {
                MessageBox.Show(e1.Message );
            }
        }

        private void button7_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnSetHome_Click(object sender, EventArgs e)
        {
            ushort mode;
            bool  dir, highspeed;
            if (radioMOnce.Checked)
                mode = 0;
            else if (radioMBack.Checked)
                mode = 1;
            else if (radioMTwice.Checked)
                mode = 2;
            else if (radioM1EZ.Checked)
                mode = 3;
            else
                mode = 4;
            if (radioHDirP.Checked)
                dir = true ;
            else
                dir = false ;
            if (radioHVLow.Checked)
                highspeed = false;
            else
                highspeed = true;
            Global.Spatula1.m_Motor.SetHomeRef(dir, highspeed, mode);
            m_SptModified = true;
        }

        private void SpatulateSet_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (m_SptModified) Global.WriteSpatulaToFile();  
        }

        
    }
}
