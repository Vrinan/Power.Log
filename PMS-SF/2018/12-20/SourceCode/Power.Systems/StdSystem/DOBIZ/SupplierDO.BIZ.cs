 
 
 using    System;
 using System.Collections.Generic;
 using System.Text; 
 using XCode.Attributes    ;

 namespace  Power.Systems.StdSystem
{
    /// <summary>
    /// 供应商
    /// </summary>
    public class SupplierDO : SupplierDO<SupplierDO>
    {

    }

	/// <summary>
    /// 供应商
    /// </summary>
	  [BindEntity(KeyWord="Supplier",EntityType = typeof(Power.Systems.StdSystem.SupplierDO),Description = "供应商"  )] 

	 [BindTable( "PB_Organize", Alias = "a",IsAttach=false,Description ="")]
[BindTable( "PB_DefaultField", Alias = "b",IsAttach=true,Description ="")]

	  [BindIndex(Name = "pk_PB_Organize", KeyType = Power.DataAccessLayer.KeyType.MainKey, Columns = "Id", TableName = "PB_Organize",Description="")]
 [BindIndex(Name = "pk_PB_DefaultField", KeyType = Power.DataAccessLayer.KeyType.MainKey, Columns = "DefaultFieldId", TableName = "PB_DefaultField",Description="")]
 [BindIndex(Name = "pt_PB_Organize", KeyType = Power.DataAccessLayer.KeyType.ParentKey, Columns = "ParentId,Id", TableName = "PB_Organize",Description="")]

    public   class SupplierDO<TEntity> : XCode.Entity<TEntity>, XCode.IEntity where TEntity : Power.Systems.StdSystem.SupplierDO<TEntity>, new()
    { 
	    #region 属性

	    
 private System.Guid _Id;
 /// <summary>
 /// 
 /// </summary>
 [BindColumn(1,"a", "Id", "","", "NCHAR", 16,0,false, IsPrimaryKey =true ,IsIdentity =true,IsNullable =false,  Length =16 )]
 [BindColumn(1,"b", "DefaultFieldId", "对应业务记录Id","", "NCHAR", 16,0,false, IsPrimaryKey =true ,IsIdentity =true,IsNullable =false,  Length =16 )]
 public virtual System.Guid Id  { get { return _Id; } set { _Id = value; } }

 private System.String _LongCode;
 /// <summary>
 /// 长代码
 /// </summary>
 [BindColumn(1,"a", "LongCode", "长代码","", "NCHAR", 1024,0,false, IsPrimaryKey =false ,IsIdentity =false,IsNullable =false,  Length =1024 )]
 public  System.String LongCode  { get { return _LongCode; } set { _LongCode = value; } }

 private System.String _SubType;
 /// <summary>
 /// 角色子类
 /// </summary>
 [BindColumn(1,"a", "SubType", "角色子类","", "NCHAR", 15,0,false, IsPrimaryKey =false ,IsIdentity =false,IsNullable =true,  Length =15 )]
 public  System.String SubType  { get { return _SubType; } set { _SubType = value; } }

 private System.Guid _ParentId;
 /// <summary>
 /// 
 /// </summary>
 [BindColumn(2,"a", "ParentId", "","", "NCHAR", 16,0,false, IsPrimaryKey =false ,IsIdentity =false,IsNullable =true,  Length =16 )]
 public  System.Guid ParentId  { get { return _ParentId; } set { _ParentId = value; } }

 private System.String _Code;
 /// <summary>
 /// 编号
 /// </summary>
 [BindColumn(3,"a", "Code", "编号","", "NCHAR", 20,0,false, IsPrimaryKey =false ,IsIdentity =false,IsNullable =true,  Length =20 )]
 public  System.String Code  { get { return _Code; } set { _Code = value; } }

 private System.String _Name;
 /// <summary>
 /// 全称
 /// </summary>
 [BindColumn(4,"a", "Name", "全称","", "NCHAR", 100,0,false, IsPrimaryKey =false ,IsIdentity =false,IsNullable =true,  Length =100 )]
 public  System.String Name  { get { return _Name; } set { _Name = value; } }

 private System.String _ShortName;
 /// <summary>
 /// 简称
 /// </summary>
 [BindColumn(5,"a", "ShortName", "简称","", "NCHAR", 30,0,false, IsPrimaryKey =false ,IsIdentity =false,IsNullable =true,  Length =30 )]
 public  System.String ShortName  { get { return _ShortName; } set { _ShortName = value; } }

