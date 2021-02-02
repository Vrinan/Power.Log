 
 
 using System;
 using System.Collections.Generic;
 using System.Collections;
 using System.Text; 
 using System.Linq;
 using XCode.Attributes;
 using Power.Business.ViewEntity;
 using Power.Business.Attributes;
 using XCode.DataAccessLayer;

  namespace Power.Systems.StdMarket.StdMarket
{ 

    /// <summary>
    /// 项目跟踪评论数
    /// </summary>
  
    public partial class V_PS_ProjectInfoView : V_PS_ProjectInfoView<V_PS_ProjectInfoView>
    {

    }

    /// <summary>
    /// 项目跟踪评论数
    /// </summary> 
	
	 [BindViewEntityConfig(KeyWord = "V_PS_ProjectInfo",BusinessKeyWord = "",ViewEntityType = Power.Business.Attributes.EViewEntityType.SQLView, Description = "项目跟踪评论数")]
 [BindIndex(Name = "pk_View", KeyType = Power.DataAccessLayer.KeyType.MainKey, Columns = "Id" ,Description="")]

    public partial class V_PS_ProjectInfoView<TViewEntity> : ViewEntity<TViewEntity> where TViewEntity : IViewEntity, new()
    {
	
	  #region 属性

	    
 private System.Guid _FollowDeptId;
 /// <summary>
 /// FollowDeptId
 /// </summary>
 [BindColumn(0, "PMPI", "FollowDeptId","FollowDeptId",null ) ]
 public System.Guid FollowDeptId  { get { return _FollowDeptId; } set { _FollowDeptId = value; } }

 private System.Double _ForcastContractAmount;
 /// <summary>
 /// ForcastContractAmount
 /// </summary>
 [BindColumn(0, "PMPI", "ForcastContractAmount","ForcastContractAmount",null ) ]
 public System.Double ForcastContractAmount  { get { return _ForcastContractAmount; } set { _ForcastContractAmount = value; } }

 private System.String _ProjectType;
 /// <summary>
 /// ProjectType
 /// </summary>
 [BindColumn(0, "PMPI", "ProjectType","ProjectType",null ) ]
 public System.String ProjectType  { get { return _ProjectType; } set { _ProjectType = value; } }

 private System.String _ProjectName;
 /// <summary>
 /// ProjectName
 /// </summary>
 [BindColumn(0, "PMPI", "ProjectName","ProjectName",null ) ]
 public System.String ProjectName  { get { return _ProjectName; } set { _ProjectName = value; } }

 private System.String _reviewStatus;
 /// <summary>
 /// reviewStatus
 /// </summary>
 [BindColumn(0, "PMPI", "reviewStatus","reviewStatus",null ) ]
 public System.String reviewStatus  { get { return _reviewStatus; } set { _reviewStatus = value; } }

 private System.Int32 _comentnum;
 /// <summary>
 /// comentnum
 /// </summary>
 [BindColumn(0, "PMPI", "comentnum","comentnum",null ) ]
 public System.Int32 comentnum  { get { return _comentnum; } set { _comentnum = value; } }

 private System.String _InfoSources;
 /// <summary>
 /// InfoSources
 /// </summary>
 [BindColumn(0, "PMPI", "InfoSources","InfoSources",null ) ]
 public System.String InfoSources  { get { return _InfoSources; } set { _InfoSources = value; } }

 private System.Int32 _isFollow;
 /// <summary>
 /// isFollow
 /// </summary>
 [BindColumn(0, "PMPI", "isFollow","isFollow",null ) ]
 public System.Int32 isFollow  { get { return _isFollow; } set { _isFollow = value; } }

 private System.String _BidResult;
 /// <summary>
 /// BidResult
 /// </summary>
 [BindColumn(0, "PMPI", "BidResult","BidResult",null ) ]
 public System.String BidResult  { get { return _BidResult; } set { _BidResult = value; } }

 private System.String _ProjectLocation;
 /// <summary>
 /// ProjectLocation
 /// </summary>
 [BindColumn(0, "PMPI", "ProjectLocation","ProjectLocation",null ) ]
 public System.String ProjectLocation  { get { return _ProjectLocation; } set { _ProjectLocation = value; } }

