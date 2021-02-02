 
 
 using    System;
 using System.Collections.Generic;
 using System.Text; 
 using XCode.Attributes    ;

 namespace  Power.Systems.StdSystem
{
    /// <summary>
    /// EPS
    /// </summary>
    public class EPSDO : EPSDO<EPSDO>
    {

    }

	/// <summary>
    /// EPS
    /// </summary>
	  [BindEntity(KeyWord="EPS",EntityType = typeof(Power.Systems.StdSystem.EPSDO),Description = "EPS"  )] 

	 [BindTable( "PLN_project", Alias = "a",IsAttach=false,Description ="")]

	  [BindIndex(Name = "pk_PLN_project", KeyType = Power.DataAccessLayer.KeyType.MainKey, Columns = "project_guid", TableName = "PLN_project",Description="")]
 [BindIndex(Name = "pt_PLN_project", KeyType = Power.DataAccessLayer.KeyType.ParentKey, Columns = "parent_guid,project_guid", TableName = "PLN_project",Description="")]

    public   class EPSDO<TEntity> : XCode.Entity<TEntity>, XCode.IEntity where TEntity : Power.Systems.StdSystem.EPSDO<TEntity>, new()
    { 
	    #region 属性

	    
 private System.String _EpsProjId;
 /// <summary>
 /// 
 /// </summary>
 [BindColumn(1,"a", "EpsProjId", "","", "NCHAR", 38,0,false, IsPrimaryKey =false ,IsIdentity =false,IsNullable =false,  Length =38 )]
 public  System.String EpsProjId  { get { return _EpsProjId; } set { _EpsProjId = value; } }

 private System.Int32 _project_id;
 /// <summary>
 /// 
 /// </summary>
 [BindColumn(1,"a", "project_id", "","", "NCHAR", 10,0,false, IsPrimaryKey =false ,IsIdentity =false,IsNullable =false,  Length =10 )]
 public  System.Int32 project_id  { get { return _project_id; } set { _project_id = value; } }

 private System.Guid _BizAreaId;
 /// <summary>
 /// 
 /// </summary>
 [BindColumn(1,"a", "BizAreaId", "","", "NCHAR", 16,0,false, IsPrimaryKey =false ,IsIdentity =false,IsNullable =true,  Length =16 )]
 public  System.Guid BizAreaId  { get { return _BizAreaId; } set { _BizAreaId = value; } }

 private System.String _project_guid;
 /// <summary>
 /// 
 /// </summary>
 [BindColumn(2,"a", "project_guid", "","", "NCHAR", 38,0,false, IsPrimaryKey =true ,IsIdentity =true,IsNullable =false,  Length =38 )]
 public virtual System.String project_guid  { get { return _project_guid; } set { _project_guid = value; } }

 private System.String _project_shortname;
 /// <summary>
 /// 
 /// </summary>
 [BindColumn(3,"a", "project_shortname", "","", "NCHAR", 200,0,false, IsPrimaryKey =false ,IsIdentity =false,IsNullable =true,  Length =200 )]
 public  System.String project_shortname  { get { return _project_shortname; } set { _project_shortname = value; } }

 private System.String _project_name;
 /// <summary>
 /// 
 /// </summary>
 [BindColumn(4,"a", "project_name", "","", "NCHAR", 200,0,false, IsPrimaryKey =false ,IsIdentity =false,IsNullable =true,  Length =200 )]
 public  System.String project_name  { get { return _project_name; } set { _project_name = value; } }

 private System.Int32 _parent_id;
 /// <summary>
 /// 
 /// </summary>
 [BindColumn(5,"a", "parent_id", "","", "NCHAR", 10,0,false, IsPrimaryKey =false ,IsIdentity =false,IsNullable =true,  Length =10 )]
 public  System.Int32 parent_id  { get { return _parent_id; } set { _parent_id = value; } }

 private System.String _parent_guid;
 /// <summary>
 /// 
 /// </summary>
 [BindColumn(6,"a", "parent_guid", "","", "NCHAR", 38,0,false, IsPrimaryKey =false ,IsIdentity =false,IsNullable =true,  Length =38 )]
 public  System.String parent_guid  { get { return _parent_guid; } set { _parent_guid = value; } }

 private System.String _remark;
 /// <summary>
 /// 
 /// </summary>
 [BindColumn(7,"a", "remark", "","", "NCHAR", 1000,0,false, IsPrimaryKey =false ,IsIdentity =false,IsNullable =true,  Length =1000 )]
 public  System.String remark  { get { return _remark; } set { _remark = value; } }

 private System.Int32 _user_sid;
 /// <summary>
 /// 
 /// </summary>
 [BindColumn(8,"a", "user_sid", "","", "NCHAR", 10,0,false, IsPrimaryKey =false ,IsIdentity =false,IsNullable =true,  Length =10 )]
 public  System.Int32 user_sid  { get { return _user_sid; } set { _user_sid = value; } }

 private System.String _user_guid;
 /// <summary>
 /// 
 /// </summary>
 [BindColumn(9,"a", "user_guid", "","", "NCHAR", 38,0,false, IsPrimaryKey =false ,IsIdentity =false,IsNullable =true,  Length =38 )]
 public  System.String user_guid  { get { return _user_guid; } set { _user_guid = value; } }

 private System.Int32 _project_type;
 /// <summary>
 /// 
 /// </summary>
 [BindColumn(10,"a", "project_type", "","", "NCHAR", 10,0,false, IsPrimaryKey =false ,IsIdentity =false,IsNullable =true,  Length =10 )]
 public  System.Int32 project_type  { get { return _project_type; } set { _project_type = value; } }

