 
 
 using    System;
 using System.Collections.Generic;
 using System.Text; 
 using XCode.Attributes    ;

 namespace  Power.Systems.StdSystem
{
    /// <summary>
    /// 项目计划版本
    /// </summary>
    public class ProjectPlanDO : ProjectPlanDO<ProjectPlanDO>
    {

    }

	/// <summary>
    /// 项目计划版本
    /// </summary>
	  [BindEntity(KeyWord="ProjectPlan",EntityType = typeof(Power.Systems.StdSystem.ProjectPlanDO),Description = "项目计划版本"  )] 

	 [BindTable( "PLN_project_plan", Alias = "a",IsAttach=false,Description ="")]

	  [BindIndex(Name = "pk_PLN_project_plan", KeyType = Power.DataAccessLayer.KeyType.MainKey, Columns = "proj_plan_guid", TableName = "PLN_project_plan",Description="")]
 [BindIndex(Name = "pt_PLN_project_plan", KeyType = Power.DataAccessLayer.KeyType.ParentKey, Columns = "parent_plan_guid,proj_plan_guid", TableName = "PLN_project_plan",Description="")]

    public   class ProjectPlanDO<TEntity> : XCode.Entity<TEntity>, XCode.IEntity where TEntity : Power.Systems.StdSystem.ProjectPlanDO<TEntity>, new()
    { 
	    #region 属性

	    
 private System.Decimal _est_wt_value;
 /// <summary>
 /// 
 /// </summary>
 [BindColumn(1,"a", "est_wt_value", "","", "NCHAR", 6,0,false, IsPrimaryKey =false ,IsIdentity =false,IsNullable =true,  Length =6 )]
 public  System.Decimal est_wt_value  { get { return _est_wt_value; } set { _est_wt_value = value; } }

 private System.Int32 _proj_plan_id;
 /// <summary>
 /// 
 /// </summary>
 [BindColumn(1,"a", "proj_plan_id", "","", "NCHAR", 10,0,false, IsAutoInsert =true , IsPrimaryKey =false ,IsIdentity =false,IsNullable =false,  Length =10 )]
 public  System.Int32 proj_plan_id  { get { return _proj_plan_id; } set { _proj_plan_id = value; } }

 private System.String _apprhumname;
 /// <summary>
 /// 
 /// </summary>
 [BindColumn(1,"a", "apprhumname", "","", "NCHAR", 6,0,false, IsPrimaryKey =false ,IsIdentity =false,IsNullable =true,  Length =6 )]
 public  System.String apprhumname  { get { return _apprhumname; } set { _apprhumname = value; } }

 private System.String _plantype;
 /// <summary>
 /// 计划类型
 /// </summary>
 [BindColumn(1,"a", "plantype", "计划类型","", "NCHAR", 6,0,false, IsPrimaryKey =false ,IsIdentity =false,IsNullable =true,  Length =6 )]
 public  System.String plantype  { get { return _plantype; } set { _plantype = value; } }

 private System.DateTime _receive_date;
 /// <summary>
 /// 
 /// </summary>
 [BindColumn(1,"a", "receive_date", "","", "NCHAR", 0,0,false, IsPrimaryKey =false ,IsIdentity =false,IsNullable =true,  Length =0 )]
 public  System.DateTime receive_date  { get { return _receive_date; } set { _receive_date = value; } }

 private System.String _planfilter;
 /// <summary>
 /// 导出计划类型
 /// </summary>
 [BindColumn(1,"a", "planfilter", "导出计划类型","", "NCHAR", 6,0,false, IsPrimaryKey =false ,IsIdentity =false,IsNullable =false,  Length =6 )]
 public  System.String planfilter  { get { return _planfilter; } set { _planfilter = value; } }

 private System.Guid _apprhumid;
 /// <summary>
 /// 
 /// </summary>
 [BindColumn(1,"a", "apprhumid", "","", "NCHAR", 0,0,false, IsPrimaryKey =false ,IsIdentity =false,IsNullable =true,  Length =0 )]
 public  System.Guid apprhumid  { get { return _apprhumid; } set { _apprhumid = value; } }

 private System.Decimal _complete_pct;
 /// <summary>
 /// 
 /// </summary>
 [BindColumn(1,"a", "complete_pct", "","", "NCHAR", 6,0,false, IsPrimaryKey =false ,IsIdentity =false,IsNullable =true,  Length =6 )]
 public  System.Decimal complete_pct  { get { return _complete_pct; } set { _complete_pct = value; } }

 private System.String _baseline_plan_guid;
 /// <summary>
 /// 
 /// </summary>
 [BindColumn(1,"a", "baseline_plan_guid", "","", "NCHAR", 38,0,false, IsPrimaryKey =false ,IsIdentity =false,IsNullable =true,  Length =38 )]
 public  System.String baseline_plan_guid  { get { return _baseline_plan_guid; } set { _baseline_plan_guid = value; } }

 private System.String _receive_user;
 /// <summary>
 /// 
 /// </summary>
 [BindColumn(1,"a", "receive_user", "","", "NCHAR", 6,0,false, IsPrimaryKey =false ,IsIdentity =false,IsNullable =true,  Length =6 )]
 public  System.String receive_user  { get { return _receive_user; } set { _receive_user = value; } }

 private System.Guid _update_user_guid;
 /// <summary>
 /// 
 /// </summary>
 [BindColumn(1,"a", "update_user_guid", "","", "NCHAR", 0,0,false, IsPrimaryKey =false ,IsIdentity =false,IsNullable =true,  Length =0 )]
 public  System.Guid update_user_guid  { get { return _update_user_guid; } set { _update_user_guid = value; } }

