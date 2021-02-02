--SF_AnnualIndicators年度指标录入
select * from PB_Widget where id='c1149c24-4bfb-4bd1-a825-a1f6dc7c08c0'
--/PowerPlat/FormXml/zh-CN/StdBid/Win_PS_TenderPlan.htm
create table SF_AnnualIndicators
(
Id uniqueidentifier not null,
Code nvarchar(50) null,
Title nvarchar(50) null,
Amount float null,
Years datetime null
)
EXEC sp_rename 'AnnualIndicators','SF_AnnualIndicators'
select * from SF_AnnualIndicators
select * from PB_BaseData where name like '%年%'
--alter table SF_AnnualIndicators alter column Years nvarchar(50)
--AnnualMarketDev年度市场开发
create table SF_AnnualMarketDev
(
Id uniqueidentifier not null,
Code nvarchar(50) null,
Title nvarchar(50) null,
Amount float null,
Years datetime null
)
--alter table SF_AnnualMarketDev alter column Years nvarchar(50)
--客户登记
select * from PB_Widget where id='415381b5-1566-4e5b-8a59-527f7377ceca'
--/PowerPlat/FormXml/zh-CN/StdMarket/Organize.htm
--客户信息管理
--客户评价PS_MK_ClientEvaluation，缺少两个字段，选择用外键关联
--alter table PS_MK_ClientEvaluation add ProjectCode nvarchar(50) null
--alter table PS_MK_ClientEvaluation add ClientCode nvarchar(50) null
--alter table PS_MK_ClientEvaluation drop column ClientCode
select * from PB_Widget where id='318cf2c5-048b-400a-b30e-09e9536279e8'
--/PowerPlat/FormXml/zh-CN/StdMarket/ClientEvaluation.htm
--项目跟踪
select * from PB_Widget where id='029d6895-3186-4565-adc3-61919e3ab1ed'
--/PowerPlat/FormXml/zh-CN/StdMarket/ProjectInfo.htm
select * from PS_MK_ProjectInfo
--招标性质BiddingType
--资金来源AmountSourceType
--重要程度ImportantLev
--设计单位DesignName
--联系人ContractHuman
--项目负责人ProjOwner
--alter table PS_MK_ProjectInfo add BiddingType nvarchar(50) null
--alter table PS_MK_ProjectInfo add AmountSourceType nvarchar(50) null
--alter table PS_MK_ProjectInfo add ImportantLev nvarchar(50) null
--alter table PS_MK_ProjectInfo add DesignName nvarchar(50) null
--alter table PS_MK_ProjectInfo add ContractHuman nvarchar(50) null
--alter table PS_MK_ProjectInfo add ContractHumanId uniqueidentifier null
--alter table PS_MK_ProjectInfo add ProjOwner nvarchar(50) null

--alter table PS_MK_ProjectInfo add duty nvarchar(500) null
--alter table PS_MK_ProjectInfo add ContractNumber nvarchar(500) null
--alter table PS_MK_ProjectInfo add TimeAndAsk nvarchar(500) null
select * from PS_MK_ProjectInfo
select * from PS_MK_ProjectInfo 
--子表SF_schedule
--MasterId主表Id
--跟进进度schedule
--下步计划NextPlan
--跟进人FollowUpHuman
--备注Memo
--记录日期RegDate
--select * from SF_schedule
Create table SF_schedule(
Id uniqueidentifier not null,
MasterId uniqueidentifier null,
schedule nvarchar(200) null,
NextPlan nvarchar(200) null,
Memo nvarchar(200) null,
RegDate datetime null
) 
--alter table SF_schedule add FollowUpHuman nvarchar(100) null
--alter table SF_schedule add FollowUpHumanId uniqueidentifier null
--招标文件购买记录
select * from SF_FilesBoughtRecord
--delete from SF_FilesBoughtRecord where ProjId is null
--项目ProjId
--外间有ProjCode，ProjName，ProjSize
--做设计向导，用业务对象PS_ProjectInfo
--购买时间BoughtDate
--购买金额BoughtAmount
--购买说明BoughtMemo
--购买机构/单位BoughtPartyA
Create table SF_FilesBoughtRecord
(
Id uniqueidentifier not null,
ProjId uniqueidentifier null,
BoughtDate datetime null,
BoughtAmount float null,
BoughtMemo nvarchar(500),
BoughtPartyA nvarchar(500)
)
--alter table SF_FilesBoughtRecord add Code nvarchar(500) null
--alter table SF_FilesBoughtRecord add Title nvarchar(500) null
--alter table SF_FilesBoughtRecord add ProjCode nvarchar(500) null
--alter table SF_FilesBoughtRecord drop column ProjCode
--EXEC sp_rename 'FilesBoughtRecord','SF_FilesBoughtRecord'
select * from SF_FilesBoughtRecord

