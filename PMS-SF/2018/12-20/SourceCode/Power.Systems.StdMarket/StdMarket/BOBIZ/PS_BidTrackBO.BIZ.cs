 
 

 using System;
 using System.Collections;
 using System.Collections.Generic;
 using System.Text; 
 using Power.Business.Attributes;
 using Power.Business;

 namespace  Power.Systems.StdMarket.StdMarket
{  
    /// <summary>
    /// 投标信息跟踪
    /// </summary>
    [BindBusinessObject(KeyWord="PS_BidTrack",EntityType = typeof(Power.Systems.StdMarket.StdMarket.PS_BidTrackDO),BusinessType=Power.Business.Attributes.EBusinessType.Main ,Description = "投标信息跟踪" ,DefaultBindWorkFlow = true)] 
    public partial  class PS_BidTrackBO : PS_BidTrackBO<PS_BidTrackBO,Power.Systems.StdMarket.StdMarket.PS_BidTrack_DtlBO >
    {

    }

	/// <summary>
    /// 投标信息跟踪
    /// </summary>  
	public    partial class PS_BidTrackBO<TBusiness,TPS_BidTrack_DtlBO> : Power.Business.BaseBusiness<TBusiness>, Power.Systems.StdMarket.IStdMarket.IPS_BidTrackBO 
        where TBusiness : Power.Systems.StdMarket.IStdMarket.IPS_BidTrackBO, new()
		where TPS_BidTrack_DtlBO : Power.Systems.StdMarket.IStdMarket.IPS_BidTrack_DtlBO,new()

