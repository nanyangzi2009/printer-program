namespace PrintInterface
{
    partial class FormCalibrate
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
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.Line1 = new System.Windows.Forms.Label();
            this.Line2 = new System.Windows.Forms.Label();
            this.btnOK = new System.Windows.Forms.Button();
            this.rdoLine1 = new System.Windows.Forms.RadioButton();
            this.rdoLine2 = new System.Windows.Forms.RadioButton();
            this.txtWidth = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.btnBigRight = new System.Windows.Forms.Button();
            this.brnBigLeft = new System.Windows.Forms.Button();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.btnSmallRight = new System.Windows.Forms.Button();
            this.btnSmallLeft = new System.Windows.Forms.Button();
            this.label3 = new System.Windows.Forms.Label();
            this.btnExit = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.groupBox1.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.SuspendLayout();
            // 
            // pictureBox1
            // 
            this.pictureBox1.BackColor = System.Drawing.SystemColors.Highlight;
            this.pictureBox1.Location = new System.Drawing.Point(0, 0);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(768, 768);
            this.pictureBox1.TabIndex = 0;
            this.pictureBox1.TabStop = false;
            // 
            // Line1
            // 
            this.Line1.BackColor = System.Drawing.Color.Red;
            this.Line1.Location = new System.Drawing.Point(146, 256);
            this.Line1.Name = "Line1";
            this.Line1.Size = new System.Drawing.Size(10, 256);
            this.Line1.TabIndex = 2;
            // 
            // Line2
            // 
            this.Line2.BackColor = System.Drawing.Color.Black;
            this.Line2.Location = new System.Drawing.Point(400, 256);
            this.Line2.Name = "Line2";
            this.Line2.Size = new System.Drawing.Size(10, 256);
            this.Line2.TabIndex = 3;
            // 
            // btnOK
            // 
            this.btnOK.Font = new System.Drawing.Font("楷体", 15F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.btnOK.Location = new System.Drawing.Point(819, 604);
            this.btnOK.Name = "btnOK";
            this.btnOK.Size = new System.Drawing.Size(135, 53);
            this.btnOK.TabIndex = 4;
            this.btnOK.Text = "确定";
            this.btnOK.UseVisualStyleBackColor = true;
            this.btnOK.Click += new System.EventHandler(this.btnOK_Click);
            // 
            // rdoLine1
            // 
            this.rdoLine1.AutoSize = true;
            this.rdoLine1.Checked = true;
            this.rdoLine1.Font = new System.Drawing.Font("微软雅黑", 15F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.rdoLine1.Location = new System.Drawing.Point(831, 213);
            this.rdoLine1.Name = "rdoLine1";
            this.rdoLine1.Size = new System.Drawing.Size(130, 31);
            this.rdoLine1.TabIndex = 5;
            this.rdoLine1.TabStop = true;
            this.rdoLine1.Text = "选左边的线";
            this.rdoLine1.UseVisualStyleBackColor = true;
            this.rdoLine1.CheckedChanged += new System.EventHandler(this.rdoLine1_CheckedChanged);
            // 
            // rdoLine2
            // 
            this.rdoLine2.AutoSize = true;
            this.rdoLine2.Font = new System.Drawing.Font("微软雅黑", 15F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.rdoLine2.Location = new System.Drawing.Point(831, 250);
            this.rdoLine2.Name = "rdoLine2";
            this.rdoLine2.Size = new System.Drawing.Size(130, 31);
            this.rdoLine2.TabIndex = 6;
            this.rdoLine2.Text = "选右边的线";
            this.rdoLine2.UseVisualStyleBackColor = true;
            this.rdoLine2.CheckedChanged += new System.EventHandler(this.rdoLine2_CheckedChanged);
            // 
            // txtWidth
            // 
            this.txtWidth.Font = new System.Drawing.Font("微软雅黑", 15F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.txtWidth.Location = new System.Drawing.Point(814, 82);
            this.txtWidth.Name = "txtWidth";
            this.txtWidth.Size = new System.Drawing.Size(91, 34);
            this.txtWidth.TabIndex = 7;
            this.txtWidth.Tag = "0.2/200";
            this.txtWidth.Text = "1.00";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("微软雅黑", 15F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label1.Location = new System.Drawing.Point(809, 51);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(152, 27);
            this.label1.TabIndex = 8;
            this.label1.Text = "两线之间的宽度";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("微软雅黑", 15F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label2.Location = new System.Drawing.Point(911, 89);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(50, 27);
            this.label2.TabIndex = 9;
            this.label2.Text = "mm";
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.btnBigRight);
            this.groupBox1.Controls.Add(this.brnBigLeft);
            this.groupBox1.Font = new System.Drawing.Font("微软雅黑", 15F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.groupBox1.Location = new System.Drawing.Point(814, 311);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(147, 93);
            this.groupBox1.TabIndex = 10;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "粗调";
            // 
            // btnBigRight
            // 
            this.btnBigRight.Font = new System.Drawing.Font("微软雅黑", 21.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.btnBigRight.Location = new System.Drawing.Point(81, 33);
            this.btnBigRight.Name = "btnBigRight";
            this.btnBigRight.Size = new System.Drawing.Size(60, 50);
            this.btnBigRight.TabIndex = 1;
            this.btnBigRight.Text = "->";
            this.btnBigRight.UseVisualStyleBackColor = true;
            this.btnBigRight.Click += new System.EventHandler(this.btnBigRight_Click);
            // 
            // brnBigLeft
            // 
            this.brnBigLeft.Font = new System.Drawing.Font("微软雅黑", 21.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.brnBigLeft.Location = new System.Drawing.Point(6, 33);
            this.brnBigLeft.Name = "brnBigLeft";
            this.brnBigLeft.Size = new System.Drawing.Size(60, 50);
            this.brnBigLeft.TabIndex = 0;
            this.brnBigLeft.Text = "<-";
            this.brnBigLeft.UseVisualStyleBackColor = true;
            this.brnBigLeft.Click += new System.EventHandler(this.brnBigLeft_Click);
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.btnSmallRight);
            this.groupBox2.Controls.Add(this.btnSmallLeft);
            this.groupBox2.Font = new System.Drawing.Font("微软雅黑", 15F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.groupBox2.Location = new System.Drawing.Point(814, 410);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(147, 93);
            this.groupBox2.TabIndex = 11;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "细调";
            // 
            // btnSmallRight
            // 
            this.btnSmallRight.Font = new System.Drawing.Font("微软雅黑", 21.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.btnSmallRight.Location = new System.Drawing.Point(81, 33);
            this.btnSmallRight.Name = "btnSmallRight";
            this.btnSmallRight.Size = new System.Drawing.Size(60, 50);
            this.btnSmallRight.TabIndex = 1;
            this.btnSmallRight.Text = "->";
            this.btnSmallRight.UseVisualStyleBackColor = true;
            this.btnSmallRight.Click += new System.EventHandler(this.btnSmallRight_Click);
            // 
            // btnSmallLeft
            // 
            this.btnSmallLeft.Font = new System.Drawing.Font("微软雅黑", 21.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.btnSmallLeft.Location = new System.Drawing.Point(6, 33);
            this.btnSmallLeft.Name = "btnSmallLeft";
            this.btnSmallLeft.Size = new System.Drawing.Size(60, 50);
            this.btnSmallLeft.TabIndex = 0;
            this.btnSmallLeft.Text = "<-";
            this.btnSmallLeft.UseVisualStyleBackColor = true;
            this.btnSmallLeft.Click += new System.EventHandler(this.btnSmallLeft_Click);
            // 
            // label3
            // 
            this.label3.Font = new System.Drawing.Font("微软雅黑", 15F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label3.Location = new System.Drawing.Point(814, 144);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(155, 55);
            this.label3.TabIndex = 12;
            this.label3.Text = "请移动两线： （以外沿为准）";
            // 
            // btnExit
            // 
            this.btnExit.Font = new System.Drawing.Font("楷体", 15F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.btnExit.Location = new System.Drawing.Point(820, 674);
            this.btnExit.Name = "btnExit";
            this.btnExit.Size = new System.Drawing.Size(135, 53);
            this.btnExit.TabIndex = 13;
            this.btnExit.Text = "退出";
            this.btnExit.UseVisualStyleBackColor = true;
            this.btnExit.Click += new System.EventHandler(this.btnExit_Click);
            // 
            // FormCalibrate
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(192)))), ((int)(((byte)(255)))));
            this.ClientSize = new System.Drawing.Size(1024, 768);
            this.Controls.Add(this.btnExit);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.txtWidth);
            this.Controls.Add(this.rdoLine2);
            this.Controls.Add(this.rdoLine1);
            this.Controls.Add(this.btnOK);
            this.Controls.Add(this.Line2);
            this.Controls.Add(this.Line1);
            this.Controls.Add(this.pictureBox1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "FormCalibrate";
            this.Text = "FormCalibrate";
            this.Load += new System.EventHandler(this.FormCalibrate_Load);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.groupBox1.ResumeLayout(false);
            this.groupBox2.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        public System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.Label Line1;
        private System.Windows.Forms.Label Line2;
        private System.Windows.Forms.Button btnOK;
        private System.Windows.Forms.RadioButton rdoLine1;
        private System.Windows.Forms.RadioButton rdoLine2;
        private System.Windows.Forms.TextBox txtWidth;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Button btnBigRight;
        private System.Windows.Forms.Button brnBigLeft;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.Button btnSmallRight;
        private System.Windows.Forms.Button btnSmallLeft;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Button btnExit;
    }
}