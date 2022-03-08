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
    public partial class FormPWD : Form
    {
        public FormPWD()
        {
            InitializeComponent();
        }

        private void TextBox_Enter(object sender, EventArgs e)
        {
           Global.GetKeyboardNum(sender); 
        }

        private void btnOK_Click(object sender, EventArgs e)
        {
            if (txtNew1.Text != txtNew2.Text)
            {
                MessageBox.Show("两个新密码的值不一样！");
                return;
            }
            if (Global.CheckPassWord(txtOld.Text))
            {
                Global.Print1.m_Password = Global.Hash_MD5_32(txtNew1.Text);
                Global.WritePrintToFile();
                MessageBox.Show("新密码存储成功！");
                this.Close();
            }
            else
            {
                MessageBox.Show("输入的当前密码有误！"); 
            }
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            this.Close();
        }

       
    }
}
