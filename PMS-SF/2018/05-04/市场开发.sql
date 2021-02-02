--SF_AnnualIndicators���ָ��¼��
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
select * from PB_BaseData where name like '%��%'
--alter table SF_AnnualIndicators alter column Years nvarchar(50)
--AnnualMarketDev����г�����
create table SF_AnnualMarketDev
(
Id uniqueidentifier not null,
Code nvarchar(50) null,
Title nvarchar(50) null,
Amount float null,
Years datetime null
)
--alter table SF_AnnualMarketDev alter column Years nvarchar(50)
--�ͻ��Ǽ�
select * from PB_Widget where id='415381b5-1566-4e5b-8a59-527f7377ceca'
--/PowerPlat/FormXml/zh-CN/StdMarket/Organize.htm
--�ͻ���Ϣ����
--�ͻ�����PS_MK_ClientEvaluation��ȱ�������ֶΣ�ѡ�����������
--alter table PS_MK_ClientEvaluation add ProjectCode nvarchar(50) null
--alter table PS_MK_ClientEvaluation add ClientCode nvarchar(50) null
--alter table PS_MK_ClientEvaluation drop column ClientCode
select * from PB_Widget where id='318cf2c5-048b-400a-b30e-09e9536279e8'
--/PowerPlat/FormXml/zh-CN/StdMarket/ClientEvaluation.htm
--��Ŀ����
select * from PB_Widget where id='029d6895-3186-4565-adc3-61919e3ab1ed'
--/PowerPlat/FormXml/zh-CN/StdMarket/ProjectInfo.htm
select * from PS_MK_ProjectInfo
--�б�����BiddingType
--�ʽ���ԴAmountSourceType
--��Ҫ�̶�ImportantLev
--��Ƶ�λDesignName
--��ϵ��ContractHuman
--��Ŀ������ProjOwner
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
--�ӱ�SF_schedule
--MasterId����Id
--��������schedule
--�²��ƻ�NextPlan
--������FollowUpHuman
--��עMemo
--��¼����RegDate
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
--�б��ļ������¼
select * from SF_FilesBoughtRecord
--delete from SF_FilesBoughtRecord where ProjId is null
--��ĿProjId
--�����ProjCode��ProjName��ProjSize
--������򵼣���ҵ�����PS_ProjectInfo
--����ʱ��BoughtDate
--������BoughtAmount
--����˵��BoughtMemo
--�������/��λBoughtPartyA
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

--�б��ļ�����
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
--������
ContractedAmount float null,
--ҵ������
OwnsCredit nvarchar(50) null,
--�б��ļ����
BiddingFilesCode nvarchar(500) null,
BiddingBegin datetime null,
BiddingEnd datetime null,
--�б�ģʽ
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

--��������
select * from PS_MK_RiskReview
--alter table PS_MK_RiskReview add Code nvarchar(100) null
--alter table PS_MK_RiskReview add Name nvarchar(100) null
--alter table PS_MK_RiskReview drop column Name
--ProjectCode
--Projectscale
select * from PB_Widget where id='524ec553-6cb7-42a9-8fdb-d7ba920e886c'
--/PowerPlat/FormXml/zh-CN/StdMarket/RiskReview.htm

--��Ͷ���������¼
Create table SF_BiddingStartMeetingRecord
(
Id uniqueidentifier not null,
Code nvarchar(100) null,
Title nvarchar(100) null, 
ProjId uniqueidentifier null,
MeetingContent nvarchar(500) null,
MeetingDate datetime null
)

--Ͷ���ļ����Ƽƻ�
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

--Ͷ���ļ�����
select * from PB_Widget where id='9b283e34-b426-4506-b917-7a23e95a7385'
--/PowerPlat/FormXml/zh-CN/StdMarket/isBidReview.htm
--ProjCode
alter table PS_MK_isBidReview add Code nvarchar(100) null
alter table PS_MK_isBidReview add Title nvarchar(100) null
alter table PS_MK_isBidReview add TenderAmount float null
alter table PS_MK_isBidReview add TenderDate datetime null
alter table PS_MK_isBidReview add ProjCode nvarchar(100) null

--����
--�ͻ��Ǽ�
select * from PB_Human where name='ccc'
select * from PB_Organize
alter table PB_Organize add OwnerHumanId uniqueidentifier null
alter table PB_Organize add duty nvarchar(100) null
--��Ŀ����
--��Ҫ��ϵ��
select Client_Guid,* from PS_MK_ProjectInfo
--alter table PS_MK_ProjectInfo add ProjOwnerId uniqueidentifier null
select * from PB_Organize
select * from PB_Widget where id='4c7b197e-93e4-4534-8c46-575ccf60c76d'
--/PowerPlat/FormXml/zh-CN/StdMarket/Win_ProjectInfo.htm
--�����¼
--alter table SF_FilesBoughtRecord add ClientId uniqueidentifier null

select * from SF_FilesBoughtRecord

--�б��ļ�����
select * from SF_BiddingFiles
--��������
select * from PB_Widget where id='72753679-8a2b-4106-930b-e83a79fe8367'
--��Ŀ��������
--/PowerPlat/FormXml/zh-CN/StdMarket/Win_RiskReview.htm