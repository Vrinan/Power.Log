 
 
 using    System;
 using System.Collections.Generic;
 using System.Text; 
 using XCode.Attributes    ;

 namespace  Power.Systems.StdMarket.StdMarket
{
    /// <summary>
    /// 合同评审
    /// </summary>
    public class PS_ContractReviewDO : PS_ContractReviewDO<PS_ContractReviewDO>
    {

    }

	/// <summary>
    /// 合同评审
    /// </summary>
	  [BindEntity(KeyWord="PS_ContractReview",EntityType = typeof(Power.Systems.StdMarket.StdMarket.PS_ContractReviewDO),Description = "合同评审"  )] 

	 [BindTable( "PS_MK_ContractReview", Alias = "a",IsAttach=false,Description ="")]

	  [BindIndex(Name = "pk_PS_MK_ContractReview", KeyType = Power.DataAccessLayer.KeyType.MainKey, Columns = "Id", TableName = "PS_MK_ContractReview",Description="")]

    public   class PS_ContractReviewDO<TEntity> : XCode.Entity<TEntity>, XCode.IEntity where TEntity : Power.Systems.StdMarket.StdMarket.PS_ContractReviewDO<TEntity>, new()
    { 
	    #region 属性

	    
 private System.Guid _Id;
 /// <summary>
 /// 主键
 /// </summary>
 [BindColumn(1,"a", "Id", "主键","", "NCHAR", 16,0,false, IsPrimaryKey =true ,IsIdentity =true,IsNullable =false,  Length =16 )]
 public virtual System.Guid Id  { get { return _Id; } set { _Id = value; } }

 private System.Guid _ProjectInfo_Guid;
 /// <summary>
 /// 前期项目信息
 /// </summary>
 [BindColumn(2,"a", "ProjectInfo_Guid", "前期项目信息","", "NCHAR", 16,0,false, IsPrimaryKey =false ,IsIdentity =false,IsNullable =true,  Length =16 )]
 public  System.Guid ProjectInfo_Guid  { get { return _ProjectInfo_Guid; } set { _ProjectInfo_Guid = value; } }

 private System.String _ContractCode;
 /// <summary>
 /// 合同编号
 /// </summary>
 [BindColumn(3,"a", "ContractCode", "合同编号","", "NCHAR", 50,0,false, IsPrimaryKey =false ,IsIdentity =false,IsNullable =true,  Length =50 )]
 public  System.String ContractCode  { get { return _ContractCode; } set { _ContractCode = value; } }

 private System.String _ContractName;
 /// <summary>
 /// 合同名称
 /// </summary>
 [BindColumn(4,"a", "ContractName", "合同名称","", "NCHAR", 300,0,false, IsPrimaryKey =false ,IsIdentity =false,IsNullable =true,  Length =300 )]
 public  System.String ContractName  { get { return _ContractName; } set { _ContractName = value; } }

 private System.String _ContractType;
 /// <summary>
 /// 合同类型，下拉
 /// </summary>
 [BindColumn(5,"a", "ContractType", "合同类型，下拉","", "NCHAR", 50,0,false, IsPrimaryKey =false ,IsIdentity =false,IsNullable =true,  Length =50 )]
 public  System.String ContractType  { get { return _ContractType; } set { _ContractType = value; } }

 private System.String _ContractForm;
 /// <summary>
 /// 合同形式，下拉
 /// </summary>
 [BindColumn(6,"a", "ContractForm", "合同形式，下拉","", "NCHAR", 50,0,false, IsPrimaryKey =false ,IsIdentity =false,IsNullable =true,  Length =50 )]
 public  System.String ContractForm  { get { return _ContractForm; } set { _ContractForm = value; } }

 private System.Double _ContractAmount;
 /// <summary>
 /// 预计合同金额
 /// </summary>
 [BindColumn(7,"a", "ContractAmount", "预计合同金额","", "NCHAR", 53,0,false, IsPrimaryKey =false ,IsIdentity =false,IsNullable =true,  Length =53 )]
 public  System.Double ContractAmount  { get { return _ContractAmount; } set { _ContractAmount = value; } }

 private System.String _CurrencyType;
 /// <summary>
 /// 币种
 /// </summary>
 [BindColumn(8,"a", "CurrencyType", "币种","", "NCHAR", 50,0,false, IsPrimaryKey =false ,IsIdentity =false,IsNullable =true,  Length =50 )]
 public  System.String CurrencyType  { get { return _CurrencyType; } set { _CurrencyType = value; } }