--招标文件评审
select * from SF_BiddingFiles
--delete from SF_BiddingFiles
Create table SF_BiddingFiles
(
Id uniqueidentifier not null,
Code nvarchar(500) null,
Title nvarchar(500) null,
ProjId uniqueidentifier null,
FilesBoughtRecordId uniqueidentifier null,
--ProjOwnId
--承揽额
ContractedAmount float null,
--业主信用
OwnsCredit nvarchar(50) null,
--招标文件编号
BiddingFilesCode nvarchar(500) null,
BiddingBegin datetime null,
BiddingEnd datetime null,
--招标模式
BiddingType nvarchar(50) null,
OpenBidding datetime null,
Duration int null
)
--alter table SF_BiddingFiles add ProjOwnId uniqueidentifier null
Create table SF_BiddingFiles_dtl
(
Id uniqueidentifier not null,
MasterId uniqueidentifier null,
LotContent nvarchar(500) null,
LotAmount float null,
Memo  nvarchar(500) null
)
--alter table SF_BiddingFiles_dtl add RegDate datetime null
select * from SF_BiddingFiles
--delete from SF_BiddingFiles

--风险评估
select * from PS_MK_RiskReview
--alter table PS_MK_RiskReview add Code nvarchar(100) null
--alter table PS_MK_RiskReview add Name nvarchar(100) null
--alter table PS_MK_RiskReview drop column Name
--ProjectCode
--Projectscale
select * from PB_Widget where id='524ec553-6cb7-42a9-8fdb-d7ba920e886c'
--/PowerPlat/FormXml/zh-CN/StdMarket/RiskReview.htm

--招投标启动会记录
Create table SF_BiddingStartMeetingRecord
(
Id uniqueidentifier not null,
Code nvarchar(100) null,
Title nvarchar(100) null, 
ProjId uniqueidentifier null,
MeetingContent nvarchar(500) null,
MeetingDate datetime null
)

--投标文件编制计划
Create table SF_RecruitmentDocumentsPlan
(
Id uniqueidentifier not null,
Code nvarchar(100) null,
Title nvarchar(100) null, 
ProjId uniqueidentifier null
)
Create table SF_RecruitmentDocumentsPlan_dtl
(
Id uniqueidentifier not null,
MasterId uniqueidentifier null,
PlanName nvarchar(500) null,
PlanDate datetime null,
DutyHumName nvarchar(100) null,
DutyHumId uniqueidentifier null,
RequiredAskDate datetime null,
RequiredDate datetime null
)
--alter table SF_RecruitmentDocumentsPlan_dtl add Memo nvarchar(500) null

--投标文件评审
select * from PB_Widget where id='9b283e34-b426-4506-b917-7a23e95a7385'
--/PowerPlat/FormXml/zh-CN/StdMarket/isBidReview.htm
--ProjCode
alter table PS_MK_isBidReview add Code nvarchar(100) null
alter table PS_MK_isBidReview add Title nvarchar(100) null
alter table PS_MK_isBidReview add TenderAmount float null
alter table PS_MK_isBidReview add TenderDate datetime null
alter table PS_MK_isBidReview add ProjCode nvarchar(100) null

--复查
--客户登记
select * from PB_Human where name='ccc'
select * from PB_Organize
alter table PB_Organize add OwnerHumanId uniqueidentifier null
alter table PB_Organize add duty nvarchar(100) null
--项目机会
--主要联系人
select Client_Guid,* from PS_MK_ProjectInfo
--alter table PS_MK_ProjectInfo add ProjOwnerId uniqueidentifier null
select * from PB_Organize
select * from PB_Widget where id='4c7b197e-93e4-4534-8c46-575ccf60c76d'
--/PowerPlat/FormXml/zh-CN/StdMarket/Win_ProjectInfo.htm
--购买记录
--alter table SF_FilesBoughtRecord add ClientId uniqueidentifier null

select * from SF_FilesBoughtRecord

--招标文件评审
select * from SF_BiddingFiles
--风险评估
select * from PB_Widget where id='72753679-8a2b-4106-930b-e83a79fe8367'
--项目风险评估
--/PowerPlat/FormXml/zh-CN/StdMarket/Win_RiskReview.htm