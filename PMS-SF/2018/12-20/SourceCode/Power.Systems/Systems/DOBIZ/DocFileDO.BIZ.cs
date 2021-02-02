 
 
 using    System;
 using System.Collections.Generic;
 using System.Text; 
 using XCode.Attributes    ;

 namespace  Power.Systems.Systems
{
    /// <summary>
    /// 文件附件
    /// </summary>
    public class DocFileDO : DocFileDO<DocFileDO>
    {

    }

	/// <summary>
    /// 文件附件
    /// </summary>
	  [BindEntity(KeyWord="DocFile",EntityType = typeof(Power.Systems.Systems.DocFileDO),Description = "文件附件"  )] 

	 [BindTable( "PB_DocFiles", Alias = "a",IsAttach=false,Description ="")]
[BindTable( "PB_DefaultField", Alias = "b",IsAttach=true,Description ="")]

	  [BindIndex(Name = "pk_PB_DocFiles", KeyType = Power.DataAccessLayer.KeyType.MainKey, Columns = "Id", TableName = "PB_DocFiles",Description="")]
 [BindIndex(Name = "pk_PB_DefaultField", KeyType = Power.DataAccessLayer.KeyType.MainKey, Columns = "DefaultFieldId", TableName = "PB_DefaultField",Description="")]

    public   class DocFileDO<TEntity> : XCode.Entity<TEntity>, XCode.IEntity where TEntity : Power.Systems.Systems.DocFileDO<TEntity>, new()
    { 
	    #region 属性

	    
 private System.Guid _Id;
 /// <summary>
 /// 
 /// </summary>
 [BindColumn(1,"a", "Id", "","", "NCHAR", 16,0,false, IsPrimaryKey =true ,IsIdentity =true,IsNullable =false,  Length =16 )]
 [BindColumn(1,"b", "DefaultFieldId", "对应业务记录Id","", "NCHAR", 16,0,false, IsPrimaryKey =true ,IsIdentity =true,IsNullable =false,  Length =16 )]
 public virtual System.Guid Id  { get { return _Id; } set { _Id = value; } }

 private System.String _PublishFlag;
 /// <summary>
 /// Y发布，N未发布
 /// </summary>
 [BindColumn(1,"a", "PublishFlag", "Y发布，N未发布","", "NCHAR", 1,0,false, IsPrimaryKey =false ,IsIdentity =false,IsNullable =true,  Length =1 )]
 public  System.String PublishFlag  { get { return _PublishFlag; } set { _PublishFlag = value; } }

 private System.Guid _FolderId;
 /// <summary>
 /// 记录文档目录Id 或 表单主bo的KeyValue
 /// </summary>
 [BindColumn(2,"a", "FolderId", "记录文档目录Id 或 表单主bo的KeyValue","", "NCHAR", 16,0,false, IsPrimaryKey =false ,IsIdentity =false,IsNullable =true,  Length =16 )]
 public  System.Guid FolderId  { get { return _FolderId; } set { _FolderId = value; } }

 private System.String _BOKeyWord;
 /// <summary>
 /// FoldId=BO.Keyvalue时，记录对应KeyWord
 /// </summary>
 [BindColumn(3,"a", "BOKeyWord", "FoldId=BO.Keyvalue时，记录对应KeyWord","", "NCHAR", 80,0,false, IsPrimaryKey =false ,IsIdentity =false,IsNullable =true,  Length =80 )]
 public  System.String BOKeyWord  { get { return _BOKeyWord; } set { _BOKeyWord = value; } }

 private System.String _Code;
 /// <summary>
 /// 编号
 /// </summary>
 [BindColumn(4,"a", "Code", "编号","", "NCHAR", 100,0,false, IsPrimaryKey =false ,IsIdentity =false,IsNullable =true,  Length =100 )]
 public  System.String Code  { get { return _Code; } set { _Code = value; } }

 private System.String _Name;
 /// <summary>
 /// 名称
 /// </summary>
 [BindColumn(5,"a", "Name", "名称","", "NCHAR", 255,0,false, IsPrimaryKey =false ,IsIdentity =false,IsNullable =true,  Length =255 )]
 public  System.String Name  { get { return _Name; } set { _Name = value; } }

 private System.String _FileExt;
 /// <summary>
 /// 文件扩展名
 /// </summary>
 [BindColumn(6,"a", "FileExt", "文件扩展名","", "NCHAR", 10,0,false, IsPrimaryKey =false ,IsIdentity =false,IsNullable =true,  Length =10 )]
 public  System.String FileExt  { get { return _FileExt; } set { _FileExt = value; } }

 private System.Int32 _FileSize;
 /// <summary>
 /// 文件大小
 /// </summary>
 [BindColumn(7,"a", "FileSize", "文件大小","", "NCHAR", 10,0,false, IsPrimaryKey =false ,IsIdentity =false,IsNullable =true,  Length =10 )]
 public  System.Int32 FileSize  { get { return _FileSize; } set { _FileSize = value; } }

 private System.Int32 _FileVersion;
 /// <summary>
 /// 版本
 /// </summary>
 [BindColumn(8,"a", "FileVersion", "版本","", "NCHAR", 10,0,false, IsPrimaryKey =false ,IsIdentity =false,IsNullable =true,  Length =10 )]
 public  System.Int32 FileVersion  { get { return _FileVersion; } set { _FileVersion = value; } }

