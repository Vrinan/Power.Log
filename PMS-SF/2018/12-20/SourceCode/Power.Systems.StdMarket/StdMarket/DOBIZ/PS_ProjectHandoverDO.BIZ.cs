 
 
 using    System;
 using System.Collections.Generic;
 using System.Text; 
 using XCode.Attributes    ;

 namespace  Power.Systems.StdMarket.StdMarket
{
    /// <summary>
    /// 项目交接单
    /// </summary>
    public class PS_ProjectHandoverDO : PS_ProjectHandoverDO<PS_ProjectHandoverDO>
    {

    }

	/// <summary>
    /// 项目交接单
    /// </summary>
	  [BindEntity(KeyWord="PS_ProjectHandover",EntityType = typeof(Power.Systems.StdMarket.StdMarket.PS_ProjectHandoverDO),Description = "项目交接单"  )] 

	 [BindTable( "PS_MK_ProjectHandover", Alias = "a",IsAttach=false,Description ="")]

	  [BindIndex(Name = "pk_PS_MK_ProjectHandover", KeyType = Power.DataAccessLayer.KeyType.MainKey, Columns = "Id", TableName = "PS_MK_ProjectHandover",Description="")]

    public   class PS_ProjectHandoverDO<TEntity> : XCode.Entity<TEntity>, XCode.IEntity where TEntity : Power.Systems.StdMarket.StdMarket.PS_ProjectHandoverDO<TEntity>, new()
    { 
	    #region 属性

	    
 private System.String _ProjectName;
 /// <summary>
 /// 项目名称
 /// </summary>
 [BindColumn(1,"a", "ProjectName", "项目名称","", "NCHAR", 300,0,false, IsPrimaryKey =false ,IsIdentity =false,IsNullable =true,  Length =300 )]
 public  System.String ProjectName  { get { return _ProjectName; } set { _ProjectName = value; } }

 private System.String _ProjectOverview;
 /// <summary>
 /// 项目概况
 /// </summary>
 [BindColumn(1,"a", "ProjectOverview", "项目概况","", "NCHAR", 500,0,false, IsPrimaryKey =false ,IsIdentity =false,IsNullable =false,  Length =500 )]
 public  System.String ProjectOverview  { get { return _ProjectOverview; } set { _ProjectOverview = value; } }

 private System.String _ProjectCode;
 /// <summary>
 /// 项目编号
 /// </summary>
 [BindColumn(1,"a", "ProjectCode", "项目编号","", "NCHAR", 50,0,false, IsPrimaryKey =false ,IsIdentity =false,IsNullable =false,  Length =50 )]
 public  System.String ProjectCode  { get { return _ProjectCode; } set { _ProjectCode = value; } }

 private System.String _ProjectShortName;
 /// <summary>
 /// 项目简称
 /// </summary>
 [BindColumn(1,"a", "ProjectShortName", "项目简称","", "NCHAR", 50,0,false, IsPrimaryKey =false ,IsIdentity =false,IsNullable =true,  Length =50 )]
 public  System.String ProjectShortName  { get { return _ProjectShortName; } set { _ProjectShortName = value; } }

 private System.String _Memo;
 /// <summary>
 /// 备注
 /// </summary>
 [BindColumn(1,"a", "Memo", "备注","", "NCHAR", 1000,0,false, IsPrimaryKey =false ,IsIdentity =false,IsNullable =true,  Length =1000 )]
 public  System.String Memo  { get { return _Memo; } set { _Memo = value; } }

 private System.Guid _Id;
 /// <summary>
 /// 
 /// </summary>
 [BindColumn(1,"a", "Id", "","", "NCHAR", 16,0,false, IsPrimaryKey =true ,IsIdentity =true,IsNullable =false,  Length =16 )]
 public virtual System.Guid Id  { get { return _Id; } set { _Id = value; } }

 private System.Guid _ProjectEps_Guid;
 /// <summary>
 /// 项目所属epsid
 /// </summary>
 [BindColumn(1,"a", "ProjectEps_Guid", "项目所属epsid","", "NCHAR", 0,0,false, IsPrimaryKey =false ,IsIdentity =false,IsNullable =true,  Length =0 )]
 public  System.Guid ProjectEps_Guid  { get { return _ProjectEps_Guid; } set { _ProjectEps_Guid = value; } }