 private System.String _LegalPerson;
 /// <summary>
 /// 法人
 /// </summary>
 [BindColumn(6,"a", "LegalPerson", "法人","", "NCHAR", 50,0,false, IsPrimaryKey =false ,IsIdentity =false,IsNullable =true,  Length =50 )]
 public  System.String LegalPerson  { get { return _LegalPerson; } set { _LegalPerson = value; } }

 private System.String _TaxCode;
 /// <summary>
 /// 税号
 /// </summary>
 [BindColumn(7,"a", "TaxCode", "税号","", "NCHAR", 30,0,false, IsPrimaryKey =false ,IsIdentity =false,IsNullable =true,  Length =30 )]
 public  System.String TaxCode  { get { return _TaxCode; } set { _TaxCode = value; } }

 private System.String _WebSite;
 /// <summary>
 /// 网址
 /// </summary>
 [BindColumn(8,"a", "WebSite", "网址","", "NCHAR", 50,0,false, IsPrimaryKey =false ,IsIdentity =false,IsNullable =true,  Length =50 )]
 public  System.String WebSite  { get { return _WebSite; } set { _WebSite = value; } }

 private System.String _Fax;
 /// <summary>
 /// 传真
 /// </summary>
 [BindColumn(9,"a", "Fax", "传真","", "NCHAR", 50,0,false, IsPrimaryKey =false ,IsIdentity =false,IsNullable =true,  Length =50 )]
 public  System.String Fax  { get { return _Fax; } set { _Fax = value; } }

 private System.String _Phone;
 /// <summary>
 /// 电话
 /// </summary>
 [BindColumn(10,"a", "Phone", "电话","", "NCHAR", 100,0,false, IsPrimaryKey =false ,IsIdentity =false,IsNullable =true,  Length =100 )]
 public  System.String Phone  { get { return _Phone; } set { _Phone = value; } }

 private System.String _Email;
 /// <summary>
 /// 电子邮件
 /// </summary>
 [BindColumn(11,"a", "Email", "电子邮件","", "NCHAR", 50,0,false, IsPrimaryKey =false ,IsIdentity =false,IsNullable =true,  Length =50 )]
 public  System.String Email  { get { return _Email; } set { _Email = value; } }

 private System.String _Address;
 /// <summary>
 /// 地址
 /// </summary>
 [BindColumn(12,"a", "Address", "地址","", "NCHAR", 100,0,false, IsPrimaryKey =false ,IsIdentity =false,IsNullable =true,  Length =100 )]
 public  System.String Address  { get { return _Address; } set { _Address = value; } }

 private System.String _PostCode;
 /// <summary>
 /// 邮编
 /// </summary>
 [BindColumn(13,"a", "PostCode", "邮编","", "NCHAR", 50,0,false, IsPrimaryKey =false ,IsIdentity =false,IsNullable =true,  Length =50 )]
 public  System.String PostCode  { get { return _PostCode; } set { _PostCode = value; } }

 private System.String _MainLinker;
 /// <summary>
 /// 主要联系人
 /// </summary>
 [BindColumn(14,"a", "MainLinker", "主要联系人","", "NCHAR", 50,0,false, IsPrimaryKey =false ,IsIdentity =false,IsNullable =true,  Length =50 )]
 public  System.String MainLinker  { get { return _MainLinker; } set { _MainLinker = value; } }

 private System.SByte _RoleType;
 /// <summary>
 /// 角色；0本单位，1业主，2承包商，3监理，4设计单位，5施工单位，6供应商
 /// </summary>
 [BindColumn(15,"a", "RoleType", "角色；0本单位，1业主，2承包商，3监理，4设计单位，5施工单位，6供应商","", "NCHAR", 3,0,false, IsPrimaryKey =false ,IsIdentity =false,IsNullable =true,  Length =3 )]
 public  System.SByte RoleType  { get { return _RoleType; } set { _RoleType = value; } }

 private System.DateTime _ValidDate;
 /// <summary>
 /// 有效期，主要是供应商使用
 /// </summary>
 [BindColumn(16,"a", "ValidDate", "有效期，主要是供应商使用","", "NCHAR", 3,0,false, IsPrimaryKey =false ,IsIdentity =false,IsNullable =true,  Length =3 )]
 public  System.DateTime ValidDate  { get { return _ValidDate; } set { _ValidDate = value; } }

