using System;
using System.Windows.Forms;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.IO;
using csLTDMC;
using PrintInterface;
using System.Runtime.Serialization.Formatters.Soap;
//using System.Windows.Media;
/*
 * Axis4X类是四个马达驱动的运算，四个马达呈矩形排布。
 * 只有一个运动控制卡，卡号为0。
 * 轴号从左前角开始，按顺时针顺序，依次为0，1，2，3。
 * 默认0号轴是X方向（横向运动）
 */
namespace csMotion
{
    public static class Global
    {
        public static MotionCard Card0;
        public static Screw3Axis2Y Platform1;
        public static Spatula Spatula1;
        public static PaperPuller PaperPuller1;
        public static Printing Print1;
        public static FormMain MainPage;
        public static string SaveDirectory = "Data";
        public static string PrintName = "PrintSettings.dat";
        public static string PlatformName = "PlatformSettings.dat";
        public static string PullerName = "PullerSettings.dat";
        public static string SpatulaName = "SpatulaSettings.dat";
        public static string LeftCamName = "LeftCamSettings.dat";
        public static string RightCamName = "RightCamSettings.dat";

        public static void GetKeyboardNum(Object sender)
        {
            Keyboard kb = new Keyboard((TextBox)sender);
            try
            {
                string s = ((TextBox)sender).Tag.ToString();
                string[] strArr = s.Split('/');
                kb.m_min = double.Parse(strArr[0]);
                kb.m_max = double.Parse(strArr[1]);
            }
            catch (Exception)
            {
            }
            kb.ShowDialog();
            ((TextBox)sender).Text = kb.m_Text;
        }

        public static double DistanceOfPoint(PointF p1, PointF p2)
        {
            return Math.Sqrt((p1.X - p2.X) * (p1.X - p2.X) + (p1.Y - p2.Y) * (p1.Y - p2.Y));
        }
        public static void CenterForm(Form frm)
        {
            int W = 1024;
            int H = 768;
            Point st = new Point();
            st.X = (W - frm.Width) / 2;
            st.Y = (H - frm.Height) / 2;
            frm.Location = st;
        }
        public static int Int45(double d)
        {
            if (d > 0)
                return (int)(d + 0.5);
            else
                return (int)(d - 0.5);
        }

        public static string ShowDMCErr(short err)
        {
            string msg;
            switch (err)
            {
                case 0:
                    msg = "成功";
                    break;
                case 1:
                    msg = "未知错误";
                    break;
                case 2:
                    msg = "参数错误";
                    break;
                case 3:
                    msg = "操作超时";
                    break;
                case 4:
                    msg = "控制卡状态忙";
                    break;
                case 6:
                    msg = "连续插补错误";
                    break;
                case 8:
                    msg = "无法连接错误";
                    break;
                case 9:
                    msg = "卡号错误";
                    break;
                case 10:
                    msg = "数据传输错误";
                    break;
                case 12:
                    msg = "固件文件错误";
                    break;
                case 14:
                    msg = "固件不匹配";
                    break;
                case 20:
                    msg = "固件参数错误";
                    break;
                case 22:
                    msg = "固件当前状态不允许操作";
                    break;
                case 24:
                    msg = "控制器不支持的功能";
                    break;
                default:
                    msg = "未定义错误";
                    break;
            }
            return msg;
        }

        public static void WritePltToFile()
        {
            WriteToFile(PlatformName, Platform1);
        }
        public static void WriteSpatulaToFile()
        {
            WriteToFile(SpatulaName, Spatula1);
        }
        public static void WritePrintToFile()
        {
            WriteToFile(PrintName, Print1);
        }
        public static void WritePullerToFile()
        {
            WriteToFile(PullerName, PaperPuller1);
        }

        public static void  WriteToFile(string filename, Object obj)
        {
            string newpath = Path.Combine(Global.SaveDirectory, filename);
            if (!Directory.Exists(SaveDirectory))
            {
                Directory.CreateDirectory(Global.SaveDirectory);
            }
            SoapFormatter formatter = new SoapFormatter();
            Stream stream = new FileStream(newpath, FileMode.Create, FileAccess.Write, FileShare.None);
            formatter.Serialize(stream, obj);
            stream.Close();
        }

        public static Object ReadFromFile(string filename)
        {
            string newpath = Path.Combine(SaveDirectory, filename);
            if(!File.Exists(newpath)) return null;
            
            SoapFormatter formatter = new SoapFormatter();
            Object obj;
            Stream stream = new FileStream(newpath, FileMode.Open, FileAccess.Read, FileShare.Read);
            try
            {
                obj = formatter.Deserialize(stream);
            }
            catch (Exception)
            {
                stream.Close();
                return null;
            }
                stream.Close();
                return obj;
         }
        public static bool ReadFromFile(string path, Object obj)
        {
            if (!File.Exists(path) || obj == null) return false;

            SoapFormatter formatter = new SoapFormatter();
            Stream stream = new FileStream(path, FileMode.Open, FileAccess.Read, FileShare.Read);
            try
            {
                obj = formatter.Deserialize(stream);
            }
            catch (Exception)
            {
                stream.Close();
                return false;
            }
            stream.Close();
            return true;
        }

        public static void InitFromFile()
        {
            Card0 = new MotionCard();
            Platform1 = (Screw3Axis2Y)ReadFromFile(PlatformName);
            if (Platform1 == null) Platform1 = new Screw3Axis2Y();
            Spatula1 = (Spatula)ReadFromFile(SpatulaName);
            if (Spatula1 == null) Spatula1 = new Spatula();
            PaperPuller1 = (PaperPuller)ReadFromFile(PullerName);
            if (PaperPuller1 == null) PaperPuller1 = new PaperPuller();
            Print1 = (Printing)ReadFromFile(PrintName);
            if (Print1 == null) Print1 = new Printing();
        }

