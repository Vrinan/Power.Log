 
 
 using    System;
 using System.Collections.Generic;
 using System.Text; 
 using XCode.Attributes    ;

 namespace  Power.Systems.StdMarket.StdMarket
{
    /// <summary>
    /// 资格预审资料
    /// </summary>
    public class PS_Prequalification_DtlDO : PS_Prequalification_DtlDO<PS_Prequalification_DtlDO>
    {

    }

	/// <summary>
    /// 资格预审资料
    /// </summary>
	  [BindEntity(KeyWord="PS_Prequalification_Dtl",EntityType = typeof(Power.Systems.StdMarket.StdMarket.PS_Prequalification_DtlDO),Description = "资格预审资料"  )] 

	 [BindTable( "PS_MK_Prequalification_Dtl", Alias = "a",IsAttach=false,Description ="")]

	  [BindIndex(Name = "pk_PS_MK_Prequalification_Dtl", KeyType = Power.DataAccessLayer.KeyType.MainKey, Columns = "Id", TableName = "PS_MK_Prequalification_Dtl",Description="")]

    public   class PS_Prequalification_DtlDO<TEntity> : XCode.Entity<TEntity>, XCode.IEntity where TEntity : Power.Systems.StdMarket.StdMarket.PS_Prequalification_DtlDO<TEntity>, new()
    { 
	    #region 属性

	    
 private System.Guid _Id;
 /// <summary>
 /// 主键
 /// </summary>
 [BindColumn(1,"a", "Id", "主键","", "NCHAR", 16,0,false, IsPrimaryKey =true ,IsIdentity =true,IsNullable =false,  Length =16 )]
 public virtual System.Guid Id  { get { return _Id; } set { _Id = value; } }

 private System.Guid _ParentId;
 /// <summary>
 /// 外键
 /// </summary>
 [BindColumn(2,"a", "ParentId", "外键","", "NCHAR", 16,0,false, IsPrimaryKey =false ,IsIdentity =false,IsNullable =true,  Length =16 )]
 public  System.Guid ParentId  { get { return _ParentId; } set { _ParentId = value; } }

 private System.Int32 _Sequ;
 /// <summary>
 /// 序号
 /// </summary>
 [BindColumn(3,"a", "Sequ", "序号","", "NCHAR", 10,0,false, IsPrimaryKey =false ,IsIdentity =false,IsNullable =true,  Length =10 )]
 public  System.Int32 Sequ  { get { return _Sequ; } set { _Sequ = value; } }

 private System.String _DocumentName;
 /// <summary>
 /// 资料名称
 /// </summary>
 [BindColumn(4,"a", "DocumentName", "资料名称","", "NCHAR", 500,0,false, IsPrimaryKey =false ,IsIdentity =false,IsNullable =true,  Length =500 )]
 public  System.String DocumentName  { get { return _DocumentName; } set { _DocumentName = value; } }

 private System.DateTime _DeliveryDate;
 /// <summary>
 /// 递交日期
 /// </summary>
 [BindColumn(5,"a", "DeliveryDate", "递交日期","", "NCHAR", 3,0,false, IsPrimaryKey =false ,IsIdentity =false,IsNullable =true,  Length =3 )]
 public  System.DateTime DeliveryDate  { get { return _DeliveryDate; } set { _DeliveryDate = value; } }

 private System.String _DeliveryWay;
 /// <summary>
 /// 提交方式
 /// </summary>
 [BindColumn(6,"a", "DeliveryWay", "提交方式","", "NCHAR", 50,0,false, IsPrimaryKey =false ,IsIdentity =false,IsNullable =true,  Length =50 )]
 public  System.String DeliveryWay  { get { return _DeliveryWay; } set { _DeliveryWay = value; } }

 private System.String _ReviewResult;
 /// <summary>
 /// 审查结果
 /// </summary>
 [BindColumn(7,"a", "ReviewResult", "审查结果","", "NCHAR", 50,0,false, IsPrimaryKey =false ,IsIdentity =false,IsNullable =true,  Length =50 )]
 public  System.String ReviewResult  { get { return _ReviewResult; } set { _ReviewResult = value; } }

 private System.String _Handler;
 /// <summary>
 /// 经办人
 /// </summary>
 [BindColumn(8,"a", "Handler", "经办人","", "NCHAR", 50,0,false, IsPrimaryKey =false ,IsIdentity =false,IsNullable =true,  Length =50 )]
 public  System.String Handler  { get { return _Handler; } set { _Handler = value; } }

 private System.Guid _HandlerId;
 /// <summary>
 /// 
 /// </summary>
 [BindColumn(9,"a", "HandlerId", "","", "NCHAR", 16,0,false, IsPrimaryKey =false ,IsIdentity =false,IsNullable =true,  Length =16 )]
 public  System.Guid HandlerId  { get { return _HandlerId; } set { _HandlerId = value; } }

      
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
if (name == "PARENTID")
{
return _ParentId;
}
if (name == "SEQU")
{
return _Sequ;
}
if (name == "DOCUMENTNAME")
{
return _DocumentName;
}
if (name == "DELIVERYDATE")
{
return _DeliveryDate;
}
if (name == "DELIVERYWAY")
{
return _DeliveryWay;
}
if (name == "REVIEWRESULT")
{
return _ReviewResult;
}
if (name == "HANDLER")
{
return _Handler;
}
if (name == "HANDLERID")
{
return _HandlerId;
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
if (name == "PARENTID")
{
 _ParentId = XCode.Common.Helper.ConvertToGuid(value);return;
}
if (name == "SEQU")
{
 _Sequ = System.Convert.ToInt32(value);return;
}
if (name == "DOCUMENTNAME")
{
 _DocumentName = System.Convert.ToString(value);return;
}
if (name == "DELIVERYDATE")
{
 if (value == null || value.ToString().IsNullOrEmpty() == true) value = DateTime.MinValue;
 _DeliveryDate = System.Convert.ToDateTime(value);return;
}
if (name == "DELIVERYWAY")
{
 _DeliveryWay = System.Convert.ToString(value);return;
}
if (name == "REVIEWRESULT")
{
 _ReviewResult = System.Convert.ToString(value);return;
}
if (name == "HANDLER")
{
 _Handler = System.Convert.ToString(value);return;
}
if (name == "HANDLERID")
{
 _HandlerId = XCode.Common.Helper.ConvertToGuid(value);return;
}

			    base[name] = value;
			}
		}
		#endregion
	}
}