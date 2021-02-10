/************************************************************
 * File:   RedisHelper.h
 * Author: Zhong Jian<77367632@qq.com>
 * Content:
		  dll �ӿ�/������
 * Created on 2019��6��
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
	** �����ݿ⣬�������ݿ����
	** addrIp:		���ݿ������IP��ַ
	** iTimeout:	���ӳ�ʱ���� Ĭ�� 3��
	** iPort:		���ݿ�������˿ں�Ĭ�� 6379
	*/
	DBHELPER_API  void* OpenDb(const char* addrIp, int iTimeout =3 ,int iPort= 6379 );

	DBHELPER_API  bool CloseDb(void* pDb);

	/**
	** д��ͼ����Ϣ
	** imgGuid int64:	����ʱ��+������  190707152356123 + 02
	** imgContent:		ͼ������
	** imgSize:			ͼ���С
	** sJsonImgInfo:	ͼ����Ϣ json��ʽ{"ShootTime":"011136618",//ʱ��  "KMValue": "K3213147",//�����;"CamNo": "30",//������; "PoleNum": "1746"// �˺�}	
	*/
	DBHELPER_API  bool WriteImg(void* pDb, long long int imgGuid, unsigned char * imgContent, int imgSize, const char* sJsonImgInfo);
	
	/**
	** д��ȱ����Ϣ
	** imgGuid int64:	����ʱ��+������  190707152356123 + 02
	** sJsonImgInfo:	ȱ������json��ʽ
	*/
	DBHELPER_API  bool WriteFault(void* pDb,long long int imgGuid,char* sJsonFault);

	DBHELPER_API  const char* GetErrInfo();

#ifdef __cplusplus
}
#endif  /* __cplusplus */
#endif