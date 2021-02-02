 
 
 using    System;
 using System.Collections.Generic;
 using System.Text; 
 using XCode.Attributes    ;

 namespace  Power.Systems.StdMarket.StdMarket
{
    /// <summary>
    /// 参与投标单位
    /// </summary>
    public class PS_BidTrack_DtlDO : PS_BidTrack_DtlDO<PS_BidTrack_DtlDO>
    {

    }

	/// <summary>
    /// 参与投标单位
    /// </summary>
	  [BindEntity(KeyWord="PS_BidTrack_Dtl",EntityType = typeof(Power.Systems.StdMarket.StdMarket.PS_BidTrack_DtlDO),Description = "参与投标单位"  )] 

	 [BindTable( "PS_MK_BidTrack_Dtl", Alias = "a",IsAttach=false,Description ="")]

	  [BindIndex(Name = "pk_PS_MK_BidTrack_Dtl", KeyType = Power.DataAccessLayer.KeyType.MainKey, Columns = "Id", TableName = "PS_MK_BidTrack_Dtl",Description="")]

    public   class PS_BidTrack_DtlDO<TEntity> : XCode.Entity<TEntity>, XCode.IEntity where TEntity : Power.Systems.StdMarket.StdMarket.PS_BidTrack_DtlDO<TEntity>, new()
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

 private System.String _Tenderer;
 /// <summary>
 /// 投标单位
 /// </summary>
 [BindColumn(3,"a", "Tenderer", "投标单位","", "NCHAR", 200,0,false, IsPrimaryKey =false ,IsIdentity =false,IsNullable =true,  Length =200 )]
 public  System.String Tenderer  { get { return _Tenderer; } set { _Tenderer = value; } }

 private System.Guid _TendererId;
 /// <summary>
 /// 投标单位Id
 /// </summary>
 [BindColumn(4,"a", "TendererId", "投标单位Id","", "NCHAR", 16,0,false, IsPrimaryKey =false ,IsIdentity =false,IsNullable =true,  Length =16 )]
 public  System.Guid TendererId  { get { return _TendererId; } set { _TendererId = value; } }

 private System.Double _Offer;
 /// <summary>
 /// 报价
 /// </summary>
 [BindColumn(5,"a", "Offer", "报价","", "NCHAR", 53,0,false, IsPrimaryKey =false ,IsIdentity =false,IsNullable =true,  Length =53 )]
 public  System.Double Offer  { get { return _Offer; } set { _Offer = value; } }

 private System.Int32 _isWin;
 /// <summary>
 /// 是否中标
 /// </summary>
 [BindColumn(6,"a", "isWin", "是否中标","", "NCHAR", 10,0,false, IsPrimaryKey =false ,IsIdentity =false,IsNullable =true,  Length =10 )]
 public  System.Int32 isWin  { get { return _isWin; } set { _isWin = value; } }

      
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
if (name == "TENDERER")
{
return _Tenderer;
}
if (name == "TENDERERID")
{
return _TendererId;
}
if (name == "OFFER")
{
return _Offer;
}
if (name == "ISWIN")
{
return _isWin;
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
if (name == "TENDERER")
{
 _Tenderer = System.Convert.ToString(value);return;
}
if (name == "TENDERERID")
{
 _TendererId = XCode.Common.Helper.ConvertToGuid(value);return;
}
if (name == "OFFER")
{
 _Offer = System.Convert.ToDouble(value);return;
}
if (name == "ISWIN")
{
 _isWin = System.Convert.ToInt32(value);return;
}

			    base[name] = value;
			}
		}
		#endregion
	}
}