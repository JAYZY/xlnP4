using System;
using System.Runtime.InteropServices;

namespace VideoRPC {
    class DllLib {

         // 1    0 00019020 ??0CImageJpegConvert@@QEAA@XZ
         // 2    1 000190C0 ??1CImageJpegConvert@@QEAA@XZ
         // 3    2 00003260 ??4CImageJpegConvert@@QEAAAEAV0@AEBV0@@Z
         // 4    3 0004A8C0 ?CloseRPC@@YAXPEAX@Z
         // 5    4 000194F0 ?DecodeBuffer@CImageJpegConvert@@QEAAHPEAEHAEAH110H@Z
         // 6    5 00019320 ?EncodeBuffer@CImageJpegConvert@@QEAAHPEAEHHH0AEAHH@Z
         // 7    6 0004AB20 ?GetErrInfo@@YAPEBDPEAX@Z
         // 8    7 00003250 ?GetProcessTime@CImageJpegConvert@@QEAANXZ
         // 9    8 0004AA20 ?GetRpcImage@@YAHPEAXHPEAD@Z
         //10    9 0004A9B0 ?GetRpcInfo@@YAPEBDPEAXH@Z
         //11    A 0004A800 ?OpenRPC@@YAPEAXPEBDH@Z
         //12    B 00019140 ?SaveBufferJpeg@CImageJpegConvert@@QEAAHPEAEHHHPEBDH@Z
         //13    C 0004A960 ?SetRPCParam@@YA_NPEAXHPEBD@Z
         //14    D 00002AE0 ?__autoclassinit2@CImageJpegConvert@@QEAAX_K@Z

        /**
        ** 打开RPC对象，返回数据库对象。
        ** addrIp:		数据库服务器IP地址
        ** iTimeout:	连接超时设置 默认 3秒
        ** iPort:		数据库服务器端口号默认 6379
        */
        [DllImport("RPCDll.dll", EntryPoint = "?OpenRPC@@YAPEAXPEBDH@Z", CharSet = CharSet.Ansi, CallingConvention = CallingConvention.StdCall)]
       
        public static extern IntPtr OpenRPC(string addrIp, int iPort = 6379);

        /**
        ** 关闭RPC对象，。
        ** pRPC:		需要关闭的RPC对象
        */
        [DllImport("RPCDll.dll", CallingConvention = CallingConvention.StdCall)]
        public static extern void CloseRPC(IntPtr pRPC);
        /**
        ** 设定相机对应的参数。
        ** pRPC:		RPC对象
        ** iCameraID:	RPC对象绑定的相机，默认是0
        ** strJsonCommand：RPC命令
        ("Gain")("Exposure")("FocusMinus")("FocusPlus")("LEDWidth")("EnableLED")("FrameRate")("TriggerMode")
        ("MoveUp")("MoveDown")("MoveLeft")("MoveRight")("MoveStop")("MoveTo")("SetPos")("RemovePos")("ShutDown"))
        */
        [DllImport("RPCDll.dll", EntryPoint = "?SetRPCParam@@YA_NPEAXHPEBD@Z", CallingConvention = CallingConvention.Cdecl)]
        public static extern bool SetRPCParam(IntPtr pRPC, int iCameraID, string strJsonCommand);
        //return json data
        /**
        ** 设定相机对应的参数。
        ** pRPC:		RPC对象
        ** iCameraID:	RPC对象绑定的相机，默认是0
        */
        [DllImport("RPCDll.dll",EntryPoint = "?GetRpcInfo@@YAPEBDPEAXH@Z",CharSet =CharSet.Ansi, CallingConvention = CallingConvention.Cdecl)]
        public static extern string GetRpcInfo(IntPtr pRPC, int iCameraID);
        /**
        ** 设定相机对应的参数。
        ** pRPC:		RPC对象
        ** iCameraID:	RPC对象绑定的相机，默认是0
        ** char* pImageData 事先分配好得图像内存数据
        **  内存结构： pImageData+0->4 iWidth
                                 +4->8 iHeight,
                                 +8->16 lTime
                       pImageData+16->end jpegdata
        */
        [DllImport("RPCDll.dll",EntryPoint = "?GetRpcImage@@YAHPEAXHPEAD@Z",  CallingConvention = CallingConvention.Cdecl)]
        public static extern int GetRpcImage(IntPtr pRPC, int iCameraID, IntPtr pImageData);

        [DllImport("RPCDll.dll", CallingConvention = CallingConvention.Cdecl)]
        public static extern string GetErrInfo(IntPtr pRPC);

       // [DllImport(@"Platform.dll", EntryPoint = "Plat_GetValueStr", CharSet = CharSet.Ansi, CallingConvention = CallingConvention.Cdecl)]
        //IntPtr ipName = Plat_GetValueStr(ConstControlUnit.ControlUnitName, iUserHandle);
        //ResName= Marshal.PtrToStringAnsi(ipName);
    }
}
