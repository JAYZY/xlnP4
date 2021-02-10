namespace PreCheckSys.UI {
    partial class DialogTaskTip {
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
            this.circularProgress1 = new DevComponents.DotNetBar.Controls.CircularProgress();
            this.lblTip = new DevComponents.DotNetBar.LabelX();
            this.timer1 = new System.Windows.Forms.Timer();
            this.SuspendLayout();
            // 
            // circularProgress1
            // 
            // 
            // 
            // 
            this.circularProgress1.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.circularProgress1.Location = new System.Drawing.Point(12, 20);
            this.circularProgress1.Name = "circularProgress1";
            this.circularProgress1.ProgressBarType = DevComponents.DotNetBar.eCircularProgressType.Spoke;
            this.circularProgress1.ProgressColor = System.Drawing.Color.CornflowerBlue;
            this.circularProgress1.Size = new System.Drawing.Size(80, 69);
            this.circularProgress1.Style = DevComponents.DotNetBar.eDotNetBarStyle.OfficeXP;
            this.circularProgress1.TabIndex = 0;
            // 
            // lblTip
            // 
            this.lblTip.AutoSize = true;
            // 
            // 
            // 
            this.lblTip.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.lblTip.Font = new System.Drawing.Font("微软雅黑", 10F);
            this.lblTip.ForeColor = System.Drawing.Color.Black;
            this.lblTip.Location = new System.Drawing.Point(98, 43);
            this.lblTip.Name = "lblTip";
            this.lblTip.Size = new System.Drawing.Size(86, 22);
            this.lblTip.TabIndex = 1;
            this.lblTip.Text = "数据加载中...";
            // 
            // timer1
            // 
            this.timer1.Tick += new System.EventHandler(this.timer1_Tick);
            // 
            // DialogTaskTip
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(294, 109);
            this.ControlBox = false;
            this.Controls.Add(this.circularProgress1);
            this.Controls.Add(this.lblTip);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Name = "DialogTaskTip";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Shown += new System.EventHandler(this.DialogTaskTip_Shown);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private DevComponents.DotNetBar.Controls.CircularProgress circularProgress1;
        private DevComponents.DotNetBar.LabelX lblTip;
        private System.Windows.Forms.Timer timer1;
    }
}