 private System.String _ProductType;
 /// <summary>
 /// 产品类型
 /// </summary>
 [BindColumn(9,"a", "ProductType", "产品类型","", "NCHAR", 50,0,false, IsPrimaryKey =false ,IsIdentity =false,IsNullable =true,  Length =50 )]
 public  System.String ProductType  { get { return _ProductType; } set { _ProductType = value; } }

 private System.String _ReviewWay;
 /// <summary>
 /// 评审形式，下拉
 /// </summary>
 [BindColumn(10,"a", "ReviewWay", "评审形式，下拉","", "NCHAR", 50,0,false, IsPrimaryKey =false ,IsIdentity =false,IsNullable =true,  Length =50 )]
 public  System.String ReviewWay  { get { return _ReviewWay; } set { _ReviewWay = value; } }

 private System.DateTime _ReviewDate;
 /// <summary>
 /// 评审日期
 /// </summary>
 [BindColumn(11,"a", "ReviewDate", "评审日期","", "NCHAR", 3,0,false, IsPrimaryKey =false ,IsIdentity =false,IsNullable =true,  Length =3 )]
 public  System.DateTime ReviewDate  { get { return _ReviewDate; } set { _ReviewDate = value; } }

 private System.DateTime _SignedDate;
 /// <summary>
 /// 预计签订日期
 /// </summary>
 [BindColumn(12,"a", "SignedDate", "预计签订日期","", "NCHAR", 3,0,false, IsPrimaryKey =false ,IsIdentity =false,IsNullable =true,  Length =3 )]
 public  System.DateTime SignedDate  { get { return _SignedDate; } set { _SignedDate = value; } }

 private System.Guid _Client_Guid;
 /// <summary>
 /// 客户id，关联organize
 /// </summary>
 [BindColumn(13,"a", "Client_Guid", "客户id，关联organize","", "NCHAR", 16,0,false, IsPrimaryKey =false ,IsIdentity =false,IsNullable =true,  Length =16 )]
 public  System.Guid Client_Guid  { get { return _Client_Guid; } set { _Client_Guid = value; } }

 private System.String _ClientName;
 /// <summary>
 /// 客户名称
 /// </summary>
 [BindColumn(14,"a", "ClientName", "客户名称","", "NCHAR", 300,0,false, IsPrimaryKey =false ,IsIdentity =false,IsNullable =true,  Length =300 )]
 public  System.String ClientName  { get { return _ClientName; } set { _ClientName = value; } }

 private System.Guid _UpdHumId;
 /// <summary>
 /// 
 /// </summary>
 [BindColumn(15,"a", "UpdHumId", "","", "NCHAR", 16,0,false, IsPrimaryKey =false ,IsIdentity =false,IsNullable =true,  Length =16 )]
 public  System.Guid UpdHumId  { get { return _UpdHumId; } set { _UpdHumId = value; } }

 private System.String _UpdHuman;
 /// <summary>
 /// 
 /// </summary>
 [BindColumn(16,"a", "UpdHuman", "","", "NCHAR", 80,0,false, IsPrimaryKey =false ,IsIdentity =false,IsNullable =true,  Length =80 )]
 public  System.String UpdHuman  { get { return _UpdHuman; } set { _UpdHuman = value; } }

 private System.DateTime _UpdDate;
 /// <summary>
 /// 
 /// </summary>
 [BindColumn(17,"a", "UpdDate", "","", "NCHAR", 3,0,false, IsPrimaryKey =false ,IsIdentity =false,IsNullable =true,  Length =3 )]
 public  System.DateTime UpdDate  { get { return _UpdDate; } set { _UpdDate = value; } }

 private System.DateTime _RegDate;
 /// <summary>
 /// 
 /// </summary>
 [BindColumn(18,"a", "RegDate", "","", "NCHAR", 3,0,false, IsPrimaryKey =false ,IsIdentity =false,IsNullable =true,  Length =3 )]
 public  System.DateTime RegDate  { get { return _RegDate; } set { _RegDate = value; } }

 private System.String _RegHumName;
 /// <summary>
 /// 
 /// </summary>
 [BindColumn(19,"a", "RegHumName", "","", "NCHAR", 80,0,false, IsPrimaryKey =false ,IsIdentity =false,IsNullable =true,  Length =80 )]
 public  System.String RegHumName  { get { return _RegHumName; } set { _RegHumName = value; } }

