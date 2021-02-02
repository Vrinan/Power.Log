 
 
 using    System;
 using System.Collections.Generic;
 using System.Text; 
 using XCode.Attributes    ;

 namespace  Power.Systems.Systems
{
    /// <summary>
    /// 报表表单关联表DO
    /// </summary>
    public class ReportFormDO : ReportFormDO<ReportFormDO>
    {

    }

	/// <summary>
    /// 报表表单关联表DO
    /// </summary>
	  [BindEntity(KeyWord="ReportForm",EntityType = typeof(Power.Systems.Systems.ReportFormDO),Description = "报表表单关联表DO"  )] 

	 [BindTable( "PB_ReportForm", Alias = "a",IsAttach=false,Description ="")]

	  [BindIndex(Name = "pk_PB_ReportForm", KeyType = Power.DataAccessLayer.KeyType.MainKey, Columns = "Id", TableName = "PB_ReportForm",Description="")]

    public   class ReportFormDO<TEntity> : XCode.Entity<TEntity>, XCode.IEntity where TEntity : Power.Systems.Systems.ReportFormDO<TEntity>, new()
    { 
	    #region 属性

	    
 private System.Guid _Id;
 /// <summary>
 /// 
 /// </summary>
 [BindColumn(1,"a", "Id", "","", "NCHAR", 16,0,false, IsPrimaryKey =true ,IsIdentity =true,IsNullable =false,  Length =16 )]
 public virtual System.Guid Id  { get { return _Id; } set { _Id = value; } }

 private System.Guid _MenuId;
 /// <summary>
 /// 
 /// </summary>
 [BindColumn(2,"a", "MenuId", "","", "NCHAR", 16,0,false, IsPrimaryKey =false ,IsIdentity =false,IsNullable =true,  Length =16 )]
 public  System.Guid MenuId  { get { return _MenuId; } set { _MenuId = value; } }

 private System.Guid _ReportId;
 /// <summary>
 /// 
 /// </summary>
 [BindColumn(3,"a", "ReportId", "","", "NCHAR", 16,0,false, IsPrimaryKey =false ,IsIdentity =false,IsNullable =true,  Length =16 )]
 public  System.Guid ReportId  { get { return _ReportId; } set { _ReportId = value; } }

 private System.Guid _WidgetId;
 /// <summary>
 /// 
 /// </summary>
 [BindColumn(4,"a", "WidgetId", "","", "NCHAR", 16,0,false, IsPrimaryKey =false ,IsIdentity =false,IsNullable =true,  Length =16 )]
 public  System.Guid WidgetId  { get { return _WidgetId; } set { _WidgetId = value; } }

 private System.Guid _FormId;
 /// <summary>
 /// 
 /// </summary>
 [BindColumn(5,"a", "FormId", "","", "NCHAR", 16,0,false, IsPrimaryKey =false ,IsIdentity =false,IsNullable =true,  Length =16 )]
 public  System.Guid FormId  { get { return _FormId; } set { _FormId = value; } }

      
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
if (name == "MENUID")
{
return _MenuId;
}
if (name == "REPORTID")
{
return _ReportId;
}
if (name == "WIDGETID")
{
return _WidgetId;
}
if (name == "FORMID")
{
return _FormId;
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
if (name == "MENUID")
{
 _MenuId = XCode.Common.Helper.ConvertToGuid(value);return;
}
if (name == "REPORTID")
{
 _ReportId = XCode.Common.Helper.ConvertToGuid(value);return;
}
if (name == "WIDGETID")
{
 _WidgetId = XCode.Common.Helper.ConvertToGuid(value);return;
}
if (name == "FORMID")
{
 _FormId = XCode.Common.Helper.ConvertToGuid(value);return;
}

			    base[name] = value;
			}
		}
		#endregion
	}
}