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
    public partial class FormMain : Form
    {
        public CameraDMK CameraLeft;
        public CameraDMK CameraRight;
        private bool m_btn_Emg = false;
        private bool m_btn_Start = false;
        private bool m_btn_Move = false;
        private bool m_btn_Pull = false;
        private bool m_in_NoPaper = false;
        private bool m_in_SendLight = false;
        private long m_BeepTime = 0;
        
        private int  m_auto_Time = 0; //记录自动印刷的时间
       // private int m_auto_BeepTime = 3000; // 蜂鸣器时间设置为响3秒；
        private bool m_auto_Beep = false ;
        private bool m_auto_Positioning = false;
        private bool m_auto_SptToLeft=false ; // 刮刀向左运动中
        private bool m_auto_SptToRight = false; // 刮刀向右运动中
        private bool m_auto_Pulling = false;  //拉料过程中

        private long m_auto_SptBeginExTime; // 记录开始切换刮刀的时间
        private bool m_auto_UVEnabled = false; //记录UV开的状态
        private bool m_auto_SptExchanged=false; // 刮刀和回墨刀已经交换
        private long m_auto_PompBeginExTime ; //记录吹风吸风开始转换时间
        private bool m_auto_PompExchanged = false;
        private bool m_auto_Finished = false;
        private int m_auto_TopenUV;// 此变量记录刮刀开始向右到开UV的时间
        private bool m_auto_First=true ;// 记录是第一轮
        private bool m_move_Direction = true;

        private Color clrLgcLow  = Color.Green ; //低电平表示绿色
        private Color clrLgcHighNormal = Color.Yellow ; //高电平正常为黄色
        private Color clrLgcHighException =  Color.Red ; //高电平如果表示异常则为红色

        private int m_CurrentBackNum = 1; //当前回墨次数

        public FormMain()
        {
            InitializeComponent();
        }

        private void frmMain_Load(object sender, EventArgs e)
        {
            this.richTextBox1.Text = "等待对位";

            Global.InitFromFile(); //从文件读取各种参数

            Global.Print1.InitPrint();
            Global.Card0.InitializeCard();
            Global.Platform1.InitPlatorm();
            Global.Spatula1.InitSpatula();
            Global.PaperPuller1.InitPuller();
           
            bool loadCam= false;
            CameraLeft = new CameraDMK (this.hWinCtlLeft );
            if (!CameraLeft.m_CamInited) loadCam =  Global.ReadFromFile(Global.LeftCamName, CameraLeft );
            if (!loadCam ) Global.Print1.PrintingExcptInfo.Add("左相机读取数据失败"); 
            CameraRight = new CameraDMK(this.hWinCtlRight);
            if (!CameraRight.m_CamInited) loadCam = Global.ReadFromFile(Global.RightCamName, CameraRight);
            if (!loadCam) Global.Print1.PrintingExcptInfo.Add("右相机读取数据失败"); 
     
            initMainPage();
        }

        private void  initMainPage()
        {
            //显示常用印刷参数
            lblPullSpeed.Text = Global.PaperPuller1.m_MaxSpeed.ToString("f3"); 
            lblManualSpeed.Text = Global.PaperPuller1.m_ManualSpeed.ToString("f3");
            lblUnitLen.Text = Global.Print1.m_UnitLen .ToString("f3");

            lblTotalCount.Text = Global.Print1.m_TotalCount.ToString();
            lblCurNum.Text = Global.Print1.m_CurrentNum.ToString ();
            lblStopNum.Text = Global.Print1.m_NumOfStop.ToString();

            //初始化几个按钮开关状态
            SetStatusAuto(Global.Print1.m_StaAuto);     //自动/手动按钮
            SetStatusSwtInPaperPomp(Global.Print1.m_SwtInPaperPomp); //进料吸风按钮
            SetStatusSwtBlow(Global.Print1.m_SwtBlow);          //风机按钮
            SetStatusSwtLightBox(!Global.Print1.m_SwtLightBox); //灯箱按钮
            SetStatusSwtSpotLight(!Global.Print1.m_SwtSpotLight); //射灯按钮

            //启动信息计时器,以及外来输入信号硬按钮检测计时器
            timerInfo.Start();
            timerBtn.Start(); 
        }

        private void SetStatusBtn(bool on, Label  lbl, Color Tcolor, Color Fcolor, string Tstr, string Fstr)
        {
            if (on)
            {
                lbl.BackColor = Tcolor ;
                lbl.Text = Tstr;
            }
            else
            {
                lbl.BackColor = Fcolor ;
                lbl.Text = Fstr ;
            }
        }


        private void SetStatusRun(bool run)
        {
            SetStatusBtn(run, lblRun, clrLgcHighNormal, clrLgcLow , "运行中", "停止中");
        }

        private void SetStatusAuto(bool auto)
        {
            SetStatusBtn(auto, lblAuto, clrLgcHighNormal, clrLgcLow, "自动", "手动");
            Global.Print1.m_StaAuto = auto;
            if (auto)
            {
                Global.Platform1.SetAutoSpeed();   
                Global.Spatula1.SetToAutoSpeed() ; //刮刀设置为自动运行速度
                Global.PaperPuller1.SetToAutoSpeed();  //拉料机设置为自动运行速度
            }
            else
            {
                Global.Platform1.SetManualSpeed();  
                Global.Spatula1.SetToManualSpeed(); //刮刀设置为手动运行速度
                Global.PaperPuller1.SetToManualSpeed();  //拉料机设置为手动运行速度
            }
        }

        private void SetStatusException(bool xcp)
        {
            SetStatusBtn(xcp, lblExcept, clrLgcHighException , clrLgcLow, "有异常", "无异常");
        }
         
        private void frmMain_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            this.Close();
        }

        private void lblAuto_DoubleClick(object sender, EventArgs e)
        {
          SetStatusAuto(!Global.Print1.m_StaAuto);
        }

       
        private void SetStatusSwtBlow(bool blow)
        {
            Global.Print1.SetBlowing(blow);
            SetStatusSwitch(lblSwtBlow, blow, clrLgcLow , clrLgcHighException , "风机");
        }

        private void lblSwtBlow_DoubleClick(object sender, EventArgs e)
        {
            SetStatusSwtBlow(!Global.Print1.m_SwtBlow );
        }

        private void SetStatusSwtLightBox(bool lb)
        {
            Global.Print1.SetLightBox(lb );
            SetStatusSwitch(lblSwtLight, lb, clrLgcLow, clrLgcHighException, "灯箱");
        }
        private void SetStatusSwtSpotLight(bool on)
        {
            Global.Print1.SetSpotlight(on);
            SetStatusSwitch(lblSwtSpot, on, clrLgcLow, clrLgcHighException, "射灯");
        }
        private void SetStatusSwtInPaperPomp(bool on)
        {
            Global.Print1.SetInPaperPomp(on);
            SetStatusSwitch(this.lblSwtPaperIn, on, clrLgcLow, clrLgcHighException, "送料吸风");
        }

        private void SetStatusSwitch(Label lbl, bool on_ff, Color clrTrue, Color clrFalse, string name)
        {
            if (on_ff )
            {
                lbl.BackColor = clrTrue;
                lbl.Text = name +"开";
            }
            else
            {
                lbl.BackColor = clrFalse;
                lbl.Text = name + "关";
            }
        }

        private void lblSwtLight_DoubleClick(object sender, EventArgs e)
        {
            SetStatusSwtLightBox(!Global.Print1.m_SwtLightBox);
        }

        private void lblSwtSpot_DoubleClick(object sender, EventArgs e)
        {
            SetStatusSwtSpotLight(!Global.Print1.m_SwtSpotLight);
        }

        private void lblSwtPaperIn_DoubleClick(object sender, EventArgs e)
        {
            SetStatusSwtInPaperPomp(!Global.Print1.m_SwtInPaperPomp);
        }

        private void btnClearTotal_Click(object sender, EventArgs e)
        {
            lblTotalCount.Text = "0";
            Global.Print1.m_TotalCount = 0;  
        }

        private void btnClearCurNum_Click(object sender, EventArgs e)
        {
            lblCurNum.Text = "0";
            Global.Print1.m_CurrentNum = 0; 
        }

       

        private bool Readbit(uint u, MotionCard.InBit bit) //低电平返回true，高电平返回false
        {
            if (((u >> (ushort)bit) & 0x1) == 0) return true;
            return false;
        }

        private void timerInfo_Tick(object sender, EventArgs e)
        {
            //设置状态
            //SetStatusAuto(Global.Print1.m_StaAuto);
            SetStatusRun(Global.Print1.IsRuning()==0); //0 代表运行
            SetStatusException(Global.Print1.IsInExcpt());
            lblMsg.Text = Global.Print1.PrintingInfo; 
        }

        private void timerBtn_Tick(object sender, EventArgs e)
        {
            uint rst = Global.Card0.GetInPort(0);
            //读取IO的输入端口
            //-----------------------------------------------------------------------
            if (Readbit(rst, MotionCard.InBit.I_NoPaper))  //如果是无料停机信号传入,目前假设物料停机给低电平信号，而不是给个短脉冲
            {
                m_in_NoPaper = true;
            }
            else
            {
                m_in_NoPaper = false;
            }
            //-----------------------------------------------------------------------
            if (Readbit(rst, MotionCard.InBit.I_SendLight))  //如果是送料光电信号传入
            {
                if (!m_in_SendLight)
                {
                    m_in_SendLight = true;
                    timerSendLight.Interval = (int)Global.Print1.m_TSendDelay;
                    timerSendLight.Tag = "first";
                    timerSendLight.Start();
                }
            }
            //----------------------------------------------------------
            if (Readbit(rst, MotionCard.InBit.I_EmgStop)) //紧急按钮按下
            {
                if (m_btn_Emg)
                    return;  //如果还处于按下状态说明已经发出了停止命令,不再检测其他按钮
                else
                {
                    m_btn_Emg = true;
                    Global.Print1. BeginBeep();
                    timerBeep.Start(); 
                    Global.Platform1.EmgStop();
                    Global.Spatula1.SptEmgStop();
                    Global.PaperPuller1.EmgStop();
                    this.SetStatusAuto(false);
                }
            }
            else
            {
                if(m_btn_Emg) m_btn_Emg =false ;
            }
            //----------------------------------------------------------------
            if (Readbit(rst, MotionCard.InBit.I_Move))  //如果点动按钮按下
            {
                if (m_btn_Move) return; //如果持续按下状态，维持不变
                if (timerStart.Enabled)
                {
                    Global.Print1.PrintingExcptInfo.Add("正在自动印刷，请先停止");
                    return;
                }
              
                m_btn_Move = true;
                timerMove.Start();
                if (Global.Print1.m_StaAuto)  //如果是自动状态下点动
                {
                    if (m_move_Direction)
                        Global.Spatula1.AutoMoveLeft();
                    else
                        Global.Spatula1.AutoMoveRight();
                    m_move_Direction = !m_move_Direction;
                    timerMove.Start();
                }
                else //手动状态下电动
                {
                    if (Global.Spatula1.m_Motor.GetCurrentPos() >= Global.Spatula1.m_LeftWorkPos) m_move_Direction = false; //超过左工作位则负向
                    if (Global.Spatula1.m_Motor.GetCurrentPos() <= Global.Spatula1.m_RightWorkPos) m_move_Direction = true; //超过右工作位则正向
                    Global.Spatula1.StartMove(m_move_Direction );   
                }
            }
            else
            {
                if (!timerMove.Enabled)
                {
                    m_btn_Move = false;  // 在完成刮刀点动情况下，重置 m_btn_Move
                    Global.Spatula1.SptStop();  //按钮起来就停止刮刀运动
                }
            }
            //-----------------------------------------------------------------------
            if (Readbit(rst, MotionCard.InBit.I_Start))  //如果按下Start硬按钮,“启动”按钮
            {
                if (!m_btn_Start)  //如果是刚按下Start按钮
                {
                    m_btn_Start = CheckPrtPrepare(); //先检查自动印刷准备工作
                    if (m_btn_Start)  StartAutoPrint();//如果完成则启动自动印刷
                }
            }
            else  //如果没有按下Start硬按钮
            {
                if (!timerStart.Enabled) m_btn_Start = false;  // 在不进行自动印刷的情况下，重置 m_btn_Start
            }

            //---------------------------------------------------------------------------
            if (Readbit(rst, MotionCard.InBit.I_PullPaper))  //如果拉料按钮按下
            {
                if (m_btn_Pull) return; //如果持续按下状态，维持不变
                if (timerStart.Enabled)
                {
                    Global.Print1.PrintingExcptInfo.Add("正在自动印刷，请先停止");
                    return;
                }
                
                m_btn_Pull = true;
                timerPull.Start();
                if (Global.Print1.m_StaAuto)  //如果是自动状态下拉料
                {
                    Global.PaperPuller1.PullToInt(); //拉料到本次完成，或者一个定长
                    timerPull.Start();
                }
                else //手动拉料
                {
                    Global.PaperPuller1.StartMove();
                }
            }
            else
            {
                if (!timerPull.Enabled)
                {
                    m_btn_Pull = false;  // 在手工拉料情况下，重置 m_btn_Pull
                    Global.PaperPuller1.PullStop ();  //按钮起来就停止拉料运动
                }
            }
           
        }

        private bool CheckPrtPrepare()
        {
            if (!Global.Print1.CheckForPrint()) return false;
            if (!Global.Platform1.CheckForPrint()) return false;
            if (!Global.PaperPuller1.CheckForPrint()) return false;
            if (!PreparePositioning())
            {
                Global.Platform1.m_Positioning = 0;
                Global.Print1.PrintingExcptInfo.Add("尚未准备好对位");
                return false;
            }
            return true;
        }
        
        

        private void StartAutoPrint()
        {
            timerBeep.Start();
            m_auto_Beep = true;
            timerStart.Start();
            Global.Print1.m_CurrentNum = 1; //开始计数,这是印刷次数
            Global.Print1.StartPomping(); //开始吸风
            m_auto_First = true;
            m_auto_Time = 0;
            m_CurrentBackNum = 1;//第几次回墨
       }

        private void timerStart_Tick(object sender, EventArgs e)//自动印刷过程
        {
            m_auto_Time += timerStart.Interval;//记录自动运行阶段的时间

            /////////////////////////////////////////////////////////蜂鸣阶段，可能开始印刷或结束印刷/////////////////////////////
            if (timerBeep.Enabled )  //如果正在蜂鸣报警则返回
                return;
            if (m_auto_Beep) //如果蜂鸣结束，但还在报警阶段
            {
                m_auto_Beep = false;
                if (m_auto_Finished) //如果是完成报警（报警可能是开始报警，也可能是完成报警）
                {
                    timerStart.Stop();
                    Global.Print1.PrintingInfo = "本批次印刷完成";
                    SetStatusAuto(false);                //设置手工状态
                    m_auto_Finished = false;
                    return;
                }
                Positioning(); //开始对位
                m_auto_Positioning = true;
                return;
            }
            //////////////////////////////////////////对位阶段///////////////////////////////////////
            if (m_auto_Positioning)
            {
                if (!m_auto_First)
                    if (m_auto_Time - m_auto_SptBeginExTime >= Global.Print1.m_TUVDelay)
                    {
                        Global.Print1.SetUVEnale(false); // 如果不是第一轮且关UV时间到则关UV  
                        m_auto_UVEnabled = false;
                    }
                if (Global.Platform1.m_Positioning ==1)
                    return; //如果对位中则返回
                 
                if (Global.Platform1.m_Positioning == -1)// 对位失败
                {
                    Global.Spatula1.SptStop();
                    Global.Platform1.PltStop();
                    Global.PaperPuller1.PullStop();
                    timerStart.Stop();
                    SetStatusAuto(false);                //设置手工状态
                    m_auto_Time = 0;
                    return;
                }
                //如果对好位了
                Global.Spatula1.AutoMoveLeft();  //刮刀向左运动
                m_auto_Positioning = false;
                m_auto_SptToLeft = true;
                Global.Platform1.PltReset();  
                return;
             }
            /////////////////////////////////////////////刮刀向左阶段/////////////////////////////////
            if (m_auto_SptToLeft)
            {
                if (!Global.Spatula1.IsSptStop()) //还在运动则返回
                    return;
                if (!m_auto_SptExchanged) //如果还没有切换刮刀
                {
                    Global.Spatula1.ExchangeSptBack(); //切换刮刀和回墨刀 
                    m_auto_SptExchanged = true;
                    m_auto_SptBeginExTime = m_auto_Time; //记录开始切换刮刀时间
                    return ;
                }
                if (m_auto_Time - m_auto_SptBeginExTime >= Global.Spatula1.m_SptToBackTime) //等待切换刮刀完成则开始向右运动
                {
                    Global.Spatula1.AutoMoveRight();  //刮刀向右运动
                    m_auto_SptToLeft = false;
                    m_auto_SptToRight = true;
                    m_auto_SptExchanged = false;
                    m_auto_Time = 0; //清零
                    return;
                }
                return;
            }
            /////////////////////////////////////////////刮刀向右阶段/////////////////////////////////
            if (m_auto_SptToRight)
            {
                if (!Global.Spatula1.IsSptStop()) //如果刮刀在运动
                {
                    if (m_auto_First ) return;
                    if (!m_auto_UVEnabled && m_auto_Time >= m_auto_TopenUV &&  m_CurrentBackNum == Global.Spatula1.m_BackNumber)
                    {
                        Global.Print1.SetUVEnale(true);
                        m_auto_UVEnabled = true;
                    }
                    return;
                }
                if (m_auto_First) //如第一轮则记录开UV的时间
                {
                    m_auto_TopenUV = m_auto_Time + Global.Print1.m_StopPompDelay -Global.Print1.m_TUVAdvance ;
                }

                if (m_CurrentBackNum == Global.Spatula1.m_BackNumber) //如果到了指定刮墨次数
                {
                    if (!m_auto_PompExchanged) //如果没有开吹风
                    {
                        if (m_auto_First) //如果是第一轮，到刮刀停下再开UV
                        {
                            Global.Print1.SetUVEnale(true);
                            m_auto_First = false;
                        }
                        Global.Print1.SetPomping(false); //吸风切换成吹风
                        Global.Spatula1.ExchangeSptBack(); //切换刮刀和回墨刀
                        m_auto_PompExchanged = true;
                        m_auto_SptExchanged = false;
                        m_auto_PompBeginExTime = m_auto_Time; //记录开始切换吹风时间
                        return;
                    }
                }
                else
                {
                    Global.Spatula1.ExchangeSptBack(); //切换刮刀为回墨刀
                    m_auto_SptExchanged = false;
                    m_auto_PompBeginExTime = m_auto_Time; //记录开始切换成墨刀时间
                }

                if (m_CurrentBackNum == Global.Spatula1.m_BackNumber)
                {
                    if (m_auto_Time - m_auto_PompBeginExTime >= Global.Print1.m_StopPompDelay) //等到关吹风完成则开始拉料
                    {
                        Global.PaperPuller1.MoveNext();  //拉料一次
                        m_auto_PompExchanged = false;
                        m_auto_SptToRight = false;
                        m_auto_Pulling = true;
                        m_CurrentBackNum = 1;
                        Global.Print1.m_CurrentNum += 1;   //当前计数加一
                    }
                    return;
                }
                else //如果还没有到回墨次数
                {
                    if (m_auto_Time - m_auto_PompBeginExTime >= Global.Spatula1.m_BackDelay) //等到回墨刀切换完成则开始回墨
                    {
                        Global.Spatula1.AutoMoveLeft(); 
                        m_auto_SptToRight = false;
                        m_auto_SptToLeft = true;   //进入刮刀向左阶段
                        m_CurrentBackNum += 1; ;   //当前回墨计数加一
                    }
                    return;
                }
            }
            //////////////////////////////////////////////如果是在拉料阶段////////////////////////////////////////////////
            if (m_auto_Pulling) 
            {
                if (!Global.PaperPuller1.IsStop()) //拉料机还在运动则返回
                    return;
                if (Global.Print1.m_CurrentNum >= Global.Print1.m_NumOfStop || m_in_NoPaper ) //如果到了停止批次则报警停止，如果收到无纸停机信号也要停下来
                {
                    m_auto_Finished = true;
                    Global.Print1.BeginBeep();
                    timerBeep.Start();
                    m_auto_Beep = true; //切换到蜂鸣阶段
                    m_auto_Pulling = false;
                    if (m_in_NoPaper) Global.Print1.PrintingExcptInfo.Add("现在无料停机");  
                    return;
                }
                if (!m_auto_PompExchanged) //如果还没有切换为吸风
                {
                    Global.Print1.SetPomping(true); //吹风切换成吸风
                    m_auto_PompExchanged = true;
                    m_auto_PompBeginExTime = m_auto_Time; //记录开始切换吸风时间
                    return;
                }
                if (m_auto_Time - m_auto_PompBeginExTime >= Global.Print1.m_PompDelay) //等到关吸风完成则开始对位
                {
                    if (!Global.Platform1.PltIsStop()) return;   
                    Positioning();
                    m_auto_Positioning = true;
                    m_auto_PompExchanged = false;
                    m_auto_Pulling = false;
                }
                return;
            }
        }

        private void timerPull_Tick(object sender, EventArgs e)
        {
            Global.Print1.PrintingInfo = "拉料位置：" + (Global.PaperPuller1.m_Motor.GetCurrentPos()).ToString("f2");
            if (Global.PaperPuller1.IsStop()) timerPull.Stop(); 
        }

        private void timerBeep_Tick(object sender, EventArgs e)
        {
            m_BeepTime += timerBeep.Interval;
            if (m_BeepTime < Global.Print1.m_BeepTime) return;
            Global.Print1.StopBeep();
            timerBeep.Stop(); 

        }

        private void timerMove_Tick(object sender, EventArgs e)
        {
            Global.Print1.PrintingInfo = "刮刀位置：" + (Global.Spatula1.m_Motor.GetCurrentPos()).ToString("f2");
            if (Global.Spatula1.IsSptStop()) timerMove.Stop(); 
        }

        private void timerSendLight_Tick(object sender, EventArgs e)
        {
            if (timerSendLight.Tag.ToString() == "first")
                timerSendLight.Tag = "second";
            else
            {
                Global.Card0.WriteOutBit(MotionCard.OutBit.O_PaperOut,0);  //0表示低电平有效
                timerSendLight.Stop(); 
            }
        }

        private void lblExcept_DoubleClick(object sender, EventArgs e)
        {
            FormException frmE = new FormException();
            frmE.ShowDialog(); 
        }

        private void frmMain_Activated(object sender, EventArgs e)
        {
            CameraLeft.StartGrab();
            CameraRight.StartGrab();
        }

       

        private void btnCamSet_Click(object sender, EventArgs e)
        {
            
            frmCameraSelect formC = new frmCameraSelect();
            formC.ShowDialog();
            if (formC.m_SelectedCam == 0) //0代表左相机
            {
                if (CameraLeft == null) CameraLeft = new CameraDMK() ;
                CameraLeft.ShowSettings();
                CameraLeft.StartGrab();
            }
            else if (formC.m_SelectedCam == 1)//代表右相机
            {
                if (CameraRight == null) CameraRight = new CameraDMK();
                CameraRight.ShowSettings();
                CameraRight.StartGrab();
            }
            else
            {
                Global.Print1.PrintingInfo = "您没有选择相机";
            }
        }

        private void btnCamAjust_Click(object sender, EventArgs e)
        {
            frmAdjustCamera FrmAC = new frmAdjustCamera();
            FrmAC.ShowDialog();
        }

        private void btnCamCalib_Click(object sender, EventArgs e)
        {
            if (!Global.VerifyPassWord())
            {
                MessageBox.Show("您需要管理员密码才能进行标定操作");
                return;
            }
            if (!Global.Card0.m_CardInited)
            {
                MessageBox.Show("目前运动卡初始化不正常");
                return;
            }
            if (Global.Print1.IsRuning()==0) //0表示运行
            {
                Global.Print1.PrintingExcptInfo.Add("等设备都停下来再标定相机");
                return;
            }
            FormChoiceToCali formC = new FormChoiceToCali();
            formC.ShowDialog();
            if (formC.m_result == -1) return;
            if ((formC.m_result  == 0 || formC.m_result == 2) && !CameraLeft.m_CamInited) //0代表左相机进行长度标定,2是左相机长度标定
            {
                 Global.Print1 .PrintingExcptInfo.Add ("左相机未准备好，请先检查相机并进行设置");
                return;
            }
             if ((formC.m_result  == 1 || formC.m_result == 3) && !CameraRight.m_CamInited) //1代表右相机进行长度标定,3是左相机长度标定
            {
                 Global.Print1 .PrintingExcptInfo.Add ("右相机未准备好，请先检查相机并进行设置");
                return;
            }

            if (formC.m_result  == 0)//代表左相机进行长度标定
            {
                CameraLeft.ShowLenCalibrate();
            }
            else if (formC.m_result == 1 )//代表右相机进行长度标定
            {
               CameraRight.ShowLenCalibrate();
            }
            else if (formC.m_result == 2) //左相机标定方向
            {
                if (!CameraLeft.m_LenCalibrated  )
                {
                    Global.Print1.PrintingExcptInfo.Add("左相机还没有长度标定，请先进行长度标定");
                    return;
                }
                if (CalibrateDir(CameraLeft))
                {
                    Global.Print1.PrintingInfo = "左相机标定方向成功";
                }
            }
            else if (formC.m_result == 3) //右相机标定方向
            {
                if (!CameraRight.m_LenCalibrated  )
                {
                    Global.Print1.PrintingExcptInfo.Add("右相机还没有长度标定，请先进行长度标定");
                    return;
                }
                if (CalibrateDir(CameraRight))
                {
                    Global.Print1.PrintingInfo = "右相机标定方向成功";
                }
            }
            if(CameraLeft.m_AngleCalibrated && CameraRight.m_AngleCalibrated )
                Global.Print1.PrintingInfo = "全部标定成功"; 
        }

        private bool CalibrateDir(CameraDMK cam)
        {
            if (!cam.m_LenCalibrated) return false;
            PointF p1, p2;
            if(!cam.ShowSample()) return false;
            p1 = cam.m_SampleCenter;
            MessageBox.Show("请注意！ 现在要移动平台3mm");
            Global.Platform1.TranslateMove(3, 0);
            while (!Global.Platform1.PltIsStop())
            {
                Application.DoEvents();
            }
            if(!cam.GetMarkCenter ()) return false;
            p2 = cam.m_MarkCenter;
            
            cam.m_AngleCalib = -Math.Atan2(p2.Y - p1.Y, p2.X - p1.X); //照相机的XY方向和外部坐标系一致的情况下，改转角为相机坐标系相对于外部坐标系的逆时针角度
            cam.m_AngleCalibrated = true;
            return true;
        }



        private void  btnCamSample_Click(object sender, EventArgs e)
        {
            frmCameraSelect formC = new frmCameraSelect();
            formC.ShowDialog();
            if (formC.m_SelectedCam == 0) //0代表左相机
            {
                if (CameraLeft == null)
                {
                    MessageBox.Show("左相机未准备好，请先检查相机并进行设置");
                    CameraLeft = new CameraDMK();
                    return;
                }
                CameraLeft.ShowSample();
            }
            if (formC.m_SelectedCam == 1)//代表右相机
            {
                if (CameraRight == null)
                {
                    MessageBox.Show("右相机未准备好，请先检查相机并进行设置");
                    CameraRight = new CameraDMK();
                    return;
                }
                CameraRight.ShowSample();
            }
        }

        private void btnStopPrint_Click(object sender, EventArgs e)
        {
            Global.Spatula1.SptStop();  
            Global.Platform1.PltStop();
            Global.PaperPuller1.PullStop();   
        }

        private void btnManualPosition_Click(object sender, EventArgs e)
        {
            if (!PreparePositioning())
            {
                Global.Platform1.m_Positioning = 0;
                return;
            }
            Positioning();
         }

        private void Positioning()
        {
            int intervel = timerStart.Interval;
            timerStart.Interval = 100;         //放缓自动印刷期间的时间探测间隔
            Global.Platform1.m_Positioning = 1; //表示对位中
            if (_Positioning()) //如果对位成功
            {
                Global.Platform1.m_Positioning = 2;
                this.richTextBox1.Text = "对位成功" + "\n" + this.richTextBox1.Text;
            }
            else
            {
                Global.Platform1.m_Positioning = -1;
                this.richTextBox1.Text = "对位失败" + "\n" + this.richTextBox1.Text;
            }
            timerStart.Interval = intervel; //恢复自动印刷期间的时间探测间隔
       }

        private bool _Positioning()
        {
            PointF p1 = new PointF(), p2 = new PointF(), pRotateCenter;
            double angle;
            int num = 1;
            while (true)
            {
                if (!CameraRight.GetMarkCenter())
                {
                    Global.Print1.PrintingExcptInfo.Add("获取右相机mark点失败");
                    return false ;
                }
                if (!CameraRight.GetMarkCenter())
                {
                    Global.Print1.PrintingExcptInfo.Add("获取左相机mark点失败");
                    return false;
                }
                if (!Global.Platform1.m_RightCam.PointToPltSys(CameraRight.m_MarkCenter, ref p1)) return false;
                if (!Global.Platform1.m_LeftCam.PointToPltSys(CameraLeft.m_MarkCenter, ref p2)) return false;
                //如果满足精度则退出
                if (Global.DistanceOfPoint(CameraLeft.m_SampleCenter, CameraLeft.m_MarkCenter) < Global.Platform1.m_PositonAcuracy && Global.DistanceOfPoint(CameraRight.m_SampleCenter, CameraRight.m_MarkCenter) < Global.Platform1.m_PositonAcuracy) break;
                //输出对位次数
                this.richTextBox1.Text = "第" + num.ToString() + "次对位" + "\n" + this.richTextBox1.Text;
                //计算并驱动平台移动
                float lPercent = (float)Global.Platform1.m_LeftComp;
                pRotateCenter = new PointF(p1.X * (1-lPercent ) + p2.X * lPercent , p1.Y * (1-lPercent ) + p2.Y *lPercent );
                angle = Math.Atan2((p2.Y - p1.Y), (p2.X - p1.X));
                Global.Platform1.m_XPosCmps = Global.Platform1.m_SamplesCenter.X - pRotateCenter.X;
                Global.Platform1.RigidMove(pRotateCenter, Global.Platform1.m_SamplesAngle - angle, Global.Platform1.m_SamplesCenter.X - pRotateCenter.X, Global.Platform1.m_SamplesCenter.Y - pRotateCenter.Y);
                while (!Global.Platform1.PltIsStop())
                {
                    Application.DoEvents();
                }
                num++;
                if (num > Global.Platform1.m_PostionNum)
                {
                    Global.Print1.PrintingExcptInfo.Add("已经超过了最高对位次数！");
                    return false;
                }
            }
            return true;
        }

        private bool PreparePositioning()
        {
            //Global.Platform1.m_Positioning = 0; //表示尚未开始对位
            if (Global.Print1.IsRuning()==0)
            {
                Global.Print1.PrintingExcptInfo.Add("请停机后再手工对位");
                return false ;
            }
            if (CameraLeft == null || CameraRight == null)
            {
                Global.Print1.PrintingExcptInfo.Add("相机没有准备好");
                return false;
            }
            if (!Global.Platform1.m_LeftCam.m_CamBind)
            {
                if (!Global.Platform1.m_LeftCam.BindCamera(CameraLeft))
                    Global.Print1.PrintingExcptInfo.Add("左相机还没有经过调整或标定");
                return false;
            }
            if (!Global.Platform1.m_RightCam.m_CamBind)
            {
                if (!Global.Platform1.m_RightCam.BindCamera(CameraRight))
                    Global.Print1.PrintingExcptInfo.Add("右相机还没有经过调整或标定");
                return false;
            }
            PointF p1 = new PointF() ,p2 = new PointF ();
            if(!Global.Platform1.m_RightCam.PointToPltSys(CameraRight.m_SampleCenter,ref p1)) return false ;
            if (!Global.Platform1.m_LeftCam.PointToPltSys(CameraLeft.m_SampleCenter, ref p2)) return false;
            Global.Platform1.m_SamplesCenter = new PointF((p1.X +p2.X )/2, (p1.Y +p2.Y )/2);
            Global.Platform1.m_SamplesAngle = Math.Atan2((p2.Y - p1.Y), (p2.X - p1.X));  
           return true;
        }


        private void btnExit_Click(object sender, EventArgs e)
        {
            DialogResult  rst = MessageBox.Show("要存储相机取样并退出系统吗？“是”：存储并退出，“否”：直接退出，“取消”：返回主界面。", "退出系统", MessageBoxButtons.YesNoCancel );
            if ( rst == DialogResult.Cancel)
                return;
            if (Global.Print1.IsRuning()==0)
            {
                Global.Print1.PrintingExcptInfo.Add("请先停止机器再退出系统");
                return;
            }
            if (rst == DialogResult.Yes &&  Global.Card0.m_CardInited )
            {
                Global.WriteToFile(Global.LeftCamName, CameraLeft);
                Global.WriteToFile(Global.RightCamName, CameraRight); 
            }
            Application.Exit();
        }

        private void btnPrintSet_Click(object sender, EventArgs e)
        {
            FormPrintSet formPrint = new FormPrintSet();
            formPrint.ShowDialog();
         }

        private void btnIO_Click(object sender, EventArgs e)
        {
            FormIO formIO = new FormIO();
            formIO.Show();
         }

        private void btnPltSet_Click(object sender, EventArgs e)
        {
             FormPltSet formP = new FormPltSet();
            formP.ShowDialog();
        }

        private void btnSysReset_Click(object sender, EventArgs e)
        {

        }

        private void btnPosSet_Click(object sender, EventArgs e)
        {
           
        }

       

       
        //endof last Method

        
    }//end of last Class
}
