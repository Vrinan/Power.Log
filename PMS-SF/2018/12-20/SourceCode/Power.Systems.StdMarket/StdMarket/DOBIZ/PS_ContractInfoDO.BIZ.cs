 
 
 using    System;
 using System.Collections.Generic;
 using System.Text; 
 using XCode.Attributes    ;

 namespace  Power.Systems.StdMarket.StdMarket
{
    /// <summary>
    /// 项目合同基本信息
    /// </summary>
    public class PS_ContractInfoDO : PS_ContractInfoDO<PS_ContractInfoDO>
    {

    }

	/// <summary>
    /// 项目合同基本信息
    /// </summary>
	  [BindEntity(KeyWord="PS_ContractInfo",EntityType = typeof(Power.Systems.StdMarket.StdMarket.PS_ContractInfoDO),Description = "项目合同基本信息"  )] 

	 [BindTable( "PS_MK_ContractInfo", Alias = "a",IsAttach=false,Description ="")]

	  [BindIndex(Name = "pk_PS_MK_ContractInfo", KeyType = Power.DataAccessLayer.KeyType.MainKey, Columns = "Id", TableName = "PS_MK_ContractInfo",Description="")]

    public   class PS_ContractInfoDO<TEntity> : XCode.Entity<TEntity>, XCode.IEntity where TEntity : Power.Systems.StdMarket.StdMarket.PS_ContractInfoDO<TEntity>, new()
    { 
	    #region 属性

	    
 private System.Guid _Id;
 /// <summary>
 /// 
 /// </summary>
 [BindColumn(1,"a", "Id", "","", "NCHAR", 16,0,false, IsPrimaryKey =true ,IsIdentity =true,IsNullable =false,  Length =16 )]
 public virtual System.Guid Id  { get { return _Id; } set { _Id = value; } }

 private System.Guid _ProjectInfo_Guid;
 /// <summary>
 /// 
 /// </summary>
 [BindColumn(2,"a", "ProjectInfo_Guid", "","", "NCHAR", 16,0,false, IsPrimaryKey =false ,IsIdentity =false,IsNullable =true,  Length =16 )]
 public  System.Guid ProjectInfo_Guid  { get { return _ProjectInfo_Guid; } set { _ProjectInfo_Guid = value; } }

 private System.String _ContractCode;
 /// <summary>
 /// 
 /// </summary>
 [BindColumn(3,"a", "ContractCode", "","", "NCHAR", 50,0,false, IsPrimaryKey =false ,IsIdentity =false,IsNullable =true,  Length =50 )]
 public  System.String ContractCode  { get { return _ContractCode; } set { _ContractCode = value; } }

 private System.String _ContractName;
 /// <summary>
 /// 
 /// </summary>
 [BindColumn(4,"a", "ContractName", "","", "NCHAR", 300,0,false, IsPrimaryKey =false ,IsIdentity =false,IsNullable =true,  Length =300 )]
 public  System.String ContractName  { get { return _ContractName; } set { _ContractName = value; } }

 private System.String _ContractType;
 /// <summary>
 /// 
 /// </summary>
 [BindColumn(5,"a", "ContractType", "","", "NCHAR", 50,0,false, IsPrimaryKey =false ,IsIdentity =false,IsNullable =true,  Length =50 )]
 public  System.String ContractType  { get { return _ContractType; } set { _ContractType = value; } }

 private System.String _ContractForm;
 /// <summary>
 /// 
 /// </summary>
 [BindColumn(6,"a", "ContractForm", "","", "NCHAR", 50,0,false, IsPrimaryKey =false ,IsIdentity =false,IsNullable =true,  Length =50 )]
 public  System.String ContractForm  { get { return _ContractForm; } set { _ContractForm = value; } }

 private System.Double _ContractAmount;
 /// <summary>
 /// 
 /// </summary>
 [BindColumn(7,"a", "ContractAmount", "","", "NCHAR", 53,0,false, IsPrimaryKey =false ,IsIdentity =false,IsNullable =true,  Length =53 )]
 public  System.Double ContractAmount  { get { return _ContractAmount; } set { _ContractAmount = value; } }

