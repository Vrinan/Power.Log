 
 

 using System;
 using System.Collections;
 using System.Collections.Generic;
 using System.Text; 
 using Power.Business.Attributes;
 using Power.Business;

 namespace  Power.Systems.StdMarket.StdMarket
{  
    /// <summary>
    /// 参与投标单位
    /// </summary>
    [BindBusinessObject(KeyWord="PS_BidTrack_Dtl",EntityType = typeof(Power.Systems.StdMarket.StdMarket.PS_BidTrack_DtlDO),BusinessType=Power.Business.Attributes.EBusinessType.Sub ,Description = "参与投标单位" )] 
    public partial  class PS_BidTrack_DtlBO : PS_BidTrack_DtlBO<PS_BidTrack_DtlBO >
    {

    }

	/// <summary>
    /// 参与投标单位
    /// </summary>  
	public    partial class PS_BidTrack_DtlBO<TBusiness> : Power.Business.BaseBusiness<TBusiness>, Power.Systems.StdMarket.IStdMarket.IPS_BidTrack_DtlBO 
        where TBusiness : Power.Systems.StdMarket.IStdMarket.IPS_BidTrack_DtlBO, new()
		
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

private  System.String _Tenderer;
/// <summary>
/// 投标单位
/// </summary>
[BindProperty(Description = "投标单位")]
public System.String Tenderer { get { return _Tenderer; } set { _Tenderer = value; }  }

private  System.Guid _TendererId;
/// <summary>
/// 投标单位Id
/// </summary>
[BindProperty(Description = "投标单位Id")]
public System.Guid TendererId { get { return _TendererId; } set { _TendererId = value; }  }

private  System.Double _Offer;
/// <summary>
/// 报价
/// </summary>
[BindProperty(Description = "报价")]
public System.Double Offer { get { return _Offer; } set { _Offer = value; }  }

private  System.Int32 _isWin;
/// <summary>
/// 是否中标
/// </summary>
[BindProperty(Description = "是否中标")]
public System.Int32 isWin { get { return _isWin; } set { _isWin = value; }  }


      
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
if (name == "TENDERER")
{
return _Tenderer;
}
if (name == "TENDERERID")
{
return _TendererId;
}
if (name == "OFFER")
{
return _Offer;
}
if (name == "ISWIN")
{
return _isWin;
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
if (name == "TENDERER")
{
 _Tenderer = System.Convert.ToString(value);return;
}
if (name == "TENDERERID")
{
 _TendererId = XCode.Common.Helper.ConvertToGuid(value);return;
}
if (name == "OFFER")
{
 _Offer = System.Convert.ToDouble(value);return;
}
if (name == "ISWIN")
{
 _isWin = System.Convert.ToInt32(value);return;
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
    /// 参与投标单位对象接口
    /// </summary>
    public partial interface IPS_BidTrack_DtlBO :  Power.Business.IBaseBusiness
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
/// 投标单位
/// </summary>
System.String Tenderer { get ; set ;}

/// <summary>
/// 投标单位Id
/// </summary>
System.Guid TendererId { get ; set ;}

/// <summary>
/// 报价
/// </summary>
System.Double Offer { get ; set ;}

/// <summary>
/// 是否中标
/// </summary>
System.Int32 isWin { get ; set ;}


      
		#endregion 
	}
}