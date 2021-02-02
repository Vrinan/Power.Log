 
 
 using    System;
 using System.Collections.Generic;
 using System.Text; 
 using XCode.Attributes    ;

 namespace  Power.Systems.Systems
{
    /// <summary>
    /// 应用系统主菜单
    /// </summary>
    public class MainMenuDO : MainMenuDO<MainMenuDO>
    {

    }

	/// <summary>
    /// 应用系统主菜单
    /// </summary>
	  [BindEntity(KeyWord="MainMenu",EntityType = typeof(Power.Systems.Systems.MainMenuDO),Description = "应用系统主菜单"  )] 

	 [BindTable( "PB_Menu", Alias = "a",IsAttach=false,Description ="")]

	  [BindIndex(Name = "pk_PB_Menu", KeyType = Power.DataAccessLayer.KeyType.MainKey, Columns = "Id", TableName = "PB_Menu",Description="")]
 [BindIndex(Name = "ser_PB_Menu", KeyType = Power.DataAccessLayer.KeyType.OrderKey, Columns = "Sequ", TableName = "PB_Menu",Description="")]

    public   class MainMenuDO<TEntity> : XCode.Entity<TEntity>, XCode.IEntity where TEntity : Power.Systems.Systems.MainMenuDO<TEntity>, new()
    { 
	    #region 属性

	    
 private System.Guid _Id;
 /// <summary>
 /// 
 /// </summary>
 [BindColumn(1,"a", "Id", "","", "NCHAR", 16,0,false, IsPrimaryKey =true ,IsIdentity =true,IsNullable =false,  Length =16 )]
 public virtual System.Guid Id  { get { return _Id; } set { _Id = value; } }

 private System.Int32 _LinkWidget;
 /// <summary>
 /// 1表示有关联widget
 /// </summary>
 [BindColumn(1,"a", "LinkWidget", "1表示有关联widget","", "NCHAR", 6,0,false, IsPrimaryKey =false ,IsIdentity =false,IsNullable =false,  Length =6 )]
 public  System.Int32 LinkWidget  { get { return _LinkWidget; } set { _LinkWidget = value; } }

 private System.DateTime _UpdDate;
 /// <summary>
 /// 
 /// </summary>
 [BindColumn(1,"a", "UpdDate", "","", "NCHAR", 0,0,false, IsPrimaryKey =false ,IsIdentity =false,IsNullable =false,  Length =0 )]
 public  System.DateTime UpdDate  { get { return _UpdDate; } set { _UpdDate = value; } }

 private System.String _IconColor;
 /// <summary>
 /// 图标颜色
 /// </summary>
 [BindColumn(1,"a", "IconColor", "图标颜色","", "NCHAR", 30,0,false, IsPrimaryKey =false ,IsIdentity =false,IsNullable =false,  Length =30 )]
 public  System.String IconColor  { get { return _IconColor; } set { _IconColor = value; } }

 private System.Guid _ParentId;
 /// <summary>
 /// 
 /// </summary>
 [BindColumn(2,"a", "ParentId", "","", "NCHAR", 16,0,false, IsPrimaryKey =false ,IsIdentity =false,IsNullable =true,  Length =16 )]
 public  System.Guid ParentId  { get { return _ParentId; } set { _ParentId = value; } }

 private System.String _Code;
 /// <summary>
 /// 编号
 /// </summary>
 [BindColumn(3,"a", "Code", "编号","", "NCHAR", 30,0,false, IsPrimaryKey =false ,IsIdentity =false,IsNullable =true,  Length =30 )]
 public  System.String Code  { get { return _Code; } set { _Code = value; } }

 private System.String _Name;
 /// <summary>
 /// 名称
 /// </summary>
 [BindColumn(4,"a", "Name", "名称","", "NCHAR", 100,0,false, IsPrimaryKey =false ,IsIdentity =false,IsNullable =true,  Length =100 )]
 public  System.String Name  { get { return _Name; } set { _Name = value; } }

 private System.String _IconClass16;
 /// <summary>
 /// 
 /// </summary>
 [BindColumn(5,"a", "IconClass16", "","", "NCHAR", 50,0,false, IsPrimaryKey =false ,IsIdentity =false,IsNullable =true,  Length =50 )]
 public  System.String IconClass16  { get { return _IconClass16; } set { _IconClass16 = value; } }

