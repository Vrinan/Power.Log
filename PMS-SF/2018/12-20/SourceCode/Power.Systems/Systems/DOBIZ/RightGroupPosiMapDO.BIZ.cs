 
 
 using    System;
 using System.Collections.Generic;
 using System.Text; 
 using XCode.Attributes    ;

 namespace  Power.Systems.Systems
{
    /// <summary>
    /// 岗位、权限组关系表
    /// </summary>
    public class RightGroupPosiMapDO : RightGroupPosiMapDO<RightGroupPosiMapDO>
    {

    }

	/// <summary>
    /// 岗位、权限组关系表
    /// </summary>
	  [BindEntity(KeyWord="RightGroupPosiMap",EntityType = typeof(Power.Systems.Systems.RightGroupPosiMapDO),Description = "岗位、权限组关系表"  )] 

	 [BindTable( "PB_RightGroupPosiMap", Alias = "a",IsAttach=false,Description ="")]

	  [BindIndex(Name = "pk_PB_RightGroupPosiMap", KeyType = Power.DataAccessLayer.KeyType.MainKey, Columns = "Id", TableName = "PB_RightGroupPosiMap",Description="")]

    public   class RightGroupPosiMapDO<TEntity> : XCode.Entity<TEntity>, XCode.IEntity where TEntity : Power.Systems.Systems.RightGroupPosiMapDO<TEntity>, new()
    { 
	    #region 属性

	    
 private System.Guid _Id;
 /// <summary>
 /// 主键
 /// </summary>
 [BindColumn(1,"a", "Id", "主键","", "NCHAR", 16,0,false, IsPrimaryKey =true ,IsIdentity =true,IsNullable =false,  Length =16 )]
 public virtual System.Guid Id  { get { return _Id; } set { _Id = value; } }

 private System.Guid _PositionId;
 /// <summary>
 /// 岗位Id
 /// </summary>
 [BindColumn(2,"a", "PositionId", "岗位Id","", "NCHAR", 16,0,false, IsPrimaryKey =false ,IsIdentity =false,IsNullable =false,  Length =16 )]
 public  System.Guid PositionId  { get { return _PositionId; } set { _PositionId = value; } }

 private System.Guid _RightGroupId;
 /// <summary>
 /// 权限组Id
 /// </summary>
 [BindColumn(3,"a", "RightGroupId", "权限组Id","", "NCHAR", 16,0,false, IsPrimaryKey =false ,IsIdentity =false,IsNullable =false,  Length =16 )]
 public  System.Guid RightGroupId  { get { return _RightGroupId; } set { _RightGroupId = value; } }

      
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
if (name == "POSITIONID")
{
return _PositionId;
}
if (name == "RIGHTGROUPID")
{
return _RightGroupId;
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
if (name == "POSITIONID")
{
 _PositionId = XCode.Common.Helper.ConvertToGuid(value);return;
}
if (name == "RIGHTGROUPID")
{
 _RightGroupId = XCode.Common.Helper.ConvertToGuid(value);return;
}

			    base[name] = value;
			}
		}
		#endregion
	}
}