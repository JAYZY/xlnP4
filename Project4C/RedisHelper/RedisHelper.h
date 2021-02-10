#pragma once
#include <iostream>
#include <stdio.h>
#include <stdlib.h>
#include <string> 
//#include <WinSock2.h>
#include "lib64/hiredis.h" //头文件跟随文件存放路径改变
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
	const char* ServerAddr = "127.0.0.1"; //可以修改该地址	
	int iPort = 6379;
	int iTimeout = 3;
	int iGeoDbId = 9;
	int iImgDbId = 10;		//图像二进制存储数据库Id
	int iImgInfoDbId = 11;  //图像信息数据库Id
	int iAIFaultDbId = 12;	//智能识别缺陷数据库Id
	
public:
	bool isConnction;
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
	//Singleton
	static RedisHelper *getInstance() { //2.提供全局访问点
		static RedisHelper m_singletonConfig; //3.c++11保证了多线程安全，程序退出时，释放资源
		return &m_singletonConfig;
	}


	/*
	** 写入图像数据
	** 参数，图片全局id,图像内容，图像大小
	*/
	bool WriteImg(long long int imgGUID, unsigned char* imgContent, int imgSize);
	bool WriteImgInfo(long long int imgGUID, const char* sJsonInfo);
	bool WriteFaultInfo(long long int imgGUID, const char* sJsonFault);
	bool WriteGeoInfo(long long iKey, const char* sJsonGeoInfo);

	/*
	** 打开Redis数据库
	*/
	bool OpenDb(const char* addrIp, int iTimeout, int  port);
	////关闭连接
	void CloseDb();
};

