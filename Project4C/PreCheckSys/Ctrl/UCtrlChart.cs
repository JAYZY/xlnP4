using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using DevComponents.DotNetBar.Charts;
using DevComponents.DotNetBar.Charts.Style;
using System.Diagnostics;
using System.Threading;

namespace PreCheckSys.Ctrl {
    public partial class UCtrlChart : UserControl {

        private ChartXy _ChartXy;
        // private System.Windows.Forms.Timer _ChartTimer;
        private double _StartMilliseconds;
        private List<ChartSeries> _DiskSeries;
        private ChartControl _ChartControl;
        
        private PerformanceCounter _mainPerformanceCouter;

        public bool isDisplay { get; private set; }


        #region 创建单实例对象
        private static UCtrlChart _uCtrlChart;
        private static object _obj = new object();
        public static UCtrlChart GetInstance() {
            if (_uCtrlChart == null) {
                lock (_obj) {
                    if (_uCtrlChart == null) {
                        _uCtrlChart = new UCtrlChart();
                    }
                }
            }
            return _uCtrlChart;
        }
        private UCtrlChart() {
            InitializeComponent();
            _DiskSeries = new List<ChartSeries>();
            SetupChart();
        }
        #endregion

        private PerformanceCounter GetPerformance(string counterName, string diskName) {
            return new PerformanceCounter("LogicalDisk", counterName, diskName);
        }
        private void SetupChart() {
            _ChartControl = new ChartControl();
            SetupScrollBarStyles();
            _ChartControl.Dock = DockStyle.Fill;
            this.Controls.Add(_ChartControl);
            AddChart();
            SetupTimer();
        }

        #region style
        /// <summary>
        /// Sets up the scrollbar styles.
        /// </summary>
        private void SetupScrollBarStyles() {
            ScrollBarVisualStyle moStyle = _ChartControl.DefaultVisualStyles.HScrollBarVisualStyles.MouseOver;
            moStyle.ArrowBackground = new Background(Color.AliceBlue);
            moStyle.ThumbBackground = new Background(Color.AliceBlue);

            ScrollBarVisualStyle smoStyle = _ChartControl.DefaultVisualStyles.HScrollBarVisualStyles.SelectedMouseOver;
            smoStyle.ArrowBackground = new Background(Color.White);
            smoStyle.ThumbBackground = new Background(Color.White);

            moStyle = _ChartControl.DefaultVisualStyles.VScrollBarVisualStyles.MouseOver;
            moStyle.ArrowBackground = new Background(Color.AliceBlue);
            moStyle.ThumbBackground = new Background(Color.AliceBlue);

            smoStyle = _ChartControl.DefaultVisualStyles.VScrollBarVisualStyles.SelectedMouseOver;
            smoStyle.ArrowBackground = new Background(Color.White);
            smoStyle.ThumbBackground = new Background(Color.White);
        }

        private void AddChart() {
            ChartXy chartXy = new ChartXy();
            _ChartXy = chartXy;
            chartXy.Name = "E盘读写速度";
            chartXy.MinContentSize = new Size(300, 300);
            chartXy.ChartLineDisplayMode =
                ChartLineDisplayMode.DisplayLine | ChartLineDisplayMode.DisplayUnsorted;
            chartXy.ChartLineAreaDisplayMode = ChartLineAreaDisplayMode.DisplayLine;
            // Setup various styles for the chart...
            SetupChartStyle(chartXy);
            SetupContainerStyle(chartXy);
            SetupChartAxes(chartXy);
            SetupChartLegend(chartXy);
            // Add associated series.

            AddSeries("主磁盘速率");
            _mainPerformanceCouter = GetPerformance("Disk Writes/sec", "C:");

            // And finally, add the chart to the ChartContainers
            // collection of chart elements.
            _ChartControl.ChartPanel.ChartContainers.Clear();
            _ChartControl.ChartPanel.ChartContainers.Add(chartXy);
        }
        //设置chart样式
        private void SetupChartStyle(ChartXy chartXy) {
            ChartXyVisualStyle xystyle = chartXy.ChartVisualStyle;
            xystyle.Background = new Background(Color.White);
            xystyle.BorderThickness = new Thickness(1);
            xystyle.BorderColor = new BorderColor(Color.Black);
            xystyle.Padding = new DevComponents.DotNetBar.Charts.Style.Padding(4);
        }
        /// <summary>
        /// Sets up the chart's container style.
        /// </summary>
        /// <param name="chartXy"></param>
        private void SetupContainerStyle(ChartXy chartXy) {
            ContainerVisualStyle dstyle = chartXy.ContainerVisualStyles.Default;
            dstyle.Background = new Background(Color.White);
            dstyle.BorderColor = new BorderColor(Color.DimGray);
            dstyle.BorderThickness = new Thickness(1);
            dstyle.DropShadow.Enabled = Tbool.True;
            dstyle.Padding = new DevComponents.DotNetBar.Charts.Style.Padding(6);
        }
        /// <summary>
        /// Sets up the Legend style.
        /// </summary>
        /// <param name="chartXy"></param>
        private void SetupChartLegend(ChartXy chartXy) {
            ChartLegend legend = chartXy.Legend;

            legend.Placement = Placement.Outside;
            legend.Alignment = Alignment.TopCenter;
            legend.AlignVerticalItems = true;
            legend.Direction = Direction.LeftToRight;

            ChartLegendVisualStyle lstyle = legend.ChartLegendVisualStyles.Default;

            lstyle.BorderThickness = new Thickness(1);
            lstyle.BorderColor = new BorderColor(Color.Crimson);

            lstyle.Margin = new DevComponents.DotNetBar.Charts.Style.Padding(8);
            lstyle.Padding = new DevComponents.DotNetBar.Charts.Style.Padding(4);

            lstyle.Background = new Background(Color.FromArgb(200, Color.White));
        }
        #endregion

