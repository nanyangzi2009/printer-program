namespace PrintInterface
{
    partial class FormMain
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.btnExit = new System.Windows.Forms.Button();
            this.btnManualPosition = new System.Windows.Forms.Button();
            this.btnSystem = new System.Windows.Forms.Button();
            this.btnPrintSet = new System.Windows.Forms.Button();
            this.btnIO = new System.Windows.Forms.Button();
            this.btnStopPrint = new System.Windows.Forms.Button();
            this.btnSysReset = new System.Windows.Forms.Button();
            this.btnPltSet = new System.Windows.Forms.Button();
            this.btnCamCalib = new System.Windows.Forms.Button();
            this.btnCamAjust = new System.Windows.Forms.Button();
            this.btnCamSet = new System.Windows.Forms.Button();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.richTextBox1 = new System.Windows.Forms.RichTextBox();
            this.groupBox3 = new System.Windows.Forms.GroupBox();
            this.label6 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.hWinCtlLeft = new HalconDotNet.HWindowControl();
            this.groupBox4 = new System.Windows.Forms.GroupBox();
            this.label8 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.hWinCtlRight = new HalconDotNet.HWindowControl();
            this.lblRun = new System.Windows.Forms.Label();
            this.lblExcept = new System.Windows.Forms.Label();
            this.lblMsg = new System.Windows.Forms.Label();
            this.timerInfo = new System.Windows.Forms.Timer(this.components);
            this.lblAuto = new System.Windows.Forms.Label();
            this.lblPullSpeed = new System.Windows.Forms.Label();
            this.label19 = new System.Windows.Forms.Label();
            this.label33 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.lblTotalCount = new System.Windows.Forms.Label();
            this.btnClearTotal = new System.Windows.Forms.Button();
            this.lblUnitLen = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.btnClearCurNum = new System.Windows.Forms.Button();
            this.lblCurNum = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.lblSwtBlow = new System.Windows.Forms.Label();
            this.lblSwtLight = new System.Windows.Forms.Label();
            this.lblSwtSpot = new System.Windows.Forms.Label();
            this.lblSwtPaperIn = new System.Windows.Forms.Label();
            this.lblManualSpeed = new System.Windows.Forms.Label();
            this.label13 = new System.Windows.Forms.Label();
            this.label14 = new System.Windows.Forms.Label();
            this.lblStopNum = new System.Windows.Forms.Label();
            this.label16 = new System.Windows.Forms.Label();
            this.timerBtn = new System.Windows.Forms.Timer(this.components);
            this.timerStart = new System.Windows.Forms.Timer(this.components);
            this.timerMove = new System.Windows.Forms.Timer(this.components);
            this.timerPull = new System.Windows.Forms.Timer(this.components);
            this.timerBeep = new System.Windows.Forms.Timer(this.components);
            this.timerSendLight = new System.Windows.Forms.Timer(this.components);
            this.btnCamSample = new System.Windows.Forms.Button();
            this.groupBox1.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.groupBox3.SuspendLayout();
            this.groupBox4.SuspendLayout();
            this.SuspendLayout();
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.btnExit);
            this.groupBox1.Controls.Add(this.btnManualPosition);
            this.groupBox1.Controls.Add(this.btnSystem);
            this.groupBox1.Controls.Add(this.btnPrintSet);
            this.groupBox1.Controls.Add(this.btnIO);
            this.groupBox1.Controls.Add(this.btnStopPrint);
            this.groupBox1.Controls.Add(this.btnSysReset);
            this.groupBox1.Controls.Add(this.btnPltSet);
            this.groupBox1.Controls.Add(this.btnCamSample);
            this.groupBox1.Controls.Add(this.btnCamCalib);
            this.groupBox1.Controls.Add(this.btnCamAjust);
            this.groupBox1.Controls.Add(this.btnCamSet);
            this.groupBox1.Font = new System.Drawing.Font("微软雅黑", 15F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.groupBox1.Location = new System.Drawing.Point(12, 12);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(480, 262);
            this.groupBox1.TabIndex = 0;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "主页面功能";
            // 
            // btnExit
            // 
            this.btnExit.Font = new System.Drawing.Font("楷体", 16F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.btnExit.Location = new System.Drawing.Point(362, 196);
            this.btnExit.Name = "btnExit";
            this.btnExit.Size = new System.Drawing.Size(110, 56);
            this.btnExit.TabIndex = 11;
            this.btnExit.Text = "退出";
            this.btnExit.UseVisualStyleBackColor = true;
            this.btnExit.Click += new System.EventHandler(this.btnExit_Click);
            // 
            // btnManualPosition
            // 
            this.btnManualPosition.Font = new System.Drawing.Font("楷体", 16F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.btnManualPosition.Location = new System.Drawing.Point(130, 114);
            this.btnManualPosition.Name = "btnManualPosition";
            this.btnManualPosition.Size = new System.Drawing.Size(110, 56);
            this.btnManualPosition.TabIndex = 10;
            this.btnManualPosition.Text = "手动对位";
            this.btnManualPosition.UseVisualStyleBackColor = true;
            this.btnManualPosition.Click += new System.EventHandler(this.btnManualPosition_Click);
            // 
            // btnSystem
            // 
            this.btnSystem.Font = new System.Drawing.Font("楷体", 16F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.btnSystem.Location = new System.Drawing.Point(246, 196);
            this.btnSystem.Name = "btnSystem";
            this.btnSystem.Size = new System.Drawing.Size(110, 56);
            this.btnSystem.TabIndex = 9;
            this.btnSystem.Text = "系统信息";
            this.btnSystem.UseVisualStyleBackColor = true;
            this.btnSystem.Click += new System.EventHandler(this.btnPosSet_Click);
            // 
            // btnPrintSet
            // 
            this.btnPrintSet.Font = new System.Drawing.Font("楷体", 16F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.btnPrintSet.Location = new System.Drawing.Point(246, 114);
            this.btnPrintSet.Name = "btnPrintSet";
            this.btnPrintSet.Size = new System.Drawing.Size(110, 56);
            this.btnPrintSet.TabIndex = 8;
            this.btnPrintSet.Text = "印刷设置";
            this.btnPrintSet.UseVisualStyleBackColor = true;
            this.btnPrintSet.Click += new System.EventHandler(this.btnPrintSet_Click);
            // 
            // btnIO
            // 
            this.btnIO.Font = new System.Drawing.Font("楷体", 16F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.btnIO.Location = new System.Drawing.Point(362, 114);
            this.btnIO.Name = "btnIO";
            this.btnIO.Size = new System.Drawing.Size(110, 56);
            this.btnIO.TabIndex = 7;
            this.btnIO.Text = "IO状态";
            this.btnIO.UseVisualStyleBackColor = true;
            this.btnIO.Click += new System.EventHandler(this.btnIO_Click);
            // 
            // btnStopPrint
            // 
            this.btnStopPrint.Font = new System.Drawing.Font("楷体", 16F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.btnStopPrint.Location = new System.Drawing.Point(16, 196);
            this.btnStopPrint.Name = "btnStopPrint";
            this.btnStopPrint.Size = new System.Drawing.Size(110, 56);
            this.btnStopPrint.TabIndex = 6;
            this.btnStopPrint.Text = "停止运行";
            this.btnStopPrint.UseVisualStyleBackColor = true;
            this.btnStopPrint.Click += new System.EventHandler(this.btnStopPrint_Click);
            // 
            // btnSysReset
            // 
            this.btnSysReset.Font = new System.Drawing.Font("楷体", 16F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.btnSysReset.Location = new System.Drawing.Point(130, 196);
            this.btnSysReset.Name = "btnSysReset";
            this.btnSysReset.Size = new System.Drawing.Size(110, 56);
            this.btnSysReset.TabIndex = 5;
            this.btnSysReset.Text = "系统复位";
            this.btnSysReset.UseVisualStyleBackColor = true;
            this.btnSysReset.Click += new System.EventHandler(this.btnSysReset_Click);
            // 
            // btnPltSet
            // 
            this.btnPltSet.Font = new System.Drawing.Font("楷体", 16F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.btnPltSet.Location = new System.Drawing.Point(15, 114);
            this.btnPltSet.Name = "btnPltSet";
            this.btnPltSet.Size = new System.Drawing.Size(110, 56);
            this.btnPltSet.TabIndex = 4;
            this.btnPltSet.Text = "平台设置";
            this.btnPltSet.UseVisualStyleBackColor = true;
            this.btnPltSet.Click += new System.EventHandler(this.btnPltSet_Click);
            // 
            // btnCamCalib
            // 
            this.btnCamCalib.Font = new System.Drawing.Font("楷体", 16F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.btnCamCalib.Location = new System.Drawing.Point(246, 37);
            this.btnCamCalib.Name = "btnCamCalib";
            this.btnCamCalib.Size = new System.Drawing.Size(110, 56);
            this.btnCamCalib.TabIndex = 2;
            this.btnCamCalib.Text = "相机标定";
            this.btnCamCalib.UseVisualStyleBackColor = true;
            this.btnCamCalib.Click += new System.EventHandler(this.btnCamCalib_Click);
            // 
            // btnCamAjust
            // 
            this.btnCamAjust.Font = new System.Drawing.Font("楷体", 16F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.btnCamAjust.Location = new System.Drawing.Point(130, 36);
            this.btnCamAjust.Name = "btnCamAjust";
            this.btnCamAjust.Size = new System.Drawing.Size(110, 56);
            this.btnCamAjust.TabIndex = 1;
            this.btnCamAjust.Text = "相机调整";
            this.btnCamAjust.UseVisualStyleBackColor = true;
            this.btnCamAjust.Click += new System.EventHandler(this.btnCamAjust_Click);
            // 
            // btnCamSet
            // 
            this.btnCamSet.Font = new System.Drawing.Font("楷体", 16F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.btnCamSet.Location = new System.Drawing.Point(16, 37);
            this.btnCamSet.Name = "btnCamSet";
            this.btnCamSet.Size = new System.Drawing.Size(110, 56);
            this.btnCamSet.TabIndex = 0;
            this.btnCamSet.Text = "相机设置";
            this.btnCamSet.UseVisualStyleBackColor = true;
            this.btnCamSet.Click += new System.EventHandler(this.btnCamSet_Click);
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.richTextBox1);
            this.groupBox2.Font = new System.Drawing.Font("微软雅黑", 15F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.groupBox2.Location = new System.Drawing.Point(516, 131);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(480, 143);
            this.groupBox2.TabIndex = 1;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "对位信息";
            // 
            // richTextBox1
            // 
            this.richTextBox1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))));
            this.richTextBox1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.richTextBox1.Font = new System.Drawing.Font("宋体", 15F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.richTextBox1.Location = new System.Drawing.Point(6, 33);
            this.richTextBox1.Name = "richTextBox1";
            this.richTextBox1.Size = new System.Drawing.Size(463, 100);
            this.richTextBox1.TabIndex = 0;
            this.richTextBox1.Text = "成功！";
            // 
            // groupBox3
            // 
            this.groupBox3.Controls.Add(this.label6);
            this.groupBox3.Controls.Add(this.label2);
            this.groupBox3.Controls.Add(this.hWinCtlLeft);
            this.groupBox3.Font = new System.Drawing.Font("微软雅黑", 15F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.groupBox3.Location = new System.Drawing.Point(12, 280);
            this.groupBox3.Name = "groupBox3";
            this.groupBox3.Size = new System.Drawing.Size(480, 407);
            this.groupBox3.TabIndex = 1;
            this.groupBox3.TabStop = false;
            this.groupBox3.Text = "左相机图像";
            // 
            // label6
            // 
            this.label6.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(128)))), ((int)(((byte)(128)))), ((int)(((byte)(255)))));
            this.label6.Location = new System.Drawing.Point(240, 32);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(1, 360);
            this.label6.TabIndex = 2;
            // 
            // label2
            // 
            this.label2.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(128)))), ((int)(((byte)(128)))), ((int)(((byte)(255)))));
            this.label2.Location = new System.Drawing.Point(15, 204);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(450, 1);
            this.label2.TabIndex = 1;
            // 
            // hWinCtlLeft
            // 
            this.hWinCtlLeft.BackColor = System.Drawing.Color.Black;
            this.hWinCtlLeft.BorderColor = System.Drawing.Color.Black;
            this.hWinCtlLeft.ImagePart = new System.Drawing.Rectangle(0, 0, 640, 480);
            this.hWinCtlLeft.Location = new System.Drawing.Point(15, 32);
            this.hWinCtlLeft.Name = "hWinCtlLeft";
            this.hWinCtlLeft.Size = new System.Drawing.Size(450, 360);
            this.hWinCtlLeft.TabIndex = 0;
            this.hWinCtlLeft.WindowSize = new System.Drawing.Size(450, 360);
            // 
            // groupBox4
            // 
            this.groupBox4.Controls.Add(this.label8);
            this.groupBox4.Controls.Add(this.label3);
            this.groupBox4.Controls.Add(this.hWinCtlRight);
            this.groupBox4.Font = new System.Drawing.Font("微软雅黑", 15F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.groupBox4.Location = new System.Drawing.Point(516, 280);
            this.groupBox4.Name = "groupBox4";
            this.groupBox4.Size = new System.Drawing.Size(480, 407);
            this.groupBox4.TabIndex = 1;
            this.groupBox4.TabStop = false;
            this.groupBox4.Text = "右相机图像";
            // 
            // label8
            // 
            this.label8.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(128)))), ((int)(((byte)(128)))), ((int)(((byte)(255)))));
            this.label8.Location = new System.Drawing.Point(240, 32);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(1, 360);
            this.label8.TabIndex = 3;
            // 
            // label3
            // 
            this.label3.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(128)))), ((int)(((byte)(128)))), ((int)(((byte)(255)))));
            this.label3.Location = new System.Drawing.Point(15, 204);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(450, 1);
            this.label3.TabIndex = 2;
            // 
            // hWinCtlRight
            // 
            this.hWinCtlRight.BackColor = System.Drawing.Color.Black;
            this.hWinCtlRight.BorderColor = System.Drawing.Color.Black;
            this.hWinCtlRight.ImagePart = new System.Drawing.Rectangle(0, 0, 640, 480);
            this.hWinCtlRight.Location = new System.Drawing.Point(15, 32);
            this.hWinCtlRight.Name = "hWinCtlRight";
            this.hWinCtlRight.Size = new System.Drawing.Size(450, 360);
            this.hWinCtlRight.TabIndex = 1;
            this.hWinCtlRight.WindowSize = new System.Drawing.Size(450, 360);
            // 
            // lblRun
            // 
            this.lblRun.BackColor = System.Drawing.Color.Lime;
            this.lblRun.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.lblRun.Font = new System.Drawing.Font("微软雅黑", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.lblRun.Location = new System.Drawing.Point(516, 702);
            this.lblRun.Name = "lblRun";
            this.lblRun.Size = new System.Drawing.Size(84, 40);
            this.lblRun.TabIndex = 2;
            this.lblRun.Text = "停止中";
            this.lblRun.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // lblExcept
            // 
            this.lblExcept.BackColor = System.Drawing.Color.Lime;
            this.lblExcept.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.lblExcept.Font = new System.Drawing.Font("微软雅黑", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.lblExcept.ForeColor = System.Drawing.Color.Black;
            this.lblExcept.Location = new System.Drawing.Point(604, 702);
            this.lblExcept.Name = "lblExcept";
            this.lblExcept.Size = new System.Drawing.Size(90, 40);
            this.lblExcept.TabIndex = 4;
            this.lblExcept.Text = "无异常";
            this.lblExcept.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.lblExcept.DoubleClick += new System.EventHandler(this.lblExcept_DoubleClick);
            // 
            // lblMsg
            // 
            this.lblMsg.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.lblMsg.Font = new System.Drawing.Font("楷体", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.lblMsg.Location = new System.Drawing.Point(700, 702);
            this.lblMsg.Name = "lblMsg";
            this.lblMsg.Size = new System.Drawing.Size(296, 40);
            this.lblMsg.TabIndex = 5;
            this.lblMsg.Text = "无异常信息";
            this.lblMsg.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // timerInfo
            // 
            this.timerInfo.Tick += new System.EventHandler(this.timerInfo_Tick);
            // 
            // lblAuto
            // 
            this.lblAuto.BackColor = System.Drawing.Color.Lime;
            this.lblAuto.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.lblAuto.Font = new System.Drawing.Font("楷体", 15F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.lblAuto.ForeColor = System.Drawing.Color.Black;
            this.lblAuto.Location = new System.Drawing.Point(12, 698);
            this.lblAuto.Name = "lblAuto";
            this.lblAuto.Size = new System.Drawing.Size(101, 46);
            this.lblAuto.TabIndex = 6;
            this.lblAuto.Text = "手动";
            this.lblAuto.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.lblAuto.DoubleClick += new System.EventHandler(this.lblAuto_DoubleClick);
            // 
            // lblPullSpeed
            // 
            this.lblPullSpeed.Font = new System.Drawing.Font("微软雅黑", 15F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.lblPullSpeed.Location = new System.Drawing.Point(596, 28);
            this.lblPullSpeed.Name = "lblPullSpeed";
            this.lblPullSpeed.Size = new System.Drawing.Size(90, 28);
            this.lblPullSpeed.TabIndex = 52;
            this.lblPullSpeed.Text = "200.999";
            // 
            // label19
            // 
            this.label19.AutoSize = true;
            this.label19.Font = new System.Drawing.Font("微软雅黑", 15F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label19.Location = new System.Drawing.Point(683, 27);
            this.label19.Name = "label19";
            this.label19.Size = new System.Drawing.Size(68, 27);
            this.label19.TabIndex = 51;
            this.label19.Text = "mm/s";
            // 
            // label33
            // 
            this.label33.AutoSize = true;
            this.label33.Font = new System.Drawing.Font("微软雅黑", 15F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label33.Location = new System.Drawing.Point(511, 28);
            this.label33.Name = "label33";
            this.label33.Size = new System.Drawing.Size(92, 27);
            this.label33.TabIndex = 50;
            this.label33.Text = "拉料速度";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("微软雅黑", 15F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label1.Location = new System.Drawing.Point(758, 27);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(92, 27);
            this.label1.TabIndex = 53;
            this.label1.Text = "生产总数";
            // 
            // lblTotalCount
            // 
            this.lblTotalCount.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.lblTotalCount.Font = new System.Drawing.Font("微软雅黑", 15F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.lblTotalCount.Location = new System.Drawing.Point(849, 26);
            this.lblTotalCount.Name = "lblTotalCount";
            this.lblTotalCount.Size = new System.Drawing.Size(79, 28);
            this.lblTotalCount.TabIndex = 54;
            this.lblTotalCount.Text = "10000";
            // 
            // btnClearTotal
            // 
            this.btnClearTotal.Font = new System.Drawing.Font("楷体", 16F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.btnClearTotal.Location = new System.Drawing.Point(933, 19);
            this.btnClearTotal.Name = "btnClearTotal";
            this.btnClearTotal.Size = new System.Drawing.Size(67, 36);
            this.btnClearTotal.TabIndex = 55;
            this.btnClearTotal.Text = "清零";
            this.btnClearTotal.UseVisualStyleBackColor = true;
            this.btnClearTotal.Click += new System.EventHandler(this.btnClearTotal_Click);
            // 
            // lblUnitLen
            // 
            this.lblUnitLen.Font = new System.Drawing.Font("微软雅黑", 15F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.lblUnitLen.Location = new System.Drawing.Point(596, 64);
            this.lblUnitLen.Name = "lblUnitLen";
            this.lblUnitLen.Size = new System.Drawing.Size(90, 28);
            this.lblUnitLen.TabIndex = 58;
            this.lblUnitLen.Text = "200.999";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("微软雅黑", 15F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label4.Location = new System.Drawing.Point(683, 63);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(50, 27);
            this.label4.TabIndex = 57;
            this.label4.Text = "mm";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("微软雅黑", 15F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label5.Location = new System.Drawing.Point(511, 64);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(92, 27);
            this.label5.TabIndex = 56;
            this.label5.Text = "单位长度";
            // 
            // btnClearCurNum
            // 
            this.btnClearCurNum.Font = new System.Drawing.Font("楷体", 16F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.btnClearCurNum.Location = new System.Drawing.Point(933, 57);
            this.btnClearCurNum.Name = "btnClearCurNum";
            this.btnClearCurNum.Size = new System.Drawing.Size(67, 36);
            this.btnClearCurNum.TabIndex = 61;
            this.btnClearCurNum.Text = "清零";
            this.btnClearCurNum.UseVisualStyleBackColor = true;
            this.btnClearCurNum.Click += new System.EventHandler(this.btnClearCurNum_Click);
            // 
            // lblCurNum
            // 
            this.lblCurNum.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.lblCurNum.Font = new System.Drawing.Font("微软雅黑", 15F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.lblCurNum.Location = new System.Drawing.Point(849, 64);
            this.lblCurNum.Name = "lblCurNum";
            this.lblCurNum.Size = new System.Drawing.Size(79, 28);
            this.lblCurNum.TabIndex = 60;
            this.lblCurNum.Text = "1";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Font = new System.Drawing.Font("微软雅黑", 15F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label7.Location = new System.Drawing.Point(758, 65);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(92, 27);
            this.label7.TabIndex = 59;
            this.label7.Text = "本批计数";
            // 
            // lblSwtBlow
            // 
            this.lblSwtBlow.BackColor = System.Drawing.Color.Lime;
            this.lblSwtBlow.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.lblSwtBlow.Font = new System.Drawing.Font("楷体", 15F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.lblSwtBlow.ForeColor = System.Drawing.Color.Black;
            this.lblSwtBlow.Location = new System.Drawing.Point(119, 699);
            this.lblSwtBlow.Name = "lblSwtBlow";
            this.lblSwtBlow.Size = new System.Drawing.Size(80, 46);
            this.lblSwtBlow.TabIndex = 62;
            this.lblSwtBlow.Text = "风机开";
            this.lblSwtBlow.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.lblSwtBlow.DoubleClick += new System.EventHandler(this.lblSwtBlow_DoubleClick);
            // 
            // lblSwtLight
            // 
            this.lblSwtLight.BackColor = System.Drawing.Color.Lime;
            this.lblSwtLight.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.lblSwtLight.Font = new System.Drawing.Font("楷体", 15F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.lblSwtLight.ForeColor = System.Drawing.Color.Black;
            this.lblSwtLight.Location = new System.Drawing.Point(204, 699);
            this.lblSwtLight.Name = "lblSwtLight";
            this.lblSwtLight.Size = new System.Drawing.Size(80, 46);
            this.lblSwtLight.TabIndex = 63;
            this.lblSwtLight.Text = "灯箱开";
            this.lblSwtLight.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.lblSwtLight.DoubleClick += new System.EventHandler(this.lblSwtLight_DoubleClick);
            // 
            // lblSwtSpot
            // 
            this.lblSwtSpot.BackColor = System.Drawing.Color.Lime;
            this.lblSwtSpot.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.lblSwtSpot.Font = new System.Drawing.Font("楷体", 15F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.lblSwtSpot.ForeColor = System.Drawing.Color.Black;
            this.lblSwtSpot.Location = new System.Drawing.Point(289, 699);
            this.lblSwtSpot.Name = "lblSwtSpot";
            this.lblSwtSpot.Size = new System.Drawing.Size(80, 46);
            this.lblSwtSpot.TabIndex = 65;
            this.lblSwtSpot.Text = "射灯开";
            this.lblSwtSpot.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.lblSwtSpot.DoubleClick += new System.EventHandler(this.lblSwtSpot_DoubleClick);
            // 
            // lblSwtPaperIn
            // 
            this.lblSwtPaperIn.BackColor = System.Drawing.Color.Lime;
            this.lblSwtPaperIn.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.lblSwtPaperIn.Font = new System.Drawing.Font("楷体", 15F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.lblSwtPaperIn.ForeColor = System.Drawing.Color.Black;
            this.lblSwtPaperIn.Location = new System.Drawing.Point(374, 699);
            this.lblSwtPaperIn.Name = "lblSwtPaperIn";
            this.lblSwtPaperIn.Size = new System.Drawing.Size(118, 46);
            this.lblSwtPaperIn.TabIndex = 66;
            this.lblSwtPaperIn.Text = "进料吸风开";
            this.lblSwtPaperIn.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.lblSwtPaperIn.DoubleClick += new System.EventHandler(this.lblSwtPaperIn_DoubleClick);
            // 
            // lblManualSpeed
            // 
            this.lblManualSpeed.Font = new System.Drawing.Font("微软雅黑", 15F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.lblManualSpeed.Location = new System.Drawing.Point(597, 100);
            this.lblManualSpeed.Name = "lblManualSpeed";
            this.lblManualSpeed.Size = new System.Drawing.Size(90, 28);
            this.lblManualSpeed.TabIndex = 69;
            this.lblManualSpeed.Text = "200.999";
            // 
            // label13
            // 
            this.label13.AutoSize = true;
            this.label13.Font = new System.Drawing.Font("微软雅黑", 15F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label13.Location = new System.Drawing.Point(684, 99);
            this.label13.Name = "label13";
            this.label13.Size = new System.Drawing.Size(68, 27);
            this.label13.TabIndex = 68;
            this.label13.Text = "mm/s";
            // 
            // label14
            // 
            this.label14.AutoSize = true;
            this.label14.Font = new System.Drawing.Font("微软雅黑", 15F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label14.Location = new System.Drawing.Point(512, 100);
            this.label14.Name = "label14";
            this.label14.Size = new System.Drawing.Size(92, 27);
            this.label14.TabIndex = 67;
            this.label14.Text = "手动拉速";
            // 
            // lblStopNum
            // 
            this.lblStopNum.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.lblStopNum.Font = new System.Drawing.Font("微软雅黑", 15F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.lblStopNum.Location = new System.Drawing.Point(849, 100);
            this.lblStopNum.Name = "lblStopNum";
            this.lblStopNum.Size = new System.Drawing.Size(79, 28);
            this.lblStopNum.TabIndex = 71;
            this.lblStopNum.Text = "1";
            // 
            // label16
            // 
            this.label16.AutoSize = true;
            this.label16.Font = new System.Drawing.Font("微软雅黑", 15F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label16.Location = new System.Drawing.Point(758, 101);
            this.label16.Name = "label16";
            this.label16.Size = new System.Drawing.Size(92, 27);
            this.label16.TabIndex = 70;
            this.label16.Text = "批量停机";
            // 
            // timerBtn
            // 
            this.timerBtn.Tick += new System.EventHandler(this.timerBtn_Tick);
            // 
            // timerStart
            // 
            this.timerStart.Interval = 10;
            this.timerStart.Tag = "FirstRound";
            this.timerStart.Tick += new System.EventHandler(this.timerStart_Tick);
            // 
            // timerMove
            // 
            this.timerMove.Tick += new System.EventHandler(this.timerMove_Tick);
            // 
            // timerPull
            // 
            this.timerPull.Tick += new System.EventHandler(this.timerPull_Tick);
            // 
            // timerBeep
            // 
            this.timerBeep.Tick += new System.EventHandler(this.timerBeep_Tick);
            // 
            // timerSendLight
            // 
            this.timerSendLight.Tick += new System.EventHandler(this.timerSendLight_Tick);
            // 
            // btnCamSample
            // 
            this.btnCamSample.Font = new System.Drawing.Font("楷体", 16F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.btnCamSample.Location = new System.Drawing.Point(362, 37);
            this.btnCamSample.Name = "btnCamSample";
            this.btnCamSample.Size = new System.Drawing.Size(110, 56);
            this.btnCamSample.TabIndex = 3;
            this.btnCamSample.Text = "相机取样";
            this.btnCamSample.UseVisualStyleBackColor = true;
            this.btnCamSample.Click += new System.EventHandler(this.btnCamSample_Click);
            // 
            // FormMain
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(192)))), ((int)(((byte)(255)))));
            this.ClientSize = new System.Drawing.Size(1024, 768);
            this.Controls.Add(this.lblStopNum);
            this.Controls.Add(this.label16);
            this.Controls.Add(this.lblManualSpeed);
            this.Controls.Add(this.label13);
            this.Controls.Add(this.label14);
            this.Controls.Add(this.lblSwtPaperIn);
            this.Controls.Add(this.lblSwtSpot);
            this.Controls.Add(this.lblSwtLight);
            this.Controls.Add(this.lblSwtBlow);
            this.Controls.Add(this.btnClearCurNum);
            this.Controls.Add(this.lblCurNum);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.lblUnitLen);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.btnClearTotal);
            this.Controls.Add(this.lblTotalCount);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.lblPullSpeed);
            this.Controls.Add(this.label19);
            this.Controls.Add(this.label33);
            this.Controls.Add(this.lblAuto);
            this.Controls.Add(this.lblMsg);
            this.Controls.Add(this.lblExcept);
            this.Controls.Add(this.lblRun);
            this.Controls.Add(this.groupBox4);
            this.Controls.Add(this.groupBox3);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.groupBox1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "FormMain";
            this.Text = "主界面";
            this.Activated += new System.EventHandler(this.frmMain_Activated);
            this.Load += new System.EventHandler(this.frmMain_Load);
            this.MouseDoubleClick += new System.Windows.Forms.MouseEventHandler(this.frmMain_MouseDoubleClick);
            this.groupBox1.ResumeLayout(false);
            this.groupBox2.ResumeLayout(false);
            this.groupBox3.ResumeLayout(false);
            this.groupBox4.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Button btnExit;
        private System.Windows.Forms.Button btnManualPosition;
        private System.Windows.Forms.Button btnSystem;
        private System.Windows.Forms.Button btnPrintSet;
        private System.Windows.Forms.Button btnIO;
        private System.Windows.Forms.Button btnStopPrint;
        private System.Windows.Forms.Button btnSysReset;
        private System.Windows.Forms.Button btnPltSet;
        private System.Windows.Forms.Button btnCamCalib;
        private System.Windows.Forms.Button btnCamAjust;
        private System.Windows.Forms.Button btnCamSet;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.GroupBox groupBox3;
        private System.Windows.Forms.GroupBox groupBox4;
        private System.Windows.Forms.RichTextBox richTextBox1;
        private System.Windows.Forms.Label lblRun;
        private System.Windows.Forms.Label lblExcept;
        private System.Windows.Forms.Label lblMsg;
        private System.Windows.Forms.Timer timerInfo;
        private System.Windows.Forms.Label lblAuto;
        private System.Windows.Forms.Label lblPullSpeed;
        private System.Windows.Forms.Label label19;
        private System.Windows.Forms.Label label33;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label lblTotalCount;
        private System.Windows.Forms.Button btnClearTotal;
        private System.Windows.Forms.Label lblUnitLen;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Button btnClearCurNum;
        private System.Windows.Forms.Label lblCurNum;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label lblSwtBlow;
        private System.Windows.Forms.Label lblSwtLight;
        private System.Windows.Forms.Label lblSwtSpot;
        private System.Windows.Forms.Label lblSwtPaperIn;
        private System.Windows.Forms.Label lblManualSpeed;
        private System.Windows.Forms.Label label13;
        private System.Windows.Forms.Label label14;
        private System.Windows.Forms.Label lblStopNum;
        private System.Windows.Forms.Label label16;
        private System.Windows.Forms.Timer timerBtn;
        private System.Windows.Forms.Timer timerStart;
        private System.Windows.Forms.Timer timerMove;
        private System.Windows.Forms.Timer timerPull;
        private System.Windows.Forms.Timer timerBeep;
        private System.Windows.Forms.Timer timerSendLight;
        private HalconDotNet.HWindowControl hWinCtlLeft;
        private HalconDotNet.HWindowControl hWinCtlRight;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Button btnCamSample;
    }
}