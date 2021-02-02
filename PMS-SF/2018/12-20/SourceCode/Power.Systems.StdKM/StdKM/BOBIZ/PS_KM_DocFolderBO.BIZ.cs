 
 

 using System;
 using System.Collections;
 using System.Collections.Generic;
 using System.Text; 
 using Power.Business.Attributes;
 using Power.Business;

 namespace  Power.Systems.StdKM.StdKM
{  
    /// <summary>
    /// 企业知识分类
    /// </summary>
    [BindBusinessObject(KeyWord="PS_KM_DocFolder",EntityType = typeof(Power.Systems.StdKM.StdKM.PS_KM_DocFolderDO),BusinessType=Power.Business.Attributes.EBusinessType.Main ,Description = "企业知识分类" )] 
    public partial  class PS_KM_DocFolderBO : PS_KM_DocFolderBO<PS_KM_DocFolderBO >
    {

    }

	/// <summary>
    /// 企业知识分类
    /// </summary>  
	public    partial class PS_KM_DocFolderBO<TBusiness> : Power.Business.BaseBusiness<TBusiness>, Power.Systems.StdKM.IStdKM.IPS_KM_DocFolderBO 
        where TBusiness : Power.Systems.StdKM.IStdKM.IPS_KM_DocFolderBO, new()
		