 private System.String _SecretLevel;
 /// <summary>
 /// 密级
 /// </summary>
 [BindColumn(9,"a", "SecretLevel", "密级","", "NCHAR", 30,0,false, IsPrimaryKey =false ,IsIdentity =false,IsNullable =true,  Length =30 )]
 public  System.String SecretLevel  { get { return _SecretLevel; } set { _SecretLevel = value; } }

 private System.String _EncodeFlag;
 /// <summary>
 /// Y加密，N未加密
 /// </summary>
 [BindColumn(10,"a", "EncodeFlag", "Y加密，N未加密","", "NCHAR", 1,0,false, IsPrimaryKey =false ,IsIdentity =false,IsNullable =true,  Length =1 )]
 public  System.String EncodeFlag  { get { return _EncodeFlag; } set { _EncodeFlag = value; } }

 private System.String _EncodeMethod;
 /// <summary>
 /// 加密算法
 /// </summary>
 [BindColumn(11,"a", "EncodeMethod", "加密算法","", "NCHAR", 200,0,false, IsPrimaryKey =false ,IsIdentity =false,IsNullable =true,  Length =200 )]
 public  System.String EncodeMethod  { get { return _EncodeMethod; } set { _EncodeMethod = value; } }

 private System.Guid _SourceFileId;
 /// <summary>
 /// 源文件id，场景：从一个目录复制到另一个目录
 /// </summary>
 [BindColumn(12,"a", "SourceFileId", "源文件id，场景：从一个目录复制到另一个目录","", "NCHAR", 16,0,false, IsPrimaryKey =false ,IsIdentity =false,IsNullable =true,  Length =16 )]
 public  System.Guid SourceFileId  { get { return _SourceFileId; } set { _SourceFileId = value; } }

 private System.Guid _TemplateId;
 /// <summary>
 /// 文件模板id
 /// </summary>
 [BindColumn(13,"a", "TemplateId", "文件模板id","", "NCHAR", 16,0,false, IsPrimaryKey =false ,IsIdentity =false,IsNullable =true,  Length =16 )]
 public  System.Guid TemplateId  { get { return _TemplateId; } set { _TemplateId = value; } }

 private System.String _ServerUrl;
 /// <summary>
 /// FTP文件路径
 /// </summary>
 [BindColumn(14,"a", "ServerUrl", "FTP文件路径","", "NCHAR", 500,0,false, IsPrimaryKey =false ,IsIdentity =false,IsNullable =true,  Length =500 )]
 public  System.String ServerUrl  { get { return _ServerUrl; } set { _ServerUrl = value; } }

 private System.String _SN;
 /// <summary>
 /// 文号
 /// </summary>
 [BindColumn(15,"a", "SN", "文号","", "NCHAR", 200,0,false, IsPrimaryKey =false ,IsIdentity =false,IsNullable =true,  Length =200 )]
 public  System.String SN  { get { return _SN; } set { _SN = value; } }

 private System.String _HandOverFlag;
 /// <summary>
 /// Y移交，N未移交
 /// </summary>
 [BindColumn(16,"a", "HandOverFlag", "Y移交，N未移交","", "NCHAR", 1,0,false, IsPrimaryKey =false ,IsIdentity =false,IsNullable =true,  Length =1 )]
 public  System.String HandOverFlag  { get { return _HandOverFlag; } set { _HandOverFlag = value; } }

 private System.DateTime _ArriveDate;
 /// <summary>
 /// 到图日期
 /// </summary>
 [BindColumn(17,"a", "ArriveDate", "到图日期","", "NCHAR", 3,0,false, IsPrimaryKey =false ,IsIdentity =false,IsNullable =true,  Length =3 )]
 public  System.DateTime ArriveDate  { get { return _ArriveDate; } set { _ArriveDate = value; } }

 private System.DateTime _PlanDate;
 /// <summary>
 /// 
 /// </summary>
 [BindColumn(18,"a", "PlanDate", "","", "NCHAR", 3,0,false, IsPrimaryKey =false ,IsIdentity =false,IsNullable =true,  Length =3 )]
 public  System.DateTime PlanDate  { get { return _PlanDate; } set { _PlanDate = value; } }

 private System.DateTime _RequireDate;
 /// <summary>
 /// 需求日期
 /// </summary>
 [BindColumn(19,"a", "RequireDate", "需求日期","", "NCHAR", 3,0,false, IsPrimaryKey =false ,IsIdentity =false,IsNullable =true,  Length =3 )]
 public  System.DateTime RequireDate  { get { return _RequireDate; } set { _RequireDate = value; } }

 private System.String _Designer;
 /// <summary>
 /// 编制人
 /// </summary>
 [BindColumn(20,"a", "Designer", "编制人","", "NCHAR", 80,0,false, IsPrimaryKey =false ,IsIdentity =false,IsNullable =true,  Length =80 )]
 public  System.String Designer  { get { return _Designer; } set { _Designer = value; } }

 private System.String _DesignOrganize;
 /// <summary>
 /// 编制单位
 /// </summary>
 [BindColumn(21,"a", "DesignOrganize", "编制单位","", "NCHAR", 100,0,false, IsPrimaryKey =false ,IsIdentity =false,IsNullable =true,  Length =100 )]
 public  System.String DesignOrganize  { get { return _DesignOrganize; } set { _DesignOrganize = value; } }

