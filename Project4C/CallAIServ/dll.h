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
	**  ��ʼ���Ĺ�����������������ļ�
	**  param_file_dir: �����ļ� cfg.txt ���ڵ�Ŀ¼�����磺C:/Users/hehai/source/repos/zmq_client_using_dll/params, params��һ���ļ������֣��ں�cfg.txt��������ļ���
	**  cfg.txt Ϊ�����ļ�������[ubuntu_server]Ϊ�ҷ�linuxϵͳ����Ϣ������ip��ַ�Ͷ˿ڣ�[debug_mode]Ϊdebugģʽ��true״����������ܶ���Ϣ��false�������Ϣ����٣���Ҫ���������
	**  ����ֵ��true��Ϊ����ɹ���false ��Ϊʧ�ܣ�
	*/
	DLL_API bool init(string param_file_dir);

	/**
	**  ��ʼ���Ĺ���
	**  ip: zmqָ����շ�������ip��ַ��
	**  port��zmqָ����շ������Ķ˿ںţ�
	**  ����ֵ��true��Ϊ�ɹ���false ��Ϊʧ�ܣ�
	*/
	DLL_API bool init(string ip, int port);

	/**
	**  ��ʼ���Ĺ���
	**  ip: zmqָ����շ�������ip��ַ��
	**  port��zmqָ����շ������Ķ˿ںţ�
	**  debug: �Ƿ����������Ϣ��
	**  ����ֵ��true��Ϊ�ɹ���false ��Ϊʧ�ܣ�
	*/
	DLL_API bool init(string ip, int port, bool debug);

	/**
	**  ��ubuntu�������ϵ��㷨ģ��
	**  server_redis_ip: redis ��������ip��ַ
	**  server_redis_port: redis �������Ķ˿�
	**  img_db_id: ���ͼ�����ݵ�db���
	**  img_key_db_id: ���ͼ��ID��db���
	**  save_results_db_id����������db���
	**  img_key_name: ���ͼ��ID���б�����
	**  ����ֵ��int �ͣ���ֵ1���򿪳ɹ���
	**  ����ֵ��int �ͣ���ֵ3���㷨ģ���Ѵ򿪣�����open��ָ����Ч��
	**  ����ֵ��int �ͣ���ֵ0����ʧ�ܣ�
	*/
	DLL_API int openAlgoModule(string server_redis_ip, int server_redis_port, int img_db_id, int img_key_db_id, int save_results_db_id, string img_key_name);

	/**
	**  �ر�ubuntu�������ϵ��㷨ģ��
	**  ����ֵ��int �ͣ���ֵ2���رճɹ���
	**  ����ֵ��int �ͣ���ֵ4���㷨ģ���ѹرգ�����close��ָ����Ч��
	**  ����ֵ��int �ͣ���ֵ0���ر�ʧ�ܣ�
	*/
	DLL_API int closeAlgoModule();
	/*
	** ��ȡ����final_sys4c_live��CPU���ڴ��ʹ���ʣ�GPU���¶ȣ�ʹ�����Լ�ͼƬ��������
	** ����ֵ��string �� ��תjson��string�ַ�����
	*/
	DLL_API string getAlgoInfo();

	//**  ���˿��Ƿ�ռ��
	//**  check_port: ��Ҫ���Ķ˿�
	//**  ����ֵ bool  �ͣ����� true: ��ʾ�˿�ռ��;
	//**  ����ֵ bool  �ͣ����� false: ��ʾ�˿�δ��ռ��;
	//*/

	DLL_API bool CheckPortOccupancy(long long check_port);

#ifdef __cplusplus
}

#endif  /* __cplusplus */
#endif