 private System.String _BankName;
 /// <summary>
 /// 开户银行名称
 /// </summary>
 [BindColumn(17,"a", "BankName", "开户银行名称","", "NCHAR", 50,0,false, IsPrimaryKey =false ,IsIdentity =false,IsNullable =true,  Length =50 )]
 public  System.String BankName  { get { return _BankName; } set { _BankName = value; } }

 private System.String _BankAccount;
 /// <summary>
 /// 开户银行账号
 /// </summary>
 [BindColumn(18,"a", "BankAccount", "开户银行账号","", "NCHAR", 60,0,false, IsPrimaryKey =false ,IsIdentity =false,IsNullable =true,  Length =60 )]
 public  System.String BankAccount  { get { return _BankAccount; } set { _BankAccount = value; } }

 private System.String _BankAddress;
 /// <summary>
 /// 开户银行地址
 /// </summary>
 [BindColumn(19,"a", "BankAddress", "开户银行地址","", "NCHAR", 100,0,false, IsPrimaryKey =false ,IsIdentity =false,IsNullable =true,  Length =100 )]
 public  System.String BankAddress  { get { return _BankAddress; } set { _BankAddress = value; } }

 private System.String _IsLongList;
 /// <summary>
 /// Y是长名单，N不是
 /// </summary>
 [BindColumn(20,"a", "IsLongList", "Y是长名单，N不是","", "NCHAR", 1,0,false, IsPrimaryKey =false ,IsIdentity =false,IsNullable =true,  Length =1 )]
 public  System.String IsLongList  { get { return _IsLongList; } set { _IsLongList = value; } }

 private System.Guid _SourceOrganizeId;
 /// <summary>
 /// 原始单位Id
 /// </summary>
 [BindColumn(21,"a", "SourceOrganizeId", "原始单位Id","", "NCHAR", 16,0,false, IsPrimaryKey =false ,IsIdentity =false,IsNullable =true,  Length =16 )]
 public  System.Guid SourceOrganizeId  { get { return _SourceOrganizeId; } set { _SourceOrganizeId = value; } }

 private System.String _TableName;
 /// <summary>
 /// 数据所属表名
 /// </summary>
 [BindColumn(2,"b", "TableName", "数据所属表名","", "NCHAR", 50,0,false, IsPrimaryKey =false ,IsIdentity =false,IsNullable =true,  Length =50 )]
 public  System.String TableName  { get { return _TableName; } set { _TableName = value; } }

 private System.Guid _BizAreaId;
 /// <summary>
 /// 数据录入业务域Id
 /// </summary>
 [BindColumn(3,"b", "BizAreaId", "数据录入业务域Id","", "NCHAR", 16,0,false, IsPrimaryKey =false ,IsIdentity =false,IsNullable =true,  Length =16 )]
 public  System.Guid BizAreaId  { get { return _BizAreaId; } set { _BizAreaId = value; } }

 private System.Int32 _Sequ;
 /// <summary>
 /// 序号
 /// </summary>
 [BindColumn(4,"b", "Sequ", "序号","", "NCHAR", 10,0,false, IsPrimaryKey =false ,IsIdentity =false,IsNullable =true,  Length =10 )]
 public  System.Int32 Sequ  { get { return _Sequ; } set { _Sequ = value; } }

 private System.SByte _Status;
 /// <summary>
 /// 平台状态；0编制中，1送审中，2生效，3废止
 /// </summary>
 [BindColumn(5,"b", "Status", "平台状态；0编制中，1送审中，2生效，3废止","", "NCHAR", 3,0,false, IsPrimaryKey =false ,IsIdentity =false,IsNullable =true,  Length =3 )]
 public  System.SByte Status  { get { return _Status; } set { _Status = value; } }

 private System.Guid _RegHumId;
 /// <summary>
 /// 录入人Id
 /// </summary>
 [BindColumn(6,"b", "RegHumId", "录入人Id","", "NCHAR", 16,0,false, IsPrimaryKey =false ,IsIdentity =false,IsNullable =true,  Length =16 )]
 public  System.Guid RegHumId  { get { return _RegHumId; } set { _RegHumId = value; } }

 private System.String _RegHumName;
 /// <summary>
 /// 录入人名称
 /// </summary>
 [BindColumn(7,"b", "RegHumName", "录入人名称","", "NCHAR", 80,0,false, IsPrimaryKey =false ,IsIdentity =false,IsNullable =true,  Length =80 )]
 public  System.String RegHumName  { get { return _RegHumName; } set { _RegHumName = value; } }

