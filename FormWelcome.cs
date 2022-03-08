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
    public partial class FormWelcome : Form
    {
        public FormWelcome()
        {
            InitializeComponent();

        }

        private void Form1_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            Application.Exit();
        }

        private void btnChinese_Click(object sender, EventArgs e)
        {
            string s = Global.Hash_MD5_32(textBox1.Text);
            if (s != "2CFDA58B4A2289B4821E088FD6439128")
            {
                MessageBox.Show(" 您输入的序列号不对,请重新输入");
                return;
            }
            Global.MainPage  = new FormMain();
            Global.MainPage.Show();
            this.Hide();
            
        }
        
        private void textBox1_Enter(object sender, EventArgs e)
        {
            Global.GetKeyboardNum(textBox1);
        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