 private System.Byte _Status;
 /// <summary>
 /// Status
 /// </summary>
 [BindColumn(0, "PMPI", "Status","Status",null ) ]
 public System.Byte Status  { get { return _Status; } set { _Status = value; } }

 private System.Decimal _ProjectInvestAmount;
 /// <summary>
 /// ProjectInvestAmount
 /// </summary>
 [BindColumn(0, "PMPI", "ProjectInvestAmount","ProjectInvestAmount",null ) ]
 public System.Decimal ProjectInvestAmount  { get { return _ProjectInvestAmount; } set { _ProjectInvestAmount = value; } }

 private System.DateTime _UpdDate;
 /// <summary>
 /// UpdDate
 /// </summary>
 [BindColumn(0, "PMPI", "UpdDate","UpdDate",null ) ]
 public System.DateTime UpdDate  { get { return _UpdDate; } set { _UpdDate = value; } }

 private System.Guid _Id;
 /// <summary>
 /// Id
 /// </summary>
 [BindColumn(0, "PMPI", "Id","Id",null,IsPrimaryKey =true ,IsIdentity =true  ) ]
 public System.Guid Id  { get { return _Id; } set { _Id = value; } }

 private System.String _FollowDept;
 /// <summary>
 /// FollowDept
 /// </summary>
 [BindColumn(0, "PMPI", "FollowDept","FollowDept",null ) ]
 public System.String FollowDept  { get { return _FollowDept; } set { _FollowDept = value; } }

 private System.String _ProjectArea;
 /// <summary>
 /// ProjectArea
 /// </summary>
 [BindColumn(0, "PMPI", "ProjectArea","ProjectArea",null ) ]
 public System.String ProjectArea  { get { return _ProjectArea; } set { _ProjectArea = value; } }

 private System.DateTime _ApprDate;
 /// <summary>
 /// ApprDate
 /// </summary>
 [BindColumn(0, "PMPI", "ApprDate","ApprDate",null ) ]
 public System.DateTime ApprDate  { get { return _ApprDate; } set { _ApprDate = value; } }

 private System.String _CommentText;
 /// <summary>
 /// CommentText
 /// </summary>
 [BindColumn(0, "PMPI", "CommentText","CommentText",null ) ]
 public System.String CommentText  { get { return _CommentText; } set { _CommentText = value; } }

 private System.Byte _isBid;
 /// <summary>
 /// isBid
 /// </summary>
 [BindColumn(0, "PMPI", "isBid","isBid",null ) ]
 public System.Byte isBid  { get { return _isBid; } set { _isBid = value; } }

 private System.DateTime _PrequalificationDeadline;
 /// <summary>
 /// PrequalificationDeadline
 /// </summary>
 [BindColumn(0, "PMPI", "PrequalificationDeadline","PrequalificationDeadline",null ) ]
 public System.DateTime PrequalificationDeadline  { get { return _PrequalificationDeadline; } set { _PrequalificationDeadline = value; } }

 private System.String _FollowLevel;
 /// <summary>
 /// FollowLevel
 /// </summary>
 [BindColumn(0, "PMPI", "FollowLevel","FollowLevel",null ) ]
 public System.String FollowLevel  { get { return _FollowLevel; } set { _FollowLevel = value; } }

 private System.String _ProjectShortName;
 /// <summary>
 /// ProjectShortName
 /// </summary>
 [BindColumn(0, "PMPI", "ProjectShortName","ProjectShortName",null ) ]
 public System.String ProjectShortName  { get { return _ProjectShortName; } set { _ProjectShortName = value; } }

 private System.Guid _ApprHumId;
 /// <summary>
 /// ApprHumId
 /// </summary>
 [BindColumn(0, "PMPI", "ApprHumId","ApprHumId",null ) ]
 public System.Guid ApprHumId  { get { return _ApprHumId; } set { _ApprHumId = value; } }

 private System.String _TenderType;
 /// <summary>
 /// TenderType
 /// </summary>
 [BindColumn(0, "PMPI", "TenderType","TenderType",null ) ]
 public System.String TenderType  { get { return _TenderType; } set { _TenderType = value; } }

