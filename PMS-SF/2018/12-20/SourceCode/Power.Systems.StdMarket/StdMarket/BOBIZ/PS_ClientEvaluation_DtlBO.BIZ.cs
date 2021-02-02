 
 

 using System;
 using System.Collections;
 using System.Collections.Generic;
 using System.Text; 
 using Power.Business.Attributes;
 using Power.Business;

 namespace  Power.Systems.StdMarket.StdMarket
{  
    /// <summary>
    /// 客户评价子表
    /// </summary>
    [BindBusinessObject(KeyWord="PS_ClientEvaluation_Dtl",EntityType = typeof(Power.Systems.StdMarket.StdMarket.PS_ClientEvaluation_DtlDO),BusinessType=Power.Business.Attributes.EBusinessType.Sub ,Description = "客户评价子表" )] 
    public partial  class PS_ClientEvaluation_DtlBO : PS_ClientEvaluation_DtlBO<PS_ClientEvaluation_DtlBO >
    {

    }

	/// <summary>
    /// 客户评价子表
    /// </summary>  
	public    partial class PS_ClientEvaluation_DtlBO<TBusiness> : Power.Business.BaseBusiness<TBusiness>, Power.Systems.StdMarket.IStdMarket.IPS_ClientEvaluation_DtlBO 
        where TBusiness : Power.Systems.StdMarket.IStdMarket.IPS_ClientEvaluation_DtlBO, new()
		
    { 

	    #region 下辖业务对象
           
		#endregion 

	    #region 属性 

	 private  System.String _EvaluationCode;
/// <summary>
/// 编号
/// </summary>
[BindProperty(Description = "编号")]
public System.String EvaluationCode { get { return _EvaluationCode; } set { _EvaluationCode = value; }  }

private  System.String _EvaluationStandard;
/// <summary>
/// 评价标准
/// </summary>
[BindProperty(Description = "评价标准")]
public System.String EvaluationStandard { get { return _EvaluationStandard; } set { _EvaluationStandard = value; }  }

private  System.Decimal _FullScore;
/// <summary>
/// 总分
/// </summary>
[BindProperty(Description = "总分")]
public System.Decimal FullScore { get { return _FullScore; } set { _FullScore = value; }  }

private  System.Guid _MasterId;
/// <summary>
/// 
/// </summary>
[BindProperty(Description = "")]
public System.Guid MasterId { get { return _MasterId; } set { _MasterId = value; }  }

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

private  System.String _Sequ;
/// <summary>
/// 序号
/// </summary>
[BindProperty(Description = "序号")]
[BindPropertyUse(PropertyUse = Power.Business.Attributes.EBusinessPropertyUse.SequField )]
public System.String Sequ { get { return _Sequ; } set { _Sequ = value; }  }

private  System.String _EvaluationItem;
/// <summary>
/// 评价项目
/// </summary>
[BindProperty(Description = "评价项目")]
public System.String EvaluationItem { get { return _EvaluationItem; } set { _EvaluationItem = value; }  }

private  System.Double _EvaluationScore;
/// <summary>
/// 得分
/// </summary>
[BindProperty(Description = "得分")]
public System.Double EvaluationScore { get { return _EvaluationScore; } set { _EvaluationScore = value; }  }

private  System.String _EvaluationLevel;
/// <summary>
/// 评价等级
/// </summary>
[BindProperty(Description = "评价等级")]
public System.String EvaluationLevel { get { return _EvaluationLevel; } set { _EvaluationLevel = value; }  }


      
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
			    if (name == "EVALUATIONCODE")
{
return _EvaluationCode;
}
if (name == "EVALUATIONSTANDARD")
{
return _EvaluationStandard;
}
if (name == "FULLSCORE")
{
return _FullScore;
}
if (name == "MASTERID")
{
return _MasterId;
}
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
if (name == "EVALUATIONITEM")
{
return _EvaluationItem;
}
if (name == "EVALUATIONSCORE")
{
return _EvaluationScore;
}
if (name == "EVALUATIONLEVEL")
{
return _EvaluationLevel;
}


				
			    return base[name];
			}
			set 
			{
			   name = name.ToUpper();
			       if (name == "EVALUATIONCODE")
{
 _EvaluationCode = System.Convert.ToString(value);return;
}
if (name == "EVALUATIONSTANDARD")
{
 _EvaluationStandard = System.Convert.ToString(value);return;
}
if (name == "FULLSCORE")
{
 _FullScore = System.Convert.ToDecimal(value);return;
}
if (name == "MASTERID")
{
 _MasterId = XCode.Common.Helper.ConvertToGuid(value);return;
}
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
 _Sequ = System.Convert.ToString(value);return;
}
if (name == "EVALUATIONITEM")
{
 _EvaluationItem = System.Convert.ToString(value);return;
}
if (name == "EVALUATIONSCORE")
{
 _EvaluationScore = System.Convert.ToDouble(value);return;
}
if (name == "EVALUATIONLEVEL")
{
 _EvaluationLevel = System.Convert.ToString(value);return;
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
    /// 客户评价子表对象接口
    /// </summary>
    public partial interface IPS_ClientEvaluation_DtlBO :  Power.Business.IBaseBusiness
    {
	      #region 属性 

	     /// <summary>
/// 编号
/// </summary>
System.String EvaluationCode { get ; set ;}

/// <summary>
/// 评价标准
/// </summary>
System.String EvaluationStandard { get ; set ;}

/// <summary>
/// 总分
/// </summary>
System.Decimal FullScore { get ; set ;}

/// <summary>
/// 
/// </summary>
System.Guid MasterId { get ; set ;}

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
System.String Sequ { get ; set ;}

/// <summary>
/// 评价项目
/// </summary>
System.String EvaluationItem { get ; set ;}

/// <summary>
/// 得分
/// </summary>
System.Double EvaluationScore { get ; set ;}

/// <summary>
/// 评价等级
/// </summary>
System.String EvaluationLevel { get ; set ;}


      
		#endregion 
	}
}