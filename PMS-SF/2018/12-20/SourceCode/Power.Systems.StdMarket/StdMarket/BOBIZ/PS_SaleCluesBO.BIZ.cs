 
 

 using System;
 using System.Collections;
 using System.Collections.Generic;
 using System.Text; 
 using Power.Business.Attributes;
 using Power.Business;

 namespace  Power.Systems.StdMarket.StdMarket
{  
    /// <summary>
    /// 经营线索
    /// </summary>
    [BindBusinessObject(KeyWord="PS_SaleClues",EntityType = typeof(Power.Systems.StdMarket.StdMarket.PS_SaleCluesDO),BusinessType=Power.Business.Attributes.EBusinessType.Main ,Description = "经营线索" ,DefaultBindWorkFlow = true)] 
    public partial  class PS_SaleCluesBO : PS_SaleCluesBO<PS_SaleCluesBO >
    {

    }

	/// <summary>
    /// 经营线索
    /// </summary>  
	public    partial class PS_SaleCluesBO<TBusiness> : Power.Business.BaseBusiness<TBusiness>, Power.Systems.StdMarket.IStdMarket.IPS_SaleCluesBO 
        where TBusiness : Power.Systems.StdMarket.IStdMarket.IPS_SaleCluesBO, new()
		
    { 

	    #region 下辖业务对象
           
		#endregion 

	    #region 属性 

	 private  System.Guid _Id;
/// <summary>
/// 主键
/// </summary>
[BindProperty(Description = "主键")]
[BindPropertyUse(PropertyUse = Power.Business.Attributes.EBusinessPropertyUse.PrimaryKey )]
public System.Guid Id { get { return _Id; } set { _Id = value; }  }

private  System.String _ClueCode;
/// <summary>
/// 线索编号
/// </summary>
[BindProperty(Description = "线索编号")]
public System.String ClueCode { get { return _ClueCode; } set { _ClueCode = value; }  }

private  System.String _ClueName;
/// <summary>
/// 线索名称
/// </summary>
[BindProperty(Description = "线索名称")]
[BindPropertyUse(PropertyUse = Power.Business.Attributes.EBusinessPropertyUse.TitleField )]
public System.String ClueName { get { return _ClueName; } set { _ClueName = value; }  }

private  System.String _ClientName;
/// <summary>
/// 客户名称
/// </summary>
[BindProperty(Description = "客户名称")]
public System.String ClientName { get { return _ClientName; } set { _ClientName = value; }  }

private  System.String _Contacts;
/// <summary>
/// 联系人
/// </summary>
[BindProperty(Description = "联系人")]
public System.String Contacts { get { return _Contacts; } set { _Contacts = value; }  }

private  System.String _Tel;
/// <summary>
/// 联系电话
/// </summary>
[BindProperty(Description = "联系电话")]
public System.String Tel { get { return _Tel; } set { _Tel = value; }  }

private  System.String _Fax;
/// <summary>
/// 传真
/// </summary>
[BindProperty(Description = "传真")]
public System.String Fax { get { return _Fax; } set { _Fax = value; }  }

private  System.String _Email;
/// <summary>
/// 电子邮件
/// </summary>
[BindProperty(Description = "电子邮件")]
public System.String Email { get { return _Email; } set { _Email = value; }  }

private  System.String _ProductType;
/// <summary>
/// 产品类型
/// </summary>
[BindProperty(Description = "产品类型")]
public System.String ProductType { get { return _ProductType; } set { _ProductType = value; }  }

private  System.String _Memo;
/// <summary>
/// 备注
/// </summary>
[BindProperty(Description = "备注")]
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
			    if (name == "ID")
{
return _Id;
}
if (name == "CLUECODE")
{
return _ClueCode;
}
if (name == "CLUENAME")
{
return _ClueName;
}
if (name == "CLIENTNAME")
{
return _ClientName;
}
if (name == "CONTACTS")
{
return _Contacts;
}
if (name == "TEL")
{
return _Tel;
}
if (name == "FAX")
{
return _Fax;
}
if (name == "EMAIL")
{
return _Email;
}
if (name == "PRODUCTTYPE")
{
return _ProductType;
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


				
			    return base[name];
			}
			set 
			{
			   name = name.ToUpper();
			       if (name == "ID")
{
 _Id = XCode.Common.Helper.ConvertToGuid(value);return;
}
if (name == "CLUECODE")
{
 _ClueCode = System.Convert.ToString(value);return;
}
if (name == "CLUENAME")
{
 _ClueName = System.Convert.ToString(value);return;
}
if (name == "CLIENTNAME")
{
 _ClientName = System.Convert.ToString(value);return;
}
if (name == "CONTACTS")
{
 _Contacts = System.Convert.ToString(value);return;
}
if (name == "TEL")
{
 _Tel = System.Convert.ToString(value);return;
}
if (name == "FAX")
{
 _Fax = System.Convert.ToString(value);return;
}
if (name == "EMAIL")
{
 _Email = System.Convert.ToString(value);return;
}
if (name == "PRODUCTTYPE")
{
 _ProductType = System.Convert.ToString(value);return;
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
    /// 经营线索对象接口
    /// </summary>
    public partial interface IPS_SaleCluesBO :  Power.Business.IBaseBusiness
    {
	      #region 属性 

	     /// <summary>
/// 主键
/// </summary>
System.Guid Id { get ; set ;}

/// <summary>
/// 线索编号
/// </summary>
System.String ClueCode { get ; set ;}

/// <summary>
/// 线索名称
/// </summary>
System.String ClueName { get ; set ;}

/// <summary>
/// 客户名称
/// </summary>
System.String ClientName { get ; set ;}

/// <summary>
/// 联系人
/// </summary>
System.String Contacts { get ; set ;}

/// <summary>
/// 联系电话
/// </summary>
System.String Tel { get ; set ;}

/// <summary>
/// 传真
/// </summary>
System.String Fax { get ; set ;}

/// <summary>
/// 电子邮件
/// </summary>
System.String Email { get ; set ;}

/// <summary>
/// 产品类型
/// </summary>
System.String ProductType { get ; set ;}

/// <summary>
/// 备注
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