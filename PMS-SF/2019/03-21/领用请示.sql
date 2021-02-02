--领用请示
CREATE TABLE SF_YX_Requisition(
	[Id] [uniqueidentifier] NOT NULL,
	[Code] [nvarchar](200) NULL,
	[Title] [nvarchar](200) NULL,
	[UpdHumId] [uniqueidentifier] NULL,
	[UpdHuman] [nvarchar](80) NULL,
	[UpdDate] [datetime] NULL,
	[RegDate] [datetime] NULL,
	[RegHumName] [nvarchar](80) NULL,
	[RegHumId] [uniqueidentifier] NULL,
	[OwnProjName] [nvarchar](255) NULL,
	[OwnProjId] [uniqueidentifier] NULL,
	[EpsProjId] [uniqueidentifier] NULL,
	[ApprHumId] [uniqueidentifier] NULL,
	[ApprHumName] [nvarchar](80) NULL,
	[ApprDate] [datetime] NULL,
	[Status] [tinyint] NULL,
	[Memo] [nvarchar](4000) NULL,

	[EpsProjectId] [uniqueidentifier] NULL,
	[EpsProjectCode] [nvarchar](200) NULL,
	[EpsProjectName] [nvarchar](200) NULL,
	--领用方式
	[RequisitionType] [nvarchar](100) NULL,--自提，快递，物流
	--需求时间
	RequisitionDate datetime null,
	--收货地址
	GetLocation nvarchar(500) null,
	--收货人
	GetPerson nvarchar(500) null,
	--联系电话
	ContractNum nvarchar(500) null
)

CREATE TABLE SF_YX_Requisition_dtl(
	[Id] [uniqueidentifier] NOT NULL,
	[MasterId] [uniqueidentifier] NULL,
	[Code] [nvarchar](200) NULL,
	[Name] [nvarchar](500) NULL,
	Spec [nvarchar](2000) NULL,
	Unit [nvarchar](500) NULL,
	Amount numeric(18,2) null,
	[Memo] [nvarchar](500) NULL,
	[Sequ] [int] NULL,
	[UpdDate] [datetime] NULL,
)


select * from PB_Widget where Id='c56cea22-6dcd-46a7-bceb-57e26ddfb4db'

alter table SF_YX_Requisition add EstimatedAmount numeric(18,2) null
--EpsProjectName
--EPSProjectName

--dt1
select dbo.GetBaseData('RequisitionType',RequisitionType) as RequisitionTypes , CONVERT(varchar(100), RequisitionDate, 23) as RequisitionDates, * from SF_YX_Requisition where Id='[@KeyValue]'
select  ROW_NUMBER() OVER(ORDER BY Sequ ASC) as rowNo, * from SF_YX_Requisition_dtl where MasterId='[@KeyValue]'

select ROW_NUMBER() OVER(ORDER BY Sequ ASC) as rowNo,dbo.GetBaseData('PackageType',MatType) as MatType,MatName,MatSpec,
MatUnit,InStoreNum, convert(varchar,convert(money,UnitPriceNoTax),1) as UnitPrice,convert(varchar,convert(money,InStoreAmountNoTax),1)  as InStoreAmount
from PS_PUR_MatInStore_Dtl 
where MasterId='[@KeyValue]'  and MatType = '7'

select * from PB_Widget where Id='028f936c-7fda-44ee-b663-dc20c1ca754e'
--/PowerPlat/FormXml/zh-CN/SF_YX/Win_SF_YX_EquRecord_1==.htm


select * from PS_CM_SubContractInvoice where Code='FPDJ-190320-004'

update PS_CM_SubContractInvoice set Status=50 where Code='FPDJ-190320-004'