 private System.DateTime _apprdate;
 /// <summary>
 /// 
 /// </summary>
 [BindColumn(1,"a", "apprdate", "","", "NCHAR", 0,0,false, IsPrimaryKey =false ,IsIdentity =false,IsNullable =true,  Length =0 )]
 public  System.DateTime apprdate  { get { return _apprdate; } set { _apprdate = value; } }

 private System.Int16 _status;
 /// <summary>
 /// 
 /// </summary>
 [BindColumn(1,"a", "status", "","", "NCHAR", 5,0,false, IsPrimaryKey =false ,IsIdentity =false,IsNullable =true,  Length =5 )]
 public  System.Int16 status  { get { return _status; } set { _status = value; } }

 private System.String _feedback_pct_type;
 /// <summary>
 /// 
 /// </summary>
 [BindColumn(1,"a", "feedback_pct_type", "","", "NCHAR", 6,0,false, IsPrimaryKey =false ,IsIdentity =false,IsNullable =true,  Length =6 )]
 public  System.String feedback_pct_type  { get { return _feedback_pct_type; } set { _feedback_pct_type = value; } }

 private System.Guid _create_user_guid;
 /// <summary>
 /// 
 /// </summary>
 [BindColumn(1,"a", "create_user_guid", "","", "NCHAR", 0,0,false, IsPrimaryKey =false ,IsIdentity =false,IsNullable =true,  Length =0 )]
 public  System.Guid create_user_guid  { get { return _create_user_guid; } set { _create_user_guid = value; } }

 private System.String _period_guid;
 /// <summary>
 /// 统计周期guid
 /// </summary>
 [BindColumn(1,"a", "period_guid", "统计周期guid","", "NCHAR", 6,0,false, IsPrimaryKey =false ,IsIdentity =false,IsNullable =true,  Length =6 )]
 public  System.String period_guid  { get { return _period_guid; } set { _period_guid = value; } }

 private System.Guid _receive_user_guid;
 /// <summary>
 /// 
 /// </summary>
 [BindColumn(1,"a", "receive_user_guid", "","", "NCHAR", 0,0,false, IsPrimaryKey =false ,IsIdentity =false,IsNullable =true,  Length =0 )]
 public  System.Guid receive_user_guid  { get { return _receive_user_guid; } set { _receive_user_guid = value; } }

 private System.Guid _proj_plan_guid;
 /// <summary>
 /// 
 /// </summary>
 [BindColumn(2,"a", "proj_plan_guid", "","", "NCHAR", 0,0,false, IsPrimaryKey =true ,IsIdentity =true,IsNullable =false,  Length =0 )]
 public virtual System.Guid proj_plan_guid  { get { return _proj_plan_guid; } set { _proj_plan_guid = value; } }

 private System.Int32 _proj_id;
 /// <summary>
 /// 
 /// </summary>
 [BindColumn(3,"a", "proj_id", "","", "NCHAR", 10,0,false, IsPrimaryKey =false ,IsIdentity =false,IsNullable =false,  Length =10 )]
 public  System.Int32 proj_id  { get { return _proj_id; } set { _proj_id = value; } }

 private System.Guid _proj_guid;
 /// <summary>
 /// 
 /// </summary>
 [BindColumn(4,"a", "proj_guid", "","", "NCHAR", 0,0,false, IsPrimaryKey =false ,IsIdentity =false,IsNullable =false,  Length =0 )]
 public  System.Guid proj_guid  { get { return _proj_guid; } set { _proj_guid = value; } }

 private System.Int32 _status_code;
 /// <summary>
 /// 
 /// </summary>
 [BindColumn(5,"a", "status_code", "","", "NCHAR", 10,0,false, IsPrimaryKey =false ,IsIdentity =false,IsNullable =true,  Length =10 )]
 public  System.Int32 status_code  { get { return _status_code; } set { _status_code = value; } }

 private System.Int32 _record_status;
 /// <summary>
 /// 
 /// </summary>
 [BindColumn(6,"a", "record_status", "","", "NCHAR", 10,0,false, IsPrimaryKey =false ,IsIdentity =false,IsNullable =true,  Length =10 )]
 public  System.Int32 record_status  { get { return _record_status; } set { _record_status = value; } }

 private System.Int32 _obs_id;
 /// <summary>
 /// 
 /// </summary>
 [BindColumn(7,"a", "obs_id", "","", "NCHAR", 10,0,false, IsPrimaryKey =false ,IsIdentity =false,IsNullable =true,  Length =10 )]
 public  System.Int32 obs_id  { get { return _obs_id; } set { _obs_id = value; } }

 private System.String _obs_guid;
 /// <summary>
 /// 
 /// </summary>
 [BindColumn(8,"a", "obs_guid", "","", "NCHAR", 38,0,false, IsPrimaryKey =false ,IsIdentity =false,IsNullable =true,  Length =38 )]
 public  System.String obs_guid  { get { return _obs_guid; } set { _obs_guid = value; } }

 private System.Int32 _risk_level;
 /// <summary>
 /// 
 /// </summary>
 [BindColumn(9,"a", "risk_level", "","", "NCHAR", 10,0,false, IsPrimaryKey =false ,IsIdentity =false,IsNullable =true,  Length =10 )]
 public  System.Int32 risk_level  { get { return _risk_level; } set { _risk_level = value; } }

 private System.Int32 _priority_num;
 /// <summary>
 /// 
 /// </summary>
 [BindColumn(10,"a", "priority_num", "","", "NCHAR", 10,0,false, IsPrimaryKey =false ,IsIdentity =false,IsNullable =true,  Length =10 )]
 public  System.Int32 priority_num  { get { return _priority_num; } set { _priority_num = value; } }

