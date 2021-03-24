namespace RedisMemoryManager {
    partial class FrmMain {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing) {
            if (disposing && (components != null)) {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent() {
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FrmMain));
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.lblMemory = new System.Windows.Forms.Label();
            this.lblReidsMemory = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.btnSetMemLimit = new System.Windows.Forms.Button();
            this.iInputMaxMemory = new DevComponents.Editors.IntegerInput();
            this.label3 = new System.Windows.Forms.Label();
            this.rTxtBoxInfo = new DevComponents.DotNetBar.Controls.RichTextBoxEx();
            this.label4 = new System.Windows.Forms.Label();
            this.iInputDelImgNum = new DevComponents.Editors.IntegerInput();
            this.btnDelNumByOnce = new System.Windows.Forms.Button();
            this.toolTip1 = new System.Windows.Forms.ToolTip(this.components);
            this.label6 = new System.Windows.Forms.Label();
            this.lblCameraA = new System.Windows.Forms.Label();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.lblCameraD = new System.Windows.Forms.Label();
            this.lblCameraC = new System.Windows.Forms.Label();
            this.lblCameraB = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.label10 = new System.Windows.Forms.Label();
            this.label8 = new System.Windows.Forms.Label();
            this.label9 = new System.Windows.Forms.Label();
            this.lblDelImgNum = new System.Windows.Forms.Label();
            this.label11 = new System.Windows.Forms.Label();
            this.label12 = new System.Windows.Forms.Label();
            this.checkBox1 = new System.Windows.Forms.CheckBox();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.button1 = new System.Windows.Forms.Button();
            this.llblDataPath = new System.Windows.Forms.LinkLabel();
            this.lblTaskInfo = new DevComponents.DotNetBar.LabelX();
            ((System.ComponentModel.ISupportInitialize)(this.iInputMaxMemory)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.iInputDelImgNum)).BeginInit();
            this.groupBox1.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(34, 98);
            this.label1.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(97, 14);
            this.label1.TabIndex = 0;
            this.label1.Text = "主机内存(MB):";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(328, 98);
            this.label2.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(103, 14);
            this.label2.TabIndex = 0;
            this.label2.Text = "Redis内存(MB):";
            // 
            // lblMemory
            // 
            this.lblMemory.Location = new System.Drawing.Point(145, 98);
            this.lblMemory.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblMemory.Name = "lblMemory";
            this.lblMemory.Size = new System.Drawing.Size(175, 14);
            this.lblMemory.TabIndex = 0;
            this.lblMemory.Text = "0";
            // 
            // lblReidsMemory
            // 
            this.lblReidsMemory.Location = new System.Drawing.Point(439, 98);
            this.lblReidsMemory.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblReidsMemory.Name = "lblReidsMemory";
            this.lblReidsMemory.Size = new System.Drawing.Size(119, 14);
            this.lblReidsMemory.TabIndex = 0;
            this.lblReidsMemory.Text = "0";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(34, 123);
            this.label5.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(187, 14);
            this.label5.TabIndex = 0;
            this.label5.Text = "Redis内存限制(最大内存MB):";
            // 
            // btnSetMemLimit
            // 
            this.btnSetMemLimit.Location = new System.Drawing.Point(339, 118);
            this.btnSetMemLimit.Name = "btnSetMemLimit";
            this.btnSetMemLimit.Size = new System.Drawing.Size(55, 23);
            this.btnSetMemLimit.TabIndex = 2;
            this.btnSetMemLimit.Text = "设置";
            this.btnSetMemLimit.UseVisualStyleBackColor = true;
            this.btnSetMemLimit.Click += new System.EventHandler(this.btnSetMemLimit_Click);
            // 
            // iInputMaxMemory
            // 
            // 
            // 
            // 
            this.iInputMaxMemory.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.iInputMaxMemory.ButtonFreeText.Shortcut = DevComponents.DotNetBar.eShortcut.F2;
            this.iInputMaxMemory.Location = new System.Drawing.Point(219, 119);
            this.iInputMaxMemory.MinValue = 1024;
            this.iInputMaxMemory.Name = "iInputMaxMemory";
            this.iInputMaxMemory.ShowUpDown = true;
            this.iInputMaxMemory.Size = new System.Drawing.Size(85, 22);
            this.iInputMaxMemory.TabIndex = 3;
            this.iInputMaxMemory.Value = 102400;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(307, 123);
            this.label3.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(28, 14);
            this.label3.TabIndex = 0;
            this.label3.Text = "MB";
            // 
            // rTxtBoxInfo
            // 
            // 
            // 
            // 
            this.rTxtBoxInfo.BackgroundStyle.Class = "RichTextBoxBorder";
            this.rTxtBoxInfo.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.rTxtBoxInfo.Location = new System.Drawing.Point(37, 219);
            this.rTxtBoxInfo.Name = "rTxtBoxInfo";
            this.rTxtBoxInfo.Rtf = "{\\rtf1\\ansi\\ansicpg936\\deff0\\deflang1033\\deflangfe2052{\\fonttbl{\\f0\\fnil\\fcharset" +
    "134 \\\'b5\\\'c8\\\'cf\\\'df;}}\r\n\\viewkind4\\uc1\\pard\\lang2052\\b\\f0\\fs21\\par\r\n}\r\n";
            this.rTxtBoxInfo.Size = new System.Drawing.Size(581, 194);
            this.rTxtBoxInfo.TabIndex = 4;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(399, 122);
            this.label4.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(108, 14);
            this.label4.TabIndex = 0;
            this.label4.Text = "批量删除图像数:";
            // 
            // iInputDelImgNum
            // 
            // 
            // 
            // 
            this.iInputDelImgNum.BackgroundStyle.Class = "DateTimeInputBackground";
            this.iInputDelImgNum.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.iInputDelImgNum.ButtonFreeText.Shortcut = DevComponents.DotNetBar.eShortcut.F2;
            this.iInputDelImgNum.Location = new System.Drawing.Point(509, 118);
            this.iInputDelImgNum.MinValue = 50;
            this.iInputDelImgNum.Name = "iInputDelImgNum";
            this.iInputDelImgNum.ShowUpDown = true;
            this.iInputDelImgNum.Size = new System.Drawing.Size(67, 22);
            this.iInputDelImgNum.TabIndex = 3;
            this.toolTip1.SetToolTip(this.iInputDelImgNum, "Redis中一次删除的图像数量，即批处理数量，数量设置过大有可能导致Redis卡顿。");
            this.iInputDelImgNum.Value = 100;
            // 
            // btnDelNumByOnce
            // 
            this.btnDelNumByOnce.Location = new System.Drawing.Point(580, 117);
            this.btnDelNumByOnce.Name = "btnDelNumByOnce";
            this.btnDelNumByOnce.Size = new System.Drawing.Size(55, 23);
            this.btnDelNumByOnce.TabIndex = 2;
            this.btnDelNumByOnce.Text = "设置";
            this.btnDelNumByOnce.UseVisualStyleBackColor = true;
            this.btnDelNumByOnce.Click += new System.EventHandler(this.btnDelNumByOnce_Click);
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.ForeColor = System.Drawing.Color.Maroon;
            this.label6.Location = new System.Drawing.Point(8, 24);
            this.label6.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(63, 14);
            this.label6.TabIndex = 0;
            this.label6.Text = "相机一：";
            // 
            // lblCameraA
            // 
            this.lblCameraA.AutoSize = true;
            this.lblCameraA.ForeColor = System.Drawing.Color.Maroon;
            this.lblCameraA.Location = new System.Drawing.Point(65, 24);
            this.lblCameraA.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblCameraA.Name = "lblCameraA";
            this.lblCameraA.Size = new System.Drawing.Size(15, 14);
            this.lblCameraA.TabIndex = 0;
            this.lblCameraA.Text = "0";
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.lblCameraD);
            this.groupBox1.Controls.Add(this.lblCameraC);
            this.groupBox1.Controls.Add(this.lblCameraB);
            this.groupBox1.Controls.Add(this.label12);
            this.groupBox1.Controls.Add(this.lblDelImgNum);
            this.groupBox1.Controls.Add(this.lblCameraA);
            this.groupBox1.Controls.Add(this.label7);
            this.groupBox1.Controls.Add(this.label10);
            this.groupBox1.Controls.Add(this.label11);
            this.groupBox1.Controls.Add(this.label9);
            this.groupBox1.Controls.Add(this.label8);
            this.groupBox1.Controls.Add(this.label6);
            this.groupBox1.Location = new System.Drawing.Point(36, 147);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(581, 68);
            this.groupBox1.TabIndex = 5;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Redis中存储图像数量";
            // 
            // lblCameraD
            // 
            this.lblCameraD.AutoSize = true;
            this.lblCameraD.ForeColor = System.Drawing.Color.Maroon;
            this.lblCameraD.Location = new System.Drawing.Point(530, 24);
            this.lblCameraD.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblCameraD.Name = "lblCameraD";
            this.lblCameraD.Size = new System.Drawing.Size(15, 14);
            this.lblCameraD.TabIndex = 0;
            this.lblCameraD.Text = "0";
            // 
            // lblCameraC
            // 
            this.lblCameraC.AutoSize = true;
            this.lblCameraC.ForeColor = System.Drawing.Color.Maroon;
            this.lblCameraC.Location = new System.Drawing.Point(375, 24);
            this.lblCameraC.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblCameraC.Name = "lblCameraC";
            this.lblCameraC.Size = new System.Drawing.Size(15, 14);
            this.lblCameraC.TabIndex = 0;
            this.lblCameraC.Text = "0";
            // 
            // lblCameraB
            // 
            this.lblCameraB.AutoSize = true;
            this.lblCameraB.ForeColor = System.Drawing.Color.Maroon;
            this.lblCameraB.Location = new System.Drawing.Point(219, 24);
            this.lblCameraB.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblCameraB.Name = "lblCameraB";
            this.lblCameraB.Size = new System.Drawing.Size(15, 14);
            this.lblCameraB.TabIndex = 0;
            this.lblCameraB.Text = "0";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.ForeColor = System.Drawing.Color.Maroon;
            this.label7.Location = new System.Drawing.Point(476, 24);
            this.label7.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(63, 14);
            this.label7.TabIndex = 0;
            this.label7.Text = "相机四：";
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.ForeColor = System.Drawing.Color.Maroon;
            this.label10.Location = new System.Drawing.Point(320, 24);
            this.label10.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(63, 14);
            this.label10.TabIndex = 0;
            this.label10.Text = "相机三：";
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.ForeColor = System.Drawing.Color.Maroon;
            this.label8.Location = new System.Drawing.Point(164, 24);
            this.label8.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(63, 14);
            this.label8.TabIndex = 0;
            this.label8.Text = "相机二：";
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.ForeColor = System.Drawing.Color.DeepSkyBlue;
            this.label9.Location = new System.Drawing.Point(8, 51);
            this.label9.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(133, 14);
            this.label9.TabIndex = 0;
            this.label9.Text = "删除的总图像数量：";
            // 
            // lblDelImgNum
            // 
            this.lblDelImgNum.AutoSize = true;
            this.lblDelImgNum.ForeColor = System.Drawing.Color.DeepSkyBlue;
            this.lblDelImgNum.Location = new System.Drawing.Point(140, 51);
            this.lblDelImgNum.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblDelImgNum.Name = "lblDelImgNum";
            this.lblDelImgNum.Size = new System.Drawing.Size(15, 14);
            this.lblDelImgNum.TabIndex = 0;
            this.lblDelImgNum.Text = "0";
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.ForeColor = System.Drawing.Color.DeepSkyBlue;
            this.label11.Location = new System.Drawing.Point(320, 51);
            this.label11.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(119, 14);
            this.label11.TabIndex = 0;
            this.label11.Text = "存储总图像数量：";
            // 
            // label12
            // 
            this.label12.AutoSize = true;
            this.label12.ForeColor = System.Drawing.Color.DeepSkyBlue;
            this.label12.Location = new System.Drawing.Point(452, 51);
            this.label12.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label12.Name = "label12";
            this.label12.Size = new System.Drawing.Size(15, 14);
            this.label12.TabIndex = 0;
            this.label12.Text = "0";
            // 
            // checkBox1
            // 
            this.checkBox1.AutoSize = true;
            this.checkBox1.Location = new System.Drawing.Point(643, 120);
            this.checkBox1.Name = "checkBox1";
            this.checkBox1.Size = new System.Drawing.Size(82, 18);
            this.checkBox1.TabIndex = 6;
            this.checkBox1.Text = "存储数据";
            this.checkBox1.UseVisualStyleBackColor = true;
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.llblDataPath);
            this.groupBox2.Controls.Add(this.button1);
            this.groupBox2.Location = new System.Drawing.Point(623, 147);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(228, 68);
            this.groupBox2.TabIndex = 7;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "数据存储参数";
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(6, 20);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(83, 23);
            this.button1.TabIndex = 2;
            this.button1.Text = "存储路径";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.btnDelNumByOnce_Click);
            // 
            // llblDataPath
            // 
            this.llblDataPath.AutoSize = true;
            this.llblDataPath.Location = new System.Drawing.Point(95, 24);
            this.llblDataPath.Name = "llblDataPath";
            this.llblDataPath.Size = new System.Drawing.Size(71, 14);
            this.llblDataPath.TabIndex = 3;
            this.llblDataPath.TabStop = true;
            this.llblDataPath.Text = "linkLabel1";
            // 
            // lblTaskInfo
            // 
            this.lblTaskInfo.BackColor = System.Drawing.Color.Transparent;
            // 
            // 
            // 
            this.lblTaskInfo.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.lblTaskInfo.Dock = System.Windows.Forms.DockStyle.Top;
            this.lblTaskInfo.Font = new System.Drawing.Font("Microsoft Sans Serif", 36F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblTaskInfo.ForeColor = System.Drawing.Color.ForestGreen;
            this.lblTaskInfo.Location = new System.Drawing.Point(0, 0);
            this.lblTaskInfo.Name = "lblTaskInfo";
            this.lblTaskInfo.PaddingTop = 50;
            this.lblTaskInfo.Size = new System.Drawing.Size(959, 95);
            this.lblTaskInfo.TabIndex = 32;
            this.lblTaskInfo.Text = "_ _ _  _ _  _ _ _-_ _ _";
            this.lblTaskInfo.TextAlignment = System.Drawing.StringAlignment.Center;
            // 
            // FrmMain
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 14F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(959, 425);
            this.Controls.Add(this.lblTaskInfo);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.checkBox1);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.rTxtBoxInfo);
            this.Controls.Add(this.iInputDelImgNum);
            this.Controls.Add(this.iInputMaxMemory);
            this.Controls.Add(this.btnDelNumByOnce);
            this.Controls.Add(this.btnSetMemLimit);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.lblReidsMemory);
            this.Controls.Add(this.lblMemory);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Font = new System.Drawing.Font("等线", 10.5F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Margin = new System.Windows.Forms.Padding(4);
            this.Name = "FrmMain";
            this.Text = "Redis内存管理";
            ((System.ComponentModel.ISupportInitialize)(this.iInputMaxMemory)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.iInputDelImgNum)).EndInit();
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label lblMemory;
        private System.Windows.Forms.Label lblReidsMemory;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Button btnSetMemLimit;
        private DevComponents.Editors.IntegerInput iInputMaxMemory;
        private System.Windows.Forms.Label label3;
        private DevComponents.DotNetBar.Controls.RichTextBoxEx rTxtBoxInfo;
        private DevComponents.Editors.IntegerInput iInputDelImgNum;
        private System.Windows.Forms.ToolTip toolTip1;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Button btnDelNumByOnce;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label lblCameraA;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Label lblCameraC;
        private System.Windows.Forms.Label lblCameraB;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Label lblCameraD;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label lblDelImgNum;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.Label label12;
        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.CheckBox checkBox1;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.LinkLabel llblDataPath;
        private DevComponents.DotNetBar.LabelX lblTaskInfo;
    }
}