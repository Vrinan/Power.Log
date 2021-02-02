﻿ 
 

 using System;
 using System.Collections;
 using System.Collections.Generic;
 using System.Text; 
 using Power.Business.Attributes;
 using Power.Business;

 namespace  Power.Systems.StdMarket.StdMarket
{  
    /// <summary>
    /// 投标任务书
    /// </summary>
    [BindBusinessObject(KeyWord="PS_BidTask",EntityType = typeof(Power.Systems.StdMarket.StdMarket.PS_BidTaskDO),BusinessType=Power.Business.Attributes.EBusinessType.Main ,Description = "投标任务书" ,DefaultBindWorkFlow = true)] 
    public partial  class PS_BidTaskBO : PS_BidTaskBO<PS_BidTaskBO,Power.Systems.StdMarket.StdMarket.PS_BidTask_DtlBO >
    {

    }

	/// <summary>
    /// 投标任务书
    /// </summary>  
	public    partial class PS_BidTaskBO<TBusiness,TPS_BidTask_DtlBO> : Power.Business.BaseBusiness<TBusiness>, Power.Systems.StdMarket.IStdMarket.IPS_BidTaskBO 
        where TBusiness : Power.Systems.StdMarket.IStdMarket.IPS_BidTaskBO, new()
		where TPS_BidTask_DtlBO : Power.Systems.StdMarket.IStdMarket.IPS_BidTask_DtlBO,new()

