 
 
 using    System;
 using System.Collections.Generic;
 using System.Text; 
 using XCode.Attributes    ;

 namespace  Power.Systems.StdSystem
{
    /// <summary>
    /// 前置任务描述
    /// </summary>
    public class TaskPredDO : TaskPredDO<TaskPredDO>
    {

    }

	/// <summary>
    /// 前置任务描述
    /// </summary>
	  [BindEntity(KeyWord="TaskPred",EntityType = typeof(Power.Systems.StdSystem.TaskPredDO),Description = "前置任务描述"  )] 

	 [BindTable( "PLN_TASKPRED", Alias = "a",IsAttach=false,Description ="")]

	  [BindIndex(Name = "pk_PLN_TASKPRED", KeyType = Power.DataAccessLayer.KeyType.MainKey, Columns = "task_pred_guid", TableName = "PLN_TASKPRED",Description="")]

    public   class TaskPredDO<TEntity> : XCode.Entity<TEntity>, XCode.IEntity where TEntity : Power.Systems.StdSystem.TaskPredDO<TEntity>, new()
    { 
	    #region 属性

	    
 private System.Int32 _task_pred_id;
 /// <summary>
 /// 
 /// </summary>
 [BindColumn(1,"a", "task_pred_id", "","", "NCHAR", 10,0,false, IsAutoInsert =true , IsPrimaryKey =false ,IsIdentity =false,IsNullable =false,  Length =10 )]
 public  System.Int32 task_pred_id  { get { return _task_pred_id; } set { _task_pred_id = value; } }

 private System.Int32 _task_id;
 /// <summary>
 /// 当前taskid
 /// </summary>
 [BindColumn(2,"a", "task_id", "当前taskid","", "NCHAR", 10,0,false, IsPrimaryKey =false ,IsIdentity =false,IsNullable =false,  Length =10 )]
 public  System.Int32 task_id  { get { return _task_id; } set { _task_id = value; } }

 private System.Int32 _wbs_id;
 /// <summary>
 /// 
 /// </summary>
 [BindColumn(3,"a", "wbs_id", "","", "NCHAR", 10,0,false, IsPrimaryKey =false ,IsIdentity =false,IsNullable =true,  Length =10 )]
 public  System.Int32 wbs_id  { get { return _wbs_id; } set { _wbs_id = value; } }

 private System.Int32 _pred_task_id;
 /// <summary>
 /// 紧前taskid
 /// </summary>
 [BindColumn(4,"a", "pred_task_id", "紧前taskid","", "NCHAR", 10,0,false, IsPrimaryKey =false ,IsIdentity =false,IsNullable =false,  Length =10 )]
 public  System.Int32 pred_task_id  { get { return _pred_task_id; } set { _pred_task_id = value; } }

 private System.Int32 _pred_wbs_id;
 /// <summary>
 /// 
 /// </summary>
 [BindColumn(5,"a", "pred_wbs_id", "","", "NCHAR", 10,0,false, IsPrimaryKey =false ,IsIdentity =false,IsNullable =true,  Length =10 )]
 public  System.Int32 pred_wbs_id  { get { return _pred_wbs_id; } set { _pred_wbs_id = value; } }

 private System.Int32 _proj_id;
 /// <summary>
 /// 项目id
 /// </summary>
 [BindColumn(6,"a", "proj_id", "项目id","", "NCHAR", 10,0,false, IsPrimaryKey =false ,IsIdentity =false,IsNullable =false,  Length =10 )]
 public  System.Int32 proj_id  { get { return _proj_id; } set { _proj_id = value; } }

 private System.Int32 _pred_proj_id;
 /// <summary>
 /// 紧前项目id
 /// </summary>
 [BindColumn(7,"a", "pred_proj_id", "紧前项目id","", "NCHAR", 10,0,false, IsPrimaryKey =false ,IsIdentity =false,IsNullable =false,  Length =10 )]
 public  System.Int32 pred_proj_id  { get { return _pred_proj_id; } set { _pred_proj_id = value; } }