 private System.Guid _ContractReview_Guid;
 /// <summary>
 /// 
 /// </summary>
 [BindColumn(2,"a", "ContractReview_Guid", "","", "NCHAR", 16,0,false, IsPrimaryKey =false ,IsIdentity =false,IsNullable =true,  Length =16 )]
 public  System.Guid ContractReview_Guid  { get { return _ContractReview_Guid; } set { _ContractReview_Guid = value; } }

 private System.Guid _ConotractInfo_Guid;
 /// <summary>
 /// 
 /// </summary>
 [BindColumn(3,"a", "ConotractInfo_Guid", "","", "NCHAR", 16,0,false, IsPrimaryKey =false ,IsIdentity =false,IsNullable =true,  Length =16 )]
 public  System.Guid ConotractInfo_Guid  { get { return _ConotractInfo_Guid; } set { _ConotractInfo_Guid = value; } }

 private System.String _StartupAccording;
 /// <summary>
 /// 立项依据
 /// </summary>
 [BindColumn(4,"a", "StartupAccording", "立项依据","", "NCHAR", 50,0,false, IsPrimaryKey =false ,IsIdentity =false,IsNullable =true,  Length =50 )]
 public  System.String StartupAccording  { get { return _StartupAccording; } set { _StartupAccording = value; } }

 private System.Guid _Client_Guid;
 /// <summary>
 /// 
 /// </summary>
 [BindColumn(5,"a", "Client_Guid", "","", "NCHAR", 16,0,false, IsPrimaryKey =false ,IsIdentity =false,IsNullable =true,  Length =16 )]
 public  System.Guid Client_Guid  { get { return _Client_Guid; } set { _Client_Guid = value; } }

 private System.String _ProjectInfo;
 /// <summary>
 /// 前期项目
 /// </summary>
 [BindColumn(5,"a", "ProjectInfo", "前期项目","", "NCHAR", 100,0,false, IsPrimaryKey =false ,IsIdentity =false,IsNullable =true,  Length =100 )]
 public  System.String ProjectInfo  { get { return _ProjectInfo; } set { _ProjectInfo = value; } }

 private System.Guid _ProjectInfo_Guid;
 /// <summary>
 /// 前期项目Id
 /// </summary>
 [BindColumn(6,"a", "ProjectInfo_Guid", "前期项目Id","", "NCHAR", 16,0,false, IsPrimaryKey =false ,IsIdentity =false,IsNullable =true,  Length =16 )]
 public  System.Guid ProjectInfo_Guid  { get { return _ProjectInfo_Guid; } set { _ProjectInfo_Guid = value; } }

 private System.String _ClientName;
 /// <summary>
 /// 客户名称
 /// </summary>
 [BindColumn(6,"a", "ClientName", "客户名称","", "NCHAR", 300,0,false, IsPrimaryKey =false ,IsIdentity =false,IsNullable =true,  Length =300 )]
 public  System.String ClientName  { get { return _ClientName; } set { _ClientName = value; } }

 private System.String _ContractName;
 /// <summary>
 /// 合同名称
 /// </summary>
 [BindColumn(7,"a", "ContractName", "合同名称","", "NCHAR", 300,0,false, IsPrimaryKey =false ,IsIdentity =false,IsNullable =true,  Length =300 )]
 public  System.String ContractName  { get { return _ContractName; } set { _ContractName = value; } }

 private System.Double _ContractAmount;
 /// <summary>
 /// 合同金额
 /// </summary>
 [BindColumn(8,"a", "ContractAmount", "合同金额","", "NCHAR", 53,0,false, IsPrimaryKey =false ,IsIdentity =false,IsNullable =true,  Length =53 )]
 public  System.Double ContractAmount  { get { return _ContractAmount; } set { _ContractAmount = value; } }

 private System.String _ProductType;
 /// <summary>
 /// 产品类型
 /// </summary>
 [BindColumn(9,"a", "ProductType", "产品类型","", "NCHAR", 50,0,false, IsPrimaryKey =false ,IsIdentity =false,IsNullable =true,  Length =50 )]
 public  System.String ProductType  { get { return _ProductType; } set { _ProductType = value; } }

 private System.String _ProjectType;
 /// <summary>
 /// 项目类型
 /// </summary>
 [BindColumn(10,"a", "ProjectType", "项目类型","", "NCHAR", 50,0,false, IsPrimaryKey =false ,IsIdentity =false,IsNullable =true,  Length =50 )]
 public  System.String ProjectType  { get { return _ProjectType; } set { _ProjectType = value; } }

