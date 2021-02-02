 
 

 using System;
 using System.Collections;
 using System.Collections.Generic;
 using System.Text; 
 using Power.Business.Attributes;
 using Power.Business;

 namespace  Power.Systems.StdMarket.StdMarket
{  
    /// <summary>
    /// 项目交接单
    /// </summary>
    [BindBusinessObject(KeyWord="PS_ProjectHandover",EntityType = typeof(Power.Systems.StdMarket.StdMarket.PS_ProjectHandoverDO),BusinessType=Power.Business.Attributes.EBusinessType.Main ,Description = "项目交接单" ,DefaultBindWorkFlow = true)] 
    public partial  class PS_ProjectHandoverBO : PS_ProjectHandoverBO<PS_ProjectHandoverBO >
    {

    }

	/// <summary>
    /// 项目交接单
    /// </summary>  
	public    partial class PS_ProjectHandoverBO<TBusiness> : Power.Business.BaseBusiness<TBusiness>, Power.Systems.StdMarket.IStdMarket.IPS_ProjectHandoverBO 
        where TBusiness : Power.Systems.StdMarket.IStdMarket.IPS_ProjectHandoverBO, new()
		
    { 

	    #region 下辖业务对象
           
		#endregion 

	    #region 属性 

	 private  System.String _HandOverType;
/// <summary>
/// 通知单类型：设计、EPC、施工、其他
/// </summary>
[BindProperty(Description = "通知单类型：设计、EPC、施工、其他")]
public System.String HandOverType { get { return _HandOverType; } set { _HandOverType = value; }  }

private  System.String _DesignManager;
/// <summary>
/// 设计经理
/// </summary>
[BindProperty(Description = "设计经理")]
public System.String DesignManager { get { return _DesignManager; } set { _DesignManager = value; }  }

private  System.Guid _DesignManagerId;
/// <summary>
/// 设计经理Id
/// </summary>
[BindProperty(Description = "设计经理Id")]
public System.Guid DesignManagerId { get { return _DesignManagerId; } set { _DesignManagerId = value; }  }

private  System.String _ProjectCode;
/// <summary>
/// 项目编号
/// </summary>
[BindProperty(Description = "项目编号")]
[BindPropertyUse(PropertyUse = Power.Business.Attributes.EBusinessPropertyUse.CodeField )]
public System.String ProjectCode { get { return _ProjectCode; } set { _ProjectCode = value; }  }

private  System.Guid _ProjectEps_Guid;
/// <summary>
/// 项目所属epsid
/// </summary>
[BindProperty(Description = "项目所属epsid")]
public System.Guid ProjectEps_Guid { get { return _ProjectEps_Guid; } set { _ProjectEps_Guid = value; }  }

private  System.String _ProjectInfo;
/// <summary>
/// 前期项目
/// </summary>
[BindProperty(Description = "前期项目")]
public System.String ProjectInfo { get { return _ProjectInfo; } set { _ProjectInfo = value; }  }

private  System.Guid _ProjectInfo_Guid;
/// <summary>
/// 前期项目Id
/// </summary>
[BindProperty(Description = "前期项目Id")]
public System.Guid ProjectInfo_Guid { get { return _ProjectInfo_Guid; } set { _ProjectInfo_Guid = value; }  }

private  System.String _ProjectOverview;
/// <summary>
/// 项目概况
/// </summary>
[BindProperty(Description = "项目概况")]
public System.String ProjectOverview { get { return _ProjectOverview; } set { _ProjectOverview = value; }  }

private  System.String _ProjectPhase;
/// <summary>
/// 设计阶段
/// </summary>
[BindProperty(Description = "设计阶段")]
public System.String ProjectPhase { get { return _ProjectPhase; } set { _ProjectPhase = value; }  }

private  System.String _ProjectShortName;
/// <summary>
/// 
/// </summary>
[BindProperty(Description = "")]
public System.String ProjectShortName { get { return _ProjectShortName; } set { _ProjectShortName = value; }  }

private  System.Double _SubmitFileNum;
/// <summary>
/// 设计成品份数
/// </summary>
[BindProperty(Description = "设计成品份数")]
public System.Double SubmitFileNum { get { return _SubmitFileNum; } set { _SubmitFileNum = value; }  }

private  System.String _ProjectName;
/// <summary>
/// 
/// </summary>
[BindProperty(Description = "")]
[BindPropertyUse(PropertyUse = Power.Business.Attributes.EBusinessPropertyUse.TitleField )]
public System.String ProjectName { get { return _ProjectName; } set { _ProjectName = value; }  }

private  System.Guid _Id;
/// <summary>
/// 
/// </summary>
[BindProperty(Description = "")]
[BindPropertyUse(PropertyUse = Power.Business.Attributes.EBusinessPropertyUse.PrimaryKey )]
public System.Guid Id { get { return _Id; } set { _Id = value; }  }

private  System.String _Memo;
/// <summary>
/// 
/// </summary>
[BindProperty(Description = "")]
public System.String Memo { get { return _Memo; } set { _Memo = value; }  }

private  System.Guid _ContractReview_Guid;
/// <summary>
/// 
/// </summary>
[BindProperty(Description = "")]
public System.Guid ContractReview_Guid { get { return _ContractReview_Guid; } set { _ContractReview_Guid = value; }  }

private  System.Guid _ConotractInfo_Guid;
/// <summary>
/// 
/// </summary>
[BindProperty(Description = "")]
public System.Guid ConotractInfo_Guid { get { return _ConotractInfo_Guid; } set { _ConotractInfo_Guid = value; }  }

private  System.String _StartupAccording;
/// <summary>
/// 
/// </summary>
[BindProperty(Description = "")]
public System.String StartupAccording { get { return _StartupAccording; } set { _StartupAccording = value; }  }

private  System.Guid _Client_Guid;
/// <summary>
/// 
/// </summary>
[BindProperty(Description = "")]
public System.Guid Client_Guid { get { return _Client_Guid; } set { _Client_Guid = value; }  }

private  System.String _ClientName;
/// <summary>
/// 
/// </summary>
[BindProperty(Description = "")]
public System.String ClientName { get { return _ClientName; } set { _ClientName = value; }  }

private  System.String _ContractName;
/// <summary>
/// 
/// </summary>
[BindProperty(Description = "")]
public System.String ContractName { get { return _ContractName; } set { _ContractName = value; }  }

private  System.Double _ContractAmount;
/// <summary>
/// 
/// </summary>
[BindProperty(Description = "")]
public System.Double ContractAmount { get { return _ContractAmount; } set { _ContractAmount = value; }  }

private  System.String _ProductType;
/// <summary>
/// 
/// </summary>
[BindProperty(Description = "")]
public System.String ProductType { get { return _ProductType; } set { _ProductType = value; }  }

private  System.String _ProjectType;
/// <summary>
/// 
/// </summary>
[BindProperty(Description = "")]
public System.String ProjectType { get { return _ProjectType; } set { _ProjectType = value; }  }

private  System.String _ProjectEps;
/// <summary>
/// 
/// </summary>
[BindProperty(Description = "")]
public System.String ProjectEps { get { return _ProjectEps; } set { _ProjectEps = value; }  }

private  System.String _ProjectManager;
/// <summary>
/// 
/// </summary>
[BindProperty(Description = "")]
public System.String ProjectManager { get { return _ProjectManager; } set { _ProjectManager = value; }  }

private  System.Guid _ProjectManagerId;
/// <summary>
/// 
/// </summary>
[BindProperty(Description = "")]
public System.Guid ProjectManagerId { get { return _ProjectManagerId; } set { _ProjectManagerId = value; }  }

private  System.String _ProjectLocation;
/// <summary>
/// 
/// </summary>
[BindProperty(Description = "")]
public System.String ProjectLocation { get { return _ProjectLocation; } set { _ProjectLocation = value; }  }

private  System.DateTime _ProjectStartDate;
/// <summary>
/// 
/// </summary>
[BindProperty(Description = "")]
public System.DateTime ProjectStartDate { get { return _ProjectStartDate; } set { _ProjectStartDate = value; }  }

private  System.DateTime _ProjectEndDate;
/// <summary>
/// 
/// </summary>
[BindProperty(Description = "")]
public System.DateTime ProjectEndDate { get { return _ProjectEndDate; } set { _ProjectEndDate = value; }  }

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

private  System.String _OwnProjName;
/// <summary>
/// 
/// </summary>
[BindProperty(Description = "")]
[BindPropertySession(PropertyAssignment = Power.Business.Attributes.EBusinessPropertyAssignment.OwnProjName,  SessionName = "OwnProjName",   IsNull = false, IsAllowNoExist = false)]
public System.String OwnProjName { get { return _OwnProjName; } set { _OwnProjName = value; }  }

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
[BindPropertyUse(PropertyUse = Power.Business.Attributes.EBusinessPropertyUse.FlowStatus )]
public System.SByte Status { get { return _Status; } set { _Status = value; }  }


      
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
if (name == "PROJECTCODE")
{
return _ProjectCode;
}
if (name == "PROJECTEPS_GUID")
{
return _ProjectEps_Guid;
}
if (name == "PROJECTINFO")
{
return _ProjectInfo;
}
if (name == "PROJECTINFO_GUID")
{
return _ProjectInfo_Guid;
}
if (name == "PROJECTOVERVIEW")
{
return _ProjectOverview;
}
if (name == "PROJECTPHASE")
{
return _ProjectPhase;
}
if (name == "PROJECTSHORTNAME")
{
return _ProjectShortName;
}
if (name == "SUBMITFILENUM")
{
return _SubmitFileNum;
}
if (name == "PROJECTNAME")
{
return _ProjectName;
}
if (name == "ID")
{
return _Id;
}
if (name == "MEMO")
{
return _Memo;
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


				
			    return base[name];
			}
			set 
			{
			   name = name.ToUpper();
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
if (name == "PROJECTCODE")
{
 _ProjectCode = System.Convert.ToString(value);return;
}
if (name == "PROJECTEPS_GUID")
{
 _ProjectEps_Guid = XCode.Common.Helper.ConvertToGuid(value);return;
}
if (name == "PROJECTINFO")
{
 _ProjectInfo = System.Convert.ToString(value);return;
}
if (name == "PROJECTINFO_GUID")
{
 _ProjectInfo_Guid = XCode.Common.Helper.ConvertToGuid(value);return;
}
if (name == "PROJECTOVERVIEW")
{
 _ProjectOverview = System.Convert.ToString(value);return;
}
if (name == "PROJECTPHASE")
{
 _ProjectPhase = System.Convert.ToString(value);return;
}
if (name == "PROJECTSHORTNAME")
{
 _ProjectShortName = System.Convert.ToString(value);return;
}
if (name == "SUBMITFILENUM")
{
 _SubmitFileNum = System.Convert.ToDouble(value);return;
}
if (name == "PROJECTNAME")
{
 _ProjectName = System.Convert.ToString(value);return;
}
if (name == "ID")
{
 _Id = XCode.Common.Helper.ConvertToGuid(value);return;
}
if (name == "MEMO")
{
 _Memo = System.Convert.ToString(value);return;
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
    /// 项目交接单对象接口
    /// </summary>
    public partial interface IPS_ProjectHandoverBO :  Power.Business.IBaseBusiness
    {
	      #region 属性 

	     /// <summary>
/// 通知单类型：设计、EPC、施工、其他
/// </summary>
System.String HandOverType { get ; set ;}

/// <summary>
/// 设计经理
/// </summary>
System.String DesignManager { get ; set ;}

/// <summary>
/// 设计经理Id
/// </summary>
System.Guid DesignManagerId { get ; set ;}

/// <summary>
/// 项目编号
/// </summary>
System.String ProjectCode { get ; set ;}

/// <summary>
/// 项目所属epsid
/// </summary>
System.Guid ProjectEps_Guid { get ; set ;}

/// <summary>
/// 前期项目
/// </summary>
System.String ProjectInfo { get ; set ;}

/// <summary>
/// 前期项目Id
/// </summary>
System.Guid ProjectInfo_Guid { get ; set ;}

/// <summary>
/// 项目概况
/// </summary>
System.String ProjectOverview { get ; set ;}

/// <summary>
/// 设计阶段
/// </summary>
System.String ProjectPhase { get ; set ;}

/// <summary>
/// 
/// </summary>
System.String ProjectShortName { get ; set ;}

/// <summary>
/// 设计成品份数
/// </summary>
System.Double SubmitFileNum { get ; set ;}

/// <summary>
/// 
/// </summary>
System.String ProjectName { get ; set ;}

/// <summary>
/// 
/// </summary>
System.Guid Id { get ; set ;}

/// <summary>
/// 
/// </summary>
System.String Memo { get ; set ;}

/// <summary>
/// 
/// </summary>
System.Guid ContractReview_Guid { get ; set ;}

/// <summary>
/// 
/// </summary>
System.Guid ConotractInfo_Guid { get ; set ;}

/// <summary>
/// 
/// </summary>
System.String StartupAccording { get ; set ;}

/// <summary>
/// 
/// </summary>
System.Guid Client_Guid { get ; set ;}

/// <summary>
/// 
/// </summary>
System.String ClientName { get ; set ;}

/// <summary>
/// 
/// </summary>
System.String ContractName { get ; set ;}

/// <summary>
/// 
/// </summary>
System.Double ContractAmount { get ; set ;}

/// <summary>
/// 
/// </summary>
System.String ProductType { get ; set ;}

/// <summary>
/// 
/// </summary>
System.String ProjectType { get ; set ;}

/// <summary>
/// 
/// </summary>
System.String ProjectEps { get ; set ;}

/// <summary>
/// 
/// </summary>
System.String ProjectManager { get ; set ;}

/// <summary>
/// 
/// </summary>
System.Guid ProjectManagerId { get ; set ;}

/// <summary>
/// 
/// </summary>
System.String ProjectLocation { get ; set ;}

/// <summary>
/// 
/// </summary>
System.DateTime ProjectStartDate { get ; set ;}

/// <summary>
/// 
/// </summary>
System.DateTime ProjectEndDate { get ; set ;}

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
System.String OwnProjName { get ; set ;}

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


      
		#endregion 
	}
}