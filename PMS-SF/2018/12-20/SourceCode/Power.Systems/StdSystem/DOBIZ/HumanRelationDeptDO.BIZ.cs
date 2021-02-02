 
 
 using    System;
 using System.Collections.Generic;
 using System.Text; 
 using XCode.Attributes    ;

 namespace  Power.Systems.StdSystem
{
    /// <summary>
    /// 人员关系部门
    /// </summary>
    public class HumanRelationDeptDO : HumanRelationDeptDO<HumanRelationDeptDO>
    {

    }

	/// <summary>
    /// 人员关系部门
    /// </summary>
	  [BindEntity(KeyWord="HumanRelationDept",EntityType = typeof(Power.Systems.StdSystem.HumanRelationDeptDO),Description = "人员关系部门"  )] 

	 [BindTable( "PB_HumanRelation", Alias = "a",IsAttach=false,Description ="")]

	  [BindIndex(Name = "pk_PB_HumanRelation", KeyType = Power.DataAccessLayer.KeyType.MainKey, Columns = "Id", TableName = "PB_HumanRelation",Description="")]

    public   class HumanRelationDeptDO<TEntity> : XCode.Entity<TEntity>, XCode.IEntity where TEntity : Power.Systems.StdSystem.HumanRelationDeptDO<TEntity>, new()
    { 
	    #region 属性

	    
 private System.Guid _Id;
 /// <summary>
 /// 
 /// </summary>
 [BindColumn(1,"a", "Id", "","", "NCHAR", 16,0,false, IsPrimaryKey =true ,IsIdentity =true,IsNullable =false,  Length =16 )]
 public virtual System.Guid Id  { get { return _Id; } set { _Id = value; } }

 private System.Guid _HumanId;
 /// <summary>
 /// 人员Id
 /// </summary>
 [BindColumn(2,"a", "HumanId", "人员Id","", "NCHAR", 16,0,false, IsPrimaryKey =false ,IsIdentity =false,IsNullable =false,  Length =16 )]
 public  System.Guid HumanId  { get { return _HumanId; } set { _HumanId = value; } }

 private System.SByte _RelationType;
 /// <summary>
 /// 组织类型，0业务域，1单位，2部门，3岗位
 /// </summary>
 [BindColumn(3,"a", "RelationType", "组织类型，0业务域，1单位，2部门，3岗位","", "NCHAR", 3,0,false, IsPrimaryKey =false ,IsIdentity =false,IsNullable =false,  Length =3 )]
 public  System.SByte RelationType  { get { return _RelationType; } set { _RelationType = value; } }

 private System.Guid _RelationId;
 /// <summary>
 /// 部门/岗位 id
 /// </summary>
 [BindColumn(4,"a", "RelationId", "部门/岗位 id","", "NCHAR", 16,0,false, IsPrimaryKey =false ,IsIdentity =false,IsNullable =false,  Length =16 )]
 public  System.Guid RelationId  { get { return _RelationId; } set { _RelationId = value; } }

 private System.SByte _Actived;
 /// <summary>
 /// true有效，false无效
 /// </summary>
 [BindColumn(5,"a", "Actived", "true有效，false无效","", "NCHAR", 3,0,false, IsPrimaryKey =false ,IsIdentity =false,IsNullable =false,  Length =3 )]
 public  System.SByte Actived  { get { return _Actived; } set { _Actived = value; } }

 private System.SByte _IsMain;
 /// <summary>
 /// 1表示 主部门/岗位，0反之
 /// </summary>
 [BindColumn(6,"a", "IsMain", "1表示 主部门/岗位，0反之","", "NCHAR", 3,0,false, IsPrimaryKey =false ,IsIdentity =false,IsNullable =false,  Length =3 )]
 public  System.SByte IsMain  { get { return _IsMain; } set { _IsMain = value; } }

 private System.Int32 _Sequ;
 /// <summary>
 /// 序号
 /// </summary>
 [BindColumn(7,"a", "Sequ", "序号","", "NCHAR", 10,0,false, IsPrimaryKey =false ,IsIdentity =false,IsNullable =true,  Length =10 )]
 public  System.Int32 Sequ  { get { return _Sequ; } set { _Sequ = value; } }

 private System.Int32 _AllocationType;
 /// <summary>
 /// 调拨类型：0临时调入，1正式调入
 /// </summary>
 [BindColumn(8,"a", "AllocationType", "调拨类型：0临时调入，1正式调入","", "NCHAR", 10,0,false, IsPrimaryKey =false ,IsIdentity =false,IsNullable =true,  Length =10 )]
 public  System.Int32 AllocationType  { get { return _AllocationType; } set { _AllocationType = value; } }

      
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
if (name == "HUMANID")
{
return _HumanId;
}
if (name == "RELATIONTYPE")
{
return _RelationType;
}
if (name == "RELATIONID")
{
return _RelationId;
}
if (name == "ACTIVED")
{
return _Actived;
}
if (name == "ISMAIN")
{
return _IsMain;
}
if (name == "SEQU")
{
return _Sequ;
}
if (name == "ALLOCATIONTYPE")
{
return _AllocationType;
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
if (name == "HUMANID")
{
 _HumanId = XCode.Common.Helper.ConvertToGuid(value);return;
}
if (name == "RELATIONTYPE")
{
 _RelationType = System.Convert.ToSByte(value);return;
}
if (name == "RELATIONID")
{
 _RelationId = XCode.Common.Helper.ConvertToGuid(value);return;
}
if (name == "ACTIVED")
{
 _Actived = System.Convert.ToSByte(value);return;
}
if (name == "ISMAIN")
{
 _IsMain = System.Convert.ToSByte(value);return;
}
if (name == "SEQU")
{
 _Sequ = System.Convert.ToInt32(value);return;
}
if (name == "ALLOCATIONTYPE")
{
 _AllocationType = System.Convert.ToInt32(value);return;
}

			    base[name] = value;
			}
		}
		#endregion
	}
}