 private System.String _ProjectEps;
 /// <summary>
 /// 所属EPS
 /// </summary>
 [BindColumn(11,"a", "ProjectEps", "所属EPS","", "NCHAR", 100,0,false, IsPrimaryKey =false ,IsIdentity =false,IsNullable =true,  Length =100 )]
 public  System.String ProjectEps  { get { return _ProjectEps; } set { _ProjectEps = value; } }

 private System.String _ProjectManager;
 /// <summary>
 /// 项目经理
 /// </summary>
 [BindColumn(12,"a", "ProjectManager", "项目经理","", "NCHAR", 50,0,false, IsPrimaryKey =false ,IsIdentity =false,IsNullable =true,  Length =50 )]
 public  System.String ProjectManager  { get { return _ProjectManager; } set { _ProjectManager = value; } }

 private System.Guid _ProjectManagerId;
 /// <summary>
 /// 
 /// </summary>
 [BindColumn(13,"a", "ProjectManagerId", "","", "NCHAR", 16,0,false, IsPrimaryKey =false ,IsIdentity =false,IsNullable =true,  Length =16 )]
 public  System.Guid ProjectManagerId  { get { return _ProjectManagerId; } set { _ProjectManagerId = value; } }

 private System.String _ProjectLocation;
 /// <summary>
 /// 项目地点
 /// </summary>
 [BindColumn(14,"a", "ProjectLocation", "项目地点","", "NCHAR", 50,0,false, IsPrimaryKey =false ,IsIdentity =false,IsNullable =true,  Length =50 )]
 public  System.String ProjectLocation  { get { return _ProjectLocation; } set { _ProjectLocation = value; } }

 private System.DateTime _ProjectStartDate;
 /// <summary>
 /// 计划开始
 /// </summary>
 [BindColumn(15,"a", "ProjectStartDate", "计划开始","", "NCHAR", 3,0,false, IsPrimaryKey =false ,IsIdentity =false,IsNullable =true,  Length =3 )]
 public  System.DateTime ProjectStartDate  { get { return _ProjectStartDate; } set { _ProjectStartDate = value; } }

 private System.DateTime _ProjectEndDate;
 /// <summary>
 /// 计划结束
 /// </summary>
 [BindColumn(16,"a", "ProjectEndDate", "计划结束","", "NCHAR", 3,0,false, IsPrimaryKey =false ,IsIdentity =false,IsNullable =true,  Length =3 )]
 public  System.DateTime ProjectEndDate  { get { return _ProjectEndDate; } set { _ProjectEndDate = value; } }

 private System.Guid _UpdHumId;
 /// <summary>
 /// 
 /// </summary>
 [BindColumn(17,"a", "UpdHumId", "","", "NCHAR", 16,0,false, IsPrimaryKey =false ,IsIdentity =false,IsNullable =true,  Length =16 )]
 public  System.Guid UpdHumId  { get { return _UpdHumId; } set { _UpdHumId = value; } }

 private System.String _UpdHuman;
 /// <summary>
 /// 
 /// </summary>
 [BindColumn(18,"a", "UpdHuman", "","", "NCHAR", 80,0,false, IsPrimaryKey =false ,IsIdentity =false,IsNullable =true,  Length =80 )]
 public  System.String UpdHuman  { get { return _UpdHuman; } set { _UpdHuman = value; } }

 private System.DateTime _UpdDate;
 /// <summary>
 /// 
 /// </summary>
 [BindColumn(19,"a", "UpdDate", "","", "NCHAR", 3,0,false, IsPrimaryKey =false ,IsIdentity =false,IsNullable =true,  Length =3 )]
 public  System.DateTime UpdDate  { get { return _UpdDate; } set { _UpdDate = value; } }

 private System.DateTime _RegDate;
 /// <summary>
 /// 
 /// </summary>
 [BindColumn(20,"a", "RegDate", "","", "NCHAR", 3,0,false, IsPrimaryKey =false ,IsIdentity =false,IsNullable =true,  Length =3 )]
 public  System.DateTime RegDate  { get { return _RegDate; } set { _RegDate = value; } }

 private System.String _RegHumName;
 /// <summary>
 /// 
 /// </summary>
 [BindColumn(21,"a", "RegHumName", "","", "NCHAR", 80,0,false, IsPrimaryKey =false ,IsIdentity =false,IsNullable =true,  Length =80 )]
 public  System.String RegHumName  { get { return _RegHumName; } set { _RegHumName = value; } }

