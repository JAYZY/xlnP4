--1.表的结构
-- 总表 mainTB 每次分表的时候 才Open   
	--- 分表1  根据图像数量来分表 	
	--- 分表2
--2.总表中记录的内容
	--a.  记录所有的缺陷信息 faultInfo
	create table indexTB
	(
		id int primary key , --表编号
		begImgGUID INT64,
		endImgGUID INT64,
		begPoleNum varchar(50),
		endPoleNum varchar(50),
		begKMV varchar(50),
		endKMV varchar(50),
		imgCount  int , --  统计有多少图像
		locFaultInfo int -- 统计有多少定位
	);
	CREATE TABLE stationInfo
	(
		sId INTEGER PRIMARY KEY AUTOINCREMENT,
		sLineName varchar(50),
		sStartStation varchar(50),
		sEndStation varchar(50),
		sType tinyint,taskDate DATE
	);
