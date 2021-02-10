#pragma once
#include <iostream>
#include <stdio.h>
#include <stdlib.h>
#include <string> 
//#include <WinSock2.h>
#include "lib64/hiredis.h" //ͷ�ļ������ļ����·���ı�
#define x86
#ifdef  x86
#pragma comment(lib,"lib32/hiredis.lib")
#pragma comment(lib,"lib32/Win32_Interop.lib")
#pragma comment(lib, "lib32/ws2_32.lib")
#else
#pragma comment(lib,"lib64/hiredis.lib")
#pragma comment(lib,"lib64/Win32_Interop.lib")
#pragma comment(lib, "ws2_32.lib") 
#endif



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
	int iGeoDbId = 9;
	int iImgDbId = 10;		//ͼ������ƴ洢���ݿ�Id
	int iImgInfoDbId = 11;  //ͼ����Ϣ���ݿ�Id
	int iAIFaultDbId = 12;	//����ʶ��ȱ�����ݿ�Id
	
public:
	bool isConnction;
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
	//Singleton
	static RedisHelper *getInstance() { //2.�ṩȫ�ַ��ʵ�
		static RedisHelper m_singletonConfig; //3.c++11��֤�˶��̰߳�ȫ�������˳�ʱ���ͷ���Դ
		return &m_singletonConfig;
	}


	/*
	** д��ͼ������
	** ������ͼƬȫ��id,ͼ�����ݣ�ͼ���С
	*/
	bool WriteImg(long long int imgGUID, unsigned char* imgContent, int imgSize);
	bool WriteImgInfo(long long int imgGUID, const char* sJsonInfo);
	bool WriteFaultInfo(long long int imgGUID, const char* sJsonFault);
	bool WriteGeoInfo(long long iKey, const char* sJsonGeoInfo);

	/*
	** ��Redis���ݿ�
	*/
	bool OpenDb(const char* addrIp, int iTimeout, int  port);
	////�ر�����
	void CloseDb();
};

