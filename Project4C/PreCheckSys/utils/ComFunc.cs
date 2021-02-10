using PreCheckSys.Properties;
using System;
using System.Diagnostics;
using System.Runtime.InteropServices;
/// <summary>
/// 通用工具包/类
/// </summary>
namespace PreCheckSys.utils {
    /// <summary>
    /// I/O通用工具类
    /// </summary>
    class IOUtils {



        /// <summary>
        /// 获取指定磁盘空间---单位GＢ
        /// </summary>
        /// <param name="sHardDiskName"></param>
        /// <returns></returns>
        public static double GetHardDiskSpace(string sHardDiskName) {
            double totalSize = 0;

            //if (!sHardDiskName.Contains(":\\")) {
            //    sHardDiskName += ":\\";
            //}
            System.IO.DriveInfo[] drives = System.IO.DriveInfo.GetDrives();
            foreach (System.IO.DriveInfo drive in drives) {
                if (drive.Name == sHardDiskName) {
                    totalSize = (1.0 * drive.TotalFreeSpace) / (1024 * 1024 * 1024);
                }
            }
            return totalSize;
        }
        public static bool CheckDiskSpace(string sDiskName) {
            double dCurDiskSpace = GetHardDiskSpace(sDiskName);
            if (dCurDiskSpace < Settings.Default.miniDiskSpace) {
                ComClassLib.MsgBox.Warning(sDiskName + " 剩余磁盘空间 " + dCurDiskSpace.ToString("F2") + "G, 存储空间不足！\n 需要至少"
                    + Settings.Default.miniDiskSpace + "G,请更换磁盘或清除磁盘内容！", "警告磁盘空间不足");
                return false;
            }
            return true;
        }
        #region 获取性能计数器
        public static PerformanceCounter GetPerformance(string counterName, string diskName) {
            return new PerformanceCounter("LogicalDisk", counterName, diskName);
        }

        #endregion

        #region 获得内存信息API
        [DllImport("kernel32.dll")]
        [return: MarshalAs(UnmanagedType.Bool)]
        public static extern bool GlobalMemoryStatusEx(ref MEMORY_INFO mi);

        //定义内存的信息结构
        [StructLayout(LayoutKind.Sequential)]
        public struct MEMORY_INFO {
            public uint dwLength; //当前结构体大小
            public uint dwMemoryLoad; //当前内存使用率
            public ulong ullTotalPhys; //总计物理内存大小
            public ulong ullAvailPhys; //可用物理内存大小
            public ulong ullTotalPageFile; //总计交换文件大小
            public ulong ullAvailPageFile; //总计交换文件大小
            public ulong ullTotalVirtual; //总计虚拟内存大小
            public ulong ullAvailVirtual; //可用虚拟内存大小
            public ulong ullAvailExtendedVirtual; //保留 这个值始终为0
        }
        #endregion

        #region 格式化容量大小
        /// <summary>
        /// 格式化容量大小
        /// </summary>
        /// <param name="size">容量（B）</param>
        /// <returns>已格式化的容量</returns>
        public static string FormatSize(double size) {
            double d = size;
            int i = 0;
            while ((d > 1024) && (i < 5)) {
                d /= 1024;
                i++;
            }
            string[] unit = { "B", "KB", "MB", "GB", "TB" };
            return (string.Format("{0} {1}", Math.Round(d, 2), unit[i]));
        }
        #endregion

        #region 获得当前内存使用情况
        /// <summary>
        /// 获得当前内存使用情况
        /// </summary>
        /// <returns></returns>
        public static MEMORY_INFO GetMemoryStatus() {
            MEMORY_INFO mi = new MEMORY_INFO();
            mi.dwLength = (uint)System.Runtime.InteropServices.Marshal.SizeOf(mi);
            GlobalMemoryStatusEx(ref mi);
            return mi;
        }
        #endregion

        #region 获得当前可用物理内存大小
        /// <summary>
        /// 获得当前可用物理内存大小
        /// </summary>
        /// <returns>当前可用物理内存（B）</returns>
        public static ulong GetAvailPhys() {
            MEMORY_INFO mi = GetMemoryStatus();
            return mi.ullAvailPhys;
        }
        #endregion

        #region 获得当前已使用的内存大小
        /// <summary>
        /// 获得当前已使用的内存大小
        /// </summary>
        /// <returns>已使用的内存大小（B）</returns>
        public static ulong GetUsedPhys() {
            MEMORY_INFO mi = GetMemoryStatus();
            return (mi.ullTotalPhys - mi.ullAvailPhys);
        }
        #endregion

        #region 获得当前总计物理内存大小
        /// <summary>
        /// 获得当前总计物理内存大小
        /// </summary>
        /// <returns&amp;gt;总计物理内存大小（B）&amp;lt;/returns&amp;gt;
        public static ulong GetTotalPhys() {
            MEMORY_INFO mi = GetMemoryStatus();
            return mi.ullTotalPhys;
        }
        #endregion

    }
}
