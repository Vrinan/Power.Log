 
 
 using    System;
 using System.Collections.Generic;
 using System.Text; 
 using XCode.Attributes    ;

 namespace  Power.Systems.StdMarket.StdMarket
{
    /// <summary>
    /// 前期项目信息
    /// </summary>
    public class PS_ProjectInfoDO : PS_ProjectInfoDO<PS_ProjectInfoDO>
    {

    }

	/// <summary>
    /// 前期项目信息
    /// </summary>
	  [BindEntity(KeyWord="PS_ProjectInfo",EntityType = typeof(Power.Systems.StdMarket.StdMarket.PS_ProjectInfoDO),Description = "前期项目信息"  )] 

	 [BindTable( "PS_MK_ProjectInfo", Alias = "a",IsAttach=false,Description ="")]

	  [BindIndex(Name = "pk_PS_MK_ProjectInfo", KeyType = Power.DataAccessLayer.KeyType.MainKey, Columns = "Id", TableName = "PS_MK_ProjectInfo",Description="")]

    public   class PS_ProjectInfoDO<TEntity> : XCode.Entity<TEntity>, XCode.IEntity where TEntity : Power.Systems.StdMarket.StdMarket.PS_ProjectInfoDO<TEntity>, new()
    { 
	    #region 属性

	    
 private System.String _FollowLevel;
 /// <summary>
 /// 跟踪级别
 /// </summary>
 [BindColumn(1,"a", "FollowLevel", "跟踪级别","", "NCHAR", 6,0,false, IsPrimaryKey =false ,IsIdentity =false,IsNullable =true,  Length =6 )]
 public  System.String FollowLevel  { get { return _FollowLevel; } set { _FollowLevel = value; } }

 private System.String _OwnProjName;
 /// <summary>
 /// 
 /// </summary>
 [BindColumn(1,"a", "OwnProjName", "","", "NCHAR", 255,0,false, IsPrimaryKey =false ,IsIdentity =false,IsNullable =true,  Length =255 )]
 public  System.String OwnProjName  { get { return _OwnProjName; } set { _OwnProjName = value; } }

 private System.Int32 _isFollow;
 /// <summary>
 /// 是否跟进
 /// </summary>
 [BindColumn(1,"a", "isFollow", "是否跟进","", "NCHAR", 6,0,false, IsPrimaryKey =false ,IsIdentity =false,IsNullable =true,  Length =6 )]
 public  System.Int32 isFollow  { get { return _isFollow; } set { _isFollow = value; } }

 private System.SByte _Status;
 /// <summary>
 /// 
 /// </summary>
 [BindColumn(1,"a", "Status", "","", "NCHAR", 3,0,false, IsPrimaryKey =false ,IsIdentity =false,IsNullable =true,  Length =3 )]
 public  System.SByte Status  { get { return _Status; } set { _Status = value; } }

 private System.Guid _Id;
 /// <summary>
 /// 
 /// </summary>
 [BindColumn(1,"a", "Id", "","", "NCHAR", 16,0,false, IsPrimaryKey =true ,IsIdentity =true,IsNullable =false,  Length =16 )]
 public virtual System.Guid Id  { get { return _Id; } set { _Id = value; } }

 private System.Guid _SaleClue_Guid;
 /// <summary>
 /// 线索GUId
 /// </summary>
 [BindColumn(2,"a", "SaleClue_Guid", "线索GUId","", "NCHAR", 16,0,false, IsPrimaryKey =false ,IsIdentity =false,IsNullable =true,  Length =16 )]
 public  System.Guid SaleClue_Guid  { get { return _SaleClue_Guid; } set { _SaleClue_Guid = value; } }

 private System.String _ProjectId;
 /// <summary>
 /// 项目编号
 /// </summary>
 [BindColumn(3,"a", "ProjectId", "项目编号","", "NCHAR", 50,0,false, IsPrimaryKey =false ,IsIdentity =false,IsNullable =true,  Length =50 )]
 public  System.String ProjectId  { get { return _ProjectId; } set { _ProjectId = value; } }