    { 

	    #region 下辖业务对象
           
		#endregion 

	    #region 属性 

	 private  System.DateTime _ApprDate;
/// <summary>
/// 批准日期
/// </summary>
[BindProperty(Description = "批准日期")]
[BindPropertyUse(PropertyUse = Power.Business.Attributes.EBusinessPropertyUse.FlowFinishDate )]
public System.DateTime ApprDate { get { return _ApprDate; } set { _ApprDate = value; }  }

private  System.Guid _ApprHumId;
/// <summary>
/// 批准人Id
/// </summary>
[BindProperty(Description = "批准人Id")]
[BindPropertyUse(PropertyUse = Power.Business.Attributes.EBusinessPropertyUse.FlowFinishHumanID )]
public System.Guid ApprHumId { get { return _ApprHumId; } set { _ApprHumId = value; }  }

private  System.String _ApprHumName;
/// <summary>
/// 批准人名称
/// </summary>
[BindProperty(Description = "批准人名称")]
[BindPropertyUse(PropertyUse = Power.Business.Attributes.EBusinessPropertyUse.FlowFinishHumanName )]
public System.String ApprHumName { get { return _ApprHumName; } set { _ApprHumName = value; }  }

private  System.Guid _BizAreaId;
/// <summary>
/// 数据录入业务域Id
/// </summary>
[BindProperty(Description = "数据录入业务域Id")]
[BindPropertySession(PropertyAssignment = Power.Business.Attributes.EBusinessPropertyAssignment.BizAreaId,  SessionName = "BizAreaId",   IsNull = false, IsAllowNoExist = false)]
public System.Guid BizAreaId { get { return _BizAreaId; } set { _BizAreaId = value; }  }

private  System.Guid _DefaultFieldId;
/// <summary>
/// 对应业务记录Id
/// </summary>
[BindProperty(Description = "对应业务记录Id")]
[BindPropertyUse(PropertyUse = Power.Business.Attributes.EBusinessPropertyUse.PrimaryKey )]
public System.Guid DefaultFieldId { get { return _DefaultFieldId; } set { _DefaultFieldId = value; }  }

private  System.Guid _EpsProjId;
/// <summary>
/// 记录所属EPS节点Id
/// </summary>
[BindProperty(Description = "记录所属EPS节点Id")]
[BindPropertySession(PropertyAssignment = Power.Business.Attributes.EBusinessPropertyAssignment.EpsProjId,  SessionName = "EpsProjId",   IsNull = false, IsAllowNoExist = false)]
public System.Guid EpsProjId { get { return _EpsProjId; } set { _EpsProjId = value; }  }

private  System.Guid _RecycleHumId;
/// <summary>
/// 删除人Id
/// </summary>
[BindProperty(Description = "删除人Id")]
[BindPropertySession(PropertyAssignment = Power.Business.Attributes.EBusinessPropertyAssignment.RecycleHumId,  SessionName = "RecycleHumId",   IsNull = false, IsAllowNoExist = false)]
public System.Guid RecycleHumId { get { return _RecycleHumId; } set { _RecycleHumId = value; }  }

private  System.DateTime _RegDate;
/// <summary>
/// 录入日期
/// </summary>
[BindProperty(Description = "录入日期")]
[BindPropertySession(PropertyAssignment = Power.Business.Attributes.EBusinessPropertyAssignment.RegDate,  SessionName = "RegDate",   IsNull = false, IsAllowNoExist = false)]
public System.DateTime RegDate { get { return _RegDate; } set { _RegDate = value; }  }

private  System.Guid _RegDeptId;
/// <summary>
/// 录入人部门Id
/// </summary>
[BindProperty(Description = "录入人部门Id")]
[BindPropertySession(PropertyAssignment = Power.Business.Attributes.EBusinessPropertyAssignment.RegDeptId,  SessionName = "RegDeptId",   IsNull = false, IsAllowNoExist = false)]
public System.Guid RegDeptId { get { return _RegDeptId; } set { _RegDeptId = value; }  }

private  System.Guid _RegHumId;
/// <summary>
/// 录入人Id
/// </summary>
[BindProperty(Description = "录入人Id")]
[BindPropertySession(PropertyAssignment = Power.Business.Attributes.EBusinessPropertyAssignment.RegHumId,  SessionName = "RegHumId",   IsNull = false, IsAllowNoExist = false)]
public System.Guid RegHumId { get { return _RegHumId; } set { _RegHumId = value; }  }

private  System.String _RegHumName;
/// <summary>
/// 录入人名称
/// </summary>
[BindProperty(Description = "录入人名称")]
[BindPropertySession(PropertyAssignment = Power.Business.Attributes.EBusinessPropertyAssignment.RegHumName,  SessionName = "RegHumName",   IsNull = false, IsAllowNoExist = false)]
public System.String RegHumName { get { return _RegHumName; } set { _RegHumName = value; }  }

private  System.Guid _RegPosiId;
/// <summary>
/// 录入人岗位Id
/// </summary>
[BindProperty(Description = "录入人岗位Id")]
[BindPropertySession(PropertyAssignment = Power.Business.Attributes.EBusinessPropertyAssignment.RegPosiId,  SessionName = "RegPosiId",   IsNull = false, IsAllowNoExist = false)]
public System.Guid RegPosiId { get { return _RegPosiId; } set { _RegPosiId = value; }  }

private  System.Int32 _Sequ;
/// <summary>
/// 序号
/// </summary>
[BindProperty(Description = "序号")]
[BindPropertyUse(PropertyUse = Power.Business.Attributes.EBusinessPropertyUse.SequField )]
public System.Int32 Sequ { get { return _Sequ; } set { _Sequ = value; }  }

private  System.SByte _Status;
/// <summary>
/// 表单状态；0新增，20审批中，35生效，40终止，50批准
/// </summary>
[BindProperty(Description = "表单状态；0新增，20审批中，35生效，40终止，50批准")]
[BindPropertyUse(PropertyUse = Power.Business.Attributes.EBusinessPropertyUse.FlowStatus )]
public System.SByte Status { get { return _Status; } set { _Status = value; }  }

private  System.String _TableName;
/// <summary>
/// 数据所属表名
/// </summary>
[BindProperty(Description = "数据所属表名")]
[BindPropertySession(PropertyAssignment = Power.Business.Attributes.EBusinessPropertyAssignment.TableName,  SessionName = "TableName",   IsNull = false, IsAllowNoExist = false)]
public System.String TableName { get { return _TableName; } set { _TableName = value; }  }

private  System.DateTime _UpdDate;
/// <summary>
/// 最后更新日期
/// </summary>
[BindProperty(Description = "最后更新日期")]
[BindPropertySession(PropertyAssignment = Power.Business.Attributes.EBusinessPropertyAssignment.UpdDate,  SessionName = "UpdDate",   IsNull = false, IsAllowNoExist = false)]
public System.DateTime UpdDate { get { return _UpdDate; } set { _UpdDate = value; }  }

private  System.Guid _UpdHumId;
/// <summary>
/// 最后更新人Id
/// </summary>
[BindProperty(Description = "最后更新人Id")]
[BindPropertySession(PropertyAssignment = Power.Business.Attributes.EBusinessPropertyAssignment.UpdHumId,  SessionName = "UpdHumId",   IsNull = false, IsAllowNoExist = false)]
public System.Guid UpdHumId { get { return _UpdHumId; } set { _UpdHumId = value; }  }

private  System.String _UpdHumName;
/// <summary>
/// 最后更新人名称
/// </summary>
[BindProperty(Description = "最后更新人名称")]
[BindPropertySession(PropertyAssignment = Power.Business.Attributes.EBusinessPropertyAssignment.UpdHumName,  SessionName = "UpdHumName",   IsNull = false, IsAllowNoExist = false)]
public System.String UpdHumName { get { return _UpdHumName; } set { _UpdHumName = value; }  }

private  System.String _Memo;
/// <summary>
/// 备注
/// </summary>
[BindProperty(Description = "备注")]
public System.String Memo { get { return _Memo; } set { _Memo = value; }  }

private  System.Guid _OwnProjId;
/// <summary>
/// 所属项目Id
/// </summary>
[BindProperty(Description = "所属项目Id")]
[BindPropertySession(PropertyAssignment = Power.Business.Attributes.EBusinessPropertyAssignment.OwnProjId,  SessionName = "OwnProjId",   IsNull = false, IsAllowNoExist = false)]
public System.Guid OwnProjId { get { return _OwnProjId; } set { _OwnProjId = value; }  }

private  System.String _OwnProjName;
/// <summary>
/// 所属项目名称
/// </summary>
[BindProperty(Description = "所属项目名称")]
[BindPropertySession(PropertyAssignment = Power.Business.Attributes.EBusinessPropertyAssignment.OwnProjName,  SessionName = "OwnProjName",   IsNull = false, IsAllowNoExist = false)]
public System.String OwnProjName { get { return _OwnProjName; } set { _OwnProjName = value; }  }

private  System.Guid _Id;
/// <summary>
/// 
/// </summary>
[BindProperty(Description = "")]
[BindPropertyUse(PropertyUse = Power.Business.Attributes.EBusinessPropertyUse.PrimaryKey )]
public System.Guid Id { get { return _Id; } set { _Id = value; }  }

private  System.Guid _ParentId;
/// <summary>
/// 
/// </summary>
[BindProperty(Description = "")]
[BindPropertyUse(PropertyUse = Power.Business.Attributes.EBusinessPropertyUse.ParentKey )]
public System.Guid ParentId { get { return _ParentId; } set { _ParentId = value; }  }

private  System.String _Code;
/// <summary>
/// 编号
/// </summary>
[BindProperty(Description = "编号")]
[BindPropertyUse(PropertyUse = Power.Business.Attributes.EBusinessPropertyUse.CodeField )]
public System.String Code { get { return _Code; } set { _Code = value; }  }

private  System.String _Name;
/// <summary>
/// 名称
/// </summary>
[BindProperty(Description = "名称")]
public System.String Name { get { return _Name; } set { _Name = value; }  }

private  System.String _LongCode;
/// <summary>
/// 
/// </summary>
[BindProperty(Description = "")]
[BindPropertyUse(PropertyUse = Power.Business.Attributes.EBusinessPropertyUse.LongCodeField )]
public System.String LongCode { get { return _LongCode; } set { _LongCode = value; }  }


      
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
			    if (name == "APPRDATE")
{
return _ApprDate;
}
if (name == "APPRHUMID")
{
return _ApprHumId;
}
if (name == "APPRHUMNAME")
{
return _ApprHumName;
}
if (name == "BIZAREAID")
{
return _BizAreaId;
}
if (name == "DEFAULTFIELDID")
{
return _DefaultFieldId;
}
if (name == "EPSPROJID")
{
return _EpsProjId;
}
if (name == "RECYCLEHUMID")
{
return _RecycleHumId;
}
if (name == "REGDATE")
{
return _RegDate;
}
if (name == "REGDEPTID")
{
return _RegDeptId;
}
if (name == "REGHUMID")
{
return _RegHumId;
}
if (name == "REGHUMNAME")
{
return _RegHumName;
}
if (name == "REGPOSIID")
{
return _RegPosiId;
}
if (name == "SEQU")
{
return _Sequ;
}
if (name == "STATUS")
{
return _Status;
}
if (name == "TABLENAME")
{
return _TableName;
}
if (name == "UPDDATE")
{
return _UpdDate;
}
if (name == "UPDHUMID")
{
return _UpdHumId;
}
if (name == "UPDHUMNAME")
{
return _UpdHumName;
}
if (name == "MEMO")
{
return _Memo;
}
if (name == "OWNPROJID")
{
return _OwnProjId;
}
if (name == "OWNPROJNAME")
{
return _OwnProjName;
}
if (name == "ID")
{
return _Id;
}
if (name == "PARENTID")
{
return _ParentId;
}
if (name == "CODE")
{
return _Code;
}
if (name == "NAME")
{
return _Name;
}
if (name == "LONGCODE")
{
return _LongCode;
}


				
			    return base[name];
			}
			set 
			{
			   name = name.ToUpper();
			       if (name == "APPRDATE")
{
 if (value == null || value.ToString().IsNullOrEmpty() == true) value = DateTime.MinValue;
 _ApprDate = System.Convert.ToDateTime(value);return;
}
if (name == "APPRHUMID")
{
 _ApprHumId = XCode.Common.Helper.ConvertToGuid(value);return;
}
if (name == "APPRHUMNAME")
{
 _ApprHumName = System.Convert.ToString(value);return;
}
if (name == "BIZAREAID")
{
 _BizAreaId = XCode.Common.Helper.ConvertToGuid(value);return;
}
if (name == "DEFAULTFIELDID")
{
 _DefaultFieldId = XCode.Common.Helper.ConvertToGuid(value);return;
}
if (name == "EPSPROJID")
{
 _EpsProjId = XCode.Common.Helper.ConvertToGuid(value);return;
}
if (name == "RECYCLEHUMID")
{
 _RecycleHumId = XCode.Common.Helper.ConvertToGuid(value);return;
}
if (name == "REGDATE")
{
 if (value == null || value.ToString().IsNullOrEmpty() == true) value = DateTime.MinValue;
 _RegDate = System.Convert.ToDateTime(value);return;
}
if (name == "REGDEPTID")
{
 _RegDeptId = XCode.Common.Helper.ConvertToGuid(value);return;
}
if (name == "REGHUMID")
{
 _RegHumId = XCode.Common.Helper.ConvertToGuid(value);return;
}
if (name == "REGHUMNAME")
{
 _RegHumName = System.Convert.ToString(value);return;
}
if (name == "REGPOSIID")
{
 _RegPosiId = XCode.Common.Helper.ConvertToGuid(value);return;
}
if (name == "SEQU")
{
 _Sequ = System.Convert.ToInt32(value);return;
}
if (name == "STATUS")
{
 _Status = System.Convert.ToSByte(value);return;
}
if (name == "TABLENAME")
{
 _TableName = System.Convert.ToString(value);return;
}
if (name == "UPDDATE")
{
 if (value == null || value.ToString().IsNullOrEmpty() == true) value = DateTime.MinValue;
 _UpdDate = System.Convert.ToDateTime(value);return;
}
if (name == "UPDHUMID")
{
 _UpdHumId = XCode.Common.Helper.ConvertToGuid(value);return;
}
if (name == "UPDHUMNAME")
{
 _UpdHumName = System.Convert.ToString(value);return;
}
if (name == "MEMO")
{
 _Memo = System.Convert.ToString(value);return;
}
if (name == "OWNPROJID")
{
 _OwnProjId = XCode.Common.Helper.ConvertToGuid(value);return;
}
if (name == "OWNPROJNAME")
{
 _OwnProjName = System.Convert.ToString(value);return;
}
if (name == "ID")
{
 _Id = XCode.Common.Helper.ConvertToGuid(value);return;
}
if (name == "PARENTID")
{
 _ParentId = XCode.Common.Helper.ConvertToGuid(value);return;
}
if (name == "CODE")
{
 _Code = System.Convert.ToString(value);return;
}
if (name == "NAME")
{
 _Name = System.Convert.ToString(value);return;
}
if (name == "LONGCODE")
{
 _LongCode = System.Convert.ToString(value);return;
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

 namespace  Power.Systems.StdKM.IStdKM
{  
	/// <summary>
    /// 企业知识分类对象接口
    /// </summary>
    public partial interface IPS_KM_DocFolderBO :  Power.Business.IBaseBusiness
    {
	      #region 属性 

	     /// <summary>
/// 批准日期
/// </summary>
System.DateTime ApprDate { get ; set ;}

/// <summary>
/// 批准人Id
/// </summary>
System.Guid ApprHumId { get ; set ;}

/// <summary>
/// 批准人名称
/// </summary>
System.String ApprHumName { get ; set ;}

/// <summary>
/// 数据录入业务域Id
/// </summary>
System.Guid BizAreaId { get ; set ;}

/// <summary>
/// 对应业务记录Id
/// </summary>
System.Guid DefaultFieldId { get ; set ;}

/// <summary>
/// 记录所属EPS节点Id
/// </summary>
System.Guid EpsProjId { get ; set ;}

/// <summary>
/// 删除人Id
/// </summary>
System.Guid RecycleHumId { get ; set ;}

/// <summary>
/// 录入日期
/// </summary>
System.DateTime RegDate { get ; set ;}

/// <summary>
/// 录入人部门Id
/// </summary>
System.Guid RegDeptId { get ; set ;}

/// <summary>
/// 录入人Id
/// </summary>
System.Guid RegHumId { get ; set ;}

/// <summary>
/// 录入人名称
/// </summary>
System.String RegHumName { get ; set ;}

/// <summary>
/// 录入人岗位Id
/// </summary>
System.Guid RegPosiId { get ; set ;}

/// <summary>
/// 序号
/// </summary>
System.Int32 Sequ { get ; set ;}

/// <summary>
/// 表单状态；0新增，20审批中，35生效，40终止，50批准
/// </summary>
System.SByte Status { get ; set ;}

/// <summary>
/// 数据所属表名
/// </summary>
System.String TableName { get ; set ;}

/// <summary>
/// 最后更新日期
/// </summary>
System.DateTime UpdDate { get ; set ;}

/// <summary>
/// 最后更新人Id
/// </summary>
System.Guid UpdHumId { get ; set ;}

/// <summary>
/// 最后更新人名称
/// </summary>
System.String UpdHumName { get ; set ;}

/// <summary>
/// 备注
/// </summary>
System.String Memo { get ; set ;}

/// <summary>
/// 所属项目Id
/// </summary>
System.Guid OwnProjId { get ; set ;}

/// <summary>
/// 所属项目名称
/// </summary>
System.String OwnProjName { get ; set ;}

/// <summary>
/// 
/// </summary>
System.Guid Id { get ; set ;}

/// <summary>
/// 
/// </summary>
System.Guid ParentId { get ; set ;}

/// <summary>
/// 编号
/// </summary>
System.String Code { get ; set ;}

/// <summary>
/// 名称
/// </summary>
System.String Name { get ; set ;}

/// <summary>
/// 
/// </summary>
System.String LongCode { get ; set ;}


      
		#endregion 
	}
}