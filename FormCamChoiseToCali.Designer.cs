namespace PrintInterface
{
    partial class FormChoiceToCali
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
            this.btnCancel = new System.Windows.Forms.Button();
            this.btnOK = new System.Windows.Forms.Button();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.rdoRightCam = new System.Windows.Forms.RadioButton();
            this.rdoLeftCam = new System.Windows.Forms.RadioButton();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.rdoDirection = new System.Windows.Forms.RadioButton();
            this.rdoLength = new System.Windows.Forms.RadioButton();
            this.groupBox1.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.SuspendLayout();
            // 
            // btnCancel
            // 
            this.btnCancel.Font = new System.Drawing.Font("楷体", 16F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.btnCancel.Location = new System.Drawing.Point(255, 176);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Size = new System.Drawing.Size(129, 44);
            this.btnCancel.TabIndex = 2;
            this.btnCancel.Text = "退出";
            this.btnCancel.UseVisualStyleBackColor = true;
            this.btnCancel.Click += new System.EventHandler(this.btnCancel_Click);
            // 
            // btnOK
            // 
            this.btnOK.Font = new System.Drawing.Font("楷体", 16F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.btnOK.Location = new System.Drawing.Point(38, 176);
            this.btnOK.Name = "btnOK";
            this.btnOK.Size = new System.Drawing.Size(129, 44);
            this.btnOK.TabIndex = 4;
            this.btnOK.Text = "确定";
            this.btnOK.UseVisualStyleBackColor = true;
            this.btnOK.Click += new System.EventHandler(this.btnOK_Click);
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.rdoRightCam);
            this.groupBox1.Controls.Add(this.rdoLeftCam);
            this.groupBox1.Font = new System.Drawing.Font("微软雅黑", 15F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.groupBox1.Location = new System.Drawing.Point(38, 6);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(346, 73);
            this.groupBox1.TabIndex = 5;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "选择相机";
            // 
            // rdoRightCam
            // 
            this.rdoRightCam.AutoSize = true;
            this.rdoRightCam.Font = new System.Drawing.Font("微软雅黑", 15F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.rdoRightCam.Location = new System.Drawing.Point(191, 30);
            this.rdoRightCam.Name = "rdoRightCam";
            this.rdoRightCam.Size = new System.Drawing.Size(130, 31);
            this.rdoRightCam.TabIndex = 11;
            this.rdoRightCam.Text = "标定右相机";
            this.rdoRightCam.UseVisualStyleBackColor = true;
            this.rdoRightCam.CheckedChanged += new System.EventHandler(this.rdoRightCam_CheckedChanged);
            // 
            // rdoLeftCam
            // 
            this.rdoLeftCam.AutoSize = true;
            this.rdoLeftCam.Checked = true;
            this.rdoLeftCam.Font = new System.Drawing.Font("微软雅黑", 15F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.rdoLeftCam.Location = new System.Drawing.Point(29, 30);
            this.rdoLeftCam.Name = "rdoLeftCam";
            this.rdoLeftCam.Size = new System.Drawing.Size(130, 31);
            this.rdoLeftCam.TabIndex = 10;
            this.rdoLeftCam.TabStop = true;
            this.rdoLeftCam.Text = "标定左相机";
            this.rdoLeftCam.UseVisualStyleBackColor = true;
            this.rdoLeftCam.CheckedChanged += new System.EventHandler(this.rdoLeftCam_CheckedChanged);
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.rdoDirection);
            this.groupBox2.Controls.Add(this.rdoLength);
            this.groupBox2.Font = new System.Drawing.Font("微软雅黑", 15F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.groupBox2.Location = new System.Drawing.Point(38, 85);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(346, 73);
            this.groupBox2.TabIndex = 6;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "选择标定";
            // 
            // rdoDirection
            // 
            this.rdoDirection.AutoSize = true;
            this.rdoDirection.Font = new System.Drawing.Font("微软雅黑", 15F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.rdoDirection.Location = new System.Drawing.Point(191, 30);
            this.rdoDirection.Name = "rdoDirection";
            this.rdoDirection.Size = new System.Drawing.Size(150, 31);
            this.rdoDirection.TabIndex = 11;
            this.rdoDirection.Text = "标定相机方向";
            this.rdoDirection.UseVisualStyleBackColor = true;
            // 
            // rdoLength
            // 
            this.rdoLength.AutoSize = true;
            this.rdoLength.Checked = true;
            this.rdoLength.Font = new System.Drawing.Font("微软雅黑", 15F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.rdoLength.Location = new System.Drawing.Point(29, 30);
            this.rdoLength.Name = "rdoLength";
            this.rdoLength.Size = new System.Drawing.Size(150, 31);
            this.rdoLength.TabIndex = 10;
            this.rdoLength.TabStop = true;
            this.rdoLength.Text = "标定像素单位";
            this.rdoLength.UseVisualStyleBackColor = true;
            // 
            // FormChoiceToCali
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(192)))), ((int)(((byte)(255)))));
            this.ClientSize = new System.Drawing.Size(426, 245);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.btnOK);
            this.Controls.Add(this.btnCancel);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.Fixed3D;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "FormChoiceToCali";
            this.Text = "相机标定";
            this.Load += new System.EventHandler(this.frmCameraSelect_Load);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button btnCancel;
        private System.Windows.Forms.Button btnOK;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.RadioButton rdoRightCam;
        private System.Windows.Forms.RadioButton rdoLeftCam;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.RadioButton rdoDirection;
        private System.Windows.Forms.RadioButton rdoLength;
    }
}