 private System.String _checkout_flag;
 /// <summary>
 /// 
 /// </summary>
 [BindColumn(11,"a", "checkout_flag", "","", "NCHAR", 1,0,false, IsPrimaryKey =false ,IsIdentity =false,IsNullable =true,  Length =1 )]
 public  System.String checkout_flag  { get { return _checkout_flag; } set { _checkout_flag = value; } }

 private System.DateTime _checkout_date;
 /// <summary>
 /// 
 /// </summary>
 [BindColumn(12,"a", "checkout_date", "","", "NCHAR", 3,0,false, IsPrimaryKey =false ,IsIdentity =false,IsNullable =true,  Length =3 )]
 public  System.DateTime checkout_date  { get { return _checkout_date; } set { _checkout_date = value; } }

 private System.Int32 _checkout_user_id;
 /// <summary>
 /// 
 /// </summary>
 [BindColumn(13,"a", "checkout_user_id", "","", "NCHAR", 10,0,false, IsPrimaryKey =false ,IsIdentity =false,IsNullable =true,  Length =10 )]
 public  System.Int32 checkout_user_id  { get { return _checkout_user_id; } set { _checkout_user_id = value; } }

 private System.String _web_local_root_path;
 /// <summary>
 /// 
 /// </summary>
 [BindColumn(14,"a", "web_local_root_path", "","", "NCHAR", 200,0,false, IsPrimaryKey =false ,IsIdentity =false,IsNullable =true,  Length =200 )]
 public  System.String web_local_root_path  { get { return _web_local_root_path; } set { _web_local_root_path = value; } }

 private System.Int32 _parent_plan_id;
 /// <summary>
 /// 
 /// </summary>
 [BindColumn(15,"a", "parent_plan_id", "","", "NCHAR", 10,0,false, IsPrimaryKey =false ,IsIdentity =false,IsNullable =true,  Length =10 )]
 public  System.Int32 parent_plan_id  { get { return _parent_plan_id; } set { _parent_plan_id = value; } }

 private System.String _parent_plan_guid;
 /// <summary>
 /// 
 /// </summary>
 [BindColumn(16,"a", "parent_plan_guid", "","", "NCHAR", 38,0,false, IsPrimaryKey =false ,IsIdentity =false,IsNullable =true,  Length =38 )]
 public  System.String parent_plan_guid  { get { return _parent_plan_guid; } set { _parent_plan_guid = value; } }

 private System.String _plan_name;
 /// <summary>
 /// 
 /// </summary>
 [BindColumn(17,"a", "plan_name", "","", "NCHAR", 200,0,false, IsPrimaryKey =false ,IsIdentity =false,IsNullable =true,  Length =200 )]
 public  System.String plan_name  { get { return _plan_name; } set { _plan_name = value; } }

 private System.String _plan_short_name;
 /// <summary>
 /// 
 /// </summary>
 [BindColumn(18,"a", "plan_short_name", "","", "NCHAR", 200,0,false, IsPrimaryKey =false ,IsIdentity =false,IsNullable =true,  Length =200 )]
 public  System.String plan_short_name  { get { return _plan_short_name; } set { _plan_short_name = value; } }

 private System.Int32 _haschild;
 /// <summary>
 /// 
 /// </summary>
 [BindColumn(19,"a", "haschild", "","", "NCHAR", 10,0,false, IsPrimaryKey =false ,IsIdentity =false,IsNullable =true,  Length =10 )]
 public  System.Int32 haschild  { get { return _haschild; } set { _haschild = value; } }

 private System.Int32 _treelevel;
 /// <summary>
 /// 
 /// </summary>
 [BindColumn(20,"a", "treelevel", "","", "NCHAR", 10,0,false, IsPrimaryKey =false ,IsIdentity =false,IsNullable =true,  Length =10 )]
 public  System.Int32 treelevel  { get { return _treelevel; } set { _treelevel = value; } }

 private System.Int32 _plan_level_id;
 /// <summary>
 /// 
 /// </summary>
 [BindColumn(21,"a", "plan_level_id", "","", "NCHAR", 10,0,false, IsPrimaryKey =false ,IsIdentity =false,IsNullable =true,  Length =10 )]
 public  System.Int32 plan_level_id  { get { return _plan_level_id; } set { _plan_level_id = value; } }

 private System.Int32 _discolor;
 /// <summary>
 /// 
 /// </summary>
 [BindColumn(22,"a", "discolor", "","", "NCHAR", 10,0,false, IsPrimaryKey =false ,IsIdentity =false,IsNullable =true,  Length =10 )]
 public  System.Int32 discolor  { get { return _discolor; } set { _discolor = value; } }

 private System.String _project_flag;
 /// <summary>
 /// 
 /// </summary>
 [BindColumn(23,"a", "project_flag", "","", "NCHAR", 1,0,false, IsPrimaryKey =false ,IsIdentity =false,IsNullable =true,  Length =1 )]
 public  System.String project_flag  { get { return _project_flag; } set { _project_flag = value; } }

 private System.DateTime _plan_start_date;
 /// <summary>
 /// 
 /// </summary>
 [BindColumn(24,"a", "plan_start_date", "","", "NCHAR", 3,0,false, IsPrimaryKey =false ,IsIdentity =false,IsNullable =true,  Length =3 )]
 public  System.DateTime plan_start_date  { get { return _plan_start_date; } set { _plan_start_date = value; } }

 private System.DateTime _plan_end_date;
 /// <summary>
 /// 
 /// </summary>
 [BindColumn(25,"a", "plan_end_date", "","", "NCHAR", 3,0,false, IsPrimaryKey =false ,IsIdentity =false,IsNullable =true,  Length =3 )]
 public  System.DateTime plan_end_date  { get { return _plan_end_date; } set { _plan_end_date = value; } }

