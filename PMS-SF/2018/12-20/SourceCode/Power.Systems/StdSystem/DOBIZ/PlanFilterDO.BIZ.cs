 
 
 using    System;
 using System.Collections.Generic;
 using System.Text; 
 using XCode.Attributes    ;

 namespace  Power.Systems.StdSystem
{
    /// <summary>
    /// 计划筛选
    /// </summary>
    public class PlanFilterDO : PlanFilterDO<PlanFilterDO>
    {

    }

	/// <summary>
    /// 计划筛选
    /// </summary>
	  [BindEntity(KeyWord="PlanFilter",EntityType = typeof(Power.Systems.StdSystem.PlanFilterDO),Description = "计划筛选"  )] 

	 [BindTable( "PB_PlnFilter", Alias = "a",IsAttach=false,Description ="")]

	  [BindIndex(Name = "pk_PB_PlnFilter", KeyType = Power.DataAccessLayer.KeyType.MainKey, Columns = "id", TableName = "PB_PlnFilter",Description="")]

    public   class PlanFilterDO<TEntity> : XCode.Entity<TEntity>, XCode.IEntity where TEntity : Power.Systems.StdSystem.PlanFilterDO<TEntity>, new()
    { 
	    #region 属性

	    
 private System.Guid _id;
 /// <summary>
 /// 
 /// </summary>
 [BindColumn(1,"a", "id", "","", "NCHAR", 16,0,false, IsPrimaryKey =true ,IsIdentity =true,IsNullable =false,  Length =16 )]
 public virtual System.Guid id  { get { return _id; } set { _id = value; } }

 private System.Int32 _project_id;
 /// <summary>
 /// 项目id
 /// </summary>
 [BindColumn(2,"a", "project_id", "项目id","", "NCHAR", 10,0,false, IsPrimaryKey =false ,IsIdentity =false,IsNullable =true,  Length =10 )]
 public  System.Int32 project_id  { get { return _project_id; } set { _project_id = value; } }

 private System.String _project_guid;
 /// <summary>
 /// 项目guid
 /// </summary>
 [BindColumn(3,"a", "project_guid", "项目guid","", "NCHAR", 38,0,false, IsPrimaryKey =false ,IsIdentity =false,IsNullable =false,  Length =38 )]
 public  System.String project_guid  { get { return _project_guid; } set { _project_guid = value; } }

 private System.Int32 _plan_id;
 /// <summary>
 /// 计划版本id
 /// </summary>
 [BindColumn(4,"a", "plan_id", "计划版本id","", "NCHAR", 10,0,false, IsPrimaryKey =false ,IsIdentity =false,IsNullable =true,  Length =10 )]
 public  System.Int32 plan_id  { get { return _plan_id; } set { _plan_id = value; } }

 private System.Int32 _wbs_id;
 /// <summary>
 /// 
 /// </summary>
 [BindColumn(5,"a", "wbs_id", "","", "NCHAR", 10,0,false, IsPrimaryKey =false ,IsIdentity =false,IsNullable =false,  Length =10 )]
 public  System.Int32 wbs_id  { get { return _wbs_id; } set { _wbs_id = value; } }

 private System.String _wbs_name;
 /// <summary>
 /// 
 /// </summary>
 [BindColumn(6,"a", "wbs_name", "","", "NCHAR", 100,0,false, IsPrimaryKey =false ,IsIdentity =false,IsNullable =true,  Length =100 )]
 public  System.String wbs_name  { get { return _wbs_name; } set { _wbs_name = value; } }

 private System.Guid _filter_id;
 /// <summary>
 /// 筛选guid
 /// </summary>
 [BindColumn(7,"a", "filter_id", "筛选guid","", "NCHAR", 16,0,false, IsPrimaryKey =false ,IsIdentity =false,IsNullable =false,  Length =16 )]
 public  System.Guid filter_id  { get { return _filter_id; } set { _filter_id = value; } }

 private System.Int32 _filter_type;
 /// <summary>
 /// 0 按human_id筛选 1 按岗位id筛选 2按权限组id筛选
 /// </summary>
 [BindColumn(8,"a", "filter_type", "0 按human_id筛选 1 按岗位id筛选 2按权限组id筛选","0", "NCHAR", 10,0,false, IsPrimaryKey =false ,IsIdentity =false,IsNullable =false,  Length =10 )]
 public  System.Int32 filter_type  { get { return _filter_type; } set { _filter_type = value; } }

      
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
return _id;
}
if (name == "PROJECT_ID")
{
return _project_id;
}
if (name == "PROJECT_GUID")
{
return _project_guid;
}
if (name == "PLAN_ID")
{
return _plan_id;
}
if (name == "WBS_ID")
{
return _wbs_id;
}
if (name == "WBS_NAME")
{
return _wbs_name;
}
if (name == "FILTER_ID")
{
return _filter_id;
}
if (name == "FILTER_TYPE")
{
return _filter_type;
}

			    return base[name];
			}
			set 
			{
			   name = name.ToUpper();
			       if (name == "ID")
{
 _id = XCode.Common.Helper.ConvertToGuid(value);return;
}
if (name == "PROJECT_ID")
{
 _project_id = System.Convert.ToInt32(value);return;
}
if (name == "PROJECT_GUID")
{
 _project_guid = System.Convert.ToString(value);return;
}
if (name == "PLAN_ID")
{
 _plan_id = System.Convert.ToInt32(value);return;
}
if (name == "WBS_ID")
{
 _wbs_id = System.Convert.ToInt32(value);return;
}
if (name == "WBS_NAME")
{
 _wbs_name = System.Convert.ToString(value);return;
}
if (name == "FILTER_ID")
{
 _filter_id = XCode.Common.Helper.ConvertToGuid(value);return;
}
if (name == "FILTER_TYPE")
{
 _filter_type = System.Convert.ToInt32(value);return;
}

			    base[name] = value;
			}
		}
		#endregion
	}
}