 private System.DateTime _RegDate;
 /// <summary>
 /// 录入日期
 /// </summary>
 [BindColumn(8,"b", "RegDate", "录入日期","", "NCHAR", 3,0,false, IsPrimaryKey =false ,IsIdentity =false,IsNullable =true,  Length =3 )]
 public  System.DateTime RegDate  { get { return _RegDate; } set { _RegDate = value; } }

 private System.Guid _RegPosiId;
 /// <summary>
 /// 录入人岗位Id
 /// </summary>
 [BindColumn(9,"b", "RegPosiId", "录入人岗位Id","", "NCHAR", 16,0,false, IsPrimaryKey =false ,IsIdentity =false,IsNullable =true,  Length =16 )]
 public  System.Guid RegPosiId  { get { return _RegPosiId; } set { _RegPosiId = value; } }

 private System.Guid _RegDeptId;
 /// <summary>
 /// 录入人部门Id
 /// </summary>
 [BindColumn(10,"b", "RegDeptId", "录入人部门Id","", "NCHAR", 16,0,false, IsPrimaryKey =false ,IsIdentity =false,IsNullable =true,  Length =16 )]
 public  System.Guid RegDeptId  { get { return _RegDeptId; } set { _RegDeptId = value; } }

 private System.Guid _EpsProjId;
 /// <summary>
 /// 记录所属EPS节点Id
 /// </summary>
 [BindColumn(11,"b", "EpsProjId", "记录所属EPS节点Id","", "NCHAR", 16,0,false, IsPrimaryKey =false ,IsIdentity =false,IsNullable =true,  Length =16 )]
 public  System.Guid EpsProjId  { get { return _EpsProjId; } set { _EpsProjId = value; } }

 private System.Guid _RecycleHumId;
 /// <summary>
 /// 删除人Id
 /// </summary>
 [BindColumn(12,"b", "RecycleHumId", "删除人Id","", "NCHAR", 16,0,false, IsPrimaryKey =false ,IsIdentity =false,IsNullable =true,  Length =16 )]
 public  System.Guid RecycleHumId  { get { return _RecycleHumId; } set { _RecycleHumId = value; } }

 private System.Guid _UpdHumId;
 /// <summary>
 /// 最后更新人Id
 /// </summary>
 [BindColumn(13,"b", "UpdHumId", "最后更新人Id","", "NCHAR", 16,0,false, IsPrimaryKey =false ,IsIdentity =false,IsNullable =true,  Length =16 )]
 public  System.Guid UpdHumId  { get { return _UpdHumId; } set { _UpdHumId = value; } }

 private System.String _UpdHumName;
 /// <summary>
 /// 最后更新人名称
 /// </summary>
 [BindColumn(14,"b", "UpdHumName", "最后更新人名称","", "NCHAR", 80,0,false, IsPrimaryKey =false ,IsIdentity =false,IsNullable =true,  Length =80 )]
 public  System.String UpdHumName  { get { return _UpdHumName; } set { _UpdHumName = value; } }

 private System.DateTime _UpdDate;
 /// <summary>
 /// 最后更新日期
 /// </summary>
 [BindColumn(15,"b", "UpdDate", "最后更新日期","", "NCHAR", 3,0,false, IsPrimaryKey =false ,IsIdentity =false,IsNullable =true,  Length =3 )]
 public  System.DateTime UpdDate  { get { return _UpdDate; } set { _UpdDate = value; } }

 private System.Guid _ApprHumId;
 /// <summary>
 /// 批准人Id
 /// </summary>
 [BindColumn(16,"b", "ApprHumId", "批准人Id","", "NCHAR", 16,0,false, IsPrimaryKey =false ,IsIdentity =false,IsNullable =true,  Length =16 )]
 public  System.Guid ApprHumId  { get { return _ApprHumId; } set { _ApprHumId = value; } }

 private System.String _ApprHumName;
 /// <summary>
 /// 批准人名称
 /// </summary>
 [BindColumn(17,"b", "ApprHumName", "批准人名称","", "NCHAR", 80,0,false, IsPrimaryKey =false ,IsIdentity =false,IsNullable =true,  Length =80 )]
 public  System.String ApprHumName  { get { return _ApprHumName; } set { _ApprHumName = value; } }

