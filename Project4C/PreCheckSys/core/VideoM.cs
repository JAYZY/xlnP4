using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;
using ComClassLib;
using ComClassLib.core;
namespace PreCheckSys.core {
    public class CameraInfo {

    }
    public class VideoM {

        #region CallDLL
        [DllImport("RPCDll.dll", EntryPoint = "?OpenRPC@@YAPEAXPEBDH@Z", CharSet = CharSet.Ansi, CallingConvention = CallingConvention.StdCall)]

        public static extern IntPtr OpenRPC(string addrIp, int iPort);
        /**
        ** 关闭RPC对象，。
        ** pRPC:		需要关闭的RPC对象
        */
        [DllImport("RPCDll.dll", EntryPoint = "?CloseRPC@@YAXPEAX@Z", CallingConvention = CallingConvention.StdCall)]
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
        [DllImport("RPCDll.dll", EntryPoint = "?GetRpcInfo@@YAPEBDPEAXH@Z", CharSet = CharSet.Ansi, CallingConvention = CallingConvention.Cdecl)]
        public static extern IntPtr GetRpcInfo(IntPtr pRPC, int iCameraID);

        [DllImport("RPCDll.dll", EntryPoint = "?GetRpcImage@@YAHPEAXH0@Z", CallingConvention = CallingConvention.Cdecl)]
        public static extern int GetRpcImage(IntPtr pRPC, int iCameraID, IntPtr pImageData);


        [DllImport("RPCDll.dll", EntryPoint = "?GetErrInfo@@YAPEBDPEAX@Z", CallingConvention = CallingConvention.Cdecl)]
        public static extern IntPtr GetErrInfo(IntPtr pRPC);
        #endregion



        public static IntPtr Connection(string _ipAddress, int iPort = 12345) {
            IntPtr hDec = IntPtr.Zero;
            try {
                hDec = OpenRPC(_ipAddress, iPort);
            }
            catch (Exception ex) {
                hDec = IntPtr.Zero;
                Console.WriteLine("设备连接失败！" + ex.ToString());
            }
            return hDec;
        }
        /// <summary>
        /// 获取相机参数
        /// </summary>
        public static string GetCameraParam(IntPtr hDec) {
            string sRtn = string.Empty;
            if (hDec != IntPtr.Zero) {
                try {
                    IntPtr ipStr = GetRpcInfo(hDec, 0);
                    sRtn = Marshal.PtrToStringAnsi(ipStr);
                }
                catch (Exception) {
                    sRtn = string.Empty;
                    Console.WriteLine("设备打开失败！");
                }
            }
            return sRtn;
        }
        /// <summary>
        /// 获取相机图像
        /// </summary>
        /// <param name="viewImage"></param>
        /// <param name="hDec"></param>
        /// <param name="imgW"></param>
        /// <param name="imgH"></param>
        /// <param name="time"></param>

        public static void  LoadImg(CtrlView viewImage, IntPtr hDec, ref int imgW, ref int imgH, ref long time) {

            if (hDec == IntPtr.Zero) {
                return;
            }
            Image img = null;
            try {
                byte[] jpg_buffer = new byte[100000000];
                IntPtr pImageData = IntPtr.Zero;
                unsafe {
                    fixed (void* p = &jpg_buffer[0]) {
                        pImageData = (IntPtr)p;
                    }
                }
                int iImgLen = GetRpcImage(hDec, 0, pImageData);
                if (iImgLen > 16) {

                    byte[] bWith = new byte[4];
                    byte[] bHeight = new byte[4];
                    byte[] bTime = new byte[8];
                    Array.Copy(jpg_buffer, 0, bWith, 0, 4);
                    imgW = System.BitConverter.ToInt32(bWith, 0);
                    Array.Copy(jpg_buffer, 4, bHeight, 0, 4);
                    imgH = System.BitConverter.ToInt32(bHeight, 0);
                    Array.Copy(jpg_buffer, 8, bTime, 0, 8);
                    time = System.BitConverter.ToInt64(bTime, 0);
                    viewImage.LoadImg(jpg_buffer, (uint)iImgLen, 16);
                    //    MemoryStream ms = new MemoryStream();
                    //    ms.Write(jpg_buffer, 16, iImgLen);
                    //    img = Image.FromStream(ms);
                    //}
                    viewImage.Refresh();
                }
            }
            catch (Exception ex) {
                Console.WriteLine("图像读取错误" + ex.ToString());
            }
        }
       /// <summary>
       /// 获取相机图像
       /// </summary>
       /// <param name="hDec"></param>
       /// <param name="imgW"></param>
       /// <param name="imgH"></param>
       /// <param name="time"></param>
       /// <returns></returns>
        public static Image GetImg(IntPtr hDec, ref int imgW, ref int imgH, ref long time) {

            if (hDec == IntPtr.Zero) {
                return null;
            }
            Image img = null;
            try {
                byte[] jpg_buffer = new byte[100000000];
                IntPtr pImageData = IntPtr.Zero;
                unsafe {
                    fixed (void* p = &jpg_buffer[0]) {
                        pImageData = (IntPtr)p;
                    }
                }
                int iImgLen = GetRpcImage(hDec, 0, pImageData);
                if (iImgLen > 16) {

                    byte[] bWith = new byte[4];
                    byte[] bHeight = new byte[4];
                    byte[] bTime = new byte[8];
                    Array.Copy(jpg_buffer, 0, bWith, 0, 4);
                    imgW = System.BitConverter.ToInt32(bWith, 0);
                    Array.Copy(jpg_buffer, 4, bHeight, 0, 4);
                    imgH = System.BitConverter.ToInt32(bHeight, 0);
                    Array.Copy(jpg_buffer, 8, bTime, 0, 8);
                    time = System.BitConverter.ToInt64(bTime, 0);
                    MemoryStream ms = new MemoryStream();
                    ms.Write(jpg_buffer, 16, iImgLen);
                    img = Image.FromStream(ms);
                }
            }
            catch (Exception ex) {
                Console.WriteLine("图像读取错误" + ex.ToString());
            }
            return img;
        }
    }
}
