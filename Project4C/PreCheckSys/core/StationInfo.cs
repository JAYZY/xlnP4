using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PreCheckSys.core {
    /// <summary>
    /// 站区信息
    /// </summary>
    class StationInfo1 {
        private int sId;        //线路Id
        private string sLineName;   //
        private string sStartStation;//
        private string sEndStation;//
        private Int16 iType;
        private DateTime taskDate;

        #region 创建单实例对象
        private static StationInfo1 _stationInfo;
        private static readonly object _obj = new object();
        public static StationInfo1 GetInstance() {
            if (_stationInfo == null) {
                lock (_obj) {
                    if (_stationInfo == null) {
                        _stationInfo = new StationInfo1();
                    }
                }
            }
            return _stationInfo;
        }
        private StationInfo1() {
        }
        #endregion

        public static String GetStationName(string str) {
            byte[] gb = new byte[str.Length];
            for (int i = 0; i < str.Length; i++) {
                gb[i] = Convert.ToByte(str[i]);
            }
            return Encoding.Default.GetString(gb);
        }
        //检测时间
        public DateTime TaskDate { get => taskDate; set => taskDate = value; }

        /// <summary>
        /// 0 - 上行 1--下行
        /// </summary>
        public int IType { set { iType =(short) value; } get { return iType; } }
        //站区类型上行
        public string SType {
            get { return (iType == 0) ? @"上行" : @"下行"; }
            set { iType = (Int16)(value.Equals("上行") ? 0 : 1); }
        }
        //线路名称
        public string LineName { get => sLineName; set => sLineName = value; }

        //起始站名称
        public string StartStation { get => sStartStation; set => sStartStation = value; }

        //结束站名称
        public string EndStation { get => sEndStation; set => sEndStation = value; }

        //站区编号
        public int SId { get => sId; set => sId = value; }
        /// <summary>
        /// 登录用户编号
        /// </summary>
        public int UId { get; set; }
        /// <summary>
        /// 登录用户名
        /// </summary>
        public string User { get; set; }
        public string GetDateStr() {
            return taskDate.ToString("yyyy年MM月dd日");
        }
        //输出 线路12.5
        public string GetShortInfo() {
            return LineName + taskDate.ToString("MM.dd");
        }
        
        //public void SaveToDb() {
        //    string sSql = string.Format("insert into stationInfo (sLineName,sStartStation,sEndStation ,sType,taskDate)values ( '{0}','{1}','{2}',{3},'{4}' )"
        //        , this.LineName, this.sStartStation, this.sEndStation, this.iType, this.taskDate.ToString("s"));
        //    try {
        //        SqliteHelper.GetSqlite(Settings.Default.MDB).ExecuteNonQuery(sSql, null);
        //    } catch (Exception) {
        //        MessageBox.Show("写入任务信息失败！");
        //    }
        //}

        //public void UpdateDb() {
        //    string sSql = string.Format("update stationInfo set sLineName='{0}',sStartStation='{1}',sEndStation='{2}', sType={3},taskDate='{4}' where sId={5}"
        //        , this.LineName, this.sStartStation, this.sEndStation, this.iType, this.taskDate.ToString("s"), this.SId);
        //    try {
        //        SqliteHelper.GetSqlite(Settings.Default.MDB).ExecuteNonQuery(sSql, null);
        //    } catch (Exception) {
        //        MessageBox.Show(@"更新任务信息失败！");
        //    }

        //}


    }
}
