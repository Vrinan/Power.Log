 
 

 using System;
 using System.Collections;
 using System.Collections.Generic;
 using System.Text; 
 using Power.Business.Attributes;
 using Power.Business;

 namespace  Power.Systems.StdMarket.StdMarket
{  
    /// <summary>
    /// 项目风险评估详情
    /// </summary>
    [BindBusinessObject(KeyWord="PS_RiskReview_Dtl",EntityType = typeof(Power.Systems.StdMarket.StdMarket.PS_RiskReview_DtlDO),BusinessType=Power.Business.Attributes.EBusinessType.Sub ,Description = "项目风险评估详情" )] 
    public partial  class PS_RiskReview_DtlBO : PS_RiskReview_DtlBO<PS_RiskReview_DtlBO >
    {

    }

	/// <summary>
    /// 项目风险评估详情
    /// </summary>  
	public    partial class PS_RiskReview_DtlBO<TBusiness> : Power.Business.BaseBusiness<TBusiness>, Power.Systems.StdMarket.IStdMarket.IPS_RiskReview_DtlBO 
        where TBusiness : Power.Systems.StdMarket.IStdMarket.IPS_RiskReview_DtlBO, new()
		
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

private  System.Guid _MasterId;
/// <summary>
/// 
/// </summary>
[BindProperty(Description = "")]
public System.Guid MasterId { get { return _MasterId; } set { _MasterId = value; }  }

private  System.Int32 _Sequ;
/// <summary>
/// 序号
/// </summary>
[BindProperty(Description = "序号")]
[BindPropertyUse(PropertyUse = Power.Business.Attributes.EBusinessPropertyUse.SequField )]
public System.Int32 Sequ { get { return _Sequ; } set { _Sequ = value; }  }

private  System.String _RiskClass;
/// <summary>
/// 风险类别
/// </summary>
[BindProperty(Description = "风险类别")]
public System.String RiskClass { get { return _RiskClass; } set { _RiskClass = value; }  }

private  System.String _RiskName;
/// <summary>
/// 风险名称
/// </summary>
[BindProperty(Description = "风险名称")]
public System.String RiskName { get { return _RiskName; } set { _RiskName = value; }  }

private  System.String _RiskLevel;
/// <summary>
/// 风险等级
/// </summary>
[BindProperty(Description = "风险等级")]
public System.String RiskLevel { get { return _RiskLevel; } set { _RiskLevel = value; }  }

private  System.Double _probability;
/// <summary>
/// 发生概率
/// </summary>
[BindProperty(Description = "发生概率")]
public System.Double probability { get { return _probability; } set { _probability = value; }  }

private  System.String _PossibleAffection;
/// <summary>
/// 可能影响
/// </summary>
[BindProperty(Description = "可能影响")]
public System.String PossibleAffection { get { return _PossibleAffection; } set { _PossibleAffection = value; }  }

private  System.String _PossiblePhase;
/// <summary>
/// 发生阶段
/// </summary>
[BindProperty(Description = "发生阶段")]
public System.String PossiblePhase { get { return _PossiblePhase; } set { _PossiblePhase = value; }  }

private  System.String _HandingMethod;
/// <summary>
/// 控制措施
/// </summary>
[BindProperty(Description = "控制措施")]
public System.String HandingMethod { get { return _HandingMethod; } set { _HandingMethod = value; }  }


      
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
if (name == "MASTERID")
{
return _MasterId;
}
if (name == "SEQU")
{
return _Sequ;
}
if (name == "RISKCLASS")
{
return _RiskClass;
}
if (name == "RISKNAME")
{
return _RiskName;
}
if (name == "RISKLEVEL")
{
return _RiskLevel;
}
if (name == "PROBABILITY")
{
return _probability;
}
if (name == "POSSIBLEAFFECTION")
{
return _PossibleAffection;
}
if (name == "POSSIBLEPHASE")
{
return _PossiblePhase;
}
if (name == "HANDINGMETHOD")
{
return _HandingMethod;
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
if (name == "MASTERID")
{
 _MasterId = XCode.Common.Helper.ConvertToGuid(value);return;
}
if (name == "SEQU")
{
 _Sequ = System.Convert.ToInt32(value);return;
}
if (name == "RISKCLASS")
{
 _RiskClass = System.Convert.ToString(value);return;
}
if (name == "RISKNAME")
{
 _RiskName = System.Convert.ToString(value);return;
}
if (name == "RISKLEVEL")
{
 _RiskLevel = System.Convert.ToString(value);return;
}
if (name == "PROBABILITY")
{
 _probability = System.Convert.ToDouble(value);return;
}
if (name == "POSSIBLEAFFECTION")
{
 _PossibleAffection = System.Convert.ToString(value);return;
}
if (name == "POSSIBLEPHASE")
{
 _PossiblePhase = System.Convert.ToString(value);return;
}
if (name == "HANDINGMETHOD")
{
 _HandingMethod = System.Convert.ToString(value);return;
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
    /// 项目风险评估详情对象接口
    /// </summary>
    public partial interface IPS_RiskReview_DtlBO :  Power.Business.IBaseBusiness
    {
	      #region 属性 

	     /// <summary>
/// 
/// </summary>
System.Guid Id { get ; set ;}

/// <summary>
/// 
/// </summary>
System.Guid MasterId { get ; set ;}

/// <summary>
/// 序号
/// </summary>
System.Int32 Sequ { get ; set ;}

/// <summary>
/// 风险类别
/// </summary>
System.String RiskClass { get ; set ;}

/// <summary>
/// 风险名称
/// </summary>
System.String RiskName { get ; set ;}

/// <summary>
/// 风险等级
/// </summary>
System.String RiskLevel { get ; set ;}

/// <summary>
/// 发生概率
/// </summary>
System.Double probability { get ; set ;}

/// <summary>
/// 可能影响
/// </summary>
System.String PossibleAffection { get ; set ;}

/// <summary>
/// 发生阶段
/// </summary>
System.String PossiblePhase { get ; set ;}

/// <summary>
/// 控制措施
/// </summary>
System.String HandingMethod { get ; set ;}


      
		#endregion 
	}
}