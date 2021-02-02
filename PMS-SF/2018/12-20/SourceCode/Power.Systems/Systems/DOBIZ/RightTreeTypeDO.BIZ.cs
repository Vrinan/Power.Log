 
 
 using    System;
 using System.Collections.Generic;
 using System.Text; 
 using XCode.Attributes    ;

 namespace  Power.Systems.Systems
{
    /// <summary>
    /// 权限分类树
    /// </summary>
    public class RightTreeTypeDO : RightTreeTypeDO<RightTreeTypeDO>
    {

    }

	/// <summary>
    /// 权限分类树
    /// </summary>
	  [BindEntity(KeyWord="RightTreeType",EntityType = typeof(Power.Systems.Systems.RightTreeTypeDO),Description = "权限分类树"  )] 

	 [BindTable( "PB_RightTreeType", Alias = "a",IsAttach=false,Description ="")]

	  [BindIndex(Name = "pk_PB_RightTreeType", KeyType = Power.DataAccessLayer.KeyType.MainKey, Columns = "Id", TableName = "PB_RightTreeType",Description="")]

    public   class RightTreeTypeDO<TEntity> : XCode.Entity<TEntity>, XCode.IEntity where TEntity : Power.Systems.Systems.RightTreeTypeDO<TEntity>, new()
    { 
	    #region 属性

	    
 private System.Guid _Id;
 /// <summary>
 /// 
 /// </summary>
 [BindColumn(1,"a", "Id", "","", "NCHAR", 16,0,false, IsPrimaryKey =true ,IsIdentity =true,IsNullable =false,  Length =16 )]
 public virtual System.Guid Id  { get { return _Id; } set { _Id = value; } }

 private System.Int32 _Sequ;
 /// <summary>
 /// 
 /// </summary>
 [BindColumn(2,"a", "Sequ", "","", "NCHAR", 10,0,false, IsPrimaryKey =false ,IsIdentity =false,IsNullable =true,  Length =10 )]
 public  System.Int32 Sequ  { get { return _Sequ; } set { _Sequ = value; } }

 private System.String _KeyWord;
 /// <summary>
 /// 
 /// </summary>
 [BindColumn(3,"a", "KeyWord", "","", "NCHAR", 50,0,false, IsPrimaryKey =false ,IsIdentity =false,IsNullable =true,  Length =50 )]
 public  System.String KeyWord  { get { return _KeyWord; } set { _KeyWord = value; } }

 private System.String _Name;
 /// <summary>
 /// 
 /// </summary>
 [BindColumn(4,"a", "Name", "","", "NCHAR", 100,0,false, IsPrimaryKey =false ,IsIdentity =false,IsNullable =true,  Length =100 )]
 public  System.String Name  { get { return _Name; } set { _Name = value; } }

 private System.String _KeyWordType;
 /// <summary>
 /// 
 /// </summary>
 [BindColumn(5,"a", "KeyWordType", "","", "NCHAR", 10,0,false, IsPrimaryKey =false ,IsIdentity =false,IsNullable =true,  Length =10 )]
 public  System.String KeyWordType  { get { return _KeyWordType; } set { _KeyWordType = value; } }

 private System.String _KeyField;
 /// <summary>
 /// 选择的数据行会写的字段
 /// </summary>
 [BindColumn(6,"a", "KeyField", "选择的数据行会写的字段","", "NCHAR", 50,0,false, IsPrimaryKey =false ,IsIdentity =false,IsNullable =true,  Length =50 )]
 public  System.String KeyField  { get { return _KeyField; } set { _KeyField = value; } }

      
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
if (name == "SEQU")
{
return _Sequ;
}
if (name == "KEYWORD")
{
return _KeyWord;
}
if (name == "NAME")
{
return _Name;
}
if (name == "KEYWORDTYPE")
{
return _KeyWordType;
}
if (name == "KEYFIELD")
{
return _KeyField;
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
if (name == "SEQU")
{
 _Sequ = System.Convert.ToInt32(value);return;
}
if (name == "KEYWORD")
{
 _KeyWord = System.Convert.ToString(value);return;
}
if (name == "NAME")
{
 _Name = System.Convert.ToString(value);return;
}
if (name == "KEYWORDTYPE")
{
 _KeyWordType = System.Convert.ToString(value);return;
}
if (name == "KEYFIELD")
{
 _KeyField = System.Convert.ToString(value);return;
}

			    base[name] = value;
			}
		}
		#endregion
	}
}