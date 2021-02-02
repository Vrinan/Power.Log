 
 
 using    System;
 using System.Collections.Generic;
 using System.Text; 
 using XCode.Attributes    ;

 namespace  Power.Systems.Systems
{
    /// <summary>
    /// 报表子表DO
    /// </summary>
    public class ReportDataDO : ReportDataDO<ReportDataDO>
    {

    }

	/// <summary>
    /// 报表子表DO
    /// </summary>
	  [BindEntity(KeyWord="ReportData",EntityType = typeof(Power.Systems.Systems.ReportDataDO),Description = "报表子表DO"  )] 

	 [BindTable( "PB_ReportData", Alias = "a",IsAttach=false,Description ="")]

	  [BindIndex(Name = "pk_PB_ReportData", KeyType = Power.DataAccessLayer.KeyType.MainKey, Columns = "Id", TableName = "PB_ReportData",Description="")]

    public   class ReportDataDO<TEntity> : XCode.Entity<TEntity>, XCode.IEntity where TEntity : Power.Systems.Systems.ReportDataDO<TEntity>, new()
    { 
	    #region 属性

	    
 private System.Guid _Id;
 /// <summary>
 /// 报表子表主键
 /// </summary>
 [BindColumn(1,"a", "Id", "报表子表主键","", "NCHAR", 16,0,false, IsPrimaryKey =true ,IsIdentity =true,IsNullable =false,  Length =16 )]
 public virtual System.Guid Id  { get { return _Id; } set { _Id = value; } }

 private System.Guid _ReportId;
 /// <summary>
 /// 报表主表主键
 /// </summary>
 [BindColumn(2,"a", "ReportId", "报表主表主键","", "NCHAR", 16,0,false, IsPrimaryKey =false ,IsIdentity =false,IsNullable =true,  Length =16 )]
 public  System.Guid ReportId  { get { return _ReportId; } set { _ReportId = value; } }

 private System.String _Name;
 /// <summary>
 /// 数据源名称
 /// </summary>
 [BindColumn(3,"a", "Name", "数据源名称","", "NCHAR", 100,0,false, IsPrimaryKey =false ,IsIdentity =false,IsNullable =true,  Length =100 )]
 public  System.String Name  { get { return _Name; } set { _Name = value; } }

 private System.String _Sql;
 /// <summary>
 /// SQL语句输入
 /// </summary>
 [BindColumn(4,"a", "Sql", "SQL语句输入","", "NCHAR", 2147483647,0,false, IsPrimaryKey =false ,IsIdentity =false,IsNullable =true,  Length =2147483647 )]
 public  System.String Sql  { get { return _Sql; } set { _Sql = value; } }

 private System.String _Bo;
 /// <summary>
 /// BO对象选择
 /// </summary>
 [BindColumn(5,"a", "Bo", "BO对象选择","", "NCHAR", 100,0,false, IsPrimaryKey =false ,IsIdentity =false,IsNullable =true,  Length =100 )]
 public  System.String Bo  { get { return _Bo; } set { _Bo = value; } }

 private System.String _BoWhere;
 /// <summary>
 /// BO对象查询条件
 /// </summary>
 [BindColumn(6,"a", "BoWhere", "BO对象查询条件","", "NCHAR", 500,0,false, IsPrimaryKey =false ,IsIdentity =false,IsNullable =true,  Length =500 )]
 public  System.String BoWhere  { get { return _BoWhere; } set { _BoWhere = value; } }

 private System.String _BoOrder;
 /// <summary>
 /// BO对象排序
 /// </summary>
 [BindColumn(7,"a", "BoOrder", "BO对象排序","", "NCHAR", 300,0,false, IsPrimaryKey =false ,IsIdentity =false,IsNullable =true,  Length =300 )]
 public  System.String BoOrder  { get { return _BoOrder; } set { _BoOrder = value; } }

 private System.String _ProcName;
 /// <summary>
 /// 存储过程名称
 /// </summary>
 [BindColumn(8,"a", "ProcName", "存储过程名称","", "NCHAR", 100,0,false, IsPrimaryKey =false ,IsIdentity =false,IsNullable =true,  Length =100 )]
 public  System.String ProcName  { get { return _ProcName; } set { _ProcName = value; } }

 private System.String _ProcParam;
 /// <summary>
 /// 存储过程参数
 /// </summary>
 [BindColumn(9,"a", "ProcParam", "存储过程参数","", "NCHAR", 300,0,false, IsPrimaryKey =false ,IsIdentity =false,IsNullable =true,  Length =300 )]
 public  System.String ProcParam  { get { return _ProcParam; } set { _ProcParam = value; } }

 private System.String _ProcValue;
 /// <summary>
 /// 存储过程数据
 /// </summary>
 [BindColumn(10,"a", "ProcValue", "存储过程数据","", "NCHAR", 300,0,false, IsPrimaryKey =false ,IsIdentity =false,IsNullable =true,  Length =300 )]
 public  System.String ProcValue  { get { return _ProcValue; } set { _ProcValue = value; } }

      
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
if (name == "REPORTID")
{
return _ReportId;
}
if (name == "NAME")
{
return _Name;
}
if (name == "SQL")
{
return _Sql;
}
if (name == "BO")
{
return _Bo;
}
if (name == "BOWHERE")
{
return _BoWhere;
}
if (name == "BOORDER")
{
return _BoOrder;
}
if (name == "PROCNAME")
{
return _ProcName;
}
if (name == "PROCPARAM")
{
return _ProcParam;
}
if (name == "PROCVALUE")
{
return _ProcValue;
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
if (name == "REPORTID")
{
 _ReportId = XCode.Common.Helper.ConvertToGuid(value);return;
}
if (name == "NAME")
{
 _Name = System.Convert.ToString(value);return;
}
if (name == "SQL")
{
 _Sql = System.Convert.ToString(value);return;
}
if (name == "BO")
{
 _Bo = System.Convert.ToString(value);return;
}
if (name == "BOWHERE")
{
 _BoWhere = System.Convert.ToString(value);return;
}
if (name == "BOORDER")
{
 _BoOrder = System.Convert.ToString(value);return;
}
if (name == "PROCNAME")
{
 _ProcName = System.Convert.ToString(value);return;
}
if (name == "PROCPARAM")
{
 _ProcParam = System.Convert.ToString(value);return;
}
if (name == "PROCVALUE")
{
 _ProcValue = System.Convert.ToString(value);return;
}

			    base[name] = value;
			}
		}
		#endregion
	}
}