        /// <summary>
        /// Sets up the chart axes.
        /// </summary>
        /// <param name="chartXy"></param>
        private void SetupChartAxes(ChartXy chartXy) {
            // X Axis
            ChartAxis axis = chartXy.AxisX;
            axis.MinorTickmarks.TickmarkCount = 0;
            axis.AxisMargins = 0;
            axis.GridSpacing = 1;
            axis.MajorGridLines.GridLinesVisualStyle.LineColor = Color.Gainsboro;
            axis.MinorGridLines.GridLinesVisualStyle.LineColor = Color.WhiteSmoke;

            // Y Axis
            axis = chartXy.AxisY;
            axis.AxisAlignment = AxisAlignment.Far;
            axis.MinorTickmarks.TickmarkCount = 0;
            axis.GridSpacing = 50;
            axis.MajorGridLines.GridLinesVisualStyle.LineColor = Color.Gainsboro;
            axis.MinorGridLines.GridLinesVisualStyle.LineColor = Color.WhiteSmoke;

            // Display the alternate background.

            axis.ChartAxisVisualStyle.AlternateBackground = new Background(Color.FromArgb(250, 250, 250));
            axis.UseAlternateBackground = true;
        }


        private void AddSeries(string seriesName) {
            ChartXy chartXy = _ChartXy;
            ChartSeries newSeries = new ChartSeries(seriesName, SeriesType.Line);
            RegressionLine rl = new RegressionLine("RegLine");
            rl.ShowInLegend = false;
            rl.Visible = false;//cbxShowRegLines.Checked;
            newSeries.ChartIndicators.Add(rl);
            chartXy.ChartSeries.Add(newSeries);
            _DiskSeries.Add(newSeries);
        }



        public void StartDisplay() {
            if (isDisplay) return;
            isDisplay = true;
            new Thread(ShowDiskInfo).Start();
        }
        public void StopDisplay() {
            if (!isDisplay) return;
            isDisplay = false;
        }

        private void SetupTimer() {
            //_ChartTimer = new System.Windows.Forms.Timer();
            _StartMilliseconds = DateTime.Now.TimeOfDay.TotalMilliseconds;
            // _ChartTimer.Interval = 1000;
            // _ChartTimer.Tick += ChartTimer_Tick;
        }
        /// <summary>
        /// Handles data refresh of old and new data.
        /// </summary>
        private void ShowDiskInfo() {
            while (isDisplay) {
                double msecs = DateTime.Now.TimeOfDay.TotalMilliseconds - _StartMilliseconds;
                double msecs2 = Math.Floor(msecs) / 1000;               
                int TimePeriod = 20;
                double xsecs = msecs2 - TimePeriod;
                foreach (ChartSeries series in _DiskSeries) {

                    SeriesPoint[] seriesPoints = new SeriesPoint[TimePeriod];
                    // for (int i = 0; i < TimePeriod; i++) {
                    float value = _mainPerformanceCouter.NextValue();
                    // seriesPoints[i] = new SeriesPoint(msecs2, value);
                    //lblDiskPrec.Text = value + "%";
                    Thread.Sleep(250);
                    msecs2 += .001;
                    series.SeriesPoints.Add(new SeriesPoint(msecs2, value));
                    if (series.SeriesPoints.Count > TimePeriod) {
                        series.SeriesPoints.RemoveAt(0);
                    }
                }
            }

            //int n = 0;
            //foreach (SeriesPoint point in _MainSeries.SeriesPoints) {
            //    if (((double)point.ValueX) < xsecs)
            //        n++;
            //}
            //if (n > _MainSeries.SeriesPoints.Count)
            //    n = _MainSeries.SeriesPoints.Count - 1;

            //if (n > 0)
            //    _MainSeries.SeriesPoints.RemoveRange(0, n);

            //SeriesPointCollection spc = _MainSeries.SeriesPoints;

            //double d = (double)spc[0].ValueX;
            //double d2 = (double)spc[spc.Count - 1].ValueX;

            //_ChartXy.AxisX.MinValue = Math.Max(0, d);
            //_ChartXy.AxisX.MaxValue = d2;

        }



        /// <summary>
        /// Update series trend lines.
        /// </summary>
        /// <param name="minValue"></param>
        /// <param name="maxValue"></param>
        private void UpdateTrendLines(double minValue, double maxValue) {
            //if (cbxShowTrendLines.Checked == true)
            //{
            //    foreach (ChartSeries series in _ChartXy.ChartSeries)
            //    {
            //        double lastValue = minValue;

            //        minValue = (int)minValue;

            //        for (int i = series.ChartIndicators.Count - 1; i >= 0; i--)
            //        {
            //            TrendLine trend = series.ChartIndicators[i] as TrendLine;

            //            if (trend != null)
            //            {
            //                double xvalue = (double)trend.ValueX2;

            //                if (xvalue > lastValue)
            //                    lastValue = xvalue;

            //                if ((double)trend.ValueX1 < minValue)
            //                    series.ChartIndicators.RemoveAt(i);
            //            }
            //        }

            //        lastValue = (double)((int)(lastValue * 2)) / 2;

            //        for (double d = lastValue; d < maxValue - .5; d += .5)
            //        {
            //            TrendLine tl = new TrendLine();

            //            tl.ShowInLegend = false;

            //            tl.TrendLineVisualStyle.LinePattern = LinePattern.DashDot;

            //            tl.ValueX1 = d;
            //            tl.ValueX2 = d + .5;

            //            series.ChartIndicators.Add(tl);
            //        }
            //    }
            //}
        }



    }
}