 private System.DateTime _data_date;
 /// <summary>
 /// 
 /// </summary>
 [BindColumn(26,"a", "data_date", "","", "NCHAR", 3,0,false, IsPrimaryKey =false ,IsIdentity =false,IsNullable =true,  Length =3 )]
 public  System.DateTime data_date  { get { return _data_date; } set { _data_date = value; } }

 private System.DateTime _compute_end_date;
 /// <summary>
 /// 
 /// </summary>
 [BindColumn(27,"a", "compute_end_date", "","", "NCHAR", 3,0,false, IsPrimaryKey =false ,IsIdentity =false,IsNullable =true,  Length =3 )]
 public  System.DateTime compute_end_date  { get { return _compute_end_date; } set { _compute_end_date = value; } }

 private System.DateTime _act_start_date;
 /// <summary>
 /// 
 /// </summary>
 [BindColumn(28,"a", "act_start_date", "","", "NCHAR", 3,0,false, IsPrimaryKey =false ,IsIdentity =false,IsNullable =true,  Length =3 )]
 public  System.DateTime act_start_date  { get { return _act_start_date; } set { _act_start_date = value; } }

 private System.DateTime _act_end_date;
 /// <summary>
 /// 
 /// </summary>
 [BindColumn(29,"a", "act_end_date", "","", "NCHAR", 3,0,false, IsPrimaryKey =false ,IsIdentity =false,IsNullable =true,  Length =3 )]
 public  System.DateTime act_end_date  { get { return _act_end_date; } set { _act_end_date = value; } }

 private System.DateTime _expect_start_date;
 /// <summary>
 /// 
 /// </summary>
 [BindColumn(30,"a", "expect_start_date", "","", "NCHAR", 3,0,false, IsPrimaryKey =false ,IsIdentity =false,IsNullable =true,  Length =3 )]
 public  System.DateTime expect_start_date  { get { return _expect_start_date; } set { _expect_start_date = value; } }

 private System.DateTime _expect_end_date;
 /// <summary>
 /// 
 /// </summary>
 [BindColumn(31,"a", "expect_end_date", "","", "NCHAR", 3,0,false, IsPrimaryKey =false ,IsIdentity =false,IsNullable =true,  Length =3 )]
 public  System.DateTime expect_end_date  { get { return _expect_end_date; } set { _expect_end_date = value; } }

 private System.String _def_duration_type;
 /// <summary>
 /// 
 /// </summary>
 [BindColumn(32,"a", "def_duration_type", "","", "NCHAR", 12,0,false, IsPrimaryKey =false ,IsIdentity =false,IsNullable =true,  Length =12 )]
 public  System.String def_duration_type  { get { return _def_duration_type; } set { _def_duration_type = value; } }

 private System.String _def_complete_pct_type;
 /// <summary>
 /// 
 /// </summary>
 [BindColumn(33,"a", "def_complete_pct_type", "","", "NCHAR", 10,0,false, IsPrimaryKey =false ,IsIdentity =false,IsNullable =true,  Length =10 )]
 public  System.String def_complete_pct_type  { get { return _def_complete_pct_type; } set { _def_complete_pct_type = value; } }

 private System.String _def_task_type;
 /// <summary>
 /// 
 /// </summary>
 [BindColumn(34,"a", "def_task_type", "","", "NCHAR", 12,0,false, IsPrimaryKey =false ,IsIdentity =false,IsNullable =true,  Length =12 )]
 public  System.String def_task_type  { get { return _def_task_type; } set { _def_task_type = value; } }

 private System.Int32 _acct_id;
 /// <summary>
 /// 
 /// </summary>
 [BindColumn(35,"a", "acct_id", "","", "NCHAR", 10,0,false, IsPrimaryKey =false ,IsIdentity =false,IsNullable =true,  Length =10 )]
 public  System.Int32 acct_id  { get { return _acct_id; } set { _acct_id = value; } }

 private System.String _acct_guid;
 /// <summary>
 /// 
 /// </summary>
 [BindColumn(36,"a", "acct_guid", "","", "NCHAR", 38,0,false, IsPrimaryKey =false ,IsIdentity =false,IsNullable =true,  Length =38 )]
 public  System.String acct_guid  { get { return _acct_guid; } set { _acct_guid = value; } }

 private System.Int32 _clndr_id;
 /// <summary>
 /// 
 /// </summary>
 [BindColumn(37,"a", "clndr_id", "","", "NCHAR", 10,0,false, IsPrimaryKey =false ,IsIdentity =false,IsNullable =true,  Length =10 )]
 public  System.Int32 clndr_id  { get { return _clndr_id; } set { _clndr_id = value; } }

 private System.Guid _clndr_guid;
 /// <summary>
 /// 
 /// </summary>
 [BindColumn(38,"a", "clndr_guid", "","", "NCHAR", 0,0,false, IsPrimaryKey =false ,IsIdentity =false,IsNullable =true,  Length =0 )]
 public  System.Guid clndr_guid  { get { return _clndr_guid; } set { _clndr_guid = value; } }

 private System.Int32 _plan_flag_id;
 /// <summary>
 /// 
 /// </summary>
 [BindColumn(39,"a", "plan_flag_id", "","", "NCHAR", 10,0,false, IsPrimaryKey =false ,IsIdentity =false,IsNullable =true,  Length =10 )]
 public  System.Int32 plan_flag_id  { get { return _plan_flag_id; } set { _plan_flag_id = value; } }

 private System.String _task_code_prefix;
 /// <summary>
 /// 
 /// </summary>
 [BindColumn(40,"a", "task_code_prefix", "","", "NCHAR", 50,0,false, IsPrimaryKey =false ,IsIdentity =false,IsNullable =true,  Length =50 )]
 public  System.String task_code_prefix  { get { return _task_code_prefix; } set { _task_code_prefix = value; } }

