// RedisWriteTest.cpp : 此文件包含 "main" 函数。程序执行将在此处开始并结束。
//

#include "pch.h"
#include <iostream>
#include <string>
#include <vector>
#include <io.h>
#include "GlobalStrOp.h"
#include "RedisHelperDll.h"
#include <Windows.h>
#pragma comment(lib,"RedisHelper.lib")
using namespace std;


#pragma region 图像文件操作方法
typedef struct tjp_info {
	int outwidth;
	int outheight;
	unsigned long jpg_size;
}tjp_info_t;
//遍历文件夹，获取所有图片
void getFiles(string path, vector<string>& files) {
	//文件句柄  
	intptr_t   hFile = 0;
	//文件信息  
	struct _finddata_t fileinfo;
	string p;
	if ((hFile = _findfirst(p.assign(path).append("\\*").c_str(), &fileinfo)) != -1) {
		do {
			//如果是目录,迭代之  
			//如果不是,加入列表  
			if ((fileinfo.attrib &  _A_SUBDIR)) {
				if (strcmp(fileinfo.name, ".") != 0 && strcmp(fileinfo.name, "..") != 0)
					getFiles(p.assign(path).append("\\").append(fileinfo.name), files);
			}
			else {
				files.push_back(p.assign(path).append("\\").append(fileinfo.name));
			}
		} while (_findnext(hFile, &fileinfo) == 0);
		_findclose(hFile);
	}
}

/*读取文件到内存*/
unsigned char* read_file2buffer(const char *filepath, int&byteSize) {
	tjp_info_t tinfo;
	FILE *fd;
	struct stat fileinfo;
	stat(filepath, &fileinfo);
	tinfo.jpg_size = fileinfo.st_size;

	fopen_s(&fd, filepath, "rb");
	if (NULL == fd) {
		printf("file not open\n");
		return NULL;
	}

	byteSize = sizeof(unsigned char) * fileinfo.st_size;
	unsigned char *data = (unsigned char *)malloc(byteSize);
	fread(data, 1, fileinfo.st_size, fd);
	fclose(fd);
	return data;
}
#pragma endregion

//使用参数 ip地址，图片文件夹目录，相机编号
/**
**	例:exe 127.0.0.1   c;/test  2
*/

int main(int argc, char *argv[]) {

	if (argc < 4) return -1;
	//ip
	string sIpAddr = argv[1];
	cout << "ip:" << sIpAddr << endl;
	//文件夾目录
	string dirPath = argv[2];
	cout << "dirPath:" << dirPath << endl;
	//相机编号
	string sCamId = argv[3];
	cout << "sCamId:" << sCamId << endl;
	//读取间隔 
	int iSleepMS = stoi(argv[4]);
	cout << "iSleepMS:" << iSleepMS << endl;
	//读取图像 
	vector<string> vecAllFiles;
	getFiles(dirPath, vecAllFiles);
	void* pDb = OpenDb(sIpAddr.c_str(), 3);
	cout << "图像数量" << vecAllFiles.size() << endl;
	long x = 0;
	while (true) {
		++x;
		for (size_t i = 0; i < vecAllFiles.size(); ++i) {
			//------ 写入图像数据 ------
			string imgFullName = vecAllFiles[i];
			string imgNameNoExt = GetFileNameNoExt(imgFullName);
			//分割图像
			vector<string> strInfo = Split_c(imgNameNoExt, '_');
			if (strInfo[4] != sCamId)
				continue;
			int imgSize = 0;
			string sJson = "{\"TIM\":1" + strInfo[0] + ", \"KMV\":\"" + strInfo[1] + "\",\"POL\":\"" + strInfo[2] + "\", \"CID\":" + strInfo[4] + "}";
			//cout << "sJson" << sJson  << endl;
			unsigned char* imgContent = read_file2buffer(imgFullName.c_str(), imgSize);

			long long int imgGuid = stoll(to_string(x) + strInfo[0] + strInfo[4]);
			cout <<"imgGuid"<<imgGuid << endl;
			bool isScu = WriteImg(pDb, imgGuid, imgContent, imgSize, sJson.c_str());
			cout << "WriteImg" << isScu << endl;

			sJson = "{\"seg\":[{\"Fault\":[0],\"ID\":79,\"mark\":[4342,3744,454,487],\"unitId\":806},{\"Fault\":[-1],\"ID\":80,\"mark\":[4181,2740,286,450],\"unitId\":798},{\"Fault\":[-1],\"ID\":81,\"mark\":[386,3447,942,892],\"unitId\":796},{\"Fault\":[0],\"ID\":82,\"mark\":[4045,2946,504,919],\"unitId\":805},{\"Fault\":[0],\"ID\":83,\"mark\":[4663,3979,702,842],\"unitId\":805}]}";
			isScu = WriteFault(pDb, imgGuid, (char*)sJson.c_str());
			cout << "WriteFault" << isScu << endl;
			free(imgContent);//释放内存资源

			Sleep(iSleepMS); //可以修改这个值 实际生产过程中可以
			//cout << strInfo[0] + "_" + strInfo[4] << " Write seccuss!" << endl;
			// ++imgGuid;
		}
	}
	CloseDb(pDb);
}

