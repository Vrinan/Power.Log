 
 
 using    System;
 using System.Collections.Generic;
 using System.Text; 
 using XCode.Attributes    ;

 namespace  Power.Systems.Menu
{
    /// <summary>
    /// 功能菜单(PB_Menu)
    /// </summary>
    public class MenuDO : MenuDO<MenuDO>
    {

    }

	/// <summary>
    /// 功能菜单(PB_Menu)
    /// </summary>
	  [BindEntity(KeyWord="Menu",EntityType = typeof(Power.Systems.Menu.MenuDO),Description = "功能菜单(PB_Menu)"  )] 

	 [BindTable( "PB_Menu", Alias = "a",IsAttach=false,Description ="功能菜单")]

	  [BindIndex(Name = "pk_PB_Menu", KeyType = Power.DataAccessLayer.KeyType.MainKey, Columns = "Id", TableName = "PB_Menu",Description="功能菜单")]
 [BindIndex(Name = "pt_PB_Menu", KeyType = Power.DataAccessLayer.KeyType.ParentKey, Columns = "ParentId,Id", TableName = "PB_Menu",Description="功能菜单")]

    public   class MenuDO<TEntity> : XCode.Entity<TEntity>, XCode.IEntity where TEntity : Power.Systems.Menu.MenuDO<TEntity>, new()
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

 private System.String _Code;
 /// <summary>
 /// 编号
 /// </summary>
 [BindColumn(3,"a", "Code", "编号","", "NCHAR", 30,0,false, IsPrimaryKey =false ,IsIdentity =false,IsNullable =true,  Length =30 )]
 public  System.String Code  { get { return _Code; } set { _Code = value; } }

 private System.String _IconClass16;
 /// <summary>
 /// 
 /// </summary>
 [BindColumn(4,"a", "IconClass16", "","", "NCHAR", 50,0,false, IsPrimaryKey =false ,IsIdentity =false,IsNullable =true,  Length =50 )]
 public  System.String IconClass16  { get { return _IconClass16; } set { _IconClass16 = value; } }

 private System.String _IconClass32;
 /// <summary>
 /// 
 /// </summary>
 [BindColumn(5,"a", "IconClass32", "","", "NCHAR", 50,0,false, IsPrimaryKey =false ,IsIdentity =false,IsNullable =true,  Length =50 )]
 public  System.String IconClass32  { get { return _IconClass32; } set { _IconClass32 = value; } }

 private System.String _IconClass64;
 /// <summary>
 /// 
 /// </summary>
 [BindColumn(6,"a", "IconClass64", "","", "NCHAR", 50,0,false, IsPrimaryKey =false ,IsIdentity =false,IsNullable =true,  Length =50 )]
 public  System.String IconClass64  { get { return _IconClass64; } set { _IconClass64 = value; } }

 private System.String _Name;
 /// <summary>
 /// 名称
 /// </summary>
 [BindColumn(7,"a", "Name", "名称","", "NCHAR", 100,0,false, IsPrimaryKey =false ,IsIdentity =false,IsNullable =true,  Length =100 )]
 public  System.String Name  { get { return _Name; } set { _Name = value; } }

 private System.String _LongPath;
 /// <summary>
 /// 长路径
 /// </summary>
 [BindColumn(8,"a", "LongPath", "长路径","", "NCHAR", -1,0,false, IsPrimaryKey =false ,IsIdentity =false,IsNullable =true,  Length =-1 )]
 public  System.String LongPath  { get { return _LongPath; } set { _LongPath = value; } }

 private System.String _Layer;
 /// <summary>
 /// 布局
 /// </summary>
 [BindColumn(9,"a", "Layer", "布局","", "NCHAR", -1,0,false, IsPrimaryKey =false ,IsIdentity =false,IsNullable =true,  Length =-1 )]
 public  System.String Layer  { get { return _Layer; } set { _Layer = value; } }

      
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
if (name == "CODE")
{
return _Code;
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
if (name == "NAME")
{
return _Name;
}
if (name == "LONGPATH")
{
return _LongPath;
}
if (name == "LAYER")
{
return _Layer;
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
if (name == "CODE")
{
 _Code = System.Convert.ToString(value);return;
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
if (name == "NAME")
{
 _Name = System.Convert.ToString(value);return;
}
if (name == "LONGPATH")
{
 _LongPath = System.Convert.ToString(value);return;
}
if (name == "LAYER")
{
 _Layer = System.Convert.ToString(value);return;
}

			    base[name] = value;
			}
		}
		#endregion
	}
}