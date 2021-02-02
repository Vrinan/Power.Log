 
 
 using    System;
 using System.Collections.Generic;
 using System.Text; 
 using XCode.Attributes    ;

 namespace  Power.Systems.StdSystem
{
    /// <summary>
    /// EPS IT管理员
    /// </summary>
    public class EPSITAdminDO : EPSITAdminDO<EPSITAdminDO>
    {

    }

	/// <summary>
    /// EPS IT管理员
    /// </summary>
	  [BindEntity(KeyWord="EPSITAdmin",EntityType = typeof(Power.Systems.StdSystem.EPSITAdminDO),Description = "EPS IT管理员"  )] 

	 [BindTable( "PB_EPSITAdmin", Alias = "a",IsAttach=false,Description ="")]

	  [BindIndex(Name = "pk_PB_EPSITAdmin", KeyType = Power.DataAccessLayer.KeyType.MainKey, Columns = "Id", TableName = "PB_EPSITAdmin",Description="")]

    public   class EPSITAdminDO<TEntity> : XCode.Entity<TEntity>, XCode.IEntity where TEntity : Power.Systems.StdSystem.EPSITAdminDO<TEntity>, new()
    { 
	    #region 属性

	    
 private System.Guid _Id;
 /// <summary>
 /// 
 /// </summary>
 [BindColumn(1,"a", "Id", "","", "NCHAR", 16,0,false, IsPrimaryKey =true ,IsIdentity =true,IsNullable =false,  Length =16 )]
 public virtual System.Guid Id  { get { return _Id; } set { _Id = value; } }

 private System.Guid _EpsProjId;
 /// <summary>
 /// EPS/Proj节点Id
 /// </summary>
 [BindColumn(2,"a", "EpsProjId", "EPS/Proj节点Id","", "NCHAR", 16,0,false, IsPrimaryKey =false ,IsIdentity =false,IsNullable =true,  Length =16 )]
 public  System.Guid EpsProjId  { get { return _EpsProjId; } set { _EpsProjId = value; } }

 private System.Guid _UserId;
 /// <summary>
 /// 用户Id
 /// </summary>
 [BindColumn(3,"a", "UserId", "用户Id","", "NCHAR", 16,0,false, IsPrimaryKey =false ,IsIdentity =false,IsNullable =true,  Length =16 )]
 public  System.Guid UserId  { get { return _UserId; } set { _UserId = value; } }

 private System.String _UserCode;
 /// <summary>
 /// 用户账号
 /// </summary>
 [BindColumn(4,"a", "UserCode", "用户账号","", "NCHAR", 50,0,false, IsPrimaryKey =false ,IsIdentity =false,IsNullable =true,  Length =50 )]
 public  System.String UserCode  { get { return _UserCode; } set { _UserCode = value; } }

 private System.String _UserName;
 /// <summary>
 /// 用户名称
 /// </summary>
 [BindColumn(5,"a", "UserName", "用户名称","", "NCHAR", 80,0,false, IsPrimaryKey =false ,IsIdentity =false,IsNullable =true,  Length =80 )]
 public  System.String UserName  { get { return _UserName; } set { _UserName = value; } }

      
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
if (name == "EPSPROJID")
{
return _EpsProjId;
}
if (name == "USERID")
{
return _UserId;
}
if (name == "USERCODE")
{
return _UserCode;
}
if (name == "USERNAME")
{
return _UserName;
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
if (name == "EPSPROJID")
{
 _EpsProjId = XCode.Common.Helper.ConvertToGuid(value);return;
}
if (name == "USERID")
{
 _UserId = XCode.Common.Helper.ConvertToGuid(value);return;
}
if (name == "USERCODE")
{
 _UserCode = System.Convert.ToString(value);return;
}
if (name == "USERNAME")
{
 _UserName = System.Convert.ToString(value);return;
}

			    base[name] = value;
			}
		}
		#endregion
	}
}