 private System.String _ProjectName;
 /// <summary>
 /// 项目名称
 /// </summary>
 [BindColumn(4,"a", "ProjectName", "项目名称","", "NCHAR", 300,0,false, IsPrimaryKey =false ,IsIdentity =false,IsNullable =true,  Length =300 )]
 public  System.String ProjectName  { get { return _ProjectName; } set { _ProjectName = value; } }

 private System.String _ProjectShortName;
 /// <summary>
 /// 项目简称
 /// </summary>
 [BindColumn(5,"a", "ProjectShortName", "项目简称","", "NCHAR", 500,0,false, IsPrimaryKey =false ,IsIdentity =false,IsNullable =true,  Length =500 )]
 public  System.String ProjectShortName  { get { return _ProjectShortName; } set { _ProjectShortName = value; } }

 private System.String _InfoSources;
 /// <summary>
 /// 信息来源，下拉
 /// </summary>
 [BindColumn(6,"a", "InfoSources", "信息来源，下拉","", "NCHAR", 50,0,false, IsPrimaryKey =false ,IsIdentity =false,IsNullable =true,  Length =50 )]
 public  System.String InfoSources  { get { return _InfoSources; } set { _InfoSources = value; } }

 private System.String _ProjectType;
 /// <summary>
 /// 项目类型，下拉
 /// </summary>
 [BindColumn(7,"a", "ProjectType", "项目类型，下拉","", "NCHAR", 50,0,false, IsPrimaryKey =false ,IsIdentity =false,IsNullable =true,  Length =50 )]
 public  System.String ProjectType  { get { return _ProjectType; } set { _ProjectType = value; } }

 private System.String _ProjectSize;
 /// <summary>
 /// 项目规模
 /// </summary>
 [BindColumn(8,"a", "ProjectSize", "项目规模","", "NCHAR", 50,0,false, IsPrimaryKey =false ,IsIdentity =false,IsNullable =true,  Length =50 )]
 public  System.String ProjectSize  { get { return _ProjectSize; } set { _ProjectSize = value; } }

 private System.String _ProjectLocation;
 /// <summary>
 /// 项目地点
 /// </summary>
 [BindColumn(9,"a", "ProjectLocation", "项目地点","", "NCHAR", 50,0,false, IsPrimaryKey =false ,IsIdentity =false,IsNullable =true,  Length =50 )]
 public  System.String ProjectLocation  { get { return _ProjectLocation; } set { _ProjectLocation = value; } }

 private System.String _ProjectArea;
 /// <summary>
 /// 项目区域，下拉
 /// </summary>
 [BindColumn(10,"a", "ProjectArea", "项目区域，下拉","", "NCHAR", 50,0,false, IsPrimaryKey =false ,IsIdentity =false,IsNullable =true,  Length =50 )]
 public  System.String ProjectArea  { get { return _ProjectArea; } set { _ProjectArea = value; } }

 private System.String _ProductType;
 /// <summary>
 /// 产品类型，下拉
 /// </summary>
 [BindColumn(11,"a", "ProductType", "产品类型，下拉","", "NCHAR", 50,0,false, IsPrimaryKey =false ,IsIdentity =false,IsNullable =true,  Length =50 )]
 public  System.String ProductType  { get { return _ProductType; } set { _ProductType = value; } }

 private System.String _SourcesOfFunds;
 /// <summary>
 /// 资金来源
 /// </summary>
 [BindColumn(12,"a", "SourcesOfFunds", "资金来源","", "NCHAR", 50,0,false, IsPrimaryKey =false ,IsIdentity =false,IsNullable =true,  Length =50 )]
 public  System.String SourcesOfFunds  { get { return _SourcesOfFunds; } set { _SourcesOfFunds = value; } }