 private System.String _Charger;
 /// <summary>
 /// 负责人
 /// </summary>
 [BindColumn(22,"a", "Charger", "负责人","", "NCHAR", 80,0,false, IsPrimaryKey =false ,IsIdentity =false,IsNullable =true,  Length =80 )]
 public  System.String Charger  { get { return _Charger; } set { _Charger = value; } }

 private System.String _ChargeOrganize;
 /// <summary>
 /// 负责单位
 /// </summary>
 [BindColumn(23,"a", "ChargeOrganize", "负责单位","", "NCHAR", 100,0,false, IsPrimaryKey =false ,IsIdentity =false,IsNullable =true,  Length =100 )]
 public  System.String ChargeOrganize  { get { return _ChargeOrganize; } set { _ChargeOrganize = value; } }

 private System.Int32 _PageCount;
 /// <summary>
 /// 文件页数
 /// </summary>
 [BindColumn(24,"a", "PageCount", "文件页数","", "NCHAR", 10,0,false, IsPrimaryKey =false ,IsIdentity =false,IsNullable =true,  Length =10 )]
 public  System.Int32 PageCount  { get { return _PageCount; } set { _PageCount = value; } }

 private System.String _Labels;
 /// <summary>
 /// 标签，记录文件的关键词
 /// </summary>
 [BindColumn(25,"a", "Labels", "标签，记录文件的关键词","", "NCHAR", 1000,0,false, IsPrimaryKey =false ,IsIdentity =false,IsNullable =true,  Length =1000 )]
 public  System.String Labels  { get { return _Labels; } set { _Labels = value; } }

 private System.String _BIMJson;
 /// <summary>
 /// 附件对于BIM的json信息fileid、transferid
 /// </summary>
 [BindColumn(27,"a", "BIMJson", "附件对于BIM的json信息fileid、transferid","", "NCHAR", 200,0,false, IsPrimaryKey =false ,IsIdentity =false,IsNullable =true,  Length =200 )]
 public  System.String BIMJson  { get { return _BIMJson; } set { _BIMJson = value; } }

 private System.Int32 _CheckFlag;
 /// <summary>
 /// 
 /// </summary>
 [BindColumn(28,"a", "CheckFlag", "","", "NCHAR", 10,0,false, IsPrimaryKey =false ,IsIdentity =false,IsNullable =true,  Length =10 )]
 public  System.Int32 CheckFlag  { get { return _CheckFlag; } set { _CheckFlag = value; } }

 private System.Guid _CheckHumId;
 /// <summary>
 /// 
 /// </summary>
 [BindColumn(29,"a", "CheckHumId", "","", "NCHAR", 16,0,false, IsPrimaryKey =false ,IsIdentity =false,IsNullable =true,  Length =16 )]
 public  System.Guid CheckHumId  { get { return _CheckHumId; } set { _CheckHumId = value; } }

 private System.String _CheckName;
 /// <summary>
 /// 
 /// </summary>
 [BindColumn(30,"a", "CheckName", "","", "NCHAR", 80,0,false, IsPrimaryKey =false ,IsIdentity =false,IsNullable =true,  Length =80 )]
 public  System.String CheckName  { get { return _CheckName; } set { _CheckName = value; } }

 private System.DateTime _CheckDate;
 /// <summary>
 /// 
 /// </summary>
 [BindColumn(31,"a", "CheckDate", "","", "NCHAR", 3,0,false, IsPrimaryKey =false ,IsIdentity =false,IsNullable =true,  Length =3 )]
 public  System.DateTime CheckDate  { get { return _CheckDate; } set { _CheckDate = value; } }

 private System.Int32 _DeletFlag;
 /// <summary>
 /// 0正常，1删除，2被删
 /// </summary>
 [BindColumn(32,"a", "DeletFlag", "0正常，1删除，2被删","", "NCHAR", 10,0,false, IsPrimaryKey =false ,IsIdentity =false,IsNullable =true,  Length =10 )]
 public  System.Int32 DeletFlag  { get { return _DeletFlag; } set { _DeletFlag = value; } }

 private System.Guid _DeletHumId;
 /// <summary>
 /// 
 /// </summary>
 [BindColumn(33,"a", "DeletHumId", "","", "NCHAR", 16,0,false, IsPrimaryKey =false ,IsIdentity =false,IsNullable =true,  Length =16 )]
 public  System.Guid DeletHumId  { get { return _DeletHumId; } set { _DeletHumId = value; } }

 private System.String _DeletName;
 /// <summary>
 /// 
 /// </summary>
 [BindColumn(34,"a", "DeletName", "","", "NCHAR", 80,0,false, IsPrimaryKey =false ,IsIdentity =false,IsNullable =true,  Length =80 )]
 public  System.String DeletName  { get { return _DeletName; } set { _DeletName = value; } }

 private System.DateTime _DeletDate;
 /// <summary>
 /// 
 /// </summary>
 [BindColumn(35,"a", "DeletDate", "","", "NCHAR", 3,0,false, IsPrimaryKey =false ,IsIdentity =false,IsNullable =true,  Length =3 )]
 public  System.DateTime DeletDate  { get { return _DeletDate; } set { _DeletDate = value; } }

 private System.String _Deliverable_guid;
 /// <summary>
 /// 
 /// </summary>
 [BindColumn(36,"a", "Deliverable_guid", "","", "NCHAR", 38,0,false, IsPrimaryKey =false ,IsIdentity =false,IsNullable =true,  Length =38 )]
 public  System.String Deliverable_guid  { get { return _Deliverable_guid; } set { _Deliverable_guid = value; } }