    { 

	    #region 下辖业务对象
         private BusinessList<TPS_BidTask_DtlBO> _BidTask_Dtl;
/// <summary>
/// 投标任务分配
/// </summary>
[BindBusinessAttach(KeyWord="PS_BidTask_Dtl", ParentKeyName = new string[] { "Id" }, MyKeyName = new string[] { "ParentId" }, Description = "投标任务分配")]
 public virtual BusinessList<TPS_BidTask_DtlBO> BidTask_Dtl { get { if (_BidTask_Dtl == null) _BidTask_Dtl = new BusinessList<TPS_BidTask_DtlBO>(); return _BidTask_Dtl; } set { _BidTask_Dtl = value; } }

   
		#endregion 

	    #region 属性 

	 private  System.String _Title;
/// <summary>
/// 
/// </summary>
[BindProperty(Description = "")]
[BindPropertyUse(PropertyUse = Power.Business.Attributes.EBusinessPropertyUse.TitleField )]
public System.String Title { get { return _Title; } set { _Title = value; }  }

private  System.String _ClientName;
/// <summary>
/// 客户名称
/// </summary>
[BindProperty(PropertySource = Power.Business.Attributes.EnumPropertySource.Business,Description = "客户名称")]
[BindPropertyUse(PropertyUse = Power.Business.Attributes.EBusinessPropertyUse.ForeignLinkValue,SourcePropertyName = "Client_Guid",ForeignName = "Name" )]
public System.String ClientName { get { return _ClientName; } set { _ClientName = value; }  }

private  System.Guid _Id;
/// <summary>
/// 主键
/// </summary>
[BindProperty(Description = "主键")]
[BindPropertyUse(PropertyUse = Power.Business.Attributes.EBusinessPropertyUse.PrimaryKey )]
public System.Guid Id { get { return _Id; } set { _Id = value; }  }

private  System.String _ProductType;
/// <summary>
/// 产品类型
/// </summary>
[BindProperty(PropertySource = Power.Business.Attributes.EnumPropertySource.Business,Description = "产品类型")]
[BindPropertyUse(PropertyUse = Power.Business.Attributes.EBusinessPropertyUse.ForeignLinkValue,SourcePropertyName = "ProjectInfo_Guid",ForeignName = "ProductType" )]
public System.String ProductType { get { return _ProductType; } set { _ProductType = value; }  }

private  System.String _ProjectName;
/// <summary>
/// 项目名称
/// </summary>
[BindProperty(PropertySource = Power.Business.Attributes.EnumPropertySource.Business,Description = "项目名称")]
[BindPropertyUse(PropertyUse = Power.Business.Attributes.EBusinessPropertyUse.ForeignLinkValue,SourcePropertyName = "ProjectInfo_Guid",ForeignName = "ProjectName" )]
public System.String ProjectName { get { return _ProjectName; } set { _ProjectName = value; }  }

private  System.String _ProjectType;
/// <summary>
/// 项目类型
/// </summary>
[BindProperty(PropertySource = Power.Business.Attributes.EnumPropertySource.Business,Description = "项目类型")]
[BindPropertyUse(PropertyUse = Power.Business.Attributes.EBusinessPropertyUse.ForeignLinkValue,SourcePropertyName = "ProjectInfo_Guid",ForeignName = "ProjectType" )]
public System.String ProjectType { get { return _ProjectType; } set { _ProjectType = value; }  }

private  System.Guid _ProjectInfo_Guid;
/// <summary>
/// 项目信息外键
/// </summary>
[BindProperty(Description = "项目信息外键")]
[BindPropertyUse(PropertyUse = Power.Business.Attributes.EBusinessPropertyUse.ForeignKey, KeyWord = "PS_ProjectInfo",DataSource =  EDataSourceType.Entity,ForeignName = "Id",IsNull = true )]
public System.Guid ProjectInfo_Guid { get { return _ProjectInfo_Guid; } set { _ProjectInfo_Guid = value; }  }

private  System.Guid _Client_Guid;
/// <summary>
/// 客户外键
/// </summary>
[BindProperty(Description = "客户外键")]
[BindPropertyUse(PropertyUse = Power.Business.Attributes.EBusinessPropertyUse.ForeignKey, KeyWord = "Organize",DataSource =  EDataSourceType.Entity,ForeignName = "Id",IsNull = true )]
public System.Guid Client_Guid { get { return _Client_Guid; } set { _Client_Guid = value; }  }

private  System.String _BussinessManager;
/// <summary>
/// 商务经理
/// </summary>
[BindProperty(Description = "商务经理")]
public System.String BussinessManager { get { return _BussinessManager; } set { _BussinessManager = value; }  }

private  System.String _TechManager;
/// <summary>
/// 技术经理
/// </summary>
[BindProperty(Description = "技术经理")]
public System.String TechManager { get { return _TechManager; } set { _TechManager = value; }  }

private  System.Guid _BussinessManagerId;
/// <summary>
/// 商务经理Id
/// </summary>
[BindProperty(Description = "商务经理Id")]
public System.Guid BussinessManagerId { get { return _BussinessManagerId; } set { _BussinessManagerId = value; }  }

private  System.Guid _TechManagerId;
/// <summary>
/// 技术经理Id
/// </summary>
[BindProperty(Description = "技术经理Id")]
public System.Guid TechManagerId { get { return _TechManagerId; } set { _TechManagerId = value; }  }

private  System.DateTime _DeadLine;
/// <summary>
/// 投标截止日期
/// </summary>
[BindProperty(Description = "投标截止日期")]
public System.DateTime DeadLine { get { return _DeadLine; } set { _DeadLine = value; }  }

private  System.String _ResponsibleHuman;
/// <summary>
/// 责任人
/// </summary>
[BindProperty(Description = "责任人")]
public System.String ResponsibleHuman { get { return _ResponsibleHuman; } set { _ResponsibleHuman = value; }  }

private  System.Guid _ResponsibleHumanId;
/// <summary>
/// 责任人Id
/// </summary>
[BindProperty(Description = "责任人Id")]
public System.Guid ResponsibleHumanId { get { return _ResponsibleHumanId; } set { _ResponsibleHumanId = value; }  }

private  System.String _Memo;
/// <summary>
/// 
/// </summary>
[BindProperty(Description = "")]
public System.String Memo { get { return _Memo; } set { _Memo = value; }  }

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
			    if (name == "TITLE")
{
return _Title;
}
if (name == "CLIENTNAME")
{
return _ClientName;
}
if (name == "ID")
{
return _Id;
}
if (name == "PRODUCTTYPE")
{
return _ProductType;
}
if (name == "PROJECTNAME")
{
return _ProjectName;
}
if (name == "PROJECTTYPE")
{
return _ProjectType;
}
if (name == "PROJECTINFO_GUID")
{
return _ProjectInfo_Guid;
}
if (name == "CLIENT_GUID")
{
return _Client_Guid;
}
if (name == "BUSSINESSMANAGER")
{
return _BussinessManager;
}
if (name == "TECHMANAGER")
{
return _TechManager;
}
if (name == "BUSSINESSMANAGERID")
{
return _BussinessManagerId;
}
if (name == "TECHMANAGERID")
{
return _TechManagerId;
}
if (name == "DEADLINE")
{
return _DeadLine;
}
if (name == "RESPONSIBLEHUMAN")
{
return _ResponsibleHuman;
}
if (name == "RESPONSIBLEHUMANID")
{
return _ResponsibleHumanId;
}
if (name == "MEMO")
{
return _Memo;
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


				if (name == "BIDTASK_DTL")
{
return  this.BidTask_Dtl;
}

			    return base[name];
			}
			set 
			{
			   name = name.ToUpper();
			       if (name == "TITLE")
{
 _Title = System.Convert.ToString(value);return;
}
if (name == "CLIENTNAME")
{
 _ClientName = System.Convert.ToString(value);return;
}
if (name == "ID")
{
 _Id = XCode.Common.Helper.ConvertToGuid(value);return;
}
if (name == "PRODUCTTYPE")
{
 _ProductType = System.Convert.ToString(value);return;
}
if (name == "PROJECTNAME")
{
 _ProjectName = System.Convert.ToString(value);return;
}
if (name == "PROJECTTYPE")
{
 _ProjectType = System.Convert.ToString(value);return;
}
if (name == "PROJECTINFO_GUID")
{
 _ProjectInfo_Guid = XCode.Common.Helper.ConvertToGuid(value);return;
}
if (name == "CLIENT_GUID")
{
 _Client_Guid = XCode.Common.Helper.ConvertToGuid(value);return;
}
if (name == "BUSSINESSMANAGER")
{
 _BussinessManager = System.Convert.ToString(value);return;
}
if (name == "TECHMANAGER")
{
 _TechManager = System.Convert.ToString(value);return;
}
if (name == "BUSSINESSMANAGERID")
{
 _BussinessManagerId = XCode.Common.Helper.ConvertToGuid(value);return;
}
if (name == "TECHMANAGERID")
{
 _TechManagerId = XCode.Common.Helper.ConvertToGuid(value);return;
}
if (name == "DEADLINE")
{
 if (value == null || value.ToString().IsNullOrEmpty() == true) value = DateTime.MinValue;
 _DeadLine = System.Convert.ToDateTime(value);return;
}
if (name == "RESPONSIBLEHUMAN")
{
 _ResponsibleHuman = System.Convert.ToString(value);return;
}
if (name == "RESPONSIBLEHUMANID")
{
 _ResponsibleHumanId = XCode.Common.Helper.ConvertToGuid(value);return;
}
if (name == "MEMO")
{
 _Memo = System.Convert.ToString(value);return;
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
ParentKeyValues = GetParentKey(Meta.AttachBusinessList["BidTask_Dtl"]);
formData.Add("BidTask_Dtl", this.ReadOtherBusiness(ParentKeyValues, BidTask_Dtl, Meta.AttachBusinessList["BidTask_Dtl"]));


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
this.SaveOtherBusiness(formData, BidTask_Dtl, Meta.AttachBusinessList["BidTask_Dtl"]);

  return iResult;
}



		  /// <summary>
/// 删除方法
/// </summary>
/// <param name="KeyValues"></param>
/// <returns></returns>
protected override int DeleteBusiness(Dictionary<string, string> KeyValues)
{
this.DeleteOtherBusiness<TPS_BidTask_DtlBO>(KeyValues, Meta.AttachBusinessList["BidTask_Dtl"]);
int iResult = base.DeleteBusiness(KeyValues); 

  return iResult;
}



		  #endregion 
	} 
}