 private System.Double _ProjectInvestAmount;
 /// <summary>
 /// 投资规模
 /// </summary>
 [BindColumn(13,"a", "ProjectInvestAmount", "投资规模","", "NCHAR", 53,0,false, IsPrimaryKey =false ,IsIdentity =false,IsNullable =true,  Length =53 )]
 public  System.Double ProjectInvestAmount  { get { return _ProjectInvestAmount; } set { _ProjectInvestAmount = value; } }

 private System.String _TenderType;
 /// <summary>
 /// 招标形式，下拉
 /// </summary>
 [BindColumn(14,"a", "TenderType", "招标形式，下拉","", "NCHAR", 50,0,false, IsPrimaryKey =false ,IsIdentity =false,IsNullable =true,  Length =50 )]
 public  System.String TenderType  { get { return _TenderType; } set { _TenderType = value; } }

 private System.String _ContractType;
 /// <summary>
 /// 预计合同形式，下拉
 /// </summary>
 [BindColumn(15,"a", "ContractType", "预计合同形式，下拉","", "NCHAR", 50,0,false, IsPrimaryKey =false ,IsIdentity =false,IsNullable =true,  Length =50 )]
 public  System.String ContractType  { get { return _ContractType; } set { _ContractType = value; } }

 private System.Double _ForcastContractAmount;
 /// <summary>
 /// 预计合同额
 /// </summary>
 [BindColumn(16,"a", "ForcastContractAmount", "预计合同额","", "NCHAR", 53,0,false, IsPrimaryKey =false ,IsIdentity =false,IsNullable =true,  Length =53 )]
 public  System.Double ForcastContractAmount  { get { return _ForcastContractAmount; } set { _ForcastContractAmount = value; } }

 private System.String _CurrencyType;
 /// <summary>
 /// 币种，下拉
 /// </summary>
 [BindColumn(17,"a", "CurrencyType", "币种，下拉","", "NCHAR", 10,0,false, IsPrimaryKey =false ,IsIdentity =false,IsNullable =true,  Length =10 )]
 public  System.String CurrencyType  { get { return _CurrencyType; } set { _CurrencyType = value; } }

 private System.Guid _Client_Guid;
 /// <summary>
 /// 客户Guid
 /// </summary>
 [BindColumn(18,"a", "Client_Guid", "客户Guid","", "NCHAR", 16,0,false, IsPrimaryKey =false ,IsIdentity =false,IsNullable =true,  Length =16 )]
 public  System.Guid Client_Guid  { get { return _Client_Guid; } set { _Client_Guid = value; } }

 private System.Guid _FollowHumanId;
 /// <summary>
 /// 跟进人Id
 /// </summary>
 [BindColumn(19,"a", "FollowHumanId", "跟进人Id","", "NCHAR", 16,0,false, IsPrimaryKey =false ,IsIdentity =false,IsNullable =true,  Length =16 )]
 public  System.Guid FollowHumanId  { get { return _FollowHumanId; } set { _FollowHumanId = value; } }

 private System.String _FollowHuman;
 /// <summary>
 /// 跟进人名称
 /// </summary>
 [BindColumn(20,"a", "FollowHuman", "跟进人名称","", "NCHAR", 50,0,false, IsPrimaryKey =false ,IsIdentity =false,IsNullable =true,  Length =50 )]
 public  System.String FollowHuman  { get { return _FollowHuman; } set { _FollowHuman = value; } }

 private System.String _FollowDept;
 /// <summary>
 /// 跟进部门
 /// </summary>
 [BindColumn(21,"a", "FollowDept", "跟进部门","", "NCHAR", 50,0,false, IsPrimaryKey =false ,IsIdentity =false,IsNullable =true,  Length =50 )]
 public  System.String FollowDept  { get { return _FollowDept; } set { _FollowDept = value; } }