 private System.String _Deliverable_name;
 /// <summary>
 /// 
 /// </summary>
 [BindColumn(37,"a", "Deliverable_name", "","", "NCHAR", 120,0,false, IsPrimaryKey =false ,IsIdentity =false,IsNullable =true,  Length =120 )]
 public  System.String Deliverable_name  { get { return _Deliverable_name; } set { _Deliverable_name = value; } }

 private System.Guid _VersionKeyValue;
 /// <summary>
 /// 
 /// </summary>
 [BindColumn(38,"a", "VersionKeyValue", "","", "NCHAR", 16,0,false, IsPrimaryKey =false ,IsIdentity =false,IsNullable =true,  Length =16 )]
 public  System.Guid VersionKeyValue  { get { return _VersionKeyValue; } set { _VersionKeyValue = value; } }

 private System.String _OssUrl;
 /// <summary>
 /// FTP文件路径
 /// </summary>
 [BindColumn(39,"a", "OssUrl", "FTP文件路径","", "NCHAR", 2000,0,false, IsPrimaryKey =false ,IsIdentity =false,IsNullable =true,  Length =2000 )]
 public  System.String OssUrl  { get { return _OssUrl; } set { _OssUrl = value; } }

 private System.Int32 _IsOss;
 /// <summary>
 /// 是否是外网直接上传至OSS（0否；1是）
 /// </summary>
 [BindColumn(40,"a", "IsOss", "是否是外网直接上传至OSS（0否；1是）","", "NCHAR", 10,0,false, IsPrimaryKey =false ,IsIdentity =false,IsNullable =true,  Length =10 )]
 public  System.Int32 IsOss  { get { return _IsOss; } set { _IsOss = value; } }

 private System.Int32 _DownloadOssSuccess;
 /// <summary>
 ///  从OSS下载文件是否成功（0否；1是）
 /// </summary>
 [BindColumn(41,"a", "DownloadOssSuccess", " 从OSS下载文件是否成功（0否；1是）","", "NCHAR", 10,0,false, IsPrimaryKey =false ,IsIdentity =false,IsNullable =true,  Length =10 )]
 public  System.Int32 DownloadOssSuccess  { get { return _DownloadOssSuccess; } set { _DownloadOssSuccess = value; } }

 private System.Int32 _IsUploadOSS;
 /// <summary>
 /// 是否需要同步至OSS平台（0否；1是）
 /// </summary>
 [BindColumn(42,"a", "IsUploadOSS", "是否需要同步至OSS平台（0否；1是）","", "NCHAR", 10,0,false, IsPrimaryKey =false ,IsIdentity =false,IsNullable =true,  Length =10 )]
 public  System.Int32 IsUploadOSS  { get { return _IsUploadOSS; } set { _IsUploadOSS = value; } }

 private System.Int32 _IsUploadOSSSuccess;
 /// <summary>
 /// 是否已同步至OSS平台（0否；1是）
 /// </summary>
 [BindColumn(43,"a", "IsUploadOSSSuccess", "是否已同步至OSS平台（0否；1是）","", "NCHAR", 10,0,false, IsPrimaryKey =false ,IsIdentity =false,IsNullable =true,  Length =10 )]
 public  System.Int32 IsUploadOSSSuccess  { get { return _IsUploadOSSSuccess; } set { _IsUploadOSSSuccess = value; } }

 private System.Int32 _IsUploadPms;
 /// <summary>
 /// 是否需要同步至内网PMS（0否；1是）
 /// </summary>
 [BindColumn(44,"a", "IsUploadPms", "是否需要同步至内网PMS（0否；1是）","", "NCHAR", 10,0,false, IsPrimaryKey =false ,IsIdentity =false,IsNullable =true,  Length =10 )]
 public  System.Int32 IsUploadPms  { get { return _IsUploadPms; } set { _IsUploadPms = value; } }

 private System.Int32 _IsUploadPmsSuccess;
 /// <summary>
 /// 是否已同步至内网PMS（0否；1是）
 /// </summary>
 [BindColumn(45,"a", "IsUploadPmsSuccess", "是否已同步至内网PMS（0否；1是）","", "NCHAR", 10,0,false, IsPrimaryKey =false ,IsIdentity =false,IsNullable =true,  Length =10 )]
 public  System.Int32 IsUploadPmsSuccess  { get { return _IsUploadPmsSuccess; } set { _IsUploadPmsSuccess = value; } }

 private System.Int32 _IsPmsSuccess;
 /// <summary>
 /// 内网小程序是否同步成功（0否；1是）
 /// </summary>
 [BindColumn(46,"a", "IsPmsSuccess", "内网小程序是否同步成功（0否；1是）","", "NCHAR", 10,0,false, IsPrimaryKey =false ,IsIdentity =false,IsNullable =true,  Length =10 )]
 public  System.Int32 IsPmsSuccess  { get { return _IsPmsSuccess; } set { _IsPmsSuccess = value; } }

 private System.Int32 _IsModeanalyze;
 /// <summary>
 /// 
 /// </summary>
 [BindColumn(47,"a", "IsModeanalyze", "","", "NCHAR", 10,0,false, IsPrimaryKey =false ,IsIdentity =false,IsNullable =true,  Length =10 )]
 public  System.Int32 IsModeanalyze  { get { return _IsModeanalyze; } set { _IsModeanalyze = value; } }

