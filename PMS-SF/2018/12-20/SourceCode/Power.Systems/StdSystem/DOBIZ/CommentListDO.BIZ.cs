 
 
 using    System;
 using System.Collections.Generic;
 using System.Text; 
 using XCode.Attributes    ;

 namespace  Power.Systems.StdSystem
{
    /// <summary>
    /// 表单评论指定通知人
    /// </summary>
    public class CommentListDO : CommentListDO<CommentListDO>
    {

    }

	/// <summary>
    /// 表单评论指定通知人
    /// </summary>
	  [BindEntity(KeyWord="CommentList",EntityType = typeof(Power.Systems.StdSystem.CommentListDO),Description = "表单评论指定通知人"  )] 

	 [BindTable( "PB_CommentList", Alias = "a",IsAttach=false,Description ="")]

	  [BindIndex(Name = "pk_PB_CommentList", KeyType = Power.DataAccessLayer.KeyType.MainKey, Columns = "Id", TableName = "PB_CommentList",Description="")]

    public   class CommentListDO<TEntity> : XCode.Entity<TEntity>, XCode.IEntity where TEntity : Power.Systems.StdSystem.CommentListDO<TEntity>, new()
    { 
	    #region 属性

	    
 private System.Guid _Id;
 /// <summary>
 /// 主键
 /// </summary>
 [BindColumn(1,"a", "Id", "主键","", "NCHAR", 16,0,false, IsPrimaryKey =true ,IsIdentity =true,IsNullable =false,  Length =16 )]
 public virtual System.Guid Id  { get { return _Id; } set { _Id = value; } }

 private System.Guid _CommentId;
 /// <summary>
 /// 评论主键
 /// </summary>
 [BindColumn(2,"a", "CommentId", "评论主键","", "NCHAR", 16,0,false, IsPrimaryKey =false ,IsIdentity =false,IsNullable =false,  Length =16 )]
 public  System.Guid CommentId  { get { return _CommentId; } set { _CommentId = value; } }

 private System.Int32 _Sequ;
 /// <summary>
 /// 序号
 /// </summary>
 [BindColumn(3,"a", "Sequ", "序号","", "NCHAR", 10,0,false, IsPrimaryKey =false ,IsIdentity =false,IsNullable =false,  Length =10 )]
 public  System.Int32 Sequ  { get { return _Sequ; } set { _Sequ = value; } }

 private System.Guid _HumanId;
 /// <summary>
 /// 待通知人id
 /// </summary>
 [BindColumn(4,"a", "HumanId", "待通知人id","", "NCHAR", 16,0,false, IsPrimaryKey =false ,IsIdentity =false,IsNullable =false,  Length =16 )]
 public  System.Guid HumanId  { get { return _HumanId; } set { _HumanId = value; } }

 private System.String _HumanName;
 /// <summary>
 /// 待通知人名称
 /// </summary>
 [BindColumn(5,"a", "HumanName", "待通知人名称","", "NCHAR", 80,0,false, IsPrimaryKey =false ,IsIdentity =false,IsNullable =true,  Length =80 )]
 public  System.String HumanName  { get { return _HumanName; } set { _HumanName = value; } }

      
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
if (name == "COMMENTID")
{
return _CommentId;
}
if (name == "SEQU")
{
return _Sequ;
}
if (name == "HUMANID")
{
return _HumanId;
}
if (name == "HUMANNAME")
{
return _HumanName;
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
if (name == "COMMENTID")
{
 _CommentId = XCode.Common.Helper.ConvertToGuid(value);return;
}
if (name == "SEQU")
{
 _Sequ = System.Convert.ToInt32(value);return;
}
if (name == "HUMANID")
{
 _HumanId = XCode.Common.Helper.ConvertToGuid(value);return;
}
if (name == "HUMANNAME")
{
 _HumanName = System.Convert.ToString(value);return;
}

			    base[name] = value;
			}
		}
		#endregion
	}
}