 private System.String _FollowStatus;
 /// <summary>
 /// 跟进状态，下拉
 /// </summary>
 [BindColumn(22,"a", "FollowStatus", "跟进状态，下拉","", "NCHAR", 6,0,false, IsPrimaryKey =false ,IsIdentity =false,IsNullable =true,  Length =6 )]
 public  System.String FollowStatus  { get { return _FollowStatus; } set { _FollowStatus = value; } }

 private System.Int32 _isPrequalification;
 /// <summary>
 /// 是否资格预审，勾选
 /// </summary>
 [BindColumn(24,"a", "isPrequalification", "是否资格预审，勾选","", "NCHAR", 6,0,false, IsPrimaryKey =false ,IsIdentity =false,IsNullable =true,  Length =6 )]
 public  System.Int32 isPrequalification  { get { return _isPrequalification; } set { _isPrequalification = value; } }

 private System.DateTime _PrequalificationDeadline;
 /// <summary>
 /// 资格预审截至日期
 /// </summary>
 [BindColumn(25,"a", "PrequalificationDeadline", "资格预审截至日期","", "NCHAR", 0,0,false, IsPrimaryKey =false ,IsIdentity =false,IsNullable =true,  Length =0 )]
 public  System.DateTime PrequalificationDeadline  { get { return _PrequalificationDeadline; } set { _PrequalificationDeadline = value; } }

 private System.Guid _FollowDeptId;
 /// <summary>
 /// 
 /// </summary>
 [BindColumn(26,"a", "FollowDeptId", "","", "NCHAR", 16,0,false, IsPrimaryKey =false ,IsIdentity =false,IsNullable =true,  Length =16 )]
 public  System.Guid FollowDeptId  { get { return _FollowDeptId; } set { _FollowDeptId = value; } }

 private System.Guid _UpdHumId;
 /// <summary>
 /// 
 /// </summary>
 [BindColumn(27,"a", "UpdHumId", "","", "NCHAR", 16,0,false, IsPrimaryKey =false ,IsIdentity =false,IsNullable =true,  Length =16 )]
 public  System.Guid UpdHumId  { get { return _UpdHumId; } set { _UpdHumId = value; } }

 private System.String _UpdHuman;
 /// <summary>
 /// 
 /// </summary>
 [BindColumn(28,"a", "UpdHuman", "","", "NCHAR", 80,0,false, IsPrimaryKey =false ,IsIdentity =false,IsNullable =true,  Length =80 )]
 public  System.String UpdHuman  { get { return _UpdHuman; } set { _UpdHuman = value; } }

 private System.DateTime _UpdDate;
 /// <summary>
 /// 
 /// </summary>
 [BindColumn(29,"a", "UpdDate", "","", "NCHAR", 3,0,false, IsPrimaryKey =false ,IsIdentity =false,IsNullable =true,  Length =3 )]
 public  System.DateTime UpdDate  { get { return _UpdDate; } set { _UpdDate = value; } }

 private System.DateTime _RegDate;
 /// <summary>
 /// 
 /// </summary>
 [BindColumn(30,"a", "RegDate", "","", "NCHAR", 3,0,false, IsPrimaryKey =false ,IsIdentity =false,IsNullable =true,  Length =3 )]
 public  System.DateTime RegDate  { get { return _RegDate; } set { _RegDate = value; } }

 private System.String _RegHumName;
 /// <summary>
 /// 
 /// </summary>
 [BindColumn(31,"a", "RegHumName", "","", "NCHAR", 80,0,false, IsPrimaryKey =false ,IsIdentity =false,IsNullable =true,  Length =80 )]
 public  System.String RegHumName  { get { return _RegHumName; } set { _RegHumName = value; } }

 private System.Guid _RegHumId;
 /// <summary>
 /// 
 /// </summary>
 [BindColumn(32,"a", "RegHumId", "","", "NCHAR", 16,0,false, IsPrimaryKey =false ,IsIdentity =false,IsNullable =true,  Length =16 )]
 public  System.Guid RegHumId  { get { return _RegHumId; } set { _RegHumId = value; } }