 private System.String _TableName;
 /// <summary>
 /// 数据所属表名
 /// </summary>
 [BindColumn(2,"b", "TableName", "数据所属表名","", "NCHAR", 50,0,false, IsPrimaryKey =false ,IsIdentity =false,IsNullable =true,  Length =50 )]
 public  System.String TableName  { get { return _TableName; } set { _TableName = value; } }

 private System.Guid _BizAreaId;
 /// <summary>
 /// 数据录入业务域Id
 /// </summary>
 [BindColumn(3,"b", "BizAreaId", "数据录入业务域Id","", "NCHAR", 16,0,false, IsPrimaryKey =false ,IsIdentity =false,IsNullable =true,  Length =16 )]
 public  System.Guid BizAreaId  { get { return _BizAreaId; } set { _BizAreaId = value; } }

 private System.Int32 _Sequ;
 /// <summary>
 /// 序号
 /// </summary>
 [BindColumn(4,"b", "Sequ", "序号","", "NCHAR", 10,0,false, IsPrimaryKey =false ,IsIdentity =false,IsNullable =true,  Length =10 )]
 public  System.Int32 Sequ  { get { return _Sequ; } set { _Sequ = value; } }

 private System.SByte _Status;
 /// <summary>
 /// 平台状态；0编制中，1送审中，2生效，3废止
 /// </summary>
 [BindColumn(5,"b", "Status", "平台状态；0编制中，1送审中，2生效，3废止","", "NCHAR", 3,0,false, IsPrimaryKey =false ,IsIdentity =false,IsNullable =true,  Length =3 )]
 public  System.SByte Status  { get { return _Status; } set { _Status = value; } }

 private System.Guid _RegHumId;
 /// <summary>
 /// 录入人Id
 /// </summary>
 [BindColumn(6,"b", "RegHumId", "录入人Id","", "NCHAR", 16,0,false, IsPrimaryKey =false ,IsIdentity =false,IsNullable =true,  Length =16 )]
 public  System.Guid RegHumId  { get { return _RegHumId; } set { _RegHumId = value; } }

 private System.String _RegHumName;
 /// <summary>
 /// 录入人名称
 /// </summary>
 [BindColumn(7,"b", "RegHumName", "录入人名称","", "NCHAR", 80,0,false, IsPrimaryKey =false ,IsIdentity =false,IsNullable =true,  Length =80 )]
 public  System.String RegHumName  { get { return _RegHumName; } set { _RegHumName = value; } }

 private System.DateTime _RegDate;
 /// <summary>
 /// 录入日期
 /// </summary>
 [BindColumn(8,"b", "RegDate", "录入日期","", "NCHAR", 3,0,false, IsPrimaryKey =false ,IsIdentity =false,IsNullable =true,  Length =3 )]
 public  System.DateTime RegDate  { get { return _RegDate; } set { _RegDate = value; } }

 private System.Guid _RegPosiId;
 /// <summary>
 /// 录入人岗位Id
 /// </summary>
 [BindColumn(9,"b", "RegPosiId", "录入人岗位Id","", "NCHAR", 16,0,false, IsPrimaryKey =false ,IsIdentity =false,IsNullable =true,  Length =16 )]
 public  System.Guid RegPosiId  { get { return _RegPosiId; } set { _RegPosiId = value; } }

 private System.Guid _RegDeptId;
 /// <summary>
 /// 录入人部门Id
 /// </summary>
 [BindColumn(10,"b", "RegDeptId", "录入人部门Id","", "NCHAR", 16,0,false, IsPrimaryKey =false ,IsIdentity =false,IsNullable =true,  Length =16 )]
 public  System.Guid RegDeptId  { get { return _RegDeptId; } set { _RegDeptId = value; } }

 private System.Guid _EpsProjId;
 /// <summary>
 /// 记录所属EPS节点Id
 /// </summary>
 [BindColumn(11,"b", "EpsProjId", "记录所属EPS节点Id","", "NCHAR", 16,0,false, IsPrimaryKey =false ,IsIdentity =false,IsNullable =true,  Length =16 )]
 public  System.Guid EpsProjId  { get { return _EpsProjId; } set { _EpsProjId = value; } }

 private System.Guid _RecycleHumId;
 /// <summary>
 /// 删除人Id
 /// </summary>
 [BindColumn(12,"b", "RecycleHumId", "删除人Id","", "NCHAR", 16,0,false, IsPrimaryKey =false ,IsIdentity =false,IsNullable =true,  Length =16 )]
 public  System.Guid RecycleHumId  { get { return _RecycleHumId; } set { _RecycleHumId = value; } }

 private System.Guid _UpdHumId;
 /// <summary>
 /// 最后更新人Id
 /// </summary>
 [BindColumn(13,"b", "UpdHumId", "最后更新人Id","", "NCHAR", 16,0,false, IsPrimaryKey =false ,IsIdentity =false,IsNullable =true,  Length =16 )]
 public  System.Guid UpdHumId  { get { return _UpdHumId; } set { _UpdHumId = value; } }

 private System.String _UpdHumName;
 /// <summary>
 /// 最后更新人名称
 /// </summary>
 [BindColumn(14,"b", "UpdHumName", "最后更新人名称","", "NCHAR", 80,0,false, IsPrimaryKey =false ,IsIdentity =false,IsNullable =true,  Length =80 )]
 public  System.String UpdHumName  { get { return _UpdHumName; } set { _UpdHumName = value; } }

