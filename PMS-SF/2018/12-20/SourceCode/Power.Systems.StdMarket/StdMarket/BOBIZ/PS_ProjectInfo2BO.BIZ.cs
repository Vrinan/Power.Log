 
 

 using System;
 using System.Collections;
 using System.Collections.Generic;
 using System.Text; 
 using Power.Business.Attributes;
 using Power.Business;

 namespace  Power.Systems.StdMarket.StdMarket
{  
    /// <summary>
    /// 前期项目跟踪
    /// </summary>
    [BindBusinessObject(KeyWord="PS_ProjectInfo2",EntityType = typeof(Power.Systems.StdMarket.StdMarket.PS_ProjectInfo2DO),BusinessType=Power.Business.Attributes.EBusinessType.Main ,Description = "前期项目跟踪" ,DefaultBindWorkFlow = true)] 
    public partial  class PS_ProjectInfo2BO : PS_ProjectInfo2BO<PS_ProjectInfo2BO >
    {

    }

	/// <summary>
    /// 前期项目跟踪
    /// </summary>  
	public    partial class PS_ProjectInfo2BO<TBusiness> : Power.Business.BaseBusiness<TBusiness>, Power.Systems.StdMarket.IStdMarket.IPS_ProjectInfo2BO 
        where TBusiness : Power.Systems.StdMarket.IStdMarket.IPS_ProjectInfo2BO, new()
		