 private System.String _IconClass32;
 /// <summary>
 /// 
 /// </summary>
 [BindColumn(6,"a", "IconClass32", "","", "NCHAR", 50,0,false, IsPrimaryKey =false ,IsIdentity =false,IsNullable =true,  Length =50 )]
 public  System.String IconClass32  { get { return _IconClass32; } set { _IconClass32 = value; } }

 private System.String _IconClass64;
 /// <summary>
 /// 
 /// </summary>
 [BindColumn(7,"a", "IconClass64", "","", "NCHAR", 50,0,false, IsPrimaryKey =false ,IsIdentity =false,IsNullable =true,  Length =50 )]
 public  System.String IconClass64  { get { return _IconClass64; } set { _IconClass64 = value; } }

 private System.String _TabFlag;
 /// <summary>
 /// Tab/Single 方式打开菜单
 /// </summary>
 [BindColumn(8,"a", "TabFlag", "Tab/Single 方式打开菜单","", "NCHAR", 10,0,false, IsPrimaryKey =false ,IsIdentity =false,IsNullable =true,  Length =10 )]
 public  System.String TabFlag  { get { return _TabFlag; } set { _TabFlag = value; } }

 private System.String _LongCode;
 /// <summary>
 /// 长路径
 /// </summary>
 [BindColumn(9,"a", "LongCode", "长路径","", "NCHAR", 500,0,false, IsPrimaryKey =false ,IsIdentity =false,IsNullable =true,  Length =500 )]
 public  System.String LongCode  { get { return _LongCode; } set { _LongCode = value; } }

 private System.String _Layer;
 /// <summary>
 /// 布局
 /// </summary>
 [BindColumn(10,"a", "Layer", "布局","", "NCHAR", -1,0,false, IsPrimaryKey =false ,IsIdentity =false,IsNullable =true,  Length =-1 )]
 public  System.String Layer  { get { return _Layer; } set { _Layer = value; } }

 private System.Int32 _Sequ;
 /// <summary>
 /// 
 /// </summary>
 [BindColumn(11,"a", "Sequ", "","", "NCHAR", 10,0,false, IsPrimaryKey =false ,IsIdentity =false,IsNullable =true,  Length =10 )]
 public  System.Int32 Sequ  { get { return _Sequ; } set { _Sequ = value; } }

      
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
if (name == "LINKWIDGET")
{
return _LinkWidget;
}
if (name == "UPDDATE")
{
return _UpdDate;
}
if (name == "ICONCOLOR")
{
return _IconColor;
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
if (name == "ICONCLASS16")
{
return _IconClass16;
}
if (name == "ICONCLASS32")
{
return _IconClass32;
}
if (name == "ICONCLASS64")
{
return _IconClass64;
}
if (name == "TABFLAG")
{
return _TabFlag;
}
if (name == "LONGCODE")
{
return _LongCode;
}
if (name == "LAYER")
{
return _Layer;
}
if (name == "SEQU")
{
return _Sequ;
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
if (name == "LINKWIDGET")
{
 _LinkWidget = System.Convert.ToInt32(value);return;
}
if (name == "UPDDATE")
{
 if (value == null || value.ToString().IsNullOrEmpty() == true) value = DateTime.MinValue;
 _UpdDate = System.Convert.ToDateTime(value);return;
}
if (name == "ICONCOLOR")
{
 _IconColor = System.Convert.ToString(value);return;
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
if (name == "ICONCLASS16")
{
 _IconClass16 = System.Convert.ToString(value);return;
}
if (name == "ICONCLASS32")
{
 _IconClass32 = System.Convert.ToString(value);return;
}
if (name == "ICONCLASS64")
{
 _IconClass64 = System.Convert.ToString(value);return;
}
if (name == "TABFLAG")
{
 _TabFlag = System.Convert.ToString(value);return;
}
if (name == "LONGCODE")
{
 _LongCode = System.Convert.ToString(value);return;
}
if (name == "LAYER")
{
 _Layer = System.Convert.ToString(value);return;
}
if (name == "SEQU")
{
 _Sequ = System.Convert.ToInt32(value);return;
}

			    base[name] = value;
			}
		}
		#endregion
	}
}