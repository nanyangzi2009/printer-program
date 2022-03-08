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
    public partial class FormPositionSet : Form
    {
        private bool m_RefModified = false;
        public FormPositionSet()
        {
            InitializeComponent();
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

        private void checkBox1_CheckedChanged(object sender, EventArgs e)
        {
            if (checkBox1.Checked)
            {
                label15.Enabled = true;
                label16.Enabled = true;
                txtPrtComp.Enabled = true;
            }
            else
            {
                label15.Enabled = false ;
                label16.Enabled = false ;
                txtPrtComp.Enabled = false ;
            }
        }

      

        private void radioButton1_CheckedChanged(object sender, EventArgs e)
        {
            if (rdoDifHalf.Checked)
            groupBox3.Enabled = false;
        }

        private void radioButton2_CheckedChanged(object sender, EventArgs e)
        {
            if (rdoDifManual.Checked)
                groupBox3.Enabled = true;
        }

        private void hScrollBar1_Scroll(object sender, ScrollEventArgs e)
        {
            txtDifLeft.Text = hScrollBar1.Value.ToString();
            txtDifRight.Text = (hScrollBar1.Maximum-hScrollBar1.Value).ToString();
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
                if (i != 100-hScrollBar1.Value)
                    txtDifRight.Text =(100- hScrollBar1.Value).ToString();
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
                hScrollBar1.Value = 100-i;
                i = int.Parse(txtDifLeft.Text);
                if (i != hScrollBar1.Value)
                    txtDifLeft.Text = hScrollBar1.Value.ToString();
            }
         }

        private void btnExit_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void FormPositionSet_Load(object sender, EventArgs e)
        {
            txtDifLeft.Text  = (Global.Platform1.m_LeftComp*100).ToString ("f1");
            txtDifRight.Text = ((1 - Global.Platform1.m_LeftComp)*100).ToString("f1");
            txtAccuracy.Text = Global.Platform1.m_PositonAcuracy.ToString("f3");
            txtPosNum.Text = Global.Platform1.m_PostionNum.ToString();
            txtPrtComp.Text = Global.Platform1.m_XPrtCmps.ToString("f3");
            lblSpeed.Text = Global.Platform1.m_MaxSpeed.ToString("f3"); 
        }

        private void btnOK_Click(object sender, EventArgs e)
        {
            Global.Platform1.m_XPrtCmps = double.Parse(txtPrtComp.Text);
            Global.Platform1.m_LeftComp = double.Parse(txtDifLeft.Text) / 100;
            Global.Platform1.m_PositonAcuracy = double.Parse(txtAccuracy.Text);
            Global.Platform1.m_PostionNum = int.Parse(txtPosNum.Text);
            MessageBox.Show("对位参数存储成功！"); 
            m_RefModified = true;
        }

        private void FormPositionSet_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (m_RefModified) Global.WritePltToFile(); 
        }

        private void btnProfile_Click(object sender, EventArgs e)
        {
            if (!Global.VerifyPassWord()) return;
            FormPltRefSet frmRef = new FormPltRefSet();
            frmRef.ShowDialog();
        }

    }
}
