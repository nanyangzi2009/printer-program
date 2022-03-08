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
    public partial class FormPrintSet : Form
    {
        private bool m_SpatulaModified = false;
        private bool m_PrintModified = false;
        private bool m_StartHome;
        private bool m_StartLeftLimit;
        public FormPrintSet()
        {
            InitializeComponent();
            m_StartHome = false;
            m_StartLeftLimit = false;
            this.txtBackDelay.Enter += new EventHandler(textBox_Enter);
            this.txtGoDelay.Enter += new EventHandler(textBox_Enter);
            this.txtLAdv.Enter += new EventHandler(textBox_Enter);
            this.txtLeftPos.Enter += new EventHandler(textBox_Enter);
            this.txtRAdv.Enter += new EventHandler(textBox_Enter);
            this.txtRightPos.Enter += new EventHandler(textBox_Enter);
            this.txtPullUnit.Enter += new EventHandler(textBox_Enter);
            this.txtPompDelay.Enter += new EventHandler(textBox_Enter);
            this.txtStopPompDelay.Enter += new EventHandler(textBox_Enter);
            this.txtBackNum .Enter += new EventHandler(textBox_Enter);
            this.txtPrtLen.Enter += new EventHandler(textBox_Enter);
            this.txtPrtCount.Enter += new EventHandler(textBox_Enter);
            this.txtPrtNum.Enter += new EventHandler(textBox_Enter);
            this.txtPrtStopNum.Enter += new EventHandler(textBox_Enter);
        }
        private void textBox_Enter(object sender, EventArgs e)
        {
            Global.GetKeyboardNum(sender); 
        }


        private void button6_Click(object sender, EventArgs e)
        {
            dynamic file = "C:\\Program Files\\Common Files\\microsoft shared\\ink\\TabTip.exe";
            Process.Start(file);
        }

        private void btnAdvance_Click(object sender, EventArgs e)
        {
            if (!Global.VerifyPassWord()) return;
            SpatulateSet spt = new SpatulateSet();
            spt.ShowDialog();
        }

        private void FormPrintSet_Load(object sender, EventArgs e)
        {
            //刮刀设置
            Global.CenterForm(this);
            txtLeftPos.Text = (Global.Spatula1.m_LeftWorkPos).ToString("f3");
            txtRightPos.Text = (Global.Spatula1.m_RightWorkPos).ToString("f3");
            double lAdv, rAdv, prtDelay, bacDelay;
            ushort bacNum;
            Global.Spatula1.GetPrintRef(out lAdv, out rAdv, out prtDelay, out bacDelay, out bacNum);
            txtLAdv.Text = lAdv.ToString("f3");
            txtRAdv.Text = rAdv.ToString("f3");
            txtGoDelay.Text = prtDelay.ToString("f3");
            txtBackDelay.Text = bacDelay.ToString("f3");
            txtBackNum.Text = bacNum.ToString();
            double len = Global.Spatula1.GetLenOfLimits(); //得到左右限位之间的总长
            lblTotalLen.Text = len.ToString("f3");

            //拉料设置
            txtPullUnit.Text =  Global.Print1.m_UnitLen.ToString("f3");
            txtPompDelay.Text = Global.Print1.m_PompDelay.ToString();
            txtStopPompDelay.Text = Global.Print1.m_StopPompDelay.ToString();
            txtPullLen.Text = txtPullUnit.Text;
            /*if (Global.PaperPuller1.m_PompAuto)
                rdoPompAuto.Checked = true;
            else
                rdoPompManual.Checked = true; */
            //印刷设置
            txtPrtNum.Text = Global.Print1.m_CurrentNum.ToString();
            txtPrtCount.Text = Global.Print1.m_TotalCount.ToString ();
            txtPrtLen.Text = Global.Print1.m_TotalLength.ToString ("f2");
            txtPrtStopNum.Text = Global.Print1.m_NumOfStop.ToString();
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            double pos = Global.Spatula1.m_Motor.GetCurrentPos();
            lblCurrentPos.Text = pos.ToString("f3");
            if (Global.Spatula1.IsSptStop())
            {
                if (m_StartLeftLimit)
                {
                    lblTotalLen.Text = lblCurrentPos.Text;
                    Global.Spatula1.SetLenOfLimits(pos);
                    m_StartLeftLimit = false;
                }
                if (m_StartHome)
                {
                    Global.Spatula1.ResetLimits(); //左右限位重置
                    m_StartHome = false; 
                }
                timer1.Enabled = false;
            }
        }

        private void btnLeftDec_Click(object sender, EventArgs e)
        {
            PosAdjust(txtLeftPos, false);
        }

        private void btnLeftInc_Click(object sender, EventArgs e)
        {
            PosAdjust(txtLeftPos, true);
        }

        private void PosAdjust(TextBox tb, bool inc) //inc 为true表示增加，否则为递减
        {
            double pos = double.Parse(tb.Text);
            if (inc)
                pos += 0.01;
            else
                pos -= 0.01;
            tb.Text = pos.ToString("f3");
        }

        private void btnRightDec_Click(object sender, EventArgs e)
        {
            PosAdjust(txtRightPos, false);
        }

        private void btnRightInc_Click(object sender, EventArgs e)
        {
            PosAdjust(txtRightPos, true);
        }

        private void btnToLeft_Click(object sender, EventArgs e)
        {
            if (timer1.Enabled)
            {
                MessageBox.Show("目前刮刀正在运动，等停下重按按钮");
                return;
            }
            Global.Spatula1.MoveTo(double.Parse(txtLeftPos.Text));
            timer1.Enabled = true;
        }

        private void btnToRight_Click(object sender, EventArgs e)
        {
            if (timer1.Enabled)
            {
                MessageBox.Show("目前刮刀正在运动，等停下重按按钮");
                return;
            }
            Global.Spatula1.MoveTo(double.Parse(txtRightPos.Text));
            timer1.Enabled = true;
        }

        private void btnHome_Click(object sender, EventArgs e)
        {
            if (timer1.Enabled)
            {
                MessageBox.Show("目前刮刀正在运动，等停下重按按钮");
                return;
            }
            Global.Spatula1.ProhibitRightLimit(); //刮刀禁用右限位，等做完回零运动然后再重置右限位允许。
            Global.Spatula1.MoveToHome();
            m_StartHome = true;
            timer1.Enabled = true;
        }

        /*private void btnReset_Click(object sender, EventArgs e)
        {
            Global.Spatula1.SptReset();
            timer1.Enabled = true;
        }*/

        private void btnLeftLmt_Click(object sender, EventArgs e)
        {
            if (timer1.Enabled)
            {
                MessageBox.Show("目前刮刀正在运动，等停下重按按钮");
                return;
            }
            Global.Spatula1.SetToManualSpeed();
            Global.Spatula1.StartMove(true);//往正方向走，假如方向不对就换成false
            m_StartLeftLimit = true;
            timer1.Enabled = true;
        }

        private void btnLPosSet_Click(object sender, EventArgs e)
        {
            if (Global.Spatula1.IsSptStop())
            {
                double pos = Global.Spatula1.m_Motor.GetCurrentPos();
                txtLeftPos.Text = pos.ToString("f3");
                Global.Spatula1.m_LeftWorkPos = pos;
                m_SpatulaModified = true; 
            }
            else
            {
                MessageBox.Show("请在刮刀停止后设置");
            }
       }

        private void btnRPosSet_Click(object sender, EventArgs e)
        {
            if (Global.Spatula1.IsSptStop())
            {
                double pos = Global.Spatula1.m_Motor.GetCurrentPos();
                txtRightPos.Text = pos.ToString("f3");
                Global.Spatula1.m_RightWorkPos = pos;
                m_SpatulaModified = true;
            }
            else
            {
                MessageBox.Show("请在刮刀停止后设置");
            }
        }

        private void btnSptSet_Click(object sender, EventArgs e)
        {
            double lAdv, rAdv, prtDelay, bacDelay;
            ushort bacNum;
            Global.Spatula1.GetPrintRef(out lAdv, out rAdv, out prtDelay, out bacDelay, out bacNum);
            lAdv = double.Parse(txtLAdv.Text);
            rAdv = double.Parse(txtRAdv.Text);
            prtDelay = double.Parse(txtGoDelay.Text);
            bacDelay = double.Parse(txtBackDelay.Text);
            bacNum = ushort.Parse(txtBackNum.Text);
            Global.Spatula1.SetPrintRef(lAdv, rAdv, prtDelay, bacDelay, bacNum);
            m_SpatulaModified = true;
        }

        private void btnAlter_Click(object sender, EventArgs e)
        {
            Global.Spatula1.ExchangeSptBack();
        }

        private void rdoPullCtn_CheckedChanged(object sender, EventArgs e)
        {
            if (rdoPullCtn.Checked)
            {
                txtPullLen.Enabled = false;
                lblMm.Enabled = false;
            }
        }

        private void rdoPullToLen_CheckedChanged(object sender, EventArgs e)
        {
            if (this.rdoPullToLen.Checked)
            {
                txtPullLen.Enabled = true;
                lblMm.Enabled = true;
            }
        }

        private void btnStartPull_Click(object sender, EventArgs e)
        {
            if (!Global.PaperPuller1.IsStop())
            {
                MessageBox.Show("拉料机正在运动请稍等");
                return;
            }
            Global.PaperPuller1.SetToManualSpeed(); //设置为手动速度
            if (rdoPullToLen.Checked)
            {
                Global.PaperPuller1.Move(double.Parse(txtPullLen.Text ));
            }
            else
                Global.PaperPuller1.StartMove();
            timer2.Enabled = true;
        }

        private void btnPullAdvSet_Click(object sender, EventArgs e)
        {
            if (!Global.VerifyPassWord()) return;
            PullPaper pullset = new PullPaper();
            pullset.ShowDialog();
        }

        private void btnStopPull_Click(object sender, EventArgs e)
        {
            Global.PaperPuller1.PullStop();
        }

       

        private void btnSetPull_Click(object sender, EventArgs e)
        {
            txtPullLen.Text = txtPullUnit.Text;
            Global.Print1.m_UnitLen = double.Parse(txtPullUnit.Text);
            Global.Print1.m_StopPompDelay = int.Parse(txtStopPompDelay.Text);
            Global.Print1.m_PompDelay = int.Parse(txtPompDelay.Text);
            m_PrintModified = true;
        }

        private void btnClearPullPos_Click(object sender, EventArgs e)
        {
            if (Global.PaperPuller1.ClearCount())
            {
                lblPullPos.Text = "0.000";
            }
            else
                MessageBox.Show("设置失败");
        }

        private void btnPullToInt_Click(object sender, EventArgs e)
        {
            if (!Global.PaperPuller1.IsStop())
            {
                MessageBox.Show("请在刮刀停止后再拉料");
                return;
            }
            Global.PaperPuller1.PullToInt();    
        }

        private void timer2_Tick(object sender, EventArgs e)
        {
            lblCurrentPos.Text =Global.PaperPuller1.m_Motor.GetCurrentPos ().ToString ("f3");
            if (Global.PaperPuller1.IsStop())
                timer2.Enabled = false; 
        }

        private void txtPullUnit_TextChanged(object sender, EventArgs e)
        {
            txtPullLen.Text = txtPullUnit.Text; 
        }

        private void rdoTotLen_CheckedChanged(object sender, EventArgs e)
        {
            if (rdoTotLen.Checked)
            {
                txtPrtCount.Enabled = false;
                txtPrtLen.Enabled = true;
            }
         }

        private void rdoTotCount_CheckedChanged(object sender, EventArgs e)
        {
            if (rdoTotCount.Checked)
            {
                txtPrtCount.Enabled = true ;
                txtPrtLen.Enabled = false ;
            }
        }

        private void btnClearPrtNum_Click(object sender, EventArgs e)
        {
            Global.Print1.m_CurrentNum =0;
            Global.Print1.m_TotalCount = 0;
            txtPrtNum.Text = "0";
            txtPrtCount.Text = "0";
        }

        private void btnSetPrt_Click(object sender, EventArgs e)
        {
            Global.Print1.m_CurrentNum = int.Parse(txtPrtNum.Text);
            Global.Print1.m_TotalLength = double.Parse(txtPrtLen.Text);
            Global.Print1.m_TotalCount = int.Parse(txtPrtCount.Text);
            Global.Print1.m_CountAsNumber = rdoTotCount.Checked;
            m_PrintModified = true;
        }

        private void txtPrtCount_TextChanged(object sender, EventArgs e)
        {
            if (!txtPrtCount.Enabled) return; 
            txtPrtLen.Text = (double.Parse(txtPrtCount.Text) * double.Parse(txtPullUnit.Text)).ToString ("f2"); 
        }

        private void txtPrtLen_TextChanged(object sender, EventArgs e)
        {
            if (!txtPrtLen.Enabled) return;
            txtPrtCount.Text = ((int)(double.Parse(txtPrtLen.Text) / double.Parse(txtPullUnit.Text))).ToString (); 
        }

        private void FormPrintSet_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (m_SpatulaModified) Global.WriteSpatulaToFile();
            if (m_PrintModified) Global.WritePrintToFile(); 
        }

        private void btnExit_Click(object sender, EventArgs e)
        {
             
            this.Close();
        }

        private void btnPWD_Click(object sender, EventArgs e)
        {
            FormPWD frmPwd = new FormPWD();
            frmPwd.ShowDialog(); 
        }
     
    }//endof Class Form
}//endof Namespace
