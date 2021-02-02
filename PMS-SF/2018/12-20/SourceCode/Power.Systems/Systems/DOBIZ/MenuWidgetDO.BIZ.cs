 
 
 using    System;
 using System.Collections.Generic;
 using System.Text; 
 using XCode.Attributes    ;

 namespace  Power.Systems.Systems
{
    /// <summary>
    /// 功能菜单widget(PB_MenuWidget)
    /// </summary>
    public class MenuWidgetDO : MenuWidgetDO<MenuWidgetDO>
    {

    }

	/// <summary>
    /// 功能菜单widget(PB_MenuWidget)
    /// </summary>
	  [BindEntity(KeyWord="MenuWidget",EntityType = typeof(Power.Systems.Systems.MenuWidgetDO),Description = "功能菜单widget(PB_MenuWidget)"  )] 

	 [BindTable( "PB_MenuWidget", Alias = "a",IsAttach=false,Description ="功能菜单widget")]

	  [BindIndex(Name = "pk_PB_MenuWidget", KeyType = Power.DataAccessLayer.KeyType.MainKey, Columns = "Id", TableName = "PB_MenuWidget",Description="功能菜单widget")]

    public   class MenuWidgetDO<TEntity> : XCode.Entity<TEntity>, XCode.IEntity where TEntity : Power.Systems.Systems.MenuWidgetDO<TEntity>, new()
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

 private System.Guid _WidgetId;
 /// <summary>
 /// 
 /// </summary>
 [BindColumn(3,"a", "WidgetId", "","", "NCHAR", 16,0,false, IsPrimaryKey =false ,IsIdentity =false,IsNullable =true,  Length =16 )]
 public  System.Guid WidgetId  { get { return _WidgetId; } set { _WidgetId = value; } }

 private System.Int32 _Sequ;
 /// <summary>
 /// 
 /// </summary>
 [BindColumn(4,"a", "Sequ", "","", "NCHAR", 10,0,false, IsPrimaryKey =false ,IsIdentity =false,IsNullable =true,  Length =10 )]
 public  System.Int32 Sequ  { get { return _Sequ; } set { _Sequ = value; } }

 private System.Boolean _bClose;
 /// <summary>
 /// 可关闭
 /// </summary>
 [BindColumn(5,"a", "bClose", "可关闭","", "NCHAR", 1,0,false, IsPrimaryKey =false ,IsIdentity =false,IsNullable =true,  Length =1 )]
 public  System.Boolean bClose  { get { return _bClose; } set { _bClose = value; } }

 private System.Boolean _bMax;
 /// <summary>
 /// 可最大化
 /// </summary>
 [BindColumn(6,"a", "bMax", "可最大化","", "NCHAR", 1,0,false, IsPrimaryKey =false ,IsIdentity =false,IsNullable =true,  Length =1 )]
 public  System.Boolean bMax  { get { return _bMax; } set { _bMax = value; } }

 private System.Boolean _bMin;
 /// <summary>
 /// 可最小化
 /// </summary>
 [BindColumn(7,"a", "bMin", "可最小化","", "NCHAR", 1,0,false, IsPrimaryKey =false ,IsIdentity =false,IsNullable =true,  Length =1 )]
 public  System.Boolean bMin  { get { return _bMin; } set { _bMin = value; } }

 private System.Boolean _bMore;
 /// <summary>
 /// 有更多
 /// </summary>
 [BindColumn(8,"a", "bMore", "有更多","", "NCHAR", 1,0,false, IsPrimaryKey =false ,IsIdentity =false,IsNullable =true,  Length =1 )]
 public  System.Boolean bMore  { get { return _bMore; } set { _bMore = value; } }

 private System.String _MoreJson;
 /// <summary>
 /// 更多内容
 /// </summary>
 [BindColumn(9,"a", "MoreJson", "更多内容","", "NCHAR", -1,0,false, IsPrimaryKey =false ,IsIdentity =false,IsNullable =true,  Length =-1 )]
 public  System.String MoreJson  { get { return _MoreJson; } set { _MoreJson = value; } }

      
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
if (name == "WIDGETID")
{
return _WidgetId;
}
if (name == "SEQU")
{
return _Sequ;
}
if (name == "BCLOSE")
{
return _bClose;
}
if (name == "BMAX")
{
return _bMax;
}
if (name == "BMIN")
{
return _bMin;
}
if (name == "BMORE")
{
return _bMore;
}
if (name == "MOREJSON")
{
return _MoreJson;
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
if (name == "WIDGETID")
{
 _WidgetId = XCode.Common.Helper.ConvertToGuid(value);return;
}
if (name == "SEQU")
{
 _Sequ = System.Convert.ToInt32(value);return;
}
if (name == "BCLOSE")
{
 _bClose = System.Convert.ToBoolean(value);return;
}
if (name == "BMAX")
{
 _bMax = System.Convert.ToBoolean(value);return;
}
if (name == "BMIN")
{
 _bMin = System.Convert.ToBoolean(value);return;
}
if (name == "BMORE")
{
 _bMore = System.Convert.ToBoolean(value);return;
}
if (name == "MOREJSON")
{
 _MoreJson = System.Convert.ToString(value);return;
}

			    base[name] = value;
			}
		}
		#endregion
	}
}