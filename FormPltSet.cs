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
    public partial class FormPltSet : Form
    {
        private bool m_StartDemo;
        private PointF m_RotateCenter;

        public FormPltSet()
        {
            InitializeComponent();
            m_StartDemo = false;
            textBoxX.Enter += new EventHandler(textBox_Enter);  //获得焦点事件
            textBoxY.Enter += new EventHandler(textBox_Enter);
            txtSpeed.Enter += new EventHandler(textBox_Enter);
            txtAngle.Enter += new EventHandler(textBox_Enter);
            txtDemoX.Enter += new EventHandler(textBox_Enter);
            txtDemoV.Enter += new EventHandler(textBox_Enter);
            txtDemoAngle.Enter += new EventHandler(textBox_Enter);
        }

        private void textBox_Enter(object sender, EventArgs e)
        {
            Global.GetKeyboardNum(sender); 
        }

        private void btnStepXY_Click(object sender, EventArgs e)
        {
            
            double xMove, yMove, speed;//单位是mm及mm/s
            xMove = double.Parse (textBoxX.Text );
            yMove = double.Parse (textBoxY.Text );
            speed = double.Parse(txtSpeed.Text);
            if(Global.Platform1.SetVelocity(speed))
                Global.Platform1.TranslateMove(xMove, yMove);
            else 
                MessageBox.Show("平移平台失败！");
        }

        
        private void RotatePlatform(bool Dir)
        {
            PointF pCenter = new PointF(-25, -59);
            double speed, angle;
            speed = double.Parse(txtSpeed.Text);
            angle = double.Parse(txtAngle.Text)* 3.1415926/360;
            if (!Dir) angle = -angle;
            if (Global.Platform1.SetVelocity(speed))
                Global.Platform1.RotateMove(pCenter, angle);
            else
                MessageBox.Show("旋转平台失败！");
        }

       

        private void btnAnticlock_Click(object sender, EventArgs e)
        {
            RotatePlatform(true);
            Global.Platform1.m_FlagReset = false; 
        }

        private void btnClockwise_Click(object sender, EventArgs e)
        {
            RotatePlatform(false);
            Global.Platform1.m_FlagReset = false; 
        }

        private void btnExit_Click(object sender, EventArgs e)
        {
            this.Close();
        }

       

        private void FormPltSet_Load(object sender, EventArgs e)
        {
            Global.CenterForm(this);
            radioX.Checked = true;
            m_RotateCenter = new PointF((float)Global.Platform1.GetAxisDistance() / 2, 0);
            double[] Wpos = new double[3];
            Global.Platform1.GetWorkPostion(Wpos);
            lblWY1.Text = Wpos[0].ToString("f2");
            lblWY2.Text = Wpos[1].ToString("f2");
            lblWX.Text = Wpos[2].ToString("f2");
        }

        private void btnToWorkPos_Click(object sender, EventArgs e)
        {
            Global.Platform1.PltReset(); 
        }

        private void btnRefSet_Click(object sender, EventArgs e)
        {
            if (!Global.VerifyPassWord()) return;
            FormPltRefSet frmRef = new FormPltRefSet();
            frmRef.ShowDialog();
        }

        

        private void btnStartDemo_Click(object sender, EventArgs e)
        {
            Global.Platform1.SetVelocity(double.Parse(txtDemoV.Text));
            Global.Platform1.PltReset ();
            if (radioX.Checked)
            {
                Global.Platform1.TranslateMove(double.Parse(txtDemoX.Text), 0);
                m_StartDemo = true;
            }
            else
            {
                Global.Platform1.RotateMove(m_RotateCenter, double.Parse(txtDemoAngle.Text));
            }
            timer1.Enabled = true;
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            if (m_StartDemo)
            {
                if (Global.Platform1.PltIsStop())
                {
                    if (radioX.Checked)
                    {
                        double des =double.Parse(txtDemoX.Text);
                        double pos = Global.Platform1.GetScrewPosition(2);//获得2号电机的移动位置；
                        if (pos > 0) des = -des;
                        Global.Platform1.TranslateXTo(des ) ;
                    }
                    else
                    {
                        double angle = double.Parse(txtDemoAngle.Text) *2 ; //摇摆的角度
                        double pltAngle = Global.Platform1.GetPltAngle();
                        if (pltAngle >0) angle = -angle;
                        Global.Platform1.RotateMove(m_RotateCenter, angle );
                    }
                }
            }

            lblPosY1.Text = Global.Platform1.GetScrewPosition(0).ToString("f2");
            lblPosY2.Text = Global.Platform1.GetScrewPosition(1).ToString("f2");
            lblPosX.Text = Global.Platform1.GetScrewPosition(2).ToString("f2");
        }

        private void btnStopDemo_Click(object sender, EventArgs e)
        {
            Global.Platform1.PltStop();
            timer1.Stop(); 
        }

        private void btnPltHome_Click(object sender, EventArgs e)
        {
             Global.Platform1.MoveToHome();
        }

        private void txtDemoX_TextChanged(object sender, EventArgs e)
        {
            if (double.Parse(txtDemoX.Text) > 10)
            {
                MessageBox.Show("请不要超过10");
                return;
            }
        }

        private void txtDemoAngle_TextChanged(object sender, EventArgs e)
        {
            if (double.Parse(txtDemoX.Text) >5)
            {
                MessageBox.Show("角度请不要超过5");
                return;
            }
        }
       
    }
}
