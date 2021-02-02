 
 
 using    System;
 using System.Collections.Generic;
 using System.Text; 
 using XCode.Attributes    ;

 namespace  Power.Systems.StdSystem
{
    /// <summary>
    /// 人员调拨单子表
    /// </summary>
    public class PB_PersonnelAllocationListDO : PB_PersonnelAllocationListDO<PB_PersonnelAllocationListDO>
    {

    }

	/// <summary>
    /// 人员调拨单子表
    /// </summary>
	  [BindEntity(KeyWord="PB_PersonnelAllocationList",EntityType = typeof(Power.Systems.StdSystem.PB_PersonnelAllocationListDO),Description = "人员调拨单子表"  )] 

	 [BindTable( "PB_PersonnelAllocationList", Alias = "a",IsAttach=false,Description ="")]

	  [BindIndex(Name = "pk_PB_PersonnelAllocationList", KeyType = Power.DataAccessLayer.KeyType.MainKey, Columns = "Id", TableName = "PB_PersonnelAllocationList",Description="")]

    public   class PB_PersonnelAllocationListDO<TEntity> : XCode.Entity<TEntity>, XCode.IEntity where TEntity : Power.Systems.StdSystem.PB_PersonnelAllocationListDO<TEntity>, new()
    { 
	    #region 属性

	    
 private System.Guid _Id;
 /// <summary>
 /// 主健
 /// </summary>
 [BindColumn(1,"a", "Id", "主健","", "NCHAR", 16,0,false, IsPrimaryKey =true ,IsIdentity =true,IsNullable =false,  Length =16 )]
 public virtual System.Guid Id  { get { return _Id; } set { _Id = value; } }

 private System.String _HumCode;
 /// <summary>
 /// 人员编号
 /// </summary>
 [BindColumn(2,"a", "HumCode", "人员编号","", "NCHAR", 50,0,false, IsPrimaryKey =false ,IsIdentity =false,IsNullable =true,  Length =50 )]
 public  System.String HumCode  { get { return _HumCode; } set { _HumCode = value; } }

 private System.String _HumName;
 /// <summary>
 /// 人员姓名
 /// </summary>
 [BindColumn(3,"a", "HumName", "人员姓名","", "NCHAR", 80,0,false, IsPrimaryKey =false ,IsIdentity =false,IsNullable =true,  Length =80 )]
 public  System.String HumName  { get { return _HumName; } set { _HumName = value; } }

 private System.Guid _HumId;
 /// <summary>
 /// 人员主健
 /// </summary>
 [BindColumn(4,"a", "HumId", "人员主健","", "NCHAR", 16,0,false, IsPrimaryKey =false ,IsIdentity =false,IsNullable =true,  Length =16 )]
 public  System.Guid HumId  { get { return _HumId; } set { _HumId = value; } }

 private System.String _FromProject;
 /// <summary>
 /// 调离项目
 /// </summary>
 [BindColumn(5,"a", "FromProject", "调离项目","", "NCHAR", 50,0,false, IsPrimaryKey =false ,IsIdentity =false,IsNullable =true,  Length =50 )]
 public  System.String FromProject  { get { return _FromProject; } set { _FromProject = value; } }

 private System.String _ToProject;
 /// <summary>
 /// 调入项目
 /// </summary>
 [BindColumn(6,"a", "ToProject", "调入项目","", "NCHAR", 50,0,false, IsPrimaryKey =false ,IsIdentity =false,IsNullable =true,  Length =50 )]
 public  System.String ToProject  { get { return _ToProject; } set { _ToProject = value; } }

 private System.String _FromDeptName;
 /// <summary>
 /// 调离部门
 /// </summary>
 [BindColumn(7,"a", "FromDeptName", "调离部门","", "NCHAR", 50,0,false, IsPrimaryKey =false ,IsIdentity =false,IsNullable =true,  Length =50 )]
 public  System.String FromDeptName  { get { return _FromDeptName; } set { _FromDeptName = value; } }

