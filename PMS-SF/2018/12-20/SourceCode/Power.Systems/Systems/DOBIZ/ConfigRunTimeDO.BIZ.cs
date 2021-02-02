 
 
 using    System;
 using System.Collections.Generic;
 using System.Text; 
 using XCode.Attributes    ;

 namespace  Power.Systems.Systems
{
    /// <summary>
    /// 运行时参数
    /// </summary>
    public class ConfigRunTimeDO : ConfigRunTimeDO<ConfigRunTimeDO>
    {

    }

	/// <summary>
    /// 运行时参数
    /// </summary>
	  [BindEntity(KeyWord="ConfigRunTime",EntityType = typeof(Power.Systems.Systems.ConfigRunTimeDO),Description = "运行时参数"  )] 

	 [BindTable( "PB_ConfigRunTime", Alias = "a",IsAttach=false,Description ="")]

	  [BindIndex(Name = "pk_PB_ConfigRunTime", KeyType = Power.DataAccessLayer.KeyType.MainKey, Columns = "Id", TableName = "PB_ConfigRunTime",Description="")]
 [BindIndex(Name = "pt_PB_ConfigRunTime", KeyType = Power.DataAccessLayer.KeyType.ParentKey, Columns = "ParentId,Id", TableName = "PB_ConfigRunTime",Description="")]

    public   class ConfigRunTimeDO<TEntity> : XCode.Entity<TEntity>, XCode.IEntity where TEntity : Power.Systems.Systems.ConfigRunTimeDO<TEntity>, new()
    { 
	    #region 属性

	    
 private System.Guid _EpsProjId;
 /// <summary>
 /// 所属项目
 /// </summary>
 [BindColumn(1,"a", "EpsProjId", "所属项目","", "NCHAR", 0,0,false, IsPrimaryKey =false ,IsIdentity =false,IsNullable =false,  Length =0 )]
 public  System.Guid EpsProjId  { get { return _EpsProjId; } set { _EpsProjId = value; } }

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

 private System.String _ConfigTypeCode;
 /// <summary>
 /// 分类编号
 /// </summary>
 [BindColumn(3,"a", "ConfigTypeCode", "分类编号","", "NCHAR", 30,0,false, IsPrimaryKey =false ,IsIdentity =false,IsNullable =true,  Length =30 )]
 public  System.String ConfigTypeCode  { get { return _ConfigTypeCode; } set { _ConfigTypeCode = value; } }

 private System.String _ConfigTypeName;
 /// <summary>
 /// 分类名称
 /// </summary>
 [BindColumn(4,"a", "ConfigTypeName", "分类名称","", "NCHAR", 100,0,false, IsPrimaryKey =false ,IsIdentity =false,IsNullable =true,  Length =100 )]
 public  System.String ConfigTypeName  { get { return _ConfigTypeName; } set { _ConfigTypeName = value; } }

 private System.Int32 _Sequ;
 /// <summary>
 /// 序号
 /// </summary>
 [BindColumn(5,"a", "Sequ", "序号","", "NCHAR", 10,0,false, IsPrimaryKey =false ,IsIdentity =false,IsNullable =true,  Length =10 )]
 public  System.Int32 Sequ  { get { return _Sequ; } set { _Sequ = value; } }

 private System.String _Code;
 /// <summary>
 /// 编号
 /// </summary>
 [BindColumn(6,"a", "Code", "编号","", "NCHAR", 100,0,false, IsPrimaryKey =false ,IsIdentity =false,IsNullable =true,  Length =100 )]
 public  System.String Code  { get { return _Code; } set { _Code = value; } }

 private System.String _Name;
 /// <summary>
 /// 名称
 /// </summary>
 [BindColumn(7,"a", "Name", "名称","", "NCHAR", 255,0,false, IsPrimaryKey =false ,IsIdentity =false,IsNullable =true,  Length =255 )]
 public  System.String Name  { get { return _Name; } set { _Name = value; } }

 private System.String _Value;
 /// <summary>
 /// 值
 /// </summary>
 [BindColumn(8,"a", "Value", "值","", "NCHAR", 255,0,false, IsPrimaryKey =false ,IsIdentity =false,IsNullable =true,  Length =255 )]
 public  System.String Value  { get { return _Value; } set { _Value = value; } }

 private System.String _EncodeFlag;
 /// <summary>
 /// 值：Y加密，N未加密
 /// </summary>
 [BindColumn(9,"a", "EncodeFlag", "值：Y加密，N未加密","", "NCHAR", 1,0,false, IsPrimaryKey =false ,IsIdentity =false,IsNullable =true,  Length =1 )]
 public  System.String EncodeFlag  { get { return _EncodeFlag; } set { _EncodeFlag = value; } }

