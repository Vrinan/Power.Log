--Ͷ�걣֤������
Create table SF_BiddingPrRecord
(
	Id uniqueidentifier not null,
	Code nvarchar(100) null,
	Title nvarchar(100) null,
	ProjId uniqueidentifier null,--ProjectInfo_Guid
	ClientName nvarchar(100) null,
	BidReviewId uniqueidentifier null
)
--alter table SF_BiddingPrRecord drop column ClientId
--alter table SF_BiddingPrRecord add ClientName nvarchar(100) null
--exec sp_rename 'BiddingPrRecord','SF_BiddingPrRecord'
--���
--ProjCode
--ProjName
--ProjSize
--BidReviewName
--BidReviewCode

--Ͷ���ļ�����
select * from PS_MK_isBidReview

--�������
Create table SF_OpenBidding
(
	Id uniqueidentifier not null,
	Code nvarchar(100) null,
	Title nvarchar(100) null,
	OpenBiddingDate datetime null,
	BiddingCode nvarchar(100) null,
	BiddingHuman nvarchar(100) null,
	BiddingHumanId uniqueidentifier null,
	Agencies nvarchar(100) null,
	BiddingAamount float null,
	scale float null,
	BiddingType nvarchar(10) null,
	PriceRating nvarchar(10) null,
	ProjId uniqueidentifier null,
	ClientName nvarchar(100) null
)
--���
--ProjCode
--ProjName
Create table SF_OpenBidding_dtl
(
	Id uniqueidentifier not null,
	MasterId uniqueidentifier null,
	BiddingHuman nvarchar(100) null,
	BiddingHumanId uniqueidentifier null,
	Score float null,
	BiddingRank int null,
	TotalQuotation float null,
	EquipmentQuotation float null,
	InstallationQuotation float null,
	BuildingQuotation float null,
	DesignQuotation float null,
	TestQuotation float null,
	OperationsQuotation float null,
	Memo nvarchar(500) null
)