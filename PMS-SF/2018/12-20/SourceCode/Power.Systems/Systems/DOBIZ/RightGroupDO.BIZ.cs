 
 
 using    System;
 using System.Collections.Generic;
 using System.Text; 
 using XCode.Attributes    ;

 namespace  Power.Systems.Systems
{
    /// <summary>
    /// 权限分组
    /// </summary>
    public class RightGroupDO : RightGroupDO<RightGroupDO>
    {

    }

	/// <summary>
    /// 权限分组
    /// </summary>
	  [BindEntity(KeyWord="RightGroup",EntityType = typeof(Power.Systems.Systems.RightGroupDO),Description = "权限分组"  )] 

	 [BindTable( "PB_RightGroup", Alias = "a",IsAttach=false,Description ="")]

	  [BindIndex(Name = "pk_PB_RightGroup", KeyType = Power.DataAccessLayer.KeyType.MainKey, Columns = "Id", TableName = "PB_RightGroup",Description="")]

    public   class RightGroupDO<TEntity> : XCode.Entity<TEntity>, XCode.IEntity where TEntity : Power.Systems.Systems.RightGroupDO<TEntity>, new()
    { 
	    #region 属性

	    
 private System.DateTime _UpdDate;
 /// <summary>
 /// 
 /// </summary>
 [BindColumn(1,"a", "UpdDate", "","", "NCHAR", 0,0,false, IsPrimaryKey =false ,IsIdentity =false,IsNullable =false,  Length =0 )]
 public  System.DateTime UpdDate  { get { return _UpdDate; } set { _UpdDate = value; } }

 private System.String _UseRange;
 /// <summary>
 /// 
 /// </summary>
 [BindColumn(1,"a", "UseRange", "","", "NCHAR", 10,0,false, IsPrimaryKey =false ,IsIdentity =false,IsNullable =false,  Length =10 )]
 public  System.String UseRange  { get { return _UseRange; } set { _UseRange = value; } }

 private System.Guid _Id;
 /// <summary>
 /// 主键
 /// </summary>
 [BindColumn(1,"a", "Id", "主键","", "NCHAR", 16,0,false, IsPrimaryKey =true ,IsIdentity =true,IsNullable =false,  Length =16 )]
 public virtual System.Guid Id  { get { return _Id; } set { _Id = value; } }

 private System.String _Name;
 /// <summary>
 /// 名称
 /// </summary>
 [BindColumn(2,"a", "Name", "名称","", "NCHAR", 80,0,false, IsPrimaryKey =false ,IsIdentity =false,IsNullable =false,  Length =80 )]
 public  System.String Name  { get { return _Name; } set { _Name = value; } }

 private System.Int32 _Sequ;
 /// <summary>
 /// 序号
 /// </summary>
 [BindColumn(3,"a", "Sequ", "序号","", "NCHAR", 10,0,false, IsPrimaryKey =false ,IsIdentity =false,IsNullable =false,  Length =10 )]
 public  System.Int32 Sequ  { get { return _Sequ; } set { _Sequ = value; } }

 private System.SByte _Actived;
 /// <summary>
 /// 1有效，0无效
 /// </summary>
 [BindColumn(4,"a", "Actived", "1有效，0无效","", "NCHAR", 3,0,false, IsPrimaryKey =false ,IsIdentity =false,IsNullable =false,  Length =3 )]
 public  System.SByte Actived  { get { return _Actived; } set { _Actived = value; } }

 private System.Guid _RegHumId;
 /// <summary>
 /// 录入人Id
 /// </summary>
 [BindColumn(5,"a", "RegHumId", "录入人Id","", "NCHAR", 16,0,false, IsPrimaryKey =false ,IsIdentity =false,IsNullable =false,  Length =16 )]
 public  System.Guid RegHumId  { get { return _RegHumId; } set { _RegHumId = value; } }

 private System.String _RegHumName;
 /// <summary>
 /// 录入人名称
 /// </summary>
 [BindColumn(6,"a", "RegHumName", "录入人名称","", "NCHAR", 80,0,false, IsPrimaryKey =false ,IsIdentity =false,IsNullable =false,  Length =80 )]
 public  System.String RegHumName  { get { return _RegHumName; } set { _RegHumName = value; } }