 private System.Decimal _est_wt;
 /// <summary>
 /// 
 /// </summary>
 [BindColumn(11,"a", "est_wt", "","", "NCHAR", 10,0,false, IsPrimaryKey =false ,IsIdentity =false,IsNullable =true,  Length =10 )]
 public  System.Decimal est_wt  { get { return _est_wt; } set { _est_wt = value; } }

 private System.Int32 _obs_sid;
 /// <summary>
 /// 
 /// </summary>
 [BindColumn(12,"a", "obs_sid", "","", "NCHAR", 10,0,false, IsPrimaryKey =false ,IsIdentity =false,IsNullable =true,  Length =10 )]
 public  System.Int32 obs_sid  { get { return _obs_sid; } set { _obs_sid = value; } }

 private System.String _obs_guid;
 /// <summary>
 /// 
 /// </summary>
 [BindColumn(13,"a", "obs_guid", "","", "NCHAR", 38,0,false, IsPrimaryKey =false ,IsIdentity =false,IsNullable =true,  Length =38 )]
 public  System.String obs_guid  { get { return _obs_guid; } set { _obs_guid = value; } }

 private System.Int32 _haschild;
 /// <summary>
 /// 
 /// </summary>
 [BindColumn(14,"a", "haschild", "","", "NCHAR", 10,0,false, IsPrimaryKey =false ,IsIdentity =false,IsNullable =true,  Length =10 )]
 public  System.Int32 haschild  { get { return _haschild; } set { _haschild = value; } }

 private System.Int32 _p3ec;
 /// <summary>
 /// 
 /// </summary>
 [BindColumn(15,"a", "p3ec", "","", "NCHAR", 10,0,false, IsPrimaryKey =false ,IsIdentity =false,IsNullable =true,  Length =10 )]
 public  System.Int32 p3ec  { get { return _p3ec; } set { _p3ec = value; } }

 private System.Int32 _treelevel;
 /// <summary>
 /// 
 /// </summary>
 [BindColumn(16,"a", "treelevel", "","", "NCHAR", 10,0,false, IsPrimaryKey =false ,IsIdentity =false,IsNullable =true,  Length =10 )]
 public  System.Int32 treelevel  { get { return _treelevel; } set { _treelevel = value; } }

 private System.String _note;
 /// <summary>
 /// 
 /// </summary>
 [BindColumn(17,"a", "note", "","", "NCHAR", 2147483647,0,false, IsPrimaryKey =false ,IsIdentity =false,IsNullable =true,  Length =2147483647 )]
 public  System.String note  { get { return _note; } set { _note = value; } }

 private System.Int32 _p3ec_project_id;
 /// <summary>
 /// 
 /// </summary>
 [BindColumn(18,"a", "p3ec_project_id", "","", "NCHAR", 10,0,false, IsPrimaryKey =false ,IsIdentity =false,IsNullable =true,  Length =10 )]
 public  System.Int32 p3ec_project_id  { get { return _p3ec_project_id; } set { _p3ec_project_id = value; } }

 private System.Int32 _contract_id;
 /// <summary>
 /// 
 /// </summary>
 [BindColumn(19,"a", "contract_id", "","", "NCHAR", 10,0,false, IsPrimaryKey =false ,IsIdentity =false,IsNullable =true,  Length =10 )]
 public  System.Int32 contract_id  { get { return _contract_id; } set { _contract_id = value; } }

 private System.Int32 _displayid;
 /// <summary>
 /// 
 /// </summary>
 [BindColumn(20,"a", "displayid", "","", "NCHAR", 10,0,false, IsPrimaryKey =false ,IsIdentity =false,IsNullable =true,  Length =10 )]
 public  System.Int32 displayid  { get { return _displayid; } set { _displayid = value; } }

 private System.Int32 _discolor;
 /// <summary>
 /// 
 /// </summary>
 [BindColumn(21,"a", "discolor", "","", "NCHAR", 10,0,false, IsPrimaryKey =false ,IsIdentity =false,IsNullable =true,  Length =10 )]
 public  System.Int32 discolor  { get { return _discolor; } set { _discolor = value; } }

 private System.Int32 _project_type_sid;
 /// <summary>
 /// 
 /// </summary>
 [BindColumn(22,"a", "project_type_sid", "","", "NCHAR", 10,0,false, IsPrimaryKey =false ,IsIdentity =false,IsNullable =true,  Length =10 )]
 public  System.Int32 project_type_sid  { get { return _project_type_sid; } set { _project_type_sid = value; } }

 private System.Int32 _project_status_sid;
 /// <summary>
 /// 
 /// </summary>
 [BindColumn(23,"a", "project_status_sid", "","", "NCHAR", 10,0,false, IsPrimaryKey =false ,IsIdentity =false,IsNullable =true,  Length =10 )]
 public  System.Int32 project_status_sid  { get { return _project_status_sid; } set { _project_status_sid = value; } }

 private System.String _project_address;
 /// <summary>
 /// 
 /// </summary>
 [BindColumn(24,"a", "project_address", "","", "NCHAR", 200,0,false, IsPrimaryKey =false ,IsIdentity =false,IsNullable =true,  Length =200 )]
 public  System.String project_address  { get { return _project_address; } set { _project_address = value; } }

 private System.DateTime _target_start_date;
 /// <summary>
 /// 
 /// </summary>
 [BindColumn(25,"a", "target_start_date", "","", "NCHAR", 3,0,false, IsPrimaryKey =false ,IsIdentity =false,IsNullable =true,  Length =3 )]
 public  System.DateTime target_start_date  { get { return _target_start_date; } set { _target_start_date = value; } }

