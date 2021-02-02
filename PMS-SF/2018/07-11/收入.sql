--收入确认表
CREATE TABLE SF_FK_RevenueRecognition(
	[Id] [uniqueidentifier] NOT NULL,
	[Code] [nvarchar](200) NULL,
	[Title] [nvarchar](200) NULL,
	EpsProjectId uniqueidentifier null,
	EpsProjectName nvarchar(100) null,
	YearMonth datetime null,
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
	[ParentId] [uniqueidentifier] NULL
)

CREATE TABLE SF_FK_RevenueRecognition_dtl(
	[Id] [uniqueidentifier] NOT NULL,
	[MasterId] [uniqueidentifier] NULL,
	[UpdDate] [datetime] NULL,
	[Memo] [nvarchar](4000) NULL,
	[Sequ] [int] null,
	YearMonth datetime null,--年月
	AmountType nvarchar(100) null,--收入类别
	ContractMoney float null,--合同金额
	ContractChangeMoney float null,--合同变更金额
	FinalContractMoney float null,--变更后合同金额
	ContractGetAmount float null,--合同收入
	BudgetCost float null,--预算成本
	BudgetRate float null,--预算毛利率
	WorkCost float null,--工程施工合同成本（540101）
	ProduceCost float null,--膜系统生产成本（500103）
	Rate float null,--小计
	MonthSchedule float null,--本月进度
	MonthGetAmount float null,--本月收入
	MonthRate float null,--本月毛利
) 


select * from SF_OpenBidding_dtl where IsBid <> '1' and BiddingHuman not like '%三峰%'


--合同金额
select * from PS_MK_ContractInfo
select a.EPSProjectId, b.TotalAmount from PS_MK_ContractInfo a left join SF_Contract_AmountList b on a.Id = b.MasterId where a.Status=50 and b.AmountType='02'

--变更金额
select * from PS_CM_ContractChange
select c.*,d.AmountType,d.TotalAmount from PS_CM_ContractChange c left join SF_Contract_AmountList d on c.Id = d.MasterId

select a.EPSProjectId,a.ContractName,b.AmountType,b.TotalAmount,e.TotalAmount,e.Title from PS_MK_ContractInfo a left join SF_Contract_AmountList b on a.Id = b.MasterId 
left join
(
select c.*,d.TotalAmount from PS_CM_ContractChange c left join SF_Contract_AmountList d on c.Id = d.MasterId
) e on e.Contract_Guid = a.Id
where a.Status=50 and b.AmountType='02'