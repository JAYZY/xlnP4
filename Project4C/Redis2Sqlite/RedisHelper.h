#pragma once
#include <iostream>
#include <stdio.h>
#include <stdlib.h>
#include <string> 
#include "hiredis.h" //ͷ�ļ������ļ����·���ı�

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
	const char* ServerAddr = "127.0.0.1"; //�����޸ĸõ�ַ	
	int iPort = 6379;
	int iTimeout = 3;
	bool isConnction;
	int iImgDbId = 10;		//ͼ������ƴ洢���ݿ�Id
	int iImgInfoDbId = 11;  //ͼ����Ϣ���ݿ�Id
	int iAIFaultDbId = 12;	//����ʶ��ȱ�����ݿ�Id

	char chErr[1024];
	inline const char* GetErrTip() { return chErr; }
#pragma region RedisDb������Ϣ
	//��������ַ
	inline void SetServerIP(const char* ipAddr) { ServerAddr = ipAddr; }
	//����ʶ��ȱ�����ݿ�Id
	inline void SetFaultDbId(int id) { iAIFaultDbId = id; }
	//ͼ������ƴ洢���ݿ�Id
	inline void SetImgDbId(int id) { iImgDbId = id; }
	//ͼ����Ϣ���ݿ�Id
	inline void SetImgInfoDbId(int id) { iImgInfoDbId = id; }

#pragma endregion
	//ѡ�����ݿ�ID
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

	//��ȡͼ������
	unsigned char* GetImgData(int64_t&iSaveImgGUID, int&imgSize) {
		unsigned char* imgData = nullptr;
		if (!isConnction) {
			OpenDb(ServerAddr, iTimeout, iPort);
		}
		if (isConnction) {
			redisReply *replyImg = (redisReply *)redisCommand(redis, "GET %lld", iSaveImgGUID);
			if (replyImg == NULL || 0 == replyImg->len) {
				sprintf(chErr, "img %lld get error!", iSaveImgGUID);//			printf("ͼ�� %lld ��ȡʧ��!\n", iSaveImgGUID);
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
** ��Redis���ݿ�
*/
	bool OpenDb(const char* addrIp, int iTimeout, int  port);
	////�ر�����
	void CloseDb();
};

