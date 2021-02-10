using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Diagnostics;
using System.Threading;
using PreCheckSys.utils;

namespace PreCheckSys.Ctrl {
    public partial class UCtrlDiskIOInfo : UserControl {

        private PerformanceCounter _PerformanceCounterRumTime, _PerformanceCounterWriteRate; //性能计数器
        private bool _isWhile;
        private Thread _th;
        private string _diskName;
        public UCtrlDiskIOInfo(string diskName, string showTip) {

            InitializeComponent();
            _diskName = diskName;
            if (string.IsNullOrEmpty(_diskName))
                showTip = "无备份磁盘";
            ((DevComponents.Instrumentation.GaugeText)gaugeCtrlDiskIO.GaugeItems[4]).Text = showTip;
            ((DevComponents.Instrumentation.GaugeText)gaugeCtrlDiskIO.GaugeItems[1]).Text ="0%";
            ((DevComponents.Instrumentation.GaugeText)gaugeCtrlDiskIO.GaugeItems[3]).Text = "0KB/秒";
        }
        public void SetDiskName(string diskName, string showTip) {
            _diskName = diskName;
            ((DevComponents.Instrumentation.GaugeText)gaugeCtrlDiskIO.GaugeItems[4]).Text = showTip;
        }

        public void StartDisplay() {
            if (string.IsNullOrEmpty(_diskName))
                return;
                StopDisplay();
            _PerformanceCounterRumTime = new PerformanceCounter("LogicalDisk", "% Disk Write Time", _diskName);
            _PerformanceCounterWriteRate = new PerformanceCounter("LogicalDisk", "Disk Write Bytes/sec", _diskName);
            
            _isWhile = true;
            _th = new Thread(DisplayTh);
            _th.Start();
        }

        public void StopDisplay() {
            if (!_isWhile) {
                return;
            }
            _isWhile = false;
            _th.Abort();
            _PerformanceCounterRumTime = _PerformanceCounterWriteRate = null;
        }

        public void DisplayTh() {
            try {
                while (_isWhile) {
                    float fWriteTime = _PerformanceCounterRumTime.NextValue();
                    if (fWriteTime > 100) fWriteTime = 100;
                    gaugeCtrlDiskIO.CircularScales[0].Pointers[0].Value = fWriteTime;
                    ((DevComponents.Instrumentation.GaugeText)gaugeCtrlDiskIO.GaugeItems[1]).Text = fWriteTime.ToString("F2") + "%";
                    ((DevComponents.Instrumentation.GaugeText)gaugeCtrlDiskIO.GaugeItems[3]).Text =
                        $"{IOUtils.FormatSize(_PerformanceCounterWriteRate.NextValue())}/秒";
                    Thread.Sleep(1000);
                }
            } catch (Exception ex) {
                MessageBox.Show("磁盘读取错误，请退出并确认配置文件！\n" + _PerformanceCounterRumTime.InstanceName);
            }
        }

    }
}
