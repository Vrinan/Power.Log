 
 
 using    System;
 using System.Collections.Generic;
 using System.Text; 
 using XCode.Attributes    ;

 namespace  Power.Systems.StdSystem
{
    /// <summary>
    /// EPSProject
    /// </summary>
    public class EPSProjectDO : EPSProjectDO<EPSProjectDO>
    {

    }

	/// <summary>
    /// EPSProject
    /// </summary>
	  [BindEntity(KeyWord="EPSProject",EntityType = typeof(Power.Systems.StdSystem.EPSProjectDO),Description = "EPSProject"  )] 

	 [BindTable( "PLN_project", Alias = "a",IsAttach=false,Description ="")]

	  [BindIndex(Name = "pk_PLN_project", KeyType = Power.DataAccessLayer.KeyType.MainKey, Columns = "project_guid", TableName = "PLN_project",Description="")]
 [BindIndex(Name = "pt_PLN_project", KeyType = Power.DataAccessLayer.KeyType.ParentKey, Columns = "parent_guid,project_guid", TableName = "PLN_project",Description="")]

    public   class EPSProjectDO<TEntity> : XCode.Entity<TEntity>, XCode.IEntity where TEntity : Power.Systems.StdSystem.EPSProjectDO<TEntity>, new()
    { 
	    #region 属性

	    
 private System.Guid _BizAreaId;
 /// <summary>
 /// 
 /// </summary>
 [BindColumn(1,"a", "BizAreaId", "","", "NCHAR", 0,0,false, IsPrimaryKey =false ,IsIdentity =false,IsNullable =true,  Length =0 )]
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
 [BindColumn(7,"a", "remark", "","", "NCHAR", 50,0,false, IsPrimaryKey =false ,IsIdentity =false,IsNullable =true,  Length =50 )]
 public  System.String remark  { get { return _remark; } set { _remark = value; } }

 private System.Int32 _project_type;
 /// <summary>
 /// 
 /// </summary>
 [BindColumn(10,"a", "project_type", "","", "NCHAR", 10,0,false, IsPrimaryKey =false ,IsIdentity =false,IsNullable =true,  Length =10 )]
 public  System.Int32 project_type  { get { return _project_type; } set { _project_type = value; } }

 private System.Int32 _displayid;
 /// <summary>
 /// 
 /// </summary>
 [BindColumn(20,"a", "displayid", "","", "NCHAR", 10,0,false, IsPrimaryKey =false ,IsIdentity =false,IsNullable =true,  Length =10 )]
 public  System.Int32 displayid  { get { return _displayid; } set { _displayid = value; } }

 private System.String _LongCode;
 /// <summary>
 /// 
 /// </summary>
 [BindColumn(64,"a", "LongCode", "","", "NCHAR", 1000,0,false, IsPrimaryKey =false ,IsIdentity =false,IsNullable =true,  Length =1000 )]
 public  System.String LongCode  { get { return _LongCode; } set { _LongCode = value; } }

      
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
if (name == "PARENT_GUID")
{
return _parent_guid;
}
if (name == "REMARK")
{
return _remark;
}
if (name == "PROJECT_TYPE")
{
return _project_type;
}
if (name == "DISPLAYID")
{
return _displayid;
}
if (name == "LONGCODE")
{
return _LongCode;
}

			    return base[name];
			}
			set 
			{
			   name = name.ToUpper();
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
if (name == "PARENT_GUID")
{
 _parent_guid = System.Convert.ToString(value);return;
}
if (name == "REMARK")
{
 _remark = System.Convert.ToString(value);return;
}
if (name == "PROJECT_TYPE")
{
 _project_type = System.Convert.ToInt32(value);return;
}
if (name == "DISPLAYID")
{
 _displayid = System.Convert.ToInt32(value);return;
}
if (name == "LONGCODE")
{
 _LongCode = System.Convert.ToString(value);return;
}

			    base[name] = value;
			}
		}
		#endregion
	}
}