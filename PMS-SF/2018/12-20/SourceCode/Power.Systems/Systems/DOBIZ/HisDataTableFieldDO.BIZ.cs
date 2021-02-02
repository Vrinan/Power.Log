 
 
 using    System;
 using System.Collections.Generic;
 using System.Text; 
 using XCode.Attributes    ;

 namespace  Power.Systems.Systems
{
    /// <summary>
    /// 历史数据迁移表字段
    /// </summary>
    public class HisDataTableFieldDO : HisDataTableFieldDO<HisDataTableFieldDO>
    {

    }

	/// <summary>
    /// 历史数据迁移表字段
    /// </summary>
	  [BindEntity(KeyWord="HisDataTableField",EntityType = typeof(Power.Systems.Systems.HisDataTableFieldDO),Description = "历史数据迁移表字段"  )] 

	 [BindTable( "PB_HisDataTableField", Alias = "a",IsAttach=false,Description ="")]

	  [BindIndex(Name = "pk_PB_HisDataTableField", KeyType = Power.DataAccessLayer.KeyType.MainKey, Columns = "Id", TableName = "PB_HisDataTableField",Description="")]

    public   class HisDataTableFieldDO<TEntity> : XCode.Entity<TEntity>, XCode.IEntity where TEntity : Power.Systems.Systems.HisDataTableFieldDO<TEntity>, new()
    { 
	    #region 属性

	    
 private System.String _ValueMap;
 /// <summary>
 /// 对应关系
 /// </summary>
 [BindColumn(1,"a", "ValueMap", "对应关系","", "NCHAR", 2000,0,false, IsPrimaryKey =false ,IsIdentity =false,IsNullable =true,  Length =2000 )]
 public  System.String ValueMap  { get { return _ValueMap; } set { _ValueMap = value; } }

 private System.Guid _Id;
 /// <summary>
 /// 
 /// </summary>
 [BindColumn(1,"a", "Id", "","", "NCHAR", 16,0,false, IsPrimaryKey =true ,IsIdentity =true,IsNullable =false,  Length =16 )]
 public virtual System.Guid Id  { get { return _Id; } set { _Id = value; } }

 private System.Int32 _Sequ;
 /// <summary>
 /// 序号
 /// </summary>
 [BindColumn(2,"a", "Sequ", "序号","", "NCHAR", 10,0,false, IsPrimaryKey =false ,IsIdentity =false,IsNullable =true,  Length =10 )]
 public  System.Int32 Sequ  { get { return _Sequ; } set { _Sequ = value; } }

 private System.String _TableName;
 /// <summary>
 /// 表名称
 /// </summary>
 [BindColumn(3,"a", "TableName", "表名称","", "NCHAR", 100,0,false, IsPrimaryKey =false ,IsIdentity =false,IsNullable =false,  Length =100 )]
 public  System.String TableName  { get { return _TableName; } set { _TableName = value; } }

 private System.String _FieldName;
 /// <summary>
 /// 字段名称
 /// </summary>
 [BindColumn(4,"a", "FieldName", "字段名称","", "NCHAR", 100,0,false, IsPrimaryKey =false ,IsIdentity =false,IsNullable =false,  Length =100 )]
 public  System.String FieldName  { get { return _FieldName; } set { _FieldName = value; } }

 private System.String _Title;
 /// <summary>
 /// 标题
 /// </summary>
 [BindColumn(5,"a", "Title", "标题","", "NCHAR", 100,0,false, IsPrimaryKey =false ,IsIdentity =false,IsNullable =true,  Length =100 )]
 public  System.String Title  { get { return _Title; } set { _Title = value; } }

 private System.String _FieldType;
 /// <summary>
 /// 类型
 /// </summary>
 [BindColumn(6,"a", "FieldType", "类型","", "NCHAR", 100,0,false, IsPrimaryKey =false ,IsIdentity =false,IsNullable =true,  Length =100 )]
 public  System.String FieldType  { get { return _FieldType; } set { _FieldType = value; } }