 private System.Guid _FromDeptId;
 /// <summary>
 /// 调离部门主健
 /// </summary>
 [BindColumn(8,"a", "FromDeptId", "调离部门主健","", "NCHAR", 16,0,false, IsPrimaryKey =false ,IsIdentity =false,IsNullable =true,  Length =16 )]
 public  System.Guid FromDeptId  { get { return _FromDeptId; } set { _FromDeptId = value; } }

 private System.String _DeptName;
 /// <summary>
 /// 调离部门
 /// </summary>
 [BindColumn(9,"a", "DeptName", "调离部门","", "NCHAR", 50,0,false, IsPrimaryKey =false ,IsIdentity =false,IsNullable =true,  Length =50 )]
 public  System.String DeptName  { get { return _DeptName; } set { _DeptName = value; } }

 private System.Guid _DeptId;
 /// <summary>
 /// 调离部门主健
 /// </summary>
 [BindColumn(10,"a", "DeptId", "调离部门主健","", "NCHAR", 16,0,false, IsPrimaryKey =false ,IsIdentity =false,IsNullable =true,  Length =16 )]
 public  System.Guid DeptId  { get { return _DeptId; } set { _DeptId = value; } }

 private System.DateTime _TransferDate;
 /// <summary>
 /// 调拨日期
 /// </summary>
 [BindColumn(11,"a", "TransferDate", "调拨日期","", "NCHAR", 3,0,false, IsPrimaryKey =false ,IsIdentity =false,IsNullable =true,  Length =3 )]
 public  System.DateTime TransferDate  { get { return _TransferDate; } set { _TransferDate = value; } }

 private System.Guid _PersonnelAllocationId;
 /// <summary>
 /// 外键
 /// </summary>
 [BindColumn(12,"a", "PersonnelAllocationId", "外键","", "NCHAR", 16,0,false, IsPrimaryKey =false ,IsIdentity =false,IsNullable =true,  Length =16 )]
 public  System.Guid PersonnelAllocationId  { get { return _PersonnelAllocationId; } set { _PersonnelAllocationId = value; } }

 private System.Guid _ToProjectId;
 /// <summary>
 /// 调入项目ID
 /// </summary>
 [BindColumn(13,"a", "ToProjectId", "调入项目ID","", "NCHAR", 16,0,false, IsPrimaryKey =false ,IsIdentity =false,IsNullable =true,  Length =16 )]
 public  System.Guid ToProjectId  { get { return _ToProjectId; } set { _ToProjectId = value; } }

 private System.Guid _FromProjectId;
 /// <summary>
 /// 调离项目编号
 /// </summary>
 [BindColumn(14,"a", "FromProjectId", "调离项目编号","", "NCHAR", 16,0,false, IsPrimaryKey =false ,IsIdentity =false,IsNullable =true,  Length =16 )]
 public  System.Guid FromProjectId  { get { return _FromProjectId; } set { _FromProjectId = value; } }

 private System.Boolean _PrimaryInformation;
 /// <summary>
 /// 是否保留原有信息
 /// </summary>
 [BindColumn(15,"a", "PrimaryInformation", "是否保留原有信息","", "NCHAR", 1,0,false, IsPrimaryKey =false ,IsIdentity =false,IsNullable =true,  Length =1 )]
 public  System.Boolean PrimaryInformation  { get { return _PrimaryInformation; } set { _PrimaryInformation = value; } }

 private System.Int32 _AllocationType;
 /// <summary>
 /// 调拨类型：0临时调入，1正式调入
 /// </summary>
 [BindColumn(16,"a", "AllocationType", "调拨类型：0临时调入，1正式调入","", "NCHAR", 10,0,false, IsPrimaryKey =false ,IsIdentity =false,IsNullable =true,  Length =10 )]
 public  System.Int32 AllocationType  { get { return _AllocationType; } set { _AllocationType = value; } }

