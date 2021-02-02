 
 

 using System;
 using System.Collections;
 using System.Collections.Generic;
 using System.Text; 
 using Power.Business.Attributes;
 using Power.Business;

 namespace  Power.Systems.StdMarket.StdMarket
{  
    /// <summary>
    /// 投标任务分配
    /// </summary>
    [BindBusinessObject(KeyWord="PS_BidTask_Dtl",EntityType = typeof(Power.Systems.StdMarket.StdMarket.PS_BidTask_DtlDO),BusinessType=Power.Business.Attributes.EBusinessType.Sub ,Description = "投标任务分配" )] 
    public partial  class PS_BidTask_DtlBO : PS_BidTask_DtlBO<PS_BidTask_DtlBO >
    {

    }

	/// <summary>
    /// 投标任务分配
    /// </summary>  
	public    partial class PS_BidTask_DtlBO<TBusiness> : Power.Business.BaseBusiness<TBusiness>, Power.Systems.StdMarket.IStdMarket.IPS_BidTask_DtlBO 
        where TBusiness : Power.Systems.StdMarket.IStdMarket.IPS_BidTask_DtlBO, new()
		
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

private  System.String _TaskName;
/// <summary>
/// 任务名称
/// </summary>
[BindProperty(Description = "任务名称")]
public System.String TaskName { get { return _TaskName; } set { _TaskName = value; }  }

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

private  System.DateTime _PlanEndDate;
/// <summary>
/// 要求完成日期
/// </summary>
[BindProperty(Description = "要求完成日期")]
public System.DateTime PlanEndDate { get { return _PlanEndDate; } set { _PlanEndDate = value; }  }


      
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
if (name == "TASKNAME")
{
return _TaskName;
}
if (name == "RESPONSIBLEHUMAN")
{
return _ResponsibleHuman;
}
if (name == "RESPONSIBLEHUMANID")
{
return _ResponsibleHumanId;
}
if (name == "PLANENDDATE")
{
return _PlanEndDate;
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
if (name == "TASKNAME")
{
 _TaskName = System.Convert.ToString(value);return;
}
if (name == "RESPONSIBLEHUMAN")
{
 _ResponsibleHuman = System.Convert.ToString(value);return;
}
if (name == "RESPONSIBLEHUMANID")
{
 _ResponsibleHumanId = XCode.Common.Helper.ConvertToGuid(value);return;
}
if (name == "PLANENDDATE")
{
 if (value == null || value.ToString().IsNullOrEmpty() == true) value = DateTime.MinValue;
 _PlanEndDate = System.Convert.ToDateTime(value);return;
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
    /// 投标任务分配对象接口
    /// </summary>
    public partial interface IPS_BidTask_DtlBO :  Power.Business.IBaseBusiness
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
/// 任务名称
/// </summary>
System.String TaskName { get ; set ;}

/// <summary>
/// 责任人
/// </summary>
System.String ResponsibleHuman { get ; set ;}

/// <summary>
/// 责任人Id
/// </summary>
System.Guid ResponsibleHumanId { get ; set ;}

/// <summary>
/// 要求完成日期
/// </summary>
System.DateTime PlanEndDate { get ; set ;}


      
		#endregion 
	}
}