 private System.String _pred_type;
 /// <summary>
 /// 关系类型，现均为FS
 /// </summary>
 [BindColumn(8,"a", "pred_type", "关系类型，现均为FS","FS", "NCHAR", 12,0,false, IsPrimaryKey =false ,IsIdentity =false,IsNullable =false,  Length =12 )]
 public  System.String pred_type  { get { return _pred_type; } set { _pred_type = value; } }

 private System.Decimal _lag_hr_cnt;
 /// <summary>
 /// 浮时
 /// </summary>
 [BindColumn(9,"a", "lag_hr_cnt", "浮时","0", "NCHAR", 17,6,false, IsPrimaryKey =false ,IsIdentity =false,IsNullable =true,  Length =17 )]
 public  System.Decimal lag_hr_cnt  { get { return _lag_hr_cnt; } set { _lag_hr_cnt = value; } }

 private System.DateTime _update_date;
 /// <summary>
 /// 更新时间
 /// </summary>
 [BindColumn(10,"a", "update_date", "更新时间","getdate()", "NCHAR", 3,0,false, IsPrimaryKey =false ,IsIdentity =false,IsNullable =true,  Length =3 )]
 public  System.DateTime update_date  { get { return _update_date; } set { _update_date = value; } }

 private System.String _update_user;
 /// <summary>
 /// 更新人员
 /// </summary>
 [BindColumn(11,"a", "update_user", "更新人员","", "NCHAR", 255,0,false, IsPrimaryKey =false ,IsIdentity =false,IsNullable =true,  Length =255 )]
 public  System.String update_user  { get { return _update_user; } set { _update_user = value; } }

 private System.DateTime _create_date;
 /// <summary>
 /// 创建时间
 /// </summary>
 [BindColumn(12,"a", "create_date", "创建时间","getdate()", "NCHAR", 3,0,false, IsPrimaryKey =false ,IsIdentity =false,IsNullable =true,  Length =3 )]
 public  System.DateTime create_date  { get { return _create_date; } set { _create_date = value; } }

 private System.String _create_user;
 /// <summary>
 /// 创建人员
 /// </summary>
 [BindColumn(13,"a", "create_user", "创建人员","", "NCHAR", 255,0,false, IsPrimaryKey =false ,IsIdentity =false,IsNullable =true,  Length =255 )]
 public  System.String create_user  { get { return _create_user; } set { _create_user = value; } }

 private System.Int32 _delete_session_id;
 /// <summary>
 /// 
 /// </summary>
 [BindColumn(14,"a", "delete_session_id", "","", "NCHAR", 10,0,false, IsPrimaryKey =false ,IsIdentity =false,IsNullable =true,  Length =10 )]
 public  System.Int32 delete_session_id  { get { return _delete_session_id; } set { _delete_session_id = value; } }

 private System.DateTime _delete_date;
 /// <summary>
 /// 
 /// </summary>
 [BindColumn(15,"a", "delete_date", "","", "NCHAR", 3,0,false, IsPrimaryKey =false ,IsIdentity =false,IsNullable =true,  Length =3 )]
 public  System.DateTime delete_date  { get { return _delete_date; } set { _delete_date = value; } }

 private System.Int32 _temp_id;
 /// <summary>
 /// 
 /// </summary>
 [BindColumn(16,"a", "temp_id", "","0", "NCHAR", 10,0,false, IsPrimaryKey =false ,IsIdentity =false,IsNullable =true,  Length =10 )]
 public  System.Int32 temp_id  { get { return _temp_id; } set { _temp_id = value; } }

 private System.Int32 _p3ec_flag;
 /// <summary>
 /// 
 /// </summary>
 [BindColumn(17,"a", "p3ec_flag", "","", "NCHAR", 10,0,false, IsPrimaryKey =false ,IsIdentity =false,IsNullable =true,  Length =10 )]
 public  System.Int32 p3ec_flag  { get { return _p3ec_flag; } set { _p3ec_flag = value; } }

