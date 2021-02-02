 
 
 using    System;
 using System.Collections.Generic;
 using System.Text; 
 using XCode.Attributes    ;

 namespace  Power.Systems.StdSystem
{
    /// <summary>
    /// 方法定义明细
    /// </summary>
    public class DistributeManagerListDO : DistributeManagerListDO<DistributeManagerListDO>
    {

    }

	/// <summary>
    /// 方法定义明细
    /// </summary>
	  [BindEntity(KeyWord="DistributeManagerList",EntityType = typeof(Power.Systems.StdSystem.DistributeManagerListDO),Description = "方法定义明细"  )] 

	 [BindTable( "PB_DistributeManagerList", Alias = "a",IsAttach=false,Description ="")]

	  [BindIndex(Name = "pk_PB_DistributeManagerList", KeyType = Power.DataAccessLayer.KeyType.MainKey, Columns = "Id", TableName = "PB_DistributeManagerList",Description="")]

    public   class DistributeManagerListDO<TEntity> : XCode.Entity<TEntity>, XCode.IEntity where TEntity : Power.Systems.StdSystem.DistributeManagerListDO<TEntity>, new()
    { 
	    #region 属性

	    
 private System.Guid _Id;
 /// <summary>
 /// 主键
 /// </summary>
 [BindColumn(1,"a", "Id", "主键","", "NCHAR", 16,0,false, IsPrimaryKey =true ,IsIdentity =true,IsNullable =false,  Length =16 )]
 public virtual System.Guid Id  { get { return _Id; } set { _Id = value; } }

 private System.Guid _ManagerId;
 /// <summary>
 /// 外键
 /// </summary>
 [BindColumn(2,"a", "ManagerId", "外键","", "NCHAR", 16,0,false, IsPrimaryKey =false ,IsIdentity =false,IsNullable =false,  Length =16 )]
 public  System.Guid ManagerId  { get { return _ManagerId; } set { _ManagerId = value; } }

 private System.Guid _HumanId;
 /// <summary>
 /// 人员id
 /// </summary>
 [BindColumn(3,"a", "HumanId", "人员id","", "NCHAR", 16,0,false, IsPrimaryKey =false ,IsIdentity =false,IsNullable =false,  Length =16 )]
 public  System.Guid HumanId  { get { return _HumanId; } set { _HumanId = value; } }

 private System.String _HumanCode;
 /// <summary>
 /// 人员编号
 /// </summary>
 [BindColumn(4,"a", "HumanCode", "人员编号","", "NCHAR", 200,0,false, IsPrimaryKey =false ,IsIdentity =false,IsNullable =true,  Length =200 )]
 public  System.String HumanCode  { get { return _HumanCode; } set { _HumanCode = value; } }

 private System.String _HumanName;
 /// <summary>
 /// 人员名称
 /// </summary>
 [BindColumn(5,"a", "HumanName", "人员名称","", "NCHAR", 200,0,false, IsPrimaryKey =false ,IsIdentity =false,IsNullable =true,  Length =200 )]
 public  System.String HumanName  { get { return _HumanName; } set { _HumanName = value; } }

 private System.String _Remark;
 /// <summary>
 /// 备注
 /// </summary>
 [BindColumn(6,"a", "Remark", "备注","", "NCHAR", 1000,0,false, IsPrimaryKey =false ,IsIdentity =false,IsNullable =true,  Length =1000 )]
 public  System.String Remark  { get { return _Remark; } set { _Remark = value; } }

 private System.DateTime _UpdDate;
 /// <summary>
 /// 最后更新时间
 /// </summary>
 [BindColumn(7,"a", "UpdDate", "最后更新时间","", "NCHAR", 3,0,false, IsPrimaryKey =false ,IsIdentity =false,IsNullable =true,  Length =3 )]
 public  System.DateTime UpdDate  { get { return _UpdDate; } set { _UpdDate = value; } }

      
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
if (name == "MANAGERID")
{
return _ManagerId;
}
if (name == "HUMANID")
{
return _HumanId;
}
if (name == "HUMANCODE")
{
return _HumanCode;
}
if (name == "HUMANNAME")
{
return _HumanName;
}
if (name == "REMARK")
{
return _Remark;
}
if (name == "UPDDATE")
{
return _UpdDate;
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
if (name == "MANAGERID")
{
 _ManagerId = XCode.Common.Helper.ConvertToGuid(value);return;
}
if (name == "HUMANID")
{
 _HumanId = XCode.Common.Helper.ConvertToGuid(value);return;
}
if (name == "HUMANCODE")
{
 _HumanCode = System.Convert.ToString(value);return;
}
if (name == "HUMANNAME")
{
 _HumanName = System.Convert.ToString(value);return;
}
if (name == "REMARK")
{
 _Remark = System.Convert.ToString(value);return;
}
if (name == "UPDDATE")
{
 if (value == null || value.ToString().IsNullOrEmpty() == true) value = DateTime.MinValue;
 _UpdDate = System.Convert.ToDateTime(value);return;
}

			    base[name] = value;
			}
		}
		#endregion
	}
}