#pragma once

/************************************************************
 * File:   rpcdll.h
 * Author: meckyxu
 * Content:
		  dll 接口/调用类
 * Created on 2019年11月
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
	** 打开RPC对象，返回数据库对象。
	** addrIp:		数据库服务器IP地址
	** iTimeout:	连接超时设置 默认 3秒
	** iPort:		数据库服务器端口号默认 6379
	*/
	GWDLL_API  void* OpenRPC(const char* addrIp, int iPort = 6379);
	/**
	** 关闭RPC对象，。
	** pRPC:		需要关闭的RPC对象
	*/
	GWDLL_API  void CloseRPC(void* pRPC);
	/**
	** 设定相机对应的参数。
	** pRPC:		RPC对象
	** iCameraID:	RPC对象绑定的相机，默认是0
	** strJsonCommand：RPC命令
	("Gain")("Exposure")("FocusMinus")("FocusPlus")("LEDWidth")("EnableLED")("FrameRate")("TriggerMode")
	("MoveUp")("MoveDown")("MoveLeft")("MoveRight")("MoveStop")("MoveTo")("SetPos")("RemovePos")("ShutDown") ("Restart"))
	*/
	GWDLL_API  bool SetRPCParam(void* pRPC,int iCameraID,const char* strJsonCommand);
	//return json data
	/**
	** 设定相机对应的参数。
	** pRPC:		RPC对象
	** iCameraID:	RPC对象绑定的相机，默认是0
	*/
	GWDLL_API  const char* GetRpcInfo(void* pRPC, int iCameraID);
	/**
	** 设定相机对应的参数。
	** pRPC:		RPC对象
	** iCameraID:	RPC对象绑定的相机，默认是0
	** char* pImageData 事先分配好得图像内存数据
	**  内存结构： pImageData+0->4 iWidth
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
