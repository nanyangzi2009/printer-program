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
    public partial class FormIO : Form
    {
        Color m_lowLgc ;
        Color m_highLgc;
        public FormIO()
        {
            InitializeComponent();
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            uint rst = Global.Card0.GetInPort (0);
            //读取IO的输入端口
            SetOnOff(rst ,(ushort)MotionCard.InBit.I_EmgStop ,lblIEmgStop );
            SetOnOff(rst, (ushort)MotionCard.InBit.I_Move, lblIMove);
            SetOnOff(rst, (ushort)MotionCard.InBit.I_NoPaper, lblINoPaper);
            SetOnOff(rst, (ushort)MotionCard.InBit.I_PullPaper, lblIPullPaper);
            SetOnOff(rst, (ushort)MotionCard.InBit.I_SendLight, lblISendLight);
            SetOnOff(rst, (ushort)MotionCard.InBit.I_Start, lblIStart);
            SetOnOff(rst, (ushort)MotionCard.InBit.I_ArmDown, lblBArmDown);
            SetOnOff(rst, (ushort)MotionCard.InBit.I_SptDown, lblSArmDown);
            SetOnOff(rst, (ushort)MotionCard.InBit.I_NetDown, lblEBoardDown);

            //读取各轴限位开关
            SetOnOff(rst, 16, lblY1BLmt);  //右轴后限位
            SetOnOff(rst, 17, lblY2BLmt);  //左轴后限位
            SetOnOff(rst, 18, lblXLLmt);    // 横轴左限位
            SetOnOff(rst, 19, lblSLLmt);   //刮刀左限位； 
            SetOnOff(rst, 21, lblRCLLmt);  //右相机左限位；21位表示5号轴正限位，5号轴为右相机，右相机从右到左
            SetOnOff(rst, 22, lblLCRLmt);  //左相机右限位，6号轴为左相机，左相机从左到右

            SetOnOff(rst, 24, lblY1FLmt);  //右轴前限位
            SetOnOff(rst, 25, lblY2FLmt);  //左轴前限位
            SetOnOff(rst, 26, lblXRLmt);    // 横轴右限位
            SetOnOff(rst, 27, lblSRLmt);   //刮刀右限位； 
            SetOnOff(rst, 29, lblRCRLmt);  //右相机右限位；21位表示5号轴正限位，5号轴为右相机，右相机从右到左
            SetOnOff(rst, 30, lblLCLLmt);  //左相机左限位，6号轴为左相机，左相机从左到右

            rst = Global.Card0.GetInPort(1);
            //读取原点信号
            SetOnOff(rst, 0, lblY1Org);  //平台右轴原点
            SetOnOff(rst, 1, lblY2Org);  //平台左轴原点
            SetOnOff(rst, 2, lblXOrg);    //平台横轴原点
            SetOnOff(rst, 3, lblSRLmt);   //刮刀原点； 
            SetOnOff(rst, 5, lblRCRLmt);  //右相机原点
            SetOnOff(rst, 6, lblLCLLmt);  //左相机原点

            rst = Global.Card0.GetOutPort ();
            //读取IO的输出端口
            SetOnOff(rst, (ushort)MotionCard.OutBit.O_Beep, lblOBeep);
            SetOnOff(rst, (ushort)MotionCard.OutBit.O_Blow, lblOBlow);
            SetOnOff(rst, (ushort)MotionCard.OutBit.O_InPaper, lblOInPaper);
            SetOnOff(rst, (ushort)MotionCard.OutBit.O_LightBox, lblOLightBox);
            SetOnOff(rst, (ushort)MotionCard.OutBit.O_PaperOut, lblOPaperOut);
            SetOnOff(rst, (ushort)MotionCard.OutBit.O_Pump, lblEPompOn);
            SetOnOff(rst, (ushort)MotionCard.OutBit.O_Spatula, lblSBackOff);
            SetOnOff(rst, (ushort)MotionCard.OutBit.O_Spotlight, lblOSpotLight);
            SetOnOff(rst, (ushort)MotionCard.OutBit.O_UV, lblOUV);

            //显示停止或运行
            int run = Global.Print1.IsRuning();
            if (run==0) //表示运行
            {
                lblDRun.BackColor = Color.Yellow ;
                lblD1Run.Text = "运行中";
            }
            else if (run == 1) //表示停止
            {
                lblDRun.BackColor = m_lowLgc   ;
                lblD1Run.Text = "停止中";
            }
            else //表示故障
            {
                lblDRun.BackColor = m_highLgc ;
                lblD1Run.Text = "故障中";
            }
            //显示异常
            int num = Global.Print1.PrintingExcptInfo.Count;
            if (num == 0)
            {
                lblDException.BackColor = m_lowLgc;
                lblD1Excpt.Text = "无异常"; 
            }
            else
            {
                lblDException.BackColor = m_highLgc ;
                lblD1Excpt.Text = "有异常";
            }

            //显示自动或手动
            if (Global.Print1.m_StaAuto)
            {
                lblDAuto.BackColor = m_highLgc;
                lblD1Auto.Text = "自动中"; 
            }
            else
            {
                lblDAuto.BackColor = m_lowLgc ;
                lblD1Auto.Text = "手动中";
            }

            //显示运动卡状态
            if (!Global.Card0.m_CardInited )
            {
                lblDCard.BackColor = m_highLgc;
                lblD1Card.Text = "卡异常";
            }
            else
            {
                lblDCard.BackColor = m_lowLgc;
                lblD1Card.Text = "卡正常";
            }
        }

        private void SetOnOff(uint rst ,ushort bit, Label lbl)
        {
            if (((rst>>bit) & 0x1) == 0)
                lbl.BackColor = lblLgcLow.BackColor;
            else
                lbl.BackColor = lblLgcHigh.BackColor;
        }

        private void FormIO_Load(object sender, EventArgs e)
        {
            m_highLgc = lblLgcHigh.BackColor;
            m_lowLgc = lblLgcLow.BackColor;
            timer1.Start();
        }

        private void btnExit_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