 private System.Double _ChangeAmount;
 /// <summary>
 /// 
 /// </summary>
 [BindColumn(8,"a", "ChangeAmount", "","", "NCHAR", 53,0,false, IsPrimaryKey =false ,IsIdentity =false,IsNullable =true,  Length =53 )]
 public  System.Double ChangeAmount  { get { return _ChangeAmount; } set { _ChangeAmount = value; } }

 private System.String _CurrencyType;
 /// <summary>
 /// 
 /// </summary>
 [BindColumn(8,"a", "CurrencyType", "","", "NCHAR", 50,0,false, IsPrimaryKey =false ,IsIdentity =false,IsNullable =true,  Length =50 )]
 public  System.String CurrencyType  { get { return _CurrencyType; } set { _CurrencyType = value; } }

 private System.String _ProductType;
 /// <summary>
 /// 
 /// </summary>
 [BindColumn(9,"a", "ProductType", "","", "NCHAR", 50,0,false, IsPrimaryKey =false ,IsIdentity =false,IsNullable =true,  Length =50 )]
 public  System.String ProductType  { get { return _ProductType; } set { _ProductType = value; } }

 private System.Double _FinalContractAmount;
 /// <summary>
 /// 
 /// </summary>
 [BindColumn(9,"a", "FinalContractAmount", "","", "NCHAR", 53,0,false, IsPrimaryKey =false ,IsIdentity =false,IsNullable =true,  Length =53 )]
 public  System.Double FinalContractAmount  { get { return _FinalContractAmount; } set { _FinalContractAmount = value; } }

 private System.String _ReviewWay;
 /// <summary>
 /// 
 /// </summary>
 [BindColumn(10,"a", "ReviewWay", "","", "NCHAR", 50,0,false, IsPrimaryKey =false ,IsIdentity =false,IsNullable =true,  Length =50 )]
 public  System.String ReviewWay  { get { return _ReviewWay; } set { _ReviewWay = value; } }

 private System.DateTime _ReviewDate;
 /// <summary>
 /// 
 /// </summary>
 [BindColumn(11,"a", "ReviewDate", "","", "NCHAR", 3,0,false, IsPrimaryKey =false ,IsIdentity =false,IsNullable =true,  Length =3 )]
 public  System.DateTime ReviewDate  { get { return _ReviewDate; } set { _ReviewDate = value; } }

 private System.DateTime _SignedDate;
 /// <summary>
 /// 
 /// </summary>
 [BindColumn(12,"a", "SignedDate", "","", "NCHAR", 3,0,false, IsPrimaryKey =false ,IsIdentity =false,IsNullable =true,  Length =3 )]
 public  System.DateTime SignedDate  { get { return _SignedDate; } set { _SignedDate = value; } }

 private System.Guid _Client_Guid;
 /// <summary>
 /// 
 /// </summary>
 [BindColumn(13,"a", "Client_Guid", "","", "NCHAR", 16,0,false, IsPrimaryKey =false ,IsIdentity =false,IsNullable =true,  Length =16 )]
 public  System.Guid Client_Guid  { get { return _Client_Guid; } set { _Client_Guid = value; } }

 private System.String _ClientName;
 /// <summary>
 /// 
 /// </summary>
 [BindColumn(14,"a", "ClientName", "","", "NCHAR", 300,0,false, IsPrimaryKey =false ,IsIdentity =false,IsNullable =true,  Length =300 )]
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

 private System.String _ClientSignPerson;
 /// <summary>
 /// 
 /// </summary>
 [BindColumn(17,"a", "ClientSignPerson", "","", "NCHAR", 20,0,false, IsPrimaryKey =false ,IsIdentity =false,IsNullable =true,  Length =20 )]
 public  System.String ClientSignPerson  { get { return _ClientSignPerson; } set { _ClientSignPerson = value; } }

 private System.DateTime _UpdDate;
 /// <summary>
 /// 
 /// </summary>
 [BindColumn(17,"a", "UpdDate", "","", "NCHAR", 3,0,false, IsPrimaryKey =false ,IsIdentity =false,IsNullable =true,  Length =3 )]
 public  System.DateTime UpdDate  { get { return _UpdDate; } set { _UpdDate = value; } }

 private System.String _PartyA;
 /// <summary>
 /// 
 /// </summary>
 [BindColumn(18,"a", "PartyA", "","", "NCHAR", 300,0,false, IsPrimaryKey =false ,IsIdentity =false,IsNullable =true,  Length =300 )]
 public  System.String PartyA  { get { return _PartyA; } set { _PartyA = value; } }

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

