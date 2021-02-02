 
 
 using    System;
 using System.Collections.Generic;
 using System.Text; 
 using XCode.Attributes    ;

 namespace  Power.Systems.Systems
{
    /// <summary>
    /// Widget(PB_Widget)
    /// </summary>
    public class WidgetDO : WidgetDO<WidgetDO>
    {

    }

	/// <summary>
    /// Widget(PB_Widget)
    /// </summary>
	  [BindEntity(KeyWord="Widget",EntityType = typeof(Power.Systems.Systems.WidgetDO),Description = "Widget(PB_Widget)"  )] 

	 [BindTable( "PB_Widget", Alias = "a",IsAttach=false,Description ="Widget")]

	  [BindIndex(Name = "pk_PB_Widget", KeyType = Power.DataAccessLayer.KeyType.MainKey, Columns = "Id", TableName = "PB_Widget",Description="Widget")]
 [BindIndex(Name = "pt_PB_Widget", KeyType = Power.DataAccessLayer.KeyType.ParentKey, Columns = "ParentId,Id", TableName = "PB_Widget",Description="Widget")]

    public   class WidgetDO<TEntity> : XCode.Entity<TEntity>, XCode.IEntity where TEntity : Power.Systems.Systems.WidgetDO<TEntity>, new()
    { 
	    #region 属性

	    
 private System.Guid _Id;
 /// <summary>
 /// 
 /// </summary>
 [BindColumn(1,"a", "Id", "","", "NCHAR", 16,0,false, IsPrimaryKey =true ,IsIdentity =true,IsNullable =false,  Length =16 )]
 public virtual System.Guid Id  { get { return _Id; } set { _Id = value; } }

 private System.String _HtmlPath;
 /// <summary>
 /// 
 /// </summary>
 [BindColumn(1,"a", "HtmlPath", "","", "NCHAR", 200,0,false, IsPrimaryKey =false ,IsIdentity =false,IsNullable =false,  Length =200 )]
 public  System.String HtmlPath  { get { return _HtmlPath; } set { _HtmlPath = value; } }

 private System.Guid _ParentId;
 /// <summary>
 /// 
 /// </summary>
 [BindColumn(2,"a", "ParentId", "","", "NCHAR", 16,0,false, IsPrimaryKey =false ,IsIdentity =false,IsNullable =true,  Length =16 )]
 public  System.Guid ParentId  { get { return _ParentId; } set { _ParentId = value; } }

 private System.String _Code;
 /// <summary>
 /// 
 /// </summary>
 [BindColumn(3,"a", "Code", "","", "NCHAR", 30,0,false, IsPrimaryKey =false ,IsIdentity =false,IsNullable =true,  Length =30 )]
 public  System.String Code  { get { return _Code; } set { _Code = value; } }

 private System.String _Name;
 /// <summary>
 /// 标题
 /// </summary>
 [BindColumn(4,"a", "Name", "标题","", "NCHAR", 200,0,false, IsPrimaryKey =false ,IsIdentity =false,IsNullable =true,  Length =200 )]
 public  System.String Name  { get { return _Name; } set { _Name = value; } }

 private System.Boolean _bPublish;
 /// <summary>
 /// 是否发布
 /// </summary>
 [BindColumn(5,"a", "bPublish", "是否发布","", "NCHAR", 1,0,false, IsPrimaryKey =false ,IsIdentity =false,IsNullable =true,  Length =1 )]
 public  System.Boolean bPublish  { get { return _bPublish; } set { _bPublish = value; } }

 private System.Boolean _bSysDefault;
 /// <summary>
 /// 系统默认
 /// </summary>
 [BindColumn(6,"a", "bSysDefault", "系统默认","", "NCHAR", 1,0,false, IsPrimaryKey =false ,IsIdentity =false,IsNullable =true,  Length =1 )]
 public  System.Boolean bSysDefault  { get { return _bSysDefault; } set { _bSysDefault = value; } }

 private System.SByte _WidgetType;
 /// <summary>
 /// widget类型；1业务表单,2树,3图表,4报表,5自定模板....
 /// </summary>
 [BindColumn(7,"a", "WidgetType", "widget类型；1业务表单,2树,3图表,4报表,5自定模板....","", "NCHAR", 3,0,false, IsPrimaryKey =false ,IsIdentity =false,IsNullable =true,  Length =3 )]
 public  System.SByte WidgetType  { get { return _WidgetType; } set { _WidgetType = value; } }