 private System.DateTime _ApprDate;
 /// <summary>
 /// 批准日期
 /// </summary>
 [BindColumn(18,"b", "ApprDate", "批准日期","", "NCHAR", 3,0,false, IsPrimaryKey =false ,IsIdentity =false,IsNullable =true,  Length =3 )]
 public  System.DateTime ApprDate  { get { return _ApprDate; } set { _ApprDate = value; } }

 private System.String _Memo;
 /// <summary>
 /// 备注
 /// </summary>
 [BindColumn(19,"b", "Memo", "备注","", "NCHAR", -1,0,false, IsPrimaryKey =false ,IsIdentity =false,IsNullable =true,  Length =-1 )]
 public  System.String Memo  { get { return _Memo; } set { _Memo = value; } }

 private System.Guid _OwnProjId;
 /// <summary>
 /// 所属项目Id
 /// </summary>
 [BindColumn(20,"b", "OwnProjId", "所属项目Id","", "NCHAR", 16,0,false, IsPrimaryKey =false ,IsIdentity =false,IsNullable =true,  Length =16 )]
 public  System.Guid OwnProjId  { get { return _OwnProjId; } set { _OwnProjId = value; } }

 private System.String _OwnProjName;
 /// <summary>
 /// 所属项目名称
 /// </summary>
 [BindColumn(21,"b", "OwnProjName", "所属项目名称","", "NCHAR", 255,0,false, IsPrimaryKey =false ,IsIdentity =false,IsNullable =true,  Length =255 )]
 public  System.String OwnProjName  { get { return _OwnProjName; } set { _OwnProjName = value; } }

      
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
if (name == "LONGCODE")
{
return _LongCode;
}
if (name == "SUBTYPE")
{
return _SubType;
}
if (name == "PARENTID")
{
return _ParentId;
}
if (name == "CODE")
{
return _Code;
}
if (name == "NAME")
{
return _Name;
}
if (name == "SHORTNAME")
{
return _ShortName;
}
if (name == "LEGALPERSON")
{
return _LegalPerson;
}
if (name == "TAXCODE")
{
return _TaxCode;
}
if (name == "WEBSITE")
{
return _WebSite;
}
if (name == "FAX")
{
return _Fax;
}
if (name == "PHONE")
{
return _Phone;
}
if (name == "EMAIL")
{
return _Email;
}
if (name == "ADDRESS")
{
return _Address;
}
if (name == "POSTCODE")
{
return _PostCode;
}
if (name == "MAINLINKER")
{
return _MainLinker;
}
if (name == "ROLETYPE")
{
return _RoleType;
}
if (name == "VALIDDATE")
{
return _ValidDate;
}
if (name == "BANKNAME")
{
return _BankName;
}
if (name == "BANKACCOUNT")
{
return _BankAccount;
}
if (name == "BANKADDRESS")
{
return _BankAddress;
}
if (name == "ISLONGLIST")
{
return _IsLongList;
}
if (name == "SOURCEORGANIZEID")
{
return _SourceOrganizeId;
}
if (name == "TABLENAME")
{
return _TableName;
}
if (name == "BIZAREAID")
{
return _BizAreaId;
}
if (name == "SEQU")
{
return _Sequ;
}
if (name == "STATUS")
{
return _Status;
}
if (name == "REGHUMID")
{
return _RegHumId;
}
if (name == "REGHUMNAME")
{
return _RegHumName;
}
if (name == "REGDATE")
{
return _RegDate;
}
if (name == "REGPOSIID")
{
return _RegPosiId;
}
if (name == "REGDEPTID")
{
return _RegDeptId;
}
if (name == "EPSPROJID")
{
return _EpsProjId;
}
if (name == "RECYCLEHUMID")
{
return _RecycleHumId;
}
if (name == "UPDHUMID")
{
return _UpdHumId;
}
if (name == "UPDHUMNAME")
{
return _UpdHumName;
}
if (name == "UPDDATE")
{
return _UpdDate;
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
if (name == "MEMO")
{
return _Memo;
}
if (name == "OWNPROJID")
{
return _OwnProjId;
}
if (name == "OWNPROJNAME")
{
return _OwnProjName;
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
if (name == "LONGCODE")
{
 _LongCode = System.Convert.ToString(value);return;
}
if (name == "SUBTYPE")
{
 _SubType = System.Convert.ToString(value);return;
}
if (name == "PARENTID")
{
 _ParentId = XCode.Common.Helper.ConvertToGuid(value);return;
}
if (name == "CODE")
{
 _Code = System.Convert.ToString(value);return;
}
if (name == "NAME")
{
 _Name = System.Convert.ToString(value);return;
}
if (name == "SHORTNAME")
{
 _ShortName = System.Convert.ToString(value);return;
}
if (name == "LEGALPERSON")
{
 _LegalPerson = System.Convert.ToString(value);return;
}
if (name == "TAXCODE")
{
 _TaxCode = System.Convert.ToString(value);return;
}
if (name == "WEBSITE")
{
 _WebSite = System.Convert.ToString(value);return;
}
if (name == "FAX")
{
 _Fax = System.Convert.ToString(value);return;
}
if (name == "PHONE")
{
 _Phone = System.Convert.ToString(value);return;
}
if (name == "EMAIL")
{
 _Email = System.Convert.ToString(value);return;
}
if (name == "ADDRESS")
{
 _Address = System.Convert.ToString(value);return;
}
if (name == "POSTCODE")
{
 _PostCode = System.Convert.ToString(value);return;
}
if (name == "MAINLINKER")
{
 _MainLinker = System.Convert.ToString(value);return;
}
if (name == "ROLETYPE")
{
 _RoleType = System.Convert.ToSByte(value);return;
}
if (name == "VALIDDATE")
{
 if (value == null || value.ToString().IsNullOrEmpty() == true) value = DateTime.MinValue;
 _ValidDate = System.Convert.ToDateTime(value);return;
}
if (name == "BANKNAME")
{
 _BankName = System.Convert.ToString(value);return;
}
if (name == "BANKACCOUNT")
{
 _BankAccount = System.Convert.ToString(value);return;
}
if (name == "BANKADDRESS")
{
 _BankAddress = System.Convert.ToString(value);return;
}
if (name == "ISLONGLIST")
{
 _IsLongList = System.Convert.ToString(value);return;
}
if (name == "SOURCEORGANIZEID")
{
 _SourceOrganizeId = XCode.Common.Helper.ConvertToGuid(value);return;
}
if (name == "TABLENAME")
{
 _TableName = System.Convert.ToString(value);return;
}
if (name == "BIZAREAID")
{
 _BizAreaId = XCode.Common.Helper.ConvertToGuid(value);return;
}
if (name == "SEQU")
{
 _Sequ = System.Convert.ToInt32(value);return;
}
if (name == "STATUS")
{
 _Status = System.Convert.ToSByte(value);return;
}
if (name == "REGHUMID")
{
 _RegHumId = XCode.Common.Helper.ConvertToGuid(value);return;
}
if (name == "REGHUMNAME")
{
 _RegHumName = System.Convert.ToString(value);return;
}
if (name == "REGDATE")
{
 if (value == null || value.ToString().IsNullOrEmpty() == true) value = DateTime.MinValue;
 _RegDate = System.Convert.ToDateTime(value);return;
}
if (name == "REGPOSIID")
{
 _RegPosiId = XCode.Common.Helper.ConvertToGuid(value);return;
}
if (name == "REGDEPTID")
{
 _RegDeptId = XCode.Common.Helper.ConvertToGuid(value);return;
}
if (name == "EPSPROJID")
{
 _EpsProjId = XCode.Common.Helper.ConvertToGuid(value);return;
}
if (name == "RECYCLEHUMID")
{
 _RecycleHumId = XCode.Common.Helper.ConvertToGuid(value);return;
}
if (name == "UPDHUMID")
{
 _UpdHumId = XCode.Common.Helper.ConvertToGuid(value);return;
}
if (name == "UPDHUMNAME")
{
 _UpdHumName = System.Convert.ToString(value);return;
}
if (name == "UPDDATE")
{
 if (value == null || value.ToString().IsNullOrEmpty() == true) value = DateTime.MinValue;
 _UpdDate = System.Convert.ToDateTime(value);return;
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
if (name == "MEMO")
{
 _Memo = System.Convert.ToString(value);return;
}
if (name == "OWNPROJID")
{
 _OwnProjId = XCode.Common.Helper.ConvertToGuid(value);return;
}
if (name == "OWNPROJNAME")
{
 _OwnProjName = System.Convert.ToString(value);return;
}

			    base[name] = value;
			}
		}
		#endregion
	}
}