 private System.Guid _PartyA_Guid;
 /// <summary>
 /// 
 /// </summary>
 [BindColumn(19,"a", "PartyA_Guid", "","", "NCHAR", 16,0,false, IsPrimaryKey =false ,IsIdentity =false,IsNullable =true,  Length =16 )]
 public  System.Guid PartyA_Guid  { get { return _PartyA_Guid; } set { _PartyA_Guid = value; } }

 private System.String _PartyAPerson;
 /// <summary>
 /// 
 /// </summary>
 [BindColumn(20,"a", "PartyAPerson", "","", "NCHAR", 20,0,false, IsPrimaryKey =false ,IsIdentity =false,IsNullable =true,  Length =20 )]
 public  System.String PartyAPerson  { get { return _PartyAPerson; } set { _PartyAPerson = value; } }

 private System.Guid _RegHumId;
 /// <summary>
 /// 
 /// </summary>
 [BindColumn(20,"a", "RegHumId", "","", "NCHAR", 16,0,false, IsPrimaryKey =false ,IsIdentity =false,IsNullable =true,  Length =16 )]
 public  System.Guid RegHumId  { get { return _RegHumId; } set { _RegHumId = value; } }

 private System.String _PartyB;
 /// <summary>
 /// 
 /// </summary>
 [BindColumn(21,"a", "PartyB", "","", "NCHAR", 300,0,false, IsPrimaryKey =false ,IsIdentity =false,IsNullable =true,  Length =300 )]
 public  System.String PartyB  { get { return _PartyB; } set { _PartyB = value; } }

 private System.String _OwnProjName;
 /// <summary>
 /// 
 /// </summary>
 [BindColumn(21,"a", "OwnProjName", "","", "NCHAR", 255,0,false, IsPrimaryKey =false ,IsIdentity =false,IsNullable =true,  Length =255 )]
 public  System.String OwnProjName  { get { return _OwnProjName; } set { _OwnProjName = value; } }

 private System.String _PartyBSighPerson;
 /// <summary>
 /// 
 /// </summary>
 [BindColumn(22,"a", "PartyBSighPerson", "","", "NCHAR", 50,0,false, IsPrimaryKey =false ,IsIdentity =false,IsNullable =true,  Length =50 )]
 public  System.String PartyBSighPerson  { get { return _PartyBSighPerson; } set { _PartyBSighPerson = value; } }

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

 private System.Guid _PartyBSighPersonId;
 /// <summary>
 /// 
 /// </summary>
 [BindColumn(23,"a", "PartyBSighPersonId", "","", "NCHAR", 16,0,false, IsPrimaryKey =false ,IsIdentity =false,IsNullable =true,  Length =16 )]
 public  System.Guid PartyBSighPersonId  { get { return _PartyBSighPersonId; } set { _PartyBSighPersonId = value; } }

 private System.DateTime _ContractStrartDate;
 /// <summary>
 /// 
 /// </summary>
 [BindColumn(24,"a", "ContractStrartDate", "","", "NCHAR", 3,0,false, IsPrimaryKey =false ,IsIdentity =false,IsNullable =true,  Length =3 )]
 public  System.DateTime ContractStrartDate  { get { return _ContractStrartDate; } set { _ContractStrartDate = value; } }

 private System.Guid _ApprHumId;
 /// <summary>
 /// 
 /// </summary>
 [BindColumn(24,"a", "ApprHumId", "","", "NCHAR", 16,0,false, IsPrimaryKey =false ,IsIdentity =false,IsNullable =true,  Length =16 )]
 public  System.Guid ApprHumId  { get { return _ApprHumId; } set { _ApprHumId = value; } }

 private System.DateTime _ContractEndDate;
 /// <summary>
 /// 
 /// </summary>
 [BindColumn(25,"a", "ContractEndDate", "","", "NCHAR", 3,0,false, IsPrimaryKey =false ,IsIdentity =false,IsNullable =true,  Length =3 )]
 public  System.DateTime ContractEndDate  { get { return _ContractEndDate; } set { _ContractEndDate = value; } }