 private System.Guid _RegHumId;
 /// <summary>
 /// 
 /// </summary>
 [BindColumn(22,"a", "RegHumId", "","", "NCHAR", 16,0,false, IsPrimaryKey =false ,IsIdentity =false,IsNullable =true,  Length =16 )]
 public  System.Guid RegHumId  { get { return _RegHumId; } set { _RegHumId = value; } }

 private System.String _OwnProjName;
 /// <summary>
 /// 
 /// </summary>
 [BindColumn(23,"a", "OwnProjName", "","", "NCHAR", 255,0,false, IsPrimaryKey =false ,IsIdentity =false,IsNullable =true,  Length =255 )]
 public  System.String OwnProjName  { get { return _OwnProjName; } set { _OwnProjName = value; } }

 private System.Guid _OwnProjId;
 /// <summary>
 /// 
 /// </summary>
 [BindColumn(24,"a", "OwnProjId", "","", "NCHAR", 16,0,false, IsPrimaryKey =false ,IsIdentity =false,IsNullable =true,  Length =16 )]
 public  System.Guid OwnProjId  { get { return _OwnProjId; } set { _OwnProjId = value; } }

 private System.Guid _EpsProjId;
 /// <summary>
 /// 
 /// </summary>
 [BindColumn(25,"a", "EpsProjId", "","", "NCHAR", 16,0,false, IsPrimaryKey =false ,IsIdentity =false,IsNullable =true,  Length =16 )]
 public  System.Guid EpsProjId  { get { return _EpsProjId; } set { _EpsProjId = value; } }

 private System.Guid _ApprHumId;
 /// <summary>
 /// 
 /// </summary>
 [BindColumn(26,"a", "ApprHumId", "","", "NCHAR", 16,0,false, IsPrimaryKey =false ,IsIdentity =false,IsNullable =true,  Length =16 )]
 public  System.Guid ApprHumId  { get { return _ApprHumId; } set { _ApprHumId = value; } }

 private System.String _ApprHumName;
 /// <summary>
 /// 
 /// </summary>
 [BindColumn(27,"a", "ApprHumName", "","", "NCHAR", 80,0,false, IsPrimaryKey =false ,IsIdentity =false,IsNullable =true,  Length =80 )]
 public  System.String ApprHumName  { get { return _ApprHumName; } set { _ApprHumName = value; } }

 private System.DateTime _ApprDate;
 /// <summary>
 /// 
 /// </summary>
 [BindColumn(28,"a", "ApprDate", "","", "NCHAR", 3,0,false, IsPrimaryKey =false ,IsIdentity =false,IsNullable =true,  Length =3 )]
 public  System.DateTime ApprDate  { get { return _ApprDate; } set { _ApprDate = value; } }

 private System.SByte _Status;
 /// <summary>
 /// 
 /// </summary>
 [BindColumn(29,"a", "Status", "","", "NCHAR", 3,0,false, IsPrimaryKey =false ,IsIdentity =false,IsNullable =true,  Length =3 )]
 public  System.SByte Status  { get { return _Status; } set { _Status = value; } }

 private System.String _HandOverType;
 /// <summary>
 /// 通知单类型：设计、EPC、施工、其他
 /// </summary>
 [BindColumn(35,"a", "HandOverType", "通知单类型：设计、EPC、施工、其他","", "NCHAR", 50,0,false, IsPrimaryKey =false ,IsIdentity =false,IsNullable =true,  Length =50 )]
 public  System.String HandOverType  { get { return _HandOverType; } set { _HandOverType = value; } }

 private System.String _DesignManager;
 /// <summary>
 /// 设计经理
 /// </summary>
 [BindColumn(36,"a", "DesignManager", "设计经理","", "NCHAR", 20,0,false, IsPrimaryKey =false ,IsIdentity =false,IsNullable =true,  Length =20 )]
 public  System.String DesignManager  { get { return _DesignManager; } set { _DesignManager = value; } }

 private System.Guid _DesignManagerId;
 /// <summary>
 /// 设计经理Id
 /// </summary>
 [BindColumn(37,"a", "DesignManagerId", "设计经理Id","", "NCHAR", 16,0,false, IsPrimaryKey =false ,IsIdentity =false,IsNullable =true,  Length =16 )]
 public  System.Guid DesignManagerId  { get { return _DesignManagerId; } set { _DesignManagerId = value; } }

