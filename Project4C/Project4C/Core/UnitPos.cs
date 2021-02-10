using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text.RegularExpressions;
using System.Windows.Forms;

namespace Project4C.Core {
    /// <summary>
    /// 部件定位信息
    /// </summary>
    class LocFaultInfo {
        
         
        public LocFaultInfo(Int64 id, int unitId, Rectangle rect, List<int> fault) {
            ID = id; UnitId = unitId; Mark = rect; Fault = fault;
            
        }
        private string strJson;
        public string GetSJson() { return strJson; }
        public void SetSJson(string value) { strJson = value; }
        //全局ID
        public Int64 ID { get; set; }
        //部件ID
        public int UnitId { get; set; }
        //标注
        public Rectangle Mark { get; set; }
        //缺陷
        public List<int> Fault { get; set; }

        public bool IsFault { get { return (Fault.Count > 0 && Fault[0] > 0); } }

        public string GetUnitName() {
            return GetUName(UnitId);

        }
        public static string GetUName(int uId) {
            DataTable dtUnits = config.ConfigInfo.GetInstance().GetDtByName("InfoB");
            DataRow[] dr = dtUnits.Select("UnitID='" + uId + "'");
            return (dr.Length == 0) ? "未知部件" : dr[0]["Name"].ToString();
        }
        public string GetFaultNameByInd(int ind) {
            return GetFName(Fault[ind]);
        }
        /// <summary>
        /// 给定类似格式数组[1,32],提取所有的数字"
        /// </summary>
        /// <param name="sFault"></param>
        /// <returns></returns>
        public static List<string> GetFaultIds(string sFault) {
            var list = Regex.Matches(sFault, @"\d+(\.\d+)?").OfType<Match>().Select(t => t.Value).ToList();
            list.ForEach(t => Console.WriteLine(t));          
            return list;
        }
        public static string GetFName(int fId) {
            DataTable dtFaults = config.ConfigInfo.GetInstance().GetDtByName("Info");
            return dtFaults.Select("FaultID='" + fId + "'")[0]["Name"].ToString();
        }
        public static LocFaultInfo getUnitPos(string sJson) {
            return Newtonsoft.Json.JsonConvert.DeserializeObject<LocFaultInfo>(sJson);
        }
        public static List<LocFaultInfo> getLstUnitPos(string sJson) {

            if (String.IsNullOrEmpty(sJson)) {
                return null;
            }

            Newtonsoft.Json.Linq.JObject jobj = Newtonsoft.Json.Linq.JObject.Parse(sJson);
            List<LocFaultInfo> obj2 = new List<LocFaultInfo>();
            try {
                var arrdata = Newtonsoft.Json.Linq.JArray.Parse(jobj["seg"].ToString());
                foreach (var item in arrdata) {
                    JToken[] r = item["mark"].ToArray();
                    JToken[] f = item["Fault"].ToArray();
                    List<int> _fault = new List<int>();
                    foreach (var t in f) {
                        _fault.Add(int.Parse(t.ToString()));
                    }
                    Rectangle rect = new Rectangle(int.Parse(r[0].ToString()), int.Parse(r[1].ToString()), int.Parse(r[2].ToString()), int.Parse(r[3].ToString()));
                    LocFaultInfo unit = new LocFaultInfo(Int64.Parse(item["ID"].ToString()), int.Parse(item["unitId"].ToString()), rect, _fault);
                    unit.SetSJson(Newtonsoft.Json.JsonConvert.SerializeObject(unit));
                    obj2.Add(unit);
                }
            }
            catch (Exception e) {
                MessageBox.Show(e.ToString());
                return null;
            }
            return obj2;
        }

    }
}
