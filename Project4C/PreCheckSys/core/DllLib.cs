using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Runtime.InteropServices;
namespace PreCheckSys.core {
 
    public class AICallDll {
       
        [DllImport("zmqDLL.dll", EntryPoint = "?openAlgoModule@@YAHV?$basic_string@DU?$char_traits@D@std@@V?$allocator@D@2@@std@@HHHH0@Z", CallingConvention = CallingConvention.Cdecl)]
        public static extern IntPtr GetErrInfo(IntPtr pRPC);
    }
}