 private System.Int32 _task_code_base;
 /// <summary>
 /// 
 /// </summary>
 [BindColumn(41,"a", "task_code_base", "","", "NCHAR", 10,0,false, IsPrimaryKey =false ,IsIdentity =false,IsNullable =true,  Length =10 )]
 public  System.Int32 task_code_base  { get { return _task_code_base; } set { _task_code_base = value; } }

 private System.Int32 _task_code_step;
 /// <summary>
 /// 
 /// </summary>
 [BindColumn(42,"a", "task_code_step", "","", "NCHAR", 10,0,false, IsPrimaryKey =false ,IsIdentity =false,IsNullable =true,  Length =10 )]
 public  System.Int32 task_code_step  { get { return _task_code_step; } set { _task_code_step = value; } }

 private System.String _task_code_prefix_flag;
 /// <summary>
 /// 
 /// </summary>
 [BindColumn(43,"a", "task_code_prefix_flag", "","", "NCHAR", 1,0,false, IsPrimaryKey =false ,IsIdentity =false,IsNullable =true,  Length =1 )]
 public  System.String task_code_prefix_flag  { get { return _task_code_prefix_flag; } set { _task_code_prefix_flag = value; } }

 private System.Decimal _critical_drtn_hr_cnt;
 /// <summary>
 /// 
 /// </summary>
 [BindColumn(44,"a", "critical_drtn_hr_cnt", "","", "NCHAR", 10,0,false, IsPrimaryKey =false ,IsIdentity =false,IsNullable =true,  Length =10 )]
 public  System.Decimal critical_drtn_hr_cnt  { get { return _critical_drtn_hr_cnt; } set { _critical_drtn_hr_cnt = value; } }

 private System.String _critical_drtn_hr_cnt_flag;
 /// <summary>
 /// 
 /// </summary>
 [BindColumn(45,"a", "critical_drtn_hr_cnt_flag", "","", "NCHAR", 1,0,false, IsPrimaryKey =false ,IsIdentity =false,IsNullable =true,  Length =1 )]
 public  System.String critical_drtn_hr_cnt_flag  { get { return _critical_drtn_hr_cnt_flag; } set { _critical_drtn_hr_cnt_flag = value; } }

 private System.DateTime _update_date;
 /// <summary>
 /// 
 /// </summary>
 [BindColumn(46,"a", "update_date", "","", "NCHAR", 3,0,false, IsPrimaryKey =false ,IsIdentity =false,IsNullable =true,  Length =3 )]
 public  System.DateTime update_date  { get { return _update_date; } set { _update_date = value; } }

 private System.String _update_user;
 /// <summary>
 /// 
 /// </summary>
 [BindColumn(47,"a", "update_user", "","", "NCHAR", 255,0,false, IsPrimaryKey =false ,IsIdentity =false,IsNullable =true,  Length =255 )]
 public  System.String update_user  { get { return _update_user; } set { _update_user = value; } }

 private System.DateTime _create_date;
 /// <summary>
 /// 
 /// </summary>
 [BindColumn(48,"a", "create_date", "","", "NCHAR", 3,0,false, IsPrimaryKey =false ,IsIdentity =false,IsNullable =true,  Length =3 )]
 public  System.DateTime create_date  { get { return _create_date; } set { _create_date = value; } }

 private System.String _create_user;
 /// <summary>
 /// 
 /// </summary>
 [BindColumn(49,"a", "create_user", "","", "NCHAR", 255,0,false, IsPrimaryKey =false ,IsIdentity =false,IsNullable =true,  Length =255 )]
 public  System.String create_user  { get { return _create_user; } set { _create_user = value; } }

 private System.Int32 _isHistoryVersion;
 /// <summary>
 /// 
 /// </summary>
 [BindColumn(50,"a", "isHistoryVersion", "","", "NCHAR", 10,0,false, IsPrimaryKey =false ,IsIdentity =false,IsNullable =true,  Length =10 )]
 public  System.Int32 isHistoryVersion  { get { return _isHistoryVersion; } set { _isHistoryVersion = value; } }

 private System.Int32 _primaryVersionId;
 /// <summary>
 /// 
 /// </summary>
 [BindColumn(51,"a", "primaryVersionId", "","", "NCHAR", 10,0,false, IsPrimaryKey =false ,IsIdentity =false,IsNullable =true,  Length =10 )]
 public  System.Int32 primaryVersionId  { get { return _primaryVersionId; } set { _primaryVersionId = value; } }

 private System.String _primaryVersion_guid;
 /// <summary>
 /// 
 /// </summary>
 [BindColumn(52,"a", "primaryVersion_guid", "","", "NCHAR", 38,0,false, IsPrimaryKey =false ,IsIdentity =false,IsNullable =true,  Length =38 )]
 public  System.String primaryVersion_guid  { get { return _primaryVersion_guid; } set { _primaryVersion_guid = value; } }

 private System.Int32 _createCompany;
 /// <summary>
 /// 
 /// </summary>
 [BindColumn(53,"a", "createCompany", "","", "NCHAR", 10,0,false, IsPrimaryKey =false ,IsIdentity =false,IsNullable =true,  Length =10 )]
 public  System.Int32 createCompany  { get { return _createCompany; } set { _createCompany = value; } }

 private System.String _memo;
 /// <summary>
 /// 
 /// </summary>
 [BindColumn(54,"a", "memo", "","", "NCHAR", 2147483647,0,false, IsPrimaryKey =false ,IsIdentity =false,IsNullable =true,  Length =2147483647 )]
 public  System.String memo  { get { return _memo; } set { _memo = value; } }

