 
 
 using    System;
 using System.Collections.Generic;
 using System.Text; 
 using XCode.Attributes    ;

 namespace  Power.Systems.StdSystem
{
    /// <summary>
    /// TASK
    /// </summary>
    public class TASKDO : TASKDO<TASKDO>
    {

    }

	/// <summary>
    /// TASK
    /// </summary>
	  [BindEntity(KeyWord="TASK",EntityType = typeof(Power.Systems.StdSystem.TASKDO),Description = "TASK"  )] 

	 [BindTable( "PLN_task", Alias = "a",IsAttach=false,Description ="")]

	  [BindIndex(Name = "pk_PLN_task", KeyType = Power.DataAccessLayer.KeyType.MainKey, Columns = "task_guid", TableName = "PLN_task",Description="")]

    public   class TASKDO<TEntity> : XCode.Entity<TEntity>, XCode.IEntity where TEntity : Power.Systems.StdSystem.TASKDO<TEntity>, new()
    { 
	    #region 属性

	    
 private System.Decimal _target_progress_rsrc_qty;
 /// <summary>
 /// 
 /// </summary>
 [BindColumn(1,"a", "target_progress_rsrc_qty", "","", "NCHAR", 17,6,false, IsPrimaryKey =false ,IsIdentity =false,IsNullable =true,  Length =17 )]
 public  System.Decimal target_progress_rsrc_qty  { get { return _target_progress_rsrc_qty; } set { _target_progress_rsrc_qty = value; } }

 private System.String _target_progress_rsrc_guid;
 /// <summary>
 /// 
 /// </summary>
 [BindColumn(1,"a", "target_progress_rsrc_guid", "","", "NCHAR", 38,0,false, IsPrimaryKey =false ,IsIdentity =false,IsNullable =true,  Length =38 )]
 public  System.String target_progress_rsrc_guid  { get { return _target_progress_rsrc_guid; } set { _target_progress_rsrc_guid = value; } }

 private System.Decimal _act_progress_rsrc_qty;
 /// <summary>
 /// 
 /// </summary>
 [BindColumn(1,"a", "act_progress_rsrc_qty", "","", "NCHAR", 17,6,false, IsPrimaryKey =false ,IsIdentity =false,IsNullable =true,  Length =17 )]
 public  System.Decimal act_progress_rsrc_qty  { get { return _act_progress_rsrc_qty; } set { _act_progress_rsrc_qty = value; } }

 private System.String _remain_progress_rsrc_curv;
 /// <summary>
 /// 
 /// </summary>
 [BindColumn(1,"a", "remain_progress_rsrc_curv", "","", "NCHAR", 4000,0,false, IsPrimaryKey =false ,IsIdentity =false,IsNullable =true,  Length =4000 )]
 public  System.String remain_progress_rsrc_curv  { get { return _remain_progress_rsrc_curv; } set { _remain_progress_rsrc_curv = value; } }

 private System.Int32 _task_id;
 /// <summary>
 /// 
 /// </summary>
 [BindColumn(1,"a", "task_id", "","", "NCHAR", 10,0,false, IsAutoInsert =true , IsPrimaryKey =false ,IsIdentity =false,IsNullable =false,  Length =10 )]
 public  System.Int32 task_id  { get { return _task_id; } set { _task_id = value; } }

 private System.Decimal _bcwp_cost;
 /// <summary>
 /// 
 /// </summary>
 [BindColumn(1,"a", "bcwp_cost", "","", "NCHAR", 23,6,false, IsPrimaryKey =false ,IsIdentity =false,IsNullable =true,  Length =23 )]
 public  System.Decimal bcwp_cost  { get { return _bcwp_cost; } set { _bcwp_cost = value; } }

 private System.DateTime _baseline3_start_date;
 /// <summary>
 /// 
 /// </summary>
 [BindColumn(1,"a", "baseline3_start_date", "","", "NCHAR", 3,0,false, IsPrimaryKey =false ,IsIdentity =false,IsNullable =true,  Length =3 )]
 public  System.DateTime baseline3_start_date  { get { return _baseline3_start_date; } set { _baseline3_start_date = value; } }

 private System.Decimal _progress_rsrc_unit_price;
 /// <summary>
 /// 
 /// </summary>
 [BindColumn(1,"a", "progress_rsrc_unit_price", "","", "NCHAR", 23,6,false, IsPrimaryKey =false ,IsIdentity =false,IsNullable =true,  Length =23 )]
 public  System.Decimal progress_rsrc_unit_price  { get { return _progress_rsrc_unit_price; } set { _progress_rsrc_unit_price = value; } }

 private System.String _curve_guid;
 /// <summary>
 /// 检测曲线
 /// </summary>
 [BindColumn(1,"a", "curve_guid", "检测曲线","", "NCHAR", 38,0,false, IsPrimaryKey =false ,IsIdentity =false,IsNullable =true,  Length =38 )]
 public  System.String curve_guid  { get { return _curve_guid; } set { _curve_guid = value; } }

 private System.String _progress_rsrc_unit_name;
 /// <summary>
 /// 
 /// </summary>
 [BindColumn(1,"a", "progress_rsrc_unit_name", "","", "NCHAR", 100,0,false, IsPrimaryKey =false ,IsIdentity =false,IsNullable =true,  Length =100 )]
 public  System.String progress_rsrc_unit_name  { get { return _progress_rsrc_unit_name; } set { _progress_rsrc_unit_name = value; } }

 private System.String _target_progress_rsrc_curv;
 /// <summary>
 /// 
 /// </summary>
 [BindColumn(1,"a", "target_progress_rsrc_curv", "","", "NCHAR", 4000,0,false, IsPrimaryKey =false ,IsIdentity =false,IsNullable =true,  Length =4000 )]
 public  System.String target_progress_rsrc_curv  { get { return _target_progress_rsrc_curv; } set { _target_progress_rsrc_curv = value; } }

 private System.Decimal _bcws_cost;
 /// <summary>
 /// 
 /// </summary>
 [BindColumn(1,"a", "bcws_cost", "","", "NCHAR", 23,6,false, IsPrimaryKey =false ,IsIdentity =false,IsNullable =true,  Length =23 )]
 public  System.Decimal bcws_cost  { get { return _bcws_cost; } set { _bcws_cost = value; } }

 private System.DateTime _baseline3_end_date;
 /// <summary>
 /// 
 /// </summary>
 [BindColumn(1,"a", "baseline3_end_date", "","", "NCHAR", 3,0,false, IsPrimaryKey =false ,IsIdentity =false,IsNullable =true,  Length =3 )]
 public  System.DateTime baseline3_end_date  { get { return _baseline3_end_date; } set { _baseline3_end_date = value; } }

 private System.DateTime _baseline2_end_date;
 /// <summary>
 /// 
 /// </summary>
 [BindColumn(1,"a", "baseline2_end_date", "","", "NCHAR", 3,0,false, IsPrimaryKey =false ,IsIdentity =false,IsNullable =true,  Length =3 )]
 public  System.DateTime baseline2_end_date  { get { return _baseline2_end_date; } set { _baseline2_end_date = value; } }

 private System.Decimal _target_progress_rsrc_cost;
 /// <summary>
 /// 
 /// </summary>
 [BindColumn(1,"a", "target_progress_rsrc_cost", "","", "NCHAR", 23,6,false, IsPrimaryKey =false ,IsIdentity =false,IsNullable =true,  Length =23 )]
 public  System.Decimal target_progress_rsrc_cost  { get { return _target_progress_rsrc_cost; } set { _target_progress_rsrc_cost = value; } }

 private System.Decimal _remain_progress_rsrc_qty;
 /// <summary>
 /// 
 /// </summary>
 [BindColumn(1,"a", "remain_progress_rsrc_qty", "","", "NCHAR", 17,6,false, IsPrimaryKey =false ,IsIdentity =false,IsNullable =true,  Length =17 )]
 public  System.Decimal remain_progress_rsrc_qty  { get { return _remain_progress_rsrc_qty; } set { _remain_progress_rsrc_qty = value; } }

 private System.String _target_progress_rsrc_code;
 /// <summary>
 /// 
 /// </summary>
 [BindColumn(1,"a", "target_progress_rsrc_code", "","", "NCHAR", 40,0,false, IsPrimaryKey =false ,IsIdentity =false,IsNullable =true,  Length =40 )]
 public  System.String target_progress_rsrc_code  { get { return _target_progress_rsrc_code; } set { _target_progress_rsrc_code = value; } }

 private System.Int32 _istopbreakdown;
 /// <summary>
 /// 
 /// </summary>
 [BindColumn(1,"a", "istopbreakdown", "","", "NCHAR", 10,0,false, IsPrimaryKey =false ,IsIdentity =false,IsNullable =true,  Length =10 )]
 public  System.Int32 istopbreakdown  { get { return _istopbreakdown; } set { _istopbreakdown = value; } }

 private System.DateTime _baseline2_start_date;
 /// <summary>
 /// 
 /// </summary>
 [BindColumn(1,"a", "baseline2_start_date", "","", "NCHAR", 3,0,false, IsPrimaryKey =false ,IsIdentity =false,IsNullable =true,  Length =3 )]
 public  System.DateTime baseline2_start_date  { get { return _baseline2_start_date; } set { _baseline2_start_date = value; } }