 private System.DateTime _target_end_date;
 /// <summary>
 /// 
 /// </summary>
 [BindColumn(26,"a", "target_end_date", "","", "NCHAR", 3,0,false, IsPrimaryKey =false ,IsIdentity =false,IsNullable =true,  Length =3 )]
 public  System.DateTime target_end_date  { get { return _target_end_date; } set { _target_end_date = value; } }

 private System.DateTime _act_start_date;
 /// <summary>
 /// 
 /// </summary>
 [BindColumn(27,"a", "act_start_date", "","", "NCHAR", 3,0,false, IsPrimaryKey =false ,IsIdentity =false,IsNullable =true,  Length =3 )]
 public  System.DateTime act_start_date  { get { return _act_start_date; } set { _act_start_date = value; } }

 private System.DateTime _act_end_date;
 /// <summary>
 /// 
 /// </summary>
 [BindColumn(28,"a", "act_end_date", "","", "NCHAR", 3,0,false, IsPrimaryKey =false ,IsIdentity =false,IsNullable =true,  Length =3 )]
 public  System.DateTime act_end_date  { get { return _act_end_date; } set { _act_end_date = value; } }

 private System.DateTime _data_date;
 /// <summary>
 /// 
 /// </summary>
 [BindColumn(29,"a", "data_date", "","", "NCHAR", 3,0,false, IsPrimaryKey =false ,IsIdentity =false,IsNullable =true,  Length =3 )]
 public  System.DateTime data_date  { get { return _data_date; } set { _data_date = value; } }

 private System.DateTime _compute_end_date;
 /// <summary>
 /// 
 /// </summary>
 [BindColumn(30,"a", "compute_end_date", "","", "NCHAR", 3,0,false, IsPrimaryKey =false ,IsIdentity =false,IsNullable =true,  Length =3 )]
 public  System.DateTime compute_end_date  { get { return _compute_end_date; } set { _compute_end_date = value; } }

 private System.DateTime _expect_start_date;
 /// <summary>
 /// 
 /// </summary>
 [BindColumn(31,"a", "expect_start_date", "","", "NCHAR", 3,0,false, IsPrimaryKey =false ,IsIdentity =false,IsNullable =true,  Length =3 )]
 public  System.DateTime expect_start_date  { get { return _expect_start_date; } set { _expect_start_date = value; } }

 private System.DateTime _expect_end_date;
 /// <summary>
 /// 
 /// </summary>
 [BindColumn(32,"a", "expect_end_date", "","", "NCHAR", 3,0,false, IsPrimaryKey =false ,IsIdentity =false,IsNullable =true,  Length =3 )]
 public  System.DateTime expect_end_date  { get { return _expect_end_date; } set { _expect_end_date = value; } }

 private System.Int32 _unContract_id;
 /// <summary>
 /// 
 /// </summary>
 [BindColumn(33,"a", "unContract_id", "","", "NCHAR", 10,0,false, IsPrimaryKey =false ,IsIdentity =false,IsNullable =true,  Length =10 )]
 public  System.Int32 unContract_id  { get { return _unContract_id; } set { _unContract_id = value; } }

 private System.Decimal _complete_pct;
 /// <summary>
 /// 
 /// </summary>
 [BindColumn(34,"a", "complete_pct", "","", "NCHAR", 18,0,false, IsPrimaryKey =false ,IsIdentity =false,IsNullable =true,  Length =18 )]
 public  System.Decimal complete_pct  { get { return _complete_pct; } set { _complete_pct = value; } }

 private System.Boolean _allow_diy_web;
 /// <summary>
 /// 
 /// </summary>
 [BindColumn(35,"a", "allow_diy_web", "","", "NCHAR", 1,0,false, IsPrimaryKey =false ,IsIdentity =false,IsNullable =false,  Length =1 )]
 public  System.Boolean allow_diy_web  { get { return _allow_diy_web; } set { _allow_diy_web = value; } }

 private System.Int32 _program_id;
 /// <summary>
 /// 
 /// </summary>
 [BindColumn(36,"a", "program_id", "","", "NCHAR", 10,0,false, IsPrimaryKey =false ,IsIdentity =false,IsNullable =true,  Length =10 )]
 public  System.Int32 program_id  { get { return _program_id; } set { _program_id = value; } }

 private System.Int32 _risk_level;
 /// <summary>
 /// 
 /// </summary>
 [BindColumn(37,"a", "risk_level", "","", "NCHAR", 10,0,false, IsPrimaryKey =false ,IsIdentity =false,IsNullable =true,  Length =10 )]
 public  System.Int32 risk_level  { get { return _risk_level; } set { _risk_level = value; } }

 private System.String _proj_url;
 /// <summary>
 /// 
 /// </summary>
 [BindColumn(38,"a", "proj_url", "","", "NCHAR", 200,0,false, IsPrimaryKey =false ,IsIdentity =false,IsNullable =true,  Length =200 )]
 public  System.String proj_url  { get { return _proj_url; } set { _proj_url = value; } }

 private System.String _def_duration_type;
 /// <summary>
 /// 
 /// </summary>
 [BindColumn(39,"a", "def_duration_type", "","", "NCHAR", 12,0,false, IsPrimaryKey =false ,IsIdentity =false,IsNullable =true,  Length =12 )]
 public  System.String def_duration_type  { get { return _def_duration_type; } set { _def_duration_type = value; } }

