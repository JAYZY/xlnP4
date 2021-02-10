string strCreateImgTB = "CREATE TABLE picInfo(pId INTEGER PRIMARY KEY AUTOINCREMENT,
cId INTEGER,shootTime INTEGER,poleNum INTEGER,GPS INTEGER,sId INTEGER,imgContent BLOG);";


--传入的数据接口为 pId,img,strJSON
--对strJSON进行解析得到下表
   
      {
      
         "Fault" :  [0],
      
         "ID" :  24,
      
         "mark" :  [4079,756,500,482],
      
         "unitId" :  787
      
    },
 create table FaultRecode
(
	rid INTEGER primary key AUTOINCREMENT,
	pid INTEGER, --图像id
	uid INTEGER, --部件id	
	fid INTEGER, --缺陷ID	
	levelId  INTEGER, --等级ID
	analyzeDate DATETIME,--分析时间
	comfirmDate DATETIME,--确认时间
	OffsetX INTEGER NOT NULL,--标注X坐标
	OffsetY INTEGER NOT NULL,--标注Y坐标
	width INTEGER NOT NULL,  --标注宽
	height INTEGER NOT NULL,  --标注高
	rType smallint NOT NULL default 0,  --识别类型 0-人工 1-智能 
	demo TEXT  --JSON格式，uNume;"部件名称",uNume;"部件名称",fNume:"缺陷名称"
)
--图像信息（后期可以考虑单独存储图像，目前看来这种分表意义不太大）
--两种优化思路 1.按照相机编号进行水平分表；2将图像BLOG 字段单独垂直分表
CREATE TABLE picInfo
(
	pId INTEGER PRIMARY KEY AUTOINCREMENT, 
	shootTime INTEGER,  --照相时间
	cNum INTEGER,       --相机编号
	poleNum varchar(50),--杆号
	KMValue INTEGER ,   --公里标
	sId INTEGER,	    --线路ID
	areaType INTEGER,   --拍照区域
	imgContent BLOG
);


CREATE TABLE stationInfo(
	sId INTEGER PRIMARY KEY AUTOINCREMENT,  -- 线路id		
	sLineName varchar(50),						-- 线路名称
	sStartStation varchar(50),
	sEndStation varchar(50),
	sType tinyint,
	taskDate DATETIME NOT NULL
);

CREATE TABLE LoginTable(loginId INTEGER PRIMARY KEY AUTOINCREMENT, userName varchar(50),userPwd varchar(50));

Create table poleIndex(
	id INTEGER PRIMARY KEY AUTOINCREMENT, --记录索引号	
	pId INTEGER, -- 图像索引号 外码
	cId INTEGER, -- 相机索引号 
	frameNo INTEGER, -- 帧号
	poleNum varchar(50),--支柱号
	sName  varchar(50)--线路名称
)

create table FaultInfo(
	   pId  INT64 primary key ,			--缺陷Id
	   imgGUID INT64,					--图像全局ID	   
       unitId int,						--部件ID       					
       fault varchar(255),			    --缺陷Mark的json语句
	   mark varchar(255),				--缺陷类型ID的json语句

       faultLevel  varchar(5),			--缺陷等级
	   isAI BOOLEAN int default 1, 		--是否为智能分析
	   analyzeDate datetime 
	   NOT NULL DEFAULT (datetime('now','localtime')),			--智能分析产生缺陷的时间       
	   confirmDate datetime,			--缺陷确定时间
       confirmUser varchar(50),			--缺陷确定人员
       confirmResult int default -1,				--确定是否为缺陷 -1 unknown 0 误判 1 确定
       memo	varchar(100) 				--备注信息
	   
);

//创建被处理过的图片信息
 create table  processedInfo
 (
    pInfoId INTEGER primary key AUTOINCREMENT,
    imgGUID int64 not null,    
    clickUser varchar(50) --第一次点击该图片的人  
 );


 create table login
 (
	uId INTEGER primary key AUTOINCREMENT,
	uName varchar(50) not null,					
	uPwd  varchar(100) not null,
	loginDatetime  datetime NOT NULL DEFAULT(datetime('now', 'localtime')) 
 )
  