 private System.DateTime _baseline_start_date;
 /// <summary>
 /// 
 /// </summary>
 [BindColumn(1,"a", "baseline_start_date", "","", "NCHAR", 3,0,false, IsPrimaryKey =false ,IsIdentity =false,IsNullable =true,  Length =3 )]
 public  System.DateTime baseline_start_date  { get { return _baseline_start_date; } set { _baseline_start_date = value; } }

 private System.Decimal _est_wt;
 /// <summary>
 /// 
 /// </summary>
 [BindColumn(1,"a", "est_wt", "","", "NCHAR", 17,6,false, IsPrimaryKey =false ,IsIdentity =false,IsNullable =true,  Length =17 )]
 public  System.Decimal est_wt  { get { return _est_wt; } set { _est_wt = value; } }

 private System.Decimal _est_wt_pct;
 /// <summary>
 /// 
 /// </summary>
 [BindColumn(1,"a", "est_wt_pct", "","", "NCHAR", 17,2,false, IsPrimaryKey =false ,IsIdentity =false,IsNullable =true,  Length =17 )]
 public  System.Decimal est_wt_pct  { get { return _est_wt_pct; } set { _est_wt_pct = value; } }

 private System.Decimal _remain_progress_rsrc_cost;
 /// <summary>
 /// 
 /// </summary>
 [BindColumn(1,"a", "remain_progress_rsrc_cost", "","", "NCHAR", 23,6,false, IsPrimaryKey =false ,IsIdentity =false,IsNullable =true,  Length =23 )]
 public  System.Decimal remain_progress_rsrc_cost  { get { return _remain_progress_rsrc_cost; } set { _remain_progress_rsrc_cost = value; } }

 private System.String _act_progress_rsrc_curv;
 /// <summary>
 /// 
 /// </summary>
 [BindColumn(1,"a", "act_progress_rsrc_curv", "","", "NCHAR", 4000,0,false, IsPrimaryKey =false ,IsIdentity =false,IsNullable =true,  Length =4000 )]
 public  System.String act_progress_rsrc_curv  { get { return _act_progress_rsrc_curv; } set { _act_progress_rsrc_curv = value; } }

 private System.Decimal _act_progress_rsrc_cost;
 /// <summary>
 /// 
 /// </summary>
 [BindColumn(1,"a", "act_progress_rsrc_cost", "","", "NCHAR", 23,6,false, IsPrimaryKey =false ,IsIdentity =false,IsNullable =true,  Length =23 )]
 public  System.Decimal act_progress_rsrc_cost  { get { return _act_progress_rsrc_cost; } set { _act_progress_rsrc_cost = value; } }

 private System.DateTime _baseline_end_date;
 /// <summary>
 /// 
 /// </summary>
 [BindColumn(1,"a", "baseline_end_date", "","", "NCHAR", 3,0,false, IsPrimaryKey =false ,IsIdentity =false,IsNullable =true,  Length =3 )]
 public  System.DateTime baseline_end_date  { get { return _baseline_end_date; } set { _baseline_end_date = value; } }

 private System.String _feedback_pct_type;
 /// <summary>
 /// 检测方式
 /// </summary>
 [BindColumn(1,"a", "feedback_pct_type", "检测方式","", "NCHAR", 38,0,false, IsPrimaryKey =false ,IsIdentity =false,IsNullable =true,  Length =38 )]
 public  System.String feedback_pct_type  { get { return _feedback_pct_type; } set { _feedback_pct_type = value; } }

 private System.Decimal _acwp_cost;
 /// <summary>
 /// 
 /// </summary>
 [BindColumn(1,"a", "acwp_cost", "","", "NCHAR", 23,6,false, IsPrimaryKey =false ,IsIdentity =false,IsNullable =true,  Length =23 )]
 public  System.Decimal acwp_cost  { get { return _acwp_cost; } set { _acwp_cost = value; } }

 private System.String _task_guid;
 /// <summary>
 /// 
 /// </summary>
 [BindColumn(2,"a", "task_guid", "","", "NCHAR", 38,0,false, IsPrimaryKey =true ,IsIdentity =true,IsNullable =false,  Length =38 )]
 public virtual System.String task_guid  { get { return _task_guid; } set { _task_guid = value; } }

 private System.Int32 _proj_id;
 /// <summary>
 /// 
 /// </summary>
 [BindColumn(3,"a", "proj_id", "","", "NCHAR", 10,0,false, IsPrimaryKey =false ,IsIdentity =false,IsNullable =false,  Length =10 )]
 public  System.Int32 proj_id  { get { return _proj_id; } set { _proj_id = value; } }

 private System.String _proj_guid;
 /// <summary>
 /// 
 /// </summary>
 [BindColumn(4,"a", "proj_guid", "","", "NCHAR", 38,0,false, IsPrimaryKey =false ,IsIdentity =false,IsNullable =false,  Length =38 )]
 public  System.String proj_guid  { get { return _proj_guid; } set { _proj_guid = value; } }

 private System.Int32 _wbs_id;
 /// <summary>
 /// 
 /// </summary>
 [BindColumn(5,"a", "wbs_id", "","", "NCHAR", 10,0,false, IsPrimaryKey =false ,IsIdentity =false,IsNullable =true,  Length =10 )]
 public  System.Int32 wbs_id  { get { return _wbs_id; } set { _wbs_id = value; } }

 private System.String _wbs_guid;
 /// <summary>
 /// 
 /// </summary>
 [BindColumn(6,"a", "wbs_guid", "","", "NCHAR", 38,0,false, IsPrimaryKey =false ,IsIdentity =false,IsNullable =true,  Length =38 )]
 public  System.String wbs_guid  { get { return _wbs_guid; } set { _wbs_guid = value; } }

 private System.Int32 _clndr_id;
 /// <summary>
 /// 
 /// </summary>
 [BindColumn(7,"a", "clndr_id", "","", "NCHAR", 10,0,false, IsPrimaryKey =false ,IsIdentity =false,IsNullable =true,  Length =10 )]
 public  System.Int32 clndr_id  { get { return _clndr_id; } set { _clndr_id = value; } }

 private System.String _clndr_guid;
 /// <summary>
 /// 
 /// </summary>
 [BindColumn(8,"a", "clndr_guid", "","", "NCHAR", 38,0,false, IsPrimaryKey =false ,IsIdentity =false,IsNullable =true,  Length =38 )]
 public  System.String clndr_guid  { get { return _clndr_guid; } set { _clndr_guid = value; } }

 private System.Int32 _plan_id;
 /// <summary>
 /// 
 /// </summary>
 [BindColumn(9,"a", "plan_id", "","", "NCHAR", 10,0,false, IsPrimaryKey =false ,IsIdentity =false,IsNullable =true,  Length =10 )]
 public  System.Int32 plan_id  { get { return _plan_id; } set { _plan_id = value; } }

 private System.String _plan_guid;
 /// <summary>
 /// 
 /// </summary>
 [BindColumn(10,"a", "plan_guid", "","", "NCHAR", 38,0,false, IsPrimaryKey =false ,IsIdentity =false,IsNullable =true,  Length =38 )]
 public  System.String plan_guid  { get { return _plan_guid; } set { _plan_guid = value; } }

 private System.Int32 _seq_num;
 /// <summary>
 /// 
 /// </summary>
 [BindColumn(11,"a", "seq_num", "","", "NCHAR", 10,0,false, IsPrimaryKey =false ,IsIdentity =false,IsNullable =true,  Length =10 )]
 public  System.Int32 seq_num  { get { return _seq_num; } set { _seq_num = value; } }

 private System.Int32 _parent_task_id;
 /// <summary>
 /// 
 /// </summary>
 [BindColumn(12,"a", "parent_task_id", "","", "NCHAR", 10,0,false, IsPrimaryKey =false ,IsIdentity =false,IsNullable =true,  Length =10 )]
 public  System.Int32 parent_task_id  { get { return _parent_task_id; } set { _parent_task_id = value; } }

 private System.String _parent_guid;
 /// <summary>
 /// 
 /// </summary>
 [BindColumn(13,"a", "parent_guid", "","", "NCHAR", 38,0,false, IsPrimaryKey =false ,IsIdentity =false,IsNullable =true,  Length =38 )]
 public  System.String parent_guid  { get { return _parent_guid; } set { _parent_guid = value; } }

 private System.Decimal _complete_pct;
 /// <summary>
 /// 
 /// </summary>
 [BindColumn(15,"a", "complete_pct", "","", "NCHAR", 18,3,false, IsPrimaryKey =false ,IsIdentity =false,IsNullable =true,  Length =18 )]
 public  System.Decimal complete_pct  { get { return _complete_pct; } set { _complete_pct = value; } }

 private System.String _rev_fdbk_flag;
 /// <summary>
 /// 
 /// </summary>
 [BindColumn(16,"a", "rev_fdbk_flag", "","", "NCHAR", 1,0,false, IsPrimaryKey =false ,IsIdentity =false,IsNullable =true,  Length =1 )]
 public  System.String rev_fdbk_flag  { get { return _rev_fdbk_flag; } set { _rev_fdbk_flag = value; } }

