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
    public partial class FormCalibrate : Form
    {
        public double m_MmPerPixel=0;
        public int m_result=0; //0 = OK; 1= Exit; 
        
        private Point P1, P2,P3,P4; 
        public FormCalibrate()
        {
            InitializeComponent();
            this.txtWidth.Enter += new EventHandler(textBox_Enter);
        }
        private void textBox_Enter(object sender, EventArgs e)
        {
            Global.GetKeyboardNum(sender);
        }

        private void FormCalibrate_Load(object sender, EventArgs e)
        {
            this.Location = new Point(0, 0);
            P1 = new Point(1, pictureBox1.Height / 3);
            P2 = new Point(pictureBox1.Width - 1, pictureBox1.Height / 3);
            P3 = new Point(1, pictureBox1.Height*2 / 3);
            P4 = new Point(pictureBox1.Width - 1, pictureBox1.Height *2/ 3);
        }
       
        
        private void btnOK_Click(object sender, EventArgs e)
        {
            m_MmPerPixel = double.Parse(txtWidth.Text) / (Line2.Location.X + Line2.Width  - Line1.Location.X);
            this.Close();
        }

        private void rdoLine1_CheckedChanged(object sender, EventArgs e)
        {
            Line1.BackColor = Color.Red;
            Line2.BackColor = Color.Black;
        }

        private void rdoLine2_CheckedChanged(object sender, EventArgs e)
        {
            Line2.BackColor = Color.Red;
            Line1.BackColor = Color.Black;
        }

        private void brnBigLeft_Click(object sender, EventArgs e)
        {
            MoveLine(-10);
        }
        private void MoveLine(int step)
        {
            int  x;
            if (Line1.BackColor == Color.Red)
            {
                x = Line1.Location.X + step;
                if (x < 1) x = 1;
                if(x > Line2.Location.X -11) x = Line2.Location.X -11;
                Line1.Location = new Point(x, 256);
            }
            else
            {
                x = Line2.Location.X + step;
                if (x < Line1.Location.X + 11) x = Line1.Location.X + 11;
                if (x > 757) x = 757; // 总宽度是768；
                Line2.Location = new Point(x, 256);
            }
        }

        private void btnBigRight_Click(object sender, EventArgs e)
        {
            MoveLine(10);
        }

        private void btnSmallLeft_Click(object sender, EventArgs e)
        {
            MoveLine(-1);
        }

        private void btnSmallRight_Click(object sender, EventArgs e)
        {
            MoveLine(1);
        }

            

        private void btnExit_Click(object sender, EventArgs e)
        {
            m_result = 1;
            this.Close();
        }

              
    }
}
