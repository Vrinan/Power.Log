 
 

 using System;
 using System.Collections;
 using System.Collections.Generic;
 using System.Text; 
 using Power.Business.Attributes;
 using Power.Business;

 namespace  Power.Systems.StdMarket.StdMarket
{  
    /// <summary>
    /// 报价计划
    /// </summary>
    [BindBusinessObject(KeyWord="PS_BidPlan",EntityType = typeof(Power.Systems.StdMarket.StdMarket.PS_BidPlanDO),BusinessType=Power.Business.Attributes.EBusinessType.Main ,Description = "报价计划" ,DefaultBindWorkFlow = true)] 
    public partial  class PS_BidPlanBO : PS_BidPlanBO<PS_BidPlanBO,Power.Systems.StdMarket.StdMarket.PS_BidPlan_QuoteHumanBO >
    {

    }

	/// <summary>
    /// 报价计划
    /// </summary>  
	public    partial class PS_BidPlanBO<TBusiness,TPS_BidPlan_QuoteHumanBO> : Power.Business.BaseBusiness<TBusiness>, Power.Systems.StdMarket.IStdMarket.IPS_BidPlanBO 
        where TBusiness : Power.Systems.StdMarket.IStdMarket.IPS_BidPlanBO, new()
		where TPS_BidPlan_QuoteHumanBO : Power.Systems.StdMarket.IStdMarket.IPS_BidPlan_QuoteHumanBO,new()

    { 

	    #region 下辖业务对象
         private BusinessList<TPS_BidPlan_QuoteHumanBO> _BidPlan_QuoteHuman;
/// <summary>
/// 参与报价人员
/// </summary>
[BindBusinessAttach(KeyWord="PS_BidPlan_QuoteHuman", ParentKeyName = new string[] { "Id" }, MyKeyName = new string[] { "MasterId" }, Description = "参与报价人员")]
 public virtual BusinessList<TPS_BidPlan_QuoteHumanBO> BidPlan_QuoteHuman { get { if (_BidPlan_QuoteHuman == null) _BidPlan_QuoteHuman = new BusinessList<TPS_BidPlan_QuoteHumanBO>(); return _BidPlan_QuoteHuman; } set { _BidPlan_QuoteHuman = value; } }

   
		#endregion 

	    #region 属性 

	 private  System.Guid _Id;
/// <summary>
/// 
/// </summary>
[BindProperty(Description = "")]
[BindPropertyUse(PropertyUse = Power.Business.Attributes.EBusinessPropertyUse.PrimaryKey )]
public System.Guid Id { get { return _Id; } set { _Id = value; }  }

private  System.String _Code;
/// <summary>
/// 编号
/// </summary>
[BindProperty(Description = "编号")]
[BindPropertyUse(PropertyUse = Power.Business.Attributes.EBusinessPropertyUse.CodeField )]
public System.String Code { get { return _Code; } set { _Code = value; }  }

private  System.Guid _ProjectInfo_Guid;
/// <summary>
/// 项目信息外键
/// </summary>
[BindProperty(Description = "项目信息外键")]
public System.Guid ProjectInfo_Guid { get { return _ProjectInfo_Guid; } set { _ProjectInfo_Guid = value; }  }

private  System.String _ProjectName;
/// <summary>
/// 项目名称
/// </summary>
[BindProperty(Description = "项目名称")]
[BindPropertyUse(PropertyUse = Power.Business.Attributes.EBusinessPropertyUse.TitleField )]
public System.String ProjectName { get { return _ProjectName; } set { _ProjectName = value; }  }

private  System.String _ProjectSize;
/// <summary>
/// 项目规模
/// </summary>
[BindProperty(Description = "项目规模")]
public System.String ProjectSize { get { return _ProjectSize; } set { _ProjectSize = value; }  }

private  System.String _ClientName;
/// <summary>
/// 客户名称
/// </summary>
[BindProperty(Description = "客户名称")]
public System.String ClientName { get { return _ClientName; } set { _ClientName = value; }  }

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
			    if (name == "ID")
{
return _Id;
}
if (name == "CODE")
{
return _Code;
}
if (name == "PROJECTINFO_GUID")
{
return _ProjectInfo_Guid;
}
if (name == "PROJECTNAME")
{
return _ProjectName;
}
if (name == "PROJECTSIZE")
{
return _ProjectSize;
}
if (name == "CLIENTNAME")
{
return _ClientName;
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


				if (name == "BIDPLAN_QUOTEHUMAN")
{
return  this.BidPlan_QuoteHuman;
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
if (name == "CODE")
{
 _Code = System.Convert.ToString(value);return;
}
if (name == "PROJECTINFO_GUID")
{
 _ProjectInfo_Guid = XCode.Common.Helper.ConvertToGuid(value);return;
}
if (name == "PROJECTNAME")
{
 _ProjectName = System.Convert.ToString(value);return;
}
if (name == "PROJECTSIZE")
{
 _ProjectSize = System.Convert.ToString(value);return;
}
if (name == "CLIENTNAME")
{
 _ClientName = System.Convert.ToString(value);return;
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
ParentKeyValues = GetParentKey(Meta.AttachBusinessList["BidPlan_QuoteHuman"]);
formData.Add("BidPlan_QuoteHuman", this.ReadOtherBusiness(ParentKeyValues, BidPlan_QuoteHuman, Meta.AttachBusinessList["BidPlan_QuoteHuman"]));


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
this.SaveOtherBusiness(formData, BidPlan_QuoteHuman, Meta.AttachBusinessList["BidPlan_QuoteHuman"]);

  return iResult;
}



		  /// <summary>
/// 删除方法
/// </summary>
/// <param name="KeyValues"></param>
/// <returns></returns>
protected override int DeleteBusiness(Dictionary<string, string> KeyValues)
{
this.DeleteOtherBusiness<TPS_BidPlan_QuoteHumanBO>(KeyValues, Meta.AttachBusinessList["BidPlan_QuoteHuman"]);
int iResult = base.DeleteBusiness(KeyValues); 

  return iResult;
}



		  #endregion 
	} 
}

 namespace  Power.Systems.StdMarket.IStdMarket
{  
	/// <summary>
    /// 报价计划对象接口
    /// </summary>
    public partial interface IPS_BidPlanBO :  Power.Business.IBaseBusiness
    {
	      #region 属性 

	     /// <summary>
/// 
/// </summary>
System.Guid Id { get ; set ;}

/// <summary>
/// 编号
/// </summary>
System.String Code { get ; set ;}

/// <summary>
/// 项目信息外键
/// </summary>
System.Guid ProjectInfo_Guid { get ; set ;}

/// <summary>
/// 项目名称
/// </summary>
System.String ProjectName { get ; set ;}

/// <summary>
/// 项目规模
/// </summary>
System.String ProjectSize { get ; set ;}

/// <summary>
/// 客户名称
/// </summary>
System.String ClientName { get ; set ;}

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