    { 

	    #region 下辖业务对象
         private BusinessList<TPS_BidTrack_DtlBO> _BidTrack_Dtl;
/// <summary>
/// 参与投标单位
/// </summary>
[BindBusinessAttach(KeyWord="PS_BidTrack_Dtl", ParentKeyName = new string[] { "Id" }, MyKeyName = new string[] { "ParentId" }, Description = "参与投标单位")]
 public virtual BusinessList<TPS_BidTrack_DtlBO> BidTrack_Dtl { get { if (_BidTrack_Dtl == null) _BidTrack_Dtl = new BusinessList<TPS_BidTrack_DtlBO>(); return _BidTrack_Dtl; } set { _BidTrack_Dtl = value; } }

   
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
/// 主键
/// </summary>
[BindProperty(Description = "主键")]
[BindPropertyUse(PropertyUse = Power.Business.Attributes.EBusinessPropertyUse.PrimaryKey )]
public System.Guid Id { get { return _Id; } set { _Id = value; }  }

private  System.String _ProjectName;
/// <summary>
/// 
/// </summary>
[BindProperty(PropertySource = Power.Business.Attributes.EnumPropertySource.Business,Description = "")]
[BindPropertyUse(PropertyUse = Power.Business.Attributes.EBusinessPropertyUse.ForeignLinkValue,SourcePropertyName = "ProjectInfo_Guid",ForeignName = "ProjectName" )]
public System.String ProjectName { get { return _ProjectName; } set { _ProjectName = value; }  }

private  System.Guid _ProjectInfo_Guid;
/// <summary>
/// 跟踪项目外键
/// </summary>
[BindProperty(Description = "跟踪项目外键")]
[BindPropertyUse(PropertyUse = Power.Business.Attributes.EBusinessPropertyUse.ForeignKey, KeyWord = "PS_ProjectInfo",DataSource =  EDataSourceType.Entity,ForeignName = "Id",IsNull = true )]
public System.Guid ProjectInfo_Guid { get { return _ProjectInfo_Guid; } set { _ProjectInfo_Guid = value; }  }

private  System.Guid _Client_Guid;
/// <summary>
/// 客户外键
/// </summary>
[BindProperty(Description = "客户外键")]
[BindPropertyUse(PropertyUse = Power.Business.Attributes.EBusinessPropertyUse.ForeignKey, KeyWord = "Organize",DataSource =  EDataSourceType.Entity,ForeignName = "Id",IsNull = true )]
public System.Guid Client_Guid { get { return _Client_Guid; } set { _Client_Guid = value; }  }

private  System.Guid _BidTask_Guid;
/// <summary>
/// 投标任务书外键
/// </summary>
[BindProperty(Description = "投标任务书外键")]
public System.Guid BidTask_Guid { get { return _BidTask_Guid; } set { _BidTask_Guid = value; }  }

private  System.String _BidResult;
/// <summary>
/// 开标结果
/// </summary>
[BindProperty(Description = "开标结果")]
[BindPropertyUse(PropertyUse = Power.Business.Attributes.EBusinessPropertyUse.TitleField )]
public System.String BidResult { get { return _BidResult; } set { _BidResult = value; }  }

private  System.Double _BidAmount;
/// <summary>
/// 投标金额
/// </summary>
[BindProperty(Description = "投标金额")]
public System.Double BidAmount { get { return _BidAmount; } set { _BidAmount = value; }  }

private  System.DateTime _BidDate;
/// <summary>
/// 开标日期
/// </summary>
[BindProperty(Description = "开标日期")]
public System.DateTime BidDate { get { return _BidDate; } set { _BidDate = value; }  }

private  System.DateTime _WinBidDate;
/// <summary>
/// 中标日期
/// </summary>
[BindProperty(Description = "中标日期")]
public System.DateTime WinBidDate { get { return _WinBidDate; } set { _WinBidDate = value; }  }

private  System.DateTime _ContractSignDate;
/// <summary>
/// 预计合同签订日期
/// </summary>
[BindProperty(Description = "预计合同签订日期")]
public System.DateTime ContractSignDate { get { return _ContractSignDate; } set { _ContractSignDate = value; }  }

private  System.String _WinCompany;
/// <summary>
/// 中标单位
/// </summary>
[BindProperty(Description = "中标单位")]
public System.String WinCompany { get { return _WinCompany; } set { _WinCompany = value; }  }

private  System.String _LoseReason;
/// <summary>
/// 丢标原因
/// </summary>
[BindProperty(Description = "丢标原因")]
public System.String LoseReason { get { return _LoseReason; } set { _LoseReason = value; }  }

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
			    if (name == "CLIENTNAME")
{
return _ClientName;
}
if (name == "ID")
{
return _Id;
}
if (name == "PROJECTNAME")
{
return _ProjectName;
}
if (name == "PROJECTINFO_GUID")
{
return _ProjectInfo_Guid;
}
if (name == "CLIENT_GUID")
{
return _Client_Guid;
}
if (name == "BIDTASK_GUID")
{
return _BidTask_Guid;
}
if (name == "BIDRESULT")
{
return _BidResult;
}
if (name == "BIDAMOUNT")
{
return _BidAmount;
}
if (name == "BIDDATE")
{
return _BidDate;
}
if (name == "WINBIDDATE")
{
return _WinBidDate;
}
if (name == "CONTRACTSIGNDATE")
{
return _ContractSignDate;
}
if (name == "WINCOMPANY")
{
return _WinCompany;
}
if (name == "LOSEREASON")
{
return _LoseReason;
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


				if (name == "BIDTRACK_DTL")
{
return  this.BidTrack_Dtl;
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
if (name == "PROJECTNAME")
{
 _ProjectName = System.Convert.ToString(value);return;
}
if (name == "PROJECTINFO_GUID")
{
 _ProjectInfo_Guid = XCode.Common.Helper.ConvertToGuid(value);return;
}
if (name == "CLIENT_GUID")
{
 _Client_Guid = XCode.Common.Helper.ConvertToGuid(value);return;
}
if (name == "BIDTASK_GUID")
{
 _BidTask_Guid = XCode.Common.Helper.ConvertToGuid(value);return;
}
if (name == "BIDRESULT")
{
 _BidResult = System.Convert.ToString(value);return;
}
if (name == "BIDAMOUNT")
{
 _BidAmount = System.Convert.ToDouble(value);return;
}
if (name == "BIDDATE")
{
 if (value == null || value.ToString().IsNullOrEmpty() == true) value = DateTime.MinValue;
 _BidDate = System.Convert.ToDateTime(value);return;
}
if (name == "WINBIDDATE")
{
 if (value == null || value.ToString().IsNullOrEmpty() == true) value = DateTime.MinValue;
 _WinBidDate = System.Convert.ToDateTime(value);return;
}
if (name == "CONTRACTSIGNDATE")
{
 if (value == null || value.ToString().IsNullOrEmpty() == true) value = DateTime.MinValue;
 _ContractSignDate = System.Convert.ToDateTime(value);return;
}
if (name == "WINCOMPANY")
{
 _WinCompany = System.Convert.ToString(value);return;
}
if (name == "LOSEREASON")
{
 _LoseReason = System.Convert.ToString(value);return;
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
Dictionary<string, string> ParentKeyValues = null;
ParentKeyValues = GetParentKey(Meta.AttachBusinessList["BidTrack_Dtl"]);
formData.Add("BidTrack_Dtl", this.ReadOtherBusiness(ParentKeyValues, BidTrack_Dtl, Meta.AttachBusinessList["BidTrack_Dtl"]));


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
this.SaveOtherBusiness(formData, BidTrack_Dtl, Meta.AttachBusinessList["BidTrack_Dtl"]);

  return iResult;
}



		  /// <summary>
/// 删除方法
/// </summary>
/// <param name="KeyValues"></param>
/// <returns></returns>
protected override int DeleteBusiness(Dictionary<string, string> KeyValues)
{
this.DeleteOtherBusiness<TPS_BidTrack_DtlBO>(KeyValues, Meta.AttachBusinessList["BidTrack_Dtl"]);
int iResult = base.DeleteBusiness(KeyValues); 

  return iResult;
}



		  #endregion 
	} 
}

 namespace  Power.Systems.StdMarket.IStdMarket
{  
	/// <summary>
    /// 投标信息跟踪对象接口
    /// </summary>
    public partial interface IPS_BidTrackBO :  Power.Business.IBaseBusiness
    {
	      #region 属性 

	     /// <summary>
/// 
/// </summary>
System.String ClientName { get ; set ;}

/// <summary>
/// 主键
/// </summary>
System.Guid Id { get ; set ;}

/// <summary>
/// 
/// </summary>
System.String ProjectName { get ; set ;}

/// <summary>
/// 跟踪项目外键
/// </summary>
System.Guid ProjectInfo_Guid { get ; set ;}

/// <summary>
/// 客户外键
/// </summary>
System.Guid Client_Guid { get ; set ;}

/// <summary>
/// 投标任务书外键
/// </summary>
System.Guid BidTask_Guid { get ; set ;}

/// <summary>
/// 开标结果
/// </summary>
System.String BidResult { get ; set ;}

/// <summary>
/// 投标金额
/// </summary>
System.Double BidAmount { get ; set ;}

/// <summary>
/// 开标日期
/// </summary>
System.DateTime BidDate { get ; set ;}

/// <summary>
/// 中标日期
/// </summary>
System.DateTime WinBidDate { get ; set ;}

/// <summary>
/// 预计合同签订日期
/// </summary>
System.DateTime ContractSignDate { get ; set ;}

/// <summary>
/// 中标单位
/// </summary>
System.String WinCompany { get ; set ;}

/// <summary>
/// 丢标原因
/// </summary>
System.String LoseReason { get ; set ;}

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