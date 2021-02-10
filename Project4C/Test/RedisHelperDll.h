/************************************************************
 * File:   RedisHelper.h
 * Author: Zhong Jian<77367632@qq.com>
 * Content:
		  dll 接口/调用类
 * Created on 2019年6月
 *************************************************************/
#pragma once
#include <string>
#ifndef IMGDBHELPER_H
#define IMGDBHELPER_H
#ifdef IMGDBHELPER_API_DU 
#define IMGDBHELPER_API_DU _declspec(dllexport)
#else
#define DBHELPER_API __declspec(dllimport)
#endif                                    
using namespace std;

#ifdef __cplusplus
extern "C" {
#endif	/* __cplusplus */
	/**
	** 打开数据库，返回数据库对象。
	** addrIp:		数据库服务器IP地址
	** iTimeout:	连接超时设置 默认 3秒
	** iPort:		数据库服务器端口号默认 6379
	*/
	DBHELPER_API  void* OpenDb(const char* addrIp, int iTimeout =3 ,int iPort= 6379 );

	DBHELPER_API  bool CloseDb(void* pDb);

	/**
	** 写入图像信息
	** imgGuid int64:	拍照时间+相机编号  190707152356123 + 02
	** imgContent:		图像内容
	** imgSize:			图像大小
	** sJsonImgInfo:	图像信息 json格式{"ShootTime":"011136618",//时间  "KMValue": "K3213147",//公里标;"CamNo": "30",//相机编号; "PoleNum": "1746"// 杆号}	
	*/
	DBHELPER_API  bool WriteImg(void* pDb, long long int imgGuid, unsigned char * imgContent, int imgSize, const char* sJsonImgInfo);
	
	/**
	** 写入缺陷信息
	** imgGuid int64:	拍照时间+相机编号  190707152356123 + 02
	** sJsonImgInfo:	缺陷内容json格式
	*/
	DBHELPER_API  bool WriteFault(void* pDb,long long int imgGuid,char* sJsonFault);

	DBHELPER_API  const char* GetErrInfo();

#ifdef __cplusplus
}
#endif  /* __cplusplus */
#endif