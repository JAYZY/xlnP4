using System.Data;

namespace Project4C.config {

    class ConfigInfo {
        #region 创建单实例对象

        private static ConfigInfo _config;
        private static readonly object _obj = new object();
        public static ConfigInfo GetInstance() {
            if (_config == null) {
                lock (_obj) {
                    if (_config == null)
                        _config = new ConfigInfo();
                }
            }
            return _config;
        }
        /// <summary>
        /// 构造函数
        /// </summary>
        private ConfigInfo() {

        }
        #endregion

        public int defaultMarkW = 300;
        public int defaultMarkH = 300;
        public static string[] strArr = { "一", "二", "三", "四", "五", "六", "七", "八", "九", "十", "十一", "十二", "十三", "十四", "十五", "十六", "十七", "十八", "十九", "二十"
        ,"二十一","二十二","二十三","二十四","二十五","二十六","二十七","二十八","二十九","三十","三十一","三十二","三十三","三十四","三十五","三十六","三十七","三十八","三十九"};
        public int TotalFualt = 0; //动态的数据

        private DataSet ds = null;
        public DataSet GetConfigInfo() {
            if (ds == null) {
                ds = FileOp.FileHelper1.XmlToDataSet("config/BaseData.xml");
            }
            return ds;
        }
        public DataTable GetDtByName(string tbName) {
            return GetConfigInfo().Tables[tbName];
        }
        public void SaveToXml() {
            if (ds != null) {
                FileOp.FileHelper1.DataSetToXml(ds);
            }
        }
    }
}
