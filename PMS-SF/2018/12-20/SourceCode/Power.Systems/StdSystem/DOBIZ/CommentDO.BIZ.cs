 
 
 using    System;
 using System.Collections.Generic;
 using System.Text; 
 using XCode.Attributes    ;

 namespace  Power.Systems.StdSystem
{
    /// <summary>
    /// 表单评论
    /// </summary>
    public class CommentDO : CommentDO<CommentDO>
    {

    }

	/// <summary>
    /// 表单评论
    /// </summary>
	  [BindEntity(KeyWord="Comment",EntityType = typeof(Power.Systems.StdSystem.CommentDO),Description = "表单评论"  )] 

	 [BindTable( "PB_Comment", Alias = "a",IsAttach=false,Description ="")]

	  [BindIndex(Name = "pk_PB_Comment", KeyType = Power.DataAccessLayer.KeyType.MainKey, Columns = "Id", TableName = "PB_Comment",Description="")]

    public   class CommentDO<TEntity> : XCode.Entity<TEntity>, XCode.IEntity where TEntity : Power.Systems.StdSystem.CommentDO<TEntity>, new()
    { 
	    #region 属性

	    
 private System.Guid _Id;
 /// <summary>
 /// 主键
 /// </summary>
 [BindColumn(1,"a", "Id", "主键","", "NCHAR", 16,0,false, IsPrimaryKey =true ,IsIdentity =true,IsNullable =false,  Length =16 )]
 public virtual System.Guid Id  { get { return _Id; } set { _Id = value; } }

 private System.String _KeyWord;
 /// <summary>
 /// 
 /// </summary>
 [BindColumn(3,"a", "KeyWord", "","", "NCHAR", 80,0,false, IsPrimaryKey =false ,IsIdentity =false,IsNullable =false,  Length =80 )]
 public  System.String KeyWord  { get { return _KeyWord; } set { _KeyWord = value; } }

 private System.Guid _KeyValue;
 /// <summary>
 /// 
 /// </summary>
 [BindColumn(4,"a", "KeyValue", "","", "NCHAR", 16,0,false, IsPrimaryKey =false ,IsIdentity =false,IsNullable =false,  Length =16 )]
 public  System.Guid KeyValue  { get { return _KeyValue; } set { _KeyValue = value; } }

 private System.String _FormUrl;
 /// <summary>
 /// 
 /// </summary>
 [BindColumn(5,"a", "FormUrl", "","", "NCHAR", 150,0,false, IsPrimaryKey =false ,IsIdentity =false,IsNullable =false,  Length =150 )]
 public  System.String FormUrl  { get { return _FormUrl; } set { _FormUrl = value; } }

 private System.Guid _RegHumId;
 /// <summary>
 /// 发送人Id
 /// </summary>
 [BindColumn(6,"a", "RegHumId", "发送人Id","", "NCHAR", 16,0,false, IsPrimaryKey =false ,IsIdentity =false,IsNullable =false,  Length =16 )]
 public  System.Guid RegHumId  { get { return _RegHumId; } set { _RegHumId = value; } }

 private System.String _RegHumName;
 /// <summary>
 /// 发送人名称
 /// </summary>
 [BindColumn(7,"a", "RegHumName", "发送人名称","", "NCHAR", 80,0,false, IsPrimaryKey =false ,IsIdentity =false,IsNullable =true,  Length =80 )]
 public  System.String RegHumName  { get { return _RegHumName; } set { _RegHumName = value; } }

 private System.DateTime _RegDate;
 /// <summary>
 /// 
 /// </summary>
 [BindColumn(8,"a", "RegDate", "","", "NCHAR", 3,0,false, IsPrimaryKey =false ,IsIdentity =false,IsNullable =false,  Length =3 )]
 public  System.DateTime RegDate  { get { return _RegDate; } set { _RegDate = value; } }

 private System.String _CommentText;
 /// <summary>
 /// 发送内容
 /// </summary>
 [BindColumn(9,"a", "CommentText", "发送内容","", "NCHAR", -1,0,false, IsPrimaryKey =false ,IsIdentity =false,IsNullable =true,  Length =-1 )]
 public  System.String CommentText  { get { return _CommentText; } set { _CommentText = value; } }

      
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
if (name == "FORMURL")
{
return _FormUrl;
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
if (name == "COMMENTTEXT")
{
return _CommentText;
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
if (name == "FORMURL")
{
 _FormUrl = System.Convert.ToString(value);return;
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
if (name == "COMMENTTEXT")
{
 _CommentText = System.Convert.ToString(value);return;
}

			    base[name] = value;
			}
		}
		#endregion
	}
}