 private System.Int32 _p3ec_pred_id;
 /// <summary>
 /// 
 /// </summary>
 [BindColumn(18,"a", "p3ec_pred_id", "","", "NCHAR", 10,0,false, IsPrimaryKey =false ,IsIdentity =false,IsNullable =true,  Length =10 )]
 public  System.Int32 p3ec_pred_id  { get { return _p3ec_pred_id; } set { _p3ec_pred_id = value; } }

 private System.String _task_guid;
 /// <summary>
 /// 
 /// </summary>
 [BindColumn(19,"a", "task_guid", "","", "NCHAR", 38,0,false, IsPrimaryKey =false ,IsIdentity =false,IsNullable =true,  Length =38 )]
 public  System.String task_guid  { get { return _task_guid; } set { _task_guid = value; } }

 private System.String _pred_guid;
 /// <summary>
 /// 
 /// </summary>
 [BindColumn(20,"a", "pred_guid", "","", "NCHAR", 38,0,false, IsPrimaryKey =false ,IsIdentity =false,IsNullable =true,  Length =38 )]
 public  System.String pred_guid  { get { return _pred_guid; } set { _pred_guid = value; } }

 private System.String _control_path_flag;
 /// <summary>
 /// 
 /// </summary>
 [BindColumn(21,"a", "control_path_flag", "","Y", "NCHAR", 1,0,false, IsPrimaryKey =false ,IsIdentity =false,IsNullable =true,  Length =1 )]
 public  System.String control_path_flag  { get { return _control_path_flag; } set { _control_path_flag = value; } }

 private System.Int32 _plan_id;
 /// <summary>
 /// 
 /// </summary>
 [BindColumn(22,"a", "plan_id", "","", "NCHAR", 10,0,false, IsPrimaryKey =false ,IsIdentity =false,IsNullable =true,  Length =10 )]
 public  System.Int32 plan_id  { get { return _plan_id; } set { _plan_id = value; } }

 private System.Int32 _pred_plan_id;
 /// <summary>
 /// 
 /// </summary>
 [BindColumn(23,"a", "pred_plan_id", "","", "NCHAR", 10,0,false, IsPrimaryKey =false ,IsIdentity =false,IsNullable =true,  Length =10 )]
 public  System.Int32 pred_plan_id  { get { return _pred_plan_id; } set { _pred_plan_id = value; } }

 private System.String _task_pred_guid;
 /// <summary>
 /// 
 /// </summary>
 [BindColumn(24,"a", "task_pred_guid", "","newid()", "NCHAR", 38,0,false, IsPrimaryKey =true ,IsIdentity =true,IsNullable =false,  Length =38 )]
 public virtual System.String task_pred_guid  { get { return _task_pred_guid; } set { _task_pred_guid = value; } }

 private System.String _wbs_guid;
 /// <summary>
 /// 
 /// </summary>
 [BindColumn(25,"a", "wbs_guid", "","", "NCHAR", 38,0,false, IsPrimaryKey =false ,IsIdentity =false,IsNullable =true,  Length =38 )]
 public  System.String wbs_guid  { get { return _wbs_guid; } set { _wbs_guid = value; } }

 private System.String _pred_wbs_guid;
 /// <summary>
 /// 
 /// </summary>
 [BindColumn(26,"a", "pred_wbs_guid", "","", "NCHAR", 38,0,false, IsPrimaryKey =false ,IsIdentity =false,IsNullable =true,  Length =38 )]
 public  System.String pred_wbs_guid  { get { return _pred_wbs_guid; } set { _pred_wbs_guid = value; } }

 private System.String _proj_guid;
 /// <summary>
 /// 
 /// </summary>
 [BindColumn(27,"a", "proj_guid", "","", "NCHAR", 38,0,false, IsPrimaryKey =false ,IsIdentity =false,IsNullable =true,  Length =38 )]
 public  System.String proj_guid  { get { return _proj_guid; } set { _proj_guid = value; } }

