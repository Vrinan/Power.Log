 
 
 using    System;
 using System.Collections.Generic;
 using System.Text; 
 using XCode.Attributes    ;

 namespace  Power.Systems.StdPlan
{
    /// <summary>
    /// 项目赢得值
    /// </summary>
    public class ProjBCWSDO : ProjBCWSDO<ProjBCWSDO>
    {

    }

	/// <summary>
    /// 项目赢得值
    /// </summary>
	  [BindEntity(KeyWord="ProjBCWS",EntityType = typeof(Power.Systems.StdPlan.ProjBCWSDO),Description = "项目赢得值"  )] 

	 [BindTable( "PS_PLN_ProjBCWS", Alias = "a",IsAttach=false,Description ="")]

	  [BindIndex(Name = "pk_PS_PLN_ProjBCWS", KeyType = Power.DataAccessLayer.KeyType.MainKey, Columns = "Id", TableName = "PS_PLN_ProjBCWS",Description="")]

    public   class ProjBCWSDO<TEntity> : XCode.Entity<TEntity>, XCode.IEntity where TEntity : Power.Systems.StdPlan.ProjBCWSDO<TEntity>, new()
    { 
	    #region 属性

	    
 private System.Guid _Id;
 /// <summary>
 /// 
 /// </summary>
 [BindColumn(1,"a", "Id", "","", "NCHAR", 16,0,false, IsPrimaryKey =true ,IsIdentity =true,IsNullable =false,  Length =16 )]
 public virtual System.Guid Id  { get { return _Id; } set { _Id = value; } }

 private System.Guid _period_guid;
 /// <summary>
 /// 
 /// </summary>
 [BindColumn(2,"a", "period_guid", "","", "NCHAR", 16,0,false, IsPrimaryKey =false ,IsIdentity =false,IsNullable =true,  Length =16 )]
 public  System.Guid period_guid  { get { return _period_guid; } set { _period_guid = value; } }

 private System.DateTime _periodstart;
 /// <summary>
 /// 
 /// </summary>
 [BindColumn(3,"a", "periodstart", "","", "NCHAR", 3,0,false, IsPrimaryKey =false ,IsIdentity =false,IsNullable =true,  Length =3 )]
 public  System.DateTime periodstart  { get { return _periodstart; } set { _periodstart = value; } }

 private System.DateTime _periodend;
 /// <summary>
 /// 
 /// </summary>
 [BindColumn(4,"a", "periodend", "","", "NCHAR", 3,0,false, IsPrimaryKey =false ,IsIdentity =false,IsNullable =true,  Length =3 )]
 public  System.DateTime periodend  { get { return _periodend; } set { _periodend = value; } }

 private System.String _type;
 /// <summary>
 /// 
 /// </summary>
 [BindColumn(5,"a", "type", "","", "NCHAR", 50,0,false, IsPrimaryKey =false ,IsIdentity =false,IsNullable =true,  Length =50 )]
 public  System.String type  { get { return _type; } set { _type = value; } }

 private System.Guid _proj_guid;
 /// <summary>
 /// 
 /// </summary>
 [BindColumn(6,"a", "proj_guid", "","", "NCHAR", 16,0,false, IsPrimaryKey =false ,IsIdentity =false,IsNullable =true,  Length =16 )]
 public  System.Guid proj_guid  { get { return _proj_guid; } set { _proj_guid = value; } }

 private System.Guid _plan_guid;
 /// <summary>
 /// 
 /// </summary>
 [BindColumn(7,"a", "plan_guid", "","", "NCHAR", 16,0,false, IsPrimaryKey =false ,IsIdentity =false,IsNullable =true,  Length =16 )]
 public  System.Guid plan_guid  { get { return _plan_guid; } set { _plan_guid = value; } }

 private System.Double _plan_complete_pct;
 /// <summary>
 /// 
 /// </summary>
 [BindColumn(8,"a", "plan_complete_pct", "","", "NCHAR", 53,0,false, IsPrimaryKey =false ,IsIdentity =false,IsNullable =true,  Length =53 )]
 public  System.Double plan_complete_pct  { get { return _plan_complete_pct; } set { _plan_complete_pct = value; } }

 private System.Double _act_complete_pct;
 /// <summary>
 /// 
 /// </summary>
 [BindColumn(9,"a", "act_complete_pct", "","", "NCHAR", 53,0,false, IsPrimaryKey =false ,IsIdentity =false,IsNullable =true,  Length =53 )]
 public  System.Double act_complete_pct  { get { return _act_complete_pct; } set { _act_complete_pct = value; } }

      
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
if (name == "PERIOD_GUID")
{
return _period_guid;
}
if (name == "PERIODSTART")
{
return _periodstart;
}
if (name == "PERIODEND")
{
return _periodend;
}
if (name == "TYPE")
{
return _type;
}
if (name == "PROJ_GUID")
{
return _proj_guid;
}
if (name == "PLAN_GUID")
{
return _plan_guid;
}
if (name == "PLAN_COMPLETE_PCT")
{
return _plan_complete_pct;
}
if (name == "ACT_COMPLETE_PCT")
{
return _act_complete_pct;
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
if (name == "PERIOD_GUID")
{
 _period_guid = XCode.Common.Helper.ConvertToGuid(value);return;
}
if (name == "PERIODSTART")
{
 if (value == null || value.ToString().IsNullOrEmpty() == true) value = DateTime.MinValue;
 _periodstart = System.Convert.ToDateTime(value);return;
}
if (name == "PERIODEND")
{
 if (value == null || value.ToString().IsNullOrEmpty() == true) value = DateTime.MinValue;
 _periodend = System.Convert.ToDateTime(value);return;
}
if (name == "TYPE")
{
 _type = System.Convert.ToString(value);return;
}
if (name == "PROJ_GUID")
{
 _proj_guid = XCode.Common.Helper.ConvertToGuid(value);return;
}
if (name == "PLAN_GUID")
{
 _plan_guid = XCode.Common.Helper.ConvertToGuid(value);return;
}
if (name == "PLAN_COMPLETE_PCT")
{
 _plan_complete_pct = System.Convert.ToDouble(value);return;
}
if (name == "ACT_COMPLETE_PCT")
{
 _act_complete_pct = System.Convert.ToDouble(value);return;
}

			    base[name] = value;
			}
		}
		#endregion
	}
}