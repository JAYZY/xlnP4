#pragma once

/************************************************************
 * File:   rpcdll.h
 * Author: meckyxu
 * Content:
		  dll �ӿ�/������
 * Created on 2019��11��
 *************************************************************/
#pragma once

#include <string>


#ifndef		CAMERARPCDLL_H
#define		CAMERARPCDLL_H

#ifdef GWDLL_EXPORTS
#define GWDLL_API __declspec(dllexport)
#else
#define GWDLL_API __declspec(dllimport)
#endif

using namespace std;

//#ifdef __cplusplus
//extern "C" {
//#endif	/* __cplusplus */
	/**
	** ��RPC���󣬷������ݿ����
	** addrIp:		���ݿ������IP��ַ
	** iTimeout:	���ӳ�ʱ���� Ĭ�� 3��
	** iPort:		���ݿ�������˿ں�Ĭ�� 6379
	*/
	GWDLL_API  void* OpenRPC(const char* addrIp, int iPort = 6379);
	/**
	** �ر�RPC���󣬡�
	** pRPC:		��Ҫ�رյ�RPC����
	*/
	GWDLL_API  void CloseRPC(void* pRPC);
	/**
	** �趨�����Ӧ�Ĳ�����
	** pRPC:		RPC����
	** iCameraID:	RPC����󶨵������Ĭ����0
	** strJsonCommand��RPC����
	("Gain")("Exposure")("FocusMinus")("FocusPlus")("LEDWidth")("EnableLED")("FrameRate")("TriggerMode")
	("MoveUp")("MoveDown")("MoveLeft")("MoveRight")("MoveStop")("MoveTo")("SetPos")("RemovePos")("ShutDown") ("Restart"))
	*/
	GWDLL_API  bool SetRPCParam(void* pRPC,int iCameraID,const char* strJsonCommand);
	//return json data
	/**
	** �趨�����Ӧ�Ĳ�����
	** pRPC:		RPC����
	** iCameraID:	RPC����󶨵������Ĭ����0
	*/
	GWDLL_API  const char* GetRpcInfo(void* pRPC, int iCameraID);
	/**
	** �趨�����Ӧ�Ĳ�����
	** pRPC:		RPC����
	** iCameraID:	RPC����󶨵������Ĭ����0
	** char* pImageData ���ȷ���õ�ͼ���ڴ�����
	**  �ڴ�ṹ�� pImageData+0->4 iWidth
		                     +4->8 iHeight,
							 +8->16 lTime
				   pImageData+16->end jpegdata
	*/
	GWDLL_API  int GetRpcImage(void* pRPC, int iCameraID, char* pImageData);

	GWDLL_API  const char* GetErrInfo(void* pRPC);

//#ifdef __cplusplus
//}
//#endif  /* __cplusplus */
#endif