 private System.String _versionCode;
 /// <summary>
 /// 
 /// </summary>
 [BindColumn(55,"a", "versionCode", "","", "NCHAR", 50,0,false, IsPrimaryKey =false ,IsIdentity =false,IsNullable =true,  Length =50 )]
 public  System.String versionCode  { get { return _versionCode; } set { _versionCode = value; } }

 private System.Int32 _state;
 /// <summary>
 /// 
 /// </summary>
 [BindColumn(56,"a", "state", "","", "NCHAR", 10,0,false, IsPrimaryKey =false ,IsIdentity =false,IsNullable =true,  Length =10 )]
 public  System.Int32 state  { get { return _state; } set { _state = value; } }

 private System.DateTime _add_date;
 /// <summary>
 /// 
 /// </summary>
 [BindColumn(57,"a", "add_date", "","", "NCHAR", 3,0,false, IsPrimaryKey =false ,IsIdentity =false,IsNullable =true,  Length =3 )]
 public  System.DateTime add_date  { get { return _add_date; } set { _add_date = value; } }

 private System.Int32 _module_type;
 /// <summary>
 /// 
 /// </summary>
 [BindColumn(58,"a", "module_type", "","", "NCHAR", 10,0,false, IsPrimaryKey =false ,IsIdentity =false,IsNullable =true,  Length =10 )]
 public  System.Int32 module_type  { get { return _module_type; } set { _module_type = value; } }

