 
 
 using    System;
 using System.Collections.Generic;
 using System.Text; 
 using XCode.Attributes    ;

 namespace  Power.Systems.Systems
{
    /// <summary>
    /// 表单关联
    /// </summary>
    public class PB_RecLinkDO : PB_RecLinkDO<PB_RecLinkDO>
    {

    }

	/// <summary>
    /// 表单关联
    /// </summary>
	  [BindEntity(KeyWord="PB_RecLink",EntityType = typeof(Power.Systems.Systems.PB_RecLinkDO),Description = "表单关联"  )] 

	 [BindTable( "PB_RecLink", Alias = "a",IsAttach=false,Description ="")]

	  [BindIndex(Name = "pk_PB_RecLink", KeyType = Power.DataAccessLayer.KeyType.MainKey, Columns = "Id", TableName = "PB_RecLink",Description="")]

    public   class PB_RecLinkDO<TEntity> : XCode.Entity<TEntity>, XCode.IEntity where TEntity : Power.Systems.Systems.PB_RecLinkDO<TEntity>, new()
    { 
	    #region 属性

	    
 private System.Guid _Id;
 /// <summary>
 /// 主键唯一标识
 /// </summary>
 [BindColumn(1,"a", "Id", "主键唯一标识","", "NCHAR", 16,0,false, IsPrimaryKey =true ,IsIdentity =true,IsNullable =false,  Length =16 )]
 public virtual System.Guid Id  { get { return _Id; } set { _Id = value; } }

 private System.String _RelaMenuName;
 /// <summary>
 /// 当前菜单名称
 /// </summary>
 [BindColumn(2,"a", "RelaMenuName", "当前菜单名称","", "NCHAR", 200,0,false, IsPrimaryKey =false ,IsIdentity =false,IsNullable =true,  Length =200 )]
 public  System.String RelaMenuName  { get { return _RelaMenuName; } set { _RelaMenuName = value; } }

 private System.Guid _RelaKeyValue;
 /// <summary>
 /// 当前表主键
 /// </summary>
 [BindColumn(2,"a", "RelaKeyValue", "当前表主键","", "NCHAR", 16,0,false, IsPrimaryKey =false ,IsIdentity =false,IsNullable =true,  Length =16 )]
 public  System.Guid RelaKeyValue  { get { return _RelaKeyValue; } set { _RelaKeyValue = value; } }

 private System.String _RelaTitle;
 /// <summary>
 /// 当前表标题
 /// </summary>
 [BindColumn(3,"a", "RelaTitle", "当前表标题","", "NCHAR", 2000,0,false, IsPrimaryKey =false ,IsIdentity =false,IsNullable =true,  Length =2000 )]
 public  System.String RelaTitle  { get { return _RelaTitle; } set { _RelaTitle = value; } }

 private System.String _RelaKeyWord;
 /// <summary>
 /// 当前表关键词
 /// </summary>
 [BindColumn(4,"a", "RelaKeyWord", "当前表关键词","", "NCHAR", 200,0,false, IsPrimaryKey =false ,IsIdentity =false,IsNullable =true,  Length =200 )]
 public  System.String RelaKeyWord  { get { return _RelaKeyWord; } set { _RelaKeyWord = value; } }

 private System.Guid _SourceKeyValue;
 /// <summary>
 /// 关联表主键
 /// </summary>
 [BindColumn(5,"a", "SourceKeyValue", "关联表主键","", "NCHAR", 16,0,false, IsPrimaryKey =false ,IsIdentity =false,IsNullable =true,  Length =16 )]
 public  System.Guid SourceKeyValue  { get { return _SourceKeyValue; } set { _SourceKeyValue = value; } }

 private System.String _SourceMenuName;
 /// <summary>
 /// 关联菜单名称
 /// </summary>
 [BindColumn(6,"a", "SourceMenuName", "关联菜单名称","", "NCHAR", 200,0,false, IsPrimaryKey =false ,IsIdentity =false,IsNullable =true,  Length =200 )]
 public  System.String SourceMenuName  { get { return _SourceMenuName; } set { _SourceMenuName = value; } }

 private System.String _SourceTitle;
 /// <summary>
 /// 关联表标题
 /// </summary>
 [BindColumn(6,"a", "SourceTitle", "关联表标题","", "NCHAR", 2000,0,false, IsPrimaryKey =false ,IsIdentity =false,IsNullable =true,  Length =2000 )]
 public  System.String SourceTitle  { get { return _SourceTitle; } set { _SourceTitle = value; } }

 private System.Guid _RelaFormId;
 /// <summary>
 /// 当前表单Id
 /// </summary>
 [BindColumn(6,"a", "RelaFormId", "当前表单Id","", "NCHAR", 16,0,false, IsPrimaryKey =false ,IsIdentity =false,IsNullable =true,  Length =16 )]
 public  System.Guid RelaFormId  { get { return _RelaFormId; } set { _RelaFormId = value; } }

 private System.String _SourceKeyWord;
 /// <summary>
 /// 关联表关键词
 /// </summary>
 [BindColumn(7,"a", "SourceKeyWord", "关联表关键词","", "NCHAR", 200,0,false, IsPrimaryKey =false ,IsIdentity =false,IsNullable =true,  Length =200 )]
 public  System.String SourceKeyWord  { get { return _SourceKeyWord; } set { _SourceKeyWord = value; } }

