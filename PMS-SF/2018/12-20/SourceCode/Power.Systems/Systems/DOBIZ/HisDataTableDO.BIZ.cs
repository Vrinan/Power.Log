 
 
 using    System;
 using System.Collections.Generic;
 using System.Text; 
 using XCode.Attributes    ;

 namespace  Power.Systems.Systems
{
    /// <summary>
    /// 历史数据迁移表
    /// </summary>
    public class HisDataTableDO : HisDataTableDO<HisDataTableDO>
    {

    }

	/// <summary>
    /// 历史数据迁移表
    /// </summary>
	  [BindEntity(KeyWord="HisDataTable",EntityType = typeof(Power.Systems.Systems.HisDataTableDO),Description = "历史数据迁移表"  )] 

	 [BindTable( "PB_HisDataTable", Alias = "a",IsAttach=false,Description ="")]

	  [BindIndex(Name = "pk_PB_HisDataTable", KeyType = Power.DataAccessLayer.KeyType.MainKey, Columns = "Id", TableName = "PB_HisDataTable",Description="")]

    public   class HisDataTableDO<TEntity> : XCode.Entity<TEntity>, XCode.IEntity where TEntity : Power.Systems.Systems.HisDataTableDO<TEntity>, new()
    { 
	    #region 属性

	    
 private System.String _KeyWord;
 /// <summary>
 /// 新表KeyWord
 /// </summary>
 [BindColumn(1,"a", "KeyWord", "新表KeyWord","", "NCHAR", 100,0,false, IsPrimaryKey =false ,IsIdentity =false,IsNullable =true,  Length =100 )]
 public  System.String KeyWord  { get { return _KeyWord; } set { _KeyWord = value; } }

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

 private System.String _Title;
 /// <summary>
 /// 标题
 /// </summary>
 [BindColumn(4,"a", "Title", "标题","", "NCHAR", 100,0,false, IsPrimaryKey =false ,IsIdentity =false,IsNullable =true,  Length =100 )]
 public  System.String Title  { get { return _Title; } set { _Title = value; } }

 private System.String _NewTableName;
 /// <summary>
 /// 新表名称
 /// </summary>
 [BindColumn(5,"a", "NewTableName", "新表名称","", "NCHAR", 100,0,false, IsPrimaryKey =false ,IsIdentity =false,IsNullable =true,  Length =100 )]
 public  System.String NewTableName  { get { return _NewTableName; } set { _NewTableName = value; } }

 private System.String _ModuleName;
 /// <summary>
 /// 所属模块
 /// </summary>
 [BindColumn(6,"a", "ModuleName", "所属模块","", "NCHAR", 100,0,false, IsPrimaryKey =false ,IsIdentity =false,IsNullable =true,  Length =100 )]
 public  System.String ModuleName  { get { return _ModuleName; } set { _ModuleName = value; } }

 private System.DateTime _RegDate;
 /// <summary>
 /// 录入日期
 /// </summary>
 [BindColumn(7,"a", "RegDate", "录入日期","", "NCHAR", 3,0,false, IsPrimaryKey =false ,IsIdentity =false,IsNullable =true,  Length =3 )]
 public  System.DateTime RegDate  { get { return _RegDate; } set { _RegDate = value; } }

 private System.String _Memo;
 /// <summary>
 /// 备注
 /// </summary>
 [BindColumn(8,"a", "Memo", "备注","", "NCHAR", 4000,0,false, IsPrimaryKey =false ,IsIdentity =false,IsNullable =true,  Length =4000 )]
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
			    if (name == "KEYWORD")
{
return _KeyWord;
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
if (name == "TITLE")
{
return _Title;
}
if (name == "NEWTABLENAME")
{
return _NewTableName;
}
if (name == "MODULENAME")
{
return _ModuleName;
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
			       if (name == "KEYWORD")
{
 _KeyWord = System.Convert.ToString(value);return;
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
if (name == "TITLE")
{
 _Title = System.Convert.ToString(value);return;
}
if (name == "NEWTABLENAME")
{
 _NewTableName = System.Convert.ToString(value);return;
}
if (name == "MODULENAME")
{
 _ModuleName = System.Convert.ToString(value);return;
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