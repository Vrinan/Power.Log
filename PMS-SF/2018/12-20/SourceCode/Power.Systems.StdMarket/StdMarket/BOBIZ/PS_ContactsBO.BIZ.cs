 
 

 using System;
 using System.Collections;
 using System.Collections.Generic;
 using System.Text; 
 using Power.Business.Attributes;
 using Power.Business;

 namespace  Power.Systems.StdMarket.StdMarket
{  
    /// <summary>
    /// 客户联系人
    /// </summary>
    [BindBusinessObject(KeyWord="PS_Contacts",EntityType = typeof(Power.Systems.StdMarket.StdMarket.PS_ContactsDO),BusinessType=Power.Business.Attributes.EBusinessType.Main ,Description = "客户联系人" )] 
    public partial  class PS_ContactsBO : PS_ContactsBO<PS_ContactsBO >
    {

    }

	/// <summary>
    /// 客户联系人
    /// </summary>  
	public    partial class PS_ContactsBO<TBusiness> : Power.Business.BaseBusiness<TBusiness>, Power.Systems.StdMarket.IStdMarket.IPS_ContactsBO 
        where TBusiness : Power.Systems.StdMarket.IStdMarket.IPS_ContactsBO, new()
		
    { 

	    #region 下辖业务对象
           
		#endregion 

	    #region 属性 

	 private  System.DateTime _Birthday;
/// <summary>
/// 
/// </summary>
[BindProperty(Description = "")]
public System.DateTime Birthday { get { return _Birthday; } set { _Birthday = value; }  }

private  System.String _ParentName;
/// <summary>
/// 客户名称
/// </summary>
[BindProperty(Description = "客户名称")]
public System.String ParentName { get { return _ParentName; } set { _ParentName = value; }  }

private  System.String _PlaceOfOrigin;
/// <summary>
/// 籍贯
/// </summary>
[BindProperty(Description = "籍贯")]
public System.String PlaceOfOrigin { get { return _PlaceOfOrigin; } set { _PlaceOfOrigin = value; }  }

private  System.DateTime _RegDate;
/// <summary>
/// 
/// </summary>
[BindProperty(Description = "")]
public System.DateTime RegDate { get { return _RegDate; } set { _RegDate = value; }  }

private  System.String _RegHumName;
/// <summary>
/// 
/// </summary>
[BindProperty(Description = "")]
public System.String RegHumName { get { return _RegHumName; } set { _RegHumName = value; }  }

private  System.Int32 _sex;
/// <summary>
/// 
/// </summary>
[BindProperty(Description = "")]
public System.Int32 sex { get { return _sex; } set { _sex = value; }  }

private  System.Int32 _Status;
/// <summary>
/// 
/// </summary>
[BindProperty(Description = "")]
[BindPropertyUse(PropertyUse = Power.Business.Attributes.EBusinessPropertyUse.FlowStatus )]
public System.Int32 Status { get { return _Status; } set { _Status = value; }  }

private  System.Guid _Id;
/// <summary>
/// 主键
/// </summary>
[BindProperty(Description = "主键")]
[BindPropertyUse(PropertyUse = Power.Business.Attributes.EBusinessPropertyUse.PrimaryKey )]
public System.Guid Id { get { return _Id; } set { _Id = value; }  }

private  System.Guid _PrentId;
/// <summary>
/// 外键
/// </summary>
[BindProperty(Description = "外键")]
public System.Guid PrentId { get { return _PrentId; } set { _PrentId = value; }  }

private  System.String _Sequ;
/// <summary>
/// 序号
/// </summary>
[BindProperty(Description = "序号")]
[BindPropertyUse(PropertyUse = Power.Business.Attributes.EBusinessPropertyUse.SequField )]
public System.String Sequ { get { return _Sequ; } set { _Sequ = value; }  }

private  System.String _Name;
/// <summary>
/// 姓名
/// </summary>
[BindProperty(Description = "姓名")]
public System.String Name { get { return _Name; } set { _Name = value; }  }

private  System.String _Position;
/// <summary>
/// 职务
/// </summary>
[BindProperty(Description = "职务")]
public System.String Position { get { return _Position; } set { _Position = value; }  }

private  System.String _Tel;
/// <summary>
/// 电话
/// </summary>
[BindProperty(Description = "电话")]
public System.String Tel { get { return _Tel; } set { _Tel = value; }  }

private  System.String _Fax;
/// <summary>
/// 传真
/// </summary>
[BindProperty(Description = "传真")]
public System.String Fax { get { return _Fax; } set { _Fax = value; }  }

private  System.String _Email;
/// <summary>
/// 邮箱
/// </summary>
[BindProperty(Description = "邮箱")]
public System.String Email { get { return _Email; } set { _Email = value; }  }

private  System.SByte _isAgent;
/// <summary>
/// 是否代理人
/// </summary>
[BindProperty(Description = "是否代理人")]
public System.SByte isAgent { get { return _isAgent; } set { _isAgent = value; }  }


      
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
			    if (name == "BIRTHDAY")
{
return _Birthday;
}
if (name == "PARENTNAME")
{
return _ParentName;
}
if (name == "PLACEOFORIGIN")
{
return _PlaceOfOrigin;
}
if (name == "REGDATE")
{
return _RegDate;
}
if (name == "REGHUMNAME")
{
return _RegHumName;
}
if (name == "SEX")
{
return _sex;
}
if (name == "STATUS")
{
return _Status;
}
if (name == "ID")
{
return _Id;
}
if (name == "PRENTID")
{
return _PrentId;
}
if (name == "SEQU")
{
return _Sequ;
}
if (name == "NAME")
{
return _Name;
}
if (name == "POSITION")
{
return _Position;
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
if (name == "ISAGENT")
{
return _isAgent;
}


				
			    return base[name];
			}
			set 
			{
			   name = name.ToUpper();
			       if (name == "BIRTHDAY")
{
 if (value == null || value.ToString().IsNullOrEmpty() == true) value = DateTime.MinValue;
 _Birthday = System.Convert.ToDateTime(value);return;
}
if (name == "PARENTNAME")
{
 _ParentName = System.Convert.ToString(value);return;
}
if (name == "PLACEOFORIGIN")
{
 _PlaceOfOrigin = System.Convert.ToString(value);return;
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
if (name == "SEX")
{
 _sex = System.Convert.ToInt32(value);return;
}
if (name == "STATUS")
{
 _Status = System.Convert.ToInt32(value);return;
}
if (name == "ID")
{
 _Id = XCode.Common.Helper.ConvertToGuid(value);return;
}
if (name == "PRENTID")
{
 _PrentId = XCode.Common.Helper.ConvertToGuid(value);return;
}
if (name == "SEQU")
{
 _Sequ = System.Convert.ToString(value);return;
}
if (name == "NAME")
{
 _Name = System.Convert.ToString(value);return;
}
if (name == "POSITION")
{
 _Position = System.Convert.ToString(value);return;
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
if (name == "ISAGENT")
{
 _isAgent = System.Convert.ToSByte(value);return;
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
    /// 客户联系人对象接口
    /// </summary>
    public partial interface IPS_ContactsBO :  Power.Business.IBaseBusiness
    {
	      #region 属性 

	     /// <summary>
/// 
/// </summary>
System.DateTime Birthday { get ; set ;}

/// <summary>
/// 客户名称
/// </summary>
System.String ParentName { get ; set ;}

/// <summary>
/// 籍贯
/// </summary>
System.String PlaceOfOrigin { get ; set ;}

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
System.Int32 sex { get ; set ;}

/// <summary>
/// 
/// </summary>
System.Int32 Status { get ; set ;}

/// <summary>
/// 主键
/// </summary>
System.Guid Id { get ; set ;}

/// <summary>
/// 外键
/// </summary>
System.Guid PrentId { get ; set ;}

/// <summary>
/// 序号
/// </summary>
System.String Sequ { get ; set ;}

/// <summary>
/// 姓名
/// </summary>
System.String Name { get ; set ;}

/// <summary>
/// 职务
/// </summary>
System.String Position { get ; set ;}

/// <summary>
/// 电话
/// </summary>
System.String Tel { get ; set ;}

/// <summary>
/// 传真
/// </summary>
System.String Fax { get ; set ;}

/// <summary>
/// 邮箱
/// </summary>
System.String Email { get ; set ;}

/// <summary>
/// 是否代理人
/// </summary>
System.SByte isAgent { get ; set ;}


      
		#endregion 
	}
}