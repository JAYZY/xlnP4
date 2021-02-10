namespace PreCheckSys.Ctrl {
    partial class UCtrlDiskIOInfo {
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
            DevComponents.Instrumentation.GaugeCircularScale gaugeCircularScale1 = new DevComponents.Instrumentation.GaugeCircularScale();
            DevComponents.Instrumentation.GradientFillColor gradientFillColor1 = new DevComponents.Instrumentation.GradientFillColor();
            DevComponents.Instrumentation.GaugePointer gaugePointer1 = new DevComponents.Instrumentation.GaugePointer();
            DevComponents.Instrumentation.GaugeSection gaugeSection1 = new DevComponents.Instrumentation.GaugeSection();
            DevComponents.Instrumentation.GradientFillColor gradientFillColor2 = new DevComponents.Instrumentation.GradientFillColor();
            DevComponents.Instrumentation.GradientFillColor gradientFillColor3 = new DevComponents.Instrumentation.GradientFillColor();
            DevComponents.Instrumentation.GaugeText gaugeText1 = new DevComponents.Instrumentation.GaugeText();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(UCtrlDiskIOInfo));
            DevComponents.Instrumentation.GaugeText gaugeText2 = new DevComponents.Instrumentation.GaugeText();
            DevComponents.Instrumentation.GaugeText gaugeText3 = new DevComponents.Instrumentation.GaugeText();
            DevComponents.Instrumentation.GaugeText gaugeText4 = new DevComponents.Instrumentation.GaugeText();
            DevComponents.Instrumentation.GaugeText gaugeText5 = new DevComponents.Instrumentation.GaugeText();
            this.gaugeCtrlDiskIO = new DevComponents.Instrumentation.GaugeControl();
            ((System.ComponentModel.ISupportInitialize)(this.gaugeCtrlDiskIO)).BeginInit();
            this.SuspendLayout();
            // 
            // gaugeCtrlDiskIO
            // 
            this.gaugeCtrlDiskIO.BackColor = System.Drawing.Color.Transparent;
            gaugeCircularScale1.BorderColor = System.Drawing.Color.White;
            gaugeCircularScale1.Labels.Layout.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            gaugeCircularScale1.Labels.Layout.ForeColor = System.Drawing.Color.White;
            gradientFillColor1.BorderColor = System.Drawing.Color.DimGray;
            gradientFillColor1.BorderWidth = 1;
            gradientFillColor1.Color1 = System.Drawing.Color.Yellow;
            gradientFillColor1.Color2 = System.Drawing.Color.White;
            gaugeCircularScale1.MajorTickMarks.Layout.FillColor = gradientFillColor1;
            gaugeCircularScale1.MaxPin.FillColor.BorderColor = System.Drawing.Color.DimGray;
            gaugeCircularScale1.MaxPin.FillColor.BorderWidth = 1;
            gaugeCircularScale1.MaxPin.FillColor.Color1 = System.Drawing.Color.Aqua;
            gaugeCircularScale1.MaxPin.FillColor.Color2 = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            gaugeCircularScale1.MaxPin.FillColor.GradientAngle = 0;
            gaugeCircularScale1.MaxPin.Name = "MaxPin";
            gaugeCircularScale1.MaxPin.Style = DevComponents.Instrumentation.GaugeMarkerStyle.Star7;
            gaugeCircularScale1.MinorTickMarks.Visible = false;
            gaugeCircularScale1.MinPin.FillColor.BorderColor = System.Drawing.Color.DimGray;
            gaugeCircularScale1.MinPin.FillColor.BorderWidth = 1;
            gaugeCircularScale1.MinPin.FillColor.Color1 = System.Drawing.Color.Lime;
            gaugeCircularScale1.MinPin.FillColor.Color2 = System.Drawing.Color.Red;
            gaugeCircularScale1.MinPin.Name = "MinPin";
            gaugeCircularScale1.Name = "Scale2";
            gaugePointer1.BarStyle = DevComponents.Instrumentation.BarPointerStyle.Pointed;
            gaugePointer1.CapFillColor.BorderColor = System.Drawing.Color.White;
            gaugePointer1.CapFillColor.BorderWidth = 1;
            gaugePointer1.CapFillColor.Color1 = System.Drawing.Color.WhiteSmoke;
            gaugePointer1.CapFillColor.Color2 = System.Drawing.Color.White;
            gaugePointer1.CapStyle = DevComponents.Instrumentation.NeedlePointerCapStyle.Style1;
            gaugePointer1.CapWidth = 0.1F;
            gaugePointer1.FillColor.BorderColor = System.Drawing.Color.DimGray;
            gaugePointer1.FillColor.BorderWidth = 1;
            gaugePointer1.FillColor.Color1 = System.Drawing.Color.WhiteSmoke;
            gaugePointer1.FillColor.Color2 = System.Drawing.Color.Blue;
            gaugePointer1.MarkerStyle = DevComponents.Instrumentation.GaugeMarkerStyle.Wedge;
            gaugePointer1.Name = "Pointer1";
            gaugePointer1.Style = DevComponents.Instrumentation.PointerStyle.Needle;
            gaugePointer1.ThermoBackColor.BorderColor = System.Drawing.Color.Black;
            gaugePointer1.ThermoBackColor.BorderWidth = 1;
            gaugePointer1.ThermoBackColor.Color1 = System.Drawing.Color.FromArgb(((int)(((byte)(100)))), ((int)(((byte)(60)))), ((int)(((byte)(60)))), ((int)(((byte)(60)))));
            gaugePointer1.Value = 0D;
            gaugeCircularScale1.Pointers.AddRange(new DevComponents.Instrumentation.GaugePointer[] {
            gaugePointer1});
            gaugeSection1.FillColor.Color1 = System.Drawing.Color.DeepSkyBlue;
            gaugeSection1.FillColor.Color2 = System.Drawing.Color.Orange;
            gaugeSection1.Name = "Section1";
            gaugeCircularScale1.Sections.AddRange(new DevComponents.Instrumentation.GaugeSection[] {
            gaugeSection1});
            gaugeCircularScale1.StartAngle = 135F;
            gaugeCircularScale1.SweepAngle = 270F;
            gaugeCircularScale1.Width = 0.098F;
            this.gaugeCtrlDiskIO.CircularScales.AddRange(new DevComponents.Instrumentation.GaugeCircularScale[] {
            gaugeCircularScale1});
            this.gaugeCtrlDiskIO.Cursor = System.Windows.Forms.Cursors.Default;
            this.gaugeCtrlDiskIO.Dock = System.Windows.Forms.DockStyle.Fill;
            this.gaugeCtrlDiskIO.ForeColor = System.Drawing.Color.Transparent;
            gradientFillColor2.Color1 = System.Drawing.Color.Gainsboro;
            gradientFillColor2.Color2 = System.Drawing.Color.DarkGray;
            this.gaugeCtrlDiskIO.Frame.BackColor = gradientFillColor2;
            gradientFillColor3.BorderColor = System.Drawing.Color.Gainsboro;
            gradientFillColor3.BorderWidth = 1;
            gradientFillColor3.Color1 = System.Drawing.Color.White;
            gradientFillColor3.Color2 = System.Drawing.Color.DimGray;
            this.gaugeCtrlDiskIO.Frame.FrameColor = gradientFillColor3;
            this.gaugeCtrlDiskIO.Frame.RoundRectangleArc = 0.442F;
            gaugeText1.BackColor.BorderColor = System.Drawing.Color.Black;
            gaugeText1.Font = new System.Drawing.Font("Microsoft YaHei UI", 18F);
            gaugeText1.ForeColor = System.Drawing.Color.White;
            gaugeText1.Location = ((System.Drawing.PointF)(resources.GetObject("gaugeText1.Location")));
            gaugeText1.Name = "Text1";
            gaugeText1.Size = new System.Drawing.SizeF(0.3F, 0.2F);
            gaugeText1.Text = "活动时间";
            gaugeText1.Tooltip = "活动时间";
            gaugeText2.BackColor.BorderColor = System.Drawing.Color.Black;
            gaugeText2.Font = new System.Drawing.Font("Microsoft YaHei UI", 24F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            gaugeText2.ForeColor = System.Drawing.Color.White;
            gaugeText2.Location = ((System.Drawing.PointF)(resources.GetObject("gaugeText2.Location")));
            gaugeText2.Name = "TxtTimeTip";
            gaugeText2.Size = new System.Drawing.SizeF(0.5F, 0.2F);
            gaugeText2.Text = "27.8KB/秒";
            gaugeText3.BackColor.BorderColor = System.Drawing.Color.Black;
            gaugeText3.Font = new System.Drawing.Font("Microsoft YaHei UI", 24.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            gaugeText3.ForeColor = System.Drawing.Color.White;
            gaugeText3.Location = ((System.Drawing.PointF)(resources.GetObject("gaugeText3.Location")));
            gaugeText3.Name = "Text2";
            gaugeText3.Size = new System.Drawing.SizeF(0.5F, 0.2F);
            gaugeText3.Text = "写入速度:";
            gaugeText4.BackColor.BorderColor = System.Drawing.Color.Black;
            gaugeText4.Font = new System.Drawing.Font("Microsoft YaHei UI", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Millimeter);
            gaugeText4.ForeColor = System.Drawing.Color.White;
            gaugeText4.Location = ((System.Drawing.PointF)(resources.GetObject("gaugeText4.Location")));
            gaugeText4.Name = "txtWriteInfoTip";
            gaugeText4.Size = new System.Drawing.SizeF(0.8F, 0.2F);
            gaugeText4.Text = "27.8KB/秒";
            gaugeText4.TextAlignment = DevComponents.Instrumentation.TextAlignment.MiddleLeft;
            gaugeText5.BackColor.BorderColor = System.Drawing.Color.Black;
            gaugeText5.Font = new System.Drawing.Font("Microsoft YaHei UI", 36F);
            gaugeText5.ForeColor = System.Drawing.Color.White;
            gaugeText5.Location = ((System.Drawing.PointF)(resources.GetObject("gaugeText5.Location")));
            gaugeText5.Name = "Text3";
            gaugeText5.Size = new System.Drawing.SizeF(0.8F, 0.2F);
            gaugeText5.Text = "";
            this.gaugeCtrlDiskIO.GaugeItems.AddRange(new DevComponents.Instrumentation.GaugeItem[] {
            gaugeText1,
            gaugeText2,
            gaugeText3,
            gaugeText4,
            gaugeText5});
            this.gaugeCtrlDiskIO.Location = new System.Drawing.Point(0, 0);
            this.gaugeCtrlDiskIO.Name = "gaugeCtrlDiskIO";
            this.gaugeCtrlDiskIO.Size = new System.Drawing.Size(270, 285);
            this.gaugeCtrlDiskIO.TabIndex = 31;
            this.gaugeCtrlDiskIO.Text = "gaugeControl1";
            // 
            // UCtrlDiskIOInfo
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.Transparent;
            this.Controls.Add(this.gaugeCtrlDiskIO);
            this.Name = "UCtrlDiskIOInfo";
            this.Size = new System.Drawing.Size(270, 285);
            ((System.ComponentModel.ISupportInitialize)(this.gaugeCtrlDiskIO)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private DevComponents.Instrumentation.GaugeControl gaugeCtrlDiskIO;
    }
}