 private System.String _lock_plan_flag;
 /// <summary>
 /// 
 /// </summary>
 [BindColumn(17,"a", "lock_plan_flag", "","", "NCHAR", 1,0,false, IsPrimaryKey =false ,IsIdentity =false,IsNullable =true,  Length =1 )]
 public  System.String lock_plan_flag  { get { return _lock_plan_flag; } set { _lock_plan_flag = value; } }

 private System.String _auto_compute_act_flag;
 /// <summary>
 /// 
 /// </summary>
 [BindColumn(18,"a", "auto_compute_act_flag", "","", "NCHAR", 1,0,false, IsPrimaryKey =false ,IsIdentity =false,IsNullable =true,  Length =1 )]
 public  System.String auto_compute_act_flag  { get { return _auto_compute_act_flag; } set { _auto_compute_act_flag = value; } }

 private System.String _complete_pct_type;
 /// <summary>
 /// 
 /// </summary>
 [BindColumn(19,"a", "complete_pct_type", "","", "NCHAR", 10,0,false, IsPrimaryKey =false ,IsIdentity =false,IsNullable =true,  Length =10 )]
 public  System.String complete_pct_type  { get { return _complete_pct_type; } set { _complete_pct_type = value; } }

 private System.String _task_type;
 /// <summary>
 /// 
 /// </summary>
 [BindColumn(20,"a", "task_type", "","", "NCHAR", 10,0,false, IsPrimaryKey =false ,IsIdentity =false,IsNullable =true,  Length =10 )]
 public  System.String task_type  { get { return _task_type; } set { _task_type = value; } }

 private System.String _duration_type;
 /// <summary>
 /// 
 /// </summary>
 [BindColumn(21,"a", "duration_type", "","", "NCHAR", 12,0,false, IsPrimaryKey =false ,IsIdentity =false,IsNullable =true,  Length =12 )]
 public  System.String duration_type  { get { return _duration_type; } set { _duration_type = value; } }

 private System.String _review_type;
 /// <summary>
 /// 
 /// </summary>
 [BindColumn(22,"a", "review_type", "","", "NCHAR", 12,0,false, IsPrimaryKey =false ,IsIdentity =false,IsNullable =true,  Length =12 )]
 public  System.String review_type  { get { return _review_type; } set { _review_type = value; } }

 private System.String _status_code;
 /// <summary>
 /// 
 /// </summary>
 [BindColumn(23,"a", "status_code", "","", "NCHAR", 12,0,false, IsPrimaryKey =false ,IsIdentity =false,IsNullable =true,  Length =12 )]
 public  System.String status_code  { get { return _status_code; } set { _status_code = value; } }

 private System.String _task_code;
 /// <summary>
 /// 
 /// </summary>
 [BindColumn(24,"a", "task_code", "","", "NCHAR", 100,0,false, IsPrimaryKey =false ,IsIdentity =false,IsNullable =false,  Length =100 )]
 public  System.String task_code  { get { return _task_code; } set { _task_code = value; } }

 private System.String _task_name;
 /// <summary>
 /// 
 /// </summary>
 [BindColumn(25,"a", "task_name", "","", "NCHAR", 255,0,false, IsPrimaryKey =false ,IsIdentity =false,IsNullable =false,  Length =255 )]
 public  System.String task_name  { get { return _task_name; } set { _task_name = value; } }

 private System.String _rsrc_name;
 /// <summary>
 /// 
 /// </summary>
 [BindColumn(26,"a", "rsrc_name", "","", "NCHAR", 50,0,false, IsPrimaryKey =false ,IsIdentity =false,IsNullable =true,  Length =50 )]
 public  System.String rsrc_name  { get { return _rsrc_name; } set { _rsrc_name = value; } }

 private System.Int32 _rsrc_id;
 /// <summary>
 /// 
 /// </summary>
 [BindColumn(27,"a", "rsrc_id", "","", "NCHAR", 10,0,false, IsPrimaryKey =false ,IsIdentity =false,IsNullable =true,  Length =10 )]
 public  System.Int32 rsrc_id  { get { return _rsrc_id; } set { _rsrc_id = value; } }

 private System.String _rsrc_guid;
 /// <summary>
 /// 
 /// </summary>
 [BindColumn(28,"a", "rsrc_guid", "","", "NCHAR", 38,0,false, IsPrimaryKey =false ,IsIdentity =false,IsNullable =true,  Length =38 )]
 public  System.String rsrc_guid  { get { return _rsrc_guid; } set { _rsrc_guid = value; } }

 private System.Decimal _total_float_hr_cnt;
 /// <summary>
 /// 
 /// </summary>
 [BindColumn(29,"a", "total_float_hr_cnt", "","", "NCHAR", 17,0,false, IsPrimaryKey =false ,IsIdentity =false,IsNullable =true,  Length =17 )]
 public  System.Decimal total_float_hr_cnt  { get { return _total_float_hr_cnt; } set { _total_float_hr_cnt = value; } }

 private System.Decimal _free_float_hr_cnt;
 /// <summary>
 /// 
 /// </summary>
 [BindColumn(30,"a", "free_float_hr_cnt", "","", "NCHAR", 17,0,false, IsPrimaryKey =false ,IsIdentity =false,IsNullable =true,  Length =17 )]
 public  System.Decimal free_float_hr_cnt  { get { return _free_float_hr_cnt; } set { _free_float_hr_cnt = value; } }

 private System.Decimal _target_drtn_hr_cnt;
 /// <summary>
 /// 
 /// </summary>
 [BindColumn(31,"a", "target_drtn_hr_cnt", "","", "NCHAR", 17,0,false, IsPrimaryKey =false ,IsIdentity =false,IsNullable =true,  Length =17 )]
 public  System.Decimal target_drtn_hr_cnt  { get { return _target_drtn_hr_cnt; } set { _target_drtn_hr_cnt = value; } }

 private System.Decimal _act_drtn_hr_cnt;
 /// <summary>
 /// 
 /// </summary>
 [BindColumn(32,"a", "act_drtn_hr_cnt", "","", "NCHAR", 17,0,false, IsPrimaryKey =false ,IsIdentity =false,IsNullable =true,  Length =17 )]
 public  System.Decimal act_drtn_hr_cnt  { get { return _act_drtn_hr_cnt; } set { _act_drtn_hr_cnt = value; } }

 private System.Decimal _remain_drtn_hr_cnt;
 /// <summary>
 /// 
 /// </summary>
 [BindColumn(33,"a", "remain_drtn_hr_cnt", "","", "NCHAR", 17,0,false, IsPrimaryKey =false ,IsIdentity =false,IsNullable =true,  Length =17 )]
 public  System.Decimal remain_drtn_hr_cnt  { get { return _remain_drtn_hr_cnt; } set { _remain_drtn_hr_cnt = value; } }

 private System.Decimal _act_work_qty;
 /// <summary>
 /// 
 /// </summary>
 [BindColumn(34,"a", "act_work_qty", "","", "NCHAR", 17,0,false, IsPrimaryKey =false ,IsIdentity =false,IsNullable =true,  Length =17 )]
 public  System.Decimal act_work_qty  { get { return _act_work_qty; } set { _act_work_qty = value; } }

 private System.Decimal _remain_work_qty;
 /// <summary>
 /// 
 /// </summary>
 [BindColumn(35,"a", "remain_work_qty", "","", "NCHAR", 17,0,false, IsPrimaryKey =false ,IsIdentity =false,IsNullable =true,  Length =17 )]
 public  System.Decimal remain_work_qty  { get { return _remain_work_qty; } set { _remain_work_qty = value; } }

 private System.Decimal _target_work_qty;
 /// <summary>
 /// 
 /// </summary>
 [BindColumn(36,"a", "target_work_qty", "","", "NCHAR", 17,0,false, IsPrimaryKey =false ,IsIdentity =false,IsNullable =true,  Length =17 )]
 public  System.Decimal target_work_qty  { get { return _target_work_qty; } set { _target_work_qty = value; } }

 private System.Decimal _target_equip_qty;
 /// <summary>
 /// 
 /// </summary>
 [BindColumn(37,"a", "target_equip_qty", "","", "NCHAR", 17,0,false, IsPrimaryKey =false ,IsIdentity =false,IsNullable =true,  Length =17 )]
 public  System.Decimal target_equip_qty  { get { return _target_equip_qty; } set { _target_equip_qty = value; } }

 private System.Decimal _act_equip_qty;
 /// <summary>
 /// 
 /// </summary>
 [BindColumn(38,"a", "act_equip_qty", "","", "NCHAR", 17,0,false, IsPrimaryKey =false ,IsIdentity =false,IsNullable =true,  Length =17 )]
 public  System.Decimal act_equip_qty  { get { return _act_equip_qty; } set { _act_equip_qty = value; } }

 private System.Decimal _remain_equip_qty;
 /// <summary>
 /// 
 /// </summary>
 [BindColumn(39,"a", "remain_equip_qty", "","", "NCHAR", 17,0,false, IsPrimaryKey =false ,IsIdentity =false,IsNullable =true,  Length =17 )]
 public  System.Decimal remain_equip_qty  { get { return _remain_equip_qty; } set { _remain_equip_qty = value; } }

 private System.String _cstr_type;
 /// <summary>
 /// 
 /// </summary>
 [BindColumn(40,"a", "cstr_type", "","", "NCHAR", 12,0,false, IsPrimaryKey =false ,IsIdentity =false,IsNullable =true,  Length =12 )]
 public  System.String cstr_type  { get { return _cstr_type; } set { _cstr_type = value; } }

