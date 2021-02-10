#pragma once
#include<string>
#ifndef DLL_H
#define DLL_H
#ifdef DLL_API_INFO 
#define DLL_API_INFO _declspec(dllexport)
#else
#define DLL_API __declspec(dllimport)
#endif     
using namespace std;

#ifdef __cplusplus
extern "C"
{
#endif	/* __cplusplus */

	/**
	**  初始化的工作，比如载入参数文件
	**  param_file_dir: 参数文件 cfg.txt 所在的目录，比如：C:/Users/hehai/source/repos/zmq_client_using_dll/params, params是一个文件夹名字，内含cfg.txt这个参数文件；
	**  cfg.txt 为配置文件，其中[ubuntu_server]为我方linux系统的信息，包含ip地址和端口；[debug_mode]为debug模式，true状况：会输出很多信息；fals：输出信息会变少，主要方便调试用
	**  返回值：true则为载入成功，false 则为失败；
	*/
	DLL_API bool init(string param_file_dir);

	/**
	**  打开ubuntu服务器上的算法模块
	**  返回值：int 型，数值1：打开成功；
	**  返回值：int 型，数值3：算法模块已打开，请求open的指令无效；
	**  返回值：int 型，数值0：打开失败；
	*/
	DLL_API int openAlgoModule();

	/**
	**  关闭ubuntu服务器上的算法模块
	**  返回值：int 型，数值2：关闭成功；
	**  返回值：int 型，数值4：算法模块已关闭，请求close的指令无效；
	**  返回值：int 型，数值0：关闭失败；
	*/
	DLL_API int closeAlgoModule();

	/**
	**  获取算法模块的一些信息，比如CPU、GPU、分析图片数量等信息，暂未开发，后续会补充和完善
	*/
	DLL_API string getAlgoModuleInfo();

#ifdef __cplusplus
}

#endif  /* __cplusplus */
#endif