 private System.DateTime _UpdDate;
 /// <summary>
 /// 最后更新日期
 /// </summary>
 [BindColumn(15,"b", "UpdDate", "最后更新日期","", "NCHAR", 3,0,false, IsPrimaryKey =false ,IsIdentity =false,IsNullable =true,  Length =3 )]
 public  System.DateTime UpdDate  { get { return _UpdDate; } set { _UpdDate = value; } }

 private System.Guid _ApprHumId;
 /// <summary>
 /// 批准人Id
 /// </summary>
 [BindColumn(16,"b", "ApprHumId", "批准人Id","", "NCHAR", 16,0,false, IsPrimaryKey =false ,IsIdentity =false,IsNullable =true,  Length =16 )]
 public  System.Guid ApprHumId  { get { return _ApprHumId; } set { _ApprHumId = value; } }

 private System.String _ApprHumName;
 /// <summary>
 /// 批准人名称
 /// </summary>
 [BindColumn(17,"b", "ApprHumName", "批准人名称","", "NCHAR", 80,0,false, IsPrimaryKey =false ,IsIdentity =false,IsNullable =true,  Length =80 )]
 public  System.String ApprHumName  { get { return _ApprHumName; } set { _ApprHumName = value; } }

 private System.DateTime _ApprDate;
 /// <summary>
 /// 批准日期
 /// </summary>
 [BindColumn(18,"b", "ApprDate", "批准日期","", "NCHAR", 3,0,false, IsPrimaryKey =false ,IsIdentity =false,IsNullable =true,  Length =3 )]
 public  System.DateTime ApprDate  { get { return _ApprDate; } set { _ApprDate = value; } }

 private System.String _Memo;
 /// <summary>
 /// 备注
 /// </summary>
 [BindColumn(19,"b", "Memo", "备注","", "NCHAR", -1,0,false, IsPrimaryKey =false ,IsIdentity =false,IsNullable =true,  Length =-1 )]
 public  System.String Memo  { get { return _Memo; } set { _Memo = value; } }

 private System.Guid _OwnProjId;
 /// <summary>
 /// 所属项目Id
 /// </summary>
 [BindColumn(20,"b", "OwnProjId", "所属项目Id","", "NCHAR", 16,0,false, IsPrimaryKey =false ,IsIdentity =false,IsNullable =true,  Length =16 )]
 public  System.Guid OwnProjId  { get { return _OwnProjId; } set { _OwnProjId = value; } }

 private System.String _OwnProjName;
 /// <summary>
 /// 所属项目名称
 /// </summary>
 [BindColumn(21,"b", "OwnProjName", "所属项目名称","", "NCHAR", 255,0,false, IsPrimaryKey =false ,IsIdentity =false,IsNullable =true,  Length =255 )]
 public  System.String OwnProjName  { get { return _OwnProjName; } set { _OwnProjName = value; } }

      
		#endregion 

