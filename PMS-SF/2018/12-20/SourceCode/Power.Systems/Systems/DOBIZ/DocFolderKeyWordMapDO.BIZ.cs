 
 
 using    System;
 using System.Collections.Generic;
 using System.Text; 
 using XCode.Attributes    ;

 namespace  Power.Systems.Systems
{
    /// <summary>
    /// 文档分类KeyWord对应表
    /// </summary>
    public class DocFolderKeyWordMapDO : DocFolderKeyWordMapDO<DocFolderKeyWordMapDO>
    {

    }

	/// <summary>
    /// 文档分类KeyWord对应表
    /// </summary>
	  [BindEntity(KeyWord="DocFolderKeyWordMap",EntityType = typeof(Power.Systems.Systems.DocFolderKeyWordMapDO),Description = "文档分类KeyWord对应表"  )] 

	 [BindTable( "PB_DocFolderKeyWordMap", Alias = "a",IsAttach=false,Description ="")]

	  [BindIndex(Name = "pk_PB_DocFolderKeyWordMap", KeyType = Power.DataAccessLayer.KeyType.MainKey, Columns = "Id", TableName = "PB_DocFolderKeyWordMap",Description="")]

    public   class DocFolderKeyWordMapDO<TEntity> : XCode.Entity<TEntity>, XCode.IEntity where TEntity : Power.Systems.Systems.DocFolderKeyWordMapDO<TEntity>, new()
    { 
	    #region 属性

	    
 private System.Guid _Id;
 /// <summary>
 /// 主键
 /// </summary>
 [BindColumn(1,"a", "Id", "主键","", "NCHAR", 16,0,false, IsPrimaryKey =true ,IsIdentity =true,IsNullable =false,  Length =16 )]
 public virtual System.Guid Id  { get { return _Id; } set { _Id = value; } }

 private System.Guid _FolderId;
 /// <summary>
 /// 文档分类Id
 /// </summary>
 [BindColumn(2,"a", "FolderId", "文档分类Id","", "NCHAR", 16,0,false, IsPrimaryKey =false ,IsIdentity =false,IsNullable =false,  Length =16 )]
 public  System.Guid FolderId  { get { return _FolderId; } set { _FolderId = value; } }

 private System.String _KeyWord;
 /// <summary>
 /// 
 /// </summary>
 [BindColumn(3,"a", "KeyWord", "","", "NCHAR", 100,0,false, IsPrimaryKey =false ,IsIdentity =false,IsNullable =false,  Length =100 )]
 public  System.String KeyWord  { get { return _KeyWord; } set { _KeyWord = value; } }

 private System.String _KeyWordName;
 /// <summary>
 /// KeyWord名称
 /// </summary>
 [BindColumn(4,"a", "KeyWordName", "KeyWord名称","", "NCHAR", 200,0,false, IsPrimaryKey =false ,IsIdentity =false,IsNullable =true,  Length =200 )]
 public  System.String KeyWordName  { get { return _KeyWordName; } set { _KeyWordName = value; } }

 private System.Guid _SourceMapId;
 /// <summary>
 /// 原始复制Id
 /// </summary>
 [BindColumn(5,"a", "SourceMapId", "原始复制Id","", "NCHAR", 16,0,false, IsPrimaryKey =false ,IsIdentity =false,IsNullable =true,  Length =16 )]
 public  System.Guid SourceMapId  { get { return _SourceMapId; } set { _SourceMapId = value; } }

 private System.String _SWhere;
 /// <summary>
 /// 有效条件
 /// </summary>
 [BindColumn(6,"a", "SWhere", "有效条件","", "NCHAR", 500,0,false, IsPrimaryKey =false ,IsIdentity =false,IsNullable =true,  Length =500 )]
 public  System.String SWhere  { get { return _SWhere; } set { _SWhere = value; } }

      
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
if (name == "FOLDERID")
{
return _FolderId;
}
if (name == "KEYWORD")
{
return _KeyWord;
}
if (name == "KEYWORDNAME")
{
return _KeyWordName;
}
if (name == "SOURCEMAPID")
{
return _SourceMapId;
}
if (name == "SWHERE")
{
return _SWhere;
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
if (name == "FOLDERID")
{
 _FolderId = XCode.Common.Helper.ConvertToGuid(value);return;
}
if (name == "KEYWORD")
{
 _KeyWord = System.Convert.ToString(value);return;
}
if (name == "KEYWORDNAME")
{
 _KeyWordName = System.Convert.ToString(value);return;
}
if (name == "SOURCEMAPID")
{
 _SourceMapId = XCode.Common.Helper.ConvertToGuid(value);return;
}
if (name == "SWHERE")
{
 _SWhere = System.Convert.ToString(value);return;
}

			    base[name] = value;
			}
		}
		#endregion
	}
}