 
 
 using    System;
 using System.Collections.Generic;
 using System.Text; 
 using XCode.Attributes    ;

 namespace  Power.Systems.StdMarket.StdMarket
{
    /// <summary>
    /// 参与报价人员
    /// </summary>
    public class PS_BidPlan_QuoteHumanDO : PS_BidPlan_QuoteHumanDO<PS_BidPlan_QuoteHumanDO>
    {

    }

	/// <summary>
    /// 参与报价人员
    /// </summary>
	  [BindEntity(KeyWord="PS_BidPlan_QuoteHuman",EntityType = typeof(Power.Systems.StdMarket.StdMarket.PS_BidPlan_QuoteHumanDO),Description = "参与报价人员"  )] 

	 [BindTable( "PS_MK_BidPlan_QuoteHuman", Alias = "a",IsAttach=false,Description ="")]

	  [BindIndex(Name = "pk_PS_MK_BidPlan_QuoteHuman", KeyType = Power.DataAccessLayer.KeyType.MainKey, Columns = "Id", TableName = "PS_MK_BidPlan_QuoteHuman",Description="")]

    public   class PS_BidPlan_QuoteHumanDO<TEntity> : XCode.Entity<TEntity>, XCode.IEntity where TEntity : Power.Systems.StdMarket.StdMarket.PS_BidPlan_QuoteHumanDO<TEntity>, new()
    { 
	    #region 属性

	    
 private System.Guid _Id;
 /// <summary>
 /// 
 /// </summary>
 [BindColumn(1,"a", "Id", "","", "NCHAR", 16,0,false, IsPrimaryKey =true ,IsIdentity =true,IsNullable =false,  Length =16 )]
 public virtual System.Guid Id  { get { return _Id; } set { _Id = value; } }

 private System.DateTime _UpdDate;
 /// <summary>
 /// 
 /// </summary>
 [BindColumn(1,"a", "UpdDate", "","", "NCHAR", 0,0,false, IsPrimaryKey =false ,IsIdentity =false,IsNullable =true,  Length =0 )]
 public  System.DateTime UpdDate  { get { return _UpdDate; } set { _UpdDate = value; } }

 private System.Guid _MasterId;
 /// <summary>
 /// 
 /// </summary>
 [BindColumn(2,"a", "MasterId", "","", "NCHAR", 16,0,false, IsPrimaryKey =false ,IsIdentity =false,IsNullable =true,  Length =16 )]
 public  System.Guid MasterId  { get { return _MasterId; } set { _MasterId = value; } }

 private System.String _Major;
 /// <summary>
 /// 专业
 /// </summary>
 [BindColumn(3,"a", "Major", "专业","", "NCHAR", 50,0,false, IsPrimaryKey =false ,IsIdentity =false,IsNullable =true,  Length =50 )]
 public  System.String Major  { get { return _Major; } set { _Major = value; } }

 private System.Guid _MajorId;
 /// <summary>
 /// 
 /// </summary>
 [BindColumn(4,"a", "MajorId", "","", "NCHAR", 16,0,false, IsPrimaryKey =false ,IsIdentity =false,IsNullable =true,  Length =16 )]
 public  System.Guid MajorId  { get { return _MajorId; } set { _MajorId = value; } }

 private System.String _HumanName;
 /// <summary>
 /// 姓名
 /// </summary>
 [BindColumn(5,"a", "HumanName", "姓名","", "NCHAR", 50,0,false, IsPrimaryKey =false ,IsIdentity =false,IsNullable =true,  Length =50 )]
 public  System.String HumanName  { get { return _HumanName; } set { _HumanName = value; } }

 private System.Guid _HumanNameId;
 /// <summary>
 /// 
 /// </summary>
 [BindColumn(6,"a", "HumanNameId", "","", "NCHAR", 16,0,false, IsPrimaryKey =false ,IsIdentity =false,IsNullable =true,  Length =16 )]
 public  System.Guid HumanNameId  { get { return _HumanNameId; } set { _HumanNameId = value; } }

 private System.String _Dept;
 /// <summary>
 /// 部门
 /// </summary>
 [BindColumn(7,"a", "Dept", "部门","", "NCHAR", 50,0,false, IsPrimaryKey =false ,IsIdentity =false,IsNullable =true,  Length =50 )]
 public  System.String Dept  { get { return _Dept; } set { _Dept = value; } }

 private System.Guid _DeptId;
 /// <summary>
 /// 
 /// </summary>
 [BindColumn(8,"a", "DeptId", "","", "NCHAR", 16,0,false, IsPrimaryKey =false ,IsIdentity =false,IsNullable =true,  Length =16 )]
 public  System.Guid DeptId  { get { return _DeptId; } set { _DeptId = value; } }

      
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
if (name == "UPDDATE")
{
return _UpdDate;
}
if (name == "MASTERID")
{
return _MasterId;
}
if (name == "MAJOR")
{
return _Major;
}
if (name == "MAJORID")
{
return _MajorId;
}
if (name == "HUMANNAME")
{
return _HumanName;
}
if (name == "HUMANNAMEID")
{
return _HumanNameId;
}
if (name == "DEPT")
{
return _Dept;
}
if (name == "DEPTID")
{
return _DeptId;
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
if (name == "UPDDATE")
{
 if (value == null || value.ToString().IsNullOrEmpty() == true) value = DateTime.MinValue;
 _UpdDate = System.Convert.ToDateTime(value);return;
}
if (name == "MASTERID")
{
 _MasterId = XCode.Common.Helper.ConvertToGuid(value);return;
}
if (name == "MAJOR")
{
 _Major = System.Convert.ToString(value);return;
}
if (name == "MAJORID")
{
 _MajorId = XCode.Common.Helper.ConvertToGuid(value);return;
}
if (name == "HUMANNAME")
{
 _HumanName = System.Convert.ToString(value);return;
}
if (name == "HUMANNAMEID")
{
 _HumanNameId = XCode.Common.Helper.ConvertToGuid(value);return;
}
if (name == "DEPT")
{
 _Dept = System.Convert.ToString(value);return;
}
if (name == "DEPTID")
{
 _DeptId = XCode.Common.Helper.ConvertToGuid(value);return;
}

			    base[name] = value;
			}
		}
		#endregion
	}
}