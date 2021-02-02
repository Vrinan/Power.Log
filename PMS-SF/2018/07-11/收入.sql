--����ȷ�ϱ�
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
	YearMonth datetime null,--����
	AmountType nvarchar(100) null,--�������
	ContractMoney float null,--��ͬ���
	ContractChangeMoney float null,--��ͬ������
	FinalContractMoney float null,--������ͬ���
	ContractGetAmount float null,--��ͬ����
	BudgetCost float null,--Ԥ��ɱ�
	BudgetRate float null,--Ԥ��ë����
	WorkCost float null,--����ʩ����ͬ�ɱ���540101��
	ProduceCost float null,--Ĥϵͳ�����ɱ���500103��
	Rate float null,--С��
	MonthSchedule float null,--���½���
	MonthGetAmount float null,--��������
	MonthRate float null,--����ë��
) 


select * from SF_OpenBidding_dtl where IsBid <> '1' and BiddingHuman not like '%����%'


--��ͬ���
select * from PS_MK_ContractInfo
select a.EPSProjectId, b.TotalAmount from PS_MK_ContractInfo a left join SF_Contract_AmountList b on a.Id = b.MasterId where a.Status=50 and b.AmountType='02'

--������
select * from PS_CM_ContractChange
select c.*,d.AmountType,d.TotalAmount from PS_CM_ContractChange c left join SF_Contract_AmountList d on c.Id = d.MasterId

select a.EPSProjectId,a.ContractName,b.AmountType,b.TotalAmount,e.TotalAmount,e.Title from PS_MK_ContractInfo a left join SF_Contract_AmountList b on a.Id = b.MasterId 
left join
(
select c.*,d.TotalAmount from PS_CM_ContractChange c left join SF_Contract_AmountList d on c.Id = d.MasterId
) e on e.Contract_Guid = a.Id
where a.Status=50 and b.AmountType='02'