 private System.String _plan_guid;
 /// <summary>
 /// 
 /// </summary>
 [BindColumn(28,"a", "plan_guid", "","", "NCHAR", 38,0,false, IsPrimaryKey =false ,IsIdentity =false,IsNullable =true,  Length =38 )]
 public  System.String plan_guid  { get { return _plan_guid; } set { _plan_guid = value; } }

 private System.String _pred_proj_guid;
 /// <summary>
 /// 
 /// </summary>
 [BindColumn(29,"a", "pred_proj_guid", "","", "NCHAR", 38,0,false, IsPrimaryKey =false ,IsIdentity =false,IsNullable =true,  Length =38 )]
 public  System.String pred_proj_guid  { get { return _pred_proj_guid; } set { _pred_proj_guid = value; } }

 private System.String _pred_plan_guid;
 /// <summary>
 /// 
 /// </summary>
 [BindColumn(30,"a", "pred_plan_guid", "","", "NCHAR", 38,0,false, IsPrimaryKey =false ,IsIdentity =false,IsNullable =true,  Length =38 )]
 public  System.String pred_plan_guid  { get { return _pred_plan_guid; } set { _pred_plan_guid = value; } }

 private System.String _temp_guid;
 /// <summary>
 /// 
 /// </summary>
 [BindColumn(31,"a", "temp_guid", "","", "NCHAR", 38,0,false, IsPrimaryKey =false ,IsIdentity =false,IsNullable =true,  Length =38 )]
 public  System.String temp_guid  { get { return _temp_guid; } set { _temp_guid = value; } }

      
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
			    if (name == "TASK_PRED_ID")
{
return _task_pred_id;
}
if (name == "TASK_ID")
{
return _task_id;
}
if (name == "WBS_ID")
{
return _wbs_id;
}
if (name == "PRED_TASK_ID")
{
return _pred_task_id;
}
if (name == "PRED_WBS_ID")
{
return _pred_wbs_id;
}
if (name == "PROJ_ID")
{
return _proj_id;
}
if (name == "PRED_PROJ_ID")
{
return _pred_proj_id;
}
if (name == "PRED_TYPE")
{
return _pred_type;
}
if (name == "LAG_HR_CNT")
{
return _lag_hr_cnt;
}
if (name == "UPDATE_DATE")
{
return _update_date;
}
if (name == "UPDATE_USER")
{
return _update_user;
}
if (name == "CREATE_DATE")
{
return _create_date;
}
if (name == "CREATE_USER")
{
return _create_user;
}
if (name == "DELETE_SESSION_ID")
{
return _delete_session_id;
}
if (name == "DELETE_DATE")
{
return _delete_date;
}
if (name == "TEMP_ID")
{
return _temp_id;
}
if (name == "P3EC_FLAG")
{
return _p3ec_flag;
}
if (name == "P3EC_PRED_ID")
{
return _p3ec_pred_id;
}
if (name == "TASK_GUID")
{
return _task_guid;
}
if (name == "PRED_GUID")
{
return _pred_guid;
}
if (name == "CONTROL_PATH_FLAG")
{
return _control_path_flag;
}
if (name == "PLAN_ID")
{
return _plan_id;
}
if (name == "PRED_PLAN_ID")
{
return _pred_plan_id;
}
if (name == "TASK_PRED_GUID")
{
return _task_pred_guid;
}
if (name == "WBS_GUID")
{
return _wbs_guid;
}
if (name == "PRED_WBS_GUID")
{
return _pred_wbs_guid;
}
if (name == "PROJ_GUID")
{
return _proj_guid;
}
if (name == "PLAN_GUID")
{
return _plan_guid;
}
if (name == "PRED_PROJ_GUID")
{
return _pred_proj_guid;
}
if (name == "PRED_PLAN_GUID")
{
return _pred_plan_guid;
}
if (name == "TEMP_GUID")
{
return _temp_guid;
}

