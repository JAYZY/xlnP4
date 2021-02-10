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
    class CallAIServ {

        [DllImport("zmqDLL.dll", CallingConvention = CallingConvention.Cdecl)]
        private static extern int openAlgoModule(string server_redis_ip, int server_redis_port, int img_db_id, int img_key_db_id, string img_key_name);
        [DllImport("zmqDLL.dll", CallingConvention = CallingConvention.Cdecl)]
        private static extern bool init(string param_file_dir);
        [DllImport("zmqDLL.dll", CallingConvention = CallingConvention.Cdecl)]
        private static extern int closeAlgoModule();
        public bool IsInit { get; set; }
        public CallAIServ() {
            IsInit = init("./");
            if (!IsInit) {
                MessageBox.Show(@"配置文件载入失败，请确认文件是否存在");
            }
        }
        public bool OpenAIServ(string sServIP, int iImgDbId, int iImgKeyDbId, string sKeyName, int iPort = 6379) {
            bool res = false;
            if (IsInit) {
                int iOpen = openAlgoModule(sServIP, iPort, iImgDbId, iImgKeyDbId, sKeyName);
                if (iOpen > 0)
                    res = true;
            }
            return res;
        }
        public bool CloseAIServ(){
            return closeAlgoModule() > 0;
        }


    }
}
