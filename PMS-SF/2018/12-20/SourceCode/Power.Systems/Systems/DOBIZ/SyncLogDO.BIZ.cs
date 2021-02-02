 
 
 using    System;
 using System.Collections.Generic;
 using System.Text; 
 using XCode.Attributes    ;

 namespace  Power.Systems.Systems
{
    /// <summary>
    /// 分布式同步日志表结构
    /// </summary>
    public class SyncLogDO : SyncLogDO<SyncLogDO>
    {

    }

	/// <summary>
    /// 分布式同步日志表结构
    /// </summary>
	  [BindEntity(KeyWord="SyncLog",EntityType = typeof(Power.Systems.Systems.SyncLogDO),Description = "分布式同步日志表结构"  )] 

	 [BindTable( "PB_SyncLog", Alias = "a",IsAttach=false,Description ="")]

	  [BindIndex(Name = "pk_PB_SyncLog", KeyType = Power.DataAccessLayer.KeyType.MainKey, Columns = "Id", TableName = "PB_SyncLog",Description="")]

    public   class SyncLogDO<TEntity> : XCode.Entity<TEntity>, XCode.IEntity where TEntity : Power.Systems.Systems.SyncLogDO<TEntity>, new()
    { 
	    #region 属性

	    
 private System.Int32 _Sequ;
 /// <summary>
 /// 
 /// </summary>
 [BindColumn(1,"a", "Sequ", "","", "NCHAR", 10,0,false, IsPrimaryKey =false ,IsIdentity =false,IsNullable =false,  Length =10 )]
 public  System.Int32 Sequ  { get { return _Sequ; } set { _Sequ = value; } }

 private System.Guid _Id;
 /// <summary>
 /// 编号
 /// </summary>
 [BindColumn(1,"a", "Id", "编号","", "NCHAR", 16,0,false, IsPrimaryKey =true ,IsIdentity =true,IsNullable =false,  Length =16 )]
 public virtual System.Guid Id  { get { return _Id; } set { _Id = value; } }

 private System.String _LogType;
 /// <summary>
 /// 日志类型：导出、导出
 /// </summary>
 [BindColumn(2,"a", "LogType", "日志类型：导出、导出","", "NCHAR", 10,0,false, IsPrimaryKey =false ,IsIdentity =false,IsNullable =true,  Length =10 )]
 public  System.String LogType  { get { return _LogType; } set { _LogType = value; } }

 private System.Int32 _LogIndext;
 /// <summary>
 /// 同步批次，每次同步，批次都会增加
 /// </summary>
 [BindColumn(3,"a", "LogIndext", "同步批次，每次同步，批次都会增加","", "NCHAR", 10,0,false, IsPrimaryKey =false ,IsIdentity =false,IsNullable =true,  Length =10 )]
 public  System.Int32 LogIndext  { get { return _LogIndext; } set { _LogIndext = value; } }

 private System.Guid _RegisterHumanId;
 /// <summary>
 /// 操作人
 /// </summary>
 [BindColumn(4,"a", "RegisterHumanId", "操作人","", "NCHAR", 16,0,false, IsPrimaryKey =false ,IsIdentity =false,IsNullable =true,  Length =16 )]
 public  System.Guid RegisterHumanId  { get { return _RegisterHumanId; } set { _RegisterHumanId = value; } }

 private System.String _RegisterHumanName;
 /// <summary>
 /// 操作人姓名
 /// </summary>
 [BindColumn(5,"a", "RegisterHumanName", "操作人姓名","", "NCHAR", 50,0,false, IsPrimaryKey =false ,IsIdentity =false,IsNullable =true,  Length =50 )]
 public  System.String RegisterHumanName  { get { return _RegisterHumanName; } set { _RegisterHumanName = value; } }