 private System.String _KeyWord;
 /// <summary>
 /// 
 /// </summary>
 [BindColumn(8,"a", "KeyWord", "","", "NCHAR", 100,0,false, IsPrimaryKey =false ,IsIdentity =false,IsNullable =true,  Length =100 )]
 public  System.String KeyWord  { get { return _KeyWord; } set { _KeyWord = value; } }

 private System.String _IconClass;
 /// <summary>
 /// 图标class名
 /// </summary>
 [BindColumn(9,"a", "IconClass", "图标class名","", "NCHAR", 100,0,false, IsPrimaryKey =false ,IsIdentity =false,IsNullable =true,  Length =100 )]
 public  System.String IconClass  { get { return _IconClass; } set { _IconClass = value; } }

 private System.String _CssStyle;
 /// <summary>
 /// 
 /// </summary>
 [BindColumn(10,"a", "CssStyle", "","", "NCHAR", 100,0,false, IsPrimaryKey =false ,IsIdentity =false,IsNullable =true,  Length =100 )]
 public  System.String CssStyle  { get { return _CssStyle; } set { _CssStyle = value; } }

 private System.String _ExtJson;
 /// <summary>
 /// widget扩展属性描述文件
 /// </summary>
 [BindColumn(11,"a", "ExtJson", "widget扩展属性描述文件","", "NCHAR", -1,0,false, IsPrimaryKey =false ,IsIdentity =false,IsNullable =true,  Length =-1 )]
 public  System.String ExtJson  { get { return _ExtJson; } set { _ExtJson = value; } }

 private System.Int16 _bWebForm;
 /// <summary>
 /// 
 /// </summary>
 [BindColumn(13,"a", "bWebForm", "","0", "NCHAR", 5,0,false, IsPrimaryKey =false ,IsIdentity =false,IsNullable =false,  Length =5 )]
 public  System.Int16 bWebForm  { get { return _bWebForm; } set { _bWebForm = value; } }

 private System.String _MobileExtJson;
 /// <summary>
 /// 
 /// </summary>
 [BindColumn(14,"a", "MobileExtJson", "","", "NCHAR", 2000,0,false, IsPrimaryKey =false ,IsIdentity =false,IsNullable =true,  Length =2000 )]
 public  System.String MobileExtJson  { get { return _MobileExtJson; } set { _MobileExtJson = value; } }

      
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
if (name == "HTMLPATH")
{
return _HtmlPath;
}
if (name == "PARENTID")
{
return _ParentId;
}
if (name == "CODE")
{
return _Code;
}
if (name == "NAME")
{
return _Name;
}
if (name == "BPUBLISH")
{
return _bPublish;
}
if (name == "BSYSDEFAULT")
{
return _bSysDefault;
}
if (name == "WIDGETTYPE")
{
return _WidgetType;
}
if (name == "KEYWORD")
{
return _KeyWord;
}
if (name == "ICONCLASS")
{
return _IconClass;
}
if (name == "CSSSTYLE")
{
return _CssStyle;
}
if (name == "EXTJSON")
{
return _ExtJson;
}
if (name == "BWEBFORM")
{
return _bWebForm;
}
if (name == "MOBILEEXTJSON")
{
return _MobileExtJson;
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
if (name == "HTMLPATH")
{
 _HtmlPath = System.Convert.ToString(value);return;
}
if (name == "PARENTID")
{
 _ParentId = XCode.Common.Helper.ConvertToGuid(value);return;
}
if (name == "CODE")
{
 _Code = System.Convert.ToString(value);return;
}
if (name == "NAME")
{
 _Name = System.Convert.ToString(value);return;
}
if (name == "BPUBLISH")
{
 _bPublish = System.Convert.ToBoolean(value);return;
}
if (name == "BSYSDEFAULT")
{
 _bSysDefault = System.Convert.ToBoolean(value);return;
}
if (name == "WIDGETTYPE")
{
 _WidgetType = System.Convert.ToSByte(value);return;
}
if (name == "KEYWORD")
{
 _KeyWord = System.Convert.ToString(value);return;
}
if (name == "ICONCLASS")
{
 _IconClass = System.Convert.ToString(value);return;
}
if (name == "CSSSTYLE")
{
 _CssStyle = System.Convert.ToString(value);return;
}
if (name == "EXTJSON")
{
 _ExtJson = System.Convert.ToString(value);return;
}
if (name == "BWEBFORM")
{
 _bWebForm = System.Convert.ToInt16(value);return;
}
if (name == "MOBILEEXTJSON")
{
 _MobileExtJson = System.Convert.ToString(value);return;
}

			    base[name] = value;
			}
		}
		#endregion
	}
}