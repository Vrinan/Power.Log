 
 

 using System;
 using System.Collections;
 using System.Collections.Generic;
 using System.Text; 
 using Power.Business.Attributes;
 using Power.Business;

 namespace  Power.Systems.StdMarket.StdMarket
{  
    /// <summary>
    /// 客户评价
    /// </summary>
    [BindBusinessObject(KeyWord="PS_ClientEvaluation",EntityType = typeof(Power.Systems.StdMarket.StdMarket.PS_ClientEvaluationDO),BusinessType=Power.Business.Attributes.EBusinessType.Main ,Description = "客户评价" ,DefaultBindWorkFlow = true)] 
    public partial  class PS_ClientEvaluationBO : PS_ClientEvaluationBO<PS_ClientEvaluationBO,Power.Systems.StdMarket.StdMarket.PS_ClientEvaluation_DtlBO >
    {

    }

	/// <summary>
    /// 客户评价
    /// </summary>  
	public    partial class PS_ClientEvaluationBO<TBusiness,TPS_ClientEvaluation_DtlBO> : Power.Business.BaseBusiness<TBusiness>, Power.Systems.StdMarket.IStdMarket.IPS_ClientEvaluationBO 
        where TBusiness : Power.Systems.StdMarket.IStdMarket.IPS_ClientEvaluationBO, new()
		where TPS_ClientEvaluation_DtlBO : Power.Systems.StdMarket.IStdMarket.IPS_ClientEvaluation_DtlBO,new()

