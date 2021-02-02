 
 

 using System;
 using System.Collections;
 using System.Collections.Generic;
 using System.Text; 
 using Power.Business.Attributes;
 using Power.Business;

 namespace  Power.Systems.StdMarket.StdMarket
{  
    /// <summary>
    /// 项目合同基本信息
    /// </summary>
    [BindBusinessObject(KeyWord="PS_ContractInfo",EntityType = typeof(Power.Systems.StdMarket.StdMarket.PS_ContractInfoDO),BusinessType=Power.Business.Attributes.EBusinessType.Main ,Description = "项目合同基本信息" ,DefaultBindWorkFlow = true)] 
    public partial  class PS_ContractInfoBO : PS_ContractInfoBO<PS_ContractInfoBO >
    {

    }

	/// <summary>
    /// 项目合同基本信息
    /// </summary>  
	public    partial class PS_ContractInfoBO<TBusiness> : Power.Business.BaseBusiness<TBusiness>, Power.Systems.StdMarket.IStdMarket.IPS_ContractInfoBO 
        where TBusiness : Power.Systems.StdMarket.IStdMarket.IPS_ContractInfoBO, new()
		
    { 

	    #region 下辖业务对象
           
		#endregion 

	    #region 属性 

	 private  System.Double _ChangeAmount;
/// <summary>
/// 
/// </summary>
[BindProperty(Description = "")]
public System.Double ChangeAmount { get { return _ChangeAmount; } set { _ChangeAmount = value; }  }

private  System.String _ClientSignPerson;
/// <summary>
/// 
/// </summary>
[BindProperty(Description = "")]
public System.String ClientSignPerson { get { return _ClientSignPerson; } set { _ClientSignPerson = value; }  }

private  System.Double _ContractPeriod;
/// <summary>
/// 
/// </summary>
[BindProperty(Description = "")]
public System.Double ContractPeriod { get { return _ContractPeriod; } set { _ContractPeriod = value; }  }

private  System.String _ContractReviewCode;
/// <summary>
/// 
/// </summary>
[BindProperty(Description = "")]
public System.String ContractReviewCode { get { return _ContractReviewCode; } set { _ContractReviewCode = value; }  }

private  System.Guid _ContractReviewId;
/// <summary>
/// 
/// </summary>
[BindProperty(Description = "")]
public System.Guid ContractReviewId { get { return _ContractReviewId; } set { _ContractReviewId = value; }  }

private  System.DateTime _ContractStrartDate;
/// <summary>
/// 
/// </summary>
[BindProperty(Description = "")]
public System.DateTime ContractStrartDate { get { return _ContractStrartDate; } set { _ContractStrartDate = value; }  }

private  System.DateTime _ContractEndDate;
/// <summary>
/// 
/// </summary>
[BindProperty(Description = "")]
public System.DateTime ContractEndDate { get { return _ContractEndDate; } set { _ContractEndDate = value; }  }

private  System.Double _FinalContractAmount;
/// <summary>
/// 
/// </summary>
[BindProperty(Description = "")]
public System.Double FinalContractAmount { get { return _FinalContractAmount; } set { _FinalContractAmount = value; }  }

private  System.Guid _PartB_Guid;
/// <summary>
/// 
/// </summary>
[BindProperty(Description = "")]
public System.Guid PartB_Guid { get { return _PartB_Guid; } set { _PartB_Guid = value; }  }

private  System.String _PartyA;
/// <summary>
/// 
/// </summary>
[BindProperty(Description = "")]
public System.String PartyA { get { return _PartyA; } set { _PartyA = value; }  }

private  System.Guid _PartyA_Guid;
/// <summary>
/// 
/// </summary>
[BindProperty(Description = "")]
public System.Guid PartyA_Guid { get { return _PartyA_Guid; } set { _PartyA_Guid = value; }  }

private  System.String _PartyAPerson;
/// <summary>
/// 
/// </summary>
[BindProperty(Description = "")]
public System.String PartyAPerson { get { return _PartyAPerson; } set { _PartyAPerson = value; }  }

private  System.String _PartyB;
/// <summary>
/// 
/// </summary>
[BindProperty(Description = "")]
public System.String PartyB { get { return _PartyB; } set { _PartyB = value; }  }

private  System.String _PartyBSighPerson;
/// <summary>
/// 
/// </summary>
[BindProperty(Description = "")]
public System.String PartyBSighPerson { get { return _PartyBSighPerson; } set { _PartyBSighPerson = value; }  }

private  System.Guid _PartyBSighPersonId;
/// <summary>
/// 
/// </summary>
[BindProperty(Description = "")]
public System.Guid PartyBSighPersonId { get { return _PartyBSighPersonId; } set { _PartyBSighPersonId = value; }  }

private  System.String _PayType;
/// <summary>
/// 支付方式
/// </summary>
[BindProperty(Description = "支付方式")]
public System.String PayType { get { return _PayType; } set { _PayType = value; }  }

private  System.String _OrArmour;
/// <summary>
/// 有无甲供材
/// </summary>
[BindProperty(Description = "有无甲供材")]
public System.String OrArmour { get { return _OrArmour; } set { _OrArmour = value; }  }

private  System.String _ProjectName;
/// <summary>
/// 
/// </summary>
[BindProperty(PropertySource = Power.Business.Attributes.EnumPropertySource.Business,Description = "")]
[BindPropertyUse(PropertyUse = Power.Business.Attributes.EBusinessPropertyUse.ForeignLinkValue,SourcePropertyName = "ProjectInfo_Guid",ForeignName = "ProjectName" )]
public System.String ProjectName { get { return _ProjectName; } set { _ProjectName = value; }  }

private  System.Guid _Id;
/// <summary>
/// 
/// </summary>
[BindProperty(Description = "")]
[BindPropertyUse(PropertyUse = Power.Business.Attributes.EBusinessPropertyUse.PrimaryKey )]
public System.Guid Id { get { return _Id; } set { _Id = value; }  }

private  System.Guid _ProjectInfo_Guid;
/// <summary>
/// 
/// </summary>
[BindProperty(Description = "")]
[BindPropertyUse(PropertyUse = Power.Business.Attributes.EBusinessPropertyUse.ForeignKey, KeyWord = "PS_ProjectInfo",DataSource =  EDataSourceType.Entity,ForeignName = "Id",IsNull = true )]
public System.Guid ProjectInfo_Guid { get { return _ProjectInfo_Guid; } set { _ProjectInfo_Guid = value; }  }

private  System.String _ContractCode;
/// <summary>
/// 
/// </summary>
[BindProperty(Description = "")]
[BindPropertyUse(PropertyUse = Power.Business.Attributes.EBusinessPropertyUse.CodeField )]
public System.String ContractCode { get { return _ContractCode; } set { _ContractCode = value; }  }

private  System.String _ContractName;
/// <summary>
/// 
/// </summary>
[BindProperty(Description = "")]
[BindPropertyUse(PropertyUse = Power.Business.Attributes.EBusinessPropertyUse.TitleField )]
public System.String ContractName { get { return _ContractName; } set { _ContractName = value; }  }

private  System.String _ContractType;
/// <summary>
/// 
/// </summary>
[BindProperty(Description = "")]
public System.String ContractType { get { return _ContractType; } set { _ContractType = value; }  }

private  System.String _ContractForm;
/// <summary>
/// 
/// </summary>
[BindProperty(Description = "")]
public System.String ContractForm { get { return _ContractForm; } set { _ContractForm = value; }  }

private  System.Double _ContractAmount;
/// <summary>
/// 
/// </summary>
[BindProperty(Description = "")]
public System.Double ContractAmount { get { return _ContractAmount; } set { _ContractAmount = value; }  }

private  System.String _CurrencyType;
/// <summary>
/// 
/// </summary>
[BindProperty(Description = "")]
public System.String CurrencyType { get { return _CurrencyType; } set { _CurrencyType = value; }  }

private  System.String _ProductType;
/// <summary>
/// 
/// </summary>
[BindProperty(Description = "")]
public System.String ProductType { get { return _ProductType; } set { _ProductType = value; }  }

private  System.String _ReviewWay;
/// <summary>
/// 
/// </summary>
[BindProperty(Description = "")]
public System.String ReviewWay { get { return _ReviewWay; } set { _ReviewWay = value; }  }

private  System.DateTime _ReviewDate;
/// <summary>
/// 
/// </summary>
[BindProperty(Description = "")]
public System.DateTime ReviewDate { get { return _ReviewDate; } set { _ReviewDate = value; }  }

private  System.DateTime _SignedDate;
/// <summary>
/// 
/// </summary>
[BindProperty(Description = "")]
public System.DateTime SignedDate { get { return _SignedDate; } set { _SignedDate = value; }  }

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
			    if (name == "CHANGEAMOUNT")
{
return _ChangeAmount;
}
if (name == "CLIENTSIGNPERSON")
{
return _ClientSignPerson;
}
if (name == "CONTRACTPERIOD")
{
return _ContractPeriod;
}
if (name == "CONTRACTREVIEWCODE")
{
return _ContractReviewCode;
}
if (name == "CONTRACTREVIEWID")
{
return _ContractReviewId;
}
if (name == "CONTRACTSTRARTDATE")
{
return _ContractStrartDate;
}
if (name == "CONTRACTENDDATE")
{
return _ContractEndDate;
}
if (name == "FINALCONTRACTAMOUNT")
{
return _FinalContractAmount;
}
if (name == "PARTB_GUID")
{
return _PartB_Guid;
}
if (name == "PARTYA")
{
return _PartyA;
}
if (name == "PARTYA_GUID")
{
return _PartyA_Guid;
}
if (name == "PARTYAPERSON")
{
return _PartyAPerson;
}
if (name == "PARTYB")
{
return _PartyB;
}
if (name == "PARTYBSIGHPERSON")
{
return _PartyBSighPerson;
}
if (name == "PARTYBSIGHPERSONID")
{
return _PartyBSighPersonId;
}
if (name == "PAYTYPE")
{
return _PayType;
}
if (name == "ORARMOUR")
{
return _OrArmour;
}
if (name == "PROJECTNAME")
{
return _ProjectName;
}
if (name == "ID")
{
return _Id;
}
if (name == "PROJECTINFO_GUID")
{
return _ProjectInfo_Guid;
}
if (name == "CONTRACTCODE")
{
return _ContractCode;
}
if (name == "CONTRACTNAME")
{
return _ContractName;
}
if (name == "CONTRACTTYPE")
{
return _ContractType;
}
if (name == "CONTRACTFORM")
{
return _ContractForm;
}
if (name == "CONTRACTAMOUNT")
{
return _ContractAmount;
}
if (name == "CURRENCYTYPE")
{
return _CurrencyType;
}
if (name == "PRODUCTTYPE")
{
return _ProductType;
}
if (name == "REVIEWWAY")
{
return _ReviewWay;
}
if (name == "REVIEWDATE")
{
return _ReviewDate;
}
if (name == "SIGNEDDATE")
{
return _SignedDate;
}
if (name == "CLIENT_GUID")
{
return _Client_Guid;
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


				
			    return base[name];
			}
			set 
			{
			   name = name.ToUpper();
			       if (name == "CHANGEAMOUNT")
{
 _ChangeAmount = System.Convert.ToDouble(value);return;
}
if (name == "CLIENTSIGNPERSON")
{
 _ClientSignPerson = System.Convert.ToString(value);return;
}
if (name == "CONTRACTPERIOD")
{
 _ContractPeriod = System.Convert.ToDouble(value);return;
}
if (name == "CONTRACTREVIEWCODE")
{
 _ContractReviewCode = System.Convert.ToString(value);return;
}
if (name == "CONTRACTREVIEWID")
{
 _ContractReviewId = XCode.Common.Helper.ConvertToGuid(value);return;
}
if (name == "CONTRACTSTRARTDATE")
{
 if (value == null || value.ToString().IsNullOrEmpty() == true) value = DateTime.MinValue;
 _ContractStrartDate = System.Convert.ToDateTime(value);return;
}
if (name == "CONTRACTENDDATE")
{
 if (value == null || value.ToString().IsNullOrEmpty() == true) value = DateTime.MinValue;
 _ContractEndDate = System.Convert.ToDateTime(value);return;
}
if (name == "FINALCONTRACTAMOUNT")
{
 _FinalContractAmount = System.Convert.ToDouble(value);return;
}
if (name == "PARTB_GUID")
{
 _PartB_Guid = XCode.Common.Helper.ConvertToGuid(value);return;
}
if (name == "PARTYA")
{
 _PartyA = System.Convert.ToString(value);return;
}
if (name == "PARTYA_GUID")
{
 _PartyA_Guid = XCode.Common.Helper.ConvertToGuid(value);return;
}
if (name == "PARTYAPERSON")
{
 _PartyAPerson = System.Convert.ToString(value);return;
}
if (name == "PARTYB")
{
 _PartyB = System.Convert.ToString(value);return;
}
if (name == "PARTYBSIGHPERSON")
{
 _PartyBSighPerson = System.Convert.ToString(value);return;
}
if (name == "PARTYBSIGHPERSONID")
{
 _PartyBSighPersonId = XCode.Common.Helper.ConvertToGuid(value);return;
}
if (name == "PAYTYPE")
{
 _PayType = System.Convert.ToString(value);return;
}
if (name == "ORARMOUR")
{
 _OrArmour = System.Convert.ToString(value);return;
}
if (name == "PROJECTNAME")
{
 _ProjectName = System.Convert.ToString(value);return;
}
if (name == "ID")
{
 _Id = XCode.Common.Helper.ConvertToGuid(value);return;
}
if (name == "PROJECTINFO_GUID")
{
 _ProjectInfo_Guid = XCode.Common.Helper.ConvertToGuid(value);return;
}
if (name == "CONTRACTCODE")
{
 _ContractCode = System.Convert.ToString(value);return;
}
if (name == "CONTRACTNAME")
{
 _ContractName = System.Convert.ToString(value);return;
}
if (name == "CONTRACTTYPE")
{
 _ContractType = System.Convert.ToString(value);return;
}
if (name == "CONTRACTFORM")
{
 _ContractForm = System.Convert.ToString(value);return;
}
if (name == "CONTRACTAMOUNT")
{
 _ContractAmount = System.Convert.ToDouble(value);return;
}
if (name == "CURRENCYTYPE")
{
 _CurrencyType = System.Convert.ToString(value);return;
}
if (name == "PRODUCTTYPE")
{
 _ProductType = System.Convert.ToString(value);return;
}
if (name == "REVIEWWAY")
{
 _ReviewWay = System.Convert.ToString(value);return;
}
if (name == "REVIEWDATE")
{
 if (value == null || value.ToString().IsNullOrEmpty() == true) value = DateTime.MinValue;
 _ReviewDate = System.Convert.ToDateTime(value);return;
}
if (name == "SIGNEDDATE")
{
 if (value == null || value.ToString().IsNullOrEmpty() == true) value = DateTime.MinValue;
 _SignedDate = System.Convert.ToDateTime(value);return;
}
if (name == "CLIENT_GUID")
{
 _Client_Guid = XCode.Common.Helper.ConvertToGuid(value);return;
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
    /// 项目合同基本信息对象接口
    /// </summary>
    public partial interface IPS_ContractInfoBO :  Power.Business.IBaseBusiness
    {
	      #region 属性 

	     /// <summary>
/// 
/// </summary>
System.Double ChangeAmount { get ; set ;}

/// <summary>
/// 
/// </summary>
System.String ClientSignPerson { get ; set ;}

/// <summary>
/// 
/// </summary>
System.Double ContractPeriod { get ; set ;}

/// <summary>
/// 
/// </summary>
System.String ContractReviewCode { get ; set ;}

/// <summary>
/// 
/// </summary>
System.Guid ContractReviewId { get ; set ;}

/// <summary>
/// 
/// </summary>
System.DateTime ContractStrartDate { get ; set ;}

/// <summary>
/// 
/// </summary>
System.DateTime ContractEndDate { get ; set ;}

/// <summary>
/// 
/// </summary>
System.Double FinalContractAmount { get ; set ;}

/// <summary>
/// 
/// </summary>
System.Guid PartB_Guid { get ; set ;}

/// <summary>
/// 
/// </summary>
System.String PartyA { get ; set ;}

/// <summary>
/// 
/// </summary>
System.Guid PartyA_Guid { get ; set ;}

/// <summary>
/// 
/// </summary>
System.String PartyAPerson { get ; set ;}

/// <summary>
/// 
/// </summary>
System.String PartyB { get ; set ;}

/// <summary>
/// 
/// </summary>
System.String PartyBSighPerson { get ; set ;}

/// <summary>
/// 
/// </summary>
System.Guid PartyBSighPersonId { get ; set ;}

/// <summary>
/// 支付方式
/// </summary>
System.String PayType { get ; set ;}

/// <summary>
/// 有无甲供材
/// </summary>
System.String OrArmour { get ; set ;}

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
System.Guid ProjectInfo_Guid { get ; set ;}

/// <summary>
/// 
/// </summary>
System.String ContractCode { get ; set ;}

/// <summary>
/// 
/// </summary>
System.String ContractName { get ; set ;}

/// <summary>
/// 
/// </summary>
System.String ContractType { get ; set ;}

/// <summary>
/// 
/// </summary>
System.String ContractForm { get ; set ;}

/// <summary>
/// 
/// </summary>
System.Double ContractAmount { get ; set ;}

/// <summary>
/// 
/// </summary>
System.String CurrencyType { get ; set ;}

/// <summary>
/// 
/// </summary>
System.String ProductType { get ; set ;}

/// <summary>
/// 
/// </summary>
System.String ReviewWay { get ; set ;}

/// <summary>
/// 
/// </summary>
System.DateTime ReviewDate { get ; set ;}

/// <summary>
/// 
/// </summary>
System.DateTime SignedDate { get ; set ;}

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