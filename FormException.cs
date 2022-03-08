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
    public partial class FormException : Form
    {
        public FormException()
        {
            InitializeComponent();
        }

        private void FormException_Load(object sender, EventArgs e)
        {
            Global.CenterForm(this);
            rtxExcp.Text = "异常列表：" +"\n";
            int count = Global.Print1.PrintingExcptInfo.Count ; 
            if(count ==0) return;
            for (int i = 0; i < count; i++)
            {
                rtxExcp.Text  += (i+1).ToString() + ":"+ Global.Print1.PrintingExcptInfo[i].ToString() + "\n" ;
            }
        }

        private void btnClear_Click(object sender, EventArgs e)
        {
            rtxExcp.Text = "异常列表：";
            Global.Print1.PrintingExcptInfo.Clear(); 
        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