 private System.String _ApprHumName;
 /// <summary>
 /// 
 /// </summary>
 [BindColumn(25,"a", "ApprHumName", "","", "NCHAR", 80,0,false, IsPrimaryKey =false ,IsIdentity =false,IsNullable =true,  Length =80 )]
 public  System.String ApprHumName  { get { return _ApprHumName; } set { _ApprHumName = value; } }

 private System.Double _ContractPeriod;
 /// <summary>
 /// 
 /// </summary>
 [BindColumn(26,"a", "ContractPeriod", "","", "NCHAR", 53,0,false, IsPrimaryKey =false ,IsIdentity =false,IsNullable =true,  Length =53 )]
 public  System.Double ContractPeriod  { get { return _ContractPeriod; } set { _ContractPeriod = value; } }

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

 private System.String _PayType;
 /// <summary>
 /// 支付方式
 /// </summary>
 [BindColumn(27,"a", "PayType", "支付方式","", "NCHAR", 50,0,false, IsPrimaryKey =false ,IsIdentity =false,IsNullable =true,  Length =50 )]
 public  System.String PayType  { get { return _PayType; } set { _PayType = value; } }

 private System.String _OrArmour;
 /// <summary>
 /// 有无甲供材
 /// </summary>
 [BindColumn(28,"a", "OrArmour", "有无甲供材","", "NCHAR", 50,0,false, IsPrimaryKey =false ,IsIdentity =false,IsNullable =true,  Length =50 )]
 public  System.String OrArmour  { get { return _OrArmour; } set { _OrArmour = value; } }

 private System.Guid _PartB_Guid;
 /// <summary>
 /// 
 /// </summary>
 [BindColumn(42,"a", "PartB_Guid", "","", "NCHAR", 16,0,false, IsPrimaryKey =false ,IsIdentity =false,IsNullable =true,  Length =16 )]
 public  System.Guid PartB_Guid  { get { return _PartB_Guid; } set { _PartB_Guid = value; } }

 private System.Guid _ContractReviewId;
 /// <summary>
 /// 
 /// </summary>
 [BindColumn(43,"a", "ContractReviewId", "","", "NCHAR", 16,0,false, IsPrimaryKey =false ,IsIdentity =false,IsNullable =true,  Length =16 )]
 public  System.Guid ContractReviewId  { get { return _ContractReviewId; } set { _ContractReviewId = value; } }