 private System.Double _SubmitFileNum;
 /// <summary>
 /// 设计成品份数
 /// </summary>
 [BindColumn(38,"a", "SubmitFileNum", "设计成品份数","", "NCHAR", 53,0,false, IsPrimaryKey =false ,IsIdentity =false,IsNullable =true,  Length =53 )]
 public  System.Double SubmitFileNum  { get { return _SubmitFileNum; } set { _SubmitFileNum = value; } }

 private System.String _ProjectPhase;
 /// <summary>
 /// 设计阶段
 /// </summary>
 [BindColumn(39,"a", "ProjectPhase", "设计阶段","", "NCHAR", 50,0,false, IsPrimaryKey =false ,IsIdentity =false,IsNullable =true,  Length =50 )]
 public  System.String ProjectPhase  { get { return _ProjectPhase; } set { _ProjectPhase = value; } }

      
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
			    if (name == "PROJECTNAME")
{
return _ProjectName;
}
if (name == "PROJECTOVERVIEW")
{
return _ProjectOverview;
}
if (name == "PROJECTCODE")
{
return _ProjectCode;
}
if (name == "PROJECTSHORTNAME")
{
return _ProjectShortName;
}
if (name == "MEMO")
{
return _Memo;
}
if (name == "ID")
{
return _Id;
}
if (name == "PROJECTEPS_GUID")
{
return _ProjectEps_Guid;
}
if (name == "CONTRACTREVIEW_GUID")
{
return _ContractReview_Guid;
}
if (name == "CONOTRACTINFO_GUID")
{
return _ConotractInfo_Guid;
}
if (name == "STARTUPACCORDING")
{
return _StartupAccording;
}
if (name == "CLIENT_GUID")
{
return _Client_Guid;
}
if (name == "PROJECTINFO")
{
return _ProjectInfo;
}
if (name == "PROJECTINFO_GUID")
{
return _ProjectInfo_Guid;
}
if (name == "CLIENTNAME")
{
return _ClientName;
}
if (name == "CONTRACTNAME")
{
return _ContractName;
}
if (name == "CONTRACTAMOUNT")
{
return _ContractAmount;
}
if (name == "PRODUCTTYPE")
{
return _ProductType;
}
if (name == "PROJECTTYPE")
{
return _ProjectType;
}
if (name == "PROJECTEPS")
{
return _ProjectEps;
}
if (name == "PROJECTMANAGER")
{
return _ProjectManager;
}
if (name == "PROJECTMANAGERID")
{
return _ProjectManagerId;
}
if (name == "PROJECTLOCATION")
{
return _ProjectLocation;
}
if (name == "PROJECTSTARTDATE")
{
return _ProjectStartDate;
}
if (name == "PROJECTENDDATE")
{
return _ProjectEndDate;
}
if (name == "UPDHUMID")
{
return _UpdHumId;
}
if (name == "UPDHUMAN")
{
return _UpdHuman;
}
if (name == "UPDDATE")
{
return _UpdDate;
}
if (name == "REGDATE")
{
return _RegDate;
}
if (name == "REGHUMNAME")
{
return _RegHumName;
}
if (name == "REGHUMID")
{
return _RegHumId;
}
if (name == "OWNPROJNAME")
{
return _OwnProjName;
}
if (name == "OWNPROJID")
{
return _OwnProjId;
}
if (name == "EPSPROJID")
{
return _EpsProjId;
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
if (name == "STATUS")
{
return _Status;
}
if (name == "HANDOVERTYPE")
{
return _HandOverType;
}
if (name == "DESIGNMANAGER")
{
return _DesignManager;
}
if (name == "DESIGNMANAGERID")
{
return _DesignManagerId;
}
if (name == "SUBMITFILENUM")
{
return _SubmitFileNum;
}
if (name == "PROJECTPHASE")
{
return _ProjectPhase;
}

			    return base[name];
			}
			set 
			{
			   name = name.ToUpper();
			       if (name == "PROJECTNAME")
{
 _ProjectName = System.Convert.ToString(value);return;
}
if (name == "PROJECTOVERVIEW")
{
 _ProjectOverview = System.Convert.ToString(value);return;
}
if (name == "PROJECTCODE")
{
 _ProjectCode = System.Convert.ToString(value);return;
}
if (name == "PROJECTSHORTNAME")
{
 _ProjectShortName = System.Convert.ToString(value);return;
}
if (name == "MEMO")
{
 _Memo = System.Convert.ToString(value);return;
}
if (name == "ID")
{
 _Id = XCode.Common.Helper.ConvertToGuid(value);return;
}
if (name == "PROJECTEPS_GUID")
{
 _ProjectEps_Guid = XCode.Common.Helper.ConvertToGuid(value);return;
}
if (name == "CONTRACTREVIEW_GUID")
{
 _ContractReview_Guid = XCode.Common.Helper.ConvertToGuid(value);return;
}
if (name == "CONOTRACTINFO_GUID")
{
 _ConotractInfo_Guid = XCode.Common.Helper.ConvertToGuid(value);return;
}
if (name == "STARTUPACCORDING")
{
 _StartupAccording = System.Convert.ToString(value);return;
}
if (name == "CLIENT_GUID")
{
 _Client_Guid = XCode.Common.Helper.ConvertToGuid(value);return;
}
if (name == "PROJECTINFO")
{
 _ProjectInfo = System.Convert.ToString(value);return;
}
if (name == "PROJECTINFO_GUID")
{
 _ProjectInfo_Guid = XCode.Common.Helper.ConvertToGuid(value);return;
}
if (name == "CLIENTNAME")
{
 _ClientName = System.Convert.ToString(value);return;
}
if (name == "CONTRACTNAME")
{
 _ContractName = System.Convert.ToString(value);return;
}
if (name == "CONTRACTAMOUNT")
{
 _ContractAmount = System.Convert.ToDouble(value);return;
}
if (name == "PRODUCTTYPE")
{
 _ProductType = System.Convert.ToString(value);return;
}
if (name == "PROJECTTYPE")
{
 _ProjectType = System.Convert.ToString(value);return;
}
if (name == "PROJECTEPS")
{
 _ProjectEps = System.Convert.ToString(value);return;
}
if (name == "PROJECTMANAGER")
{
 _ProjectManager = System.Convert.ToString(value);return;
}
if (name == "PROJECTMANAGERID")
{
 _ProjectManagerId = XCode.Common.Helper.ConvertToGuid(value);return;
}
if (name == "PROJECTLOCATION")
{
 _ProjectLocation = System.Convert.ToString(value);return;
}
if (name == "PROJECTSTARTDATE")
{
 if (value == null || value.ToString().IsNullOrEmpty() == true) value = DateTime.MinValue;
 _ProjectStartDate = System.Convert.ToDateTime(value);return;
}
if (name == "PROJECTENDDATE")
{
 if (value == null || value.ToString().IsNullOrEmpty() == true) value = DateTime.MinValue;
 _ProjectEndDate = System.Convert.ToDateTime(value);return;
}
if (name == "UPDHUMID")
{
 _UpdHumId = XCode.Common.Helper.ConvertToGuid(value);return;
}
if (name == "UPDHUMAN")
{
 _UpdHuman = System.Convert.ToString(value);return;
}
if (name == "UPDDATE")
{
 if (value == null || value.ToString().IsNullOrEmpty() == true) value = DateTime.MinValue;
 _UpdDate = System.Convert.ToDateTime(value);return;
}
if (name == "REGDATE")
{
 if (value == null || value.ToString().IsNullOrEmpty() == true) value = DateTime.MinValue;
 _RegDate = System.Convert.ToDateTime(value);return;
}
if (name == "REGHUMNAME")
{
 _RegHumName = System.Convert.ToString(value);return;
}
if (name == "REGHUMID")
{
 _RegHumId = XCode.Common.Helper.ConvertToGuid(value);return;
}
if (name == "OWNPROJNAME")
{
 _OwnProjName = System.Convert.ToString(value);return;
}
if (name == "OWNPROJID")
{
 _OwnProjId = XCode.Common.Helper.ConvertToGuid(value);return;
}
if (name == "EPSPROJID")
{
 _EpsProjId = XCode.Common.Helper.ConvertToGuid(value);return;
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
if (name == "STATUS")
{
 _Status = System.Convert.ToSByte(value);return;
}
if (name == "HANDOVERTYPE")
{
 _HandOverType = System.Convert.ToString(value);return;
}
if (name == "DESIGNMANAGER")
{
 _DesignManager = System.Convert.ToString(value);return;
}
if (name == "DESIGNMANAGERID")
{
 _DesignManagerId = XCode.Common.Helper.ConvertToGuid(value);return;
}
if (name == "SUBMITFILENUM")
{
 _SubmitFileNum = System.Convert.ToDouble(value);return;
}
if (name == "PROJECTPHASE")
{
 _ProjectPhase = System.Convert.ToString(value);return;
}

			    base[name] = value;
			}
		}
		#endregion
	}
}