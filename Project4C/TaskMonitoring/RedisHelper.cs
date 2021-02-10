using StackExchange.Redis;

namespace TaskMonitoring {
    class RedisHelper {
        private readonly string _redisServerIp;
        private readonly object asyncState;
        private ConnectionMultiplexer redisClient;

        public RedisHelper(string svrIp) {

            asyncState = new object();            
            redisClient = ConnectionMultiplexer.Connect(svrIp);
            
        }

        public bool SetString(string key, string sValue, int dbNum) {
            try {

                IDatabase db = redisClient.GetDatabase(dbNum, asyncState);
                db.StringSet(key, sValue);

            }
            catch (System.Exception) {

                return false;
            }
            return true;
        }
    }
}