 private System.DateTime _cstr_date;
 /// <summary>
 /// 
 /// </summary>
 [BindColumn(41,"a", "cstr_date", "","", "NCHAR", 3,0,false, IsPrimaryKey =false ,IsIdentity =false,IsNullable =true,  Length =3 )]
 public  System.DateTime cstr_date  { get { return _cstr_date; } set { _cstr_date = value; } }

 private System.DateTime _late_start_date;
 /// <summary>
 /// 
 /// </summary>
 [BindColumn(42,"a", "late_start_date", "","", "NCHAR", 3,0,false, IsPrimaryKey =false ,IsIdentity =false,IsNullable =true,  Length =3 )]
 public  System.DateTime late_start_date  { get { return _late_start_date; } set { _late_start_date = value; } }

 private System.DateTime _late_end_date;
 /// <summary>
 /// 
 /// </summary>
 [BindColumn(43,"a", "late_end_date", "","", "NCHAR", 3,0,false, IsPrimaryKey =false ,IsIdentity =false,IsNullable =true,  Length =3 )]
 public  System.DateTime late_end_date  { get { return _late_end_date; } set { _late_end_date = value; } }

 private System.DateTime _early_start_date;
 /// <summary>
 /// 
 /// </summary>
 [BindColumn(44,"a", "early_start_date", "","", "NCHAR", 3,0,false, IsPrimaryKey =false ,IsIdentity =false,IsNullable =true,  Length =3 )]
 public  System.DateTime early_start_date  { get { return _early_start_date; } set { _early_start_date = value; } }

 private System.DateTime _early_end_date;
 /// <summary>
 /// 
 /// </summary>
 [BindColumn(45,"a", "early_end_date", "","", "NCHAR", 3,0,false, IsPrimaryKey =false ,IsIdentity =false,IsNullable =true,  Length =3 )]
 public  System.DateTime early_end_date  { get { return _early_end_date; } set { _early_end_date = value; } }

 private System.DateTime _restart_date;
 /// <summary>
 /// 
 /// </summary>
 [BindColumn(46,"a", "restart_date", "","", "NCHAR", 3,0,false, IsPrimaryKey =false ,IsIdentity =false,IsNullable =true,  Length =3 )]
 public  System.DateTime restart_date  { get { return _restart_date; } set { _restart_date = value; } }

 private System.DateTime _reend_date;
 /// <summary>
 /// 
 /// </summary>
 [BindColumn(47,"a", "reend_date", "","", "NCHAR", 3,0,false, IsPrimaryKey =false ,IsIdentity =false,IsNullable =true,  Length =3 )]
 public  System.DateTime reend_date  { get { return _reend_date; } set { _reend_date = value; } }

 private System.DateTime _review_end_date;
 /// <summary>
 /// 
 /// </summary>
 [BindColumn(48,"a", "review_end_date", "","", "NCHAR", 3,0,false, IsPrimaryKey =false ,IsIdentity =false,IsNullable =true,  Length =3 )]
 public  System.DateTime review_end_date  { get { return _review_end_date; } set { _review_end_date = value; } }

 private System.DateTime _rem_late_start_date;
 /// <summary>
 /// 
 /// </summary>
 [BindColumn(49,"a", "rem_late_start_date", "","", "NCHAR", 3,0,false, IsPrimaryKey =false ,IsIdentity =false,IsNullable =true,  Length =3 )]
 public  System.DateTime rem_late_start_date  { get { return _rem_late_start_date; } set { _rem_late_start_date = value; } }

 private System.DateTime _rem_late_end_date;
 /// <summary>
 /// 
 /// </summary>
 [BindColumn(50,"a", "rem_late_end_date", "","", "NCHAR", 3,0,false, IsPrimaryKey =false ,IsIdentity =false,IsNullable =true,  Length =3 )]
 public  System.DateTime rem_late_end_date  { get { return _rem_late_end_date; } set { _rem_late_end_date = value; } }

 private System.String _priority_type;
 /// <summary>
 /// 
 /// </summary>
 [BindColumn(51,"a", "priority_type", "","", "NCHAR", 12,0,false, IsPrimaryKey =false ,IsIdentity =false,IsNullable =true,  Length =12 )]
 public  System.String priority_type  { get { return _priority_type; } set { _priority_type = value; } }

 private System.String _guid;
 /// <summary>
 /// 
 /// </summary>
 [BindColumn(52,"a", "guid", "","", "NCHAR", 38,0,false, IsPrimaryKey =false ,IsIdentity =false,IsNullable =true,  Length =38 )]
 public  System.String guid  { get { return _guid; } set { _guid = value; } }

 private System.String _tmpl_guid;
 /// <summary>
 /// 
 /// </summary>
 [BindColumn(53,"a", "tmpl_guid", "","", "NCHAR", 22,0,false, IsPrimaryKey =false ,IsIdentity =false,IsNullable =true,  Length =22 )]
 public  System.String tmpl_guid  { get { return _tmpl_guid; } set { _tmpl_guid = value; } }

 private System.DateTime _cstr_date2;
 /// <summary>
 /// 
 /// </summary>
 [BindColumn(54,"a", "cstr_date2", "","", "NCHAR", 3,0,false, IsPrimaryKey =false ,IsIdentity =false,IsNullable =true,  Length =3 )]
 public  System.DateTime cstr_date2  { get { return _cstr_date2; } set { _cstr_date2 = value; } }

 private System.String _cstr_type2;
 /// <summary>
 /// 
 /// </summary>
 [BindColumn(55,"a", "cstr_type2", "","", "NCHAR", 12,0,false, IsPrimaryKey =false ,IsIdentity =false,IsNullable =true,  Length =12 )]
 public  System.String cstr_type2  { get { return _cstr_type2; } set { _cstr_type2 = value; } }

 private System.Decimal _act_this_per_work_qty;
 /// <summary>
 /// 
 /// </summary>
 [BindColumn(56,"a", "act_this_per_work_qty", "","", "NCHAR", 17,0,false, IsPrimaryKey =false ,IsIdentity =false,IsNullable =true,  Length =17 )]
 public  System.Decimal act_this_per_work_qty  { get { return _act_this_per_work_qty; } set { _act_this_per_work_qty = value; } }

 private System.Decimal _act_this_per_equip_qty;
 /// <summary>
 /// 
 /// </summary>
 [BindColumn(57,"a", "act_this_per_equip_qty", "","", "NCHAR", 17,0,false, IsPrimaryKey =false ,IsIdentity =false,IsNullable =true,  Length =17 )]
 public  System.Decimal act_this_per_equip_qty  { get { return _act_this_per_equip_qty; } set { _act_this_per_equip_qty = value; } }

 private System.String _driving_path_flag;
 /// <summary>
 /// 
 /// </summary>
 [BindColumn(58,"a", "driving_path_flag", "","", "NCHAR", 1,0,false, IsPrimaryKey =false ,IsIdentity =false,IsNullable =true,  Length =1 )]
 public  System.String driving_path_flag  { get { return _driving_path_flag; } set { _driving_path_flag = value; } }

 private System.Int32 _float_path;
 /// <summary>
 /// 
 /// </summary>
 [BindColumn(59,"a", "float_path", "","", "NCHAR", 10,0,false, IsPrimaryKey =false ,IsIdentity =false,IsNullable =true,  Length =10 )]
 public  System.Int32 float_path  { get { return _float_path; } set { _float_path = value; } }

 private System.Int32 _float_path_order;
 /// <summary>
 /// 
 /// </summary>
 [BindColumn(60,"a", "float_path_order", "","", "NCHAR", 10,0,false, IsPrimaryKey =false ,IsIdentity =false,IsNullable =true,  Length =10 )]
 public  System.Int32 float_path_order  { get { return _float_path_order; } set { _float_path_order = value; } }

 private System.DateTime _suspend_date;
 /// <summary>
 /// 
 /// </summary>
 [BindColumn(61,"a", "suspend_date", "","", "NCHAR", 3,0,false, IsPrimaryKey =false ,IsIdentity =false,IsNullable =true,  Length =3 )]
 public  System.DateTime suspend_date  { get { return _suspend_date; } set { _suspend_date = value; } }

 private System.DateTime _resume_date;
 /// <summary>
 /// 
 /// </summary>
 [BindColumn(62,"a", "resume_date", "","", "NCHAR", 3,0,false, IsPrimaryKey =false ,IsIdentity =false,IsNullable =true,  Length =3 )]
 public  System.DateTime resume_date  { get { return _resume_date; } set { _resume_date = value; } }

 private System.DateTime _external_early_start_date;
 /// <summary>
 /// 
 /// </summary>
 [BindColumn(63,"a", "external_early_start_date", "","", "NCHAR", 3,0,false, IsPrimaryKey =false ,IsIdentity =false,IsNullable =true,  Length =3 )]
 public  System.DateTime external_early_start_date  { get { return _external_early_start_date; } set { _external_early_start_date = value; } }