 private System.String _def_complete_pct_type;
 /// <summary>
 /// 
 /// </summary>
 [BindColumn(40,"a", "def_complete_pct_type", "","", "NCHAR", 10,0,false, IsPrimaryKey =false ,IsIdentity =false,IsNullable =true,  Length =10 )]
 public  System.String def_complete_pct_type  { get { return _def_complete_pct_type; } set { _def_complete_pct_type = value; } }

 private System.String _def_task_type;
 /// <summary>
 /// 
 /// </summary>
 [BindColumn(41,"a", "def_task_type", "","", "NCHAR", 12,0,false, IsPrimaryKey =false ,IsIdentity =false,IsNullable =true,  Length =12 )]
 public  System.String def_task_type  { get { return _def_task_type; } set { _def_task_type = value; } }

 private System.Int32 _acct_id;
 /// <summary>
 /// 
 /// </summary>
 [BindColumn(42,"a", "acct_id", "","", "NCHAR", 10,0,false, IsPrimaryKey =false ,IsIdentity =false,IsNullable =true,  Length =10 )]
 public  System.Int32 acct_id  { get { return _acct_id; } set { _acct_id = value; } }

 private System.String _acct_guid;
 /// <summary>
 /// 
 /// </summary>
 [BindColumn(43,"a", "acct_guid", "","", "NCHAR", 38,0,false, IsPrimaryKey =false ,IsIdentity =false,IsNullable =true,  Length =38 )]
 public  System.String acct_guid  { get { return _acct_guid; } set { _acct_guid = value; } }

 private System.Int32 _clndr_id;
 /// <summary>
 /// 
 /// </summary>
 [BindColumn(44,"a", "clndr_id", "","", "NCHAR", 10,0,false, IsPrimaryKey =false ,IsIdentity =false,IsNullable =true,  Length =10 )]
 public  System.Int32 clndr_id  { get { return _clndr_id; } set { _clndr_id = value; } }

 private System.String _clndr_guid;
 /// <summary>
 /// 
 /// </summary>
 [BindColumn(45,"a", "clndr_guid", "","", "NCHAR", 38,0,false, IsPrimaryKey =false ,IsIdentity =false,IsNullable =true,  Length =38 )]
 public  System.String clndr_guid  { get { return _clndr_guid; } set { _clndr_guid = value; } }

 private System.Int32 _week_id;
 /// <summary>
 /// 
 /// </summary>
 [BindColumn(46,"a", "week_id", "","", "NCHAR", 10,0,false, IsPrimaryKey =false ,IsIdentity =false,IsNullable =true,  Length =10 )]
 public  System.Int32 week_id  { get { return _week_id; } set { _week_id = value; } }

 private System.DateTime _update_date;
 /// <summary>
 /// 
 /// </summary>
 [BindColumn(47,"a", "update_date", "","", "NCHAR", 3,0,false, IsPrimaryKey =false ,IsIdentity =false,IsNullable =true,  Length =3 )]
 public  System.DateTime update_date  { get { return _update_date; } set { _update_date = value; } }

 private System.Decimal _critical_drtn_hr_cnt;
 /// <summary>
 /// 
 /// </summary>
 [BindColumn(48,"a", "critical_drtn_hr_cnt", "","", "NCHAR", 10,0,false, IsPrimaryKey =false ,IsIdentity =false,IsNullable =true,  Length =10 )]
 public  System.Decimal critical_drtn_hr_cnt  { get { return _critical_drtn_hr_cnt; } set { _critical_drtn_hr_cnt = value; } }

 private System.String _critical_path_type;
 /// <summary>
 /// 
 /// </summary>
 [BindColumn(49,"a", "critical_path_type", "","", "NCHAR", 12,0,false, IsPrimaryKey =false ,IsIdentity =false,IsNullable =true,  Length =12 )]
 public  System.String critical_path_type  { get { return _critical_path_type; } set { _critical_path_type = value; } }

 private System.DateTime _start_date;
 /// <summary>
 /// 
 /// </summary>
 [BindColumn(50,"a", "start_date", "","", "NCHAR", 3,0,false, IsPrimaryKey =false ,IsIdentity =false,IsNullable =true,  Length =3 )]
 public  System.DateTime start_date  { get { return _start_date; } set { _start_date = value; } }

 private System.DateTime _end_date;
 /// <summary>
 /// 
 /// </summary>
 [BindColumn(51,"a", "end_date", "","", "NCHAR", 3,0,false, IsPrimaryKey =false ,IsIdentity =false,IsNullable =true,  Length =3 )]
 public  System.DateTime end_date  { get { return _end_date; } set { _end_date = value; } }

 private System.Int32 _Pro_owners;
 /// <summary>
 /// 
 /// </summary>
 [BindColumn(52,"a", "Pro_owners", "","", "NCHAR", 10,0,false, IsPrimaryKey =false ,IsIdentity =false,IsNullable =true,  Length =10 )]
 public  System.Int32 Pro_owners  { get { return _Pro_owners; } set { _Pro_owners = value; } }

 private System.Int32 _Pro_manager;
 /// <summary>
 /// 
 /// </summary>
 [BindColumn(53,"a", "Pro_manager", "","", "NCHAR", 10,0,false, IsPrimaryKey =false ,IsIdentity =false,IsNullable =true,  Length =10 )]
 public  System.Int32 Pro_manager  { get { return _Pro_manager; } set { _Pro_manager = value; } }

 private System.DateTime _Pro_time;
 /// <summary>
 /// 
 /// </summary>
 [BindColumn(54,"a", "Pro_time", "","", "NCHAR", 3,0,false, IsPrimaryKey =false ,IsIdentity =false,IsNullable =true,  Length =3 )]
 public  System.DateTime Pro_time  { get { return _Pro_time; } set { _Pro_time = value; } }

