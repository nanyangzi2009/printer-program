using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace PrintInterface
{
    public partial class Keyboard : Form
    {
        public double m_min = 1, m_max = 0;
        public string m_Text;
        public Keyboard()
        {
            InitializeComponent();
            this.Text = "请输入数字";
        }
        public Keyboard(TextBox tb)
        {
            InitializeComponent();
            if (tb.PasswordChar != '\0')
            {
                textBox1.PasswordChar = tb.PasswordChar;
                btnNegate.Enabled = false;
            }
            m_Text = tb.Text ;
            
        }

        private void Num1_Click(object sender, EventArgs e)
        {
            int idx =textBox1.SelectionStart;
            string s = textBox1.Text.Insert(textBox1.SelectionStart, "1");
            textBox1.Text=s;
            textBox1.Select(idx + 1, 0);
            textBox1.Focus();
        }

        private void Num2_Click(object sender, EventArgs e)
        {
            int idx = textBox1.SelectionStart;
            string s = textBox1.Text.Insert(textBox1.SelectionStart, "2");
            textBox1.Text = s;
            textBox1.Select(idx + 1, 0);
            textBox1.Focus();
        }

        private void Num3_Click(object sender, EventArgs e)
        {
            int idx = textBox1.SelectionStart;
            string s = textBox1.Text.Insert(textBox1.SelectionStart, "3");
            textBox1.Text = s;
            textBox1.Select(idx + 1, 0);
            textBox1.Focus();
        }

        private void Num4_Click(object sender, EventArgs e)
        {
            int idx = textBox1.SelectionStart;
            string s = textBox1.Text.Insert(textBox1.SelectionStart, "4");
            textBox1.Text = s;
            textBox1.Select(idx + 1, 0);
            textBox1.Focus();
        }

        private void Num5_Click(object sender, EventArgs e)
        {
            int idx = textBox1.SelectionStart;
            string s = textBox1.Text.Insert(textBox1.SelectionStart, "5");
            textBox1.Text = s;
            textBox1.Select(idx + 1, 0);
            textBox1.Focus();
        }

        private void Num6_Click(object sender, EventArgs e)
        {
            int idx = textBox1.SelectionStart;
            string s = textBox1.Text.Insert(textBox1.SelectionStart, "6");
            textBox1.Text = s;
            textBox1.Select(idx + 1, 0);
            textBox1.Focus();
        }

        private void Num7_Click(object sender, EventArgs e)
        {
            int idx = textBox1.SelectionStart;
            string s = textBox1.Text.Insert(textBox1.SelectionStart, "7");
            textBox1.Text = s;
            textBox1.Select(idx + 1, 0);
            textBox1.Focus();
        }

        private void Num_Click(object sender, EventArgs e)
        {
            int idx = textBox1.SelectionStart;
            string s = textBox1.Text.Insert(textBox1.SelectionStart, "8");
            textBox1.Text = s;
            textBox1.Select(idx + 1, 0);
            textBox1.Focus();
        }

        private void Num9_Click(object sender, EventArgs e)
        {
            int idx = textBox1.SelectionStart;
            string s = textBox1.Text.Insert(textBox1.SelectionStart, "9");
            textBox1.Text = s;
            textBox1.Select(idx + 1, 0);
            textBox1.Focus();
        }

        private void Num0_Click(object sender, EventArgs e)
        {
            int idx =textBox1.SelectionStart;
            string s = textBox1.Text.Insert(textBox1.SelectionStart, "0");
            textBox1.Text=s;
            textBox1.Select(idx + 1, 0);
            textBox1.Focus();
        }

        

        private void lblPoint_Click(object sender, EventArgs e)
        {
            int idx =textBox1.SelectionStart;
            string s = textBox1.Text.Insert(textBox1.SelectionStart, ".");
            textBox1.Text=s;
            textBox1.Select(idx + 1, 0);
            textBox1.Focus();
        }

        private void lblBack_Click(object sender, EventArgs e)
        {
            int idx = textBox1.SelectionStart;
            if (idx  > 0) 
            {
                textBox1.Text = textBox1.Text.Substring(0, idx - 1) + textBox1.Text.Substring(idx);
                textBox1.Select(idx-1,0);

            }
            textBox1.Focus();
        }

       

        
        private void Keyboard_Load(object sender, EventArgs e)
        {
            textBox1.Text = m_Text;
                       
        }

        private void lblDone_Click(object sender, EventArgs e)
        {
            double v=0;
            try
            {
                v = double.Parse(textBox1.Text);
            }
            catch (Exception e1)
            {
                DialogResult rst= MessageBox.Show ("无法转换为数字："+ e1.Message +"仍然要退出吗","出错",MessageBoxButtons.YesNo ); 
                if(rst== DialogResult.No ) 
                {
                    return;
                }
                else
                    textBox1.Text = m_Text;
                this.Close ();
                return;
            }
            if (m_min > m_max) //说明不限制范围
            {
                m_Text = textBox1.Text;
                this.Close();
                return; 
            }
            else if (v < m_min || v > m_max)
            {
                DialogResult rst = MessageBox.Show("超过范围：" + m_min.ToString("f3") + " - " + m_max.ToString("f3") + "，仍然要退出吗？", "出错", MessageBoxButtons.YesNo);
                if (rst == DialogResult.No)
                {
                    return;
                }
                else
                    this.Close();
            }
            else
            {
                m_Text = textBox1.Text;
                this.Close();
            }
        }

        private void Keyboard_Activated(object sender, EventArgs e)
        {
            textBox1.Select(textBox1.Text.Length, 0);
            textBox1.Focus();
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            //textBox1.Text = m_Text;
            this.Close();
        }

        private void btnClear_Click(object sender, EventArgs e)
        {
        
            textBox1.Text = "";
            textBox1.Focus();
        }

        private void btnNegate_Click(object sender, EventArgs e)
        {
            int idx = textBox1.SelectionStart;
            if (textBox1.Text != "")
            {
                if (textBox1.Text.Substring(0, 1) == "-")
                {
                    textBox1.Text = textBox1.Text.Substring(1, textBox1.Text.Length - 1);
                    textBox1.Select(idx - 1, 0);
                }
                else
                {
                    textBox1.Text = "-"+ textBox1.Text;
                    textBox1.Select(idx + 1, 0);
                }
            }
            textBox1.Focus();
        }
       
    }
}
