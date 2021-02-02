 
 
 using    System;
 using System.Collections.Generic;
 using System.Text; 
 using XCode.Attributes    ;

 namespace  Power.Systems.StdSystem
{
    /// <summary>
    /// 计划类型子表
    /// </summary>
    public class project_plan_typeDO : project_plan_typeDO<project_plan_typeDO>
    {

    }

	/// <summary>
    /// 计划类型子表
    /// </summary>
	  [BindEntity(KeyWord="project_plan_type",EntityType = typeof(Power.Systems.StdSystem.project_plan_typeDO),Description = "计划类型子表"  )] 

	 [BindTable( "pln_project_plan_type", Alias = "a",IsAttach=false,Description ="")]

	  [BindIndex(Name = "pk_pln_project_plan_type", KeyType = Power.DataAccessLayer.KeyType.MainKey, Columns = "Id", TableName = "pln_project_plan_type",Description="")]

    public   class project_plan_typeDO<TEntity> : XCode.Entity<TEntity>, XCode.IEntity where TEntity : Power.Systems.StdSystem.project_plan_typeDO<TEntity>, new()
    { 
	    #region 属性

	    
 private System.Guid _Id;
 /// <summary>
 /// 
 /// </summary>
 [BindColumn(1,"a", "Id", "","", "NCHAR", 16,0,false, IsPrimaryKey =true ,IsIdentity =true,IsNullable =false,  Length =16 )]
 public virtual System.Guid Id  { get { return _Id; } set { _Id = value; } }

 private System.Int32 _Sequ;
 /// <summary>
 /// 序号
 /// </summary>
 [BindColumn(2,"a", "Sequ", "序号","", "NCHAR", 10,0,false, IsPrimaryKey =false ,IsIdentity =false,IsNullable =false,  Length =10 )]
 public  System.Int32 Sequ  { get { return _Sequ; } set { _Sequ = value; } }

 private System.Guid _plan_guid;
 /// <summary>
 /// plan关联外键
 /// </summary>
 [BindColumn(3,"a", "plan_guid", "plan关联外键","", "NCHAR", 16,0,false, IsPrimaryKey =false ,IsIdentity =false,IsNullable =false,  Length =16 )]
 public  System.Guid plan_guid  { get { return _plan_guid; } set { _plan_guid = value; } }

 private System.String _plantype;
 /// <summary>
 /// 计划类型
 /// </summary>
 [BindColumn(4,"a", "plantype", "计划类型","", "NCHAR", 20,0,false, IsPrimaryKey =false ,IsIdentity =false,IsNullable =true,  Length =20 )]
 public  System.String plantype  { get { return _plantype; } set { _plantype = value; } }

 private System.String _plantype_title;
 /// <summary>
 /// 计划类型名称
 /// </summary>
 [BindColumn(5,"a", "plantype_title", "计划类型名称","", "NCHAR", 50,0,false, IsPrimaryKey =false ,IsIdentity =false,IsNullable =true,  Length =50 )]
 public  System.String plantype_title  { get { return _plantype_title; } set { _plantype_title = value; } }

 private System.Int32 _actived;
 /// <summary>
 /// 是否激活
 /// </summary>
 [BindColumn(6,"a", "actived", "是否激活","", "NCHAR", 10,0,false, IsPrimaryKey =false ,IsIdentity =false,IsNullable =false,  Length =10 )]
 public  System.Int32 actived  { get { return _actived; } set { _actived = value; } }

 private System.String _memo;
 /// <summary>
 /// 备注
 /// </summary>
 [BindColumn(7,"a", "memo", "备注","", "NCHAR", 255,0,false, IsPrimaryKey =false ,IsIdentity =false,IsNullable =true,  Length =255 )]
 public  System.String memo  { get { return _memo; } set { _memo = value; } }

 private System.String _bSysDefault;
 /// <summary>
 /// 是否系统默认
 /// </summary>
 [BindColumn(8,"a", "bSysDefault", "是否系统默认","", "NCHAR", 6,0,false, IsPrimaryKey =false ,IsIdentity =false,IsNullable =true,  Length =6 )]
 public  System.String bSysDefault  { get { return _bSysDefault; } set { _bSysDefault = value; } }

 private System.DateTime _UpdDate;
 /// <summary>
 /// 最后更新日期
 /// </summary>
 [BindColumn(9,"a", "UpdDate", "最后更新日期","", "NCHAR", 3,0,false, IsPrimaryKey =false ,IsIdentity =false,IsNullable =false,  Length =3 )]
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
if (name == "SEQU")
{
return _Sequ;
}
if (name == "PLAN_GUID")
{
return _plan_guid;
}
if (name == "PLANTYPE")
{
return _plantype;
}
if (name == "PLANTYPE_TITLE")
{
return _plantype_title;
}
if (name == "ACTIVED")
{
return _actived;
}
if (name == "MEMO")
{
return _memo;
}
if (name == "BSYSDEFAULT")
{
return _bSysDefault;
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
if (name == "SEQU")
{
 _Sequ = System.Convert.ToInt32(value);return;
}
if (name == "PLAN_GUID")
{
 _plan_guid = XCode.Common.Helper.ConvertToGuid(value);return;
}
if (name == "PLANTYPE")
{
 _plantype = System.Convert.ToString(value);return;
}
if (name == "PLANTYPE_TITLE")
{
 _plantype_title = System.Convert.ToString(value);return;
}
if (name == "ACTIVED")
{
 _actived = System.Convert.ToInt32(value);return;
}
if (name == "MEMO")
{
 _memo = System.Convert.ToString(value);return;
}
if (name == "BSYSDEFAULT")
{
 _bSysDefault = System.Convert.ToString(value);return;
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