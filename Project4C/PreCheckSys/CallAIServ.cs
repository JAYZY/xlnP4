using System;
using System.Collections.Generic;
using System.Linq;

using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace PreCheckSys {
    /// <summary>
    /// 调用远程智能分析服务器
    /// </summary>
    public class CallAIServ {

        [DllImport("zmqDLL.dll", EntryPoint = "?openAlgoModule@@YAHV?$basic_string@DU?$char_traits@D@std@@V?$allocator@D@2@@std@@HHHH0@Z", CallingConvention = CallingConvention.Cdecl)]
        private static extern int OpenAlgoModule(string server_redis_ip, int server_redis_port, int img_db_id, int img_key_db_id, int save_results_db_id, string img_key_name);


        [DllImport("zmqDLL.dll", EntryPoint = "?init@@YA_NV?$basic_string@DU?$char_traits@D@std@@V?$allocator@D@2@@std@@H@Z", CallingConvention = CallingConvention.Cdecl)]
        private static extern bool Init(string param_file_dir, int port);

        [DllImport("zmqDLL.dll", EntryPoint = "?closeAlgoModule@@YAHXZ", CallingConvention = CallingConvention.Cdecl)]
        private static extern int CloseAlgoModule();

        #region 创建单实例对象
        private static CallAIServ _callAIServ;
        private static object _obj = new object();
        public static CallAIServ GetInstance() {
            if (_callAIServ == null) {
                lock (_obj) {
                    if (_callAIServ == null) {
                        _callAIServ = new CallAIServ();
                    }
                }
            }
            return _callAIServ;
        }
        private CallAIServ() {

        }
        #endregion

        public bool IsInit { get; set; }  //"open@192.168.1.0@6379@10@11@list"  open 

        //"192.168.100.58", 6379, 10, 11, 12, "list"
        public bool OpenAIServ(string sServIP, int iImgDbId, int iImgKeyDbId, int iLocDbId, string imgKeyName = "list", int iPort = 6379) {
            if (IsInit) {
                return true;
            }
            bool res = false;
            IsInit = Init("192.168.100.10", 5555);
            if (IsInit) {
                int iOpen = OpenAlgoModule(sServIP, iPort, iImgDbId, iImgKeyDbId, iLocDbId, imgKeyName);
                if (iOpen > 0)
                    res = true;
            }
            return res;
        }

        public bool CloseAIServ() {
            bool res = IsInit ? CloseAlgoModule() > 0 : false;
            return res;
        }


    }
}