 namespace  Power.Systems.StdMarket.IStdMarket
{  
	/// <summary>
    /// 投标任务书对象接口
    /// </summary>
    public partial interface IPS_BidTaskBO :  Power.Business.IBaseBusiness
    {
	      #region 属性 

	     /// <summary>
/// 
/// </summary>
System.String Title { get ; set ;}

/// <summary>
/// 客户名称
/// </summary>
System.String ClientName { get ; set ;}

/// <summary>
/// 主键
/// </summary>
System.Guid Id { get ; set ;}

/// <summary>
/// 产品类型
/// </summary>
System.String ProductType { get ; set ;}

/// <summary>
/// 项目名称
/// </summary>
System.String ProjectName { get ; set ;}

/// <summary>
/// 项目类型
/// </summary>
System.String ProjectType { get ; set ;}

/// <summary>
/// 项目信息外键
/// </summary>
System.Guid ProjectInfo_Guid { get ; set ;}

/// <summary>
/// 客户外键
/// </summary>
System.Guid Client_Guid { get ; set ;}

/// <summary>
/// 商务经理
/// </summary>
System.String BussinessManager { get ; set ;}

/// <summary>
/// 技术经理
/// </summary>
System.String TechManager { get ; set ;}

/// <summary>
/// 商务经理Id
/// </summary>
System.Guid BussinessManagerId { get ; set ;}

/// <summary>
/// 技术经理Id
/// </summary>
System.Guid TechManagerId { get ; set ;}

/// <summary>
/// 投标截止日期
/// </summary>
System.DateTime DeadLine { get ; set ;}

/// <summary>
/// 责任人
/// </summary>
System.String ResponsibleHuman { get ; set ;}

/// <summary>
/// 责任人Id
/// </summary>
System.Guid ResponsibleHumanId { get ; set ;}

/// <summary>
/// 
/// </summary>
System.String Memo { get ; set ;}

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