        public static string Hash_MD5_32(string word, bool toUpper = true)
        {
            try
            {
                System.Security.Cryptography.MD5CryptoServiceProvider MD5CSP = new System.Security.Cryptography.MD5CryptoServiceProvider();
                byte[] bytValue = System.Text.Encoding.UTF8.GetBytes(word);
                byte[] bytHash = MD5CSP.ComputeHash(bytValue);
                MD5CSP.Clear();
                //根据计算得到的Hash码翻译为MD5码
                string sHash = "", sTemp = "";
                for (int counter = 0; counter < bytHash.Count(); counter++)
                {
                    int i = bytHash[counter] / 16;
                    if (i > 9)
                    {
                        sTemp = ((char)(i - 10 + 0x41)).ToString();
                    }
                    else
                    {
                        sTemp = ((char)(i + 0x30)).ToString();
                    }
                    i = bytHash[counter] % 16;
                    if (i > 9)
                    {
                        sTemp += ((char)(i - 10 + 0x41)).ToString();
                    }
                    else
                    {
                        sTemp += ((char)(i + 0x30)).ToString();
                    }
                    sHash += sTemp;
                }
                //根据大小写规则决定返回的字符串
                return toUpper ? sHash : sHash.ToLower();
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
        public static bool VerifyPassWord()
        {
            FormVerify frm = new FormVerify();
            frm.ShowDialog();
            if (frm.m_pwdYes)return true ;
           return false;
        }

        public static bool CheckPassWord(string pwd)
        {
           if(Hash_MD5_32(pwd) == Print1.m_Password ) return true ;
           else 
            return false ;
        }
    }

               
    public class MotionCard
    {
        public  enum InBit:ushort 
        {
            I_ArmDown =0, //大臂降
            I_SptDown =1,//小臂降
            I_NetDown = 2, //网板降
            I_Move =  8,//点动
            I_EmgStop= 9,//急停
            I_PullPaper= 10,//拉料
            I_SendLight= 11,//送料光电
            I_NoPaper= 12, //无料停机
            I_Start= 13//启动
        }
        public  enum OutBit : ushort
        {
            O_Blow=0,// 风机
            O_Beep=1, //蜂鸣器
            O_UV=2, //UV致能
            O_Pump=3,//吸风电磁阀
            O_Spatula=4, //刮刀电磁阀
            O_PaperOut=5,//送料输出
            O_LightBox=6,//灯箱
            O_Spotlight=7, //射灯
            O_InPaper=8//进料吸风
        }
        public  enum ScrewIdx : ushort 
        {
            Plt_Y1=0,
            Plt_Y2 =1,
            Plt_X = 2,
            Sptula =3,
            Puller =4,
            Camera1 =5,
            Camera2 =6
        }
        

        public ushort m_CardID ;
        public  bool m_CardInited; // 运动卡已经初始化

       public MotionCard()
        {
            m_CardID =0;
            m_CardInited =false ;
        }

        public bool  InitializeCard()
        {
            try
            {
                short num = LTDMC.dmc_board_init();//获取卡数量
                if (num <= 0 || num > 8)
                {
                    Global.Print1.PrintingExcptInfo.Add("初始卡失败!");
                    return false;
                }
                ushort _num = 0;
                ushort[] cardids = new ushort[8];
                uint[] cardtypes = new uint[8];
                short result = LTDMC.dmc_get_CardInfList(ref _num, cardtypes, cardids);
                if (result != 0)
                {
                    Global.Print1.PrintingExcptInfo.Add("获取卡信息失败!");
                    return false ;
                }
                m_CardID = cardids[0];
                if (m_CardID != 0)
                {
                    Global.Print1.PrintingExcptInfo.Add("运动卡号不为零！");
                    return false ;
                }
                ushort state = 0;
                short rst = LTDMC.dmc_LinkState(m_CardID , ref state);
                if(state == 1)//接线盒与运动卡处于断开
                {
                    Global.Print1.PrintingExcptInfo.Add("接线盒未连接：" + Global.ShowDMCErr(rst) );
                    return false;
                }
            }
            catch (Exception e1)
            {
                Global.Print1.PrintingExcptInfo.Add( "初始化运动卡失败:"+ e1.Message);
                return false;
            }
            m_CardInited = true;
            Global.Print1.PrintingInfo ="运动卡初始化成功" ;
            return true ;
        }

        public ushort ReadInBit(InBit bit)
        {
            return (ushort)LTDMC.dmc_read_inbit(m_CardID, (ushort)bit);
        }
        public ushort ReadOutBit(OutBit bit)
        {
            return (ushort)LTDMC.dmc_read_outbit(m_CardID, (ushort)bit);
        }
        public ushort WriteOutBit(OutBit bit, ushort on_off)
        {
            return (ushort)LTDMC.dmc_write_outbit(m_CardID, (ushort)bit, on_off);
        }
        public void InvalidNegLimit(ushort screw) //禁用负限位
        {
            LTDMC.dmc_set_el_mode(m_CardID, screw, 3, 0, 1);// 3表示负限位禁止，0表示低电平有效，1表示正负限位减速停止
        }
        public void ResetLimitsMode(ushort screw)
        {
            LTDMC.dmc_set_el_mode(m_CardID, screw, 1, 0, 1);// 1表示正负限位允许，0表示低电平有效，1表示正负限位减速停止
        }
        public uint GetLgcLmtP(ushort screw) // 读取正限位，screw 为轴号，返回0或1，0 代表低电平 
        {
            uint rst = LTDMC.dmc_read_inport(m_CardID, 0);
            int bit = screw + 16;
            return (rst >> bit) & 0x1;
        }
        public uint GetLgcLmtN(ushort screw)// 读取负限位，screw 为轴号，返回0或1，0 代表低电平 
        {
            uint rst = LTDMC.dmc_read_inport(m_CardID, 0);
            int bit = screw + 24;
            return (rst >> bit) & 0x1;
        }
        public uint GetLgcOrg(ushort screw)// 读取原点，screw 为轴号，返回0或1，0 代表低电平 
        {
            uint rst = LTDMC.dmc_read_inport(m_CardID, 1); 
            return (rst >> screw) & 0x1;
        }
        public uint GetInPort(ushort no)
        {
            return LTDMC.dmc_read_inport(m_CardID, no);
        }
        public uint GetOutPort()
        {
            return LTDMC.dmc_read_outport(m_CardID, 0);
        }
    }

    [Serializable]
    public class Screw3Axis2Y  //这是3马达驱动，2个定位轴的平台类，左轴的驱动方向是Y，右轴是XY，默认0号电机驱动Y1轴，1号驱动Y2轴，2号驱动X轴
    {

        [NonSerialized] public bool m_FlagReset=false ;//True 说明平台已经初始化并复位，False 说明没有复位，
        [NonSerialized] public bool m_FlagHome = false; //已归零

        private ushort m_CardID =0;//默认是0，只有一个卡
        private Mat2DNormal m_Mat2D= new Mat2DNormal ();//平台状态的矩阵,自定义的右手坐标系

        private ushort m_LCamScrewIdx =6;
        private ushort m_RCamScrewIdx =5;

        public double m_MaxSpeed=5;//各驱动轴的最高速度，也是自动对位时的速度，单位mm
        private double m_StartSpeed=2; //这几项是速度曲线设置
        private double m_AccTime=0.05;
        private double m_DecTime=0.05;
        private double m_STime=0.01;
        private double m_StopSpeed=2;

        private bool m_FlagVelSetted=false ; //运动卡已经设置了平台驱动轴必要的运动参数
        
        private float m_DistanceAxisX=1000; //四个轴心的X方向间距 mm
        private int m_PulsesPerRev =1000;   //每圈的脉冲数
        private float m_ThreadPitch=5;  // 丝杆螺距

        private PointF[] m_Axis= new PointF[2];//各支撑轴的轴心位置
        private bool[] m_ScrewDirection = new bool[3] { true, true, true }; //各驱动轴的方向 
        private int[] m_WorkPos = new int[3];  //单位Pulse，是运动卡记忆的位置，转化为外在尺度需要变换
        private Mat2DNormal m_WorkPosMat=new Mat2DNormal (); //这是对应工作位置的内部矩阵
        private ushort m_PulseMode=0;

        //以下是平台的对位参数
        [NonSerialized]  public int m_Positioning = 0; // 0= 没有进行对位；1= 正在对位；2= 对位成功； -1= 对位失败
        public double m_ManualSpeed=3;  //手工对位速度，或调试时手动速度
        private double m_PositionSpeed; //实际对位的速度
        public double m_PositonAcuracy=0.05; //对位精度
        public int m_PostionNum=10;       //对位次数
        [NonSerialized ]public double m_XPosCmps=0.01; // 纵向对位补偿 ,运行时才计算
        public double m_XPrtCmps=0; //纵向印刷补偿
        public double  m_LeftComp= 0.5; //这是向左纵向补偿比例,向右纵向补偿比例可以算出
        public PointF m_SamplesCenter=new PointF(); //左右相机取样后，两个样本中心连线在总坐标系位置
        public double m_SamplesAngle=0; //左右相机取样后，两个样本中心连线在总坐标系角度，单位弧度

        //归零参数
        ushort m_HomeDir = 0; //负向回零
        ushort m_HomeMode = 2; //二次回零
        ushort m_HomeSpeedMode = 0; //低速回零

        //以下是相机运动参数
        public CamMotor m_LeftCam; //左相机驱动
        public CamMotor m_RightCam; //右相机驱动

        public Screw3Axis2Y()
        {
            m_Axis = new PointF[2];
            m_Axis[0] = new PointF(0,0);
            m_Axis[1] = new PointF(m_DistanceAxisX,0);
            m_WorkPos = new int[3] { 0, 0, 0 };
            PointF p1 = new Point(725,200); //左相机归零时的坐标
            PointF p2 = new Point(275,200); //右相机归零时的坐标
            m_LeftCam = new CamMotor(m_CardID , m_LCamScrewIdx,true,0,p2);//true表示方向与坐标轴一致，0表示负向回零
            m_RightCam = new CamMotor(m_CardID, m_RCamScrewIdx, true, 0,p1);
        }

        //平台初始化
       public bool InitPlatorm()
       {
           if(!Global.Card0.m_CardInited) 
           {
               Global.Print1.PrintingExcptInfo.Add("运动控制卡还没有初始化");
               return false;
           }
           ushort screw;
           for (screw = 0; screw < 3; screw++)
           {
               LTDMC.dmc_set_pulse_outmode(m_CardID, screw, m_PulseMode);//设置脉冲模式
               LTDMC.dmc_set_home_pin_logic(m_CardID, screw, 0, 0);//各驱动轴设置原点低电平有效
           }
           SetAllScrewMotionRef();
           SetToHomeRef();
           m_LeftCam.Initialize();
           m_RightCam.Initialize();
           return true;
       }

        //外面初始化设置各个运动轴的速度曲线,单位mm
        public void SetPltVel(double dStartVel, double dMaxVel, double dTacc, double dTdec, double dStopVel, double dS_para)
        {
            m_StartSpeed = dStartVel;
            m_MaxSpeed = dMaxVel;
            m_AccTime = dTacc;
            m_DecTime = dTdec;
            m_StopSpeed = dStopVel;
            m_STime = dS_para;
            SetAllScrewMotionRef();
            m_FlagVelSetted = true;
        }

        //把速度曲线参数设置到运动卡上
        private void SetAllScrewMotionRef()
        {
            double dStartVel =m_StartSpeed * m_PulsesPerRev / m_ThreadPitch;
            double dMaxVel = m_MaxSpeed * m_PulsesPerRev / m_ThreadPitch;
            double dStopVel = m_StopSpeed * m_PulsesPerRev / m_ThreadPitch;
            ushort screw;
            for (screw = 0; screw < 3; screw++)
            {
                LTDMC.dmc_set_profile(m_CardID, screw, dStartVel, dMaxVel, m_AccTime , m_DecTime, dStopVel);//设置速度参数
                LTDMC.dmc_set_s_profile(m_CardID, screw, 0, m_STime );//设置S段速度参数
                LTDMC.dmc_set_dec_stop_time(m_CardID, screw, m_DecTime); //设置减速停止时间;
            }
        }
        /*
        public void SetCoordinateRef()
        {
            double dStartVel = m_StartSpeed * m_PulsesPerRev / m_ThreadPitch;
            double dMaxVel = m_MaxSpeed * m_PulsesPerRev / m_ThreadPitch;
            double dStopVel = m_StopSpeed * m_PulsesPerRev / m_ThreadPitch;
            LTDMC.dmc_set_vector_profile_multicoor(m_CardID, 0, dStartVel, dMaxVel, m_AccTime, m_DecTime, dStopVel);
        }*/

        public void SetAutoSpeed()
        {
            m_PositionSpeed =  m_MaxSpeed ;
        }
        public void  SetManualSpeed()
        {
            m_PositionSpeed = m_ManualSpeed;
        }

        // //外部设置平台驱动轴限速
        public bool SetVelocity(double v) //v 的单位是mm/s
        {
            if (!m_FlagVelSetted)
            {
                Global.Print1.PrintingExcptInfo.Add("请先设置各轴参数");
                return false;
            }
            m_MaxSpeed = v;
            for (UInt16 screw = 0; screw < 3; screw++)
            {
                SetScrewSpeed(v, screw);
            }
            return true;
        }

        //运动卡单轴速度设置
        private void SetScrewSpeed(double speedDistance, ushort axis)//设置轴速(单位mm），其他不变，axis 是轴号
        {
            double Min_Vel = 0.0, Max_Vel = 0.0, Tacc = 0.0, Tdec = 0.0, stop_vel = 0.0;
            double speedPulse = speedDistance / m_ThreadPitch * m_PulsesPerRev;

            LTDMC.dmc_get_profile(0, axis, ref  Min_Vel, ref Max_Vel, ref Tacc, ref Tdec, ref stop_vel);
            LTDMC.dmc_set_profile(0, axis, Min_Vel, speedPulse, Tacc, Tdec, stop_vel);
        }

        public bool PltIsStop()
        {
           for (ushort  screw = 0; screw< 3; screw++)
            {
                if (LTDMC.dmc_check_done(m_CardID, screw) == 0) // 读取指定轴运动状态, 0表示在运动
                {
                    return false ;
                }
             }
            return true;
        }


        //供外部调用函数，以下是刚体运动,先绕着pCenter转动角度Angle,然后再平移xMove和yMove
        public void RigidMove(PointF pCenter, double Angle, double xMove, double yMove)
        {
            PlainMove(pCenter, Angle, xMove, yMove);
        }

        //以下是绕给定点做旋转运动，供调用
        public void RotateMove(PointF pCenter, double Angle)//Angle 是弧度
        {
            PlainMove(pCenter, Angle, 0.0, 0.0); //平移为零

        }

        //以下是平移运动，供调用

        public void TranslateMove(double xMove, double yMove)
        {
            PlainMove(new PointF(), 10.0, xMove, yMove); //   第二个参数大于2*3.14 ，意思是旋转无效

        }

        //下面是平台的通用移动方法
        private void PlainMove(PointF pCenter, double Angle, double xMove, double yMove)
        {
            PointF[] A = new PointF[4];
            ushort i;
            for (i = 0; i < 2; i++)
            {
                A[i] = m_Mat2D * m_Axis[i];
            }
            if (Angle < 3.1415926 * 2 && Angle > -3.1415926 * 2)
                m_Mat2D = m_Mat2D.RotateAt(pCenter, Angle);//Windows.Media里的Rotate是顺时针，我们计算时设定逆时针为正，所以角度取反。
            m_Mat2D = m_Mat2D.Translate(xMove, yMove);
            for (i = 0; i < 2; i++)
            {
                m_Axis[i] = m_Mat2D * m_Axis[i];
            }
            double[] D = new double[3];
            D[0] = m_Axis[0].Y- A[0].Y;
            D[1] = m_Axis[1].Y - A[1].Y;
            D[2] = m_Axis[1].X - A[1].X;
            
            double MaxD = 0.0;
            for (i = 0; i < 3; i++)
            {
                if (MaxD < Math.Abs(D[i])) MaxD = Math.Abs(D[i]);
            }

            double[] V = new double[3];
            int[] Dpulse = new int[3];
            for (i = 0; i < 3; i++)
            {
                V[i] = Math.Abs(D[i] / MaxD * m_PositionSpeed);//计算各轴速度
                SetScrewSpeed(V[i], i);
                Dpulse[i] = (int)(D[i] / m_ThreadPitch * m_PulsesPerRev);
                if (!m_ScrewDirection[i]) Dpulse[i] = -Dpulse[i];   //根据电机设置决定脉冲数是否反向
            }
            i = 0;
            for (i = 0; i < 3; i++)
            {
                LTDMC.dmc_pmove(m_CardID, i, Dpulse[i], 0);//i号轴移动定长
            }
            m_FlagReset = false; //平台移动后复位标志失效
        }

        //设置归零参数
        public void SetHomeRef(bool direction, bool highspeed, ushort mode)
        {
            m_HomeDir = 1; //1表示正向回零
            if (!direction) m_HomeDir = 0; //0 是负向回零
            m_HomeSpeedMode = (ushort)(highspeed ? 1 : 0);
            m_HomeMode = mode;
            SetToHomeRef();
        }
        public void GetHomeRef(out bool dir, out bool highspeed, out ushort mode)//speed速度是mm/s
        {
            dir = (m_HomeDir == 1); // 1表示正向回零
            mode = m_HomeMode;
            highspeed = (m_HomeSpeedMode == 1 ? true : false);
        }
        private void SetToHomeRef()
        {
            for (ushort screw = 0; screw < 3; screw++)
            {
                LTDMC.dmc_set_homemode(m_CardID, screw, m_HomeDir, (double)m_HomeSpeedMode, m_HomeMode, 0);
            }
        }
        public bool  MoveToHome()// 平台归零
        {
            if (!CheckForMove()) return false;

            for (ushort screw = 0; screw < 3; screw++)
            {
                LTDMC.dmc_home_move(m_CardID, screw);//三轴启动回零
            }
            while (!PltIsStop())
            {
                Application.DoEvents();
            }
            for (ushort screw = 0; screw < 3; screw++)
            {
                LTDMC.dmc_set_position(m_CardID, screw , 0);
            }
            m_Mat2D =new Mat2DNormal ();
            m_FlagHome = true;
            return true;
        }

        public bool PltReset()// 平台复位到工作位置
        {
            if (!MoveToHome()) return false;
            ushort screw;
            for (screw = 0; screw < 3; screw++)
                {
                    LTDMC.dmc_pmove(m_CardID, screw, m_WorkPos [screw], 1);
                }
            m_Mat2D = new Mat2DNormal (m_WorkPosMat );
            m_FlagReset = true;
            return true;
        }

        private bool CheckForMove()
        {
            if (!m_FlagVelSetted)
            {
                Global.Print1.PrintingExcptInfo.Add (" 还没有设置运动轴参数");
                return false ;
            }
            return true;
        }

       
        public void GetAxisPos(out PointF axis0, out PointF axis1)
        {
            axis0 = m_Mat2D * m_Axis[0];
            axis1 = m_Mat2D * m_Axis[1];
        }

        public double GetPltAngle()
        {
            return m_Mat2D.GetAngle();
        }

        public double GetAxisDistance()
        {
            return m_DistanceAxisX;
        }

        public double GetScrewPosition(ushort screw)
        {
            return (double) LTDMC.dmc_get_position(m_CardID, screw) * m_ThreadPitch /m_PulsesPerRev ;
        }

        
        public void TranslateXTo(double des)
        {
            int pos = Global.Int45(des /m_ThreadPitch * m_PulsesPerRev );
            if (LTDMC.dmc_check_done(m_CardID, 2) == 0)    //如果2号轴在运行
            {
                LTDMC.dmc_reset_target_position(m_CardID, 2, pos, 1);  //在线变位
            }
            else
            {
                LTDMC.dmc_pmove(m_CardID, 2, pos, 1); //绝对模式运动过去
            }
            m_Mat2D.SetOffsetX(des);
        }

        public void PltStop()
        {
            ushort stop_mode = 0; //制动方式，0：减速停止，1：紧急停止
            for (ushort screw = 0; screw < 3; screw++)
            {
          
                LTDMC.dmc_stop(m_CardID, screw, stop_mode);
            }
        }
        public void EmgStop()
        {
            ushort stop_mode = 1; //制动方式，0：减速停止，1：紧急停止
            for (ushort screw = 0; screw < 3; screw++)
            {

                LTDMC.dmc_stop(m_CardID, screw, stop_mode);
            }
        }


        public  void GetWorkPostion( double[]Wpos) //得到的是mm
        {
           for (int i = 0; i < 3; i++)
            {
                Wpos[i] = m_WorkPos[i] / m_PulsesPerRev * m_ThreadPitch;
                if (m_ScrewDirection[i] == false) Wpos[i] = -Wpos[i];
            }
        }

        
        public void SetCurrentToWorkPostion()
        {
            for (ushort  i = 0; i < 3; i++)
            {
               m_WorkPos[i] = LTDMC.dmc_get_position(m_CardID ,i);
            }
            m_WorkPosMat = new Mat2DNormal(m_Mat2D); 
        }

        public void SetScrewsDirection(bool [] dir)
        {
            for (int i = 0; i < 3; i++)
            {
                m_ScrewDirection[i] = dir[i];
            }
        }

        public void SetScrewPulseMode(ushort mode)
        {
            if (mode < 0 || mode > 5)
            {
                MessageBox.Show("设置脉冲模式失败，模式值应该介于0-5."); 
            }
            for (ushort screw = 0; screw < 3; screw++)
            {
                LTDMC.dmc_set_pulse_outmode(m_CardID, screw, mode );
            }

        }

        public void GetSpeedRef( out double dStartVel, out double dMaxVel, out double dTacc, out double dTdec, out double dStopVel, out double dS_para)
        {
            dStartVel = m_StartSpeed;
            dMaxVel = m_MaxSpeed;
            dTacc = m_AccTime;
            dTdec = m_DecTime;
            dStopVel = m_StopSpeed;
            dS_para = m_STime;

        }

        public void GetLogicSet(out ushort pulseMode, bool[] screwDirection)
        {
            pulseMode = m_PulseMode;
            for (int i = 0; i < 3; i++)
            {
                screwDirection[i] = m_ScrewDirection[i];
            }
        }
        public bool CheckInitialed()
        {
            if (!m_FlagVelSetted)
            {
                Global.Print1.PrintingExcptInfo.Add("对位平台的速度参数还没有设置好！");
                return false;
            }
            return true;
        }
        public bool CheckForPrint()
        {
            if (!CheckInitialed()) return false;
            if (!m_FlagReset)
            {
                Global.Print1.PrintingExcptInfo.Add("对位平台还没有复位！");
                return false;
            }
            return true;
        }
  
    }

    

    [Serializable]
    public class Mat2DNormal // 这是自定义的平面运动矩阵类
    {
        private double M11;
        private double M12;
        private double M21;
        private double M22;
        private double OffsetX;
        private double OffsetY;
        public Mat2DNormal()
        {
            M11 = 1.0;
            M12 = 0.0;
            M21 = 0.0;
            M22 = 1.0;
            OffsetX = 0.0;
            OffsetY = 0.0;
        }

        public Mat2DNormal(Mat2DNormal m)
        {
            this.M11 = m.M11;
            this.M12 = m.M12;
            this.M21 = m.M21;
            this.M22 = m.M22;
            this.OffsetX = m.OffsetX;
            this.OffsetY = m.OffsetY;
        }

        public Mat2DNormal(double Angle)
        {
            M11 = Math.Cos(Angle);
            M12 = -Math.Sin(Angle);
            M21 = Math.Sin(Angle);
            M22 = Math.Cos(Angle);
            OffsetX = 0.0;
            OffsetY = 0.0;
        }

        public static Mat2DNormal operator *(Mat2DNormal mA, Mat2DNormal mB)
        {
            Mat2DNormal m = new Mat2DNormal();
            m.M11 = mA.M11 * mB.M11 + mA.M12 * mB.M21;
            m.M12 = mA.M11 * mB.M12 + mA.M12 * mB.M22;
            m.M21 = mA.M21 * mB.M11 + mA.M22 * mB.M21;
            m.M22 = mA.M21 * mB.M12 + mA.M22 * mB.M22;
            m.OffsetX = mA.M11 * mB.OffsetX + mA.M12 * mB.OffsetY + mA.OffsetX;
            m.OffsetY = mA.M21 * mB.OffsetX + mA.M22 * mB.OffsetY + mA.OffsetY;
            return m;
        }
        public static PointF operator *(Mat2DNormal m, PointF p)
        {
            PointF p1 = new PointF();
            p1.X = (float)(m.M11 * p.X + m.M12 * p.Y + m.OffsetX);
            p1.Y = (float)(m.M21 * p.X + m.M22 * p.Y + m.OffsetY);
            return p1;
        }

        public Mat2DNormal Translate(double xMove, double yMove)
        {
            Mat2DNormal m = this;
            m.OffsetX = this.OffsetX + xMove;
            m.OffsetY = this.OffsetY + yMove;
            return m;
        }

        public Mat2DNormal Rotate(double Angle)// Angle 是弧度
        {
            Mat2DNormal m = new Mat2DNormal(Angle);
            return m * this;

        }
        public Mat2DNormal RotateAt(PointF pCenter, double Angle)// Angle 是弧度
        {
            Mat2DNormal m1 = new Mat2DNormal(Angle);
            Mat2DNormal m2 = this.Translate(-pCenter.X, -pCenter.Y);
            Mat2DNormal m3 = (m1 * m2);
            return m3.Translate(pCenter.X, pCenter.Y);

        }
        public double GetAngle()
        {
            return Math.Asin(M21) * 180 / 3.1425926;
        }
        public void SetOffsetX(double offset)
        {
            OffsetX = offset;
        }
    }

    [Serializable ]
    public class Spatula //刮刀类
    {
        private ushort m_CardID =0;
              
        private double m_MaxSpeed=200;//刮刀运行的最高速度，也是运行速度，单位mm
        private double m_BackSpeed=150; //回墨速度
        private double m_ManualSpeed=50; //刮刀手动速度
       
        public SpatulaMotor m_Motor;
        
        public double m_LeftAdance=5; //刮刀左提前量
        public double m_RightAdance=5; //刮刀右提前量
        public double m_PrintDelay=0.1;       //刮刀延时
        public double m_BackDelay=0.1;   //回墨刀延时
        public ushort m_BackNumber=1; //回墨次数
        public int  m_SptToBackTime=300; // 回墨刀和刮刀转换时间,毫秒
        public double m_LeftWorkPos=400;  //左工作位置 mm
        public double m_RightWorkPos=100;  //右工作位置 mm

        [NonSerialized]public bool m_FlagHome = false;
        [NonSerialized]public bool m_FlagReset=false;
        [NonSerialized] private bool m_RightBack = true; //默认右侧是回墨刀
        public double m_LenOfLimits = 600; //总长

        public Spatula()
        {
           m_Motor = new SpatulaMotor();
        }

        //刮刀初始化
        public void InitSpatula()
        {
            if (!Global.Card0.m_CardInited)
            {
                MessageBox.Show("运动控制卡还没有初始化");
                return;
            }
            m_Motor.Initialize();
            SptReset();
        }
        
        //外面初始化设置各个运动轴的速度曲线,单位mm
        public void SetSptVel(double dStartVel, double dMaxVel, double dTacc, double dTdec, double dStopVel, double dS_para,double dBack, double dManual)
        {
            if (!Global.Card0.m_CardInited)
            {
                MessageBox.Show("运动卡还没有初始化！");
                return;
            }
            m_Motor.SetProfile (dStartVel,dMaxVel,dTacc, dTdec, dStopVel,dS_para);
            m_BackSpeed = dBack;
            m_ManualSpeed = dManual;
        }

        public bool SetToManualSpeed() //设置成手工速度
        {
            return SetVelocity(m_ManualSpeed);
        }
        public bool SetToAutoSpeed()  //设置成运行速度
        {
           return SetVelocity(m_MaxSpeed); 
        }
        public bool SetToBackSpeed()  //设置成回墨刀速度
        {
            return SetVelocity(m_BackSpeed);
        }
        // //外部设置刮刀速度 
        public bool SetVelocity(double v) //v 的单位是mm/s
        {
            return m_Motor.SetSpeed(v);
        }

        public bool IsSptStop() //判断是否停下来
        {
            return m_Motor.IsStop(); 
        }

        private void Move( double dMm) //以mm为单位移动相对位置，原点在右限位，向左为正
        {
            if (!Global.Card0.m_CardInited)
            {
                MessageBox.Show("运动卡还没有初始化！");
                return;
            }
            if (!m_Motor.m_ProfileSetted  )
            {
                MessageBox.Show(" 还没有设置运动轴参数");
                return;
            }
            if(!m_Motor.IsStop())
            {
                MessageBox.Show ("刮刀停止状态下才能做相对移动");
                return ;
            }
            m_Motor.Move(dMm );
        }

        public int MoveTo(double dMm) //以mm为单位移动相对位置，原点在右限位，向左为正
        {
           return m_Motor.MoveTo(dMm); 
        }
        public void ProhibitRightLimit() //禁止右限位，目的是进行回零运动
        {
            Global.Card0.InvalidNegLimit(m_Motor.m_ScrewIdx);
        }
        public void ResetLimits() //恢复右限位
        {
            Global.Card0.ResetLimitsMode(m_Motor.m_ScrewIdx);
        }

        public int MoveToHome() //回零运动
        {
           int rst= m_Motor.MoveToHome();
           if (rst == 0) m_FlagHome = true;
           return rst;
        }
       
        public void SptReset()// 平台复位到右工作位置
        {
            if (!m_FlagHome) return;
            MoveTo(m_RightWorkPos);
            m_FlagReset = true;
        }

       public void StartMove(bool dir) //dir 为true代表正向
        {
            m_Motor.StartMove(dir);
        }

        public double GetDiameter()
        {
            return m_Motor.m_Diameter;
        }

        
        public void SptStop()
        {
            m_Motor.Stop (0); //制动方式，0：减速停止，1：紧急停止
        }

        public void SptEmgStop()
        {
            m_Motor.Stop(1); //制动方式，0：减速停止，1：紧急停止
        }

       public bool SetMotorPulseMode(ushort mode)
        {
            if (mode < 0 || mode > 5)
            {
                return false ;
            }
            m_Motor.SetPulseMode(mode );
            return true;
        }
        
        public void GetSpeedRef(out double dStartVel, out double dMaxVel, out double dTacc, out double dTdec, out double dStopVel, out double dS_para,out double dBackV,out double dManualV)
        {
            dStartVel =m_Motor.m_StartSpeed;
            dMaxVel = m_Motor.m_MaxSpeed;
            dTacc = m_Motor.m_AccTime;
            dTdec = m_Motor.m_DecTime;
            dStopVel = m_Motor.m_StopSpeed;
            dS_para = m_Motor.m_STime;
            dBackV = m_BackSpeed;
            dManualV = m_ManualSpeed;
        }

        public ushort GetPulseMode()
        {
            return m_Motor.GetPulseMode();
         }
        
        public bool IsLeftLimit()   //是否有左限位
        {
            uint rst = Global.Card0.GetInPort(0);
            if (((rst >> 19) & 0x1) == 0) //19代表第3轴正限位
                return true;
            return false;
        }

        public bool IsRightLimit() //是否有右限位
        {
            uint rst = Global.Card0.GetInPort(0);
            if (((rst >> 27) & 0x1) == 0) //27代表第3轴负限位
                return true;
            return false;
        }
        
         public double GetLenOfLimits()  //记录了左右限位之间的距离
        {
            return m_LenOfLimits;
        }
        public  void SetLenOfLimits(double len)
        {
            m_LenOfLimits=len;
        }
        
        public void GetPrintRef(out double LAdvanc,out double RAdvance, out double PrintDelay, out double BackDelay, out ushort BackNumber)
        {
            LAdvanc = m_LeftAdance;
            RAdvance = m_RightAdance;
            PrintDelay = m_PrintDelay;
            BackDelay = m_BackDelay;
            BackNumber = m_BackNumber;
        }
        public void SetPrintRef(double LAdvanc,  double RAdvance,  double PrintDelay, double BackDelay,  ushort BackNumber)
        {
            m_LeftAdance=LAdvanc  ;
            m_RightAdance=RAdvance  ;
            m_PrintDelay = PrintDelay;
            m_BackDelay = BackDelay;
            m_BackNumber = BackNumber;
        }

        public void ExchangeSptBack()//刮刀和回墨刀转换
        {
            ushort bit = (ushort )(MotionCard.OutBit.O_Spatula); 
            short v    = LTDMC.dmc_read_outbit(m_CardID ,bit )   ;
            if (v == 0)
            {
                LTDMC.dmc_write_outbit(m_CardID, bit, 1); //反转电平
            }
            else
            {
                LTDMC.dmc_write_outbit(m_CardID, bit, 0);
            }
            m_RightBack = !m_RightBack;                  //m_RightBack 为true表示右侧墨刀
        }
        public int GetPulsePerRev()
        {
            return m_Motor.m_PulsePerRev ;
        }
        
       
        public bool CheckForPrint()
        {
            if (!m_FlagReset)
            {
                Global.Print1.PrintingExcptInfo.Add("自动印刷前请把刮刀复位");   
            }
            return true;
        }
        public void AutoMoveLeft()
        {
            double  dest = m_LeftWorkPos + m_LeftAdance ; //目标位置是左工作位置再加上左提前量
            MoveTo(dest);
        }
        public void AutoMoveRight()
        {
            double dest = m_RightWorkPos - m_PrintDelay; //目标位置是右工作位置再加上延迟量
            MoveTo(dest);
        }
    }//end of Class Spatula

    [Serializable ]
    public class PaperPuller
    {
        public double m_MaxSpeed=100;//拉料机运行的最高速度，也是运行速度，单位mm
        public double m_ManualSpeed=10; //拉料机手动速度
        
        public PullerMotor m_Motor;


        public PaperPuller()
        {
            m_Motor = new PullerMotor();
        }

        //拉料初始化
        public void InitPuller()
        {
            if (!Global.Card0.m_CardInited)
            {
                Global.Print1.PrintingExcptInfo.Add ("运动控制卡还没有初始化");
                return;
            }
            m_Motor.Initialize();
        }


        //外面初始化设置各个运动轴的速度曲线,单位mm
        public void SetPullerVel(double dStartVel, double dMaxVel, double dTacc, double dTdec, double dStopVel, double dS_para,  double dManual)
        {
            m_Motor.SetProfile(dStartVel, dMaxVel, dTacc, dTdec, dStopVel, dS_para);
            m_ManualSpeed = dManual;
        }
       
        public void SetToManualSpeed()
        {
            m_Motor.SetSpeed (m_ManualSpeed);
        }
        public void SetToAutoSpeed()
        {
            m_Motor.SetSpeed(m_MaxSpeed);
        }

        // //外部设置拉料机速度 
        public bool SetVelocity(double v) //v 的单位是mm/s
        {
            if (!m_Motor.m_ProfileSetted )
            {
                return false;
            }
            if (m_Motor.IsStop())
            {
                m_Motor.SetSpeed(v); //停止状态使用普通参数设置
                return true;
            }
            m_Motor.ChangeToSpeed(v); //运行时变速到指定速度
            return true;
        }

        public bool IsStop()
        {
            return m_Motor.IsStop ();
        }

        public bool Move(double dMm) //以mm为单位移动相对位置，原点在右限位，向左为正
        {
            if (!CheckForMove())
            {
                return false;
            }
            m_Motor.Move(dMm);
            return true;
        }

        private bool CheckForMove()
        {
            if (!m_Motor .m_ProfileSetted )
            {
                Global.Print1.PrintingExcptInfo.Add(" 还没有设置运动轴参数");
                return false;
            }
            if (!IsStop())
            {
                Global.Print1.PrintingExcptInfo.Add ("拉料机停止状态下才能做相对移动");
                return false;
            }
            return true;
        }
          

        public bool StartMove() //开始连续运动
        {
            if (!CheckForMove()) return false;
            m_Motor.StartMove (true);
            return true;
        }

        public bool MoveNext() //拉一次料
        {
            double len = Global.Print1.m_UnitLen + Global.Platform1.m_XPosCmps+ Global.Platform1.m_XPrtCmps  ;
            if(!Move(len)) return false;
            return true;
        }
       

        public void PullStop()
        {
            m_Motor.Stop(0); //减速停止
        }

        public void EmgStop()
        {
            m_Motor.Stop(1); //紧急停止
        }

        
        public bool  SetMotorPulseMode(ushort mode)
        {
           if (mode < 0 || mode > 5)
            {
                Global.Print1.PrintingExcptInfo .Add ("设置脉冲模式失败，模式值应该介于0-5.");
                return false ;
            }
            m_Motor .SetPulseMode(mode) ;
            return true;
        }
        

        private  void GetSpeedRef(out double dStartVel, out double dMaxVel, out double dTacc, out double dTdec, out double dStopVel, out double dS_para,  out double dManualV)
        {
            dStartVel =m_Motor. m_StartSpeed;
            dMaxVel = m_Motor.m_MaxSpeed;
            dTacc = m_Motor.m_AccTime;
            dTdec = m_Motor.m_DecTime;
            dStopVel = m_Motor.m_StopSpeed;
            dS_para = m_Motor.m_STime;
            dManualV = m_ManualSpeed;
        }
        
       
        public bool ClearCount()
        {
            if (!IsStop())
            {
                Global.Print1.PrintingExcptInfo.Add("请在拉料机停止后再清零");
                return false;
            }
            m_Motor.ClearPosition();
            return true;
        }

        public bool CheckForPrint()
        {
            return CheckForMove(); 
        }

        public void PullToInt()// 拉到单位长度整数倍
        {
            double rest = m_Motor.GetCurrentPos() % Global.Print1.m_UnitLen  ;
            rest = Global.Print1.m_UnitLen - rest;
            Global.PaperPuller1.Move(rest);
        }
        
          
    }//endof Class PaperPuller
    
    [Serializable ]
    public class Printing
    {
        public string m_Password = "E10ADC3949BA59ABBE56E057F20F883E";
        public double m_TotalLength=0; //印刷总长度
        public int m_TotalCount=0; //印刷总次数或张数
        public double m_UnitLen=0; //单张长度
        public double m_UnitWidth=0; // 料的宽度
        public int m_TSendDelay=0; //送料光电延迟时间；
        public int m_TUVAdvance; //UV提前时间 ms
        public int m_TUVDelay; // UV延后时间  ms
        public int m_CurrentNum=1; //当前张数（从1开始计数）
        [NonSerialized] public bool m_CurrentOK=false ; //当前张数印完
        [NonSerialized ]public bool m_Ready =false ;
        public bool m_CountAsNumber=true ;//以张数计量，如果false则是以Length计量
        public int m_NumOfStop;   //印到此张数停机

        [NonSerialized] public string PrintingInfo;  //这两个成员收集信息，PrintingInfo 得到一条消息并显示在主界面。 PrintingExcptInfo
        [NonSerialized] public ArrayList PrintingExcptInfo = new ArrayList();// PrintingExcptInfo收集异常信息，在主界面的异常按钮双击可以查看
        
        public int m_PompDelay; //吸风延时
        public int m_StopPompDelay; //关吸风延时

        [NonSerialized]        public bool m_StaAuto =false ; //自动状态为true，手动为false
        [NonSerialized]        public bool m_SwtBlow = false;  //风机开
        [NonSerialized]        public bool m_SwtLightBox = false ;// 灯箱开
        [NonSerialized]        public bool m_SwtSpotLight = false; //射灯开
        [NonSerialized]        public bool m_SwtInPaperPomp= false; //进料吸风开
        [NonSerialized]        public bool m_SwtPomping = false;//吸风阀开

        public uint m_BeepTime=3000; //蜂鸣器时间为3秒

       
        public Printing()
        {
        }
        public int IsRuning()  // 0 :运行，1停止，-1 错误
        {
            if(!Global.Card0.m_CardInited ) return -1;
            if (!Global.Platform1.PltIsStop()) return 0;
            if (!Global.Spatula1.IsSptStop()) return 0 ;
            if (!Global.PaperPuller1.IsStop()) return 0;
            return 1;
        }
        public void InitPrint()
        {
            PrintingExcptInfo = new ArrayList();
        }

        public bool IsInExcpt()
        {
            if (PrintingExcptInfo.Count == 0) return false ;
            return true;
        }
        public void SetUVEnale(bool on)
        {
            ushort on_off = (ushort)(on ? 0 : 1);  // 0  表示低电平，通常设置低电平有效；
            Global.Card0.WriteOutBit(MotionCard.OutBit.O_UV, on_off);
        }
        public void SetLightBox(bool on)
        {
            m_SwtLightBox = on;
            ushort on_off = (ushort)(on ? 0 : 1);  // 0  表示低电平，通常设置低电平有效；
            Global.Card0.WriteOutBit(MotionCard.OutBit.O_LightBox, on_off);
        }
        public void SetSpotlight(bool on)
        {
            m_SwtSpotLight = on;
            ushort on_off = (ushort)(on ? 0 : 1);  // 0  表示低电平，通常设置低电平有效；
            Global.Card0.WriteOutBit(MotionCard.OutBit.O_Spotlight, on_off);
        }
        public void SetInPaperPomp(bool on)
        {
            m_SwtInPaperPomp = on;
            ushort on_off = (ushort)(on ? 0 : 1);  // 0  表示低电平，通常设置低电平有效；
            Global.Card0.WriteOutBit(MotionCard.OutBit.O_InPaper, on_off);
        }
        public void SetBlowing(bool on)
        {
            m_SwtBlow = on;
            ushort on_off = (ushort)(on ? 0 : 1);  // 0  表示低电平，通常设置低电平有效；
            Global.Card0.WriteOutBit(MotionCard.OutBit.O_Blow, on_off);
        }
        public void SetPomping(bool on)
        {
            m_SwtPomping = on;
            ushort on_off = (ushort)(on ? 0 : 1);  // 0  表示低电平，通常设置低电平有效；
            Global.Card0.WriteOutBit(MotionCard.OutBit.O_Pump , on_off);
        }

        public bool CheckInitialed() //检查初始设置
        {
            if(!m_SwtBlow)
            {
                PrintingExcptInfo.Add("风机还没有开！");
                return false;
            }
            if (m_UnitLen<=0 )
            {
                PrintingExcptInfo.Add("还没有设置单位料长！");
                return false;
            }
            if (m_TotalCount <= 0 || m_TotalLength <= 0)
            {
                PrintingExcptInfo.Add("还没有设置料长！");
                return false;
            }
            if (m_NumOfStop <= 0)
            {
                PrintingExcptInfo.Add("还没有设置批次信息！");
                return false;
            }
            return true;
        }
        public bool CheckForPrint() //为印刷进行检查
        {
            if (!CheckInitialed () )
            {
                return false;
            }
            if (!m_StaAuto)
            {
                PrintingExcptInfo.Add("还没有设置为自动状态！");
                return false;
            }
            if (!m_SwtInPaperPomp)
            {
                PrintingExcptInfo.Add("还没有打开进料吸风！");
                return false;
            }
            if(Global.Card0.ReadInBit(MotionCard.InBit.I_ArmDown)==1) //如果为高电平，表示无效
            {
                PrintingExcptInfo.Add("大臂还没有降下来！");
                return false;
            }
            if (Global.Card0.ReadInBit(MotionCard.InBit.I_SptDown) == 1) //如果为高电平，表示无效
            {
                PrintingExcptInfo.Add("小臂还没有降下来！");
                return false;
            }
            if (Global.Card0.ReadInBit(MotionCard.InBit.I_NetDown) == 1) //如果为高电平，表示无效
            {
                PrintingExcptInfo.Add("网框还没有降下来！");
                return false;
            }
            return true;
        }

        public void BeginBeep()
        {
            Global.Card0.WriteOutBit(MotionCard.OutBit.O_Beep, 0); //0代表低电平有效
        }
        public void StopBeep()
        {
            Global.Card0.WriteOutBit(MotionCard.OutBit.O_Beep, 1);//1代表高电平无效
        }
        public void StartPomping()// 开始吸风
        {
            Global.Card0.WriteOutBit(MotionCard.OutBit.O_Pump, 0); //0代表低电平有效
        }
         
    } // end of class Printing
  
    [Serializable ]
    public class Motor
    {
        public ushort m_CardID =0;
        public ushort m_ScrewIdx=0;//轴号
        protected double m_CoMmToPulse;
        public bool m_ProfileSetted = false;
        private bool m_Direction = true;
        public int m_PulsePerRev;

        public double m_MaxSpeed;//最高速度或运行速度，单位mm/s
        public double m_StartSpeed; //这几项是速度曲线设置
        public double m_AccTime;
        public double m_DecTime;
        public double m_STime;
        public double m_StopSpeed;

        private ushort m_PulseMode=0; // 脉冲模式，缺省为0， 相反为2
        public ushort m_HomeMode=2; //0，一次回零，1，一次回零加回找，2，二次回零，3，一次回零加EZ，4，EZ
        public ushort m_HomeDir = 0;    //回零方向，如果方向不对，需要调整。默认是0，负向回零。1是正向回零。
        public int m_HomeSpeedMode=0; //归零速度模式 ，1是高速，0是低速。
        private int m_WorkPos=0;  //单位 pulse，直接记录工作位置

        public  Motor()
        {
           
        }
        public void SetCoef(double coefMmToPulse)
        {
            m_CoMmToPulse = coefMmToPulse;
        }
        protected void Init()
        {
            LTDMC.dmc_set_pulse_outmode(m_CardID, m_ScrewIdx, m_PulseMode);//设置脉冲模式
            LTDMC.dmc_set_home_pin_logic(m_CardID, m_ScrewIdx, 0, 0);//驱动轴设置原点低电平有效
        }
        public void SetCarDID(ushort cardID)
        {
            m_CardID = cardID;
        }
        public void SetDirection(bool dir)
        {
            m_Direction = dir;
            m_CoMmToPulse = Math.Abs(m_CoMmToPulse);
            if (!dir) m_CoMmToPulse = -m_CoMmToPulse;
        }
        public bool GetDirection()
        {
            return m_Direction; 
        }
        public bool ClearPosition() //位置清零
        {
           if(LTDMC.dmc_set_position(m_CardID, m_ScrewIdx, 0)==0)return true ;
           return false ;
        }

        public void SetHomeRef(bool direction, bool highspeed, ushort mode)
        {
            m_HomeDir = 1; //1表示正向回零
            if (!direction) m_HomeDir = 0; //0表示负向归零
            m_HomeMode = mode;
            m_HomeSpeedMode = (highspeed ? 1:0);
            SetToHomeRef();
        }
        public void GetHomeRef(out bool dir, out bool highspeed, out ushort mode)//speed速度是mm/s
        {
            dir = (m_HomeDir ==1) ; // 1表示正向回零
            mode= m_HomeMode;
            highspeed= (m_HomeSpeedMode == 1 ? true: false) ;
        }
        public  void SetToHomeRef()
        {
            LTDMC.dmc_set_homemode(m_CardID, m_ScrewIdx, m_HomeDir, (double)m_HomeSpeedMode, m_HomeMode, 0);
        }
        public void SetPulseMode(ushort mode)
        {
            m_PulseMode = mode;
            LTDMC.dmc_set_pulse_outmode(m_CardID, m_ScrewIdx, mode);
        }
        public ushort GetPulseMode()
        {
            return m_PulseMode;
        }

        public bool SetToProfile()
        {
            double minVel= m_StartSpeed * m_CoMmToPulse;
            double maxVel= m_MaxSpeed* m_CoMmToPulse;
            double stopVel= m_StopSpeed * m_CoMmToPulse;
            try
            {
                LTDMC.dmc_set_profile(m_CardID, m_ScrewIdx, minVel, maxVel, m_AccTime, m_DecTime, stopVel);
                LTDMC.dmc_set_s_profile(m_CardID, m_ScrewIdx, 0,m_STime);//设置S段速度参数
                LTDMC.dmc_set_dec_stop_time(m_CardID, m_ScrewIdx, m_DecTime); //设置减速停止时间
                m_ProfileSetted = true;
                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }
        public bool SetProfile(double startVel, double maxVel, double accTime, double decTime, double stopVel, double dS_para)
        {
            m_MaxSpeed =maxVel ;
            m_StartSpeed = startVel ;
            m_AccTime = accTime;
            m_DecTime = decTime ;
            m_StopSpeed = stopVel ;
            m_STime = dS_para;
            if(!SetToProfile()) return false ;
            return true;
        }

        public double GetCurrentPos()
        {
            int pos = LTDMC.dmc_get_position(m_CardID, m_ScrewIdx);
            return pos / m_CoMmToPulse;        
        }

        public bool SetSpeed(double v)
        {
            if (!m_ProfileSetted) return false;
            try
            {
                m_MaxSpeed = v;
                double Min_Vel = 0.0, Max_Vel = 0.0, Tacc = 0.0, Tdec = 0.0, stop_vel = 0.0;
                double speedPulse = v * m_CoMmToPulse;

                LTDMC.dmc_get_profile(m_CardID, m_ScrewIdx, ref  Min_Vel, ref Max_Vel, ref Tacc, ref Tdec, ref stop_vel);
                LTDMC.dmc_set_profile(m_CardID, m_ScrewIdx, Min_Vel, speedPulse, Tacc, Tdec, stop_vel);
                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }
         public bool ChangeToSpeed(double v) //在线变速
        {
            if (!m_ProfileSetted) return false;
            try
            {
                LTDMC.dmc_change_speed(m_CardID, m_ScrewIdx, v * m_CoMmToPulse, m_AccTime);
                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }
        
        public bool StartMove(bool dir)
        {
            bool d = m_Direction;
            if (dir) d = !d;
            ushort  screw_dir = 1;
            if (d) screw_dir = 0;
            
           if( LTDMC.dmc_vmove(m_CardID, m_ScrewIdx, screw_dir)==0)//连续运动,0负方向，1是正方向
            return true;
           return false;
        }
        public int MoveToHome() //返回零为成功，-1为没有设置速度参数，其他返回运动卡错误号
        {
            if (!m_ProfileSetted) return -1;
            short err = LTDMC.dmc_home_move(m_CardID, m_ScrewIdx);//启动回零
            while (!IsStop())
            {
                Application.DoEvents();
            }
            if (err == 0) LTDMC.dmc_set_position (m_CardID, m_ScrewIdx,0);//计数清零
            return (int)err;
        }

        public bool IsStop()
        {
            if (LTDMC.dmc_check_done(m_CardID, m_ScrewIdx) == 0)
                return false ;
            else
                return true ;
        }

        public void Stop(ushort stop_mode)//制动方式，0：减速停止，1：紧急停止
        {
            LTDMC.dmc_stop(m_CardID, m_ScrewIdx, stop_mode);
        }
        public int Move(double des) //单位mm
        {
            if (!m_ProfileSetted) return -1;
            int dPulse = (int)(des * m_CoMmToPulse);
            short err =  LTDMC.dmc_pmove(m_CardID ,m_ScrewIdx , dPulse ,0);
            return (int)err;
        }

        public int MoveTo(double des) //单位mm
        {
            if (!m_ProfileSetted) return -1;
            int dPulse = Global.Int45(des * m_CoMmToPulse);
            short err = LTDMC.dmc_pmove(m_CardID, m_ScrewIdx, dPulse, 1);
            return (int)err;
        }
        public double GetWorkPosition()//相对于归零后的移动位置，正负符号表示跟X轴方向是否相同。 返回值是mm
        {
            double pos = m_WorkPos * m_CoMmToPulse;
            if (!GetDirection()) pos = -pos;
            return pos;
        }
        public bool SetCurrentToWorkPos()
        {
            if (LTDMC.dmc_check_done(m_CardID, m_ScrewIdx) == 0) return false;
            m_WorkPos = LTDMC.dmc_get_position(m_CardID, m_ScrewIdx);
            return true;
        }
    }

    [Serializable ]
    public class ScrewMotor : Motor
    {
        public double m_ThreadPitch = 1;
       
        public ScrewMotor()
        {
           
        }
        
        public ScrewMotor(ushort CardID, ushort Axis, int pulsePerRev, double threadPithch, bool dir)
        {
            m_CardID = CardID;
            m_ScrewIdx = Axis;
            m_PulsePerRev = pulsePerRev;
            m_ThreadPitch = threadPithch;
            ResetCoMmToPulse();
            SetDirection(dir);
        }
        
        public void ResetCoMmToPulse()
        {
            m_CoMmToPulse = m_PulsePerRev / m_ThreadPitch ;
            if (!GetDirection()) m_CoMmToPulse = -m_CoMmToPulse;
        }
       
    }

    [Serializable ]
    public class CamMotor : ScrewMotor 
    {
        [NonSerialized] public bool m_CamBind = false; //绑定的相机
        public PointF m_ZeroPoint; //相机归零时的广义坐标
        [NonSerialized ]public bool m_OrgCalibrated = false; // Original point has been calibrated
        private Mat2DNormal m_Mat=new Mat2DNormal (); //此矩阵用于把图像位置转化为广义空间位置

        public CamMotor(ushort CardID, ushort Axis,bool Dir, ushort HomeDir, PointF pZero)
        {
            //设置基本参数
            m_CardID = CardID;
            m_ScrewIdx = Axis;
            m_PulsePerRev = 1000;
            m_ThreadPitch = 2;
            m_CoMmToPulse = m_PulsePerRev / m_ThreadPitch;
            SetDirection(Dir);
            m_ZeroPoint = pZero;
            
            //设置速度参数
            m_MaxSpeed = 10; // mm
            m_StartSpeed = 1;//mm
            m_StopSpeed = 1;//mm
            m_AccTime = 0.1;//s
            m_DecTime = 0.1; //s
            m_STime = 0.02;//s
            
            //设置回零参数
            m_HomeMode = 2;//二次回零
            m_HomeSpeedMode = 1; //高速回零
            m_HomeDir = HomeDir;// 0 表示负向回零
         }

        public void Initialize()
        {
            base.Init();
            base.ResetCoMmToPulse();
            SetToProfile();
            SetToHomeRef(); 
        }
            
        public bool BindCamera(CameraDMK cam)
        {
            if (cam != null && m_OrgCalibrated && cam.m_LenCalibrated  && cam.m_AngleCalibrated)
            {
                m_Mat.Translate(-cam.m_ht_ImgWidth * cam.m_MmPerPixel * 0.5, -cam.m_ht_ImgHeight * cam.m_MmPerPixel * 0.5); //计算相对于相机图像中心位置坐标
                m_Mat.Rotate(-cam.m_AngleCalib); //根据校对后的角度修正坐标相对位置
                m_Mat.Translate(m_ZeroPoint.X + GetWorkPosition (), m_ZeroPoint.Y); //转化为平台坐标系坐标 
                m_CamBind = true;
                return true;
            }
            return false;
        }

        public bool  PointToPltSys(PointF pCam, ref PointF pSys)
        {
            if (!m_CamBind) return false;
            pSys = m_Mat * pCam;
            return true;
        }
        public bool PointToPltSys(Point pCam, ref PointF pSys)
        {
            if (!m_CamBind) return false;
            PointF p2=new PointF ();
            p2.X = pCam.X;
            p2.Y = pCam.Y;
            pSys = m_Mat * p2;
            return true ;
        }
      
    }

    [Serializable ]
    public class BeltMotor : Motor
    {
        public double m_ReduceRatio ;
        public double m_Diameter;
        public BeltMotor()
        {
        }
        public BeltMotor(double r, double d)
        {
            m_Diameter = d;
            m_ReduceRatio = r;
            ResetCoMmToPulse();
        }
              
         public void ResetCoMmToPulse()
        {
            m_CoMmToPulse = m_PulsePerRev * m_ReduceRatio / 3.1415926 / m_Diameter;
            if (!GetDirection()) m_CoMmToPulse = -m_CoMmToPulse;
        }
    }

    [Serializable ]
    public class SpatulaMotor : BeltMotor
    {
        public SpatulaMotor()
        {
            //设置基本参数
            m_CardID = 0;
            m_ScrewIdx = 3;
            m_PulsePerRev = 2000;
            m_ReduceRatio = 10;
            m_Diameter = 80.86;

            //设置速度参数
            m_MaxSpeed = 20;
            m_StartSpeed = 2;
            m_StopSpeed = 2;
            m_AccTime = 0.1;
            m_DecTime = 0.1;
            m_STime = 0.05;

            //设置回零参数
            m_HomeSpeedMode = 1; //高速回零
            m_HomeDir = 0; //负向回零
            m_HomeMode = 2; //二次回零
        }
        public void Initialize()
        {
            base.Init();
            ResetCoMmToPulse();
            SetToHomeRef();
            SetToProfile();
        }
    }

    [Serializable ]
    public class PullerMotor : BeltMotor
    {
        public PullerMotor()
        {
            //设置基本参数
            m_CardID = 0;
            m_ScrewIdx = 4;
            m_PulsePerRev = 2000;
            m_ReduceRatio = 10;
            m_Diameter = 80.86;

            //设置速度参数
            m_MaxSpeed = 20;
            m_StartSpeed = 2;
            m_StopSpeed = 2;
            m_AccTime = 0.1;
            m_DecTime = 0.1;
            m_STime = 0.05;
        }
        public void Initialize()
        {
            base.Init();
            ResetCoMmToPulse();
            SetToProfile();
        }
    }

}//endof namespace csMotion