			    return base[name];
			}
			set 
			{
			   name = name.ToUpper();
			       if (name == "TASK_PRED_ID")
{
 _task_pred_id = System.Convert.ToInt32(value);return;
}
if (name == "TASK_ID")
{
 _task_id = System.Convert.ToInt32(value);return;
}
if (name == "WBS_ID")
{
 _wbs_id = System.Convert.ToInt32(value);return;
}
if (name == "PRED_TASK_ID")
{
 _pred_task_id = System.Convert.ToInt32(value);return;
}
if (name == "PRED_WBS_ID")
{
 _pred_wbs_id = System.Convert.ToInt32(value);return;
}
if (name == "PROJ_ID")
{
 _proj_id = System.Convert.ToInt32(value);return;
}
if (name == "PRED_PROJ_ID")
{
 _pred_proj_id = System.Convert.ToInt32(value);return;
}
if (name == "PRED_TYPE")
{
 _pred_type = System.Convert.ToString(value);return;
}
if (name == "LAG_HR_CNT")
{
 _lag_hr_cnt = System.Convert.ToDecimal(value);return;
}
if (name == "UPDATE_DATE")
{
 if (value == null || value.ToString().IsNullOrEmpty() == true) value = DateTime.MinValue;
 _update_date = System.Convert.ToDateTime(value);return;
}
if (name == "UPDATE_USER")
{
 _update_user = System.Convert.ToString(value);return;
}
if (name == "CREATE_DATE")
{
 if (value == null || value.ToString().IsNullOrEmpty() == true) value = DateTime.MinValue;
 _create_date = System.Convert.ToDateTime(value);return;
}
if (name == "CREATE_USER")
{
 _create_user = System.Convert.ToString(value);return;
}
if (name == "DELETE_SESSION_ID")
{
 _delete_session_id = System.Convert.ToInt32(value);return;
}
if (name == "DELETE_DATE")
{
 if (value == null || value.ToString().IsNullOrEmpty() == true) value = DateTime.MinValue;
 _delete_date = System.Convert.ToDateTime(value);return;
}
if (name == "TEMP_ID")
{
 _temp_id = System.Convert.ToInt32(value);return;
}
if (name == "P3EC_FLAG")
{
 _p3ec_flag = System.Convert.ToInt32(value);return;
}
if (name == "P3EC_PRED_ID")
{
 _p3ec_pred_id = System.Convert.ToInt32(value);return;
}
if (name == "TASK_GUID")
{
 _task_guid = System.Convert.ToString(value);return;
}
if (name == "PRED_GUID")
{
 _pred_guid = System.Convert.ToString(value);return;
}
if (name == "CONTROL_PATH_FLAG")
{
 _control_path_flag = System.Convert.ToString(value);return;
}
if (name == "PLAN_ID")
{
 _plan_id = System.Convert.ToInt32(value);return;
}
if (name == "PRED_PLAN_ID")
{
 _pred_plan_id = System.Convert.ToInt32(value);return;
}
if (name == "TASK_PRED_GUID")
{
 _task_pred_guid = System.Convert.ToString(value);return;
}
if (name == "WBS_GUID")
{
 _wbs_guid = System.Convert.ToString(value);return;
}
if (name == "PRED_WBS_GUID")
{
 _pred_wbs_guid = System.Convert.ToString(value);return;
}
if (name == "PROJ_GUID")
{
 _proj_guid = System.Convert.ToString(value);return;
}
if (name == "PLAN_GUID")
{
 _plan_guid = System.Convert.ToString(value);return;
}
if (name == "PRED_PROJ_GUID")
{
 _pred_proj_guid = System.Convert.ToString(value);return;
}
if (name == "PRED_PLAN_GUID")
{
 _pred_plan_guid = System.Convert.ToString(value);return;
}
if (name == "TEMP_GUID")
{
 _temp_guid = System.Convert.ToString(value);return;
}

			    base[name] = value;
			}
		}
		#endregion
	}
}