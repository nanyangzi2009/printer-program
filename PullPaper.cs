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
    public partial class PullPaper : Form
    {
        private bool m_PullerModified =false;
        private bool m_PrintModified = false;
        public PullPaper()
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
            this.txtManualV.Enter += new EventHandler(textBox_Enter);
            this.txtPulsePRev.Enter += new EventHandler(textBox_Enter);

            this.txtSendDelay.Enter += new EventHandler(textBox_Enter);
            this.txtUVAdv.Enter += new EventHandler(textBox_Enter);
            this.txtUVDelay.Enter += new EventHandler(textBox_Enter);
         }
        private void textBox_Enter(object sender, EventArgs e)
        {
            Global.GetKeyboardNum(sender); 
        }

        private void PullPaper_Load(object sender, EventArgs e)
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
            Global.Spatula1.GetSpeedRef(out dStartVel, out dMaxVel, out dTacc, out dTdec, out dStopVel, out dS_para, out dBack, out dManual);
            txtAccT.Text = dTacc.ToString("f3");
            txtDecT.Text = dTdec.ToString("f3");
            txtMaxV.Text = dMaxVel.ToString("f3");
            txtST.Text = dS_para.ToString("f3");
            txtStartV.Text = dStartVel.ToString("f3");
            txtStopV.Text = dStopVel.ToString("f3");
            txtManualV.Text = dManual.ToString("f3");


            //以下处理基本参数
            ushort pulsemode = Global.PaperPuller1.m_Motor.GetPulseMode();
            bool screwDirection = Global.PaperPuller1.m_Motor.GetDirection() ;
            if (pulsemode == 0 || pulsemode == 1)
                radioPulseP.Checked = true;
            else
                radioPulseN.Checked = true;
            if (screwDirection)
                radioXP.Checked = true;
            else
                radioXN.Checked = true;

            txtDiameter.Text = Global.PaperPuller1.m_Motor.m_Diameter.ToString("f3");
            txtReduceRatio.Text = Global.PaperPuller1.m_Motor.m_ReduceRatio.ToString("f3");
            txtPulsePRev.Text = Global.PaperPuller1.m_Motor.m_PulsePerRev.ToString();

            //处理三个时间参数
            txtSendDelay.Text = Global.Print1.m_TSendDelay.ToString();
            txtUVAdv.Text = Global.Print1.m_TUVAdvance .ToString();
            txtUVDelay.Text = Global.Print1.m_TUVDelay.ToString();    

            //以下处理开关
            if(Global.Print1.m_SwtInPaperPomp  ) 
                rdoInPompOn.Checked =true ;
            else
                rdoInPompOff.Checked =true;
            if (Global.Print1.m_SwtSpotLight)
                rdoSpotOn.Checked =true ;
            else
                rdoSpotOff .Checked =true ;
            if (Global.Print1.m_SwtLightBox)
                rdoLightOn.Checked = true;
            else
                rdoLightOff.Checked = true;
            if (Global.Print1.m_SwtBlow )
                this.rdoBlowOn .Checked = true;
            else
                rdoBlowOff.Checked = true;
            if (Global.Print1.m_SwtPomping)
                this.rdoPompOn.Checked = true;
            else
                rdoPompOff.Checked = true;
        }

        private void btnSetV_Click(object sender, EventArgs e)
        {
            double dStartVel;//起始速度
            double dMaxVel;//运行速度
            double dTacc;//加速时间
            double dTdec;//减速时间
            double dStopVel;//停止速度
            double dS_para;//S段时间
            double dManual;//手动速度

            //ushort sPosi_mode; //运动模式0：相对坐标模式，1：绝对坐标模式

            dStartVel = double.Parse(this.txtStartV.Text);
            dMaxVel = double.Parse(this.txtMaxV.Text);
            dTacc = double.Parse(this.txtAccT.Text);
            dTdec = double.Parse(this.txtDecT.Text);
            dStopVel = double.Parse(this.txtStopV.Text);
            dS_para = double.Parse(this.txtST.Text);
            dManual = double.Parse(this.txtManualV.Text);

            Global.PaperPuller1.SetPullerVel (dStartVel, dMaxVel, dTacc, dTdec, dStopVel, dS_para, dManual);
            m_PullerModified = true;
        }

        private void button7_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        
        private void btnSetBasic_Click(object sender, EventArgs e)
        {
            if (radioPulseP.Checked)
                Global.PaperPuller1.m_Motor.SetPulseMode(0);
            else
                Global.PaperPuller1.m_Motor.SetPulseMode(2);
            Global.PaperPuller1.m_Motor.SetDirection (radioXP.Checked);
            Global.PaperPuller1.m_Motor.m_Diameter = double.Parse(txtDiameter.Text);
            Global.PaperPuller1.m_Motor.m_PulsePerRev = int.Parse(txtPulsePRev.Text);
            m_PullerModified = true; 
        }

       private void btnDiaInc_Click(object sender, EventArgs e)
        {
            DiaAdjust(true); 
        }
        private void DiaAdjust( bool inc) //inc 为true表示增加，否则为递减
        {
            double dia = double.Parse(this.txtDiameter.Text);
            if (inc)
                dia += 0.01;
            else
                dia -= 0.01;
            txtDiameter.Text = dia.ToString("f3");
        }

        private void btnDiaDec_Click(object sender, EventArgs e)
        {
            DiaAdjust(false);
        }

        private void btnSetTimeSwitch_Click(object sender, EventArgs e)
        {
            Global.Print1.m_SwtInPaperPomp = rdoInPompOn.Checked;
            Global.Print1.m_SwtLightBox= rdoLightOn.Checked;
            Global.Print1.m_SwtSpotLight= rdoSpotOn.Checked;
            Global.Print1.m_SwtBlow = rdoBlowOn.Checked;
            Global.Print1.m_SwtPomping = rdoPompOn.Checked;

            Global.Print1.m_TSendDelay  = int.Parse(txtSendDelay.Text);
            Global.Print1.m_TUVAdvance = int.Parse(txtUVAdv.Text);
            Global.Print1.m_TUVDelay = int.Parse(txtUVDelay.Text);
            m_PrintModified = true;
        }

        private void PullPaper_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (m_PullerModified) Global.WritePullerToFile();
            if (m_PrintModified) Global.WritePrintToFile();  
        }
      }
}
