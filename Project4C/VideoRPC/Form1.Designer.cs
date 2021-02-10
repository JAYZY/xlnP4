namespace VideoRPC {
    partial class Form1 {
        /// <summary>
        /// 必需的设计器变量。
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// 清理所有正在使用的资源。
        /// </summary>
        /// <param name="disposing">如果应释放托管资源，为 true；否则为 false。</param>
        protected override void Dispose(bool disposing) {
            if (disposing && (components != null)) {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows 窗体设计器生成的代码

        /// <summary>
        /// 设计器支持所需的方法 - 不要修改
        /// 使用代码编辑器修改此方法的内容。
        /// </summary>
        private void InitializeComponent() {
            this.buttonX1 = new DevComponents.DotNetBar.ButtonX();
            this.richTextBox1 = new System.Windows.Forms.RichTextBox();
            this.ipAddressInput1 = new DevComponents.Editors.IpAddressInput();
            ((System.ComponentModel.ISupportInitialize)(this.ipAddressInput1)).BeginInit();
            this.SuspendLayout();
            // 
            // buttonX1
            // 
            this.buttonX1.AccessibleRole = System.Windows.Forms.AccessibleRole.PushButton;
            this.buttonX1.ColorTable = DevComponents.DotNetBar.eButtonColor.OrangeWithBackground;
            this.buttonX1.Location = new System.Drawing.Point(292, 42);
            this.buttonX1.Name = "buttonX1";
            this.buttonX1.Size = new System.Drawing.Size(75, 23);
            this.buttonX1.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled;
            this.buttonX1.TabIndex = 0;
            this.buttonX1.Text = "打开相机";
            this.buttonX1.Click += new System.EventHandler(this.buttonX1_Click);
            // 
            // richTextBox1
            // 
            this.richTextBox1.Location = new System.Drawing.Point(67, 71);
            this.richTextBox1.Name = "richTextBox1";
            this.richTextBox1.Size = new System.Drawing.Size(486, 252);
            this.richTextBox1.TabIndex = 0;
            this.richTextBox1.Text = "";
            // 
            // ipAddressInput1
            // 
            this.ipAddressInput1.AutoOverwrite = true;
            // 
            // 
            // 
            this.ipAddressInput1.BackgroundStyle.Class = "DateTimeInputBackground";
            this.ipAddressInput1.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.ipAddressInput1.ButtonFreeText.Shortcut = DevComponents.DotNetBar.eShortcut.F2;
            this.ipAddressInput1.ButtonFreeText.Visible = true;
            this.ipAddressInput1.Location = new System.Drawing.Point(67, 42);
            this.ipAddressInput1.Name = "ipAddressInput1";
            this.ipAddressInput1.Size = new System.Drawing.Size(207, 21);
            this.ipAddressInput1.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled;
            this.ipAddressInput1.TabIndex = 0;
            this.ipAddressInput1.Value = "192.168.100.62";
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.ipAddressInput1);
            this.Controls.Add(this.richTextBox1);
            this.Controls.Add(this.buttonX1);
            this.Name = "Form1";
            this.Text = "Form1";
            ((System.ComponentModel.ISupportInitialize)(this.ipAddressInput1)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private DevComponents.DotNetBar.ButtonX buttonX1;
        private DevComponents.Editors.IpAddressInput ipAddressInput1;
        private System.Windows.Forms.RichTextBox richTextBox1;
    }
}