 private System.String _Reason;
 /// <summary>
 /// 调拨原因
 /// </summary>
 [BindColumn(16,"a", "Reason", "调拨原因","", "NCHAR", 1000,0,false, IsPrimaryKey =false ,IsIdentity =false,IsNullable =true,  Length =1000 )]
 public  System.String Reason  { get { return _Reason; } set { _Reason = value; } }

 private System.String _Remark;
 /// <summary>
 /// 备注
 /// </summary>
 [BindColumn(17,"a", "Remark", "备注","", "NCHAR", 1000,0,false, IsPrimaryKey =false ,IsIdentity =false,IsNullable =true,  Length =1000 )]
 public  System.String Remark  { get { return _Remark; } set { _Remark = value; } }

      
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
if (name == "HUMCODE")
{
return _HumCode;
}
if (name == "HUMNAME")
{
return _HumName;
}
if (name == "HUMID")
{
return _HumId;
}
if (name == "FROMPROJECT")
{
return _FromProject;
}
if (name == "TOPROJECT")
{
return _ToProject;
}
if (name == "FROMDEPTNAME")
{
return _FromDeptName;
}
if (name == "FROMDEPTID")
{
return _FromDeptId;
}
if (name == "DEPTNAME")
{
return _DeptName;
}
if (name == "DEPTID")
{
return _DeptId;
}
if (name == "TRANSFERDATE")
{
return _TransferDate;
}
if (name == "PERSONNELALLOCATIONID")
{
return _PersonnelAllocationId;
}
if (name == "TOPROJECTID")
{
return _ToProjectId;
}
if (name == "FROMPROJECTID")
{
return _FromProjectId;
}
if (name == "PRIMARYINFORMATION")
{
return _PrimaryInformation;
}
if (name == "ALLOCATIONTYPE")
{
return _AllocationType;
}
if (name == "REASON")
{
return _Reason;
}
if (name == "REMARK")
{
return _Remark;
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
if (name == "HUMCODE")
{
 _HumCode = System.Convert.ToString(value);return;
}
if (name == "HUMNAME")
{
 _HumName = System.Convert.ToString(value);return;
}
if (name == "HUMID")
{
 _HumId = XCode.Common.Helper.ConvertToGuid(value);return;
}
if (name == "FROMPROJECT")
{
 _FromProject = System.Convert.ToString(value);return;
}
if (name == "TOPROJECT")
{
 _ToProject = System.Convert.ToString(value);return;
}
if (name == "FROMDEPTNAME")
{
 _FromDeptName = System.Convert.ToString(value);return;
}
if (name == "FROMDEPTID")
{
 _FromDeptId = XCode.Common.Helper.ConvertToGuid(value);return;
}
if (name == "DEPTNAME")
{
 _DeptName = System.Convert.ToString(value);return;
}
if (name == "DEPTID")
{
 _DeptId = XCode.Common.Helper.ConvertToGuid(value);return;
}
if (name == "TRANSFERDATE")
{
 if (value == null || value.ToString().IsNullOrEmpty() == true) value = DateTime.MinValue;
 _TransferDate = System.Convert.ToDateTime(value);return;
}
if (name == "PERSONNELALLOCATIONID")
{
 _PersonnelAllocationId = XCode.Common.Helper.ConvertToGuid(value);return;
}
if (name == "TOPROJECTID")
{
 _ToProjectId = XCode.Common.Helper.ConvertToGuid(value);return;
}
if (name == "FROMPROJECTID")
{
 _FromProjectId = XCode.Common.Helper.ConvertToGuid(value);return;
}
if (name == "PRIMARYINFORMATION")
{
 _PrimaryInformation = System.Convert.ToBoolean(value);return;
}
if (name == "ALLOCATIONTYPE")
{
 _AllocationType = System.Convert.ToInt32(value);return;
}
if (name == "REASON")
{
 _Reason = System.Convert.ToString(value);return;
}
if (name == "REMARK")
{
 _Remark = System.Convert.ToString(value);return;
}

			    base[name] = value;
			}
		}
		#endregion
	}
}