 private System.Guid _BizAreaId;
 /// <summary>
 /// 业务域
 /// </summary>
 [BindColumn(10,"a", "BizAreaId", "业务域","", "NCHAR", 16,0,false, IsPrimaryKey =false ,IsIdentity =false,IsNullable =true,  Length =16 )]
 public  System.Guid BizAreaId  { get { return _BizAreaId; } set { _BizAreaId = value; } }

 private System.Guid _UpdHumId;
 /// <summary>
 /// 最后更新人Id
 /// </summary>
 [BindColumn(11,"a", "UpdHumId", "最后更新人Id","", "NCHAR", 16,0,false, IsPrimaryKey =false ,IsIdentity =false,IsNullable =true,  Length =16 )]
 public  System.Guid UpdHumId  { get { return _UpdHumId; } set { _UpdHumId = value; } }

 private System.String _UpdHumName;
 /// <summary>
 /// 最后更新人名称
 /// </summary>
 [BindColumn(12,"a", "UpdHumName", "最后更新人名称","", "NCHAR", 80,0,false, IsPrimaryKey =false ,IsIdentity =false,IsNullable =true,  Length =80 )]
 public  System.String UpdHumName  { get { return _UpdHumName; } set { _UpdHumName = value; } }

 private System.DateTime _UpdDate;
 /// <summary>
 /// 最后更新日期
 /// </summary>
 [BindColumn(13,"a", "UpdDate", "最后更新日期","", "NCHAR", 3,0,false, IsPrimaryKey =false ,IsIdentity =false,IsNullable =true,  Length =3 )]
 public  System.DateTime UpdDate  { get { return _UpdDate; } set { _UpdDate = value; } }

 private System.String _Memo;
 /// <summary>
 /// 备注
 /// </summary>
 [BindColumn(14,"a", "Memo", "备注","", "NCHAR", 255,0,false, IsPrimaryKey =false ,IsIdentity =false,IsNullable =true,  Length =255 )]
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
			    if (name == "EPSPROJID")
{
return _EpsProjId;
}
if (name == "ID")
{
return _Id;
}
if (name == "PARENTID")
{
return _ParentId;
}
if (name == "CONFIGTYPECODE")
{
return _ConfigTypeCode;
}
if (name == "CONFIGTYPENAME")
{
return _ConfigTypeName;
}
if (name == "SEQU")
{
return _Sequ;
}
if (name == "CODE")
{
return _Code;
}
if (name == "NAME")
{
return _Name;
}
if (name == "VALUE")
{
return _Value;
}
if (name == "ENCODEFLAG")
{
return _EncodeFlag;
}
if (name == "BIZAREAID")
{
return _BizAreaId;
}
if (name == "UPDHUMID")
{
return _UpdHumId;
}
if (name == "UPDHUMNAME")
{
return _UpdHumName;
}
if (name == "UPDDATE")
{
return _UpdDate;
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
			       if (name == "EPSPROJID")
{
 _EpsProjId = XCode.Common.Helper.ConvertToGuid(value);return;
}
if (name == "ID")
{
 _Id = XCode.Common.Helper.ConvertToGuid(value);return;
}
if (name == "PARENTID")
{
 _ParentId = XCode.Common.Helper.ConvertToGuid(value);return;
}
if (name == "CONFIGTYPECODE")
{
 _ConfigTypeCode = System.Convert.ToString(value);return;
}
if (name == "CONFIGTYPENAME")
{
 _ConfigTypeName = System.Convert.ToString(value);return;
}
if (name == "SEQU")
{
 _Sequ = System.Convert.ToInt32(value);return;
}
if (name == "CODE")
{
 _Code = System.Convert.ToString(value);return;
}
if (name == "NAME")
{
 _Name = System.Convert.ToString(value);return;
}
if (name == "VALUE")
{
 _Value = System.Convert.ToString(value);return;
}
if (name == "ENCODEFLAG")
{
 _EncodeFlag = System.Convert.ToString(value);return;
}
if (name == "BIZAREAID")
{
 _BizAreaId = XCode.Common.Helper.ConvertToGuid(value);return;
}
if (name == "UPDHUMID")
{
 _UpdHumId = XCode.Common.Helper.ConvertToGuid(value);return;
}
if (name == "UPDHUMNAME")
{
 _UpdHumName = System.Convert.ToString(value);return;
}
if (name == "UPDDATE")
{
 if (value == null || value.ToString().IsNullOrEmpty() == true) value = DateTime.MinValue;
 _UpdDate = System.Convert.ToDateTime(value);return;
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