 private System.Guid _OwnProjId;
 /// <summary>
 /// 
 /// </summary>
 [BindColumn(33,"a", "OwnProjId", "","", "NCHAR", 16,0,false, IsPrimaryKey =false ,IsIdentity =false,IsNullable =true,  Length =16 )]
 public  System.Guid OwnProjId  { get { return _OwnProjId; } set { _OwnProjId = value; } }

 private System.Guid _EpsProjId;
 /// <summary>
 /// 
 /// </summary>
 [BindColumn(34,"a", "EpsProjId", "","", "NCHAR", 16,0,false, IsPrimaryKey =false ,IsIdentity =false,IsNullable =true,  Length =16 )]
 public  System.Guid EpsProjId  { get { return _EpsProjId; } set { _EpsProjId = value; } }

 private System.Guid _ApprHumId;
 /// <summary>
 /// 
 /// </summary>
 [BindColumn(35,"a", "ApprHumId", "","", "NCHAR", 16,0,false, IsPrimaryKey =false ,IsIdentity =false,IsNullable =true,  Length =16 )]
 public  System.Guid ApprHumId  { get { return _ApprHumId; } set { _ApprHumId = value; } }

 private System.String _ApprHumName;
 /// <summary>
 /// 
 /// </summary>
 [BindColumn(36,"a", "ApprHumName", "","", "NCHAR", 80,0,false, IsPrimaryKey =false ,IsIdentity =false,IsNullable =true,  Length =80 )]
 public  System.String ApprHumName  { get { return _ApprHumName; } set { _ApprHumName = value; } }