 private System.Guid _RegHumId;
 /// <summary>
 /// 
 /// </summary>
 [BindColumn(20,"a", "RegHumId", "","", "NCHAR", 16,0,false, IsPrimaryKey =false ,IsIdentity =false,IsNullable =true,  Length =16 )]
 public  System.Guid RegHumId  { get { return _RegHumId; } set { _RegHumId = value; } }

 private System.String _OwnProjName;
 /// <summary>
 /// 
 /// </summary>
 [BindColumn(21,"a", "OwnProjName", "","", "NCHAR", 255,0,false, IsPrimaryKey =false ,IsIdentity =false,IsNullable =true,  Length =255 )]
 public  System.String OwnProjName  { get { return _OwnProjName; } set { _OwnProjName = value; } }

 private System.Guid _OwnProjId;
 /// <summary>
 /// 
 /// </summary>
 [BindColumn(22,"a", "OwnProjId", "","", "NCHAR", 16,0,false, IsPrimaryKey =false ,IsIdentity =false,IsNullable =true,  Length =16 )]
 public  System.Guid OwnProjId  { get { return _OwnProjId; } set { _OwnProjId = value; } }

 private System.Guid _EpsProjId;
 /// <summary>
 /// 
 /// </summary>
 [BindColumn(23,"a", "EpsProjId", "","", "NCHAR", 16,0,false, IsPrimaryKey =false ,IsIdentity =false,IsNullable =true,  Length =16 )]
 public  System.Guid EpsProjId  { get { return _EpsProjId; } set { _EpsProjId = value; } }

 private System.Guid _ApprHumId;
 /// <summary>
 /// 
 /// </summary>
 [BindColumn(24,"a", "ApprHumId", "","", "NCHAR", 16,0,false, IsPrimaryKey =false ,IsIdentity =false,IsNullable =true,  Length =16 )]
 public  System.Guid ApprHumId  { get { return _ApprHumId; } set { _ApprHumId = value; } }

 private System.String _ApprHumName;
 /// <summary>
 /// 
 /// </summary>
 [BindColumn(25,"a", "ApprHumName", "","", "NCHAR", 80,0,false, IsPrimaryKey =false ,IsIdentity =false,IsNullable =true,  Length =80 )]
 public  System.String ApprHumName  { get { return _ApprHumName; } set { _ApprHumName = value; } }

 private System.DateTime _ApprDate;
 /// <summary>
 /// 
 /// </summary>
 [BindColumn(26,"a", "ApprDate", "","", "NCHAR", 3,0,false, IsPrimaryKey =false ,IsIdentity =false,IsNullable =true,  Length =3 )]
 public  System.DateTime ApprDate  { get { return _ApprDate; } set { _ApprDate = value; } }

 private System.SByte _Status;
 /// <summary>
 /// 
 /// </summary>
 [BindColumn(27,"a", "Status", "","", "NCHAR", 3,0,false, IsPrimaryKey =false ,IsIdentity =false,IsNullable =true,  Length =3 )]
 public  System.SByte Status  { get { return _Status; } set { _Status = value; } }

