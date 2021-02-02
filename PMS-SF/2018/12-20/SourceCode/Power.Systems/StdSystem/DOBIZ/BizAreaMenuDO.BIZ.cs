 
 
 using    System;
 using System.Collections.Generic;
 using System.Text; 
 using XCode.Attributes    ;

 namespace  Power.Systems.StdSystem
{
    /// <summary>
    /// 菜单
    /// </summary>
    public class BizAreaMenuDO : BizAreaMenuDO<BizAreaMenuDO>
    {

    }

	/// <summary>
    /// 菜单
    /// </summary>
	  [BindEntity(KeyWord="BizAreaMenu",EntityType = typeof(Power.Systems.StdSystem.BizAreaMenuDO),Description = "菜单"  )] 

	 [BindTable( "PB_BizAreaObject", Alias = "a",IsAttach=false,Description ="")]

	  [BindIndex(Name = "pk_PB_BizAreaObject", KeyType = Power.DataAccessLayer.KeyType.MainKey, Columns = "Id", TableName = "PB_BizAreaObject",Description="")]
 [BindIndex(Name = "pt_PB_BizAreaObject", KeyType = Power.DataAccessLayer.KeyType.ParentKey, Columns = "ParentId,Id", TableName = "PB_BizAreaObject",Description="")]

    public   class BizAreaMenuDO<TEntity> : XCode.Entity<TEntity>, XCode.IEntity where TEntity : Power.Systems.StdSystem.BizAreaMenuDO<TEntity>, new()
    { 
	    #region 属性

	    
 private System.Guid _Id;
 /// <summary>
 /// 关键字
 /// </summary>
 [BindColumn(1,"a", "Id", "关键字","", "NCHAR", 16,0,false, IsPrimaryKey =true ,IsIdentity =true,IsNullable =false,  Length =16 )]
 public virtual System.Guid Id  { get { return _Id; } set { _Id = value; } }

 private System.Guid _ParentId;
 /// <summary>
 /// 父节点
 /// </summary>
 [BindColumn(2,"a", "ParentId", "父节点","", "NCHAR", 16,0,false, IsPrimaryKey =false ,IsIdentity =false,IsNullable =true,  Length =16 )]
 public  System.Guid ParentId  { get { return _ParentId; } set { _ParentId = value; } }

 private System.Guid _BizAreaId;
 /// <summary>
 /// 所属业务域
 /// </summary>
 [BindColumn(3,"a", "BizAreaId", "所属业务域","", "NCHAR", 16,0,false, IsPrimaryKey =false ,IsIdentity =false,IsNullable =true,  Length =16 )]
 public  System.Guid BizAreaId  { get { return _BizAreaId; } set { _BizAreaId = value; } }

 private System.SByte _ObjectType;
 /// <summary>
 /// 对象类型，0 管理员，1 菜单，2业务对象
 /// </summary>
 [BindColumn(4,"a", "ObjectType", "对象类型，0 管理员，1 菜单，2业务对象","", "NCHAR", 3,0,false, IsPrimaryKey =false ,IsIdentity =false,IsNullable =false,  Length =3 )]
 public  System.SByte ObjectType  { get { return _ObjectType; } set { _ObjectType = value; } }

 private System.Guid _ObjectId;
 /// <summary>
 /// 对象Id
 /// </summary>
 [BindColumn(5,"a", "ObjectId", "对象Id","", "NCHAR", 16,0,false, IsPrimaryKey =false ,IsIdentity =false,IsNullable =true,  Length =16 )]
 public  System.Guid ObjectId  { get { return _ObjectId; } set { _ObjectId = value; } }

 private System.String _ObjectCode;
 /// <summary>
 /// 对象编号
 /// </summary>
 [BindColumn(6,"a", "ObjectCode", "对象编号","", "NCHAR", 50,0,false, IsPrimaryKey =false ,IsIdentity =false,IsNullable =true,  Length =50 )]
 public  System.String ObjectCode  { get { return _ObjectCode; } set { _ObjectCode = value; } }

 private System.String _ObjectName;
 /// <summary>
 /// 对象名称
 /// </summary>
 [BindColumn(7,"a", "ObjectName", "对象名称","", "NCHAR", 100,0,false, IsPrimaryKey =false ,IsIdentity =false,IsNullable =true,  Length =100 )]
 public  System.String ObjectName  { get { return _ObjectName; } set { _ObjectName = value; } }

 private System.DateTime _RegDate;
 /// <summary>
 /// 录入日期
 /// </summary>
 [BindColumn(8,"a", "RegDate", "录入日期","", "NCHAR", 3,0,false, IsPrimaryKey =false ,IsIdentity =false,IsNullable =true,  Length =3 )]
 public  System.DateTime RegDate  { get { return _RegDate; } set { _RegDate = value; } }

 private System.String _Memo;
 /// <summary>
 /// 备注
 /// </summary>
 [BindColumn(9,"a", "Memo", "备注","", "NCHAR", 1000,0,false, IsPrimaryKey =false ,IsIdentity =false,IsNullable =true,  Length =1000 )]
 public  System.String Memo  { get { return _Memo; } set { _Memo = value; } }

      
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
if (name == "BIZAREAID")
{
return _BizAreaId;
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
if (name == "REGDATE")
{
return _RegDate;
}
if (name == "MEMO")
{
return _Memo;
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
if (name == "BIZAREAID")
{
 _BizAreaId = XCode.Common.Helper.ConvertToGuid(value);return;
}
if (name == "OBJECTTYPE")
{
 _ObjectType = System.Convert.ToSByte(value);return;
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
if (name == "REGDATE")
{
 if (value == null || value.ToString().IsNullOrEmpty() == true) value = DateTime.MinValue;
 _RegDate = System.Convert.ToDateTime(value);return;
}
if (name == "MEMO")
{
 _Memo = System.Convert.ToString(value);return;
}

			    base[name] = value;
			}
		}
		#endregion
	}
}