 private System.DateTime _RegDate;
 /// <summary>
 /// 录入日期
 /// </summary>
 [BindColumn(7,"a", "RegDate", "录入日期","", "NCHAR", 3,0,false, IsPrimaryKey =false ,IsIdentity =false,IsNullable =false,  Length =3 )]
 public  System.DateTime RegDate  { get { return _RegDate; } set { _RegDate = value; } }

 private System.Guid _BizAreaId;
 /// <summary>
 /// 业务域
 /// </summary>
 [BindColumn(8,"a", "BizAreaId", "业务域","", "NCHAR", 16,0,false, IsPrimaryKey =false ,IsIdentity =false,IsNullable =false,  Length =16 )]
 public  System.Guid BizAreaId  { get { return _BizAreaId; } set { _BizAreaId = value; } }

 private System.Guid _EpsProjId;
 /// <summary>
 /// EpsProjId
 /// </summary>
 [BindColumn(9,"a", "EpsProjId", "EpsProjId","", "NCHAR", 16,0,false, IsPrimaryKey =false ,IsIdentity =false,IsNullable =false,  Length =16 )]
 public  System.Guid EpsProjId  { get { return _EpsProjId; } set { _EpsProjId = value; } }

 private System.String _Memo;
 /// <summary>
 /// 备注
 /// </summary>
 [BindColumn(10,"a", "Memo", "备注","", "NCHAR", 255,0,false, IsPrimaryKey =false ,IsIdentity =false,IsNullable =true,  Length =255 )]
 public  System.String Memo  { get { return _Memo; } set { _Memo = value; } }

 private System.Guid _SourceId;
 /// <summary>
 /// IT初始化复制的源Id
 /// </summary>
 [BindColumn(11,"a", "SourceId", "IT初始化复制的源Id","", "NCHAR", 16,0,false, IsPrimaryKey =false ,IsIdentity =false,IsNullable =true,  Length =16 )]
 public  System.Guid SourceId  { get { return _SourceId; } set { _SourceId = value; } }

      
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
			    if (name == "UPDDATE")
{
return _UpdDate;
}
if (name == "USERANGE")
{
return _UseRange;
}
if (name == "ID")
{
return _Id;
}
if (name == "NAME")
{
return _Name;
}
if (name == "SEQU")
{
return _Sequ;
}
if (name == "ACTIVED")
{
return _Actived;
}
if (name == "REGHUMID")
{
return _RegHumId;
}
if (name == "REGHUMNAME")
{
return _RegHumName;
}
if (name == "REGDATE")
{
return _RegDate;
}
if (name == "BIZAREAID")
{
return _BizAreaId;
}
if (name == "EPSPROJID")
{
return _EpsProjId;
}
if (name == "MEMO")
{
return _Memo;
}
if (name == "SOURCEID")
{
return _SourceId;
}

			    return base[name];
			}
			set 
			{
			   name = name.ToUpper();
			       if (name == "UPDDATE")
{
 if (value == null || value.ToString().IsNullOrEmpty() == true) value = DateTime.MinValue;
 _UpdDate = System.Convert.ToDateTime(value);return;
}
if (name == "USERANGE")
{
 _UseRange = System.Convert.ToString(value);return;
}
if (name == "ID")
{
 _Id = XCode.Common.Helper.ConvertToGuid(value);return;
}
if (name == "NAME")
{
 _Name = System.Convert.ToString(value);return;
}
if (name == "SEQU")
{
 _Sequ = System.Convert.ToInt32(value);return;
}
if (name == "ACTIVED")
{
 _Actived = System.Convert.ToSByte(value);return;
}
if (name == "REGHUMID")
{
 _RegHumId = XCode.Common.Helper.ConvertToGuid(value);return;
}
if (name == "REGHUMNAME")
{
 _RegHumName = System.Convert.ToString(value);return;
}
if (name == "REGDATE")
{
 if (value == null || value.ToString().IsNullOrEmpty() == true) value = DateTime.MinValue;
 _RegDate = System.Convert.ToDateTime(value);return;
}
if (name == "BIZAREAID")
{
 _BizAreaId = XCode.Common.Helper.ConvertToGuid(value);return;
}
if (name == "EPSPROJID")
{
 _EpsProjId = XCode.Common.Helper.ConvertToGuid(value);return;
}
if (name == "MEMO")
{
 _Memo = System.Convert.ToString(value);return;
}
if (name == "SOURCEID")
{
 _SourceId = XCode.Common.Helper.ConvertToGuid(value);return;
}

			    base[name] = value;
			}
		}
		#endregion
	}
}