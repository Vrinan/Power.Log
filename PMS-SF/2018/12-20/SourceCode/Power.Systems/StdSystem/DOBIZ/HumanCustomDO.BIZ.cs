 
 
 using    System;
 using System.Collections.Generic;
 using System.Text; 
 using XCode.Attributes    ;

 namespace  Power.Systems.StdSystem
{
    /// <summary>
    /// 人员自定义配置
    /// </summary>
    public class HumanCustomDO : HumanCustomDO<HumanCustomDO>
    {

    }

	/// <summary>
    /// 人员自定义配置
    /// </summary>
	  [BindEntity(KeyWord="HumanCustom",EntityType = typeof(Power.Systems.StdSystem.HumanCustomDO),Description = "人员自定义配置"  )] 

	 [BindTable( "PB_HumanCustom", Alias = "a",IsAttach=false,Description ="")]

	  [BindIndex(Name = "pk_PB_HumanCustom", KeyType = Power.DataAccessLayer.KeyType.MainKey, Columns = "Id", TableName = "PB_HumanCustom",Description="")]

    public   class HumanCustomDO<TEntity> : XCode.Entity<TEntity>, XCode.IEntity where TEntity : Power.Systems.StdSystem.HumanCustomDO<TEntity>, new()
    { 
	    #region 属性

	    
 private System.Int32 _Sequ;
 /// <summary>
 /// 序号
 /// </summary>
 [BindColumn(1,"a", "Sequ", "序号","", "NCHAR", 6,0,false, IsPrimaryKey =false ,IsIdentity =false,IsNullable =false,  Length =6 )]
 public  System.Int32 Sequ  { get { return _Sequ; } set { _Sequ = value; } }

 private System.Int32 _IsDefault;
 /// <summary>
 /// 1缺省
 /// </summary>
 [BindColumn(1,"a", "IsDefault", "1缺省","", "NCHAR", 6,0,false, IsPrimaryKey =false ,IsIdentity =false,IsNullable =false,  Length =6 )]
 public  System.Int32 IsDefault  { get { return _IsDefault; } set { _IsDefault = value; } }

 private System.Guid _Id;
 /// <summary>
 /// 
 /// </summary>
 [BindColumn(1,"a", "Id", "","", "NCHAR", 16,0,false, IsPrimaryKey =true ,IsIdentity =true,IsNullable =false,  Length =16 )]
 public virtual System.Guid Id  { get { return _Id; } set { _Id = value; } }

 private System.String _ObjectCode;
 /// <summary>
 /// 对象编号
 /// </summary>
 [BindColumn(1,"a", "ObjectCode", "对象编号","", "NCHAR", 100,0,false, IsPrimaryKey =false ,IsIdentity =false,IsNullable =false,  Length =100 )]
 public  System.String ObjectCode  { get { return _ObjectCode; } set { _ObjectCode = value; } }

 private System.String _Name;
 /// <summary>
 /// 名称
 /// </summary>
 [BindColumn(1,"a", "Name", "名称","", "NCHAR", 100,0,false, IsPrimaryKey =false ,IsIdentity =false,IsNullable =false,  Length =100 )]
 public  System.String Name  { get { return _Name; } set { _Name = value; } }

 private System.Guid _HumanId;
 /// <summary>
 /// 人员Id
 /// </summary>
 [BindColumn(2,"a", "HumanId", "人员Id","", "NCHAR", 16,0,false, IsPrimaryKey =false ,IsIdentity =false,IsNullable =false,  Length =16 )]
 public  System.Guid HumanId  { get { return _HumanId; } set { _HumanId = value; } }

 private System.String _CustomType;
 /// <summary>
 /// 自定义类型,详细参考EHumanCustomType
 /// </summary>
 [BindColumn(3,"a", "CustomType", "自定义类型,详细参考EHumanCustomType","", "NCHAR", 50,0,false, IsPrimaryKey =false ,IsIdentity =false,IsNullable =false,  Length =50 )]
 public  System.String CustomType  { get { return _CustomType; } set { _CustomType = value; } }

 private System.String _ObjectId;
 /// <summary>
 /// 对象Id
 /// </summary>
 [BindColumn(4,"a", "ObjectId", "对象Id","", "NCHAR", 50,0,false, IsPrimaryKey =false ,IsIdentity =false,IsNullable =true,  Length =50 )]
 public  System.String ObjectId  { get { return _ObjectId; } set { _ObjectId = value; } }

 private System.String _ExtJson;
 /// <summary>
 /// 配置文件
 /// </summary>
 [BindColumn(5,"a", "ExtJson", "配置文件","", "NCHAR", -1,0,false, IsPrimaryKey =false ,IsIdentity =false,IsNullable =true,  Length =-1 )]
 public  System.String ExtJson  { get { return _ExtJson; } set { _ExtJson = value; } }

      
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
			    if (name == "SEQU")
{
return _Sequ;
}
if (name == "ISDEFAULT")
{
return _IsDefault;
}
if (name == "ID")
{
return _Id;
}
if (name == "OBJECTCODE")
{
return _ObjectCode;
}
if (name == "NAME")
{
return _Name;
}
if (name == "HUMANID")
{
return _HumanId;
}
if (name == "CUSTOMTYPE")
{
return _CustomType;
}
if (name == "OBJECTID")
{
return _ObjectId;
}
if (name == "EXTJSON")
{
return _ExtJson;
}

			    return base[name];
			}
			set 
			{
			   name = name.ToUpper();
			       if (name == "SEQU")
{
 _Sequ = System.Convert.ToInt32(value);return;
}
if (name == "ISDEFAULT")
{
 _IsDefault = System.Convert.ToInt32(value);return;
}
if (name == "ID")
{
 _Id = XCode.Common.Helper.ConvertToGuid(value);return;
}
if (name == "OBJECTCODE")
{
 _ObjectCode = System.Convert.ToString(value);return;
}
if (name == "NAME")
{
 _Name = System.Convert.ToString(value);return;
}
if (name == "HUMANID")
{
 _HumanId = XCode.Common.Helper.ConvertToGuid(value);return;
}
if (name == "CUSTOMTYPE")
{
 _CustomType = System.Convert.ToString(value);return;
}
if (name == "OBJECTID")
{
 _ObjectId = System.Convert.ToString(value);return;
}
if (name == "EXTJSON")
{
 _ExtJson = System.Convert.ToString(value);return;
}

			    base[name] = value;
			}
		}
		#endregion
	}
}