 private System.Int32 _feedbackType;
 /// <summary>
 /// 
 /// </summary>
 [BindColumn(59,"a", "feedbackType", "","", "NCHAR", 10,0,false, IsPrimaryKey =false ,IsIdentity =false,IsNullable =true,  Length =10 )]
 public  System.Int32 feedbackType  { get { return _feedbackType; } set { _feedbackType = value; } }

      
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
			    if (name == "EST_WT_VALUE")
{
return _est_wt_value;
}
if (name == "PROJ_PLAN_ID")
{
return _proj_plan_id;
}
if (name == "APPRHUMNAME")
{
return _apprhumname;
}
if (name == "PLANTYPE")
{
return _plantype;
}
if (name == "RECEIVE_DATE")
{
return _receive_date;
}
if (name == "PLANFILTER")
{
return _planfilter;
}
if (name == "APPRHUMID")
{
return _apprhumid;
}
if (name == "COMPLETE_PCT")
{
return _complete_pct;
}
if (name == "BASELINE_PLAN_GUID")
{
return _baseline_plan_guid;
}
if (name == "RECEIVE_USER")
{
return _receive_user;
}
if (name == "UPDATE_USER_GUID")
{
return _update_user_guid;
}
if (name == "APPRDATE")
{
return _apprdate;
}
if (name == "STATUS")
{
return _status;
}
if (name == "FEEDBACK_PCT_TYPE")
{
return _feedback_pct_type;
}
if (name == "CREATE_USER_GUID")
{
return _create_user_guid;
}
if (name == "PERIOD_GUID")
{
return _period_guid;
}
if (name == "RECEIVE_USER_GUID")
{
return _receive_user_guid;
}
if (name == "PROJ_PLAN_GUID")
{
return _proj_plan_guid;
}
if (name == "PROJ_ID")
{
return _proj_id;
}
if (name == "PROJ_GUID")
{
return _proj_guid;
}
if (name == "STATUS_CODE")
{
return _status_code;
}
if (name == "RECORD_STATUS")
{
return _record_status;
}
if (name == "OBS_ID")
{
return _obs_id;
}
if (name == "OBS_GUID")
{
return _obs_guid;
}
if (name == "RISK_LEVEL")
{
return _risk_level;
}
if (name == "PRIORITY_NUM")
{
return _priority_num;
}
if (name == "CHECKOUT_FLAG")
{
return _checkout_flag;
}
if (name == "CHECKOUT_DATE")
{
return _checkout_date;
}
if (name == "CHECKOUT_USER_ID")
{
return _checkout_user_id;
}
if (name == "WEB_LOCAL_ROOT_PATH")
{
return _web_local_root_path;
}
if (name == "PARENT_PLAN_ID")
{
return _parent_plan_id;
}
if (name == "PARENT_PLAN_GUID")
{
return _parent_plan_guid;
}
if (name == "PLAN_NAME")
{
return _plan_name;
}
if (name == "PLAN_SHORT_NAME")
{
return _plan_short_name;
}
if (name == "HASCHILD")
{
return _haschild;
}
if (name == "TREELEVEL")
{
return _treelevel;
}
if (name == "PLAN_LEVEL_ID")
{
return _plan_level_id;
}
if (name == "DISCOLOR")
{
return _discolor;
}
if (name == "PROJECT_FLAG")
{
return _project_flag;
}
if (name == "PLAN_START_DATE")
{
return _plan_start_date;
}
if (name == "PLAN_END_DATE")
{
return _plan_end_date;
}
if (name == "DATA_DATE")
{
return _data_date;
}
if (name == "COMPUTE_END_DATE")
{
return _compute_end_date;
}
if (name == "ACT_START_DATE")
{
return _act_start_date;
}
if (name == "ACT_END_DATE")
{
return _act_end_date;
}
if (name == "EXPECT_START_DATE")
{
return _expect_start_date;
}
if (name == "EXPECT_END_DATE")
{
return _expect_end_date;
}
if (name == "DEF_DURATION_TYPE")
{
return _def_duration_type;
}
if (name == "DEF_COMPLETE_PCT_TYPE")
{
return _def_complete_pct_type;
}
if (name == "DEF_TASK_TYPE")
{
return _def_task_type;
}
if (name == "ACCT_ID")
{
return _acct_id;
}
if (name == "ACCT_GUID")
{
return _acct_guid;
}
if (name == "CLNDR_ID")
{
return _clndr_id;
}
if (name == "CLNDR_GUID")
{
return _clndr_guid;
}
if (name == "PLAN_FLAG_ID")
{
return _plan_flag_id;
}
if (name == "TASK_CODE_PREFIX")
{
return _task_code_prefix;
}
if (name == "TASK_CODE_BASE")
{
return _task_code_base;
}
if (name == "TASK_CODE_STEP")
{
return _task_code_step;
}
if (name == "TASK_CODE_PREFIX_FLAG")
{
return _task_code_prefix_flag;
}
if (name == "CRITICAL_DRTN_HR_CNT")
{
return _critical_drtn_hr_cnt;
}
if (name == "CRITICAL_DRTN_HR_CNT_FLAG")
{
return _critical_drtn_hr_cnt_flag;
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
if (name == "ISHISTORYVERSION")
{
return _isHistoryVersion;
}
if (name == "PRIMARYVERSIONID")
{
return _primaryVersionId;
}
if (name == "PRIMARYVERSION_GUID")
{
return _primaryVersion_guid;
}
if (name == "CREATECOMPANY")
{
return _createCompany;
}
if (name == "MEMO")
{
return _memo;
}
if (name == "VERSIONCODE")
{
return _versionCode;
}
if (name == "STATE")
{
return _state;
}
if (name == "ADD_DATE")
{
return _add_date;
}
if (name == "MODULE_TYPE")
{
return _module_type;
}
if (name == "FEEDBACKTYPE")
{
return _feedbackType;
}

			    return base[name];
			}
			set 
			{
			   name = name.ToUpper();
			       if (name == "EST_WT_VALUE")
{
 _est_wt_value = System.Convert.ToDecimal(value);return;
}
if (name == "PROJ_PLAN_ID")
{
 _proj_plan_id = System.Convert.ToInt32(value);return;
}
if (name == "APPRHUMNAME")
{
 _apprhumname = System.Convert.ToString(value);return;
}
if (name == "PLANTYPE")
{
 _plantype = System.Convert.ToString(value);return;
}
if (name == "RECEIVE_DATE")
{
 if (value == null || value.ToString().IsNullOrEmpty() == true) value = DateTime.MinValue;
 _receive_date = System.Convert.ToDateTime(value);return;
}
if (name == "PLANFILTER")
{
 _planfilter = System.Convert.ToString(value);return;
}
if (name == "APPRHUMID")
{
 _apprhumid = XCode.Common.Helper.ConvertToGuid(value);return;
}
if (name == "COMPLETE_PCT")
{
 _complete_pct = System.Convert.ToDecimal(value);return;
}
if (name == "BASELINE_PLAN_GUID")
{
 _baseline_plan_guid = System.Convert.ToString(value);return;
}
if (name == "RECEIVE_USER")
{
 _receive_user = System.Convert.ToString(value);return;
}
if (name == "UPDATE_USER_GUID")
{
 _update_user_guid = XCode.Common.Helper.ConvertToGuid(value);return;
}
if (name == "APPRDATE")
{
 if (value == null || value.ToString().IsNullOrEmpty() == true) value = DateTime.MinValue;
 _apprdate = System.Convert.ToDateTime(value);return;
}
if (name == "STATUS")
{
 _status = System.Convert.ToInt16(value);return;
}
if (name == "FEEDBACK_PCT_TYPE")
{
 _feedback_pct_type = System.Convert.ToString(value);return;
}
if (name == "CREATE_USER_GUID")
{
 _create_user_guid = XCode.Common.Helper.ConvertToGuid(value);return;
}
if (name == "PERIOD_GUID")
{
 _period_guid = System.Convert.ToString(value);return;
}
if (name == "RECEIVE_USER_GUID")
{
 _receive_user_guid = XCode.Common.Helper.ConvertToGuid(value);return;
}
if (name == "PROJ_PLAN_GUID")
{
 _proj_plan_guid = XCode.Common.Helper.ConvertToGuid(value);return;
}
if (name == "PROJ_ID")
{
 _proj_id = System.Convert.ToInt32(value);return;
}
if (name == "PROJ_GUID")
{
 _proj_guid = XCode.Common.Helper.ConvertToGuid(value);return;
}
if (name == "STATUS_CODE")
{
 _status_code = System.Convert.ToInt32(value);return;
}
if (name == "RECORD_STATUS")
{
 _record_status = System.Convert.ToInt32(value);return;
}
if (name == "OBS_ID")
{
 _obs_id = System.Convert.ToInt32(value);return;
}
if (name == "OBS_GUID")
{
 _obs_guid = System.Convert.ToString(value);return;
}
if (name == "RISK_LEVEL")
{
 _risk_level = System.Convert.ToInt32(value);return;
}
if (name == "PRIORITY_NUM")
{
 _priority_num = System.Convert.ToInt32(value);return;
}
if (name == "CHECKOUT_FLAG")
{
 _checkout_flag = System.Convert.ToString(value);return;
}
if (name == "CHECKOUT_DATE")
{
 if (value == null || value.ToString().IsNullOrEmpty() == true) value = DateTime.MinValue;
 _checkout_date = System.Convert.ToDateTime(value);return;
}
if (name == "CHECKOUT_USER_ID")
{
 _checkout_user_id = System.Convert.ToInt32(value);return;
}
if (name == "WEB_LOCAL_ROOT_PATH")
{
 _web_local_root_path = System.Convert.ToString(value);return;
}
if (name == "PARENT_PLAN_ID")
{
 _parent_plan_id = System.Convert.ToInt32(value);return;
}
if (name == "PARENT_PLAN_GUID")
{
 _parent_plan_guid = System.Convert.ToString(value);return;
}
if (name == "PLAN_NAME")
{
 _plan_name = System.Convert.ToString(value);return;
}
if (name == "PLAN_SHORT_NAME")
{
 _plan_short_name = System.Convert.ToString(value);return;
}
if (name == "HASCHILD")
{
 _haschild = System.Convert.ToInt32(value);return;
}
if (name == "TREELEVEL")
{
 _treelevel = System.Convert.ToInt32(value);return;
}
if (name == "PLAN_LEVEL_ID")
{
 _plan_level_id = System.Convert.ToInt32(value);return;
}
if (name == "DISCOLOR")
{
 _discolor = System.Convert.ToInt32(value);return;
}
if (name == "PROJECT_FLAG")
{
 _project_flag = System.Convert.ToString(value);return;
}
if (name == "PLAN_START_DATE")
{
 if (value == null || value.ToString().IsNullOrEmpty() == true) value = DateTime.MinValue;
 _plan_start_date = System.Convert.ToDateTime(value);return;
}
if (name == "PLAN_END_DATE")
{
 if (value == null || value.ToString().IsNullOrEmpty() == true) value = DateTime.MinValue;
 _plan_end_date = System.Convert.ToDateTime(value);return;
}
if (name == "DATA_DATE")
{
 if (value == null || value.ToString().IsNullOrEmpty() == true) value = DateTime.MinValue;
 _data_date = System.Convert.ToDateTime(value);return;
}
if (name == "COMPUTE_END_DATE")
{
 if (value == null || value.ToString().IsNullOrEmpty() == true) value = DateTime.MinValue;
 _compute_end_date = System.Convert.ToDateTime(value);return;
}
if (name == "ACT_START_DATE")
{
 if (value == null || value.ToString().IsNullOrEmpty() == true) value = DateTime.MinValue;
 _act_start_date = System.Convert.ToDateTime(value);return;
}
if (name == "ACT_END_DATE")
{
 if (value == null || value.ToString().IsNullOrEmpty() == true) value = DateTime.MinValue;
 _act_end_date = System.Convert.ToDateTime(value);return;
}
if (name == "EXPECT_START_DATE")
{
 if (value == null || value.ToString().IsNullOrEmpty() == true) value = DateTime.MinValue;
 _expect_start_date = System.Convert.ToDateTime(value);return;
}
if (name == "EXPECT_END_DATE")
{
 if (value == null || value.ToString().IsNullOrEmpty() == true) value = DateTime.MinValue;
 _expect_end_date = System.Convert.ToDateTime(value);return;
}
if (name == "DEF_DURATION_TYPE")
{
 _def_duration_type = System.Convert.ToString(value);return;
}
if (name == "DEF_COMPLETE_PCT_TYPE")
{
 _def_complete_pct_type = System.Convert.ToString(value);return;
}
if (name == "DEF_TASK_TYPE")
{
 _def_task_type = System.Convert.ToString(value);return;
}
if (name == "ACCT_ID")
{
 _acct_id = System.Convert.ToInt32(value);return;
}
if (name == "ACCT_GUID")
{
 _acct_guid = System.Convert.ToString(value);return;
}
if (name == "CLNDR_ID")
{
 _clndr_id = System.Convert.ToInt32(value);return;
}
if (name == "CLNDR_GUID")
{
 _clndr_guid = XCode.Common.Helper.ConvertToGuid(value);return;
}
if (name == "PLAN_FLAG_ID")
{
 _plan_flag_id = System.Convert.ToInt32(value);return;
}
if (name == "TASK_CODE_PREFIX")
{
 _task_code_prefix = System.Convert.ToString(value);return;
}
if (name == "TASK_CODE_BASE")
{
 _task_code_base = System.Convert.ToInt32(value);return;
}
if (name == "TASK_CODE_STEP")
{
 _task_code_step = System.Convert.ToInt32(value);return;
}
if (name == "TASK_CODE_PREFIX_FLAG")
{
 _task_code_prefix_flag = System.Convert.ToString(value);return;
}
if (name == "CRITICAL_DRTN_HR_CNT")
{
 _critical_drtn_hr_cnt = System.Convert.ToDecimal(value);return;
}
if (name == "CRITICAL_DRTN_HR_CNT_FLAG")
{
 _critical_drtn_hr_cnt_flag = System.Convert.ToString(value);return;
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
if (name == "ISHISTORYVERSION")
{
 _isHistoryVersion = System.Convert.ToInt32(value);return;
}
if (name == "PRIMARYVERSIONID")
{
 _primaryVersionId = System.Convert.ToInt32(value);return;
}
if (name == "PRIMARYVERSION_GUID")
{
 _primaryVersion_guid = System.Convert.ToString(value);return;
}
if (name == "CREATECOMPANY")
{
 _createCompany = System.Convert.ToInt32(value);return;
}
if (name == "MEMO")
{
 _memo = System.Convert.ToString(value);return;
}
if (name == "VERSIONCODE")
{
 _versionCode = System.Convert.ToString(value);return;
}
if (name == "STATE")
{
 _state = System.Convert.ToInt32(value);return;
}
if (name == "ADD_DATE")
{
 if (value == null || value.ToString().IsNullOrEmpty() == true) value = DateTime.MinValue;
 _add_date = System.Convert.ToDateTime(value);return;
}
if (name == "MODULE_TYPE")
{
 _module_type = System.Convert.ToInt32(value);return;
}
if (name == "FEEDBACKTYPE")
{
 _feedbackType = System.Convert.ToInt32(value);return;
}

			    base[name] = value;
			}
		}
		#endregion
	}
}