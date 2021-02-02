 
 
 using    System;
 using System.Collections.Generic;
 using System.Text; 
 using XCode.Attributes    ;

 namespace  Power.Systems.StdSystem
{
    /// <summary>
    /// 表单评论订阅
    /// </summary>
    public class CommentSubscribeDO : CommentSubscribeDO<CommentSubscribeDO>
    {

    }

	/// <summary>
    /// 表单评论订阅
    /// </summary>
	  [BindEntity(KeyWord="CommentSubscribe",EntityType = typeof(Power.Systems.StdSystem.CommentSubscribeDO),Description = "表单评论订阅"  )] 

	 [BindTable( "PB_CommentSubscribe", Alias = "a",IsAttach=false,Description ="")]

	  [BindIndex(Name = "pk_PB_CommentSubscribe", KeyType = Power.DataAccessLayer.KeyType.MainKey, Columns = "Id", TableName = "PB_CommentSubscribe",Description="")]

    public   class CommentSubscribeDO<TEntity> : XCode.Entity<TEntity>, XCode.IEntity where TEntity : Power.Systems.StdSystem.CommentSubscribeDO<TEntity>, new()
    { 
	    #region 属性

	    
 private System.Guid _Id;
 /// <summary>
 ///  主键
 /// </summary>
 [BindColumn(1,"a", "Id", " 主键","", "NCHAR", 16,0,false, IsPrimaryKey =true ,IsIdentity =true,IsNullable =false,  Length =16 )]
 public virtual System.Guid Id  { get { return _Id; } set { _Id = value; } }

 private System.String _KeyWord;
 /// <summary>
 /// KeyWord
 /// </summary>
 [BindColumn(2,"a", "KeyWord", "KeyWord","", "NCHAR", 80,0,false, IsPrimaryKey =false ,IsIdentity =false,IsNullable =false,  Length =80 )]
 public  System.String KeyWord  { get { return _KeyWord; } set { _KeyWord = value; } }

 private System.Guid _KeyValue;
 /// <summary>
 /// KeyWord主键
 /// </summary>
 [BindColumn(3,"a", "KeyValue", "KeyWord主键","", "NCHAR", 16,0,false, IsPrimaryKey =false ,IsIdentity =false,IsNullable =false,  Length =16 )]
 public  System.Guid KeyValue  { get { return _KeyValue; } set { _KeyValue = value; } }

 private System.Guid _RegHumId;
 /// <summary>
 /// 订阅人Id
 /// </summary>
 [BindColumn(4,"a", "RegHumId", "订阅人Id","", "NCHAR", 16,0,false, IsPrimaryKey =false ,IsIdentity =false,IsNullable =false,  Length =16 )]
 public  System.Guid RegHumId  { get { return _RegHumId; } set { _RegHumId = value; } }

 private System.DateTime _RegDate;
 /// <summary>
 /// 订阅日期
 /// </summary>
 [BindColumn(5,"a", "RegDate", "订阅日期","", "NCHAR", 3,0,false, IsPrimaryKey =false ,IsIdentity =false,IsNullable =false,  Length =3 )]
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
			    if (name == "ID")
{
return _Id;
}
if (name == "KEYWORD")
{
return _KeyWord;
}
if (name == "KEYVALUE")
{
return _KeyValue;
}
if (name == "REGHUMID")
{
return _RegHumId;
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
			       if (name == "ID")
{
 _Id = XCode.Common.Helper.ConvertToGuid(value);return;
}
if (name == "KEYWORD")
{
 _KeyWord = System.Convert.ToString(value);return;
}
if (name == "KEYVALUE")
{
 _KeyValue = XCode.Common.Helper.ConvertToGuid(value);return;
}
if (name == "REGHUMID")
{
 _RegHumId = XCode.Common.Helper.ConvertToGuid(value);return;
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