 private System.Int32 _FieldLength;
 /// <summary>
 /// 长度
 /// </summary>
 [BindColumn(7,"a", "FieldLength", "长度","", "NCHAR", 10,0,false, IsPrimaryKey =false ,IsIdentity =false,IsNullable =true,  Length =10 )]
 public  System.Int32 FieldLength  { get { return _FieldLength; } set { _FieldLength = value; } }

 private System.SByte _AllowNull;
 /// <summary>
 /// 允许空
 /// </summary>
 [BindColumn(8,"a", "AllowNull", "允许空","", "NCHAR", 3,0,false, IsPrimaryKey =false ,IsIdentity =false,IsNullable =true,  Length =3 )]
 public  System.SByte AllowNull  { get { return _AllowNull; } set { _AllowNull = value; } }

 private System.SByte _IsKeyField;
 /// <summary>
 /// 是主键
 /// </summary>
 [BindColumn(9,"a", "IsKeyField", "是主键","", "NCHAR", 3,0,false, IsPrimaryKey =false ,IsIdentity =false,IsNullable =true,  Length =3 )]
 public  System.SByte IsKeyField  { get { return _IsKeyField; } set { _IsKeyField = value; } }

 private System.String _UseType;
 /// <summary>
 /// 字段用途:Default/Longcode/ProjectCode/Sequ
 /// </summary>
 [BindColumn(10,"a", "UseType", "字段用途:Default/Longcode/ProjectCode/Sequ","", "NCHAR", 15,0,false, IsPrimaryKey =false ,IsIdentity =false,IsNullable =true,  Length =15 )]
 public  System.String UseType  { get { return _UseType; } set { _UseType = value; } }

 private System.String _GuidFieldName;
 /// <summary>
 /// 对应Guid字段名称
 /// </summary>
 [BindColumn(11,"a", "GuidFieldName", "对应Guid字段名称","", "NCHAR", 100,0,false, IsPrimaryKey =false ,IsIdentity =false,IsNullable =true,  Length =100 )]
 public  System.String GuidFieldName  { get { return _GuidFieldName; } set { _GuidFieldName = value; } }

 private System.String _NewFieldName;
 /// <summary>
 /// 新字段名
 /// </summary>
 [BindColumn(12,"a", "NewFieldName", "新字段名","", "NCHAR", 100,0,false, IsPrimaryKey =false ,IsIdentity =false,IsNullable =true,  Length =100 )]
 public  System.String NewFieldName  { get { return _NewFieldName; } set { _NewFieldName = value; } }

 private System.String _NewFieldType;
 /// <summary>
 /// 新字段类型
 /// </summary>
 [BindColumn(13,"a", "NewFieldType", "新字段类型","", "NCHAR", 100,0,false, IsPrimaryKey =false ,IsIdentity =false,IsNullable =true,  Length =100 )]
 public  System.String NewFieldType  { get { return _NewFieldType; } set { _NewFieldType = value; } }

 private System.Int32 _NewFieldLength;
 /// <summary>
 /// 新字段长度
 /// </summary>
 [BindColumn(14,"a", "NewFieldLength", "新字段长度","", "NCHAR", 10,0,false, IsPrimaryKey =false ,IsIdentity =false,IsNullable =true,  Length =10 )]
 public  System.Int32 NewFieldLength  { get { return _NewFieldLength; } set { _NewFieldLength = value; } }

 private System.String _DefaultValue;
 /// <summary>
 /// 迁移缺省值
 /// </summary>
 [BindColumn(15,"a", "DefaultValue", "迁移缺省值","", "NCHAR", 50,0,false, IsPrimaryKey =false ,IsIdentity =false,IsNullable =true,  Length =50 )]
 public  System.String DefaultValue  { get { return _DefaultValue; } set { _DefaultValue = value; } }

 private System.String _ForeignTableField;
 /// <summary>
 /// 关联的外键表字段
 /// </summary>
 [BindColumn(16,"a", "ForeignTableField", "关联的外键表字段","", "NCHAR", 200,0,false, IsPrimaryKey =false ,IsIdentity =false,IsNullable =true,  Length =200 )]
 public  System.String ForeignTableField  { get { return _ForeignTableField; } set { _ForeignTableField = value; } }

