#include "RedisHelper.h"
#include <assert.h>
#include <WInSock.h>

redisContext *RedisHelper::redis = nullptr;

RedisHelper::RedisHelper() {
	isConnction = false;
}


RedisHelper::~RedisHelper() {
	CloseDb();
}

bool RedisHelper::WriteImg(long long int imgGuid, unsigned char * imgContent, int imgSize) {

	bool isSucc = false;
	if (!isConnction) {
		OpenDb(this->ServerAddr, this->iTimeout, this->iPort);
	}
	if (isConnction) {
		try {
			redisReply *reply = NULL;
			//------ д��ͼ������ to ͼ��DB-----
			std::string strSel = "SELECT  " + std::to_string(this->iImgDbId);
			reply = (redisReply *)redisCommand(redis, strSel.c_str()); //ѡ��ͼ�����ݿ� 
			if (reply) {
				freeReplyObject(reply);
			}
			reply = (redisReply *)redisCommand(redis, "SET  %lld %b", imgGuid, imgContent, (size_t)imgSize);
			if (reply) {
				freeReplyObject(reply);
			}
			if (nullptr == redis || 0 != redis->err) {
				isConnction = false;
				isSucc = false;
			}
			else {
				//--- д�� list ��Ϣ
				printf("%lld inserted success��: %s\n", imgGuid, reply->str);
				//------ д��ͼ���ȫ��ID���� to ͼ����ϢDB------
				reply = NULL;
				strSel = "SELECT  " + std::to_string(this->iImgInfoDbId);
				reply = (redisReply *)redisCommand(redis, strSel.c_str()); //ѡ��ͼ��info
				if (reply) {
					freeReplyObject(reply);
				}
				reply = (redisReply *)redisCommand(redis, "rpush  list %lld", imgGuid);
				if (nullptr == redis || 0 != redis->err) {
					isConnction = false;
					isSucc = false;
				}
				else {
					printf("List inserted success��: %lld\n", imgGuid);
					if (reply) {
						freeReplyObject(reply);
					}
					isSucc = true;
				}
			}
		}
		catch (...) {
			sprintf(chErr, "Image Write Error!");
			isConnction = false;
			isSucc = false;
		}
	}
	return	isSucc;

}

bool RedisHelper::WriteImgInfo(long long int imgGuid, const char * sJsonInfo) {
	bool isSucc = false;
	if (!isConnction) {
		OpenDb(this->ServerAddr, this->iTimeout, this->iPort);
	}
	if (isConnction) {
		try {
			redisReply *reply = NULL;
			//------ д��ͼ���ȫ��ID���� to ͼ����ϢDB------
			std::string strSel = "SELECT  " + std::to_string(this->iImgInfoDbId);
			reply = (redisReply *)redisCommand(redis, strSel.c_str()); //ѡ��ͼ��infoDb
			if (reply)
				freeReplyObject(reply);
			if (nullptr == redis || 0 != redis->err) {
				isConnction = false;
				isSucc = false;
			}
			else {
				reply = (redisReply *)redisCommand(redis, "SET %lld %s", imgGuid, sJsonInfo);
				if (reply) {
					freeReplyObject(reply);
				}
				if (nullptr == redis || 0 != redis->err) {
					isConnction = false;
					isSucc = false;
				}
				else {
					isSucc = true;
				}
			}
		}
		catch (const std::exception&msg) {
			sprintf(chErr, "ImgInfo Write Error!\n %s", msg.what());
			isConnction = false;
			isSucc = false;
		}
	}
	return isSucc;
}

bool RedisHelper::WriteFaultInfo(long long int imgGuid, const char * sJsonFault) {
	bool isSucc = false;
	if (!isConnction) {
		OpenDb(this->ServerAddr, this->iTimeout, this->iPort);
		printf("OpenDB again\n");
	}
	if (isConnction) {
		try {
			redisReply *reply = NULL;
			printf("input str: %s\n", sJsonFault);
			//------ д��ͼ���ȫ��ID���� to ȱ�����ݿ�------
			std::string strSel = "SELECT  " + std::to_string(this->iAIFaultDbId);
			reply = (redisReply *)redisCommand(redis, strSel.c_str()); //ѡ��ȱ��Db 			
			printf("Select Data success %d", this->iAIFaultDbId);
			freeReplyObject(reply);
			reply = (redisReply *)redisCommand(redis, "SET %lld %s", imgGuid, sJsonFault);
			printf("%lld inserted successed��: %s\n", imgGuid, reply->str);
			freeReplyObject(reply);
			//--- д�� list ��Ϣ
			reply = (redisReply *)redisCommand(redis, "rpush  list %lld", imgGuid);
			if (nullptr == redis || 0 != redis->err) {
				isConnction = false;
				isSucc = false;
			}
			else {
				printf("Fault List inserted success��: %lld\n", imgGuid);
				if (reply) {
					freeReplyObject(reply);
				}
				isSucc = true;
			}
		}
		catch (const std::exception& msg) {
			sprintf(chErr, "FaultInfo Write Error!\n %s", msg.what());
			isConnction = false;
			isSucc = false;
		}

	}
	return isSucc;
}

bool RedisHelper::WriteGeoInfo(long long imgGuid, const char* sJsonGeoInfo) {
	bool isSucc = false;
	if (!isConnction) {
		OpenDb(this->ServerAddr, this->iTimeout, this->iPort);
		printf("OpenDB again\n");
	}
	if (isConnction) {
		try {
			redisReply *reply = NULL;
			printf("input str: %s\n", sJsonGeoInfo);
			//------ д��ͼ���ȫ��ID���� to ȱ�����ݿ�------
			std::string strSel = "SELECT  " + std::to_string(this->iGeoDbId);
			reply = (redisReply *)redisCommand(redis, strSel.c_str()); //ѡ��ȱ��Db 			
			printf("Select Data success %d", this->iGeoDbId);
			freeReplyObject(reply);
			reply = (redisReply *)redisCommand(redis, "SET %lld %s", imgGuid, sJsonGeoInfo);
			printf("%lld inserted successed��: %s\n", imgGuid, reply->str);
			freeReplyObject(reply);
			//--- д�� list ��Ϣ
			reply = (redisReply *)redisCommand(redis, "rpush  geoLst %lld", imgGuid);
			if (nullptr == redis || 0 != redis->err) {
				isConnction = false;
				isSucc = false;
			}
			else {
				printf("Fault geoLst inserted success��: %lld\n", imgGuid);
				if (reply) {
					freeReplyObject(reply);
				}
				isSucc = true;
			}
		}
		catch (const std::exception& msg) {
			sprintf(chErr, "FaultInfo Write Error!\n %s", msg.what());
			isConnction = false;
			isSucc = false;
		}

	}
	return isSucc;
}

/*
** ����redis������
*/
bool RedisHelper::OpenDb(const char* addrIp, int iTimeout, int port) {
	if (isConnction) {
		assert(redis);
		return true;
	}
	if (addrIp == nullptr || addrIp == "") {
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

	if (redis == NULL || redis->err) {
		if (redis) {
			sprintf(chErr, "OpenDB Error: %s\n", redis->errstr);
			printf("Error: %s\n", redis->errstr);
		}
		else {
			sprintf(chErr, "Can't allocate redis context\n");
			printf("Can't allocate redis context\n");
		}
		isConnction = false;
	}
	else {
		printf("Connect Successed!");
		isConnction = true;

	}

	return isConnction;
}

void RedisHelper::CloseDb() {
	if (!isConnction) {
		assert(!redis);
	}
	else if (redis) {
		redisFree(redis);
		redis = nullptr;
		isConnction = false;
	}
};