 private System.DateTime _external_late_end_date;
 /// <summary>
 /// 
 /// </summary>
 [BindColumn(64,"a", "external_late_end_date", "","", "NCHAR", 3,0,false, IsPrimaryKey =false ,IsIdentity =false,IsNullable =true,  Length =3 )]
 public  System.DateTime external_late_end_date  { get { return _external_late_end_date; } set { _external_late_end_date = value; } }

 private System.DateTime _update_date;
 /// <summary>
 /// 
 /// </summary>
 [BindColumn(65,"a", "update_date", "","", "NCHAR", 3,0,false, IsPrimaryKey =false ,IsIdentity =false,IsNullable =true,  Length =3 )]
 public  System.DateTime update_date  { get { return _update_date; } set { _update_date = value; } }

 private System.String _update_user;
 /// <summary>
 /// 
 /// </summary>
 [BindColumn(66,"a", "update_user", "","", "NCHAR", 255,0,false, IsPrimaryKey =false ,IsIdentity =false,IsNullable =true,  Length =255 )]
 public  System.String update_user  { get { return _update_user; } set { _update_user = value; } }

 private System.DateTime _create_date;
 /// <summary>
 /// 
 /// </summary>
 [BindColumn(67,"a", "create_date", "","", "NCHAR", 3,0,false, IsPrimaryKey =false ,IsIdentity =false,IsNullable =true,  Length =3 )]
 public  System.DateTime create_date  { get { return _create_date; } set { _create_date = value; } }

 private System.Int32 _create_user_sid;
 /// <summary>
 /// 
 /// </summary>
 [BindColumn(68,"a", "create_user_sid", "","", "NCHAR", 10,0,false, IsPrimaryKey =false ,IsIdentity =false,IsNullable =true,  Length =10 )]
 public  System.Int32 create_user_sid  { get { return _create_user_sid; } set { _create_user_sid = value; } }

 private System.String _create_user;
 /// <summary>
 /// 
 /// </summary>
 [BindColumn(69,"a", "create_user", "","", "NCHAR", 255,0,false, IsPrimaryKey =false ,IsIdentity =false,IsNullable =true,  Length =255 )]
 public  System.String create_user  { get { return _create_user; } set { _create_user = value; } }

 private System.Int32 _delete_session_id;
 /// <summary>
 /// 
 /// </summary>
 [BindColumn(70,"a", "delete_session_id", "","", "NCHAR", 10,0,false, IsPrimaryKey =false ,IsIdentity =false,IsNullable =true,  Length =10 )]
 public  System.Int32 delete_session_id  { get { return _delete_session_id; } set { _delete_session_id = value; } }

 private System.DateTime _delete_date;
 /// <summary>
 /// 
 /// </summary>
 [BindColumn(71,"a", "delete_date", "","", "NCHAR", 3,0,false, IsPrimaryKey =false ,IsIdentity =false,IsNullable =true,  Length =3 )]
 public  System.DateTime delete_date  { get { return _delete_date; } set { _delete_date = value; } }

 private System.DateTime _act_start_date;
 /// <summary>
 /// 
 /// </summary>
 [BindColumn(72,"a", "act_start_date", "","", "NCHAR", 3,0,false, IsPrimaryKey =false ,IsIdentity =false,IsNullable =true,  Length =3 )]
 public  System.DateTime act_start_date  { get { return _act_start_date; } set { _act_start_date = value; } }

 private System.DateTime _act_end_date;
 /// <summary>
 /// 
 /// </summary>
 [BindColumn(73,"a", "act_end_date", "","", "NCHAR", 3,0,false, IsPrimaryKey =false ,IsIdentity =false,IsNullable =true,  Length =3 )]
 public  System.DateTime act_end_date  { get { return _act_end_date; } set { _act_end_date = value; } }

 private System.DateTime _expect_start_date;
 /// <summary>
 /// 
 /// </summary>
 [BindColumn(74,"a", "expect_start_date", "","", "NCHAR", 3,0,false, IsPrimaryKey =false ,IsIdentity =false,IsNullable =true,  Length =3 )]
 public  System.DateTime expect_start_date  { get { return _expect_start_date; } set { _expect_start_date = value; } }

 private System.DateTime _expect_end_date;
 /// <summary>
 /// 
 /// </summary>
 [BindColumn(75,"a", "expect_end_date", "","", "NCHAR", 3,0,false, IsPrimaryKey =false ,IsIdentity =false,IsNullable =true,  Length =3 )]
 public  System.DateTime expect_end_date  { get { return _expect_end_date; } set { _expect_end_date = value; } }

 private System.DateTime _target_start_date;
 /// <summary>
 /// 
 /// </summary>
 [BindColumn(76,"a", "target_start_date", "","", "NCHAR", 3,0,false, IsPrimaryKey =false ,IsIdentity =false,IsNullable =true,  Length =3 )]
 public  System.DateTime target_start_date  { get { return _target_start_date; } set { _target_start_date = value; } }

 private System.DateTime _target_end_date;
 /// <summary>
 /// 
 /// </summary>
 [BindColumn(77,"a", "target_end_date", "","", "NCHAR", 3,0,false, IsPrimaryKey =false ,IsIdentity =false,IsNullable =true,  Length =3 )]
 public  System.DateTime target_end_date  { get { return _target_end_date; } set { _target_end_date = value; } }

 private System.Boolean _SysOrNot;
 /// <summary>
 /// 
 /// </summary>
 [BindColumn(78,"a", "SysOrNot", "","", "NCHAR", 1,0,false, IsPrimaryKey =false ,IsIdentity =false,IsNullable =true,  Length =1 )]
 public  System.Boolean SysOrNot  { get { return _SysOrNot; } set { _SysOrNot = value; } }

 private System.Int32 _rec_type;
 /// <summary>
 /// 
 /// </summary>
 [BindColumn(79,"a", "rec_type", "","", "NCHAR", 10,0,false, IsPrimaryKey =false ,IsIdentity =false,IsNullable =true,  Length =10 )]
 public  System.Int32 rec_type  { get { return _rec_type; } set { _rec_type = value; } }

 private System.Int32 _temp_id;
 /// <summary>
 /// 
 /// </summary>
 [BindColumn(80,"a", "temp_id", "","", "NCHAR", 10,0,false, IsPrimaryKey =false ,IsIdentity =false,IsNullable =true,  Length =10 )]
 public  System.Int32 temp_id  { get { return _temp_id; } set { _temp_id = value; } }

 private System.Int32 _p3ec_flag;
 /// <summary>
 /// 
 /// </summary>
 [BindColumn(81,"a", "p3ec_flag", "","", "NCHAR", 10,0,false, IsPrimaryKey =false ,IsIdentity =false,IsNullable =true,  Length =10 )]
 public  System.Int32 p3ec_flag  { get { return _p3ec_flag; } set { _p3ec_flag = value; } }

 private System.Int32 _p3ec_task_id;
 /// <summary>
 /// 
 /// </summary>
 [BindColumn(82,"a", "p3ec_task_id", "","", "NCHAR", 10,0,false, IsPrimaryKey =false ,IsIdentity =false,IsNullable =true,  Length =10 )]
 public  System.Int32 p3ec_task_id  { get { return _p3ec_task_id; } set { _p3ec_task_id = value; } }

 private System.DateTime _data_date;
 /// <summary>
 /// 
 /// </summary>
 [BindColumn(83,"a", "data_date", "","", "NCHAR", 3,0,false, IsPrimaryKey =false ,IsIdentity =false,IsNullable =true,  Length =3 )]
 public  System.DateTime data_date  { get { return _data_date; } set { _data_date = value; } }

 private System.DateTime _start_date;
 /// <summary>
 /// 
 /// </summary>
 [BindColumn(84,"a", "start_date", "","", "NCHAR", 3,0,false, IsPrimaryKey =false ,IsIdentity =false,IsNullable =true,  Length =3 )]
 public  System.DateTime start_date  { get { return _start_date; } set { _start_date = value; } }

 private System.DateTime _end_date;
 /// <summary>
 /// 
 /// </summary>
 [BindColumn(85,"a", "end_date", "","", "NCHAR", 3,0,false, IsPrimaryKey =false ,IsIdentity =false,IsNullable =true,  Length =3 )]
 public  System.DateTime end_date  { get { return _end_date; } set { _end_date = value; } }

 private System.Int32 _plan_task_id_befor;
 /// <summary>
 /// 
 /// </summary>
 [BindColumn(86,"a", "plan_task_id_befor", "","", "NCHAR", 10,0,false, IsPrimaryKey =false ,IsIdentity =false,IsNullable =true,  Length =10 )]
 public  System.Int32 plan_task_id_befor  { get { return _plan_task_id_befor; } set { _plan_task_id_befor = value; } }

 private System.String _plan_task_guid_before;
 /// <summary>
 /// 
 /// </summary>
 [BindColumn(87,"a", "plan_task_guid_before", "","", "NCHAR", 38,0,false, IsPrimaryKey =false ,IsIdentity =false,IsNullable =true,  Length =38 )]
 public  System.String plan_task_guid_before  { get { return _plan_task_guid_before; } set { _plan_task_guid_before = value; } }

 private System.String _memo;
 /// <summary>
 /// 
 /// </summary>
 [BindColumn(88,"a", "memo", "","", "NCHAR", 2147483647,0,false, IsPrimaryKey =false ,IsIdentity =false,IsNullable =true,  Length =2147483647 )]
 public  System.String memo  { get { return _memo; } set { _memo = value; } }