 private System.Guid _OwnProjId;
 /// <summary>
 /// OwnProjId
 /// </summary>
 [BindColumn(0, "PMPI", "OwnProjId","OwnProjId",null ) ]
 public System.Guid OwnProjId  { get { return _OwnProjId; } set { _OwnProjId = value; } }

 private System.String _FollowStatus;
 /// <summary>
 /// FollowStatus
 /// </summary>
 [BindColumn(0, "PMPI", "FollowStatus","FollowStatus",null ) ]
 public System.String FollowStatus  { get { return _FollowStatus; } set { _FollowStatus = value; } }

 private System.String _FollowHuman;
 /// <summary>
 /// FollowHuman
 /// </summary>
 [BindColumn(0, "PMPI", "FollowHuman","FollowHuman",null ) ]
 public System.String FollowHuman  { get { return _FollowHuman; } set { _FollowHuman = value; } }

 private System.Int32 _isPrequalification;
 /// <summary>
 /// isPrequalification
 /// </summary>
 [BindColumn(0, "PMPI", "isPrequalification","isPrequalification",null ) ]
 public System.Int32 isPrequalification  { get { return _isPrequalification; } set { _isPrequalification = value; } }

 private System.String _ApprHumName;
 /// <summary>
 /// ApprHumName
 /// </summary>
 [BindColumn(0, "PMPI", "ApprHumName","ApprHumName",null ) ]
 public System.String ApprHumName  { get { return _ApprHumName; } set { _ApprHumName = value; } }

 private System.Guid _FollowHumanId;
 /// <summary>
 /// FollowHumanId
 /// </summary>
 [BindColumn(0, "PMPI", "FollowHumanId","FollowHumanId",null ) ]
 public System.Guid FollowHumanId  { get { return _FollowHumanId; } set { _FollowHumanId = value; } }

 private System.String _ContractType;
 /// <summary>
 /// ContractType
 /// </summary>
 [BindColumn(0, "PMPI", "ContractType","ContractType",null ) ]
 public System.String ContractType  { get { return _ContractType; } set { _ContractType = value; } }

 private System.DateTime _FollowDate;
 /// <summary>
 /// FollowDate
 /// </summary>
 [BindColumn(0, "PMPI", "FollowDate","FollowDate",null ) ]
 public System.DateTime FollowDate  { get { return _FollowDate; } set { _FollowDate = value; } }

 private System.String _CurrencyType;
 /// <summary>
 /// CurrencyType
 /// </summary>
 [BindColumn(0, "PMPI", "CurrencyType","CurrencyType",null ) ]
 public System.String CurrencyType  { get { return _CurrencyType; } set { _CurrencyType = value; } }

 private System.String _OwnProjName;
 /// <summary>
 /// OwnProjName
 /// </summary>
 [BindColumn(0, "PMPI", "OwnProjName","OwnProjName",null ) ]
 public System.String OwnProjName  { get { return _OwnProjName; } set { _OwnProjName = value; } }

 private System.Guid _RegHumId;
 /// <summary>
 /// RegHumId
 /// </summary>
 [BindColumn(0, "PMPI", "RegHumId","RegHumId",null ) ]
 public System.Guid RegHumId  { get { return _RegHumId; } set { _RegHumId = value; } }

 private System.Guid _UpdHumId;
 /// <summary>
 /// UpdHumId
 /// </summary>
 [BindColumn(0, "PMPI", "UpdHumId","UpdHumId",null ) ]
 public System.Guid UpdHumId  { get { return _UpdHumId; } set { _UpdHumId = value; } }

 private System.String _RegHumName;
 /// <summary>
 /// RegHumName
 /// </summary>
 [BindColumn(0, "PMPI", "RegHumName","RegHumName",null ) ]
 public System.String RegHumName  { get { return _RegHumName; } set { _RegHumName = value; } }

 private System.String _ProjectId;
 /// <summary>
 /// ProjectId
 /// </summary>
 [BindColumn(0, "PMPI", "ProjectId","ProjectId",null ) ]
 public System.String ProjectId  { get { return _ProjectId; } set { _ProjectId = value; } }

