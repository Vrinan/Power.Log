 
 
 using    System;
 using System.Collections.Generic;
 using System.Text; 
 using XCode.Attributes    ;

 namespace  Power.Systems.StdSystem
{
    /// <summary>
    /// 计划与业务关联表
    /// </summary>
    public class PS_TaskRecLinkDO : PS_TaskRecLinkDO<PS_TaskRecLinkDO>
    {

    }

	/// <summary>
    /// 计划与业务关联表
    /// </summary>
	  [BindEntity(KeyWord="PS_TaskRecLink",EntityType = typeof(Power.Systems.StdSystem.PS_TaskRecLinkDO),Description = "计划与业务关联表"  )] 

	 [BindTable( "PS_TaskRecLink", Alias = "a",IsAttach=false,Description ="")]

	  [BindIndex(Name = "pk_PS_TaskRecLink", KeyType = Power.DataAccessLayer.KeyType.MainKey, Columns = "Id", TableName = "PS_TaskRecLink",Description="")]

    public   class PS_TaskRecLinkDO<TEntity> : XCode.Entity<TEntity>, XCode.IEntity where TEntity : Power.Systems.StdSystem.PS_TaskRecLinkDO<TEntity>, new()
    { 
	    #region 属性

	    
 private System.Guid _Id;
 /// <summary>
 /// 
 /// </summary>
 [BindColumn(1,"a", "Id", "","", "NCHAR", 16,0,false, IsPrimaryKey =true ,IsIdentity =true,IsNullable =false,  Length =16 )]
 public virtual System.Guid Id  { get { return _Id; } set { _Id = value; } }

 private System.String _LinkType;
 /// <summary>
 /// task,proc
 /// </summary>
 [BindColumn(2,"a", "LinkType", "task,proc","", "NCHAR", 10,0,false, IsPrimaryKey =false ,IsIdentity =false,IsNullable =true,  Length =10 )]
 public  System.String LinkType  { get { return _LinkType; } set { _LinkType = value; } }

 private System.Guid _TaskGuid;
 /// <summary>
 /// 作业主键
 /// </summary>
 [BindColumn(3,"a", "TaskGuid", "作业主键","", "NCHAR", 16,0,false, IsPrimaryKey =false ,IsIdentity =false,IsNullable =true,  Length =16 )]
 public  System.Guid TaskGuid  { get { return _TaskGuid; } set { _TaskGuid = value; } }

 private System.String _TaskRecKeyWord;
 /// <summary>
 /// 作业关联业务keyword
 /// </summary>
 [BindColumn(4,"a", "TaskRecKeyWord", "作业关联业务keyword","", "NCHAR", 100,0,false, IsPrimaryKey =false ,IsIdentity =false,IsNullable =true,  Length =100 )]
 public  System.String TaskRecKeyWord  { get { return _TaskRecKeyWord; } set { _TaskRecKeyWord = value; } }

 private System.Guid _TaskRecKeyValue;
 /// <summary>
 /// 作业管理业务KeyValue
 /// </summary>
 [BindColumn(5,"a", "TaskRecKeyValue", "作业管理业务KeyValue","", "NCHAR", 16,0,false, IsPrimaryKey =false ,IsIdentity =false,IsNullable =true,  Length =16 )]
 public  System.Guid TaskRecKeyValue  { get { return _TaskRecKeyValue; } set { _TaskRecKeyValue = value; } }

 private System.Guid _ProcGuid;
 /// <summary>
 /// 步骤主键
 /// </summary>
 [BindColumn(6,"a", "ProcGuid", "步骤主键","", "NCHAR", 16,0,false, IsPrimaryKey =false ,IsIdentity =false,IsNullable =true,  Length =16 )]
 public  System.Guid ProcGuid  { get { return _ProcGuid; } set { _ProcGuid = value; } }

 private System.String _ProcRecKeyWord;
 /// <summary>
 /// 步骤关联业务Keyword
 /// </summary>
 [BindColumn(7,"a", "ProcRecKeyWord", "步骤关联业务Keyword","", "NCHAR", 100,0,false, IsPrimaryKey =false ,IsIdentity =false,IsNullable =true,  Length =100 )]
 public  System.String ProcRecKeyWord  { get { return _ProcRecKeyWord; } set { _ProcRecKeyWord = value; } }

 private System.Guid _ProcRecKeyValue;
 /// <summary>
 /// 步骤关联业务KeyValue
 /// </summary>
 [BindColumn(8,"a", "ProcRecKeyValue", "步骤关联业务KeyValue","", "NCHAR", 16,0,false, IsPrimaryKey =false ,IsIdentity =false,IsNullable =true,  Length =16 )]
 public  System.Guid ProcRecKeyValue  { get { return _ProcRecKeyValue; } set { _ProcRecKeyValue = value; } }

 private System.Int32 _IsDefault;
 /// <summary>
 /// 是否默认值i
 /// </summary>
 [BindColumn(9,"a", "IsDefault", "是否默认值i","", "NCHAR", 10,0,false, IsPrimaryKey =false ,IsIdentity =false,IsNullable =true,  Length =10 )]
 public  System.Int32 IsDefault  { get { return _IsDefault; } set { _IsDefault = value; } }

 private System.DateTime _UpdDate;
 /// <summary>
 /// 
 /// </summary>
 [BindColumn(10,"a", "UpdDate", "","", "NCHAR", 3,0,false, IsPrimaryKey =false ,IsIdentity =false,IsNullable =true,  Length =3 )]
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
			    if (name == "ID")
{
return _Id;
}
if (name == "LINKTYPE")
{
return _LinkType;
}
if (name == "TASKGUID")
{
return _TaskGuid;
}
if (name == "TASKRECKEYWORD")
{
return _TaskRecKeyWord;
}
if (name == "TASKRECKEYVALUE")
{
return _TaskRecKeyValue;
}
if (name == "PROCGUID")
{
return _ProcGuid;
}
if (name == "PROCRECKEYWORD")
{
return _ProcRecKeyWord;
}
if (name == "PROCRECKEYVALUE")
{
return _ProcRecKeyValue;
}
if (name == "ISDEFAULT")
{
return _IsDefault;
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
			       if (name == "ID")
{
 _Id = XCode.Common.Helper.ConvertToGuid(value);return;
}
if (name == "LINKTYPE")
{
 _LinkType = System.Convert.ToString(value);return;
}
if (name == "TASKGUID")
{
 _TaskGuid = XCode.Common.Helper.ConvertToGuid(value);return;
}
if (name == "TASKRECKEYWORD")
{
 _TaskRecKeyWord = System.Convert.ToString(value);return;
}
if (name == "TASKRECKEYVALUE")
{
 _TaskRecKeyValue = XCode.Common.Helper.ConvertToGuid(value);return;
}
if (name == "PROCGUID")
{
 _ProcGuid = XCode.Common.Helper.ConvertToGuid(value);return;
}
if (name == "PROCRECKEYWORD")
{
 _ProcRecKeyWord = System.Convert.ToString(value);return;
}
if (name == "PROCRECKEYVALUE")
{
 _ProcRecKeyValue = XCode.Common.Helper.ConvertToGuid(value);return;
}
if (name == "ISDEFAULT")
{
 _IsDefault = System.Convert.ToInt32(value);return;
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