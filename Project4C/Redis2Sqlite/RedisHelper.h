#pragma once
#include <iostream>
#include <stdio.h>
#include <stdlib.h>
#include <string> 
#include "hiredis.h" //头文件跟随文件存放路径改变

#pragma comment(lib,"hiredis.lib")
#pragma comment(lib,"Win32_Interop.lib")
#pragma comment(lib, "ws2_32.lib") 
using namespace std;
class RedisHelper
{
public:
	RedisHelper();
	~RedisHelper();

private:
	static redisContext *redis;
	const char* ServerAddr = "127.0.0.1"; //可以修改该地址	
	int iPort = 6379;
	int iTimeout = 3;
	bool isConnction;
	int iImgDbId = 10;		//图像二进制存储数据库Id
	int iImgInfoDbId = 11;  //图像信息数据库Id
	int iAIFaultDbId = 12;	//智能识别缺陷数据库Id

	char chErr[1024];
	inline const char* GetErrTip() { return chErr; }
#pragma region RedisDb配置信息
	//服务器地址
	inline void SetServerIP(const char* ipAddr) { ServerAddr = ipAddr; }
	//智能识别缺陷数据库Id
	inline void SetFaultDbId(int id) { iAIFaultDbId = id; }
	//图像二进制存储数据库Id
	inline void SetImgDbId(int id) { iImgDbId = id; }
	//图像信息数据库Id
	inline void SetImgInfoDbId(int id) { iImgInfoDbId = id; }

#pragma endregion
	//选择数据库ID
	bool SelectDb(string sImgDbId) {
		if (!isConnction) {
			OpenDb(ServerAddr, iTimeout, iPort);
		}
		if (isConnction) {
			redisReply *replyImg = (redisReply *)redisCommand(redis, ("select " + sImgDbId).c_str());
			if (replyImg) {
				freeReplyObject(replyImg);
			}
			if (nullptr == redis || redis->err != 0) {
				sprintf(chErr, "select Db %s err", sImgDbId.c_str());
				isConnction = false;
			}
		}
		return isConnction;
	}

	//获取图像数据
	unsigned char* GetImgData(int64_t&iSaveImgGUID, int&imgSize) {
		unsigned char* imgData = nullptr;
		if (!isConnction) {
			OpenDb(ServerAddr, iTimeout, iPort);
		}
		if (isConnction) {
			redisReply *replyImg = (redisReply *)redisCommand(redis, "GET %lld", iSaveImgGUID);
			if (replyImg == NULL || 0 == replyImg->len) {
				sprintf(chErr, "img %lld get error!", iSaveImgGUID);//			printf("图像 %lld 获取失败!\n", iSaveImgGUID);
				if (replyImg)
					freeReplyObject(replyImg);
				if (nullptr == redis || redis->err != 0) {
					sprintf(chErr, "select Db  err");
					isConnction = false;
				}
			}
			imgData = (unsigned char*)replyImg->element;
			imgSize = replyImg->len;
		}
		return imgData;
	}

	/*
** 打开Redis数据库
*/
	bool OpenDb(const char* addrIp, int iTimeout, int  port);
	////关闭连接
	void CloseDb();
};

