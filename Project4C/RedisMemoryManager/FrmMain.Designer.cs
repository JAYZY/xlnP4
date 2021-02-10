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
            this.lblCameraC = new System.Windows.Forms.Label();
            this.lblCameraB = new System.Windows.Forms.Label();
            this.label10 = new System.Windows.Forms.Label();
            this.label8 = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.iInputMaxMemory)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.iInputDelImgNum)).BeginInit();
            this.groupBox1.SuspendLayout();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(34, 19);
            this.label1.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(97, 14);
            this.label1.TabIndex = 0;
            this.label1.Text = "主机内存(MB):";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(328, 19);
            this.label2.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(103, 14);
            this.label2.TabIndex = 0;
            this.label2.Text = "Redis内存(MB):";
            // 
            // lblMemory
            // 
            this.lblMemory.Location = new System.Drawing.Point(145, 19);
            this.lblMemory.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblMemory.Name = "lblMemory";
            this.lblMemory.Size = new System.Drawing.Size(175, 14);
            this.lblMemory.TabIndex = 0;
            this.lblMemory.Text = "0";
            // 
            // lblReidsMemory
            // 
            this.lblReidsMemory.Location = new System.Drawing.Point(439, 19);
            this.lblReidsMemory.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblReidsMemory.Name = "lblReidsMemory";
            this.lblReidsMemory.Size = new System.Drawing.Size(119, 14);
            this.lblReidsMemory.TabIndex = 0;
            this.lblReidsMemory.Text = "0";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(35, 56);
            this.label5.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(187, 14);
            this.label5.TabIndex = 0;
            this.label5.Text = "Redis内存限制(最大内存MB):";
            // 
            // btnSetMemLimit
            // 
            this.btnSetMemLimit.Location = new System.Drawing.Point(340, 51);
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
            this.iInputMaxMemory.Location = new System.Drawing.Point(220, 52);
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
            this.label3.Location = new System.Drawing.Point(308, 56);
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
            this.rTxtBoxInfo.Location = new System.Drawing.Point(37, 157);
            this.rTxtBoxInfo.Name = "rTxtBoxInfo";
            this.rTxtBoxInfo.Rtf = "{\\rtf1\\ansi\\ansicpg936\\deff0\\deflang1033\\deflangfe2052{\\fonttbl{\\f0\\fnil\\fcharset" +
    "134 \\\'b5\\\'c8\\\'cf\\\'df;}}\r\n\\viewkind4\\uc1\\pard\\lang2052\\b\\f0\\fs21\\par\r\n}\r\n";
            this.rTxtBoxInfo.Size = new System.Drawing.Size(581, 174);
            this.rTxtBoxInfo.TabIndex = 4;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(400, 55);
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
            this.iInputDelImgNum.Location = new System.Drawing.Point(510, 51);
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
            this.btnDelNumByOnce.Location = new System.Drawing.Point(581, 50);
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
            this.label6.Location = new System.Drawing.Point(17, 24);
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
            this.lblCameraA.Location = new System.Drawing.Point(79, 24);
            this.lblCameraA.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblCameraA.Name = "lblCameraA";
            this.lblCameraA.Size = new System.Drawing.Size(15, 14);
            this.lblCameraA.TabIndex = 0;
            this.lblCameraA.Text = "0";
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.lblCameraC);
            this.groupBox1.Controls.Add(this.lblCameraB);
            this.groupBox1.Controls.Add(this.lblCameraA);
            this.groupBox1.Controls.Add(this.label10);
            this.groupBox1.Controls.Add(this.label8);
            this.groupBox1.Controls.Add(this.label6);
            this.groupBox1.Location = new System.Drawing.Point(37, 80);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(581, 51);
            this.groupBox1.TabIndex = 5;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Redis中存储图像数量";
            // 
            // lblCameraC
            // 
            this.lblCameraC.AutoSize = true;
            this.lblCameraC.ForeColor = System.Drawing.Color.Maroon;
            this.lblCameraC.Location = new System.Drawing.Point(492, 24);
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
            this.lblCameraB.Location = new System.Drawing.Point(267, 24);
            this.lblCameraB.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblCameraB.Name = "lblCameraB";
            this.lblCameraB.Size = new System.Drawing.Size(15, 14);
            this.lblCameraB.TabIndex = 0;
            this.lblCameraB.Text = "0";
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.ForeColor = System.Drawing.Color.Maroon;
            this.label10.Location = new System.Drawing.Point(430, 24);
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
            this.label8.Location = new System.Drawing.Point(205, 24);
            this.label8.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(63, 14);
            this.label8.TabIndex = 0;
            this.label8.Text = "相机二：";
            // 
            // FrmMain
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 14F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(649, 342);
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
    }
}