 private System.Int32 _module_type;
 /// <summary>
 /// 
 /// </summary>
 [BindColumn(89,"a", "module_type", "","", "NCHAR", 10,0,false, IsPrimaryKey =false ,IsIdentity =false,IsNullable =true,  Length =10 )]
 public  System.Int32 module_type  { get { return _module_type; } set { _module_type = value; } }

 private System.String _plan_actvcode_guid;
 /// <summary>
 /// 
 /// </summary>
 [BindColumn(90,"a", "plan_actvcode_guid", "","", "NCHAR", 38,0,false, IsPrimaryKey =false ,IsIdentity =false,IsNullable =true,  Length =38 )]
 public  System.String plan_actvcode_guid  { get { return _plan_actvcode_guid; } set { _plan_actvcode_guid = value; } }

 private System.Int32 _plan_actvcode_id;
 /// <summary>
 /// 
 /// </summary>
 [BindColumn(91,"a", "plan_actvcode_id", "","", "NCHAR", 10,0,false, IsPrimaryKey =false ,IsIdentity =false,IsNullable =true,  Length =10 )]
 public  System.Int32 plan_actvcode_id  { get { return _plan_actvcode_id; } set { _plan_actvcode_id = value; } }

 private System.String _parent_task_plan_guid;
 /// <summary>
 /// 
 /// </summary>
 [BindColumn(92,"a", "parent_task_plan_guid", "","", "NCHAR", 38,0,false, IsPrimaryKey =false ,IsIdentity =false,IsNullable =true,  Length =38 )]
 public  System.String parent_task_plan_guid  { get { return _parent_task_plan_guid; } set { _parent_task_plan_guid = value; } }

 private System.String _videoUrl;
 /// <summary>
 /// 视频地址
 /// </summary>
 [BindColumn(115,"a", "videoUrl", "视频地址","", "NCHAR", 200,0,false, IsPrimaryKey =false ,IsIdentity =false,IsNullable =true,  Length =200 )]
 public  System.String videoUrl  { get { return _videoUrl; } set { _videoUrl = value; } }

