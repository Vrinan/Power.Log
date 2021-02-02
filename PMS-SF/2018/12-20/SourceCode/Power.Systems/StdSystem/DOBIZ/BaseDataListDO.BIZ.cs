 
 
 using    System;
 using System.Collections.Generic;
 using System.Text; 
 using XCode.Attributes    ;

 namespace  Power.Systems.StdSystem
{
    /// <summary>
    /// 基础数据列表
    /// </summary>
    public class BaseDataListDO : BaseDataListDO<BaseDataListDO>
    {

    }

	/// <summary>
    /// 基础数据列表
    /// </summary>
	  [BindEntity(KeyWord="BaseDataList",EntityType = typeof(Power.Systems.StdSystem.BaseDataListDO),Description = "基础数据列表"  )] 

	 [BindTable( "PB_BaseDataList", Alias = "a",IsAttach=false,Description ="")]

	  [BindIndex(Name = "pk_PB_BaseDataList", KeyType = Power.DataAccessLayer.KeyType.MainKey, Columns = "Id", TableName = "PB_BaseDataList",Description="")]
 [BindIndex(Name = "pt_PB_BaseDataList", KeyType = Power.DataAccessLayer.KeyType.ParentKey, Columns = "ParentId,Id", TableName = "PB_BaseDataList",Description="")]

    public   class BaseDataListDO<TEntity> : XCode.Entity<TEntity>, XCode.IEntity where TEntity : Power.Systems.StdSystem.BaseDataListDO<TEntity>, new()
    { 
	    #region 属性

	    
 private System.String _OtherInfo;
 /// <summary>
 /// 
 /// </summary>
 [BindColumn(1,"a", "OtherInfo", "","", "NCHAR", 100,0,false, IsPrimaryKey =false ,IsIdentity =false,IsNullable =true,  Length =100 )]
 public  System.String OtherInfo  { get { return _OtherInfo; } set { _OtherInfo = value; } }

 private System.Int32 _Sequ;
 /// <summary>
 /// 
 /// </summary>
 [BindColumn(1,"a", "Sequ", "","", "NCHAR", 6,0,false, IsPrimaryKey =false ,IsIdentity =false,IsNullable =true,  Length =6 )]
 public  System.Int32 Sequ  { get { return _Sequ; } set { _Sequ = value; } }

 private System.String _bSysDefault;
 /// <summary>
 /// Y系统缺省,N用户自定义
 /// </summary>
 [BindColumn(1,"a", "bSysDefault", "Y系统缺省,N用户自定义","", "NCHAR", 1,0,false, IsPrimaryKey =false ,IsIdentity =false,IsNullable =false,  Length =1 )]
 public  System.String bSysDefault  { get { return _bSysDefault; } set { _bSysDefault = value; } }

 private System.Guid _SourceBaseDataId;
 /// <summary>
 /// 原始基础数据Id
 /// </summary>
 [BindColumn(1,"a", "SourceBaseDataId", "原始基础数据Id","", "NCHAR", 0,0,false, IsPrimaryKey =false ,IsIdentity =false,IsNullable =true,  Length =0 )]
 public  System.Guid SourceBaseDataId  { get { return _SourceBaseDataId; } set { _SourceBaseDataId = value; } }

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

 private System.Guid _BaseDataId;
 /// <summary>
 /// 基础数据类型Id
 /// </summary>
 [BindColumn(3,"a", "BaseDataId", "基础数据类型Id","", "NCHAR", 16,0,false, IsPrimaryKey =false ,IsIdentity =false,IsNullable =true,  Length =16 )]
 public  System.Guid BaseDataId  { get { return _BaseDataId; } set { _BaseDataId = value; } }

 private System.String _Code;
 /// <summary>
 /// 基础数据编号
 /// </summary>
 [BindColumn(4,"a", "Code", "基础数据编号","", "NCHAR", 50,0,false, IsPrimaryKey =false ,IsIdentity =false,IsNullable =true,  Length =50 )]
 public  System.String Code  { get { return _Code; } set { _Code = value; } }

 private System.String _Name;
 /// <summary>
 /// 基础数据名称
 /// </summary>
 [BindColumn(5,"a", "Name", "基础数据名称","", "NCHAR", 100,0,false, IsPrimaryKey =false ,IsIdentity =false,IsNullable =true,  Length =100 )]
 public  System.String Name  { get { return _Name; } set { _Name = value; } }

 private System.SByte _Actived;
 /// <summary>
 /// 启用1，禁用0
 /// </summary>
 [BindColumn(6,"a", "Actived", "启用1，禁用0","", "NCHAR", 3,0,false, IsPrimaryKey =false ,IsIdentity =false,IsNullable =true,  Length =3 )]
 public  System.SByte Actived  { get { return _Actived; } set { _Actived = value; } }

 private System.DateTime _UpdDate;
 /// <summary>
 /// 最后修改日期
 /// </summary>
 [BindColumn(7,"a", "UpdDate", "最后修改日期","", "NCHAR", 3,0,false, IsPrimaryKey =false ,IsIdentity =false,IsNullable =true,  Length =3 )]
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
			    if (name == "OTHERINFO")
{
return _OtherInfo;
}
if (name == "SEQU")
{
return _Sequ;
}
if (name == "BSYSDEFAULT")
{
return _bSysDefault;
}
if (name == "SOURCEBASEDATAID")
{
return _SourceBaseDataId;
}
if (name == "ID")
{
return _Id;
}
if (name == "PARENTID")
{
return _ParentId;
}
if (name == "BASEDATAID")
{
return _BaseDataId;
}
if (name == "CODE")
{
return _Code;
}
if (name == "NAME")
{
return _Name;
}
if (name == "ACTIVED")
{
return _Actived;
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
			       if (name == "OTHERINFO")
{
 _OtherInfo = System.Convert.ToString(value);return;
}
if (name == "SEQU")
{
 _Sequ = System.Convert.ToInt32(value);return;
}
if (name == "BSYSDEFAULT")
{
 _bSysDefault = System.Convert.ToString(value);return;
}
if (name == "SOURCEBASEDATAID")
{
 _SourceBaseDataId = XCode.Common.Helper.ConvertToGuid(value);return;
}
if (name == "ID")
{
 _Id = XCode.Common.Helper.ConvertToGuid(value);return;
}
if (name == "PARENTID")
{
 _ParentId = XCode.Common.Helper.ConvertToGuid(value);return;
}
if (name == "BASEDATAID")
{
 _BaseDataId = XCode.Common.Helper.ConvertToGuid(value);return;
}
if (name == "CODE")
{
 _Code = System.Convert.ToString(value);return;
}
if (name == "NAME")
{
 _Name = System.Convert.ToString(value);return;
}
if (name == "ACTIVED")
{
 _Actived = System.Convert.ToSByte(value);return;
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