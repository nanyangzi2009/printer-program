namespace PrintInterface
{
    partial class FormSample
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
            this.grpAjust = new System.Windows.Forms.GroupBox();
            this.rdoFine = new System.Windows.Forms.RadioButton();
            this.rdoRough = new System.Windows.Forms.RadioButton();
            this.groupBox3 = new System.Windows.Forms.GroupBox();
            this.rdoAjustFrmBorder = new System.Windows.Forms.RadioButton();
            this.rdoMoveFrm = new System.Windows.Forms.RadioButton();
            this.rdoMoveImg = new System.Windows.Forms.RadioButton();
            this.btnUp = new System.Windows.Forms.Button();
            this.picSmall = new System.Windows.Forms.PictureBox();
            this.picBig = new System.Windows.Forms.PictureBox();
            this.btnDown = new System.Windows.Forms.Button();
            this.btnLeft = new System.Windows.Forms.Button();
            this.btnRight = new System.Windows.Forms.Button();
            this.grpSelect = new System.Windows.Forms.GroupBox();
            this.rdoUp = new System.Windows.Forms.RadioButton();
            this.rdoBottom = new System.Windows.Forms.RadioButton();
            this.rdoRight = new System.Windows.Forms.RadioButton();
            this.rdoLeft = new System.Windows.Forms.RadioButton();
            this.LineSelected = new System.Windows.Forms.Label();
            this.btnOK = new System.Windows.Forms.Button();
            this.btnExit = new System.Windows.Forms.Button();
            this.grpAjust.SuspendLayout();
            this.groupBox3.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.picSmall)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.picBig)).BeginInit();
            this.grpSelect.SuspendLayout();
            this.SuspendLayout();
            // 
            // grpAjust
            // 
            this.grpAjust.Controls.Add(this.rdoFine);
            this.grpAjust.Controls.Add(this.rdoRough);
            this.grpAjust.Location = new System.Drawing.Point(784, 430);
            this.grpAjust.Name = "grpAjust";
            this.grpAjust.Size = new System.Drawing.Size(200, 48);
            this.grpAjust.TabIndex = 12;
            this.grpAjust.TabStop = false;
            // 
            // rdoFine
            // 
            this.rdoFine.AutoSize = true;
            this.rdoFine.Font = new System.Drawing.Font("微软雅黑", 15F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.rdoFine.Location = new System.Drawing.Point(123, 11);
            this.rdoFine.Name = "rdoFine";
            this.rdoFine.Size = new System.Drawing.Size(70, 31);
            this.rdoFine.TabIndex = 10;
            this.rdoFine.Text = "细调";
            this.rdoFine.UseVisualStyleBackColor = true;
            this.rdoFine.CheckedChanged += new System.EventHandler(this.rdoFine_CheckedChanged);
            // 
            // rdoRough
            // 
            this.rdoRough.AutoSize = true;
            this.rdoRough.Checked = true;
            this.rdoRough.Font = new System.Drawing.Font("微软雅黑", 15F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.rdoRough.Location = new System.Drawing.Point(13, 12);
            this.rdoRough.Name = "rdoRough";
            this.rdoRough.Size = new System.Drawing.Size(70, 31);
            this.rdoRough.TabIndex = 9;
            this.rdoRough.TabStop = true;
            this.rdoRough.Text = "粗调";
            this.rdoRough.UseVisualStyleBackColor = true;
            this.rdoRough.CheckedChanged += new System.EventHandler(this.rdoRough_CheckedChanged);
            // 
            // groupBox3
            // 
            this.groupBox3.Controls.Add(this.rdoAjustFrmBorder);
            this.groupBox3.Controls.Add(this.rdoMoveFrm);
            this.groupBox3.Controls.Add(this.rdoMoveImg);
            this.groupBox3.Location = new System.Drawing.Point(784, 178);
            this.groupBox3.Name = "groupBox3";
            this.groupBox3.Size = new System.Drawing.Size(200, 98);
            this.groupBox3.TabIndex = 13;
            this.groupBox3.TabStop = false;
            // 
            // rdoAjustFrmBorder
            // 
            this.rdoAjustFrmBorder.AutoSize = true;
            this.rdoAjustFrmBorder.Font = new System.Drawing.Font("微软雅黑", 15F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.rdoAjustFrmBorder.Location = new System.Drawing.Point(13, 63);
            this.rdoAjustFrmBorder.Name = "rdoAjustFrmBorder";
            this.rdoAjustFrmBorder.Size = new System.Drawing.Size(170, 31);
            this.rdoAjustFrmBorder.TabIndex = 11;
            this.rdoAjustFrmBorder.Text = "调整选取框大小";
            this.rdoAjustFrmBorder.UseVisualStyleBackColor = true;
            this.rdoAjustFrmBorder.CheckedChanged += new System.EventHandler(this.rdoAjustFrm_CheckedChanged);
            // 
            // rdoMoveFrm
            // 
            this.rdoMoveFrm.AutoSize = true;
            this.rdoMoveFrm.Checked = true;
            this.rdoMoveFrm.Font = new System.Drawing.Font("微软雅黑", 15F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.rdoMoveFrm.Location = new System.Drawing.Point(103, 20);
            this.rdoMoveFrm.Name = "rdoMoveFrm";
            this.rdoMoveFrm.Size = new System.Drawing.Size(90, 31);
            this.rdoMoveFrm.TabIndex = 10;
            this.rdoMoveFrm.TabStop = true;
            this.rdoMoveFrm.Text = "移动框";
            this.rdoMoveFrm.UseVisualStyleBackColor = true;
            this.rdoMoveFrm.CheckedChanged += new System.EventHandler(this.rdoMoveFrm_CheckedChanged);
            // 
            // rdoMoveImg
            // 
            this.rdoMoveImg.AutoSize = true;
            this.rdoMoveImg.Font = new System.Drawing.Font("微软雅黑", 15F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.rdoMoveImg.Location = new System.Drawing.Point(13, 22);
            this.rdoMoveImg.Name = "rdoMoveImg";
            this.rdoMoveImg.Size = new System.Drawing.Size(90, 31);
            this.rdoMoveImg.TabIndex = 9;
            this.rdoMoveImg.Text = "移动图";
            this.rdoMoveImg.UseVisualStyleBackColor = true;
            this.rdoMoveImg.CheckedChanged += new System.EventHandler(this.rdoMoveImg_CheckedChanged);
            // 
            // btnUp
            // 
            this.btnUp.BackgroundImage = global::PrintInterface.Properties.Resources.up;
            this.btnUp.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.btnUp.Location = new System.Drawing.Point(857, 484);
            this.btnUp.Name = "btnUp";
            this.btnUp.Size = new System.Drawing.Size(55, 50);
            this.btnUp.TabIndex = 15;
            this.btnUp.UseVisualStyleBackColor = true;
            this.btnUp.Click += new System.EventHandler(this.btnUp_Click);
            // 
            // picSmall
            // 
            this.picSmall.BackColor = System.Drawing.SystemColors.Highlight;
            this.picSmall.Location = new System.Drawing.Point(784, 12);
            this.picSmall.Name = "picSmall";
            this.picSmall.Size = new System.Drawing.Size(200, 160);
            this.picSmall.TabIndex = 1;
            this.picSmall.TabStop = false;
            // 
            // picBig
            // 
            this.picBig.BackColor = System.Drawing.SystemColors.Highlight;
            this.picBig.Location = new System.Drawing.Point(0, 0);
            this.picBig.Name = "picBig";
            this.picBig.Size = new System.Drawing.Size(768, 768);
            this.picBig.TabIndex = 0;
            this.picBig.TabStop = false;
            // 
            // btnDown
            // 
            this.btnDown.BackgroundImage = global::PrintInterface.Properties.Resources.down;
            this.btnDown.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.btnDown.Location = new System.Drawing.Point(857, 540);
            this.btnDown.Name = "btnDown";
            this.btnDown.Size = new System.Drawing.Size(55, 50);
            this.btnDown.TabIndex = 16;
            this.btnDown.UseVisualStyleBackColor = true;
            this.btnDown.Click += new System.EventHandler(this.btnDown_Click);
            // 
            // btnLeft
            // 
            this.btnLeft.BackgroundImage = global::PrintInterface.Properties.Resources.Left;
            this.btnLeft.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.btnLeft.Location = new System.Drawing.Point(796, 515);
            this.btnLeft.Name = "btnLeft";
            this.btnLeft.Size = new System.Drawing.Size(55, 50);
            this.btnLeft.TabIndex = 17;
            this.btnLeft.UseVisualStyleBackColor = true;
            this.btnLeft.Click += new System.EventHandler(this.btnLeft_Click);
            // 
            // btnRight
            // 
            this.btnRight.BackgroundImage = global::PrintInterface.Properties.Resources.right;
            this.btnRight.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.btnRight.Location = new System.Drawing.Point(918, 515);
            this.btnRight.Name = "btnRight";
            this.btnRight.Size = new System.Drawing.Size(55, 50);
            this.btnRight.TabIndex = 18;
            this.btnRight.UseVisualStyleBackColor = true;
            this.btnRight.Click += new System.EventHandler(this.btnRight_Click);
            // 
            // grpSelect
            // 
            this.grpSelect.Controls.Add(this.rdoUp);
            this.grpSelect.Controls.Add(this.rdoBottom);
            this.grpSelect.Controls.Add(this.rdoRight);
            this.grpSelect.Controls.Add(this.rdoLeft);
            this.grpSelect.Enabled = false;
            this.grpSelect.Font = new System.Drawing.Font("微软雅黑", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.grpSelect.Location = new System.Drawing.Point(784, 282);
            this.grpSelect.Name = "grpSelect";
            this.grpSelect.Size = new System.Drawing.Size(200, 142);
            this.grpSelect.TabIndex = 19;
            this.grpSelect.TabStop = false;
            this.grpSelect.Text = "选边";
            // 
            // rdoUp
            // 
            this.rdoUp.AutoSize = true;
            this.rdoUp.Font = new System.Drawing.Font("微软雅黑", 15F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.rdoUp.Location = new System.Drawing.Point(60, 22);
            this.rdoUp.Name = "rdoUp";
            this.rdoUp.Size = new System.Drawing.Size(90, 31);
            this.rdoUp.TabIndex = 12;
            this.rdoUp.Text = "选上边";
            this.rdoUp.UseVisualStyleBackColor = true;
            this.rdoUp.CheckedChanged += new System.EventHandler(this.rdoUp_CheckedChanged);
            // 
            // rdoBottom
            // 
            this.rdoBottom.AutoSize = true;
            this.rdoBottom.Font = new System.Drawing.Font("微软雅黑", 15F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.rdoBottom.Location = new System.Drawing.Point(60, 105);
            this.rdoBottom.Name = "rdoBottom";
            this.rdoBottom.Size = new System.Drawing.Size(90, 31);
            this.rdoBottom.TabIndex = 11;
            this.rdoBottom.Text = "选下边";
            this.rdoBottom.UseVisualStyleBackColor = true;
            this.rdoBottom.CheckedChanged += new System.EventHandler(this.rdoBottom_CheckedChanged);
            // 
            // rdoRight
            // 
            this.rdoRight.AutoSize = true;
            this.rdoRight.Font = new System.Drawing.Font("微软雅黑", 15F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.rdoRight.Location = new System.Drawing.Point(106, 59);
            this.rdoRight.Name = "rdoRight";
            this.rdoRight.Size = new System.Drawing.Size(90, 31);
            this.rdoRight.TabIndex = 10;
            this.rdoRight.Text = "选右边";
            this.rdoRight.UseVisualStyleBackColor = true;
            this.rdoRight.CheckedChanged += new System.EventHandler(this.rdoRight_CheckedChanged);
            // 
            // rdoLeft
            // 
            this.rdoLeft.AutoSize = true;
            this.rdoLeft.Checked = true;
            this.rdoLeft.Font = new System.Drawing.Font("微软雅黑", 15F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.rdoLeft.Location = new System.Drawing.Point(6, 59);
            this.rdoLeft.Name = "rdoLeft";
            this.rdoLeft.Size = new System.Drawing.Size(90, 31);
            this.rdoLeft.TabIndex = 9;
            this.rdoLeft.TabStop = true;
            this.rdoLeft.Text = "选左边";
            this.rdoLeft.UseVisualStyleBackColor = true;
            this.rdoLeft.CheckedChanged += new System.EventHandler(this.rdoLeft_CheckedChanged);
            // 
            // LineSelected
            // 
            this.LineSelected.BackColor = System.Drawing.Color.Red;
            this.LineSelected.Location = new System.Drawing.Point(97, 85);
            this.LineSelected.Name = "LineSelected";
            this.LineSelected.Size = new System.Drawing.Size(1, 100);
            this.LineSelected.TabIndex = 20;
            // 
            // btnOK
            // 
            this.btnOK.Font = new System.Drawing.Font("楷体", 15F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.btnOK.Location = new System.Drawing.Point(832, 616);
            this.btnOK.Name = "btnOK";
            this.btnOK.Size = new System.Drawing.Size(135, 53);
            this.btnOK.TabIndex = 22;
            this.btnOK.Text = "确定";
            this.btnOK.UseVisualStyleBackColor = true;
            this.btnOK.Click += new System.EventHandler(this.btnOK_Click);
            // 
            // btnExit
            // 
            this.btnExit.Font = new System.Drawing.Font("楷体", 15F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.btnExit.Location = new System.Drawing.Point(832, 685);
            this.btnExit.Name = "btnExit";
            this.btnExit.Size = new System.Drawing.Size(135, 53);
            this.btnExit.TabIndex = 21;
            this.btnExit.Text = "退出";
            this.btnExit.UseVisualStyleBackColor = true;
            this.btnExit.Click += new System.EventHandler(this.btnExit_Click);
            // 
            // FormSample
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(192)))), ((int)(((byte)(255)))));
            this.ClientSize = new System.Drawing.Size(1024, 768);
            this.Controls.Add(this.btnOK);
            this.Controls.Add(this.btnExit);
            this.Controls.Add(this.LineSelected);
            this.Controls.Add(this.grpSelect);
            this.Controls.Add(this.btnRight);
            this.Controls.Add(this.btnLeft);
            this.Controls.Add(this.btnDown);
            this.Controls.Add(this.btnUp);
            this.Controls.Add(this.groupBox3);
            this.Controls.Add(this.grpAjust);
            this.Controls.Add(this.picSmall);
            this.Controls.Add(this.picBig);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "FormSample";
            this.Text = "取样设置";
            this.Load += new System.EventHandler(this.FormSample_Load);
            this.grpAjust.ResumeLayout(false);
            this.grpAjust.PerformLayout();
            this.groupBox3.ResumeLayout(false);
            this.groupBox3.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.picSmall)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.picBig)).EndInit();
            this.grpSelect.ResumeLayout(false);
            this.grpSelect.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        public System.Windows.Forms.PictureBox picBig;
        public System.Windows.Forms.PictureBox picSmall;
        private System.Windows.Forms.GroupBox grpAjust;
        private System.Windows.Forms.RadioButton rdoFine;
        private System.Windows.Forms.RadioButton rdoRough;
        private System.Windows.Forms.GroupBox groupBox3;
        private System.Windows.Forms.RadioButton rdoAjustFrmBorder;
        private System.Windows.Forms.RadioButton rdoMoveFrm;
        private System.Windows.Forms.RadioButton rdoMoveImg;
        private System.Windows.Forms.Button btnUp;
        private System.Windows.Forms.Button btnDown;
        private System.Windows.Forms.Button btnLeft;
        private System.Windows.Forms.Button btnRight;
        private System.Windows.Forms.GroupBox grpSelect;
        private System.Windows.Forms.RadioButton rdoUp;
        private System.Windows.Forms.RadioButton rdoBottom;
        private System.Windows.Forms.RadioButton rdoRight;
        private System.Windows.Forms.RadioButton rdoLeft;
        private System.Windows.Forms.Label LineSelected;
        private System.Windows.Forms.Button btnOK;
        private System.Windows.Forms.Button btnExit;

    }
}