 private System.DateTime _RegisterDatetime;
 /// <summary>
 /// 操作事件
 /// </summary>
 [BindColumn(6,"a", "RegisterDatetime", "操作事件","", "NCHAR", 3,0,false, IsPrimaryKey =false ,IsIdentity =false,IsNullable =true,  Length =3 )]
 public  System.DateTime RegisterDatetime  { get { return _RegisterDatetime; } set { _RegisterDatetime = value; } }

 private System.String _Message;
 /// <summary>
 /// 操作记录：导入\导出KeyWord成功N条||导入\导出KeyWord失败\开始对服务器AA进行操作\完成对服务器AA今昔操作
 /// </summary>
 [BindColumn(7,"a", "Message", "操作记录：导入\导出KeyWord成功N条||导入\导出KeyWord失败\开始对服务器AA进行操作\完成对服务器AA今昔操作","", "NCHAR", 2000,0,false, IsPrimaryKey =false ,IsIdentity =false,IsNullable =true,  Length =2000 )]
 public  System.String Message  { get { return _Message; } set { _Message = value; } }

 private System.String _KeyWord;
 /// <summary>
 /// 当前同步的是哪个KeyWord
 /// </summary>
 [BindColumn(8,"a", "KeyWord", "当前同步的是哪个KeyWord","", "NCHAR", 50,0,false, IsPrimaryKey =false ,IsIdentity =false,IsNullable =true,  Length =50 )]
 public  System.String KeyWord  { get { return _KeyWord; } set { _KeyWord = value; } }

 private System.String _ServerToken;
 /// <summary>
 /// 当前操作的服务器
 /// </summary>
 [BindColumn(9,"a", "ServerToken", "当前操作的服务器","", "NCHAR", 50,0,false, IsPrimaryKey =false ,IsIdentity =false,IsNullable =true,  Length =50 )]
 public  System.String ServerToken  { get { return _ServerToken; } set { _ServerToken = value; } }

      
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
			    if (name == "SEQU")
{
return _Sequ;
}
if (name == "ID")
{
return _Id;
}
if (name == "LOGTYPE")
{
return _LogType;
}
if (name == "LOGINDEXT")
{
return _LogIndext;
}
if (name == "REGISTERHUMANID")
{
return _RegisterHumanId;
}
if (name == "REGISTERHUMANNAME")
{
return _RegisterHumanName;
}
if (name == "REGISTERDATETIME")
{
return _RegisterDatetime;
}
if (name == "MESSAGE")
{
return _Message;
}
if (name == "KEYWORD")
{
return _KeyWord;
}
if (name == "SERVERTOKEN")
{
return _ServerToken;
}

			    return base[name];
			}
			set 
			{
			   name = name.ToUpper();
			       if (name == "SEQU")
{
 _Sequ = System.Convert.ToInt32(value);return;
}
if (name == "ID")
{
 _Id = XCode.Common.Helper.ConvertToGuid(value);return;
}
if (name == "LOGTYPE")
{
 _LogType = System.Convert.ToString(value);return;
}
if (name == "LOGINDEXT")
{
 _LogIndext = System.Convert.ToInt32(value);return;
}
if (name == "REGISTERHUMANID")
{
 _RegisterHumanId = XCode.Common.Helper.ConvertToGuid(value);return;
}
if (name == "REGISTERHUMANNAME")
{
 _RegisterHumanName = System.Convert.ToString(value);return;
}
if (name == "REGISTERDATETIME")
{
 if (value == null || value.ToString().IsNullOrEmpty() == true) value = DateTime.MinValue;
 _RegisterDatetime = System.Convert.ToDateTime(value);return;
}
if (name == "MESSAGE")
{
 _Message = System.Convert.ToString(value);return;
}
if (name == "KEYWORD")
{
 _KeyWord = System.Convert.ToString(value);return;
}
if (name == "SERVERTOKEN")
{
 _ServerToken = System.Convert.ToString(value);return;
}

			    base[name] = value;
			}
		}
		#endregion
	}
}