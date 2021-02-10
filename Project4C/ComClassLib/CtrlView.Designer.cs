namespace ComClassLib {
    partial class CtrlView {
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

        #region 组件设计器生成的代码

        /// <summary> 
        /// 设计器支持所需的方法 - 不要修改
        /// 使用代码编辑器修改此方法的内容。
        /// </summary>
        private void InitializeComponent() {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(CtrlView));
            this.imgView = new FVIL.Forms.CFviImageView();
            this.SuspendLayout();
            // 
            // imgView
            // 
            this.imgView.Display = ((FVIL.GDI.CFviDisplay)(resources.GetObject("imgView.Display")));
            this.imgView.Dock = System.Windows.Forms.DockStyle.Fill;
            this.imgView.EnableMouseGrip = true;
            this.imgView.EnableMouseWheel = false;
            this.imgView.EnableScrollBar = false;
            this.imgView.Location = new System.Drawing.Point(0, 0);
            this.imgView.Margin = new System.Windows.Forms.Padding(1);
            this.imgView.Name = "imgView";
            this.imgView.Size = new System.Drawing.Size(636, 492);
            this.imgView.TabIndex = 20;
            this.imgView.Tag = "0";
            // 
            // CtrlView
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.imgView);
            this.Name = "CtrlView";
            this.Size = new System.Drawing.Size(636, 492);
            this.ResumeLayout(false);

        }

        #endregion

        private FVIL.Forms.CFviImageView imgView;
    }
}
