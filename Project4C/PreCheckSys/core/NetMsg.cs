using System;
using System.Net;
using System.Net.Sockets;
using System.Runtime.InteropServices;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace PreCheckSys.core {
    [Serializable] // 指示可序列化
    [StructLayoutAttribute(LayoutKind.Sequential, CharSet = CharSet.Ansi, Pack = 1)]
    //[StructLayout(LayoutKind.Sequential, Pack = 1)] // 按1字节对齐 
    public struct StuReceive {
        [MarshalAs(UnmanagedType.ByValTStr, SizeConst = 32)] // 声明一个字符数组，大小为32
        public string strStationName;       //区间名
        [MarshalAs(UnmanagedType.ByValTStr, SizeConst = 32)] // 声明一个字符数组，大小为20
        public string strMaoduanName;       //锚段名
        [MarshalAs(UnmanagedType.ByValTStr, SizeConst = 32)] // 声明一个字符数组，大小为32
        public string strPoleName;          //杆号名

        public int iDataBaseID;                    //当前数据(数据库编号ID)         
        public double dTimeStamp;                  //更新时间标识：时间戳
        public int uiWheelPulse;                   //车轮脉冲

        public Byte bLineDir;                      //true:上行 ；flase :下行
        public Byte bTrainMoveDir;                 //运动方向 
        public Byte ucLineType;                    //线路类型
        public Byte ucPoleLocateType;              //定位方式

        public float fPerPoleDistance;             //数据库跨距(米)
        public float fSpeed;                       //当前速度(km/h)
        public double dTrainMoveDistance;          //列车行车里程(从检测时开始累计)-(KM).
        public double dPoleKiloMeter;              //线路数据库公里标(km)
        public float fPoleMeter;                   //当前跨距内行车距离(米)*/

        [MarshalAs(UnmanagedType.ByValArray, SizeConst = 4)] // 声明一个字符数组，大小为32
        public float[] fZigs;                      //检测拉出值数组
        [MarshalAs(UnmanagedType.ByValArray, SizeConst = 4)] // 声明一个字符数组，大小为32
        public float[] fHeis;                      //检测导值数组
        [MarshalAs(UnmanagedType.ByValArray, SizeConst = 4)] // 声明一个字符数组，大小为32
        public float[] fZigsBC;                    //补偿后的拉出值
        [MarshalAs(UnmanagedType.ByValArray, SizeConst = 4)] // 声明一个字符数组，大小为32
        public float[] fHeisBC;                    //补偿后的导高

        public float fCxLeft;                      //左水平补偿
        public float fCyLeft;                      //左高度补偿
        public float fCxRight;                     //右水平补偿 
        public float fCyRight;                     //右高度补偿

        public int iMonitorFrameNum;  //监控桢
        public System.Single fTemperature;   //温度
        public System.Single fHumidity;    //湿度
        public System.Int64 tTime;
        public System.UInt32 uiId; //唯一id，对应results表的id
    };
    class NetMsg {
        private int _port;
        private bool _isRece;
        private Task _thRec;
        CancellationTokenSource _tokenSource;
        CancellationToken _token;
        ManualResetEvent _resetEvent;
        UdpClient _client;
        internal delegate void Feedback(string msg);
        private Feedback callBack;
        public NetMsg(int port) {
            this._port = port;
            _isRece = false;
            callBack = null;
            _tokenSource = new CancellationTokenSource();
            _token = _tokenSource.Token;
            _resetEvent = new ManualResetEvent(true);
        }
        public void SetCallBack(Feedback cb) {
            callBack = cb;
        }
        public void start() {
            if (!_isRece) {
                _isRece = true;
                _thRec = new Task(ReciveMsg, _token);
                _thRec.Start();
            }
        }
        public void Stop() {
            if (_isRece) {
                _isRece = false;
                _tokenSource.Cancel();
                SendSelf();
                //_client.Close();
                //_client = null;

            }
        }
        private void SendSelf() {
            byte[] datagram = new byte[] { 0xff };
            _client.Send(datagram, datagram.Length, new IPEndPoint(IPAddress.Parse("127.0.0.1"), _port));

        }
        public void ReciveMsg() {
            try {
                _client = new UdpClient(new IPEndPoint(IPAddress.Any, _port));
                var iep = new IPEndPoint(IPAddress.Any, 0);
                callBack("---开始监听广播，端口：" + _port + "\n");
                while (_isRece) {
                    if (_tokenSource.IsCancellationRequested) {
                        return;
                    }
                    byte[] bytes = _client.Receive(ref iep);
                    StuReceive deviceinfo = new StuReceive();
                    object obj=  this.BytesToStruct(bytes, typeof(StuReceive));
                    if (obj == null) {
                        continue;
                    }
                    deviceinfo = (StuReceive)obj;
                   
                    string result = deviceinfo.fSpeed + "," + deviceinfo.strStationName;                                                                                                                                    // string xx=System.Text.Encoding.Default.GetString(bytes);
                    if (callBack != null) {
                        callBack(result);
                    }
                }
                if (_client != null) {
                    _client.Close();
                    _client = null;
                }

            }
            catch (Exception ex) {
                MessageBox.Show(ex.ToString());

            }
        }
        /// byte数组转结构
        /// 
        /// byte数组
        /// 结构类型
        /// 转换后的结构
        public object BytesToStruct(byte[] bytes, Type type) {
            //得到结构的大小
            int size = Marshal.SizeOf(type);
            //Log(size.ToString(), 1);
            //byte数组长度小于结构的大小
            if (size > bytes.Length) {
                //返回空
                return null;
            }
            //分配结构大小的内存空间
            IntPtr structPtr = Marshal.AllocHGlobal(size);
            //将byte数组拷到分配好的内存空间
            Marshal.Copy(bytes, 0, structPtr, size);
            //将内存空间转换为目标结构
            object obj = Marshal.PtrToStructure(structPtr, type);
            //释放内存空间
            Marshal.FreeHGlobal(structPtr);
            //返回结构
            return obj;
        }
    }
}
