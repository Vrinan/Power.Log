 
 
 using    System;
 using System.Collections.Generic;
 using System.Text; 
 using XCode.Attributes    ;

 namespace  Power.Systems.StdSystem
{
    /// <summary>
    /// APP聊天分组子表
    /// </summary>
    public class PB_ChartsListDO : PB_ChartsListDO<PB_ChartsListDO>
    {

    }

	/// <summary>
    /// APP聊天分组子表
    /// </summary>
	  [BindEntity(KeyWord="PB_ChartsList",EntityType = typeof(Power.Systems.StdSystem.PB_ChartsListDO),Description = "APP聊天分组子表"  )] 

	 [BindTable( "PB_ChartsList", Alias = "a",IsAttach=false,Description ="")]

	  [BindIndex(Name = "pk_PB_ChartsList", KeyType = Power.DataAccessLayer.KeyType.MainKey, Columns = "Id", TableName = "PB_ChartsList",Description="")]

    public   class PB_ChartsListDO<TEntity> : XCode.Entity<TEntity>, XCode.IEntity where TEntity : Power.Systems.StdSystem.PB_ChartsListDO<TEntity>, new()
    { 
	    #region 属性

	    
 private System.Guid _Id;
 /// <summary>
 /// 
 /// </summary>
 [BindColumn(1,"a", "Id", "","", "NCHAR", 16,0,false, IsPrimaryKey =true ,IsIdentity =true,IsNullable =false,  Length =16 )]
 public virtual System.Guid Id  { get { return _Id; } set { _Id = value; } }

 private System.Guid _GroupId;
 /// <summary>
 /// 分组Id
 /// </summary>
 [BindColumn(2,"a", "GroupId", "分组Id","", "NCHAR", 16,0,false, IsPrimaryKey =false ,IsIdentity =false,IsNullable =true,  Length =16 )]
 public  System.Guid GroupId  { get { return _GroupId; } set { _GroupId = value; } }

 private System.Guid _HumanId;
 /// <summary>
 /// 人员Id
 /// </summary>
 [BindColumn(3,"a", "HumanId", "人员Id","", "NCHAR", 16,0,false, IsPrimaryKey =false ,IsIdentity =false,IsNullable =true,  Length =16 )]
 public  System.Guid HumanId  { get { return _HumanId; } set { _HumanId = value; } }

 private System.String _HumanCode;
 /// <summary>
 /// 人员编号
 /// </summary>
 [BindColumn(4,"a", "HumanCode", "人员编号","", "NCHAR", 200,0,false, IsPrimaryKey =false ,IsIdentity =false,IsNullable =true,  Length =200 )]
 public  System.String HumanCode  { get { return _HumanCode; } set { _HumanCode = value; } }

 private System.String _HumanName;
 /// <summary>
 /// 人员名称
 /// </summary>
 [BindColumn(5,"a", "HumanName", "人员名称","", "NCHAR", 200,0,false, IsPrimaryKey =false ,IsIdentity =false,IsNullable =true,  Length =200 )]
 public  System.String HumanName  { get { return _HumanName; } set { _HumanName = value; } }

 private System.String _HumanRemark;
 /// <summary>
 /// 人员备注名称
 /// </summary>
 [BindColumn(6,"a", "HumanRemark", "人员备注名称","", "NCHAR", 200,0,false, IsPrimaryKey =false ,IsIdentity =false,IsNullable =true,  Length =200 )]
 public  System.String HumanRemark  { get { return _HumanRemark; } set { _HumanRemark = value; } }

 private System.Int32 _IsOwner;
 /// <summary>
 /// 
 /// </summary>
 [BindColumn(7,"a", "IsOwner", "","", "NCHAR", 10,0,false, IsPrimaryKey =false ,IsIdentity =false,IsNullable =true,  Length =10 )]
 public  System.Int32 IsOwner  { get { return _IsOwner; } set { _IsOwner = value; } }

 private System.String _Memo;
 /// <summary>
 /// 备注
 /// </summary>
 [BindColumn(7,"a", "Memo", "备注","", "NCHAR", 1000,0,false, IsPrimaryKey =false ,IsIdentity =false,IsNullable =true,  Length =1000 )]
 public  System.String Memo  { get { return _Memo; } set { _Memo = value; } }

 private System.DateTime _UpdDate;
 /// <summary>
 /// 
 /// </summary>
 [BindColumn(8,"a", "UpdDate", "","", "NCHAR", 3,0,false, IsPrimaryKey =false ,IsIdentity =false,IsNullable =true,  Length =3 )]
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
if (name == "GROUPID")
{
return _GroupId;
}
if (name == "HUMANID")
{
return _HumanId;
}
if (name == "HUMANCODE")
{
return _HumanCode;
}
if (name == "HUMANNAME")
{
return _HumanName;
}
if (name == "HUMANREMARK")
{
return _HumanRemark;
}
if (name == "ISOWNER")
{
return _IsOwner;
}
if (name == "MEMO")
{
return _Memo;
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
if (name == "GROUPID")
{
 _GroupId = XCode.Common.Helper.ConvertToGuid(value);return;
}
if (name == "HUMANID")
{
 _HumanId = XCode.Common.Helper.ConvertToGuid(value);return;
}
if (name == "HUMANCODE")
{
 _HumanCode = System.Convert.ToString(value);return;
}
if (name == "HUMANNAME")
{
 _HumanName = System.Convert.ToString(value);return;
}
if (name == "HUMANREMARK")
{
 _HumanRemark = System.Convert.ToString(value);return;
}
if (name == "ISOWNER")
{
 _IsOwner = System.Convert.ToInt32(value);return;
}
if (name == "MEMO")
{
 _Memo = System.Convert.ToString(value);return;
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