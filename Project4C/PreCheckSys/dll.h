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
	**  ��ʼ���Ĺ�����������������ļ�
	**  param_file_dir: �����ļ� cfg.txt ���ڵ�Ŀ¼�����磺C:/Users/hehai/source/repos/zmq_client_using_dll/params, params��һ���ļ������֣��ں�cfg.txt��������ļ���
	**  cfg.txt Ϊ�����ļ�������[ubuntu_server]Ϊ�ҷ�linuxϵͳ����Ϣ������ip��ַ�Ͷ˿ڣ�[debug_mode]Ϊdebugģʽ��true״����������ܶ���Ϣ��fals�������Ϣ����٣���Ҫ���������
	**  ����ֵ��true��Ϊ����ɹ���false ��Ϊʧ�ܣ�
	*/
	DLL_API bool init(string param_file_dir);

	/**
	**  ��ubuntu�������ϵ��㷨ģ��
	**  ����ֵ��int �ͣ���ֵ1���򿪳ɹ���
	**  ����ֵ��int �ͣ���ֵ3���㷨ģ���Ѵ򿪣�����open��ָ����Ч��
	**  ����ֵ��int �ͣ���ֵ0����ʧ�ܣ�
	*/
	DLL_API int openAlgoModule();

	/**
	**  �ر�ubuntu�������ϵ��㷨ģ��
	**  ����ֵ��int �ͣ���ֵ2���رճɹ���
	**  ����ֵ��int �ͣ���ֵ4���㷨ģ���ѹرգ�����close��ָ����Ч��
	**  ����ֵ��int �ͣ���ֵ0���ر�ʧ�ܣ�
	*/
	DLL_API int closeAlgoModule();

	/**
	**  ��ȡ�㷨ģ���һЩ��Ϣ������CPU��GPU������ͼƬ��������Ϣ����δ�����������Ჹ�������
	*/
	DLL_API string getAlgoModuleInfo();

#ifdef __cplusplus
}

#endif  /* __cplusplus */
#endif