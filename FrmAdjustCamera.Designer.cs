namespace PrintInterface
{
    partial class frmAdjustCamera
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
            this.grpLCam = new System.Windows.Forms.GroupBox();
            this.btnLCamRgiht = new System.Windows.Forms.Button();
            this.btnLCamLeft = new System.Windows.Forms.Button();
            this.lblLCamPos = new System.Windows.Forms.Label();
            this.btnLeftZero = new System.Windows.Forms.Button();
            this.label5 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.txtLeftStep = new System.Windows.Forms.TextBox();
            this.btnOK = new System.Windows.Forms.Button();
            this.btnExit = new System.Windows.Forms.Button();
            this.grpRCam = new System.Windows.Forms.GroupBox();
            this.btnRCamRight = new System.Windows.Forms.Button();
            this.btnRCamLeft = new System.Windows.Forms.Button();
            this.lblRCamPos = new System.Windows.Forms.Label();
            this.btnRightZero = new System.Windows.Forms.Button();
            this.label9 = new System.Windows.Forms.Label();
            this.label10 = new System.Windows.Forms.Label();
            this.label8 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.txtRightStep = new System.Windows.Forms.TextBox();
            this.grpPlt = new System.Windows.Forms.GroupBox();
            this.rdoCW = new System.Windows.Forms.RadioButton();
            this.rdoAntiCW = new System.Windows.Forms.RadioButton();
            this.btnPltRotate = new System.Windows.Forms.Button();
            this.txtPltAngle = new System.Windows.Forms.TextBox();
            this.label11 = new System.Windows.Forms.Label();
            this.label12 = new System.Windows.Forms.Label();
            this.txtPltStep = new System.Windows.Forms.TextBox();
            this.btnPltDown = new System.Windows.Forms.Button();
            this.btnPltUp = new System.Windows.Forms.Button();
            this.btnPltRight = new System.Windows.Forms.Button();
            this.btnPltLeft = new System.Windows.Forms.Button();
            this.btnPltZero = new System.Windows.Forms.Button();
            this.label14 = new System.Windows.Forms.Label();
            this.label16 = new System.Windows.Forms.Label();
            this.grpLCam.SuspendLayout();
            this.grpRCam.SuspendLayout();
            this.grpPlt.SuspendLayout();
            this.SuspendLayout();
            // 
            // grpLCam
            // 
            this.grpLCam.Controls.Add(this.btnLCamRgiht);
            this.grpLCam.Controls.Add(this.btnLCamLeft);
            this.grpLCam.Controls.Add(this.lblLCamPos);
            this.grpLCam.Controls.Add(this.btnLeftZero);
            this.grpLCam.Controls.Add(this.label5);
            this.grpLCam.Controls.Add(this.label7);
            this.grpLCam.Controls.Add(this.label1);
            this.grpLCam.Controls.Add(this.label6);
            this.grpLCam.Controls.Add(this.label2);
            this.grpLCam.Controls.Add(this.txtLeftStep);
            this.grpLCam.Font = new System.Drawing.Font("微软雅黑", 15F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.grpLCam.Location = new System.Drawing.Point(445, 3);
            this.grpLCam.Name = "grpLCam";
            this.grpLCam.Size = new System.Drawing.Size(232, 171);
            this.grpLCam.TabIndex = 2;
            this.grpLCam.TabStop = false;
            this.grpLCam.Text = "左相机调整";
            // 
            // btnLCamRgiht
            // 
            this.btnLCamRgiht.BackgroundImage = global::PrintInterface.Properties.Resources.right;
            this.btnLCamRgiht.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.btnLCamRgiht.Font = new System.Drawing.Font("楷体", 16F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.btnLCamRgiht.Location = new System.Drawing.Point(70, 122);
            this.btnLCamRgiht.Name = "btnLCamRgiht";
            this.btnLCamRgiht.Size = new System.Drawing.Size(52, 45);
            this.btnLCamRgiht.TabIndex = 15;
            this.btnLCamRgiht.UseVisualStyleBackColor = true;
            this.btnLCamRgiht.Click += new System.EventHandler(this.btnLCamRgiht_Click);
            // 
            // btnLCamLeft
            // 
            this.btnLCamLeft.BackgroundImage = global::PrintInterface.Properties.Resources.Left;
            this.btnLCamLeft.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.btnLCamLeft.Font = new System.Drawing.Font("楷体", 16F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.btnLCamLeft.Location = new System.Drawing.Point(12, 122);
            this.btnLCamLeft.Name = "btnLCamLeft";
            this.btnLCamLeft.Size = new System.Drawing.Size(52, 45);
            this.btnLCamLeft.TabIndex = 14;
            this.btnLCamLeft.UseVisualStyleBackColor = true;
            this.btnLCamLeft.Click += new System.EventHandler(this.btnLCamLeft_Click);
            // 
            // lblLCamPos
            // 
            this.lblLCamPos.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.lblLCamPos.Location = new System.Drawing.Point(103, 52);
            this.lblLCamPos.Name = "lblLCamPos";
            this.lblLCamPos.Size = new System.Drawing.Size(73, 29);
            this.lblLCamPos.TabIndex = 11;
            this.lblLCamPos.Text = "0.0";
            this.lblLCamPos.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // btnLeftZero
            // 
            this.btnLeftZero.Font = new System.Drawing.Font("楷体", 16F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.btnLeftZero.Location = new System.Drawing.Point(136, 123);
            this.btnLeftZero.Name = "btnLeftZero";
            this.btnLeftZero.Size = new System.Drawing.Size(90, 42);
            this.btnLeftZero.TabIndex = 10;
            this.btnLeftZero.Text = "左归零";
            this.btnLeftZero.UseVisualStyleBackColor = true;
            this.btnLeftZero.Click += new System.EventHandler(this.btnLeftZero_Click);
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("微软雅黑", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label5.Location = new System.Drawing.Point(9, 52);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(96, 28);
            this.label5.TabIndex = 9;
            this.label5.Text = "当前位置";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Font = new System.Drawing.Font("微软雅黑", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label7.Location = new System.Drawing.Point(175, 52);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(52, 28);
            this.label7.TabIndex = 8;
            this.label7.Text = "mm";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("微软雅黑", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label1.Location = new System.Drawing.Point(7, 86);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(75, 28);
            this.label1.TabIndex = 6;
            this.label1.Text = "点动量";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Font = new System.Drawing.Font("微软雅黑", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label6.Location = new System.Drawing.Point(9, 27);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(130, 28);
            this.label6.TabIndex = 5;
            this.label6.Text = "总长150mm";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("微软雅黑", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label2.Location = new System.Drawing.Point(174, 86);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(52, 28);
            this.label2.TabIndex = 3;
            this.label2.Text = "mm";
            // 
            // txtLeftStep
            // 
            this.txtLeftStep.Font = new System.Drawing.Font("微软雅黑", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.txtLeftStep.Location = new System.Drawing.Point(103, 83);
            this.txtLeftStep.Name = "txtLeftStep";
            this.txtLeftStep.Size = new System.Drawing.Size(73, 35);
            this.txtLeftStep.TabIndex = 1;
            this.txtLeftStep.Tag = "0.01/50";
            this.txtLeftStep.Text = "0.1";
            this.txtLeftStep.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // btnOK
            // 
            this.btnOK.Font = new System.Drawing.Font("楷体", 16F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.btnOK.Location = new System.Drawing.Point(928, 28);
            this.btnOK.Name = "btnOK";
            this.btnOK.Size = new System.Drawing.Size(70, 49);
            this.btnOK.TabIndex = 3;
            this.btnOK.Text = "确定";
            this.btnOK.UseVisualStyleBackColor = true;
            this.btnOK.Click += new System.EventHandler(this.btnOK_Click);
            // 
            // btnExit
            // 
            this.btnExit.Font = new System.Drawing.Font("楷体", 16F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.btnExit.Location = new System.Drawing.Point(928, 120);
            this.btnExit.Name = "btnExit";
            this.btnExit.Size = new System.Drawing.Size(70, 47);
            this.btnExit.TabIndex = 5;
            this.btnExit.Text = "退出";
            this.btnExit.UseVisualStyleBackColor = true;
            this.btnExit.Click += new System.EventHandler(this.btnExit_Click);
            // 
            // grpRCam
            // 
            this.grpRCam.Controls.Add(this.btnRCamRight);
            this.grpRCam.Controls.Add(this.btnRCamLeft);
            this.grpRCam.Controls.Add(this.lblRCamPos);
            this.grpRCam.Controls.Add(this.btnRightZero);
            this.grpRCam.Controls.Add(this.label9);
            this.grpRCam.Controls.Add(this.label10);
            this.grpRCam.Controls.Add(this.label8);
            this.grpRCam.Controls.Add(this.label3);
            this.grpRCam.Controls.Add(this.label4);
            this.grpRCam.Controls.Add(this.txtRightStep);
            this.grpRCam.Font = new System.Drawing.Font("微软雅黑", 15F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.grpRCam.Location = new System.Drawing.Point(683, 3);
            this.grpRCam.Name = "grpRCam";
            this.grpRCam.Size = new System.Drawing.Size(239, 171);
            this.grpRCam.TabIndex = 6;
            this.grpRCam.TabStop = false;
            this.grpRCam.Text = "右相机调整";
            // 
            // btnRCamRight
            // 
            this.btnRCamRight.BackgroundImage = global::PrintInterface.Properties.Resources.right;
            this.btnRCamRight.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.btnRCamRight.Font = new System.Drawing.Font("楷体", 16F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.btnRCamRight.Location = new System.Drawing.Point(69, 120);
            this.btnRCamRight.Name = "btnRCamRight";
            this.btnRCamRight.Size = new System.Drawing.Size(52, 45);
            this.btnRCamRight.TabIndex = 17;
            this.btnRCamRight.UseVisualStyleBackColor = true;
            this.btnRCamRight.Click += new System.EventHandler(this.btnRCamRight_Click);
            // 
            // btnRCamLeft
            // 
            this.btnRCamLeft.BackgroundImage = global::PrintInterface.Properties.Resources.Left;
            this.btnRCamLeft.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.btnRCamLeft.Font = new System.Drawing.Font("楷体", 16F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.btnRCamLeft.Location = new System.Drawing.Point(11, 120);
            this.btnRCamLeft.Name = "btnRCamLeft";
            this.btnRCamLeft.Size = new System.Drawing.Size(52, 45);
            this.btnRCamLeft.TabIndex = 16;
            this.btnRCamLeft.UseVisualStyleBackColor = true;
            this.btnRCamLeft.Click += new System.EventHandler(this.btnRCamLeft_Click);
            // 
            // lblRCamPos
            // 
            this.lblRCamPos.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.lblRCamPos.Location = new System.Drawing.Point(100, 51);
            this.lblRCamPos.Name = "lblRCamPos";
            this.lblRCamPos.Size = new System.Drawing.Size(78, 29);
            this.lblRCamPos.TabIndex = 13;
            this.lblRCamPos.Text = "0.0";
            this.lblRCamPos.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // btnRightZero
            // 
            this.btnRightZero.Font = new System.Drawing.Font("楷体", 16F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.btnRightZero.Location = new System.Drawing.Point(142, 123);
            this.btnRightZero.Name = "btnRightZero";
            this.btnRightZero.Size = new System.Drawing.Size(90, 42);
            this.btnRightZero.TabIndex = 12;
            this.btnRightZero.Text = "右归零";
            this.btnRightZero.UseVisualStyleBackColor = true;
            this.btnRightZero.Click += new System.EventHandler(this.btnRightZero_Click);
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Font = new System.Drawing.Font("微软雅黑", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label9.Location = new System.Drawing.Point(180, 51);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(52, 28);
            this.label9.TabIndex = 11;
            this.label9.Text = "mm";
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Font = new System.Drawing.Font("微软雅黑", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label10.Location = new System.Drawing.Point(6, 52);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(96, 28);
            this.label10.TabIndex = 10;
            this.label10.Text = "当前位置";
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Font = new System.Drawing.Font("微软雅黑", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label8.Location = new System.Drawing.Point(6, 27);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(130, 28);
            this.label8.TabIndex = 8;
            this.label8.Text = "总长150mm";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("微软雅黑", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label3.Location = new System.Drawing.Point(180, 85);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(52, 28);
            this.label3.TabIndex = 6;
            this.label3.Text = "mm";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("微软雅黑", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label4.Location = new System.Drawing.Point(6, 85);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(75, 28);
            this.label4.TabIndex = 5;
            this.label4.Text = "点动量";
            // 
            // txtRightStep
            // 
            this.txtRightStep.Font = new System.Drawing.Font("微软雅黑", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.txtRightStep.Location = new System.Drawing.Point(100, 82);
            this.txtRightStep.Name = "txtRightStep";
            this.txtRightStep.Size = new System.Drawing.Size(78, 35);
            this.txtRightStep.TabIndex = 4;
            this.txtRightStep.Tag = "0.01/50";
            this.txtRightStep.Text = "0.1";
            this.txtRightStep.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // grpPlt
            // 
            this.grpPlt.Controls.Add(this.rdoCW);
            this.grpPlt.Controls.Add(this.rdoAntiCW);
            this.grpPlt.Controls.Add(this.btnPltRotate);
            this.grpPlt.Controls.Add(this.txtPltAngle);
            this.grpPlt.Controls.Add(this.label11);
            this.grpPlt.Controls.Add(this.label12);
            this.grpPlt.Controls.Add(this.txtPltStep);
            this.grpPlt.Controls.Add(this.btnPltDown);
            this.grpPlt.Controls.Add(this.btnPltUp);
            this.grpPlt.Controls.Add(this.btnPltRight);
            this.grpPlt.Controls.Add(this.btnPltLeft);
            this.grpPlt.Controls.Add(this.btnPltZero);
            this.grpPlt.Controls.Add(this.label14);
            this.grpPlt.Controls.Add(this.label16);
            this.grpPlt.Font = new System.Drawing.Font("微软雅黑", 15F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.grpPlt.Location = new System.Drawing.Point(3, 3);
            this.grpPlt.Name = "grpPlt";
            this.grpPlt.Size = new System.Drawing.Size(436, 171);
            this.grpPlt.TabIndex = 7;
            this.grpPlt.TabStop = false;
            this.grpPlt.Text = "平台调整";
            // 
            // rdoCW
            // 
            this.rdoCW.AutoSize = true;
            this.rdoCW.Font = new System.Drawing.Font("微软雅黑", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.rdoCW.Location = new System.Drawing.Point(335, 72);
            this.rdoCW.Name = "rdoCW";
            this.rdoCW.Size = new System.Drawing.Size(93, 32);
            this.rdoCW.TabIndex = 21;
            this.rdoCW.Text = "顺时针";
            this.rdoCW.UseVisualStyleBackColor = true;
            // 
            // rdoAntiCW
            // 
            this.rdoAntiCW.AutoSize = true;
            this.rdoAntiCW.Checked = true;
            this.rdoAntiCW.Font = new System.Drawing.Font("微软雅黑", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.rdoAntiCW.Location = new System.Drawing.Point(244, 72);
            this.rdoAntiCW.Name = "rdoAntiCW";
            this.rdoAntiCW.Size = new System.Drawing.Size(93, 32);
            this.rdoAntiCW.TabIndex = 20;
            this.rdoAntiCW.TabStop = true;
            this.rdoAntiCW.Text = "逆时针";
            this.rdoAntiCW.UseVisualStyleBackColor = true;
            // 
            // btnPltRotate
            // 
            this.btnPltRotate.Font = new System.Drawing.Font("楷体", 16F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.btnPltRotate.Location = new System.Drawing.Point(309, 120);
            this.btnPltRotate.Name = "btnPltRotate";
            this.btnPltRotate.Size = new System.Drawing.Size(108, 45);
            this.btnPltRotate.TabIndex = 19;
            this.btnPltRotate.Text = "转动";
            this.btnPltRotate.UseVisualStyleBackColor = true;
            this.btnPltRotate.Click += new System.EventHandler(this.btnPltRotate_Click);
            // 
            // txtPltAngle
            // 
            this.txtPltAngle.Font = new System.Drawing.Font("微软雅黑", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.txtPltAngle.Location = new System.Drawing.Point(335, 28);
            this.txtPltAngle.Name = "txtPltAngle";
            this.txtPltAngle.Size = new System.Drawing.Size(66, 35);
            this.txtPltAngle.TabIndex = 16;
            this.txtPltAngle.Tag = "0.001/2.5";
            this.txtPltAngle.Text = "0.1";
            this.txtPltAngle.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.Font = new System.Drawing.Font("微软雅黑", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label11.Location = new System.Drawing.Point(241, 34);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(96, 28);
            this.label11.TabIndex = 18;
            this.label11.Text = "转动角度";
            // 
            // label12
            // 
            this.label12.AutoSize = true;
            this.label12.Font = new System.Drawing.Font("微软雅黑", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label12.Location = new System.Drawing.Point(400, 34);
            this.label12.Name = "label12";
            this.label12.Size = new System.Drawing.Size(33, 28);
            this.label12.TabIndex = 17;
            this.label12.Text = "度";
            // 
            // txtPltStep
            // 
            this.txtPltStep.Font = new System.Drawing.Font("微软雅黑", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.txtPltStep.Location = new System.Drawing.Point(120, 30);
            this.txtPltStep.Name = "txtPltStep";
            this.txtPltStep.Size = new System.Drawing.Size(66, 35);
            this.txtPltStep.TabIndex = 1;
            this.txtPltStep.Tag = "0..01/10";
            this.txtPltStep.Text = "0.1";
            this.txtPltStep.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // btnPltDown
            // 
            this.btnPltDown.BackgroundImage = global::PrintInterface.Properties.Resources.down;
            this.btnPltDown.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.btnPltDown.Font = new System.Drawing.Font("楷体", 16F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.btnPltDown.Location = new System.Drawing.Point(72, 120);
            this.btnPltDown.Name = "btnPltDown";
            this.btnPltDown.Size = new System.Drawing.Size(52, 45);
            this.btnPltDown.TabIndex = 15;
            this.btnPltDown.UseVisualStyleBackColor = true;
            this.btnPltDown.Click += new System.EventHandler(this.btnPltDown_Click);
            // 
            // btnPltUp
            // 
            this.btnPltUp.BackgroundImage = global::PrintInterface.Properties.Resources.up;
            this.btnPltUp.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.btnPltUp.Font = new System.Drawing.Font("楷体", 16F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.btnPltUp.Location = new System.Drawing.Point(72, 72);
            this.btnPltUp.Name = "btnPltUp";
            this.btnPltUp.Size = new System.Drawing.Size(52, 45);
            this.btnPltUp.TabIndex = 14;
            this.btnPltUp.UseVisualStyleBackColor = true;
            this.btnPltUp.Click += new System.EventHandler(this.btnPltUp_Click);
            // 
            // btnPltRight
            // 
            this.btnPltRight.BackgroundImage = global::PrintInterface.Properties.Resources.right;
            this.btnPltRight.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.btnPltRight.Font = new System.Drawing.Font("楷体", 16F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.btnPltRight.Location = new System.Drawing.Point(128, 120);
            this.btnPltRight.Name = "btnPltRight";
            this.btnPltRight.Size = new System.Drawing.Size(52, 45);
            this.btnPltRight.TabIndex = 13;
            this.btnPltRight.UseVisualStyleBackColor = true;
            this.btnPltRight.Click += new System.EventHandler(this.btnPltRight_Click);
            // 
            // btnPltLeft
            // 
            this.btnPltLeft.BackgroundImage = global::PrintInterface.Properties.Resources.Left;
            this.btnPltLeft.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.btnPltLeft.Font = new System.Drawing.Font("楷体", 16F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.btnPltLeft.Location = new System.Drawing.Point(17, 120);
            this.btnPltLeft.Name = "btnPltLeft";
            this.btnPltLeft.Size = new System.Drawing.Size(52, 45);
            this.btnPltLeft.TabIndex = 12;
            this.btnPltLeft.UseVisualStyleBackColor = true;
            this.btnPltLeft.Click += new System.EventHandler(this.btnPltLeft_Click);
            // 
            // btnPltZero
            // 
            this.btnPltZero.Font = new System.Drawing.Font("楷体", 16F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.btnPltZero.Location = new System.Drawing.Point(191, 120);
            this.btnPltZero.Name = "btnPltZero";
            this.btnPltZero.Size = new System.Drawing.Size(108, 45);
            this.btnPltZero.TabIndex = 10;
            this.btnPltZero.Text = "平台归零";
            this.btnPltZero.UseVisualStyleBackColor = true;
            this.btnPltZero.Click += new System.EventHandler(this.btnPltZero_Click);
            // 
            // label14
            // 
            this.label14.AutoSize = true;
            this.label14.Font = new System.Drawing.Font("微软雅黑", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label14.Location = new System.Drawing.Point(5, 36);
            this.label14.Name = "label14";
            this.label14.Size = new System.Drawing.Size(117, 28);
            this.label14.TabIndex = 6;
            this.label14.Text = "点动平移量";
            // 
            // label16
            // 
            this.label16.AutoSize = true;
            this.label16.Font = new System.Drawing.Font("微软雅黑", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label16.Location = new System.Drawing.Point(184, 32);
            this.label16.Name = "label16";
            this.label16.Size = new System.Drawing.Size(52, 28);
            this.label16.TabIndex = 3;
            this.label16.Text = "mm";
            // 
            // frmAdjustCamera
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(192)))), ((int)(((byte)(255)))));
            this.ClientSize = new System.Drawing.Size(1008, 177);
            this.Controls.Add(this.grpPlt);
            this.Controls.Add(this.grpRCam);
            this.Controls.Add(this.btnExit);
            this.Controls.Add(this.btnOK);
            this.Controls.Add(this.grpLCam);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "frmAdjustCamera";
            this.Text = "调整相机";
            this.Load += new System.EventHandler(this.frmAdjustCamera_Load);
            this.grpLCam.ResumeLayout(false);
            this.grpLCam.PerformLayout();
            this.grpRCam.ResumeLayout(false);
            this.grpRCam.PerformLayout();
            this.grpPlt.ResumeLayout(false);
            this.grpPlt.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox grpLCam;
        private System.Windows.Forms.Button btnOK;
        private System.Windows.Forms.Button btnExit;
        private System.Windows.Forms.GroupBox grpRCam;
        private System.Windows.Forms.TextBox txtLeftStep;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox txtRightStep;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.Label lblLCamPos;
        private System.Windows.Forms.Button btnLeftZero;
        private System.Windows.Forms.Label lblRCamPos;
        private System.Windows.Forms.Button btnRightZero;
        private System.Windows.Forms.GroupBox grpPlt;
        private System.Windows.Forms.Button btnPltRotate;
        private System.Windows.Forms.TextBox txtPltAngle;
        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.Label label12;
        private System.Windows.Forms.TextBox txtPltStep;
        private System.Windows.Forms.Button btnPltDown;
        private System.Windows.Forms.Button btnPltUp;
        private System.Windows.Forms.Button btnPltRight;
        private System.Windows.Forms.Button btnPltLeft;
        private System.Windows.Forms.Button btnPltZero;
        private System.Windows.Forms.Label label14;
        private System.Windows.Forms.Label label16;
        private System.Windows.Forms.RadioButton rdoCW;
        private System.Windows.Forms.RadioButton rdoAntiCW;
        private System.Windows.Forms.Button btnLCamRgiht;
        private System.Windows.Forms.Button btnLCamLeft;
        private System.Windows.Forms.Button btnRCamRight;
        private System.Windows.Forms.Button btnRCamLeft;
    }
}