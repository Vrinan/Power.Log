 
 

 using System;
 using System.Collections;
 using System.Collections.Generic;
 using System.Text; 
 using Power.Business.Attributes;
 using Power.Business;

 namespace  Power.Systems.StdMarket.StdMarket
{  
    /// <summary>
    /// 参与报价人员
    /// </summary>
    [BindBusinessObject(KeyWord="PS_BidPlan_QuoteHuman",EntityType = typeof(Power.Systems.StdMarket.StdMarket.PS_BidPlan_QuoteHumanDO),BusinessType=Power.Business.Attributes.EBusinessType.Sub ,Description = "参与报价人员" )] 
    public partial  class PS_BidPlan_QuoteHumanBO : PS_BidPlan_QuoteHumanBO<PS_BidPlan_QuoteHumanBO >
    {

    }

	/// <summary>
    /// 参与报价人员
    /// </summary>  
	public    partial class PS_BidPlan_QuoteHumanBO<TBusiness> : Power.Business.BaseBusiness<TBusiness>, Power.Systems.StdMarket.IStdMarket.IPS_BidPlan_QuoteHumanBO 
        where TBusiness : Power.Systems.StdMarket.IStdMarket.IPS_BidPlan_QuoteHumanBO, new()
		
    { 

	    #region 下辖业务对象
           
		#endregion 

	    #region 属性 

	 private  System.Guid _Id;
/// <summary>
/// 
/// </summary>
[BindProperty(Description = "")]
[BindPropertyUse(PropertyUse = Power.Business.Attributes.EBusinessPropertyUse.PrimaryKey )]
public System.Guid Id { get { return _Id; } set { _Id = value; }  }

private  System.DateTime _UpdDate;
/// <summary>
/// 
/// </summary>
[BindProperty(Description = "")]
[BindPropertySession(PropertyAssignment = Power.Business.Attributes.EBusinessPropertyAssignment.UpdDate,  SessionName = "UpdDate",   IsNull = false, IsAllowNoExist = false)]
public System.DateTime UpdDate { get { return _UpdDate; } set { _UpdDate = value; }  }

private  System.Guid _MasterId;
/// <summary>
/// 
/// </summary>
[BindProperty(Description = "")]
public System.Guid MasterId { get { return _MasterId; } set { _MasterId = value; }  }

private  System.String _Major;
/// <summary>
/// 专业
/// </summary>
[BindProperty(Description = "专业")]
public System.String Major { get { return _Major; } set { _Major = value; }  }

private  System.Guid _MajorId;
/// <summary>
/// 
/// </summary>
[BindProperty(Description = "")]
public System.Guid MajorId { get { return _MajorId; } set { _MajorId = value; }  }

private  System.String _HumanName;
/// <summary>
/// 姓名
/// </summary>
[BindProperty(Description = "姓名")]
public System.String HumanName { get { return _HumanName; } set { _HumanName = value; }  }

private  System.Guid _HumanNameId;
/// <summary>
/// 
/// </summary>
[BindProperty(Description = "")]
public System.Guid HumanNameId { get { return _HumanNameId; } set { _HumanNameId = value; }  }

private  System.String _Dept;
/// <summary>
/// 部门
/// </summary>
[BindProperty(Description = "部门")]
public System.String Dept { get { return _Dept; } set { _Dept = value; }  }

private  System.Guid _DeptId;
/// <summary>
/// 
/// </summary>
[BindProperty(Description = "")]
public System.Guid DeptId { get { return _DeptId; } set { _DeptId = value; }  }


      
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
if (name == "UPDDATE")
{
return _UpdDate;
}
if (name == "MASTERID")
{
return _MasterId;
}
if (name == "MAJOR")
{
return _Major;
}
if (name == "MAJORID")
{
return _MajorId;
}
if (name == "HUMANNAME")
{
return _HumanName;
}
if (name == "HUMANNAMEID")
{
return _HumanNameId;
}
if (name == "DEPT")
{
return _Dept;
}
if (name == "DEPTID")
{
return _DeptId;
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
if (name == "UPDDATE")
{
 if (value == null || value.ToString().IsNullOrEmpty() == true) value = DateTime.MinValue;
 _UpdDate = System.Convert.ToDateTime(value);return;
}
if (name == "MASTERID")
{
 _MasterId = XCode.Common.Helper.ConvertToGuid(value);return;
}
if (name == "MAJOR")
{
 _Major = System.Convert.ToString(value);return;
}
if (name == "MAJORID")
{
 _MajorId = XCode.Common.Helper.ConvertToGuid(value);return;
}
if (name == "HUMANNAME")
{
 _HumanName = System.Convert.ToString(value);return;
}
if (name == "HUMANNAMEID")
{
 _HumanNameId = XCode.Common.Helper.ConvertToGuid(value);return;
}
if (name == "DEPT")
{
 _Dept = System.Convert.ToString(value);return;
}
if (name == "DEPTID")
{
 _DeptId = XCode.Common.Helper.ConvertToGuid(value);return;
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
    /// 参与报价人员对象接口
    /// </summary>
    public partial interface IPS_BidPlan_QuoteHumanBO :  Power.Business.IBaseBusiness
    {
	      #region 属性 

	     /// <summary>
/// 
/// </summary>
System.Guid Id { get ; set ;}

/// <summary>
/// 
/// </summary>
System.DateTime UpdDate { get ; set ;}

/// <summary>
/// 
/// </summary>
System.Guid MasterId { get ; set ;}

/// <summary>
/// 专业
/// </summary>
System.String Major { get ; set ;}

/// <summary>
/// 
/// </summary>
System.Guid MajorId { get ; set ;}

/// <summary>
/// 姓名
/// </summary>
System.String HumanName { get ; set ;}

/// <summary>
/// 
/// </summary>
System.Guid HumanNameId { get ; set ;}

/// <summary>
/// 部门
/// </summary>
System.String Dept { get ; set ;}

/// <summary>
/// 
/// </summary>
System.Guid DeptId { get ; set ;}


      
		#endregion 
	}
}