 private System.Guid _Client_Guid;
 /// <summary>
 /// Client_Guid
 /// </summary>
 [BindColumn(0, "PMPI", "Client_Guid","Client_Guid",null ) ]
 public System.Guid Client_Guid  { get { return _Client_Guid; } set { _Client_Guid = value; } }

 private System.DateTime _RegDate;
 /// <summary>
 /// RegDate
 /// </summary>
 [BindColumn(0, "PMPI", "RegDate","RegDate",null ) ]
 public System.DateTime RegDate  { get { return _RegDate; } set { _RegDate = value; } }

 private System.Guid _EpsProjId;
 /// <summary>
 /// EpsProjId
 /// </summary>
 [BindColumn(0, "PMPI", "EpsProjId","EpsProjId",null ) ]
 public System.Guid EpsProjId  { get { return _EpsProjId; } set { _EpsProjId = value; } }

 private System.String _ProjectSize;
 /// <summary>
 /// ProjectSize
 /// </summary>
 [BindColumn(0, "PMPI", "ProjectSize","ProjectSize",null ) ]
 public System.String ProjectSize  { get { return _ProjectSize; } set { _ProjectSize = value; } }

 private System.String _SourcesOfFunds;
 /// <summary>
 /// SourcesOfFunds
 /// </summary>
 [BindColumn(0, "PMPI", "SourcesOfFunds","SourcesOfFunds",null ) ]
 public System.String SourcesOfFunds  { get { return _SourcesOfFunds; } set { _SourcesOfFunds = value; } }

 private System.String _ProductType;
 /// <summary>
 /// ProductType
 /// </summary>
 [BindColumn(0, "PMPI", "ProductType","ProductType",null ) ]
 public System.String ProductType  { get { return _ProductType; } set { _ProductType = value; } }

 private System.String _UpdHuman;
 /// <summary>
 /// UpdHuman
 /// </summary>
 [BindColumn(0, "PMPI", "UpdHuman","UpdHuman",null ) ]
 public System.String UpdHuman  { get { return _UpdHuman; } set { _UpdHuman = value; } }

 private System.Guid _SaleClue_Guid;
 /// <summary>
 /// SaleClue_Guid
 /// </summary>
 [BindColumn(0, "PMPI", "SaleClue_Guid","SaleClue_Guid",null ) ]
 public System.Guid SaleClue_Guid  { get { return _SaleClue_Guid; } set { _SaleClue_Guid = value; } }

      
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
			    if (name == "FOLLOWDEPTID")
{
return _FollowDeptId;
}
if (name == "FORCASTCONTRACTAMOUNT")
{
return _ForcastContractAmount;
}
if (name == "PROJECTTYPE")
{
return _ProjectType;
}
if (name == "PROJECTNAME")
{
return _ProjectName;
}
if (name == "REVIEWSTATUS")
{
return _reviewStatus;
}
if (name == "COMENTNUM")
{
return _comentnum;
}
if (name == "INFOSOURCES")
{
return _InfoSources;
}
if (name == "ISFOLLOW")
{
return _isFollow;
}
if (name == "BIDRESULT")
{
return _BidResult;
}
if (name == "PROJECTLOCATION")
{
return _ProjectLocation;
}
if (name == "STATUS")
{
return _Status;
}
if (name == "PROJECTINVESTAMOUNT")
{
return _ProjectInvestAmount;
}
if (name == "UPDDATE")
{
return _UpdDate;
}
if (name == "ID")
{
return _Id;
}
if (name == "FOLLOWDEPT")
{
return _FollowDept;
}
if (name == "PROJECTAREA")
{
return _ProjectArea;
}
if (name == "APPRDATE")
{
return _ApprDate;
}
if (name == "COMMENTTEXT")
{
return _CommentText;
}
if (name == "ISBID")
{
return _isBid;
}
if (name == "PREQUALIFICATIONDEADLINE")
{
return _PrequalificationDeadline;
}
if (name == "FOLLOWLEVEL")
{
return _FollowLevel;
}
if (name == "PROJECTSHORTNAME")
{
return _ProjectShortName;
}
if (name == "APPRHUMID")
{
return _ApprHumId;
}
if (name == "TENDERTYPE")
{
return _TenderType;
}
if (name == "OWNPROJID")
{
return _OwnProjId;
}
if (name == "FOLLOWSTATUS")
{
return _FollowStatus;
}
if (name == "FOLLOWHUMAN")
{
return _FollowHuman;
}
if (name == "ISPREQUALIFICATION")
{
return _isPrequalification;
}
if (name == "APPRHUMNAME")
{
return _ApprHumName;
}
if (name == "FOLLOWHUMANID")
{
return _FollowHumanId;
}
if (name == "CONTRACTTYPE")
{
return _ContractType;
}
if (name == "FOLLOWDATE")
{
return _FollowDate;
}
if (name == "CURRENCYTYPE")
{
return _CurrencyType;
}
if (name == "OWNPROJNAME")
{
return _OwnProjName;
}
if (name == "REGHUMID")
{
return _RegHumId;
}
if (name == "UPDHUMID")
{
return _UpdHumId;
}
if (name == "REGHUMNAME")
{
return _RegHumName;
}
if (name == "PROJECTID")
{
return _ProjectId;
}
if (name == "CLIENT_GUID")
{
return _Client_Guid;
}
if (name == "REGDATE")
{
return _RegDate;
}
if (name == "EPSPROJID")
{
return _EpsProjId;
}
if (name == "PROJECTSIZE")
{
return _ProjectSize;
}
if (name == "SOURCESOFFUNDS")
{
return _SourcesOfFunds;
}
if (name == "PRODUCTTYPE")
{
return _ProductType;
}
if (name == "UPDHUMAN")
{
return _UpdHuman;
}
if (name == "SALECLUE_GUID")
{
return _SaleClue_Guid;
}

