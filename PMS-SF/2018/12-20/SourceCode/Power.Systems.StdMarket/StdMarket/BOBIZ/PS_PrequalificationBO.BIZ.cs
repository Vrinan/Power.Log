 
 

 using System;
 using System.Collections;
 using System.Collections.Generic;
 using System.Text; 
 using Power.Business.Attributes;
 using Power.Business;

 namespace  Power.Systems.StdMarket.StdMarket
{  
    /// <summary>
    /// 资格预审
    /// </summary>
    [BindBusinessObject(KeyWord="PS_Prequalification",EntityType = typeof(Power.Systems.StdMarket.StdMarket.PS_PrequalificationDO),BusinessType=Power.Business.Attributes.EBusinessType.Main ,Description = "资格预审" ,DefaultBindWorkFlow = true)] 
    public partial  class PS_PrequalificationBO : PS_PrequalificationBO<PS_PrequalificationBO,Power.Systems.StdMarket.StdMarket.PS_Prequalification_DtlBO >
    {

    }

	/// <summary>
    /// 资格预审
    /// </summary>  
	public    partial class PS_PrequalificationBO<TBusiness,TPS_Prequalification_DtlBO> : Power.Business.BaseBusiness<TBusiness>, Power.Systems.StdMarket.IStdMarket.IPS_PrequalificationBO 
        where TBusiness : Power.Systems.StdMarket.IStdMarket.IPS_PrequalificationBO, new()
		where TPS_Prequalification_DtlBO : Power.Systems.StdMarket.IStdMarket.IPS_Prequalification_DtlBO,new()

    { 

	    #region 下辖业务对象
         private BusinessList<TPS_Prequalification_DtlBO> _Prequalification_Dtl;
/// <summary>
/// 资格预审资料
/// </summary>
[BindBusinessAttach(KeyWord="PS_Prequalification_Dtl", ParentKeyName = new string[] { "Id" }, MyKeyName = new string[] { "ParentId" }, Description = "资格预审资料")]
 public virtual BusinessList<TPS_Prequalification_DtlBO> Prequalification_Dtl { get { if (_Prequalification_Dtl == null) _Prequalification_Dtl = new BusinessList<TPS_Prequalification_DtlBO>(); return _Prequalification_Dtl; } set { _Prequalification_Dtl = value; } }

   
		#endregion 

	    #region 属性 

	 private  System.String _Title;
/// <summary>
/// 
/// </summary>
[BindProperty(Description = "")]
[BindPropertyUse(PropertyUse = Power.Business.Attributes.EBusinessPropertyUse.TitleField )]
public System.String Title { get { return _Title; } set { _Title = value; }  }

private  System.String _ProjectName;
/// <summary>
/// 
/// </summary>
[BindProperty(PropertySource = Power.Business.Attributes.EnumPropertySource.Business,Description = "")]
[BindPropertyUse(PropertyUse = Power.Business.Attributes.EBusinessPropertyUse.ForeignLinkValue,SourcePropertyName = "ProjectInfo_Guid",ForeignName = "ProjectName" )]
public System.String ProjectName { get { return _ProjectName; } set { _ProjectName = value; }  }

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

private  System.Guid _ProjectInfo_Guid;
/// <summary>
/// 前期信息GUID
/// </summary>
[BindProperty(Description = "前期信息GUID")]
[BindPropertyUse(PropertyUse = Power.Business.Attributes.EBusinessPropertyUse.ForeignKey, KeyWord = "PS_ProjectInfo",DataSource =  EDataSourceType.Entity,ForeignName = "Id",IsNull = true )]
public System.Guid ProjectInfo_Guid { get { return _ProjectInfo_Guid; } set { _ProjectInfo_Guid = value; }  }

private  System.Guid _Client_Guid;
/// <summary>
/// 客户GUID
/// </summary>
[BindProperty(Description = "客户GUID")]
[BindPropertyUse(PropertyUse = Power.Business.Attributes.EBusinessPropertyUse.ForeignKey, KeyWord = "Organize",DataSource =  EDataSourceType.Entity,ForeignName = "Id",IsNull = true )]
public System.Guid Client_Guid { get { return _Client_Guid; } set { _Client_Guid = value; }  }

private  System.String _PrequalificationStatus;
/// <summary>
/// 资格预审结果
/// </summary>
[BindProperty(Description = "资格预审结果")]
public System.String PrequalificationStatus { get { return _PrequalificationStatus; } set { _PrequalificationStatus = value; }  }

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
if (name == "PROJECTNAME")
{
return _ProjectName;
}
if (name == "CLIENTNAME")
{
return _ClientName;
}
if (name == "ID")
{
return _Id;
}
if (name == "PROJECTINFO_GUID")
{
return _ProjectInfo_Guid;
}
if (name == "CLIENT_GUID")
{
return _Client_Guid;
}
if (name == "PREQUALIFICATIONSTATUS")
{
return _PrequalificationStatus;
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


				if (name == "PREQUALIFICATION_DTL")
{
return  this.Prequalification_Dtl;
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
if (name == "PROJECTNAME")
{
 _ProjectName = System.Convert.ToString(value);return;
}
if (name == "CLIENTNAME")
{
 _ClientName = System.Convert.ToString(value);return;
}
if (name == "ID")
{
 _Id = XCode.Common.Helper.ConvertToGuid(value);return;
}
if (name == "PROJECTINFO_GUID")
{
 _ProjectInfo_Guid = XCode.Common.Helper.ConvertToGuid(value);return;
}
if (name == "CLIENT_GUID")
{
 _Client_Guid = XCode.Common.Helper.ConvertToGuid(value);return;
}
if (name == "PREQUALIFICATIONSTATUS")
{
 _PrequalificationStatus = System.Convert.ToString(value);return;
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
ParentKeyValues = GetParentKey(Meta.AttachBusinessList["Prequalification_Dtl"]);
formData.Add("Prequalification_Dtl", this.ReadOtherBusiness(ParentKeyValues, Prequalification_Dtl, Meta.AttachBusinessList["Prequalification_Dtl"]));


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
this.SaveOtherBusiness(formData, Prequalification_Dtl, Meta.AttachBusinessList["Prequalification_Dtl"]);

  return iResult;
}



		  /// <summary>
/// 删除方法
/// </summary>
/// <param name="KeyValues"></param>
/// <returns></returns>
protected override int DeleteBusiness(Dictionary<string, string> KeyValues)
{
this.DeleteOtherBusiness<TPS_Prequalification_DtlBO>(KeyValues, Meta.AttachBusinessList["Prequalification_Dtl"]);
int iResult = base.DeleteBusiness(KeyValues); 

  return iResult;
}



		  #endregion 
	} 
}

 namespace  Power.Systems.StdMarket.IStdMarket
{  
	/// <summary>
    /// 资格预审对象接口
    /// </summary>
    public partial interface IPS_PrequalificationBO :  Power.Business.IBaseBusiness
    {
	      #region 属性 

	     /// <summary>
/// 
/// </summary>
System.String Title { get ; set ;}

/// <summary>
/// 
/// </summary>
System.String ProjectName { get ; set ;}

/// <summary>
/// 
/// </summary>
System.String ClientName { get ; set ;}

/// <summary>
/// 主键
/// </summary>
System.Guid Id { get ; set ;}

/// <summary>
/// 前期信息GUID
/// </summary>
System.Guid ProjectInfo_Guid { get ; set ;}

/// <summary>
/// 客户GUID
/// </summary>
System.Guid Client_Guid { get ; set ;}

/// <summary>
/// 资格预审结果
/// </summary>
System.String PrequalificationStatus { get ; set ;}

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