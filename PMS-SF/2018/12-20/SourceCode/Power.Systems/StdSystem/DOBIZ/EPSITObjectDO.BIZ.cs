 
 
 using    System;
 using System.Collections.Generic;
 using System.Text; 
 using XCode.Attributes    ;

 namespace  Power.Systems.StdSystem
{
    /// <summary>
    /// EPS IT管理员 对象
    /// </summary>
    public class EPSITObjectDO : EPSITObjectDO<EPSITObjectDO>
    {

    }

	/// <summary>
    /// EPS IT管理员 对象
    /// </summary>
	  [BindEntity(KeyWord="EPSITObject",EntityType = typeof(Power.Systems.StdSystem.EPSITObjectDO),Description = "EPS IT管理员 对象"  )] 

	 [BindTable( "PB_EPSITObject", Alias = "a",IsAttach=false,Description ="")]

	  [BindIndex(Name = "pk_PB_EPSITObject", KeyType = Power.DataAccessLayer.KeyType.MainKey, Columns = "Id", TableName = "PB_EPSITObject",Description="")]
 [BindIndex(Name = "pt_PB_EPSITObject", KeyType = Power.DataAccessLayer.KeyType.ParentKey, Columns = "ParentId,Id", TableName = "PB_EPSITObject",Description="")]

    public   class EPSITObjectDO<TEntity> : XCode.Entity<TEntity>, XCode.IEntity where TEntity : Power.Systems.StdSystem.EPSITObjectDO<TEntity>, new()
    { 
	    #region 属性

	    
 private System.Guid _Id;
 /// <summary>
 /// 主键
 /// </summary>
 [BindColumn(1,"a", "Id", "主键","", "NCHAR", 16,0,false, IsPrimaryKey =true ,IsIdentity =true,IsNullable =false,  Length =16 )]
 public virtual System.Guid Id  { get { return _Id; } set { _Id = value; } }

 private System.Guid _ParentId;
 /// <summary>
 /// 父键
 /// </summary>
 [BindColumn(2,"a", "ParentId", "父键","", "NCHAR", 16,0,false, IsPrimaryKey =false ,IsIdentity =false,IsNullable =true,  Length =16 )]
 public  System.Guid ParentId  { get { return _ParentId; } set { _ParentId = value; } }

 private System.Guid _ITAdminId;
 /// <summary>
 /// IT管理员Id
 /// </summary>
 [BindColumn(3,"a", "ITAdminId", "IT管理员Id","", "NCHAR", 16,0,false, IsPrimaryKey =false ,IsIdentity =false,IsNullable =false,  Length =16 )]
 public  System.Guid ITAdminId  { get { return _ITAdminId; } set { _ITAdminId = value; } }

 private System.Int32 _Sequ;
 /// <summary>
 /// 序号
 /// </summary>
 [BindColumn(4,"a", "Sequ", "序号","", "NCHAR", 10,0,false, IsPrimaryKey =false ,IsIdentity =false,IsNullable =false,  Length =10 )]
 public  System.Int32 Sequ  { get { return _Sequ; } set { _Sequ = value; } }

 private System.String _ObjectType;
 /// <summary>
 /// MENU/RIGHTMENU/RIGHTBO
 /// </summary>
 [BindColumn(6,"a", "ObjectType", "MENU/RIGHTMENU/RIGHTBO","", "NCHAR", 10,0,false, IsPrimaryKey =false ,IsIdentity =false,IsNullable =false,  Length =10 )]
 public  System.String ObjectType  { get { return _ObjectType; } set { _ObjectType = value; } }

 private System.Guid _ObjectId;
 /// <summary>
 /// 对象id
 /// </summary>
 [BindColumn(7,"a", "ObjectId", "对象id","", "NCHAR", 16,0,false, IsPrimaryKey =false ,IsIdentity =false,IsNullable =true,  Length =16 )]
 public  System.Guid ObjectId  { get { return _ObjectId; } set { _ObjectId = value; } }

 private System.String _ObjectCode;
 /// <summary>
 /// 对象编号
 /// </summary>
 [BindColumn(8,"a", "ObjectCode", "对象编号","", "NCHAR", 100,0,false, IsPrimaryKey =false ,IsIdentity =false,IsNullable =true,  Length =100 )]
 public  System.String ObjectCode  { get { return _ObjectCode; } set { _ObjectCode = value; } }

 private System.String _ObjectName;
 /// <summary>
 /// 对象名称
 /// </summary>
 [BindColumn(9,"a", "ObjectName", "对象名称","", "NCHAR", 255,0,false, IsPrimaryKey =false ,IsIdentity =false,IsNullable =true,  Length =255 )]
 public  System.String ObjectName  { get { return _ObjectName; } set { _ObjectName = value; } }

      
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
if (name == "ITADMINID")
{
return _ITAdminId;
}
if (name == "SEQU")
{
return _Sequ;
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
if (name == "ITADMINID")
{
 _ITAdminId = XCode.Common.Helper.ConvertToGuid(value);return;
}
if (name == "SEQU")
{
 _Sequ = System.Convert.ToInt32(value);return;
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

			    base[name] = value;
			}
		}
		#endregion
	}
}