 private System.String _Pro_general_situation;
 /// <summary>
 /// 
 /// </summary>
 [BindColumn(55,"a", "Pro_general_situation", "","", "NCHAR", 2147483647,0,false, IsPrimaryKey =false ,IsIdentity =false,IsNullable =true,  Length =2147483647 )]
 public  System.String Pro_general_situation  { get { return _Pro_general_situation; } set { _Pro_general_situation = value; } }

 private System.String _Pro_Construction_content;
 /// <summary>
 /// 
 /// </summary>
 [BindColumn(56,"a", "Pro_Construction_content", "","", "NCHAR", 2147483647,0,false, IsPrimaryKey =false ,IsIdentity =false,IsNullable =true,  Length =2147483647 )]
 public  System.String Pro_Construction_content  { get { return _Pro_Construction_content; } set { _Pro_Construction_content = value; } }

 private System.Decimal _Pro_total;
 /// <summary>
 /// 
 /// </summary>
 [BindColumn(57,"a", "Pro_total", "","", "NCHAR", 19,0,false, IsPrimaryKey =false ,IsIdentity =false,IsNullable =true,  Length =19 )]
 public  System.Decimal Pro_total  { get { return _Pro_total; } set { _Pro_total = value; } }

 private System.Int32 _STATE;
 /// <summary>
 /// 
 /// </summary>
 [BindColumn(58,"a", "STATE", "","", "NCHAR", 10,0,false, IsPrimaryKey =false ,IsIdentity =false,IsNullable =true,  Length =10 )]
 public  System.Int32 STATE  { get { return _STATE; } set { _STATE = value; } }

 private System.String _zuzhijigou;
 /// <summary>
 /// 
 /// </summary>
 [BindColumn(59,"a", "zuzhijigou", "","", "NCHAR", 2147483647,0,false, IsPrimaryKey =false ,IsIdentity =false,IsNullable =true,  Length =2147483647 )]
 public  System.String zuzhijigou  { get { return _zuzhijigou; } set { _zuzhijigou = value; } }

 private System.Int32 _isLiXiang;
 /// <summary>
 /// 
 /// </summary>
 [BindColumn(60,"a", "isLiXiang", "","", "NCHAR", 10,0,false, IsPrimaryKey =false ,IsIdentity =false,IsNullable =true,  Length =10 )]
 public  System.Int32 isLiXiang  { get { return _isLiXiang; } set { _isLiXiang = value; } }

 private System.Int32 _adder_sid;
 /// <summary>
 /// 
 /// </summary>
 [BindColumn(61,"a", "adder_sid", "","", "NCHAR", 10,0,false, IsPrimaryKey =false ,IsIdentity =false,IsNullable =true,  Length =10 )]
 public  System.Int32 adder_sid  { get { return _adder_sid; } set { _adder_sid = value; } }

 private System.DateTime _add_date;
 /// <summary>
 /// 
 /// </summary>
 [BindColumn(62,"a", "add_date", "","", "NCHAR", 3,0,false, IsPrimaryKey =false ,IsIdentity =false,IsNullable =true,  Length =3 )]
 public  System.DateTime add_date  { get { return _add_date; } set { _add_date = value; } }

 private System.Boolean _if_plan;
 /// <summary>
 /// 
 /// </summary>
 [BindColumn(63,"a", "if_plan", "","", "NCHAR", 1,0,false, IsPrimaryKey =false ,IsIdentity =false,IsNullable =true,  Length =1 )]
 public  System.Boolean if_plan  { get { return _if_plan; } set { _if_plan = value; } }

 private System.String _LongCode;
 /// <summary>
 /// 
 /// </summary>
 [BindColumn(64,"a", "LongCode", "","", "NCHAR", 1000,0,false, IsPrimaryKey =false ,IsIdentity =false,IsNullable =true,  Length =1000 )]
 public  System.String LongCode  { get { return _LongCode; } set { _LongCode = value; } }

 private System.Guid _Pro_manager_guid;
 /// <summary>
 /// 
 /// </summary>
 [BindColumn(66,"a", "Pro_manager_guid", "","", "NCHAR", 16,0,false, IsPrimaryKey =false ,IsIdentity =false,IsNullable =true,  Length =16 )]
 public  System.Guid Pro_manager_guid  { get { return _Pro_manager_guid; } set { _Pro_manager_guid = value; } }

 private System.String _Pro_manager_name;
 /// <summary>
 /// 
 /// </summary>
 [BindColumn(67,"a", "Pro_manager_name", "","", "NCHAR", 50,0,false, IsPrimaryKey =false ,IsIdentity =false,IsNullable =true,  Length =50 )]
 public  System.String Pro_manager_name  { get { return _Pro_manager_name; } set { _Pro_manager_name = value; } }

 private System.Guid _Pro_owners_guid;
 /// <summary>
 /// 
 /// </summary>
 [BindColumn(68,"a", "Pro_owners_guid", "","", "NCHAR", 16,0,false, IsPrimaryKey =false ,IsIdentity =false,IsNullable =true,  Length =16 )]
 public  System.Guid Pro_owners_guid  { get { return _Pro_owners_guid; } set { _Pro_owners_guid = value; } }

 private System.String _Pro_owners_name;
 /// <summary>
 /// 
 /// </summary>
 [BindColumn(69,"a", "Pro_owners_name", "","", "NCHAR", 200,0,false, IsPrimaryKey =false ,IsIdentity =false,IsNullable =true,  Length =200 )]
 public  System.String Pro_owners_name  { get { return _Pro_owners_name; } set { _Pro_owners_name = value; } }