 private System.DateTime _ApprDate;
 /// <summary>
 /// 
 /// </summary>
 [BindColumn(37,"a", "ApprDate", "","", "NCHAR", 3,0,false, IsPrimaryKey =false ,IsIdentity =false,IsNullable =true,  Length =3 )]
 public  System.DateTime ApprDate  { get { return _ApprDate; } set { _ApprDate = value; } }

      
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
			    if (name == "FOLLOWLEVEL")
{
return _FollowLevel;
}
if (name == "OWNPROJNAME")
{
return _OwnProjName;
}
if (name == "ISFOLLOW")
{
return _isFollow;
}
if (name == "STATUS")
{
return _Status;
}
if (name == "ID")
{
return _Id;
}
if (name == "SALECLUE_GUID")
{
return _SaleClue_Guid;
}
if (name == "PROJECTID")
{
return _ProjectId;
}
if (name == "PROJECTNAME")
{
return _ProjectName;
}
if (name == "PROJECTSHORTNAME")
{
return _ProjectShortName;
}
if (name == "INFOSOURCES")
{
return _InfoSources;
}
if (name == "PROJECTTYPE")
{
return _ProjectType;
}
if (name == "PROJECTSIZE")
{
return _ProjectSize;
}
if (name == "PROJECTLOCATION")
{
return _ProjectLocation;
}
if (name == "PROJECTAREA")
{
return _ProjectArea;
}
if (name == "PRODUCTTYPE")
{
return _ProductType;
}
if (name == "SOURCESOFFUNDS")
{
return _SourcesOfFunds;
}
if (name == "PROJECTINVESTAMOUNT")
{
return _ProjectInvestAmount;
}
if (name == "TENDERTYPE")
{
return _TenderType;
}
if (name == "CONTRACTTYPE")
{
return _ContractType;
}
if (name == "FORCASTCONTRACTAMOUNT")
{
return _ForcastContractAmount;
}
if (name == "CURRENCYTYPE")
{
return _CurrencyType;
}
if (name == "CLIENT_GUID")
{
return _Client_Guid;
}
if (name == "FOLLOWHUMANID")
{
return _FollowHumanId;
}
if (name == "FOLLOWHUMAN")
{
return _FollowHuman;
}
if (name == "FOLLOWDEPT")
{
return _FollowDept;
}
if (name == "FOLLOWSTATUS")
{
return _FollowStatus;
}
if (name == "ISPREQUALIFICATION")
{
return _isPrequalification;
}
if (name == "PREQUALIFICATIONDEADLINE")
{
return _PrequalificationDeadline;
}
if (name == "FOLLOWDEPTID")
{
return _FollowDeptId;
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

			    return base[name];
			}
			set 
			{
			   name = name.ToUpper();
			       if (name == "FOLLOWLEVEL")
{
 _FollowLevel = System.Convert.ToString(value);return;
}
if (name == "OWNPROJNAME")
{
 _OwnProjName = System.Convert.ToString(value);return;
}
if (name == "ISFOLLOW")
{
 _isFollow = System.Convert.ToInt32(value);return;
}
if (name == "STATUS")
{
 _Status = System.Convert.ToSByte(value);return;
}
if (name == "ID")
{
 _Id = XCode.Common.Helper.ConvertToGuid(value);return;
}
if (name == "SALECLUE_GUID")
{
 _SaleClue_Guid = XCode.Common.Helper.ConvertToGuid(value);return;
}
if (name == "PROJECTID")
{
 _ProjectId = System.Convert.ToString(value);return;
}
if (name == "PROJECTNAME")
{
 _ProjectName = System.Convert.ToString(value);return;
}
if (name == "PROJECTSHORTNAME")
{
 _ProjectShortName = System.Convert.ToString(value);return;
}
if (name == "INFOSOURCES")
{
 _InfoSources = System.Convert.ToString(value);return;
}
if (name == "PROJECTTYPE")
{
 _ProjectType = System.Convert.ToString(value);return;
}
if (name == "PROJECTSIZE")
{
 _ProjectSize = System.Convert.ToString(value);return;
}
if (name == "PROJECTLOCATION")
{
 _ProjectLocation = System.Convert.ToString(value);return;
}
if (name == "PROJECTAREA")
{
 _ProjectArea = System.Convert.ToString(value);return;
}
if (name == "PRODUCTTYPE")
{
 _ProductType = System.Convert.ToString(value);return;
}
if (name == "SOURCESOFFUNDS")
{
 _SourcesOfFunds = System.Convert.ToString(value);return;
}
if (name == "PROJECTINVESTAMOUNT")
{
 _ProjectInvestAmount = System.Convert.ToDouble(value);return;
}
if (name == "TENDERTYPE")
{
 _TenderType = System.Convert.ToString(value);return;
}
if (name == "CONTRACTTYPE")
{
 _ContractType = System.Convert.ToString(value);return;
}
if (name == "FORCASTCONTRACTAMOUNT")
{
 _ForcastContractAmount = System.Convert.ToDouble(value);return;
}
if (name == "CURRENCYTYPE")
{
 _CurrencyType = System.Convert.ToString(value);return;
}
if (name == "CLIENT_GUID")
{
 _Client_Guid = XCode.Common.Helper.ConvertToGuid(value);return;
}
if (name == "FOLLOWHUMANID")
{
 _FollowHumanId = XCode.Common.Helper.ConvertToGuid(value);return;
}
if (name == "FOLLOWHUMAN")
{
 _FollowHuman = System.Convert.ToString(value);return;
}
if (name == "FOLLOWDEPT")
{
 _FollowDept = System.Convert.ToString(value);return;
}
if (name == "FOLLOWSTATUS")
{
 _FollowStatus = System.Convert.ToString(value);return;
}
if (name == "ISPREQUALIFICATION")
{
 _isPrequalification = System.Convert.ToInt32(value);return;
}
if (name == "PREQUALIFICATIONDEADLINE")
{
 if (value == null || value.ToString().IsNullOrEmpty() == true) value = DateTime.MinValue;
 _PrequalificationDeadline = System.Convert.ToDateTime(value);return;
}
if (name == "FOLLOWDEPTID")
{
 _FollowDeptId = XCode.Common.Helper.ConvertToGuid(value);return;
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

			    base[name] = value;
			}
		}
		#endregion
	}
}