		#region 获取/设置 字段值
		 /// <summary>获取/设置 字段值。</summary>
        /// <param name="name">属性名</param>
        /// <return>属性值</return>
        public override object this[string name]
        {
            get
            {
			  name = name.ToUpper();
			    if (name == "ID")
{
return _Id;
}
if (name == "PUBLISHFLAG")
{
return _PublishFlag;
}
if (name == "FOLDERID")
{
return _FolderId;
}
if (name == "BOKEYWORD")
{
return _BOKeyWord;
}
if (name == "CODE")
{
return _Code;
}
if (name == "NAME")
{
return _Name;
}
if (name == "FILEEXT")
{
return _FileExt;
}
if (name == "FILESIZE")
{
return _FileSize;
}
if (name == "FILEVERSION")
{
return _FileVersion;
}
if (name == "SECRETLEVEL")
{
return _SecretLevel;
}
if (name == "ENCODEFLAG")
{
return _EncodeFlag;
}
if (name == "ENCODEMETHOD")
{
return _EncodeMethod;
}
if (name == "SOURCEFILEID")
{
return _SourceFileId;
}
if (name == "TEMPLATEID")
{
return _TemplateId;
}
if (name == "SERVERURL")
{
return _ServerUrl;
}
if (name == "SN")
{
return _SN;
}
if (name == "HANDOVERFLAG")
{
return _HandOverFlag;
}
if (name == "ARRIVEDATE")
{
return _ArriveDate;
}
if (name == "PLANDATE")
{
return _PlanDate;
}
if (name == "REQUIREDATE")
{
return _RequireDate;
}
if (name == "DESIGNER")
{
return _Designer;
}
if (name == "DESIGNORGANIZE")
{
return _DesignOrganize;
}
if (name == "CHARGER")
{
return _Charger;
}
if (name == "CHARGEORGANIZE")
{
return _ChargeOrganize;
}
if (name == "PAGECOUNT")
{
return _PageCount;
}
if (name == "LABELS")
{
return _Labels;
}
if (name == "BIMJSON")
{
return _BIMJson;
}
if (name == "CHECKFLAG")
{
return _CheckFlag;
}
if (name == "CHECKHUMID")
{
return _CheckHumId;
}
if (name == "CHECKNAME")
{
return _CheckName;
}
if (name == "CHECKDATE")
{
return _CheckDate;
}
if (name == "DELETFLAG")
{
return _DeletFlag;
}
if (name == "DELETHUMID")
{
return _DeletHumId;
}
if (name == "DELETNAME")
{
return _DeletName;
}
if (name == "DELETDATE")
{
return _DeletDate;
}
if (name == "DELIVERABLE_GUID")
{
return _Deliverable_guid;
}
if (name == "DELIVERABLE_NAME")
{
return _Deliverable_name;
}
if (name == "VERSIONKEYVALUE")
{
return _VersionKeyValue;
}
if (name == "OSSURL")
{
return _OssUrl;
}
if (name == "ISOSS")
{
return _IsOss;
}
if (name == "DOWNLOADOSSSUCCESS")
{
return _DownloadOssSuccess;
}
if (name == "ISUPLOADOSS")
{
return _IsUploadOSS;
}
if (name == "ISUPLOADOSSSUCCESS")
{
return _IsUploadOSSSuccess;
}
if (name == "ISUPLOADPMS")
{
return _IsUploadPms;
}
if (name == "ISUPLOADPMSSUCCESS")
{
return _IsUploadPmsSuccess;
}
if (name == "ISPMSSUCCESS")
{
return _IsPmsSuccess;
}
if (name == "ISMODEANALYZE")
{
return _IsModeanalyze;
}
if (name == "TABLENAME")
{
return _TableName;
}
if (name == "BIZAREAID")
{
return _BizAreaId;
}
if (name == "SEQU")
{
return _Sequ;
}
if (name == "STATUS")
{
return _Status;
}
if (name == "REGHUMID")
{
return _RegHumId;
}
if (name == "REGHUMNAME")
{
return _RegHumName;
}
if (name == "REGDATE")
{
return _RegDate;
}
if (name == "REGPOSIID")
{
return _RegPosiId;
}
if (name == "REGDEPTID")
{
return _RegDeptId;
}
if (name == "EPSPROJID")
{
return _EpsProjId;
}
if (name == "RECYCLEHUMID")
{
return _RecycleHumId;
}
if (name == "UPDHUMID")
{
return _UpdHumId;
}
if (name == "UPDHUMNAME")
{
return _UpdHumName;
}
if (name == "UPDDATE")
{
return _UpdDate;
}
if (name == "APPRHUMID")
{
return _ApprHumId;
}
if (name == "APPRHUMNAME")
{
return _ApprHumName;
}
if (name == "APPRDATE")
{
return _ApprDate;
}
if (name == "MEMO")
{
return _Memo;
}
if (name == "OWNPROJID")
{
return _OwnProjId;
}
if (name == "OWNPROJNAME")
{
return _OwnProjName;
}

			    return base[name];
			}
			set 
			{
			   name = name.ToUpper();
			       if (name == "ID")
{
 _Id = XCode.Common.Helper.ConvertToGuid(value);return;
}
if (name == "PUBLISHFLAG")
{
 _PublishFlag = System.Convert.ToString(value);return;
}
if (name == "FOLDERID")
{
 _FolderId = XCode.Common.Helper.ConvertToGuid(value);return;
}
if (name == "BOKEYWORD")
{
 _BOKeyWord = System.Convert.ToString(value);return;
}
if (name == "CODE")
{
 _Code = System.Convert.ToString(value);return;
}
if (name == "NAME")
{
 _Name = System.Convert.ToString(value);return;
}
if (name == "FILEEXT")
{
 _FileExt = System.Convert.ToString(value);return;
}
if (name == "FILESIZE")
{
 _FileSize = System.Convert.ToInt32(value);return;
}
if (name == "FILEVERSION")
{
 _FileVersion = System.Convert.ToInt32(value);return;
}
if (name == "SECRETLEVEL")
{
 _SecretLevel = System.Convert.ToString(value);return;
}
if (name == "ENCODEFLAG")
{
 _EncodeFlag = System.Convert.ToString(value);return;
}
if (name == "ENCODEMETHOD")
{
 _EncodeMethod = System.Convert.ToString(value);return;
}
if (name == "SOURCEFILEID")
{
 _SourceFileId = XCode.Common.Helper.ConvertToGuid(value);return;
}
if (name == "TEMPLATEID")
{
 _TemplateId = XCode.Common.Helper.ConvertToGuid(value);return;
}
if (name == "SERVERURL")
{
 _ServerUrl = System.Convert.ToString(value);return;
}
if (name == "SN")
{
 _SN = System.Convert.ToString(value);return;
}
if (name == "HANDOVERFLAG")
{
 _HandOverFlag = System.Convert.ToString(value);return;
}
if (name == "ARRIVEDATE")
{
 if (value == null || value.ToString().IsNullOrEmpty() == true) value = DateTime.MinValue;
 _ArriveDate = System.Convert.ToDateTime(value);return;
}
if (name == "PLANDATE")
{
 if (value == null || value.ToString().IsNullOrEmpty() == true) value = DateTime.MinValue;
 _PlanDate = System.Convert.ToDateTime(value);return;
}
if (name == "REQUIREDATE")
{
 if (value == null || value.ToString().IsNullOrEmpty() == true) value = DateTime.MinValue;
 _RequireDate = System.Convert.ToDateTime(value);return;
}
if (name == "DESIGNER")
{
 _Designer = System.Convert.ToString(value);return;
}
if (name == "DESIGNORGANIZE")
{
 _DesignOrganize = System.Convert.ToString(value);return;
}
if (name == "CHARGER")
{
 _Charger = System.Convert.ToString(value);return;
}
if (name == "CHARGEORGANIZE")
{
 _ChargeOrganize = System.Convert.ToString(value);return;
}
if (name == "PAGECOUNT")
{
 _PageCount = System.Convert.ToInt32(value);return;
}
if (name == "LABELS")
{
 _Labels = System.Convert.ToString(value);return;
}
if (name == "BIMJSON")
{
 _BIMJson = System.Convert.ToString(value);return;
}
if (name == "CHECKFLAG")
{
 _CheckFlag = System.Convert.ToInt32(value);return;
}
if (name == "CHECKHUMID")
{
 _CheckHumId = XCode.Common.Helper.ConvertToGuid(value);return;
}
if (name == "CHECKNAME")
{
 _CheckName = System.Convert.ToString(value);return;
}
if (name == "CHECKDATE")
{
 if (value == null || value.ToString().IsNullOrEmpty() == true) value = DateTime.MinValue;
 _CheckDate = System.Convert.ToDateTime(value);return;
}
if (name == "DELETFLAG")
{
 _DeletFlag = System.Convert.ToInt32(value);return;
}
if (name == "DELETHUMID")
{
 _DeletHumId = XCode.Common.Helper.ConvertToGuid(value);return;
}
if (name == "DELETNAME")
{
 _DeletName = System.Convert.ToString(value);return;
}
if (name == "DELETDATE")
{
 if (value == null || value.ToString().IsNullOrEmpty() == true) value = DateTime.MinValue;
 _DeletDate = System.Convert.ToDateTime(value);return;
}
if (name == "DELIVERABLE_GUID")
{
 _Deliverable_guid = System.Convert.ToString(value);return;
}
if (name == "DELIVERABLE_NAME")
{
 _Deliverable_name = System.Convert.ToString(value);return;
}
if (name == "VERSIONKEYVALUE")
{
 _VersionKeyValue = XCode.Common.Helper.ConvertToGuid(value);return;
}
if (name == "OSSURL")
{
 _OssUrl = System.Convert.ToString(value);return;
}
if (name == "ISOSS")
{
 _IsOss = System.Convert.ToInt32(value);return;
}
if (name == "DOWNLOADOSSSUCCESS")
{
 _DownloadOssSuccess = System.Convert.ToInt32(value);return;
}
if (name == "ISUPLOADOSS")
{
 _IsUploadOSS = System.Convert.ToInt32(value);return;
}
if (name == "ISUPLOADOSSSUCCESS")
{
 _IsUploadOSSSuccess = System.Convert.ToInt32(value);return;
}
if (name == "ISUPLOADPMS")
{
 _IsUploadPms = System.Convert.ToInt32(value);return;
}
if (name == "ISUPLOADPMSSUCCESS")
{
 _IsUploadPmsSuccess = System.Convert.ToInt32(value);return;
}
if (name == "ISPMSSUCCESS")
{
 _IsPmsSuccess = System.Convert.ToInt32(value);return;
}
if (name == "ISMODEANALYZE")
{
 _IsModeanalyze = System.Convert.ToInt32(value);return;
}
if (name == "TABLENAME")
{
 _TableName = System.Convert.ToString(value);return;
}
if (name == "BIZAREAID")
{
 _BizAreaId = XCode.Common.Helper.ConvertToGuid(value);return;
}
if (name == "SEQU")
{
 _Sequ = System.Convert.ToInt32(value);return;
}
if (name == "STATUS")
{
 _Status = System.Convert.ToSByte(value);return;
}
if (name == "REGHUMID")
{
 _RegHumId = XCode.Common.Helper.ConvertToGuid(value);return;
}
if (name == "REGHUMNAME")
{
 _RegHumName = System.Convert.ToString(value);return;
}
if (name == "REGDATE")
{
 if (value == null || value.ToString().IsNullOrEmpty() == true) value = DateTime.MinValue;
 _RegDate = System.Convert.ToDateTime(value);return;
}
if (name == "REGPOSIID")
{
 _RegPosiId = XCode.Common.Helper.ConvertToGuid(value);return;
}
if (name == "REGDEPTID")
{
 _RegDeptId = XCode.Common.Helper.ConvertToGuid(value);return;
}
if (name == "EPSPROJID")
{
 _EpsProjId = XCode.Common.Helper.ConvertToGuid(value);return;
}
if (name == "RECYCLEHUMID")
{
 _RecycleHumId = XCode.Common.Helper.ConvertToGuid(value);return;
}
if (name == "UPDHUMID")
{
 _UpdHumId = XCode.Common.Helper.ConvertToGuid(value);return;
}
if (name == "UPDHUMNAME")
{
 _UpdHumName = System.Convert.ToString(value);return;
}
if (name == "UPDDATE")
{
 if (value == null || value.ToString().IsNullOrEmpty() == true) value = DateTime.MinValue;
 _UpdDate = System.Convert.ToDateTime(value);return;
}
if (name == "APPRHUMID")
{
 _ApprHumId = XCode.Common.Helper.ConvertToGuid(value);return;
}
if (name == "APPRHUMNAME")
{
 _ApprHumName = System.Convert.ToString(value);return;
}
if (name == "APPRDATE")
{
 if (value == null || value.ToString().IsNullOrEmpty() == true) value = DateTime.MinValue;
 _ApprDate = System.Convert.ToDateTime(value);return;
}
if (name == "MEMO")
{
 _Memo = System.Convert.ToString(value);return;
}
if (name == "OWNPROJID")
{
 _OwnProjId = XCode.Common.Helper.ConvertToGuid(value);return;
}
if (name == "OWNPROJNAME")
{
 _OwnProjName = System.Convert.ToString(value);return;
}

			    base[name] = value;
			}
		}
		#endregion
	}
}