 private System.Int32 _UseOwnProjRight;
 /// <summary>
 /// 1启用普通项目范围权限,0不启用
 /// </summary>
 [BindColumn(70,"a", "UseOwnProjRight", "1启用普通项目范围权限,0不启用","", "NCHAR", 10,0,false, IsPrimaryKey =false ,IsIdentity =false,IsNullable =true,  Length =10 )]
 public  System.Int32 UseOwnProjRight  { get { return _UseOwnProjRight; } set { _UseOwnProjRight = value; } }

 private System.Int32 _EpsProjType;
 /// <summary>
 /// 管理层级类型；0非管理层级，1总公司，2分公司，3项目群，4项目...
 /// </summary>
 [BindColumn(71,"a", "EpsProjType", "管理层级类型；0非管理层级，1总公司，2分公司，3项目群，4项目...","", "NCHAR", 10,0,false, IsPrimaryKey =false ,IsIdentity =false,IsNullable =true,  Length =10 )]
 public  System.Int32 EpsProjType  { get { return _EpsProjType; } set { _EpsProjType = value; } }

 private System.String _EpsProjName;
 /// <summary>
 /// 管理层级名称
 /// </summary>
 [BindColumn(73,"a", "EpsProjName", "管理层级名称","", "NCHAR", 255,0,false, IsPrimaryKey =false ,IsIdentity =false,IsNullable =true,  Length =255 )]
 public  System.String EpsProjName  { get { return _EpsProjName; } set { _EpsProjName = value; } }

 private System.Decimal _est_wt_value;
 /// <summary>
 /// 
 /// </summary>
 [BindColumn(74,"a", "est_wt_value", "","100", "NCHAR", 17,6,false, IsPrimaryKey =false ,IsIdentity =false,IsNullable =true,  Length =17 )]
 public  System.Decimal est_wt_value  { get { return _est_wt_value; } set { _est_wt_value = value; } }

 private System.Decimal _Longitude;
 /// <summary>
 /// 
 /// </summary>
 [BindColumn(75,"a", "Longitude", "","", "NCHAR", 18,7,false, IsPrimaryKey =false ,IsIdentity =false,IsNullable =true,  Length =18 )]
 public  System.Decimal Longitude  { get { return _Longitude; } set { _Longitude = value; } }

 private System.Decimal _Latitude;
 /// <summary>
 /// 
 /// </summary>
 [BindColumn(76,"a", "Latitude", "","", "NCHAR", 18,7,false, IsPrimaryKey =false ,IsIdentity =false,IsNullable =true,  Length =18 )]
 public  System.Decimal Latitude  { get { return _Latitude; } set { _Latitude = value; } }

 private System.Guid _RegHumId;
 /// <summary>
 /// 
 /// </summary>
 [BindColumn(77,"a", "RegHumId", "","", "NCHAR", 16,0,false, IsPrimaryKey =false ,IsIdentity =false,IsNullable =true,  Length =16 )]
 public  System.Guid RegHumId  { get { return _RegHumId; } set { _RegHumId = value; } }

 private System.String _RegHumName;
 /// <summary>
 /// 
 /// </summary>
 [BindColumn(78,"a", "RegHumName", "","", "NCHAR", 255,0,false, IsPrimaryKey =false ,IsIdentity =false,IsNullable =true,  Length =255 )]
 public  System.String RegHumName  { get { return _RegHumName; } set { _RegHumName = value; } }

