using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using Project4C.Core;
using Project4C.Properties;
using System;
using System.Data;
using System.IO;
using System.Windows.Forms;
using System.Xml;

namespace Project4C.FileOp {
    class FileHelper1 {
        #region 文件操作
        //创建文件夹
        public static bool CreateDir(String sDirPath) {
            try {
                if (false == System.IO.Directory.Exists(sDirPath)) {
                    //创建文件夹
                    Directory.CreateDirectory(sDirPath);
                }
            } catch (Exception) {

                return false;
            }

            return true;
        }
        //写入图像
        public static bool ImgToFile(string sFileFullPath, byte[] imgBytes) {
            try {
                int iNewImgLen = imgBytes.Length - 8;
                byte[] img = new byte[iNewImgLen];
                Buffer.BlockCopy(imgBytes, 8, img, 0, iNewImgLen);
                System.IO.File.WriteAllBytes(sFileFullPath, img);              
            } catch (Exception) {
                return false;
            }
            return true;


        }
        #endregion
        public static byte[] getImageByte(string imgPath) {
            byte[] imageBytes = null;
            string imgName = Path.GetFileNameWithoutExtension(imgPath);
            try {
                FileStream fs = new FileStream(imgPath, FileMode.Open);
                imageBytes = new byte[fs.Length];
                BinaryReader br = new BinaryReader(fs);
                imageBytes = br.ReadBytes(Convert.ToInt32(fs.Length));//图片转换成二进制流
            } catch (Exception ex) {
                Console.WriteLine("Insert {0} is error;\n{1}", imgName, ex.Message);//显示异常信息
            }
            return imageBytes;
        }
        /// <summary>
        /// 得到图像的二进制byte[] -- 传入图像Image
        /// </summary>
        /// <param name="imgPhoto"></param>
        /// <returns></returns>
        public static byte[] getImageByte(System.Drawing.Image imgPhoto) {
            //将Image转换成流数据，并保存为byte[]
            using (MemoryStream mstream = new MemoryStream()) {
                imgPhoto.Save(mstream, System.Drawing.Imaging.ImageFormat.Bmp);
                byte[] byData = new Byte[mstream.Length];
                mstream.Position = 0;
                mstream.Read(byData, 0, byData.Length);
                return byData;
            }

        }
        /// <summary>
        /// 将xml转为Datable
        /// </summary>
        public static DataTable XmlToDataTable(string xmlStr) {
            if (!string.IsNullOrEmpty(xmlStr)) {
                StringReader StrStream = null;
                XmlTextReader Xmlrdr = null;
                try {
                    DataSet ds = new DataSet();
                    //读取字符串中的信息  
                    StrStream = new StringReader(xmlStr);
                    //获取StrStream中的数据  
                    Xmlrdr = new XmlTextReader(StrStream);
                    //ds获取Xmlrdr中的数据                 
                    ds.ReadXml(Xmlrdr);
                    return ds.Tables[0];
                } catch (Exception) {
                    return null;
                } finally {
                    //释放资源  
                    if (Xmlrdr != null) {
                        Xmlrdr.Close();
                        StrStream.Close();
                        StrStream.Dispose();
                    }
                }
            }
            return null;
        }
        public static DataSet XmlToDataSet(string xmlFilePath) {

            StreamReader sr = null;
            DataSet ds = new DataSet();
            try {
                sr = new StreamReader(xmlFilePath, System.Text.Encoding.Default);
                ds.ReadXml(sr);
            } catch (Exception) {
                return null;
            } finally {
                sr.Close();
                //释放资源  

            }
            DataSetToXml(ds);
            return ds;
        }
        /// <summary>
        /// 将datatable转为xml 
        /// </summary>
        public static void DataTableToXml(DataTable vTable) {
            string savePath = Application.StartupPath.ToString();
            if (!Directory.Exists(savePath)) {
                Directory.CreateDirectory(savePath);
            }
            string xml = savePath + @"\编组信息表.xml";
            //如果文件DataTable.xml存在则直接删除
            if (File.Exists(xml)) {
                File.Delete(xml);
            }
            vTable.WriteXml(savePath + @"\编组信息表.xml");
        }
        public static void DataSetToXml(DataSet ds) {
            string savePath = Application.StartupPath.ToString();
            if (!Directory.Exists(savePath)) {
                Directory.CreateDirectory(savePath);
            }
            string xml = savePath + @"\111.xml";
            //如果文件DataTable.xml存在则直接删除
            if (File.Exists(xml)) {
                File.Delete(xml);
            }
            ds.WriteXml(savePath + @"\111.xml");
        }

        #region 读写文件
        public static bool SaveTextFile(string path, string content) {
            if (string.IsNullOrEmpty(content)) {
                return false;
            }
            try {
                using (FileStream fs = new FileStream(path, FileMode.Create, FileAccess.Write)) {
                    StreamWriter sw = new StreamWriter(fs);
                    sw.Write(content);
                    sw.Close();
                }
                return true;
            } catch (Exception) {
                // Debug.WriteLine(string.Format("写入文件出错：消息={0},堆栈={1}", ex.Message, ex.StackTrace));
                return false;
            }
        }

        #endregion
        #region 类型转换
        /// <summary>
        /// 转换C的多字节汉字为C#正常文本。
        /// 如："\xBA\xBC\xD6\xDD\xC4\xCF-\xBA\xBC\xD6\xDD\xC4\xCF"
        /// </summary>
        /// <param name="str"></param>
        public static String ConvertToStr(String str) {
            if (String.IsNullOrEmpty(str)) {
                return null;
            }
            if(str.Length==0)
                return null;
            byte[] gb = new byte[str.Length];
            for (int i = 0; i < str.Length; i++) {
                gb[i] = Convert.ToByte(str[i]);
            }
            return System.Text.Encoding.Default.GetString(gb);
        }
        #endregion

    }
    //日志文件
    class Log {
        public const string Update = "U";
        public const string Add = "A";
        public const string Del = "D";
        #region 创建单实例对象
        private static Log _log;
        private static readonly object _obj = new object();
        private readonly string sLogPath;
        public static Log GetInstance() {
            if (_log == null) {
                lock (_obj) {
                    if (_log == null) {
                        _log = new Log();
                    }
                }
            }
            return _log;
        }
        #region  初始化
        private Log() {
            sLogPath = Settings.Default.LogPath;
            if (String.IsNullOrEmpty(sLogPath)) {
                sLogPath = Application.StartupPath.ToString();
                if (!Directory.Exists(sLogPath)) {
                    Directory.CreateDirectory(sLogPath);
                }
            }
            sLogPath = Path.Combine(sLogPath, "log_" + DateTime.Now.ToString("yyyyMMdd") + ".log");
        }
        public void Write(string op, FaultInfo fInfo) {
            try {
                JObject obj = new JObject();
                obj.Add("OP", op);
                obj.Add("CONTENT", JToken.FromObject(fInfo));
                string sjson = JsonConvert.SerializeObject(obj);
                using (FileStream fs = new FileStream(sLogPath, FileMode.Append, FileAccess.Write)) {
                    StreamWriter sw = new StreamWriter(fs);
                    sw.WriteLine(sjson);
                    sw.Close();
                }
            } catch (Exception e) {
                MessageBox.Show("日志写入错误!错误信息：\n" + e.ToString());
            }

        }



        #endregion

        #endregion
    }
}
