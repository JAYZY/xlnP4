#include "pch.h"
#include "RedisHelper.h"
#include <assert.h>
#include <WInSock.h>
RedisHelper::RedisHelper()
{
}


RedisHelper::~RedisHelper()
{
}
bool RedisHelper::OpenDb(const char* addrIp, int iTimeout, int port)
{
	if (isConnction)
	{
		assert(redis);
		return true;
	}
	if (addrIp == nullptr || addrIp == "")
	{
		return false;
	}
	this->ServerAddr = addrIp;
	this->iPort = port;
	this->iTimeout = iTimeout;

	struct timeval tv;
	tv.tv_sec = iTimeout / 1000;
	tv.tv_usec = (iTimeout % 1000) * 1000;
	if (redis) {
		redisFree(redis);
		redis = nullptr;
	}
	redis = redisConnectWithTimeout(this->ServerAddr, port, tv);
	if (redis == NULL || redis->err)
	{
		if (redis)
		{
			sprintf(chErr, "OpenDB Error: %s\n", redis->errstr);
			printf("Error: %s\n", redis->errstr);
		}
		else
		{
			sprintf(chErr, "Can't allocate redis context\n");
			printf("Can't allocate redis context\n");
		}
		isConnction = false;
	}

	else
	{
		printf("connect successed!");
		isConnction = true;
	}

	return isConnction;
}

void RedisHelper::CloseDb()
{
	if (!isConnction) {
		assert(!redis);
	}
	else if (redis) {
		redisFree(redis);
		redis = nullptr;
		isConnction = false;
	}
};