 private System.String _ProjectName;
 /// <summary>
 /// 
 /// </summary>
 [BindColumn(28,"a", "ProjectName", "","", "NCHAR", 100,0,false, IsPrimaryKey =false ,IsIdentity =false,IsNullable =true,  Length =100 )]
 public  System.String ProjectName  { get { return _ProjectName; } set { _ProjectName = value; } }

      
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
if (name == "PROJECTINFO_GUID")
{
return _ProjectInfo_Guid;
}
if (name == "CONTRACTCODE")
{
return _ContractCode;
}
if (name == "CONTRACTNAME")
{
return _ContractName;
}
if (name == "CONTRACTTYPE")
{
return _ContractType;
}
if (name == "CONTRACTFORM")
{
return _ContractForm;
}
if (name == "CONTRACTAMOUNT")
{
return _ContractAmount;
}
if (name == "CURRENCYTYPE")
{
return _CurrencyType;
}
if (name == "PRODUCTTYPE")
{
return _ProductType;
}
if (name == "REVIEWWAY")
{
return _ReviewWay;
}
if (name == "REVIEWDATE")
{
return _ReviewDate;
}
if (name == "SIGNEDDATE")
{
return _SignedDate;
}
if (name == "CLIENT_GUID")
{
return _Client_Guid;
}
if (name == "CLIENTNAME")
{
return _ClientName;
}
if (name == "UPDHUMID")
{
return _UpdHumId;
}
if (name == "UPDHUMAN")
{
return _UpdHuman;
}
if (name == "UPDDATE")
{
return _UpdDate;
}
if (name == "REGDATE")
{
return _RegDate;
}
if (name == "REGHUMNAME")
{
return _RegHumName;
}
if (name == "REGHUMID")
{
return _RegHumId;
}
if (name == "OWNPROJNAME")
{
return _OwnProjName;
}
if (name == "OWNPROJID")
{
return _OwnProjId;
}
if (name == "EPSPROJID")
{
return _EpsProjId;
}
if (name == "APPRHUMID")
{
return _ApprHumId;
}
if (name == "APPRHUMNAME")
{
return _ApprHumName;
}
if (name == "APPRDATE")
{
return _ApprDate;
}
if (name == "STATUS")
{
return _Status;
}
if (name == "PROJECTNAME")
{
return _ProjectName;
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
if (name == "PROJECTINFO_GUID")
{
 _ProjectInfo_Guid = XCode.Common.Helper.ConvertToGuid(value);return;
}
if (name == "CONTRACTCODE")
{
 _ContractCode = System.Convert.ToString(value);return;
}
if (name == "CONTRACTNAME")
{
 _ContractName = System.Convert.ToString(value);return;
}
if (name == "CONTRACTTYPE")
{
 _ContractType = System.Convert.ToString(value);return;
}
if (name == "CONTRACTFORM")
{
 _ContractForm = System.Convert.ToString(value);return;
}
if (name == "CONTRACTAMOUNT")
{
 _ContractAmount = System.Convert.ToDouble(value);return;
}
if (name == "CURRENCYTYPE")
{
 _CurrencyType = System.Convert.ToString(value);return;
}
if (name == "PRODUCTTYPE")
{
 _ProductType = System.Convert.ToString(value);return;
}
if (name == "REVIEWWAY")
{
 _ReviewWay = System.Convert.ToString(value);return;
}
if (name == "REVIEWDATE")
{
 if (value == null || value.ToString().IsNullOrEmpty() == true) value = DateTime.MinValue;
 _ReviewDate = System.Convert.ToDateTime(value);return;
}
if (name == "SIGNEDDATE")
{
 if (value == null || value.ToString().IsNullOrEmpty() == true) value = DateTime.MinValue;
 _SignedDate = System.Convert.ToDateTime(value);return;
}
if (name == "CLIENT_GUID")
{
 _Client_Guid = XCode.Common.Helper.ConvertToGuid(value);return;
}
if (name == "CLIENTNAME")
{
 _ClientName = System.Convert.ToString(value);return;
}
if (name == "UPDHUMID")
{
 _UpdHumId = XCode.Common.Helper.ConvertToGuid(value);return;
}
if (name == "UPDHUMAN")
{
 _UpdHuman = System.Convert.ToString(value);return;
}
if (name == "UPDDATE")
{
 if (value == null || value.ToString().IsNullOrEmpty() == true) value = DateTime.MinValue;
 _UpdDate = System.Convert.ToDateTime(value);return;
}
if (name == "REGDATE")
{
 if (value == null || value.ToString().IsNullOrEmpty() == true) value = DateTime.MinValue;
 _RegDate = System.Convert.ToDateTime(value);return;
}
if (name == "REGHUMNAME")
{
 _RegHumName = System.Convert.ToString(value);return;
}
if (name == "REGHUMID")
{
 _RegHumId = XCode.Common.Helper.ConvertToGuid(value);return;
}
if (name == "OWNPROJNAME")
{
 _OwnProjName = System.Convert.ToString(value);return;
}
if (name == "OWNPROJID")
{
 _OwnProjId = XCode.Common.Helper.ConvertToGuid(value);return;
}
if (name == "EPSPROJID")
{
 _EpsProjId = XCode.Common.Helper.ConvertToGuid(value);return;
}
if (name == "APPRHUMID")
{
 _ApprHumId = XCode.Common.Helper.ConvertToGuid(value);return;
}
if (name == "APPRHUMNAME")
{
 _ApprHumName = System.Convert.ToString(value);return;
}
if (name == "APPRDATE")
{
 if (value == null || value.ToString().IsNullOrEmpty() == true) value = DateTime.MinValue;
 _ApprDate = System.Convert.ToDateTime(value);return;
}
if (name == "STATUS")
{
 _Status = System.Convert.ToSByte(value);return;
}
if (name == "PROJECTNAME")
{
 _ProjectName = System.Convert.ToString(value);return;
}

			    base[name] = value;
			}
		}
		#endregion
	}
}