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
    public partial class FormVerify : Form
    {
        public bool  m_pwdYes = false ; //验证成功为true， 否则为false
        public FormVerify()
        {
            InitializeComponent();
        }

        private void TextBox_Enter(object sender, EventArgs e)
        {
           Global.GetKeyboardNum(sender); 
        }

        private void btnOK_Click(object sender, EventArgs e)
        {
           if (Global.CheckPassWord(txtPwd.Text))
            {
                m_pwdYes =true;
                this.Close();
            }
           else
            {

                MessageBox.Show("输入的当前密码有误！"); 
            }
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            m_pwdYes = false ;
            this.Close();
        }

        private void FormVerify_Load(object sender, EventArgs e)
        {

        }

    }
}
