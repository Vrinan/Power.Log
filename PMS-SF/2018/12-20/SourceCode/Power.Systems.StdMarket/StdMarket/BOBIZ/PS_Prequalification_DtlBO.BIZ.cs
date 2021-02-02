 
 

 using System;
 using System.Collections;
 using System.Collections.Generic;
 using System.Text; 
 using Power.Business.Attributes;
 using Power.Business;

 namespace  Power.Systems.StdMarket.StdMarket
{  
    /// <summary>
    /// 资格预审资料
    /// </summary>
    [BindBusinessObject(KeyWord="PS_Prequalification_Dtl",EntityType = typeof(Power.Systems.StdMarket.StdMarket.PS_Prequalification_DtlDO),BusinessType=Power.Business.Attributes.EBusinessType.Sub ,Description = "资格预审资料" )] 
    public partial  class PS_Prequalification_DtlBO : PS_Prequalification_DtlBO<PS_Prequalification_DtlBO >
    {

    }

	/// <summary>
    /// 资格预审资料
    /// </summary>  
	public    partial class PS_Prequalification_DtlBO<TBusiness> : Power.Business.BaseBusiness<TBusiness>, Power.Systems.StdMarket.IStdMarket.IPS_Prequalification_DtlBO 
        where TBusiness : Power.Systems.StdMarket.IStdMarket.IPS_Prequalification_DtlBO, new()
		
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

private  System.Guid _ParentId;
/// <summary>
/// 外键
/// </summary>
[BindProperty(Description = "外键")]
public System.Guid ParentId { get { return _ParentId; } set { _ParentId = value; }  }

private  System.Int32 _Sequ;
/// <summary>
/// 序号
/// </summary>
[BindProperty(Description = "序号")]
[BindPropertyUse(PropertyUse = Power.Business.Attributes.EBusinessPropertyUse.SequField )]
public System.Int32 Sequ { get { return _Sequ; } set { _Sequ = value; }  }

private  System.String _DocumentName;
/// <summary>
/// 资料名称
/// </summary>
[BindProperty(Description = "资料名称")]
public System.String DocumentName { get { return _DocumentName; } set { _DocumentName = value; }  }

private  System.DateTime _DeliveryDate;
/// <summary>
/// 递交日期
/// </summary>
[BindProperty(Description = "递交日期")]
public System.DateTime DeliveryDate { get { return _DeliveryDate; } set { _DeliveryDate = value; }  }

private  System.String _DeliveryWay;
/// <summary>
/// 提交方式
/// </summary>
[BindProperty(Description = "提交方式")]
public System.String DeliveryWay { get { return _DeliveryWay; } set { _DeliveryWay = value; }  }

private  System.String _ReviewResult;
/// <summary>
/// 审查结果
/// </summary>
[BindProperty(Description = "审查结果")]
public System.String ReviewResult { get { return _ReviewResult; } set { _ReviewResult = value; }  }

private  System.String _Handler;
/// <summary>
/// 经办人
/// </summary>
[BindProperty(Description = "经办人")]
public System.String Handler { get { return _Handler; } set { _Handler = value; }  }

private  System.Guid _HandlerId;
/// <summary>
/// 
/// </summary>
[BindProperty(Description = "")]
public System.Guid HandlerId { get { return _HandlerId; } set { _HandlerId = value; }  }


      
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
if (name == "PARENTID")
{
return _ParentId;
}
if (name == "SEQU")
{
return _Sequ;
}
if (name == "DOCUMENTNAME")
{
return _DocumentName;
}
if (name == "DELIVERYDATE")
{
return _DeliveryDate;
}
if (name == "DELIVERYWAY")
{
return _DeliveryWay;
}
if (name == "REVIEWRESULT")
{
return _ReviewResult;
}
if (name == "HANDLER")
{
return _Handler;
}
if (name == "HANDLERID")
{
return _HandlerId;
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
if (name == "PARENTID")
{
 _ParentId = XCode.Common.Helper.ConvertToGuid(value);return;
}
if (name == "SEQU")
{
 _Sequ = System.Convert.ToInt32(value);return;
}
if (name == "DOCUMENTNAME")
{
 _DocumentName = System.Convert.ToString(value);return;
}
if (name == "DELIVERYDATE")
{
 if (value == null || value.ToString().IsNullOrEmpty() == true) value = DateTime.MinValue;
 _DeliveryDate = System.Convert.ToDateTime(value);return;
}
if (name == "DELIVERYWAY")
{
 _DeliveryWay = System.Convert.ToString(value);return;
}
if (name == "REVIEWRESULT")
{
 _ReviewResult = System.Convert.ToString(value);return;
}
if (name == "HANDLER")
{
 _Handler = System.Convert.ToString(value);return;
}
if (name == "HANDLERID")
{
 _HandlerId = XCode.Common.Helper.ConvertToGuid(value);return;
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
    /// 资格预审资料对象接口
    /// </summary>
    public partial interface IPS_Prequalification_DtlBO :  Power.Business.IBaseBusiness
    {
	      #region 属性 

	     /// <summary>
/// 主键
/// </summary>
System.Guid Id { get ; set ;}

/// <summary>
/// 外键
/// </summary>
System.Guid ParentId { get ; set ;}

/// <summary>
/// 序号
/// </summary>
System.Int32 Sequ { get ; set ;}

/// <summary>
/// 资料名称
/// </summary>
System.String DocumentName { get ; set ;}

/// <summary>
/// 递交日期
/// </summary>
System.DateTime DeliveryDate { get ; set ;}

/// <summary>
/// 提交方式
/// </summary>
System.String DeliveryWay { get ; set ;}

/// <summary>
/// 审查结果
/// </summary>
System.String ReviewResult { get ; set ;}

/// <summary>
/// 经办人
/// </summary>
System.String Handler { get ; set ;}

/// <summary>
/// 
/// </summary>
System.Guid HandlerId { get ; set ;}


      
		#endregion 
	}
}