    { 

	    #region 下辖业务对象
           
		#endregion 

	    #region 属性 

	 private  System.String _ClientName;
/// <summary>
/// 
/// </summary>
[BindProperty(PropertySource = Power.Business.Attributes.EnumPropertySource.Business,Description = "")]
[BindPropertyUse(PropertyUse = Power.Business.Attributes.EBusinessPropertyUse.ForeignLinkValue,SourcePropertyName = "Client_Guid",ForeignName = "Name" )]
public System.String ClientName { get { return _ClientName; } set { _ClientName = value; }  }

private  System.Guid _Id;
/// <summary>
/// 
/// </summary>
[BindProperty(Description = "")]
[BindPropertyUse(PropertyUse = Power.Business.Attributes.EBusinessPropertyUse.PrimaryKey )]
public System.Guid Id { get { return _Id; } set { _Id = value; }  }

private  System.Guid _SaleClue_Guid;
/// <summary>
/// 
/// </summary>
[BindProperty(Description = "")]
public System.Guid SaleClue_Guid { get { return _SaleClue_Guid; } set { _SaleClue_Guid = value; }  }

private  System.String _ProjectId;
/// <summary>
/// 项目编号
/// </summary>
[BindProperty(Description = "项目编号")]
public System.String ProjectId { get { return _ProjectId; } set { _ProjectId = value; }  }

private  System.String _ProjectName;
/// <summary>
/// 项目名称
/// </summary>
[BindProperty(Description = "项目名称")]
[BindPropertyUse(PropertyUse = Power.Business.Attributes.EBusinessPropertyUse.TitleField )]
public System.String ProjectName { get { return _ProjectName; } set { _ProjectName = value; }  }

private  System.String _ProjectShortName;
/// <summary>
/// 项目简称
/// </summary>
[BindProperty(Description = "项目简称")]
public System.String ProjectShortName { get { return _ProjectShortName; } set { _ProjectShortName = value; }  }

private  System.String _InfoSources;
/// <summary>
/// 信息来源
/// </summary>
[BindProperty(Description = "信息来源")]
public System.String InfoSources { get { return _InfoSources; } set { _InfoSources = value; }  }

private  System.String _ProjectType;
/// <summary>
/// 项目类型
/// </summary>
[BindProperty(Description = "项目类型")]
public System.String ProjectType { get { return _ProjectType; } set { _ProjectType = value; }  }

private  System.String _ProjectSize;
/// <summary>
/// 项目规模
/// </summary>
[BindProperty(Description = "项目规模")]
public System.String ProjectSize { get { return _ProjectSize; } set { _ProjectSize = value; }  }

private  System.String _ProjectLocation;
/// <summary>
/// 项目地点
/// </summary>
[BindProperty(Description = "项目地点")]
public System.String ProjectLocation { get { return _ProjectLocation; } set { _ProjectLocation = value; }  }

private  System.String _ProjectArea;
/// <summary>
/// 项目区域
/// </summary>
[BindProperty(Description = "项目区域")]
public System.String ProjectArea { get { return _ProjectArea; } set { _ProjectArea = value; }  }

private  System.String _ProductType;
/// <summary>
/// 产品类型
/// </summary>
[BindProperty(Description = "产品类型")]
public System.String ProductType { get { return _ProductType; } set { _ProductType = value; }  }

private  System.String _SourcesOfFunds;
/// <summary>
/// 资金来源
/// </summary>
[BindProperty(Description = "资金来源")]
public System.String SourcesOfFunds { get { return _SourcesOfFunds; } set { _SourcesOfFunds = value; }  }

private  System.Double _ProjectInvestAmount;
/// <summary>
/// 投资规模
/// </summary>
[BindProperty(Description = "投资规模")]
public System.Double ProjectInvestAmount { get { return _ProjectInvestAmount; } set { _ProjectInvestAmount = value; }  }

private  System.String _TenderType;
/// <summary>
/// 招标形式
/// </summary>
[BindProperty(Description = "招标形式")]
public System.String TenderType { get { return _TenderType; } set { _TenderType = value; }  }

private  System.String _ContractType;
/// <summary>
/// 合同形式
/// </summary>
[BindProperty(Description = "合同形式")]
public System.String ContractType { get { return _ContractType; } set { _ContractType = value; }  }

private  System.Double _ForcastContractAmount;
/// <summary>
/// 预计合同额
/// </summary>
[BindProperty(Description = "预计合同额")]
public System.Double ForcastContractAmount { get { return _ForcastContractAmount; } set { _ForcastContractAmount = value; }  }

private  System.String _CurrencyType;
/// <summary>
/// 币种
/// </summary>
[BindProperty(Description = "币种")]
public System.String CurrencyType { get { return _CurrencyType; } set { _CurrencyType = value; }  }

private  System.Guid _Client_Guid;
/// <summary>
/// 
/// </summary>
[BindProperty(Description = "")]
[BindPropertyUse(PropertyUse = Power.Business.Attributes.EBusinessPropertyUse.ForeignKey, KeyWord = "Organize",DataSource =  EDataSourceType.Entity,ForeignName = "Id",IsNull = true )]
public System.Guid Client_Guid { get { return _Client_Guid; } set { _Client_Guid = value; }  }

private  System.Guid _FollowHumanId;
/// <summary>
/// 
/// </summary>
[BindProperty(Description = "")]
public System.Guid FollowHumanId { get { return _FollowHumanId; } set { _FollowHumanId = value; }  }

private  System.String _FollowHuman;
/// <summary>
/// 跟进人员
/// </summary>
[BindProperty(Description = "跟进人员")]
public System.String FollowHuman { get { return _FollowHuman; } set { _FollowHuman = value; }  }

private  System.String _FollowDept;
/// <summary>
/// 跟进部门
/// </summary>
[BindProperty(Description = "跟进部门")]
public System.String FollowDept { get { return _FollowDept; } set { _FollowDept = value; }  }

private  System.Guid _FollowDeptId;
/// <summary>
/// 
/// </summary>
[BindProperty(Description = "")]
public System.Guid FollowDeptId { get { return _FollowDeptId; } set { _FollowDeptId = value; }  }

private  System.Guid _UpdHumId;
/// <summary>
/// 
/// </summary>
[BindProperty(Description = "")]
[BindPropertySession(PropertyAssignment = Power.Business.Attributes.EBusinessPropertyAssignment.UpdHumId,  SessionName = "UpdHumId",   IsNull = false, IsAllowNoExist = false)]
public System.Guid UpdHumId { get { return _UpdHumId; } set { _UpdHumId = value; }  }

private  System.String _UpdHuman;
/// <summary>
/// 
/// </summary>
[BindProperty(Description = "")]
public System.String UpdHuman { get { return _UpdHuman; } set { _UpdHuman = value; }  }

private  System.DateTime _UpdDate;
/// <summary>
/// 
/// </summary>
[BindProperty(Description = "")]
[BindPropertySession(PropertyAssignment = Power.Business.Attributes.EBusinessPropertyAssignment.UpdDate,  SessionName = "UpdDate",   IsNull = false, IsAllowNoExist = false)]
public System.DateTime UpdDate { get { return _UpdDate; } set { _UpdDate = value; }  }

private  System.DateTime _RegDate;
/// <summary>
/// 
/// </summary>
[BindProperty(Description = "")]
[BindPropertySession(PropertyAssignment = Power.Business.Attributes.EBusinessPropertyAssignment.RegDate,  SessionName = "RegDate",   IsNull = false, IsAllowNoExist = false)]
public System.DateTime RegDate { get { return _RegDate; } set { _RegDate = value; }  }

private  System.String _RegHumName;
/// <summary>
/// 
/// </summary>
[BindProperty(Description = "")]
[BindPropertySession(PropertyAssignment = Power.Business.Attributes.EBusinessPropertyAssignment.RegHumName,  SessionName = "RegHumName",   IsNull = false, IsAllowNoExist = false)]
public System.String RegHumName { get { return _RegHumName; } set { _RegHumName = value; }  }

private  System.Guid _RegHumId;
/// <summary>
/// 
/// </summary>
[BindProperty(Description = "")]
[BindPropertySession(PropertyAssignment = Power.Business.Attributes.EBusinessPropertyAssignment.RegHumId,  SessionName = "RegHumId",   IsNull = false, IsAllowNoExist = false)]
public System.Guid RegHumId { get { return _RegHumId; } set { _RegHumId = value; }  }

private  System.Guid _OwnProjId;
/// <summary>
/// 
/// </summary>
[BindProperty(Description = "")]
[BindPropertySession(PropertyAssignment = Power.Business.Attributes.EBusinessPropertyAssignment.OwnProjId,  SessionName = "OwnProjId",   IsNull = false, IsAllowNoExist = false)]
public System.Guid OwnProjId { get { return _OwnProjId; } set { _OwnProjId = value; }  }

private  System.Guid _EpsProjId;
/// <summary>
/// 
/// </summary>
[BindProperty(Description = "")]
[BindPropertySession(PropertyAssignment = Power.Business.Attributes.EBusinessPropertyAssignment.EpsProjId,  SessionName = "EpsProjId",   IsNull = false, IsAllowNoExist = false)]
public System.Guid EpsProjId { get { return _EpsProjId; } set { _EpsProjId = value; }  }

private  System.Guid _ApprHumId;
/// <summary>
/// 
/// </summary>
[BindProperty(Description = "")]
[BindPropertyUse(PropertyUse = Power.Business.Attributes.EBusinessPropertyUse.FlowFinishHumanID )]
public System.Guid ApprHumId { get { return _ApprHumId; } set { _ApprHumId = value; }  }

private  System.String _ApprHumName;
/// <summary>
/// 
/// </summary>
[BindProperty(Description = "")]
[BindPropertyUse(PropertyUse = Power.Business.Attributes.EBusinessPropertyUse.FlowFinishHumanName )]
public System.String ApprHumName { get { return _ApprHumName; } set { _ApprHumName = value; }  }

private  System.DateTime _ApprDate;
/// <summary>
/// 
/// </summary>
[BindProperty(Description = "")]
[BindPropertyUse(PropertyUse = Power.Business.Attributes.EBusinessPropertyUse.FlowFinishDate )]
public System.DateTime ApprDate { get { return _ApprDate; } set { _ApprDate = value; }  }

private  System.SByte _Status;
/// <summary>
/// 
/// </summary>
[BindProperty(Description = "")]
public System.SByte Status { get { return _Status; } set { _Status = value; }  }

private  System.String _OwnProjName;
/// <summary>
/// 
/// </summary>
[BindProperty(Description = "")]
[BindPropertySession(PropertyAssignment = Power.Business.Attributes.EBusinessPropertyAssignment.OwnProjName,  SessionName = "OwnProjName",   IsNull = false, IsAllowNoExist = false)]
public System.String OwnProjName { get { return _OwnProjName; } set { _OwnProjName = value; }  }

private  System.String _FollowStatus;
/// <summary>
/// 
/// </summary>
[BindProperty(Description = "")]
public System.String FollowStatus { get { return _FollowStatus; } set { _FollowStatus = value; }  }

private  System.Int32 _isPrequalification;
/// <summary>
/// 
/// </summary>
[BindProperty(Description = "")]
public System.Int32 isPrequalification { get { return _isPrequalification; } set { _isPrequalification = value; }  }

private  System.DateTime _PrequalificationDeadline;
/// <summary>
/// 
/// </summary>
[BindProperty(Description = "")]
public System.DateTime PrequalificationDeadline { get { return _PrequalificationDeadline; } set { _PrequalificationDeadline = value; }  }

private  System.String _FollowLevel;
/// <summary>
/// 
/// </summary>
[BindProperty(Description = "")]
public System.String FollowLevel { get { return _FollowLevel; } set { _FollowLevel = value; }  }

private  System.Int32 _isFollow;
/// <summary>
/// 
/// </summary>
[BindProperty(Description = "")]
public System.Int32 isFollow { get { return _isFollow; } set { _isFollow = value; }  }

private  System.SByte _Status2;
/// <summary>
/// 状态（跟踪用）
/// </summary>
[BindProperty(Description = "状态（跟踪用）")]
[BindPropertyUse(PropertyUse = Power.Business.Attributes.EBusinessPropertyUse.FlowStatus )]
public System.SByte Status2 { get { return _Status2; } set { _Status2 = value; }  }


      
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
			    if (name == "CLIENTNAME")
{
return _ClientName;
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
if (name == "STATUS")
{
return _Status;
}
if (name == "OWNPROJNAME")
{
return _OwnProjName;
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
if (name == "FOLLOWLEVEL")
{
return _FollowLevel;
}
if (name == "ISFOLLOW")
{
return _isFollow;
}
if (name == "STATUS2")
{
return _Status2;
}


				
			    return base[name];
			}
			set 
			{
			   name = name.ToUpper();
			       if (name == "CLIENTNAME")
{
 _ClientName = System.Convert.ToString(value);return;
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
if (name == "STATUS")
{
 _Status = System.Convert.ToSByte(value);return;
}
if (name == "OWNPROJNAME")
{
 _OwnProjName = System.Convert.ToString(value);return;
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
if (name == "FOLLOWLEVEL")
{
 _FollowLevel = System.Convert.ToString(value);return;
}
if (name == "ISFOLLOW")
{
 _isFollow = System.Convert.ToInt32(value);return;
}
if (name == "STATUS2")
{
 _Status2 = System.Convert.ToSByte(value);return;
}

			    base[name] = value;
			}
		}
		#endregion

		  #region 拦截事件

		  /// <summary>
/// 读取方法
/// </summary>
/// <param name="KeyValues"></param>
/// <param name="flag"></param>
/// <returns></returns>
protected override Hashtable ReadBusiness(Dictionary<string, string> KeyValues, SearchFlag flag)
{
Hashtable formData = base.ReadBusiness(KeyValues,flag);


 return formData;
}



		  /// <summary>
/// 保存方法
/// </summary>
/// <param name="formData"></param>
/// <param name="methodType"></param>
/// <returns></returns>
protected override int SaveBusiness(Hashtable formData, System.ComponentModel.DataObjectMethodType methodType)
{
int iResult = base.SaveBusiness(formData, methodType);

  return iResult;
}



		  /// <summary>
/// 删除方法
/// </summary>
/// <param name="KeyValues"></param>
/// <returns></returns>
protected override int DeleteBusiness(Dictionary<string, string> KeyValues)
{
int iResult = base.DeleteBusiness(KeyValues); 

  return iResult;
}



		  #endregion 
	} 
}

 namespace  Power.Systems.StdMarket.IStdMarket
{  
	/// <summary>
    /// 前期项目跟踪对象接口
    /// </summary>
    public partial interface IPS_ProjectInfo2BO :  Power.Business.IBaseBusiness
    {
	      #region 属性 

	     /// <summary>
/// 
/// </summary>
System.String ClientName { get ; set ;}

/// <summary>
/// 
/// </summary>
System.Guid Id { get ; set ;}

/// <summary>
/// 
/// </summary>
System.Guid SaleClue_Guid { get ; set ;}

/// <summary>
/// 项目编号
/// </summary>
System.String ProjectId { get ; set ;}

/// <summary>
/// 项目名称
/// </summary>
System.String ProjectName { get ; set ;}

/// <summary>
/// 项目简称
/// </summary>
System.String ProjectShortName { get ; set ;}

/// <summary>
/// 信息来源
/// </summary>
System.String InfoSources { get ; set ;}

/// <summary>
/// 项目类型
/// </summary>
System.String ProjectType { get ; set ;}

/// <summary>
/// 项目规模
/// </summary>
System.String ProjectSize { get ; set ;}

/// <summary>
/// 项目地点
/// </summary>
System.String ProjectLocation { get ; set ;}

/// <summary>
/// 项目区域
/// </summary>
System.String ProjectArea { get ; set ;}

/// <summary>
/// 产品类型
/// </summary>
System.String ProductType { get ; set ;}

/// <summary>
/// 资金来源
/// </summary>
System.String SourcesOfFunds { get ; set ;}

/// <summary>
/// 投资规模
/// </summary>
System.Double ProjectInvestAmount { get ; set ;}

/// <summary>
/// 招标形式
/// </summary>
System.String TenderType { get ; set ;}

/// <summary>
/// 合同形式
/// </summary>
System.String ContractType { get ; set ;}

/// <summary>
/// 预计合同额
/// </summary>
System.Double ForcastContractAmount { get ; set ;}

/// <summary>
/// 币种
/// </summary>
System.String CurrencyType { get ; set ;}

/// <summary>
/// 
/// </summary>
System.Guid Client_Guid { get ; set ;}

/// <summary>
/// 
/// </summary>
System.Guid FollowHumanId { get ; set ;}

/// <summary>
/// 跟进人员
/// </summary>
System.String FollowHuman { get ; set ;}

/// <summary>
/// 跟进部门
/// </summary>
System.String FollowDept { get ; set ;}

/// <summary>
/// 
/// </summary>
System.Guid FollowDeptId { get ; set ;}

/// <summary>
/// 
/// </summary>
System.Guid UpdHumId { get ; set ;}

/// <summary>
/// 
/// </summary>
System.String UpdHuman { get ; set ;}

/// <summary>
/// 
/// </summary>
System.DateTime UpdDate { get ; set ;}

/// <summary>
/// 
/// </summary>
System.DateTime RegDate { get ; set ;}

/// <summary>
/// 
/// </summary>
System.String RegHumName { get ; set ;}

/// <summary>
/// 
/// </summary>
System.Guid RegHumId { get ; set ;}

/// <summary>
/// 
/// </summary>
System.Guid OwnProjId { get ; set ;}

/// <summary>
/// 
/// </summary>
System.Guid EpsProjId { get ; set ;}

/// <summary>
/// 
/// </summary>
System.Guid ApprHumId { get ; set ;}

/// <summary>
/// 
/// </summary>
System.String ApprHumName { get ; set ;}

/// <summary>
/// 
/// </summary>
System.DateTime ApprDate { get ; set ;}

/// <summary>
/// 
/// </summary>
System.SByte Status { get ; set ;}

/// <summary>
/// 
/// </summary>
System.String OwnProjName { get ; set ;}

/// <summary>
/// 
/// </summary>
System.String FollowStatus { get ; set ;}

/// <summary>
/// 
/// </summary>
System.Int32 isPrequalification { get ; set ;}

/// <summary>
/// 
/// </summary>
System.DateTime PrequalificationDeadline { get ; set ;}

/// <summary>
/// 
/// </summary>
System.String FollowLevel { get ; set ;}

/// <summary>
/// 
/// </summary>
System.Int32 isFollow { get ; set ;}

/// <summary>
/// 状态（跟踪用）
/// </summary>
System.SByte Status2 { get ; set ;}


      
		#endregion 
	}
}