 private System.DateTime _RegDate;
 /// <summary>
 /// 录入日期
 /// </summary>
 [BindColumn(17,"a", "RegDate", "录入日期","", "NCHAR", 3,0,false, IsPrimaryKey =false ,IsIdentity =false,IsNullable =true,  Length =3 )]
 public  System.DateTime RegDate  { get { return _RegDate; } set { _RegDate = value; } }

      
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
			    if (name == "VALUEMAP")
{
return _ValueMap;
}
if (name == "ID")
{
return _Id;
}
if (name == "SEQU")
{
return _Sequ;
}
if (name == "TABLENAME")
{
return _TableName;
}
if (name == "FIELDNAME")
{
return _FieldName;
}
if (name == "TITLE")
{
return _Title;
}
if (name == "FIELDTYPE")
{
return _FieldType;
}
if (name == "FIELDLENGTH")
{
return _FieldLength;
}
if (name == "ALLOWNULL")
{
return _AllowNull;
}
if (name == "ISKEYFIELD")
{
return _IsKeyField;
}
if (name == "USETYPE")
{
return _UseType;
}
if (name == "GUIDFIELDNAME")
{
return _GuidFieldName;
}
if (name == "NEWFIELDNAME")
{
return _NewFieldName;
}
if (name == "NEWFIELDTYPE")
{
return _NewFieldType;
}
if (name == "NEWFIELDLENGTH")
{
return _NewFieldLength;
}
if (name == "DEFAULTVALUE")
{
return _DefaultValue;
}
if (name == "FOREIGNTABLEFIELD")
{
return _ForeignTableField;
}
if (name == "REGDATE")
{
return _RegDate;
}

			    return base[name];
			}
			set 
			{
			   name = name.ToUpper();
			       if (name == "VALUEMAP")
{
 _ValueMap = System.Convert.ToString(value);return;
}
if (name == "ID")
{
 _Id = XCode.Common.Helper.ConvertToGuid(value);return;
}
if (name == "SEQU")
{
 _Sequ = System.Convert.ToInt32(value);return;
}
if (name == "TABLENAME")
{
 _TableName = System.Convert.ToString(value);return;
}
if (name == "FIELDNAME")
{
 _FieldName = System.Convert.ToString(value);return;
}
if (name == "TITLE")
{
 _Title = System.Convert.ToString(value);return;
}
if (name == "FIELDTYPE")
{
 _FieldType = System.Convert.ToString(value);return;
}
if (name == "FIELDLENGTH")
{
 _FieldLength = System.Convert.ToInt32(value);return;
}
if (name == "ALLOWNULL")
{
 _AllowNull = System.Convert.ToSByte(value);return;
}
if (name == "ISKEYFIELD")
{
 _IsKeyField = System.Convert.ToSByte(value);return;
}
if (name == "USETYPE")
{
 _UseType = System.Convert.ToString(value);return;
}
if (name == "GUIDFIELDNAME")
{
 _GuidFieldName = System.Convert.ToString(value);return;
}
if (name == "NEWFIELDNAME")
{
 _NewFieldName = System.Convert.ToString(value);return;
}
if (name == "NEWFIELDTYPE")
{
 _NewFieldType = System.Convert.ToString(value);return;
}
if (name == "NEWFIELDLENGTH")
{
 _NewFieldLength = System.Convert.ToInt32(value);return;
}
if (name == "DEFAULTVALUE")
{
 _DefaultValue = System.Convert.ToString(value);return;
}
if (name == "FOREIGNTABLEFIELD")
{
 _ForeignTableField = System.Convert.ToString(value);return;
}
if (name == "REGDATE")
{
 if (value == null || value.ToString().IsNullOrEmpty() == true) value = DateTime.MinValue;
 _RegDate = System.Convert.ToDateTime(value);return;
}

			    base[name] = value;
			}
		}
		#endregion
	}
}