 private System.String _ContractReviewCode;
 /// <summary>
 /// 
 /// </summary>
 [BindColumn(44,"a", "ContractReviewCode", "","", "NCHAR", 50,0,false, IsPrimaryKey =false ,IsIdentity =false,IsNullable =true,  Length =50 )]
 public  System.String ContractReviewCode  { get { return _ContractReviewCode; } set { _ContractReviewCode = value; } }

      
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
if (name == "CHANGEAMOUNT")
{
return _ChangeAmount;
}
if (name == "CURRENCYTYPE")
{
return _CurrencyType;
}
if (name == "PRODUCTTYPE")
{
return _ProductType;
}
if (name == "FINALCONTRACTAMOUNT")
{
return _FinalContractAmount;
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
if (name == "CLIENTSIGNPERSON")
{
return _ClientSignPerson;
}
if (name == "UPDDATE")
{
return _UpdDate;
}
if (name == "PARTYA")
{
return _PartyA;
}
if (name == "REGDATE")
{
return _RegDate;
}
if (name == "REGHUMNAME")
{
return _RegHumName;
}
if (name == "PARTYA_GUID")
{
return _PartyA_Guid;
}
if (name == "PARTYAPERSON")
{
return _PartyAPerson;
}
if (name == "REGHUMID")
{
return _RegHumId;
}
if (name == "PARTYB")
{
return _PartyB;
}
if (name == "OWNPROJNAME")
{
return _OwnProjName;
}
if (name == "PARTYBSIGHPERSON")
{
return _PartyBSighPerson;
}
if (name == "OWNPROJID")
{
return _OwnProjId;
}
if (name == "EPSPROJID")
{
return _EpsProjId;
}
if (name == "PARTYBSIGHPERSONID")
{
return _PartyBSighPersonId;
}
if (name == "CONTRACTSTRARTDATE")
{
return _ContractStrartDate;
}
if (name == "APPRHUMID")
{
return _ApprHumId;
}
if (name == "CONTRACTENDDATE")
{
return _ContractEndDate;
}
if (name == "APPRHUMNAME")
{
return _ApprHumName;
}
if (name == "CONTRACTPERIOD")
{
return _ContractPeriod;
}
if (name == "APPRDATE")
{
return _ApprDate;
}
if (name == "STATUS")
{
return _Status;
}
if (name == "PAYTYPE")
{
return _PayType;
}
if (name == "ORARMOUR")
{
return _OrArmour;
}
if (name == "PARTB_GUID")
{
return _PartB_Guid;
}
if (name == "CONTRACTREVIEWID")
{
return _ContractReviewId;
}
if (name == "CONTRACTREVIEWCODE")
{
return _ContractReviewCode;
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
if (name == "CHANGEAMOUNT")
{
 _ChangeAmount = System.Convert.ToDouble(value);return;
}
if (name == "CURRENCYTYPE")
{
 _CurrencyType = System.Convert.ToString(value);return;
}
if (name == "PRODUCTTYPE")
{
 _ProductType = System.Convert.ToString(value);return;
}
if (name == "FINALCONTRACTAMOUNT")
{
 _FinalContractAmount = System.Convert.ToDouble(value);return;
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
if (name == "CLIENTSIGNPERSON")
{
 _ClientSignPerson = System.Convert.ToString(value);return;
}
if (name == "UPDDATE")
{
 if (value == null || value.ToString().IsNullOrEmpty() == true) value = DateTime.MinValue;
 _UpdDate = System.Convert.ToDateTime(value);return;
}
if (name == "PARTYA")
{
 _PartyA = System.Convert.ToString(value);return;
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
if (name == "PARTYA_GUID")
{
 _PartyA_Guid = XCode.Common.Helper.ConvertToGuid(value);return;
}
if (name == "PARTYAPERSON")
{
 _PartyAPerson = System.Convert.ToString(value);return;
}
if (name == "REGHUMID")
{
 _RegHumId = XCode.Common.Helper.ConvertToGuid(value);return;
}
if (name == "PARTYB")
{
 _PartyB = System.Convert.ToString(value);return;
}
if (name == "OWNPROJNAME")
{
 _OwnProjName = System.Convert.ToString(value);return;
}
if (name == "PARTYBSIGHPERSON")
{
 _PartyBSighPerson = System.Convert.ToString(value);return;
}
if (name == "OWNPROJID")
{
 _OwnProjId = XCode.Common.Helper.ConvertToGuid(value);return;
}
if (name == "EPSPROJID")
{
 _EpsProjId = XCode.Common.Helper.ConvertToGuid(value);return;
}
if (name == "PARTYBSIGHPERSONID")
{
 _PartyBSighPersonId = XCode.Common.Helper.ConvertToGuid(value);return;
}
if (name == "CONTRACTSTRARTDATE")
{
 if (value == null || value.ToString().IsNullOrEmpty() == true) value = DateTime.MinValue;
 _ContractStrartDate = System.Convert.ToDateTime(value);return;
}
if (name == "APPRHUMID")
{
 _ApprHumId = XCode.Common.Helper.ConvertToGuid(value);return;
}
if (name == "CONTRACTENDDATE")
{
 if (value == null || value.ToString().IsNullOrEmpty() == true) value = DateTime.MinValue;
 _ContractEndDate = System.Convert.ToDateTime(value);return;
}
if (name == "APPRHUMNAME")
{
 _ApprHumName = System.Convert.ToString(value);return;
}
if (name == "CONTRACTPERIOD")
{
 _ContractPeriod = System.Convert.ToDouble(value);return;
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
if (name == "PAYTYPE")
{
 _PayType = System.Convert.ToString(value);return;
}
if (name == "ORARMOUR")
{
 _OrArmour = System.Convert.ToString(value);return;
}
if (name == "PARTB_GUID")
{
 _PartB_Guid = XCode.Common.Helper.ConvertToGuid(value);return;
}
if (name == "CONTRACTREVIEWID")
{
 _ContractReviewId = XCode.Common.Helper.ConvertToGuid(value);return;
}
if (name == "CONTRACTREVIEWCODE")
{
 _ContractReviewCode = System.Convert.ToString(value);return;
}

			    base[name] = value;
			}
		}
		#endregion
	}
}