 private System.String _RecType;
 /// <summary>
 /// 单项，双向
 /// </summary>
 [BindColumn(8,"a", "RecType", "单项，双向","", "NCHAR", 10,0,false, IsPrimaryKey =false ,IsIdentity =false,IsNullable =true,  Length =10 )]
 public  System.String RecType  { get { return _RecType; } set { _RecType = value; } }

 private System.Guid _RegHumId;
 /// <summary>
 /// 录入人Id
 /// </summary>
 [BindColumn(9,"a", "RegHumId", "录入人Id","", "NCHAR", 16,0,false, IsPrimaryKey =false ,IsIdentity =false,IsNullable =true,  Length =16 )]
 public  System.Guid RegHumId  { get { return _RegHumId; } set { _RegHumId = value; } }

 private System.String _RegHumName;
 /// <summary>
 /// 录入人名称
 /// </summary>
 [BindColumn(10,"a", "RegHumName", "录入人名称","", "NCHAR", 200,0,false, IsPrimaryKey =false ,IsIdentity =false,IsNullable =true,  Length =200 )]
 public  System.String RegHumName  { get { return _RegHumName; } set { _RegHumName = value; } }

 private System.DateTime _RegDate;
 /// <summary>
 /// 录入时间
 /// </summary>
 [BindColumn(11,"a", "RegDate", "录入时间","", "NCHAR", 3,0,false, IsPrimaryKey =false ,IsIdentity =false,IsNullable =true,  Length =3 )]
 public  System.DateTime RegDate  { get { return _RegDate; } set { _RegDate = value; } }

 private System.Guid _SourceFormId;
 /// <summary>
 /// 关联表单Id
 /// </summary>
 [BindColumn(11,"a", "SourceFormId", "关联表单Id","", "NCHAR", 16,0,false, IsPrimaryKey =false ,IsIdentity =false,IsNullable =true,  Length =16 )]
 public  System.Guid SourceFormId  { get { return _SourceFormId; } set { _SourceFormId = value; } }

 private System.Guid _UpdHumId;
 /// <summary>
 /// 修改人Id
 /// </summary>
 [BindColumn(12,"a", "UpdHumId", "修改人Id","", "NCHAR", 16,0,false, IsPrimaryKey =false ,IsIdentity =false,IsNullable =true,  Length =16 )]
 public  System.Guid UpdHumId  { get { return _UpdHumId; } set { _UpdHumId = value; } }

 private System.String _UpdHumName;
 /// <summary>
 /// 修改人名称
 /// </summary>
 [BindColumn(13,"a", "UpdHumName", "修改人名称","", "NCHAR", 200,0,false, IsPrimaryKey =false ,IsIdentity =false,IsNullable =true,  Length =200 )]
 public  System.String UpdHumName  { get { return _UpdHumName; } set { _UpdHumName = value; } }

 private System.DateTime _UpdDate;
 /// <summary>
 /// 修改时间
 /// </summary>
 [BindColumn(14,"a", "UpdDate", "修改时间","", "NCHAR", 3,0,false, IsPrimaryKey =false ,IsIdentity =false,IsNullable =true,  Length =3 )]
 public  System.DateTime UpdDate  { get { return _UpdDate; } set { _UpdDate = value; } }

 private System.Int32 _Sequ;
 /// <summary>
 /// 序号
 /// </summary>
 [BindColumn(15,"a", "Sequ", "序号","", "NCHAR", 10,0,false, IsPrimaryKey =false ,IsIdentity =false,IsNullable =true,  Length =10 )]
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
if (name == "RELAMENUNAME")
{
return _RelaMenuName;
}
if (name == "RELAKEYVALUE")
{
return _RelaKeyValue;
}
if (name == "RELATITLE")
{
return _RelaTitle;
}
if (name == "RELAKEYWORD")
{
return _RelaKeyWord;
}
if (name == "SOURCEKEYVALUE")
{
return _SourceKeyValue;
}
if (name == "SOURCEMENUNAME")
{
return _SourceMenuName;
}
if (name == "SOURCETITLE")
{
return _SourceTitle;
}
if (name == "RELAFORMID")
{
return _RelaFormId;
}
if (name == "SOURCEKEYWORD")
{
return _SourceKeyWord;
}
if (name == "RECTYPE")
{
return _RecType;
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
if (name == "SOURCEFORMID")
{
return _SourceFormId;
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
if (name == "RELAMENUNAME")
{
 _RelaMenuName = System.Convert.ToString(value);return;
}
if (name == "RELAKEYVALUE")
{
 _RelaKeyValue = XCode.Common.Helper.ConvertToGuid(value);return;
}
if (name == "RELATITLE")
{
 _RelaTitle = System.Convert.ToString(value);return;
}
if (name == "RELAKEYWORD")
{
 _RelaKeyWord = System.Convert.ToString(value);return;
}
if (name == "SOURCEKEYVALUE")
{
 _SourceKeyValue = XCode.Common.Helper.ConvertToGuid(value);return;
}
if (name == "SOURCEMENUNAME")
{
 _SourceMenuName = System.Convert.ToString(value);return;
}
if (name == "SOURCETITLE")
{
 _SourceTitle = System.Convert.ToString(value);return;
}
if (name == "RELAFORMID")
{
 _RelaFormId = XCode.Common.Helper.ConvertToGuid(value);return;
}
if (name == "SOURCEKEYWORD")
{
 _SourceKeyWord = System.Convert.ToString(value);return;
}
if (name == "RECTYPE")
{
 _RecType = System.Convert.ToString(value);return;
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
if (name == "SOURCEFORMID")
{
 _SourceFormId = XCode.Common.Helper.ConvertToGuid(value);return;
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