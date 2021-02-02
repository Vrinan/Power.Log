 
 
 using    System;
 using System.Collections.Generic;
 using System.Text; 
 using XCode.Attributes    ;

 namespace  Power.Systems.Systems
{
    /// <summary>
    /// 个人设置(PB_HumanObject)
    /// </summary>
    public class HumanObjectDO : HumanObjectDO<HumanObjectDO>
    {

    }

	/// <summary>
    /// 个人设置(PB_HumanObject)
    /// </summary>
	  [BindEntity(KeyWord="HumanObject",EntityType = typeof(Power.Systems.Systems.HumanObjectDO),Description = "个人设置(PB_HumanObject)"  )] 

	 [BindTable( "PB_HumanObject", Alias = "a",IsAttach=false,Description ="个人设置")]

	  [BindIndex(Name = "pk_PB_HumanObject", KeyType = Power.DataAccessLayer.KeyType.MainKey, Columns = "Id", TableName = "PB_HumanObject",Description="个人设置")]
 [BindIndex(Name = "pt_PB_HumanObject", KeyType = Power.DataAccessLayer.KeyType.ParentKey, Columns = "ParentId,Id", TableName = "PB_HumanObject",Description="个人设置")]

    public   class HumanObjectDO<TEntity> : XCode.Entity<TEntity>, XCode.IEntity where TEntity : Power.Systems.Systems.HumanObjectDO<TEntity>, new()
    { 
	    #region 属性

	    
 private System.Guid _Id;
 /// <summary>
 /// 
 /// </summary>
 [BindColumn(1,"a", "Id", "","", "NCHAR", 16,0,false, IsPrimaryKey =true ,IsIdentity =true,IsNullable =false,  Length =16 )]
 public virtual System.Guid Id  { get { return _Id; } set { _Id = value; } }

 private System.Guid _ParentId;
 /// <summary>
 /// 
 /// </summary>
 [BindColumn(2,"a", "ParentId", "","", "NCHAR", 16,0,false, IsPrimaryKey =false ,IsIdentity =false,IsNullable =true,  Length =16 )]
 public  System.Guid ParentId  { get { return _ParentId; } set { _ParentId = value; } }

 private System.Guid _HumanId;
 /// <summary>
 /// 
 /// </summary>
 [BindColumn(3,"a", "HumanId", "","", "NCHAR", 16,0,false, IsPrimaryKey =false ,IsIdentity =false,IsNullable =true,  Length =16 )]
 public  System.Guid HumanId  { get { return _HumanId; } set { _HumanId = value; } }

 private System.Guid _BizAreaId;
 /// <summary>
 /// 
 /// </summary>
 [BindColumn(4,"a", "BizAreaId", "","", "NCHAR", 16,0,false, IsPrimaryKey =false ,IsIdentity =false,IsNullable =true,  Length =16 )]
 public  System.Guid BizAreaId  { get { return _BizAreaId; } set { _BizAreaId = value; } }

 private System.Int32 _Sequ;
 /// <summary>
 /// 
 /// </summary>
 [BindColumn(5,"a", "Sequ", "","", "NCHAR", 10,0,false, IsPrimaryKey =false ,IsIdentity =false,IsNullable =true,  Length =10 )]
 public  System.Int32 Sequ  { get { return _Sequ; } set { _Sequ = value; } }

 private System.String _GroupCode;
 /// <summary>
 /// 分类：HUMHINT/HUMMENU/MENUWIDGET
 /// </summary>
 [BindColumn(6,"a", "GroupCode", "分类：HUMHINT/HUMMENU/MENUWIDGET","", "NCHAR", 10,0,false, IsPrimaryKey =false ,IsIdentity =false,IsNullable =true,  Length =10 )]
 public  System.String GroupCode  { get { return _GroupCode; } set { _GroupCode = value; } }

 private System.String _ObjectType;
 /// <summary>
 /// 对象类型：MAINMENU/WIDGET/URL
 /// </summary>
 [BindColumn(7,"a", "ObjectType", "对象类型：MAINMENU/WIDGET/URL","", "NCHAR", 10,0,false, IsPrimaryKey =false ,IsIdentity =false,IsNullable =true,  Length =10 )]
 public  System.String ObjectType  { get { return _ObjectType; } set { _ObjectType = value; } }

 private System.Guid _ObjectId;
 /// <summary>
 /// 对象Id
 /// </summary>
 [BindColumn(8,"a", "ObjectId", "对象Id","", "NCHAR", 16,0,false, IsPrimaryKey =false ,IsIdentity =false,IsNullable =true,  Length =16 )]
 public  System.Guid ObjectId  { get { return _ObjectId; } set { _ObjectId = value; } }

