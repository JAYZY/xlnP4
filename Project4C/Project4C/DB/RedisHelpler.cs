using Project4C.FileOp;
using StackExchange.Redis;
using System.Collections.Generic;
using System.Text;
using System.Windows.Forms;

namespace Project4C.DB {
    public class RedisHelper {
        private string _redisServerIp;
        private readonly object asyncState;
        private ConnectionMultiplexer redisClient;
        private Dictionary<int, IDatabase> dicDB;

        public string RedisServer {
            get { return _redisServerIp; }

        }
        public bool SetRedisServer(string svrIp) {
            redisClient = ConnectionMultiplexer.Connect(svrIp);
            _redisServerIp = svrIp;
            if (redisClient.IsConnected) {
                dicDB = new Dictionary<int, IDatabase>();
                dicDB.Add(10, redisClient.GetDatabase(10, asyncState));
                return true;
            }
            return false;
        }

        #region 创建单实例对象
        private static RedisHelper _redisHelper;
        private static readonly object _obj = new object();
        public static RedisHelper GetInstance() {
            if (_redisHelper == null) {
                lock (_obj) {
                    if (_redisHelper == null) {
                        _redisHelper = new RedisHelper();
                    }
                }
            }
            return _redisHelper;
        }
        private RedisHelper() {

            asyncState = new object();
            redisClient = null;
            dicDB = null;

        }
        #endregion

        private IDatabase getDB(int num) {
            if (!dicDB.ContainsKey(num)) {
                dicDB[num] = redisClient.GetDatabase(num, asyncState);
            }

            return dicDB[num];
        }
        //返回字符串
        public byte[] GetByte(string key, int dbNum = 10) {
            byte[] rByt = null;
            try {
                if (dicDB != null) {
                    RedisValue rdv = getDB(dbNum).StringGet(key);
                    if (rdv.IsNullOrEmpty) {
                        rByt = null;
                    }
                    else {
                        rByt = rdv;
                    }
                }
            }
            catch (System.Exception) {
                rByt = null;
            }
            return rByt;

        }
        public string GetString(string key, int dbNum = 10) {
            try {
                if (dicDB == null) {
                    return null;
                }
                RedisValue rdv = getDB(dbNum).StringGet(key);
                if (rdv.IsNullOrEmpty) {
                    return null;
                }
                return rdv;
            }
            catch (System.Exception ex) {
                MessageBox.Show("内存数据库获取数据失败,请检查数据库服务器! 错误详细信息：\n" + ex.ToString());
                return null;
            }

            // return getDB(dbNum).StringGet(key);
        }
        public bool SetString(string key, string sValue, int dbNum) {
            try {
                return getDB(dbNum).StringSet(key, sValue);

            }
            catch (System.Exception ex) {
                MessageBox.Show("写入redis出错\n" + ex.ToString());
                return false;
            }
        }
        public void GetAllKeys(int dbNum) {
            StringBuilder sb = new StringBuilder();
            foreach (var ep in redisClient.GetEndPoints()) {
                var server = redisClient.GetServer(ep);
                var keys = server.Keys(dbNum, pattern: "*");
                foreach (var key in keys) {
                    string sjson = GetString(key, dbNum);
                    sb.AppendLine(sjson);
                    // System.Console.WriteLine(GetString(key,dbNum));
                }
            }
            FileHelper1.SaveTextFile("d:\\Location.db", sb.ToString());
        }

        /// <summary>s
        /// 获取一个key的对象
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="key"></param>
        /// <returns></returns>
        public T GetObj<T>(string key, int dbNum = 10) where T : class {
            if (dicDB == null) {
                return null;
            }
            try {
                var result = getDB(dbNum).StringGet(key);
                if (string.IsNullOrEmpty(result)) {
                    return null;
                }
                return JsonHelper.GetModel<T>(result);
            }
            catch {
                return null;
            }
        }
        public string getList(string key, long index, int dbNum = 10) {
            RedisValue value = getDB(dbNum).ListGetByIndex(key, index);
            return (value.IsNullOrEmpty) ? "" : value.ToString();
        }

        public long GetLstLen(string key, int dbNum) {
            return getDB(dbNum).ListLength(key);
        }


        public List<string> GetAllList(string key, int dbNum = 11) {
            RedisValue[] value = getDB(dbNum).ListRange(key);
            List<string> resLst = new List<string>();
            foreach (var item in value) {
                resLst.Add(item.ToString());
            }
            return resLst;
        }
        public void SetFaultValue(string sFkey, string value, int iIdx, int iDbNum) {
            try {
                getDB(iDbNum).StringSet(sFkey, value);
                SetLstValue("faultLst", sFkey, iIdx, iDbNum);
            }
            catch {

            }


        }
        /// <summary>
        /// 设置列表的值
        /// </summary>
        /// <param name="sLstkey"></param>
        /// <param name="iIdx"></param>
        /// <param name="sValue"></param>
        /// <param name="iDbNum"></param>
        public void SetLstValue(string sLstkey, string sValue, int iIdx, int iDbNum) {
            try {
                IDatabase idb = getDB(iDbNum);
                idb.ListSetByIndex(sLstkey, 0, iIdx);
                idb.ListRightPush(sLstkey, sValue);
            }
            catch {

            }
        }
        public void RightLstPush(string sLstkey, string sValue, int iDbNum) {
            getDB(iDbNum).ListRightPush(sLstkey, sValue);
        }

        #region 写入Redis
        public bool WriteValue(string key, string value, int dbNum) {
            return getDB(dbNum).StringSet(key, value);
        }
        #endregion
    }

}
