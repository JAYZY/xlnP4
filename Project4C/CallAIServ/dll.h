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
extern "C++"
{
#endif	/* __cplusplus */


	/**
	**  初始化的工作，比如载入参数文件
	**  param_file_dir: 参数文件 cfg.txt 所在的目录，比如：C:/Users/hehai/source/repos/zmq_client_using_dll/params, params是一个文件夹名字，内含cfg.txt这个参数文件；
	**  cfg.txt 为配置文件，其中[ubuntu_server]为我方linux系统的信息，包含ip地址和端口；[debug_mode]为debug模式，true状况：会输出很多信息；false：输出信息会变少，主要方便调试用
	**  返回值：true则为载入成功，false 则为失败；
	*/
	DLL_API bool init(string param_file_dir);

	/**
	**  初始化的工作
	**  ip: zmq指令接收服务器的ip地址；
	**  port：zmq指令接收服务器的端口号；
	**  返回值：true则为成功，false 则为失败；
	*/
	DLL_API bool init(string ip, int port);

	/**
	**  初始化的工作
	**  ip: zmq指令接收服务器的ip地址；
	**  port：zmq指令接收服务器的端口号；
	**  debug: 是否输出调试信息；
	**  返回值：true则为成功，false 则为失败；
	*/
	DLL_API bool init(string ip, int port, bool debug);

	/**
	**  打开ubuntu服务器上的算法模块
	**  server_redis_ip: redis 服务器的ip地址
	**  server_redis_port: redis 服务器的端口
	**  img_db_id: 存放图像数据的db编号
	**  img_key_db_id: 存放图像ID的db编号
	**  save_results_db_id：保存结果的db编号
	**  img_key_name: 存放图像ID的列表名称
	**  返回值：int 型，数值1：打开成功；
	**  返回值：int 型，数值3：算法模块已打开，请求open的指令无效；
	**  返回值：int 型，数值0：打开失败；
	*/
	DLL_API int openAlgoModule(string server_redis_ip, int server_redis_port, int img_db_id, int img_key_db_id, int save_results_db_id, string img_key_name);

	/**
	**  关闭ubuntu服务器上的算法模块
	**  返回值：int 型，数值2：关闭成功；
	**  返回值：int 型，数值4：算法模块已关闭，请求close的指令无效；
	**  返回值：int 型，数值0：关闭失败；
	*/
	DLL_API int closeAlgoModule();
	/*
	** 获取程序：final_sys4c_live的CPU，内存的使用率，GPU的温度，使用率以及图片的数量；
	** 返回值：string 型 可转json的string字符串；
	*/
	DLL_API string getAlgoInfo();

	//**  检查端口是否被占用
	//**  check_port: 需要检查的端口
	//**  返回值 bool  型，数据 true: 表示端口占用;
	//**  返回值 bool  型，数据 false: 表示端口未被占用;
	//*/

	DLL_API bool CheckPortOccupancy(long long check_port);

#ifdef __cplusplus
}

#endif  /* __cplusplus */
#endif