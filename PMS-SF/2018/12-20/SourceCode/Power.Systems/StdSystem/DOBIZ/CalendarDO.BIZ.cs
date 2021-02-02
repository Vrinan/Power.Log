 
 
 using    System;
 using System.Collections.Generic;
 using System.Text; 
 using XCode.Attributes    ;

 namespace  Power.Systems.StdSystem
{
    /// <summary>
    /// 计划日历
    /// </summary>
    public class CalendarDO : CalendarDO<CalendarDO>
    {

    }

	/// <summary>
    /// 计划日历
    /// </summary>
	  [BindEntity(KeyWord="Calendar",EntityType = typeof(Power.Systems.StdSystem.CalendarDO),Description = "计划日历"  )] 

	 [BindTable( "calendar", Alias = "a",IsAttach=false,Description ="")]

	  [BindIndex(Name = "pk_calendar", KeyType = Power.DataAccessLayer.KeyType.MainKey, Columns = "clndr_guid", TableName = "calendar",Description="")]

    public   class CalendarDO<TEntity> : XCode.Entity<TEntity>, XCode.IEntity where TEntity : Power.Systems.StdSystem.CalendarDO<TEntity>, new()
    { 
	    #region 属性

	    
 private System.Int32 _clndr_id;
 /// <summary>
 /// 
 /// </summary>
 [BindColumn(1,"a", "clndr_id", "","", "NCHAR", 10,0,false, IsPrimaryKey =false ,IsIdentity =false,IsNullable =false,  Length =10 )]
 public  System.Int32 clndr_id  { get { return _clndr_id; } set { _clndr_id = value; } }

 private System.String _clndr_name;
 /// <summary>
 /// 
 /// </summary>
 [BindColumn(2,"a", "clndr_name", "","", "NCHAR", 50,0,false, IsPrimaryKey =false ,IsIdentity =false,IsNullable =true,  Length =50 )]
 public  System.String clndr_name  { get { return _clndr_name; } set { _clndr_name = value; } }

 private System.Int32 _day_hr_cnt;
 /// <summary>
 /// 
 /// </summary>
 [BindColumn(3,"a", "day_hr_cnt", "","", "NCHAR", 10,0,false, IsPrimaryKey =false ,IsIdentity =false,IsNullable =true,  Length =10 )]
 public  System.Int32 day_hr_cnt  { get { return _day_hr_cnt; } set { _day_hr_cnt = value; } }

 private System.Int32 _week_hr_cnt;
 /// <summary>
 /// 
 /// </summary>
 [BindColumn(4,"a", "week_hr_cnt", "","", "NCHAR", 10,0,false, IsPrimaryKey =false ,IsIdentity =false,IsNullable =true,  Length =10 )]
 public  System.Int32 week_hr_cnt  { get { return _week_hr_cnt; } set { _week_hr_cnt = value; } }

 private System.Int32 _month_hr_cnt;
 /// <summary>
 /// 
 /// </summary>
 [BindColumn(5,"a", "month_hr_cnt", "","", "NCHAR", 10,0,false, IsPrimaryKey =false ,IsIdentity =false,IsNullable =true,  Length =10 )]
 public  System.Int32 month_hr_cnt  { get { return _month_hr_cnt; } set { _month_hr_cnt = value; } }

 private System.Int32 _year_hr_cnt;
 /// <summary>
 /// 
 /// </summary>
 [BindColumn(6,"a", "year_hr_cnt", "","", "NCHAR", 10,0,false, IsPrimaryKey =false ,IsIdentity =false,IsNullable =true,  Length =10 )]
 public  System.Int32 year_hr_cnt  { get { return _year_hr_cnt; } set { _year_hr_cnt = value; } }

 private System.String _default_flag;
 /// <summary>
 /// 
 /// </summary>
 [BindColumn(7,"a", "default_flag", "","", "NCHAR", 255,0,false, IsPrimaryKey =false ,IsIdentity =false,IsNullable =true,  Length =255 )]
 public  System.String default_flag  { get { return _default_flag; } set { _default_flag = value; } }

 private System.String _clndr_guid;
 /// <summary>
 /// 
 /// </summary>
 [BindColumn(8,"a", "clndr_guid", "","newid()", "NCHAR", 38,0,false, IsPrimaryKey =true ,IsIdentity =true,IsNullable =false,  Length =38 )]
 public virtual System.String clndr_guid  { get { return _clndr_guid; } set { _clndr_guid = value; } }

 private System.String _clndr_type;
 /// <summary>
 /// 
 /// </summary>
 [BindColumn(9,"a", "clndr_type", "","", "NCHAR", 16,0,false, IsPrimaryKey =false ,IsIdentity =false,IsNullable =true,  Length =16 )]
 public  System.String clndr_type  { get { return _clndr_type; } set { _clndr_type = value; } }

 private System.String _clndr_data;
 /// <summary>
 /// 
 /// </summary>
 [BindColumn(10,"a", "clndr_data", "","", "NCHAR", 2147483647,0,false, IsPrimaryKey =false ,IsIdentity =false,IsNullable =true,  Length =2147483647 )]
 public  System.String clndr_data  { get { return _clndr_data; } set { _clndr_data = value; } }

      
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
			    if (name == "CLNDR_ID")
{
return _clndr_id;
}
if (name == "CLNDR_NAME")
{
return _clndr_name;
}
if (name == "DAY_HR_CNT")
{
return _day_hr_cnt;
}
if (name == "WEEK_HR_CNT")
{
return _week_hr_cnt;
}
if (name == "MONTH_HR_CNT")
{
return _month_hr_cnt;
}
if (name == "YEAR_HR_CNT")
{
return _year_hr_cnt;
}
if (name == "DEFAULT_FLAG")
{
return _default_flag;
}
if (name == "CLNDR_GUID")
{
return _clndr_guid;
}
if (name == "CLNDR_TYPE")
{
return _clndr_type;
}
if (name == "CLNDR_DATA")
{
return _clndr_data;
}

			    return base[name];
			}
			set 
			{
			   name = name.ToUpper();
			       if (name == "CLNDR_ID")
{
 _clndr_id = System.Convert.ToInt32(value);return;
}
if (name == "CLNDR_NAME")
{
 _clndr_name = System.Convert.ToString(value);return;
}
if (name == "DAY_HR_CNT")
{
 _day_hr_cnt = System.Convert.ToInt32(value);return;
}
if (name == "WEEK_HR_CNT")
{
 _week_hr_cnt = System.Convert.ToInt32(value);return;
}
if (name == "MONTH_HR_CNT")
{
 _month_hr_cnt = System.Convert.ToInt32(value);return;
}
if (name == "YEAR_HR_CNT")
{
 _year_hr_cnt = System.Convert.ToInt32(value);return;
}
if (name == "DEFAULT_FLAG")
{
 _default_flag = System.Convert.ToString(value);return;
}
if (name == "CLNDR_GUID")
{
 _clndr_guid = System.Convert.ToString(value);return;
}
if (name == "CLNDR_TYPE")
{
 _clndr_type = System.Convert.ToString(value);return;
}
if (name == "CLNDR_DATA")
{
 _clndr_data = System.Convert.ToString(value);return;
}

			    base[name] = value;
			}
		}
		#endregion
	}
}