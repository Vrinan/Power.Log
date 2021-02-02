--财务、费用
--费用工作接待申请
CREATE TABLE SF_FK_Reception(
	[Id] [uniqueidentifier] NOT NULL,
	[Code] [nvarchar](200) NULL,
	[Title] [nvarchar](200) NULL,
	ApplicantHuman nvarchar(100) null,--申请人
	ApplicantHumanId uniqueidentifier null,--申请人Id
	DeptName nvarchar(100) null,
	DeptId uniqueidentifier null,
	ApplicantDate datetime null,
	ReceptionType nvarchar(100) null,--接待类型（公务/商务）
	ReceptionReason nvarchar(500) null,--接待事由
	Amount float null,
	MatterDescription nvarchar(500) null,--事项说明
	ReceptionObject nvarchar(100) null,--接待对象
	PeopleAmount int null,
	MeetingTime datetime null,--用餐时间
	MeetType nvarchar(100) null,--用餐类型
	MenuDtl nvarchar(100) null,--菜单明细
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
	[Memo] [nvarchar](1000) NULL
)
--费用报销
CREATE TABLE SF_FK_Reimbursement(
	[Id] [uniqueidentifier] NOT NULL,
	[Code] [nvarchar](200) NULL,
	[Title] [nvarchar](200) NULL,
	ApplicationHuman nvarchar(100) null,--申请人
	ApplicationHumanId uniqueidentifier null,--申请人Id
	DeptName nvarchar(100) null,
	DeptId uniqueidentifier null,
	PartyBName nvarchar(500) null,--对方单位名称
	PartyBBank nvarchar(500) null,--开户行
	PartyBBankCode nvarchar(500) null,--帐号
	Amount float null,
	MatterDescription nvarchar(500) null,--事项说明
	IsHSAmount nvarchar(100) null,--是否安全环保费
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
	[Memo] [nvarchar](1000) NULL
)
--保证金(保函)（业主）申请
CREATE TABLE SF_FK_MarginOwnerApply(
	[Id] [uniqueidentifier] NOT NULL,
	[Code] [nvarchar](200) NULL,
	[Title] [nvarchar](200) NULL,
	ContractCode nvarchar(100) null,--合同编号
	ContractId uniqueidentifier null,
	ApplyHuamn nvarchar(100) null,--申请人
	ApplyHumanId uniqueidentifier null,
	DeptName nvarchar(100) null,
	DeptId uniqueidentifier null,
	PartyBName nvarchar(500) null,--对方单位名称
	PartyBBank nvarchar(500) null,--开户行
	PartyBBankCode nvarchar(500) null,--帐号
	Amount float null,
	ApplyType nvarchar(100) null,--申请类型
	Clearing nvarchar(100) null,--结算方式
	MatterDescription nvarchar(500) null,--事项说明
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
	[Memo] [nvarchar](1000) NULL
)
alter table SF_FK_MarginOwnerApply add ContractName nvarchar(200) null
select * from SF_FK_MarginOwnerApply 
--保证金(保函)（业主）退还
alter table SF_FK_MarginOwnerReturn add ApplyType  nvarchar(100) null
CREATE TABLE SF_FK_MarginOwnerReturn(
	[Id] [uniqueidentifier] NOT NULL,
	[Code] [nvarchar](200) NULL,
	[Title] [nvarchar](200) NULL,

	MarginOwnerApplyId uniqueidentifier null,
	MarginOwnerApply nvarchar(100) null,--申请名称
	ContractId uniqueidentifier null,
	ContractName nvarchar(100) null,--合同名称
	ContractCode nvarchar(100) null,--合同编号
	ApplyAmount float null,--申请金额
	PartyBName nvarchar(500) null,--对方单位名称
	ApplyType nvarchar(100) null,--申请类型
	
	Manager nvarchar(100) null,--经办人
	ManagerId uniqueidentifier null,
	ReturnAmount float null,--退还金额
	ReturnDate datetime null,
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
	[Memo] [nvarchar](1000) NULL
)
--------------------------------------
--保证金(保函)（分包）登记
CREATE TABLE SF_FK_MarginSubcontractorApply(
	[Id] [uniqueidentifier] NOT NULL,
	[Code] [nvarchar](200) NULL,
	[Title] [nvarchar](200) NULL,
	MarginType nvarchar(100) null,--保证金类型（投标保证金（不显示合同）、履约保证金、履约保函、HSE保证金）
	ContractName nvarchar(100) null,--合同名称
	ContractCode nvarchar(100) null,--合同编号
	ContractId uniqueidentifier null,

	PartyBName nvarchar(100) null,--对方单位名称
	PartyBHuman nvarchar(100) null,--联系人
	PartyBPhone nvarchar(100) null,--联系电话
	ReturnAmount float null,
	Returndate datetime null,
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
	[Memo] [nvarchar](1000) NULL
)

--保证金(保函)（分包）退还
alter table SF_FK_MarginSubcontractorReturn drop column PartyBName
CREATE TABLE SF_FK_MarginSubcontractorReturn(
	[Id] [uniqueidentifier] NOT NULL,
	[Code] [nvarchar](200) NULL,
	[Title] [nvarchar](200) NULL,
	MarginSubcontractorApplyId uniqueidentifier null,
	--外键
	--MarginSubcontractorApplyCode保证金登记编号
	--MarginType款项类型
	--ContractName合同名称
	--ContractCode合同编号		
	ApplyHuman nvarchar(100) null,--申请人
	ApplyHumanId uniqueidentifier null,
	DeptName nvarchar(100) null,
	DeptId uniqueidentifier null,
	--PartyBName nvarchar(500) null,--对方单位名称
	PartyBBank nvarchar(500) null,--开户行
	PartyBBankCode nvarchar(500) null,--帐号
	Amount float null,
	Clearing nvarchar(100) null,--结算方式
	MatterDescription nvarchar(500) null,--事项说明
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
	[Memo] [nvarchar](1000) NULL
)