 private System.Double _budget_cost;
 /// <summary>
 /// 
 /// </summary>
 [BindColumn(116,"a", "budget_cost", "","", "NCHAR", 53,0,false, IsPrimaryKey =false ,IsIdentity =false,IsNullable =true,  Length =53 )]
 public  System.Double budget_cost  { get { return _budget_cost; } set { _budget_cost = value; } }

      
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
			    if (name == "TARGET_PROGRESS_RSRC_QTY")
{
return _target_progress_rsrc_qty;
}
if (name == "TARGET_PROGRESS_RSRC_GUID")
{
return _target_progress_rsrc_guid;
}
if (name == "ACT_PROGRESS_RSRC_QTY")
{
return _act_progress_rsrc_qty;
}
if (name == "REMAIN_PROGRESS_RSRC_CURV")
{
return _remain_progress_rsrc_curv;
}
if (name == "TASK_ID")
{
return _task_id;
}
if (name == "BCWP_COST")
{
return _bcwp_cost;
}
if (name == "BASELINE3_START_DATE")
{
return _baseline3_start_date;
}
if (name == "PROGRESS_RSRC_UNIT_PRICE")
{
return _progress_rsrc_unit_price;
}
if (name == "CURVE_GUID")
{
return _curve_guid;
}
if (name == "PROGRESS_RSRC_UNIT_NAME")
{
return _progress_rsrc_unit_name;
}
if (name == "TARGET_PROGRESS_RSRC_CURV")
{
return _target_progress_rsrc_curv;
}
if (name == "BCWS_COST")
{
return _bcws_cost;
}
if (name == "BASELINE3_END_DATE")
{
return _baseline3_end_date;
}
if (name == "BASELINE2_END_DATE")
{
return _baseline2_end_date;
}
if (name == "TARGET_PROGRESS_RSRC_COST")
{
return _target_progress_rsrc_cost;
}
if (name == "REMAIN_PROGRESS_RSRC_QTY")
{
return _remain_progress_rsrc_qty;
}
if (name == "TARGET_PROGRESS_RSRC_CODE")
{
return _target_progress_rsrc_code;
}
if (name == "ISTOPBREAKDOWN")
{
return _istopbreakdown;
}
if (name == "BASELINE2_START_DATE")
{
return _baseline2_start_date;
}
if (name == "BASELINE_START_DATE")
{
return _baseline_start_date;
}
if (name == "EST_WT")
{
return _est_wt;
}
if (name == "EST_WT_PCT")
{
return _est_wt_pct;
}
if (name == "REMAIN_PROGRESS_RSRC_COST")
{
return _remain_progress_rsrc_cost;
}
if (name == "ACT_PROGRESS_RSRC_CURV")
{
return _act_progress_rsrc_curv;
}
if (name == "ACT_PROGRESS_RSRC_COST")
{
return _act_progress_rsrc_cost;
}
if (name == "BASELINE_END_DATE")
{
return _baseline_end_date;
}
if (name == "FEEDBACK_PCT_TYPE")
{
return _feedback_pct_type;
}
if (name == "ACWP_COST")
{
return _acwp_cost;
}
if (name == "TASK_GUID")
{
return _task_guid;
}
if (name == "PROJ_ID")
{
return _proj_id;
}
if (name == "PROJ_GUID")
{
return _proj_guid;
}
if (name == "WBS_ID")
{
return _wbs_id;
}
if (name == "WBS_GUID")
{
return _wbs_guid;
}
if (name == "CLNDR_ID")
{
return _clndr_id;
}
if (name == "CLNDR_GUID")
{
return _clndr_guid;
}
if (name == "PLAN_ID")
{
return _plan_id;
}
if (name == "PLAN_GUID")
{
return _plan_guid;
}
if (name == "SEQ_NUM")
{
return _seq_num;
}
if (name == "PARENT_TASK_ID")
{
return _parent_task_id;
}
if (name == "PARENT_GUID")
{
return _parent_guid;
}
if (name == "COMPLETE_PCT")
{
return _complete_pct;
}
if (name == "REV_FDBK_FLAG")
{
return _rev_fdbk_flag;
}
if (name == "LOCK_PLAN_FLAG")
{
return _lock_plan_flag;
}
if (name == "AUTO_COMPUTE_ACT_FLAG")
{
return _auto_compute_act_flag;
}
if (name == "COMPLETE_PCT_TYPE")
{
return _complete_pct_type;
}
if (name == "TASK_TYPE")
{
return _task_type;
}
if (name == "DURATION_TYPE")
{
return _duration_type;
}
if (name == "REVIEW_TYPE")
{
return _review_type;
}
if (name == "STATUS_CODE")
{
return _status_code;
}
if (name == "TASK_CODE")
{
return _task_code;
}
if (name == "TASK_NAME")
{
return _task_name;
}
if (name == "RSRC_NAME")
{
return _rsrc_name;
}
if (name == "RSRC_ID")
{
return _rsrc_id;
}
if (name == "RSRC_GUID")
{
return _rsrc_guid;
}
if (name == "TOTAL_FLOAT_HR_CNT")
{
return _total_float_hr_cnt;
}
if (name == "FREE_FLOAT_HR_CNT")
{
return _free_float_hr_cnt;
}
if (name == "TARGET_DRTN_HR_CNT")
{
return _target_drtn_hr_cnt;
}
if (name == "ACT_DRTN_HR_CNT")
{
return _act_drtn_hr_cnt;
}
if (name == "REMAIN_DRTN_HR_CNT")
{
return _remain_drtn_hr_cnt;
}
if (name == "ACT_WORK_QTY")
{
return _act_work_qty;
}
if (name == "REMAIN_WORK_QTY")
{
return _remain_work_qty;
}
if (name == "TARGET_WORK_QTY")
{
return _target_work_qty;
}
if (name == "TARGET_EQUIP_QTY")
{
return _target_equip_qty;
}
if (name == "ACT_EQUIP_QTY")
{
return _act_equip_qty;
}
if (name == "REMAIN_EQUIP_QTY")
{
return _remain_equip_qty;
}
if (name == "CSTR_TYPE")
{
return _cstr_type;
}
if (name == "CSTR_DATE")
{
return _cstr_date;
}
if (name == "LATE_START_DATE")
{
return _late_start_date;
}
if (name == "LATE_END_DATE")
{
return _late_end_date;
}
if (name == "EARLY_START_DATE")
{
return _early_start_date;
}
if (name == "EARLY_END_DATE")
{
return _early_end_date;
}
if (name == "RESTART_DATE")
{
return _restart_date;
}
if (name == "REEND_DATE")
{
return _reend_date;
}
if (name == "REVIEW_END_DATE")
{
return _review_end_date;
}
if (name == "REM_LATE_START_DATE")
{
return _rem_late_start_date;
}
if (name == "REM_LATE_END_DATE")
{
return _rem_late_end_date;
}
if (name == "PRIORITY_TYPE")
{
return _priority_type;
}
if (name == "GUID")
{
return _guid;
}
if (name == "TMPL_GUID")
{
return _tmpl_guid;
}
if (name == "CSTR_DATE2")
{
return _cstr_date2;
}
if (name == "CSTR_TYPE2")
{
return _cstr_type2;
}
if (name == "ACT_THIS_PER_WORK_QTY")
{
return _act_this_per_work_qty;
}
if (name == "ACT_THIS_PER_EQUIP_QTY")
{
return _act_this_per_equip_qty;
}
if (name == "DRIVING_PATH_FLAG")
{
return _driving_path_flag;
}
if (name == "FLOAT_PATH")
{
return _float_path;
}
if (name == "FLOAT_PATH_ORDER")
{
return _float_path_order;
}
if (name == "SUSPEND_DATE")
{
return _suspend_date;
}
if (name == "RESUME_DATE")
{
return _resume_date;
}
if (name == "EXTERNAL_EARLY_START_DATE")
{
return _external_early_start_date;
}
if (name == "EXTERNAL_LATE_END_DATE")
{
return _external_late_end_date;
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
if (name == "CREATE_USER_SID")
{
return _create_user_sid;
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
if (name == "TARGET_START_DATE")
{
return _target_start_date;
}
if (name == "TARGET_END_DATE")
{
return _target_end_date;
}
if (name == "SYSORNOT")
{
return _SysOrNot;
}
if (name == "REC_TYPE")
{
return _rec_type;
}
if (name == "TEMP_ID")
{
return _temp_id;
}
if (name == "P3EC_FLAG")
{
return _p3ec_flag;
}
if (name == "P3EC_TASK_ID")
{
return _p3ec_task_id;
}
if (name == "DATA_DATE")
{
return _data_date;
}
if (name == "START_DATE")
{
return _start_date;
}
if (name == "END_DATE")
{
return _end_date;
}
if (name == "PLAN_TASK_ID_BEFOR")
{
return _plan_task_id_befor;
}
if (name == "PLAN_TASK_GUID_BEFORE")
{
return _plan_task_guid_before;
}
if (name == "MEMO")
{
return _memo;
}
if (name == "MODULE_TYPE")
{
return _module_type;
}
if (name == "PLAN_ACTVCODE_GUID")
{
return _plan_actvcode_guid;
}
if (name == "PLAN_ACTVCODE_ID")
{
return _plan_actvcode_id;
}
if (name == "PARENT_TASK_PLAN_GUID")
{
return _parent_task_plan_guid;
}
if (name == "VIDEOURL")
{
return _videoUrl;
}
if (name == "BUDGET_COST")
{
return _budget_cost;
}

			    return base[name];
			}
			set 
			{
			   name = name.ToUpper();
			       if (name == "TARGET_PROGRESS_RSRC_QTY")
{
 _target_progress_rsrc_qty = System.Convert.ToDecimal(value);return;
}
if (name == "TARGET_PROGRESS_RSRC_GUID")
{
 _target_progress_rsrc_guid = System.Convert.ToString(value);return;
}
if (name == "ACT_PROGRESS_RSRC_QTY")
{
 _act_progress_rsrc_qty = System.Convert.ToDecimal(value);return;
}
if (name == "REMAIN_PROGRESS_RSRC_CURV")
{
 _remain_progress_rsrc_curv = System.Convert.ToString(value);return;
}
if (name == "TASK_ID")
{
 _task_id = System.Convert.ToInt32(value);return;
}
if (name == "BCWP_COST")
{
 _bcwp_cost = System.Convert.ToDecimal(value);return;
}
if (name == "BASELINE3_START_DATE")
{
 if (value == null || value.ToString().IsNullOrEmpty() == true) value = DateTime.MinValue;
 _baseline3_start_date = System.Convert.ToDateTime(value);return;
}
if (name == "PROGRESS_RSRC_UNIT_PRICE")
{
 _progress_rsrc_unit_price = System.Convert.ToDecimal(value);return;
}
if (name == "CURVE_GUID")
{
 _curve_guid = System.Convert.ToString(value);return;
}
if (name == "PROGRESS_RSRC_UNIT_NAME")
{
 _progress_rsrc_unit_name = System.Convert.ToString(value);return;
}
if (name == "TARGET_PROGRESS_RSRC_CURV")
{
 _target_progress_rsrc_curv = System.Convert.ToString(value);return;
}
if (name == "BCWS_COST")
{
 _bcws_cost = System.Convert.ToDecimal(value);return;
}
if (name == "BASELINE3_END_DATE")
{
 if (value == null || value.ToString().IsNullOrEmpty() == true) value = DateTime.MinValue;
 _baseline3_end_date = System.Convert.ToDateTime(value);return;
}
if (name == "BASELINE2_END_DATE")
{
 if (value == null || value.ToString().IsNullOrEmpty() == true) value = DateTime.MinValue;
 _baseline2_end_date = System.Convert.ToDateTime(value);return;
}
if (name == "TARGET_PROGRESS_RSRC_COST")
{
 _target_progress_rsrc_cost = System.Convert.ToDecimal(value);return;
}
if (name == "REMAIN_PROGRESS_RSRC_QTY")
{
 _remain_progress_rsrc_qty = System.Convert.ToDecimal(value);return;
}
if (name == "TARGET_PROGRESS_RSRC_CODE")
{
 _target_progress_rsrc_code = System.Convert.ToString(value);return;
}
if (name == "ISTOPBREAKDOWN")
{
 _istopbreakdown = System.Convert.ToInt32(value);return;
}
if (name == "BASELINE2_START_DATE")
{
 if (value == null || value.ToString().IsNullOrEmpty() == true) value = DateTime.MinValue;
 _baseline2_start_date = System.Convert.ToDateTime(value);return;
}
if (name == "BASELINE_START_DATE")
{
 if (value == null || value.ToString().IsNullOrEmpty() == true) value = DateTime.MinValue;
 _baseline_start_date = System.Convert.ToDateTime(value);return;
}
if (name == "EST_WT")
{
 _est_wt = System.Convert.ToDecimal(value);return;
}
if (name == "EST_WT_PCT")
{
 _est_wt_pct = System.Convert.ToDecimal(value);return;
}
if (name == "REMAIN_PROGRESS_RSRC_COST")
{
 _remain_progress_rsrc_cost = System.Convert.ToDecimal(value);return;
}
if (name == "ACT_PROGRESS_RSRC_CURV")
{
 _act_progress_rsrc_curv = System.Convert.ToString(value);return;
}
if (name == "ACT_PROGRESS_RSRC_COST")
{
 _act_progress_rsrc_cost = System.Convert.ToDecimal(value);return;
}
if (name == "BASELINE_END_DATE")
{
 if (value == null || value.ToString().IsNullOrEmpty() == true) value = DateTime.MinValue;
 _baseline_end_date = System.Convert.ToDateTime(value);return;
}
if (name == "FEEDBACK_PCT_TYPE")
{
 _feedback_pct_type = System.Convert.ToString(value);return;
}
if (name == "ACWP_COST")
{
 _acwp_cost = System.Convert.ToDecimal(value);return;
}
if (name == "TASK_GUID")
{
 _task_guid = System.Convert.ToString(value);return;
}
if (name == "PROJ_ID")
{
 _proj_id = System.Convert.ToInt32(value);return;
}
if (name == "PROJ_GUID")
{
 _proj_guid = System.Convert.ToString(value);return;
}
if (name == "WBS_ID")
{
 _wbs_id = System.Convert.ToInt32(value);return;
}
if (name == "WBS_GUID")
{
 _wbs_guid = System.Convert.ToString(value);return;
}
if (name == "CLNDR_ID")
{
 _clndr_id = System.Convert.ToInt32(value);return;
}
if (name == "CLNDR_GUID")
{
 _clndr_guid = System.Convert.ToString(value);return;
}
if (name == "PLAN_ID")
{
 _plan_id = System.Convert.ToInt32(value);return;
}
if (name == "PLAN_GUID")
{
 _plan_guid = System.Convert.ToString(value);return;
}
if (name == "SEQ_NUM")
{
 _seq_num = System.Convert.ToInt32(value);return;
}
if (name == "PARENT_TASK_ID")
{
 _parent_task_id = System.Convert.ToInt32(value);return;
}
if (name == "PARENT_GUID")
{
 _parent_guid = System.Convert.ToString(value);return;
}
if (name == "COMPLETE_PCT")
{
 _complete_pct = System.Convert.ToDecimal(value);return;
}
if (name == "REV_FDBK_FLAG")
{
 _rev_fdbk_flag = System.Convert.ToString(value);return;
}
if (name == "LOCK_PLAN_FLAG")
{
 _lock_plan_flag = System.Convert.ToString(value);return;
}
if (name == "AUTO_COMPUTE_ACT_FLAG")
{
 _auto_compute_act_flag = System.Convert.ToString(value);return;
}
if (name == "COMPLETE_PCT_TYPE")
{
 _complete_pct_type = System.Convert.ToString(value);return;
}
if (name == "TASK_TYPE")
{
 _task_type = System.Convert.ToString(value);return;
}
if (name == "DURATION_TYPE")
{
 _duration_type = System.Convert.ToString(value);return;
}
if (name == "REVIEW_TYPE")
{
 _review_type = System.Convert.ToString(value);return;
}
if (name == "STATUS_CODE")
{
 _status_code = System.Convert.ToString(value);return;
}
if (name == "TASK_CODE")
{
 _task_code = System.Convert.ToString(value);return;
}
if (name == "TASK_NAME")
{
 _task_name = System.Convert.ToString(value);return;
}
if (name == "RSRC_NAME")
{
 _rsrc_name = System.Convert.ToString(value);return;
}
if (name == "RSRC_ID")
{
 _rsrc_id = System.Convert.ToInt32(value);return;
}
if (name == "RSRC_GUID")
{
 _rsrc_guid = System.Convert.ToString(value);return;
}
if (name == "TOTAL_FLOAT_HR_CNT")
{
 _total_float_hr_cnt = System.Convert.ToDecimal(value);return;
}
if (name == "FREE_FLOAT_HR_CNT")
{
 _free_float_hr_cnt = System.Convert.ToDecimal(value);return;
}
if (name == "TARGET_DRTN_HR_CNT")
{
 _target_drtn_hr_cnt = System.Convert.ToDecimal(value);return;
}
if (name == "ACT_DRTN_HR_CNT")
{
 _act_drtn_hr_cnt = System.Convert.ToDecimal(value);return;
}
if (name == "REMAIN_DRTN_HR_CNT")
{
 _remain_drtn_hr_cnt = System.Convert.ToDecimal(value);return;
}
if (name == "ACT_WORK_QTY")
{
 _act_work_qty = System.Convert.ToDecimal(value);return;
}
if (name == "REMAIN_WORK_QTY")
{
 _remain_work_qty = System.Convert.ToDecimal(value);return;
}
if (name == "TARGET_WORK_QTY")
{
 _target_work_qty = System.Convert.ToDecimal(value);return;
}
if (name == "TARGET_EQUIP_QTY")
{
 _target_equip_qty = System.Convert.ToDecimal(value);return;
}
if (name == "ACT_EQUIP_QTY")
{
 _act_equip_qty = System.Convert.ToDecimal(value);return;
}
if (name == "REMAIN_EQUIP_QTY")
{
 _remain_equip_qty = System.Convert.ToDecimal(value);return;
}
if (name == "CSTR_TYPE")
{
 _cstr_type = System.Convert.ToString(value);return;
}
if (name == "CSTR_DATE")
{
 if (value == null || value.ToString().IsNullOrEmpty() == true) value = DateTime.MinValue;
 _cstr_date = System.Convert.ToDateTime(value);return;
}
if (name == "LATE_START_DATE")
{
 if (value == null || value.ToString().IsNullOrEmpty() == true) value = DateTime.MinValue;
 _late_start_date = System.Convert.ToDateTime(value);return;
}
if (name == "LATE_END_DATE")
{
 if (value == null || value.ToString().IsNullOrEmpty() == true) value = DateTime.MinValue;
 _late_end_date = System.Convert.ToDateTime(value);return;
}
if (name == "EARLY_START_DATE")
{
 if (value == null || value.ToString().IsNullOrEmpty() == true) value = DateTime.MinValue;
 _early_start_date = System.Convert.ToDateTime(value);return;
}
if (name == "EARLY_END_DATE")
{
 if (value == null || value.ToString().IsNullOrEmpty() == true) value = DateTime.MinValue;
 _early_end_date = System.Convert.ToDateTime(value);return;
}
if (name == "RESTART_DATE")
{
 if (value == null || value.ToString().IsNullOrEmpty() == true) value = DateTime.MinValue;
 _restart_date = System.Convert.ToDateTime(value);return;
}
if (name == "REEND_DATE")
{
 if (value == null || value.ToString().IsNullOrEmpty() == true) value = DateTime.MinValue;
 _reend_date = System.Convert.ToDateTime(value);return;
}
if (name == "REVIEW_END_DATE")
{
 if (value == null || value.ToString().IsNullOrEmpty() == true) value = DateTime.MinValue;
 _review_end_date = System.Convert.ToDateTime(value);return;
}
if (name == "REM_LATE_START_DATE")
{
 if (value == null || value.ToString().IsNullOrEmpty() == true) value = DateTime.MinValue;
 _rem_late_start_date = System.Convert.ToDateTime(value);return;
}
if (name == "REM_LATE_END_DATE")
{
 if (value == null || value.ToString().IsNullOrEmpty() == true) value = DateTime.MinValue;
 _rem_late_end_date = System.Convert.ToDateTime(value);return;
}
if (name == "PRIORITY_TYPE")
{
 _priority_type = System.Convert.ToString(value);return;
}
if (name == "GUID")
{
 _guid = System.Convert.ToString(value);return;
}
if (name == "TMPL_GUID")
{
 _tmpl_guid = System.Convert.ToString(value);return;
}
if (name == "CSTR_DATE2")
{
 if (value == null || value.ToString().IsNullOrEmpty() == true) value = DateTime.MinValue;
 _cstr_date2 = System.Convert.ToDateTime(value);return;
}
if (name == "CSTR_TYPE2")
{
 _cstr_type2 = System.Convert.ToString(value);return;
}
if (name == "ACT_THIS_PER_WORK_QTY")
{
 _act_this_per_work_qty = System.Convert.ToDecimal(value);return;
}
if (name == "ACT_THIS_PER_EQUIP_QTY")
{
 _act_this_per_equip_qty = System.Convert.ToDecimal(value);return;
}
if (name == "DRIVING_PATH_FLAG")
{
 _driving_path_flag = System.Convert.ToString(value);return;
}
if (name == "FLOAT_PATH")
{
 _float_path = System.Convert.ToInt32(value);return;
}
if (name == "FLOAT_PATH_ORDER")
{
 _float_path_order = System.Convert.ToInt32(value);return;
}
if (name == "SUSPEND_DATE")
{
 if (value == null || value.ToString().IsNullOrEmpty() == true) value = DateTime.MinValue;
 _suspend_date = System.Convert.ToDateTime(value);return;
}
if (name == "RESUME_DATE")
{
 if (value == null || value.ToString().IsNullOrEmpty() == true) value = DateTime.MinValue;
 _resume_date = System.Convert.ToDateTime(value);return;
}
if (name == "EXTERNAL_EARLY_START_DATE")
{
 if (value == null || value.ToString().IsNullOrEmpty() == true) value = DateTime.MinValue;
 _external_early_start_date = System.Convert.ToDateTime(value);return;
}
if (name == "EXTERNAL_LATE_END_DATE")
{
 if (value == null || value.ToString().IsNullOrEmpty() == true) value = DateTime.MinValue;
 _external_late_end_date = System.Convert.ToDateTime(value);return;
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
if (name == "CREATE_USER_SID")
{
 _create_user_sid = System.Convert.ToInt32(value);return;
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
if (name == "TARGET_START_DATE")
{
 if (value == null || value.ToString().IsNullOrEmpty() == true) value = DateTime.MinValue;
 _target_start_date = System.Convert.ToDateTime(value);return;
}
if (name == "TARGET_END_DATE")
{
 if (value == null || value.ToString().IsNullOrEmpty() == true) value = DateTime.MinValue;
 _target_end_date = System.Convert.ToDateTime(value);return;
}
if (name == "SYSORNOT")
{
 _SysOrNot = System.Convert.ToBoolean(value);return;
}
if (name == "REC_TYPE")
{
 _rec_type = System.Convert.ToInt32(value);return;
}
if (name == "TEMP_ID")
{
 _temp_id = System.Convert.ToInt32(value);return;
}
if (name == "P3EC_FLAG")
{
 _p3ec_flag = System.Convert.ToInt32(value);return;
}
if (name == "P3EC_TASK_ID")
{
 _p3ec_task_id = System.Convert.ToInt32(value);return;
}
if (name == "DATA_DATE")
{
 if (value == null || value.ToString().IsNullOrEmpty() == true) value = DateTime.MinValue;
 _data_date = System.Convert.ToDateTime(value);return;
}
if (name == "START_DATE")
{
 if (value == null || value.ToString().IsNullOrEmpty() == true) value = DateTime.MinValue;
 _start_date = System.Convert.ToDateTime(value);return;
}
if (name == "END_DATE")
{
 if (value == null || value.ToString().IsNullOrEmpty() == true) value = DateTime.MinValue;
 _end_date = System.Convert.ToDateTime(value);return;
}
if (name == "PLAN_TASK_ID_BEFOR")
{
 _plan_task_id_befor = System.Convert.ToInt32(value);return;
}
if (name == "PLAN_TASK_GUID_BEFORE")
{
 _plan_task_guid_before = System.Convert.ToString(value);return;
}
if (name == "MEMO")
{
 _memo = System.Convert.ToString(value);return;
}
if (name == "MODULE_TYPE")
{
 _module_type = System.Convert.ToInt32(value);return;
}
if (name == "PLAN_ACTVCODE_GUID")
{
 _plan_actvcode_guid = System.Convert.ToString(value);return;
}
if (name == "PLAN_ACTVCODE_ID")
{
 _plan_actvcode_id = System.Convert.ToInt32(value);return;
}
if (name == "PARENT_TASK_PLAN_GUID")
{
 _parent_task_plan_guid = System.Convert.ToString(value);return;
}
if (name == "VIDEOURL")
{
 _videoUrl = System.Convert.ToString(value);return;
}
if (name == "BUDGET_COST")
{
 _budget_cost = System.Convert.ToDouble(value);return;
}

			    base[name] = value;
			}
		}
		#endregion
	}
}