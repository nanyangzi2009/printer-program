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
    public partial class FormPltRefSet : Form
    {
        private bool m_RefModified = false;
        public FormPltRefSet()
        {
            InitializeComponent();
            txtAccT.Enter += new EventHandler(textBox_Enter); 
            txtDecT.Enter += new EventHandler(textBox_Enter);
            txtMaxV.Enter += new EventHandler(textBox_Enter);
            txtST.Enter += new EventHandler(textBox_Enter);
            txtStartV.Enter += new EventHandler(textBox_Enter);
            txtStopV.Enter += new EventHandler(textBox_Enter);
            this.txtAccuracy.Enter += new EventHandler(textBox_Enter);
            this.txtPosNum.Enter += new EventHandler(textBox_Enter);
            this.txtPrtComp.Enter += new EventHandler(textBox_Enter);
            this.txtDifLeft.Enter += new EventHandler(textBox_Enter);
            this.txtDifRight.Enter += new EventHandler(textBox_Enter);
        }

        private void textBox_Enter(object sender, EventArgs e)
        {
           Global.GetKeyboardNum(sender); 
        }

        private void FormRefSet_Load(object sender, EventArgs e)
        {
            Global.CenterForm(this);
            //初始化速度参数
            double dStartVel;//起始速度
            double dMaxVel;//运行速度
            double dTacc;//加速时间
            double dTdec;//减速时间
            double dStopVel;//停止速度
            double dS_para;//S段时间
            Global.Platform1.GetSpeedRef(out dStartVel, out dMaxVel, out dTacc, out dTdec, out dStopVel, out dS_para);
            txtAccT.Text = dTacc.ToString("f3");
            txtDecT.Text = dTdec.ToString("f3");
            txtMaxV.Text = dMaxVel.ToString("f3");
            txtST.Text = dS_para.ToString("f3");
            txtStartV.Text = dStartVel.ToString("f3");
            txtStopV.Text = dStopVel.ToString("f3");
            //初始化方向参数
            ushort pulsemode;
            bool[] screwDirection = new bool[3];
            Global.Platform1.GetLogicSet(out pulsemode, screwDirection);
            if (pulsemode == 0 || pulsemode == 1)
                radioPulseP.Checked = true;
            else
                radioPulseN.Checked = true;
            if (screwDirection[0])
                radioY1P.Checked = true;
            else
                radioY1N.Checked = true;
            if (screwDirection[1])
                radioY2P.Checked = true;
            else
                radioY2N.Checked = true;
            if (screwDirection[2])
                radioXP.Checked = true;
            else
                radioXN.Checked = true;
            //初始化对位参数
            txtDifLeft.Text = (Global.Platform1.m_LeftComp * 100).ToString("f1");
            txtDifRight.Text = ((1 - Global.Platform1.m_LeftComp) * 100).ToString("f1");
            txtAccuracy.Text = Global.Platform1.m_PositonAcuracy.ToString("f3");
            txtPosNum.Text = Global.Platform1.m_PostionNum.ToString();
            txtPrtComp.Text = Global.Platform1.m_XPrtCmps.ToString("f3");
            lblSpeed.Text = Global.Platform1.m_MaxSpeed.ToString("f3"); 
        }

        private void btnSetV_Click(object sender, EventArgs e)
        {
            double dStartVel;//起始速度
            double dMaxVel;//运行速度
            double dTacc;//加速时间
            double dTdec;//减速时间
            double dStopVel;//停止速度
            double dS_para;//S段时间

            //ushort sPosi_mode; //运动模式0：相对坐标模式，1：绝对坐标模式

            dStartVel = double.Parse(this.txtStartV.Text );
            dMaxVel = double.Parse(this.txtMaxV .Text);
            dTacc = double.Parse(this.txtAccT .Text);
            dTdec = double.Parse(this.txtDecT.Text);
            dStopVel = double.Parse(this.txtStopV.Text);
            dS_para = double.Parse(this.txtST.Text);
            Global.Platform1.SetPltVel(dStartVel, dMaxVel, dTacc, dTdec, dStopVel, dS_para);
            
            //设置方向
            ushort pulsemode = (ushort)(radioPulseP.Checked ? 0 : 2);
            bool[] screwDirection = new bool[3];
            screwDirection[0] = radioXP.Checked ? true : false;
            screwDirection[1] = radioY1P.Checked ? true : false;
            screwDirection[2] = radioY2P.Checked ? true : false;
            Global.Platform1.SetScrewsDirection(screwDirection);
            Global.Platform1.SetScrewPulseMode(pulsemode);
            
            //对位设置
            Global.Platform1.m_XPrtCmps = double.Parse(txtPrtComp.Text);
            Global.Platform1.m_LeftComp = double.Parse(txtDifLeft.Text) / 100;
            Global.Platform1.m_PositonAcuracy = double.Parse(txtAccuracy.Text);
            Global.Platform1.m_PostionNum = int.Parse(txtPosNum.Text);
            MessageBox.Show("对位参数存储成功！"); 

            m_RefModified = true;
        }

        private void btnExit_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void FormPltRefSet_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (m_RefModified) Global.WritePltToFile(); 
        }

        private void checkBox1_CheckedChanged(object sender, EventArgs e)
        {
            if (checkBox1.Checked)
            {
                label3.Enabled = true;
                label5.Enabled = true;
                txtPrtComp.Enabled = true;
            }
            else
            {
                label3.Enabled = false;
                label5.Enabled = false;
                txtPrtComp.Enabled = false;
            }
        }

        private void rdoDifHalf_CheckedChanged(object sender, EventArgs e)
        {
            if (rdoDifHalf.Checked)
                groupBox9.Enabled = false;
            else
                groupBox9.Enabled = true;
        }

        private void hScrollBar1_Scroll(object sender, ScrollEventArgs e)
        {
            txtDifLeft.Text = hScrollBar1.Value.ToString();
            txtDifRight.Text = (hScrollBar1.Maximum - hScrollBar1.Value).ToString();
        }

        private void txtDifLeft_TextChanged(object sender, EventArgs e)
        {
            int i = int.Parse(txtDifLeft.Text);
            if (i < 0 || i > 100)
            {
                MessageBox.Show("数值必须介于0-100！");
                return;
            }
            else
            {
                hScrollBar1.Value = i;
                i = int.Parse(txtDifRight.Text);
                if (i != 100 - hScrollBar1.Value)
                    txtDifRight.Text = (100 - hScrollBar1.Value).ToString();
            }
        }

        private void txtDifRight_TextChanged(object sender, EventArgs e)
        {
            int i = int.Parse(txtDifRight.Text);
            if (i < 0 || i > 100)
            {
                MessageBox.Show("数值必须介于0-100！");
                return;
            }
            else
            {
                hScrollBar1.Value = 100 - i;
                i = int.Parse(txtDifLeft.Text);
                if (i != hScrollBar1.Value)
                    txtDifLeft.Text = hScrollBar1.Value.ToString();
            }
        }

       
    }
}