 private System.DateTime _RegDate;
 /// <summary>
 /// 
 /// </summary>
 [BindColumn(79,"a", "RegDate", "","", "NCHAR", 3,0,false, IsPrimaryKey =false ,IsIdentity =false,IsNullable =true,  Length =3 )]
 public  System.DateTime RegDate  { get { return _RegDate; } set { _RegDate = value; } }

      
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
			    if (name == "EPSPROJID")
{
return _EpsProjId;
}
if (name == "PROJECT_ID")
{
return _project_id;
}
if (name == "BIZAREAID")
{
return _BizAreaId;
}
if (name == "PROJECT_GUID")
{
return _project_guid;
}
if (name == "PROJECT_SHORTNAME")
{
return _project_shortname;
}
if (name == "PROJECT_NAME")
{
return _project_name;
}
if (name == "PARENT_ID")
{
return _parent_id;
}
if (name == "PARENT_GUID")
{
return _parent_guid;
}
if (name == "REMARK")
{
return _remark;
}
if (name == "USER_SID")
{
return _user_sid;
}
if (name == "USER_GUID")
{
return _user_guid;
}
if (name == "PROJECT_TYPE")
{
return _project_type;
}
if (name == "EST_WT")
{
return _est_wt;
}
if (name == "OBS_SID")
{
return _obs_sid;
}
if (name == "OBS_GUID")
{
return _obs_guid;
}
if (name == "HASCHILD")
{
return _haschild;
}
if (name == "P3EC")
{
return _p3ec;
}
if (name == "TREELEVEL")
{
return _treelevel;
}
if (name == "NOTE")
{
return _note;
}
if (name == "P3EC_PROJECT_ID")
{
return _p3ec_project_id;
}
if (name == "CONTRACT_ID")
{
return _contract_id;
}
if (name == "DISPLAYID")
{
return _displayid;
}
if (name == "DISCOLOR")
{
return _discolor;
}
if (name == "PROJECT_TYPE_SID")
{
return _project_type_sid;
}
if (name == "PROJECT_STATUS_SID")
{
return _project_status_sid;
}
if (name == "PROJECT_ADDRESS")
{
return _project_address;
}
if (name == "TARGET_START_DATE")
{
return _target_start_date;
}
if (name == "TARGET_END_DATE")
{
return _target_end_date;
}
if (name == "ACT_START_DATE")
{
return _act_start_date;
}
if (name == "ACT_END_DATE")
{
return _act_end_date;
}
if (name == "DATA_DATE")
{
return _data_date;
}
if (name == "COMPUTE_END_DATE")
{
return _compute_end_date;
}
if (name == "EXPECT_START_DATE")
{
return _expect_start_date;
}
if (name == "EXPECT_END_DATE")
{
return _expect_end_date;
}
if (name == "UNCONTRACT_ID")
{
return _unContract_id;
}
if (name == "COMPLETE_PCT")
{
return _complete_pct;
}
if (name == "ALLOW_DIY_WEB")
{
return _allow_diy_web;
}
if (name == "PROGRAM_ID")
{
return _program_id;
}
if (name == "RISK_LEVEL")
{
return _risk_level;
}
if (name == "PROJ_URL")
{
return _proj_url;
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
if (name == "WEEK_ID")
{
return _week_id;
}
if (name == "UPDATE_DATE")
{
return _update_date;
}
if (name == "CRITICAL_DRTN_HR_CNT")
{
return _critical_drtn_hr_cnt;
}
if (name == "CRITICAL_PATH_TYPE")
{
return _critical_path_type;
}
if (name == "START_DATE")
{
return _start_date;
}
if (name == "END_DATE")
{
return _end_date;
}
if (name == "PRO_OWNERS")
{
return _Pro_owners;
}
if (name == "PRO_MANAGER")
{
return _Pro_manager;
}
if (name == "PRO_TIME")
{
return _Pro_time;
}
if (name == "PRO_GENERAL_SITUATION")
{
return _Pro_general_situation;
}
if (name == "PRO_CONSTRUCTION_CONTENT")
{
return _Pro_Construction_content;
}
if (name == "PRO_TOTAL")
{
return _Pro_total;
}
if (name == "STATE")
{
return _STATE;
}
if (name == "ZUZHIJIGOU")
{
return _zuzhijigou;
}
if (name == "ISLIXIANG")
{
return _isLiXiang;
}
if (name == "ADDER_SID")
{
return _adder_sid;
}
if (name == "ADD_DATE")
{
return _add_date;
}
if (name == "IF_PLAN")
{
return _if_plan;
}
if (name == "LONGCODE")
{
return _LongCode;
}
if (name == "PRO_MANAGER_GUID")
{
return _Pro_manager_guid;
}
if (name == "PRO_MANAGER_NAME")
{
return _Pro_manager_name;
}
if (name == "PRO_OWNERS_GUID")
{
return _Pro_owners_guid;
}
if (name == "PRO_OWNERS_NAME")
{
return _Pro_owners_name;
}
if (name == "USEOWNPROJRIGHT")
{
return _UseOwnProjRight;
}
if (name == "EPSPROJTYPE")
{
return _EpsProjType;
}
if (name == "EPSPROJNAME")
{
return _EpsProjName;
}
if (name == "EST_WT_VALUE")
{
return _est_wt_value;
}
if (name == "LONGITUDE")
{
return _Longitude;
}
if (name == "LATITUDE")
{
return _Latitude;
}
if (name == "REGHUMID")
{
return _RegHumId;
}
if (name == "REGHUMNAME")
{
return _RegHumName;
}
if (name == "REGDATE")
{
return _RegDate;
}

			    return base[name];
			}
			set 
			{
			   name = name.ToUpper();
			       if (name == "EPSPROJID")
{
 _EpsProjId = System.Convert.ToString(value);return;
}
if (name == "PROJECT_ID")
{
 _project_id = System.Convert.ToInt32(value);return;
}
if (name == "BIZAREAID")
{
 _BizAreaId = XCode.Common.Helper.ConvertToGuid(value);return;
}
if (name == "PROJECT_GUID")
{
 _project_guid = System.Convert.ToString(value);return;
}
if (name == "PROJECT_SHORTNAME")
{
 _project_shortname = System.Convert.ToString(value);return;
}
if (name == "PROJECT_NAME")
{
 _project_name = System.Convert.ToString(value);return;
}
if (name == "PARENT_ID")
{
 _parent_id = System.Convert.ToInt32(value);return;
}
if (name == "PARENT_GUID")
{
 _parent_guid = System.Convert.ToString(value);return;
}
if (name == "REMARK")
{
 _remark = System.Convert.ToString(value);return;
}
if (name == "USER_SID")
{
 _user_sid = System.Convert.ToInt32(value);return;
}
if (name == "USER_GUID")
{
 _user_guid = System.Convert.ToString(value);return;
}
if (name == "PROJECT_TYPE")
{
 _project_type = System.Convert.ToInt32(value);return;
}
if (name == "EST_WT")
{
 _est_wt = System.Convert.ToDecimal(value);return;
}
if (name == "OBS_SID")
{
 _obs_sid = System.Convert.ToInt32(value);return;
}
if (name == "OBS_GUID")
{
 _obs_guid = System.Convert.ToString(value);return;
}
if (name == "HASCHILD")
{
 _haschild = System.Convert.ToInt32(value);return;
}
if (name == "P3EC")
{
 _p3ec = System.Convert.ToInt32(value);return;
}
if (name == "TREELEVEL")
{
 _treelevel = System.Convert.ToInt32(value);return;
}
if (name == "NOTE")
{
 _note = System.Convert.ToString(value);return;
}
if (name == "P3EC_PROJECT_ID")
{
 _p3ec_project_id = System.Convert.ToInt32(value);return;
}
if (name == "CONTRACT_ID")
{
 _contract_id = System.Convert.ToInt32(value);return;
}
if (name == "DISPLAYID")
{
 _displayid = System.Convert.ToInt32(value);return;
}
if (name == "DISCOLOR")
{
 _discolor = System.Convert.ToInt32(value);return;
}
if (name == "PROJECT_TYPE_SID")
{
 _project_type_sid = System.Convert.ToInt32(value);return;
}
if (name == "PROJECT_STATUS_SID")
{
 _project_status_sid = System.Convert.ToInt32(value);return;
}
if (name == "PROJECT_ADDRESS")
{
 _project_address = System.Convert.ToString(value);return;
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
if (name == "UNCONTRACT_ID")
{
 _unContract_id = System.Convert.ToInt32(value);return;
}
if (name == "COMPLETE_PCT")
{
 _complete_pct = System.Convert.ToDecimal(value);return;
}
if (name == "ALLOW_DIY_WEB")
{
 _allow_diy_web = System.Convert.ToBoolean(value);return;
}
if (name == "PROGRAM_ID")
{
 _program_id = System.Convert.ToInt32(value);return;
}
if (name == "RISK_LEVEL")
{
 _risk_level = System.Convert.ToInt32(value);return;
}
if (name == "PROJ_URL")
{
 _proj_url = System.Convert.ToString(value);return;
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
 _clndr_guid = System.Convert.ToString(value);return;
}
if (name == "WEEK_ID")
{
 _week_id = System.Convert.ToInt32(value);return;
}
if (name == "UPDATE_DATE")
{
 if (value == null || value.ToString().IsNullOrEmpty() == true) value = DateTime.MinValue;
 _update_date = System.Convert.ToDateTime(value);return;
}
if (name == "CRITICAL_DRTN_HR_CNT")
{
 _critical_drtn_hr_cnt = System.Convert.ToDecimal(value);return;
}
if (name == "CRITICAL_PATH_TYPE")
{
 _critical_path_type = System.Convert.ToString(value);return;
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
if (name == "PRO_OWNERS")
{
 _Pro_owners = System.Convert.ToInt32(value);return;
}
if (name == "PRO_MANAGER")
{
 _Pro_manager = System.Convert.ToInt32(value);return;
}
if (name == "PRO_TIME")
{
 if (value == null || value.ToString().IsNullOrEmpty() == true) value = DateTime.MinValue;
 _Pro_time = System.Convert.ToDateTime(value);return;
}
if (name == "PRO_GENERAL_SITUATION")
{
 _Pro_general_situation = System.Convert.ToString(value);return;
}
if (name == "PRO_CONSTRUCTION_CONTENT")
{
 _Pro_Construction_content = System.Convert.ToString(value);return;
}
if (name == "PRO_TOTAL")
{
 _Pro_total = System.Convert.ToDecimal(value);return;
}
if (name == "STATE")
{
 _STATE = System.Convert.ToInt32(value);return;
}
if (name == "ZUZHIJIGOU")
{
 _zuzhijigou = System.Convert.ToString(value);return;
}
if (name == "ISLIXIANG")
{
 _isLiXiang = System.Convert.ToInt32(value);return;
}
if (name == "ADDER_SID")
{
 _adder_sid = System.Convert.ToInt32(value);return;
}
if (name == "ADD_DATE")
{
 if (value == null || value.ToString().IsNullOrEmpty() == true) value = DateTime.MinValue;
 _add_date = System.Convert.ToDateTime(value);return;
}
if (name == "IF_PLAN")
{
 _if_plan = System.Convert.ToBoolean(value);return;
}
if (name == "LONGCODE")
{
 _LongCode = System.Convert.ToString(value);return;
}
if (name == "PRO_MANAGER_GUID")
{
 _Pro_manager_guid = XCode.Common.Helper.ConvertToGuid(value);return;
}
if (name == "PRO_MANAGER_NAME")
{
 _Pro_manager_name = System.Convert.ToString(value);return;
}
if (name == "PRO_OWNERS_GUID")
{
 _Pro_owners_guid = XCode.Common.Helper.ConvertToGuid(value);return;
}
if (name == "PRO_OWNERS_NAME")
{
 _Pro_owners_name = System.Convert.ToString(value);return;
}
if (name == "USEOWNPROJRIGHT")
{
 _UseOwnProjRight = System.Convert.ToInt32(value);return;
}
if (name == "EPSPROJTYPE")
{
 _EpsProjType = System.Convert.ToInt32(value);return;
}
if (name == "EPSPROJNAME")
{
 _EpsProjName = System.Convert.ToString(value);return;
}
if (name == "EST_WT_VALUE")
{
 _est_wt_value = System.Convert.ToDecimal(value);return;
}
if (name == "LONGITUDE")
{
 _Longitude = System.Convert.ToDecimal(value);return;
}
if (name == "LATITUDE")
{
 _Latitude = System.Convert.ToDecimal(value);return;
}
if (name == "REGHUMID")
{
 _RegHumId = XCode.Common.Helper.ConvertToGuid(value);return;
}
if (name == "REGHUMNAME")
{
 _RegHumName = System.Convert.ToString(value);return;
}
if (name == "REGDATE")
{
 if (value == null || value.ToString().IsNullOrEmpty() == true) value = DateTime.MinValue;
 _RegDate = System.Convert.ToDateTime(value);return;
}

			    base[name] = value;
			}
		}
		#endregion
	}
}