			    return base[name];
			}
			set 
			{
			   name = name.ToUpper();
			       if (name == "FOLLOWDEPTID")
{
 _FollowDeptId = XCode.Common.Helper.ConvertToGuid(value);return;
}
if (name == "FORCASTCONTRACTAMOUNT")
{
 _ForcastContractAmount = System.Convert.ToDouble(value);return;
}
if (name == "PROJECTTYPE")
{
 _ProjectType = System.Convert.ToString(value);return;
}
if (name == "PROJECTNAME")
{
 _ProjectName = System.Convert.ToString(value);return;
}
if (name == "REVIEWSTATUS")
{
 _reviewStatus = System.Convert.ToString(value);return;
}
if (name == "COMENTNUM")
{
 _comentnum = System.Convert.ToInt32(value);return;
}
if (name == "INFOSOURCES")
{
 _InfoSources = System.Convert.ToString(value);return;
}
if (name == "ISFOLLOW")
{
 _isFollow = System.Convert.ToInt32(value);return;
}
if (name == "BIDRESULT")
{
 _BidResult = System.Convert.ToString(value);return;
}
if (name == "PROJECTLOCATION")
{
 _ProjectLocation = System.Convert.ToString(value);return;
}
if (name == "STATUS")
{
 _Status = System.Convert.ToByte(value);return;
}
if (name == "PROJECTINVESTAMOUNT")
{
 _ProjectInvestAmount = System.Convert.ToDecimal(value);return;
}
if (name == "UPDDATE")
{
 if (value == null || value.ToString().IsNullOrEmpty() == true) value = DateTime.MinValue;
 _UpdDate = System.Convert.ToDateTime(value);return;
}
if (name == "ID")
{
 _Id = XCode.Common.Helper.ConvertToGuid(value);return;
}
if (name == "FOLLOWDEPT")
{
 _FollowDept = System.Convert.ToString(value);return;
}
if (name == "PROJECTAREA")
{
 _ProjectArea = System.Convert.ToString(value);return;
}
if (name == "APPRDATE")
{
 if (value == null || value.ToString().IsNullOrEmpty() == true) value = DateTime.MinValue;
 _ApprDate = System.Convert.ToDateTime(value);return;
}
if (name == "COMMENTTEXT")
{
 _CommentText = System.Convert.ToString(value);return;
}
if (name == "ISBID")
{
 _isBid = System.Convert.ToByte(value);return;
}
if (name == "PREQUALIFICATIONDEADLINE")
{
 if (value == null || value.ToString().IsNullOrEmpty() == true) value = DateTime.MinValue;
 _PrequalificationDeadline = System.Convert.ToDateTime(value);return;
}
if (name == "FOLLOWLEVEL")
{
 _FollowLevel = System.Convert.ToString(value);return;
}
if (name == "PROJECTSHORTNAME")
{
 _ProjectShortName = System.Convert.ToString(value);return;
}
if (name == "APPRHUMID")
{
 _ApprHumId = XCode.Common.Helper.ConvertToGuid(value);return;
}
if (name == "TENDERTYPE")
{
 _TenderType = System.Convert.ToString(value);return;
}
if (name == "OWNPROJID")
{
 _OwnProjId = XCode.Common.Helper.ConvertToGuid(value);return;
}
if (name == "FOLLOWSTATUS")
{
 _FollowStatus = System.Convert.ToString(value);return;
}
if (name == "FOLLOWHUMAN")
{
 _FollowHuman = System.Convert.ToString(value);return;
}
if (name == "ISPREQUALIFICATION")
{
 _isPrequalification = System.Convert.ToInt32(value);return;
}
if (name == "APPRHUMNAME")
{
 _ApprHumName = System.Convert.ToString(value);return;
}
if (name == "FOLLOWHUMANID")
{
 _FollowHumanId = XCode.Common.Helper.ConvertToGuid(value);return;
}
if (name == "CONTRACTTYPE")
{
 _ContractType = System.Convert.ToString(value);return;
}
if (name == "FOLLOWDATE")
{
 if (value == null || value.ToString().IsNullOrEmpty() == true) value = DateTime.MinValue;
 _FollowDate = System.Convert.ToDateTime(value);return;
}
if (name == "CURRENCYTYPE")
{
 _CurrencyType = System.Convert.ToString(value);return;
}
if (name == "OWNPROJNAME")
{
 _OwnProjName = System.Convert.ToString(value);return;
}
if (name == "REGHUMID")
{
 _RegHumId = XCode.Common.Helper.ConvertToGuid(value);return;
}
if (name == "UPDHUMID")
{
 _UpdHumId = XCode.Common.Helper.ConvertToGuid(value);return;
}
if (name == "REGHUMNAME")
{
 _RegHumName = System.Convert.ToString(value);return;
}
if (name == "PROJECTID")
{
 _ProjectId = System.Convert.ToString(value);return;
}
if (name == "CLIENT_GUID")
{
 _Client_Guid = XCode.Common.Helper.ConvertToGuid(value);return;
}
if (name == "REGDATE")
{
 if (value == null || value.ToString().IsNullOrEmpty() == true) value = DateTime.MinValue;
 _RegDate = System.Convert.ToDateTime(value);return;
}
if (name == "EPSPROJID")
{
 _EpsProjId = XCode.Common.Helper.ConvertToGuid(value);return;
}
if (name == "PROJECTSIZE")
{
 _ProjectSize = System.Convert.ToString(value);return;
}
if (name == "SOURCESOFFUNDS")
{
 _SourcesOfFunds = System.Convert.ToString(value);return;
}
if (name == "PRODUCTTYPE")
{
 _ProductType = System.Convert.ToString(value);return;
}
if (name == "UPDHUMAN")
{
 _UpdHuman = System.Convert.ToString(value);return;
}
if (name == "SALECLUE_GUID")
{
 _SaleClue_Guid = XCode.Common.Helper.ConvertToGuid(value);return;
}

			    base[name] = value;
			}
		}
		#endregion

		#region 辅助
		  public override  SelectBuilder ViewSQL { 
			 get 
			 {
				 if (_ViewSQL != null) return _ViewSQL;
SelectBuilder sSql = new SelectBuilder();
sSql.Column = @"*";
sSql.Table = @"V_PS_MK_ProjectInfo PMPI";
sSql.OrderBy = "Id";
 _ViewSQL = sSql; return _ViewSQL;   
			 }
	     }
		#endregion
	}
}