 private System.String _ObjectCode;
 /// <summary>
 /// link时写url
 /// </summary>
 [BindColumn(9,"a", "ObjectCode", "link时写url","", "NCHAR", 200,0,false, IsPrimaryKey =false ,IsIdentity =false,IsNullable =true,  Length =200 )]
 public  System.String ObjectCode  { get { return _ObjectCode; } set { _ObjectCode = value; } }

 private System.String _ObjectName;
 /// <summary>
 /// 对象名称
 /// </summary>
 [BindColumn(10,"a", "ObjectName", "对象名称","", "NCHAR", 100,0,false, IsPrimaryKey =false ,IsIdentity =false,IsNullable =true,  Length =100 )]
 public  System.String ObjectName  { get { return _ObjectName; } set { _ObjectName = value; } }

 private System.Guid _WidgetMenuId;
 /// <summary>
 /// widget对应的菜单id
 /// </summary>
 [BindColumn(11,"a", "WidgetMenuId", "widget对应的菜单id","", "NCHAR", 16,0,false, IsPrimaryKey =false ,IsIdentity =false,IsNullable =true,  Length =16 )]
 public  System.Guid WidgetMenuId  { get { return _WidgetMenuId; } set { _WidgetMenuId = value; } }

 private System.String _IconClass;
 /// <summary>
 /// 
 /// </summary>
 [BindColumn(12,"a", "IconClass", "","", "NCHAR", 50,0,false, IsPrimaryKey =false ,IsIdentity =false,IsNullable =true,  Length =50 )]
 public  System.String IconClass  { get { return _IconClass; } set { _IconClass = value; } }

 private System.DateTime _UpdDate;
 /// <summary>
 /// 
 /// </summary>
 [BindColumn(13,"a", "UpdDate", "","", "NCHAR", 0,0,false, IsPrimaryKey =false ,IsIdentity =false,IsNullable =true,  Length =0 )]
 public  System.DateTime UpdDate  { get { return _UpdDate; } set { _UpdDate = value; } }

      
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
if (name == "PARENTID")
{
return _ParentId;
}
if (name == "HUMANID")
{
return _HumanId;
}
if (name == "BIZAREAID")
{
return _BizAreaId;
}
if (name == "SEQU")
{
return _Sequ;
}
if (name == "GROUPCODE")
{
return _GroupCode;
}
if (name == "OBJECTTYPE")
{
return _ObjectType;
}
if (name == "OBJECTID")
{
return _ObjectId;
}
if (name == "OBJECTCODE")
{
return _ObjectCode;
}
if (name == "OBJECTNAME")
{
return _ObjectName;
}
if (name == "WIDGETMENUID")
{
return _WidgetMenuId;
}
if (name == "ICONCLASS")
{
return _IconClass;
}
if (name == "UPDDATE")
{
return _UpdDate;
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
if (name == "PARENTID")
{
 _ParentId = XCode.Common.Helper.ConvertToGuid(value);return;
}
if (name == "HUMANID")
{
 _HumanId = XCode.Common.Helper.ConvertToGuid(value);return;
}
if (name == "BIZAREAID")
{
 _BizAreaId = XCode.Common.Helper.ConvertToGuid(value);return;
}
if (name == "SEQU")
{
 _Sequ = System.Convert.ToInt32(value);return;
}
if (name == "GROUPCODE")
{
 _GroupCode = System.Convert.ToString(value);return;
}
if (name == "OBJECTTYPE")
{
 _ObjectType = System.Convert.ToString(value);return;
}
if (name == "OBJECTID")
{
 _ObjectId = XCode.Common.Helper.ConvertToGuid(value);return;
}
if (name == "OBJECTCODE")
{
 _ObjectCode = System.Convert.ToString(value);return;
}
if (name == "OBJECTNAME")
{
 _ObjectName = System.Convert.ToString(value);return;
}
if (name == "WIDGETMENUID")
{
 _WidgetMenuId = XCode.Common.Helper.ConvertToGuid(value);return;
}
if (name == "ICONCLASS")
{
 _IconClass = System.Convert.ToString(value);return;
}
if (name == "UPDDATE")
{
 if (value == null || value.ToString().IsNullOrEmpty() == true) value = DateTime.MinValue;
 _UpdDate = System.Convert.ToDateTime(value);return;
}

			    base[name] = value;
			}
		}
		#endregion
	}
}