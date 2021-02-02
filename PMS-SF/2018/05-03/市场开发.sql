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
--�ӱ�SF_schedule
--MasterId����Id
--��������schedule
--�²��ƻ�NextPlan
--������FollowUpHuman
--��עMemo
--��¼����RegDate
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