    { 

	    #region 下辖业务对象
         private BusinessList<TPS_ClientEvaluation_DtlBO> _ClientEvaluation_Dtl;
/// <summary>
/// 客户评价子表
/// </summary>
[BindBusinessAttach(KeyWord="PS_ClientEvaluation_Dtl", ParentKeyName = new string[] { "Id" }, MyKeyName = new string[] { "ParentId" }, Description = "客户评价子表")]
 public virtual BusinessList<TPS_ClientEvaluation_DtlBO> ClientEvaluation_Dtl { get { if (_ClientEvaluation_Dtl == null) _ClientEvaluation_Dtl = new BusinessList<TPS_ClientEvaluation_DtlBO>(); return _ClientEvaluation_Dtl; } set { _ClientEvaluation_Dtl = value; } }

   
		#endregion 

	    #region 属性 

	 private  System.String _ClientName;
/// <summary>
/// 客户名称
/// </summary>
[BindProperty(Description = "客户名称")]
public System.String ClientName { get { return _ClientName; } set { _ClientName = value; }  }

private  System.DateTime _EvaluationDate;
/// <summary>
/// 评价日期
/// </summary>
[BindProperty(Description = "评价日期")]
public System.DateTime EvaluationDate { get { return _EvaluationDate; } set { _EvaluationDate = value; }  }

private  System.String _ProjectName;
/// <summary>
/// 项目名称
/// </summary>
[BindProperty(Description = "项目名称")]
public System.String ProjectName { get { return _ProjectName; } set { _ProjectName = value; }  }

private  System.Guid _Id;
/// <summary>
/// 
/// </summary>
[BindProperty(Description = "")]
[BindPropertyUse(PropertyUse = Power.Business.Attributes.EBusinessPropertyUse.PrimaryKey )]
public System.Guid Id { get { return _Id; } set { _Id = value; }  }

private  System.String _ContractName;
/// <summary>
/// 合同名称
/// </summary>
[BindProperty(PropertySource = Power.Business.Attributes.EnumPropertySource.Business,Description = "合同名称")]
[BindPropertyUse(PropertyUse = Power.Business.Attributes.EBusinessPropertyUse.ForeignLinkValue,SourcePropertyName = "Contract_Guid",ForeignName = "ContractName" )]
public System.String ContractName { get { return _ContractName; } set { _ContractName = value; }  }

private  System.String _ClientCode;
/// <summary>
/// 客户编号
/// </summary>
[BindProperty(PropertySource = Power.Business.Attributes.EnumPropertySource.Business,Description = "客户编号")]
[BindPropertyUse(PropertyUse = Power.Business.Attributes.EBusinessPropertyUse.ForeignLinkValue,SourcePropertyName = "Client_Guid",ForeignName = "Code" )]
public System.String ClientCode { get { return _ClientCode; } set { _ClientCode = value; }  }

private  System.Guid _Client_Guid;
/// <summary>
/// 关联客户
/// </summary>
[BindProperty(Description = "关联客户")]
[BindPropertyUse(PropertyUse = Power.Business.Attributes.EBusinessPropertyUse.ForeignKey, KeyWord = "Organize",DataSource =  EDataSourceType.Entity,ForeignName = "Id",IsNull = true )]
public System.Guid Client_Guid { get { return _Client_Guid; } set { _Client_Guid = value; }  }

private  System.Guid _Proj_Guid;
/// <summary>
/// 关联项目
/// </summary>
[BindProperty(Description = "关联项目")]
[BindPropertyUse(PropertyUse = Power.Business.Attributes.EBusinessPropertyUse.ForeignKey, KeyWord = "PLNProject",DataSource =  EDataSourceType.Entity,ForeignName = "project_guid",IsNull = true )]
public System.Guid Proj_Guid { get { return _Proj_Guid; } set { _Proj_Guid = value; }  }

private  System.Guid _Contract_Guid;
/// <summary>
/// 关联合同
/// </summary>
[BindProperty(Description = "关联合同")]
[BindPropertyUse(PropertyUse = Power.Business.Attributes.EBusinessPropertyUse.ForeignKey, KeyWord = "PS_ContractInfo",DataSource =  EDataSourceType.Entity,ForeignName = "Id",IsNull = true )]
public System.Guid Contract_Guid { get { return _Contract_Guid; } set { _Contract_Guid = value; }  }

private  System.String _Code;
/// <summary>
/// 
/// </summary>
[BindProperty(Description = "")]
[BindPropertyUse(PropertyUse = Power.Business.Attributes.EBusinessPropertyUse.CodeField )]
public System.String Code { get { return _Code; } set { _Code = value; }  }

private  System.String _Title;
/// <summary>
/// 
/// </summary>
[BindProperty(Description = "")]
[BindPropertyUse(PropertyUse = Power.Business.Attributes.EBusinessPropertyUse.TitleField )]
public System.String Title { get { return _Title; } set { _Title = value; }  }

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
if (name == "EVALUATIONDATE")
{
return _EvaluationDate;
}
if (name == "PROJECTNAME")
{
return _ProjectName;
}
if (name == "ID")
{
return _Id;
}
if (name == "CONTRACTNAME")
{
return _ContractName;
}
if (name == "CLIENTCODE")
{
return _ClientCode;
}
if (name == "CLIENT_GUID")
{
return _Client_Guid;
}
if (name == "PROJ_GUID")
{
return _Proj_Guid;
}
if (name == "CONTRACT_GUID")
{
return _Contract_Guid;
}
if (name == "CODE")
{
return _Code;
}
if (name == "TITLE")
{
return _Title;
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


				if (name == "CLIENTEVALUATION_DTL")
{
return  this.ClientEvaluation_Dtl;
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
if (name == "EVALUATIONDATE")
{
 if (value == null || value.ToString().IsNullOrEmpty() == true) value = DateTime.MinValue;
 _EvaluationDate = System.Convert.ToDateTime(value);return;
}
if (name == "PROJECTNAME")
{
 _ProjectName = System.Convert.ToString(value);return;
}
if (name == "ID")
{
 _Id = XCode.Common.Helper.ConvertToGuid(value);return;
}
if (name == "CONTRACTNAME")
{
 _ContractName = System.Convert.ToString(value);return;
}
if (name == "CLIENTCODE")
{
 _ClientCode = System.Convert.ToString(value);return;
}
if (name == "CLIENT_GUID")
{
 _Client_Guid = XCode.Common.Helper.ConvertToGuid(value);return;
}
if (name == "PROJ_GUID")
{
 _Proj_Guid = XCode.Common.Helper.ConvertToGuid(value);return;
}
if (name == "CONTRACT_GUID")
{
 _Contract_Guid = XCode.Common.Helper.ConvertToGuid(value);return;
}
if (name == "CODE")
{
 _Code = System.Convert.ToString(value);return;
}
if (name == "TITLE")
{
 _Title = System.Convert.ToString(value);return;
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
ParentKeyValues = GetParentKey(Meta.AttachBusinessList["ClientEvaluation_Dtl"]);
formData.Add("ClientEvaluation_Dtl", this.ReadOtherBusiness(ParentKeyValues, ClientEvaluation_Dtl, Meta.AttachBusinessList["ClientEvaluation_Dtl"]));


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
this.SaveOtherBusiness(formData, ClientEvaluation_Dtl, Meta.AttachBusinessList["ClientEvaluation_Dtl"]);

  return iResult;
}



		  /// <summary>
/// 删除方法
/// </summary>
/// <param name="KeyValues"></param>
/// <returns></returns>
protected override int DeleteBusiness(Dictionary<string, string> KeyValues)
{
this.DeleteOtherBusiness<TPS_ClientEvaluation_DtlBO>(KeyValues, Meta.AttachBusinessList["ClientEvaluation_Dtl"]);
int iResult = base.DeleteBusiness(KeyValues); 

  return iResult;
}



		  #endregion 
	} 
}

 namespace  Power.Systems.StdMarket.IStdMarket
{  
	/// <summary>
    /// 客户评价对象接口
    /// </summary>
    public partial interface IPS_ClientEvaluationBO :  Power.Business.IBaseBusiness
    {
	      #region 属性 

	     /// <summary>
/// 客户名称
/// </summary>
System.String ClientName { get ; set ;}

/// <summary>
/// 评价日期
/// </summary>
System.DateTime EvaluationDate { get ; set ;}

/// <summary>
/// 项目名称
/// </summary>
System.String ProjectName { get ; set ;}

/// <summary>
/// 
/// </summary>
System.Guid Id { get ; set ;}

/// <summary>
/// 合同名称
/// </summary>
System.String ContractName { get ; set ;}

/// <summary>
/// 客户编号
/// </summary>
System.String ClientCode { get ; set ;}

/// <summary>
/// 关联客户
/// </summary>
System.Guid Client_Guid { get ; set ;}

/// <summary>
/// 关联项目
/// </summary>
System.Guid Proj_Guid { get ; set ;}

/// <summary>
/// 关联合同
/// </summary>
System.Guid Contract_Guid { get ; set ;}

/// <summary>
/// 
/// </summary>
System.String Code { get ; set ;}

/// <summary>
/// 
/// </summary>
System.String Title { get ; set ;}

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