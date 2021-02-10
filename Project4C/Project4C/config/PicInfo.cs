

using System.IO;
using System.Runtime.Serialization.Json;

namespace Project4C.config {

    public class PicInfo {

        //public int _1 { get; set; }
        //public string _2 { get; set; }
        //public string _3 { get; set; }
        //public string _4 { get; set; }
        //public int _5 { get; set; }
        public int CID { get; set; }
        public string Tim { get; set; }
        public string GPS { get; set; }
        public string POL { get; set; }
        public int SAT { get; set; }

        public static PicInfo FromJson(string sJson) {
            DataContractJsonSerializer js = new DataContractJsonSerializer(typeof(PicInfo));
            using (MemoryStream ms = new MemoryStream()) {
                StreamWriter sw = new StreamWriter(ms);
                sw.Write(sJson);
                sw.Flush();
                ms.Seek(0, SeekOrigin.Begin);
                return (PicInfo)js.ReadObject(ms);
            }
           // JavaScriptSerializer serializer = new JavaScriptSerializer();
          //  PicInfo p2 = serializer.Deserialize<PicInfo>(sJson); //反序列化：JSON字符串=>对象
           // return p2;

        }
    }


}
