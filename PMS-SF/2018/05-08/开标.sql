--投标保证函审查表
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
--外键
--ProjCode
--ProjName
--ProjSize
--BidReviewName
--BidReviewCode

--投标文件评审
select * from PS_MK_isBidReview

--开标情况
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
--外键
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
	Remark nvarchar(500) null
)
--alter table SF_OpenBidding_dtl drop column Memo
--alter table SF_OpenBidding_dtl add Remark nvarchar(500) null

--投标结果登记
Create table SF_AuctionResultRegistration
(
	Id uniqueidentifier not null,
	Code nvarchar(100) null,
	Title nvarchar(100) null,
	ProjId uniqueidentifier null,
	OpenBiddingId uniqueidentifier null,
	AuctionDate datetime null,
	BiddingAmount float null,
	AuctionClient nvarchar(100) null,
	AuctionClientId uniqueidentifier null
)
--外键
--ProjCode
--ProjName
--OpenBiddingCode
--OpenBiddingName
Create table SF_AuctionResultRegistration_dtl
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
	Remark nvarchar(500) null
)

--项目交接单
Create table SF_ProjectHandover
(
	Id uniqueidentifier not null,
	Code nvarchar(100) null,
	Title nvarchar(100) null,
	ProjId uniqueidentifier null,
	ClientId uniqueidentifier null,--Client_Guid
	ProjectManager nvarchar(100) null,
	ProjectManagerId uniqueidentifier null,
	ProjectLocation nvarchar(500) null,
	PlanBegin datetime null,
	PlanEnd datetime null,
	ProjectContent nvarchar(500) null,
	HandOverContent nvarchar(500) null
)
alter table SF_ProjectHandover add EpsName nvarchar(100) null
alter table SF_ProjectHandover add EpsId nvarchar(100) null
--外键
--ProjCode
--ProjName
--ProjectType性质
--ProjectSize规模
--ClientCode
--ClientName
select * from PB_Widget where id='52a324af-b225-49aa-8552-654e539b9008'

select * from SF_ProjectHandover
select LongCode,EpsProjId,EpsProjName,EpsProjType,project_address,Pro_owners_guid,Pro_manager_guid,Pro_manager_name,STATE,clndr_id,* from PLN_project where project_name='233'
select * from PLN_project where update_date>'2018-05-6 09:01:26.000'
--PLNProject

--project_shortname ProjName
--project_name ProjName
--clndr_id 1
--STATE 0
--Pro_manager_name ProjectManager
--Pro_manager_guid ProjectManagerId
--Pro_owners_name ClientName
--Pro_owners_guid ClientId
--dtplanstart PlanBegin
--dtplanfinish PlanEnd
--project_address ProjectLocation
--EpsProjType 1
--EpsProjName ProjName
--EpsProjId 一致的。。

--EPSProject
select project_type,BizAreaId,* from PLN_project
select LongCode from PLN_project
select displayid,project_type,* from PLN_project where parent_guid='fd622805-aaf0-4cda-b170-b695ae9aacca'
select * from PLN_project where displayid = '239' order by displayid 
--BizAreaId 00000000-0000-0000-0000-00000000000A
--project_guid ProjId
--parent_guid EpsId
--project_type 1
--displayid 241（最大值+1）
--LongCode 
-- -放弃了。。这个还是改表单快。。


--项目交接单
select * from PB_Widget where id='abd9f2b5-0330-4c53-91b8-ffc7be72da17'
--项目立项交接单
--/PowerPlat/FormXml/zh-CN/StdMarket/PS_ProjectHandover.htm
select * from PS_MK_ProjectHandover
exec P_DeleteWorkFlow_sam '53f9a5a2-167e-4e78-8b8c-4db3d3380d44','PS_MK_ProjectHandover'
select * from PLN_project where project_name='233'

--竞争对手库
select * from PB_Widget where id='3b335884-29f3-4201-8f19-6b06ba85796b'
--竞争对手
--/PowerPlat/FormXml/zh-CN/StdMarket/Opponent.htm

alter table PB_Organize add RegisteredCapital float null

--客户满意度
Create table SF_CustomerSatisfaction
(
	Id uniqueidentifier not null,
	Code nvarchar(100) null,
	Title nvarchar(100) null,
	ProjId uniqueidentifier null,
	ClientId uniqueidentifier null,
)
Create table SF_CustomerSatisfaction_dtl
(
	Id uniqueidentifier not null,
	MasterId uniqueidentifier not null,
	Grading int null,
	GradingProj nvarchar(100) null,
	Score int null,
	TotalRace int null,
	ProjLev int null
)
--外键
--ProjCode
--ProjName
--ClientCode
--ClientName


--综合统计
sp_helptext V_PS_MK_ProjectInfo 

ALTER view [dbo].[V_PS_MK_ProjectInfo]
as
select a.*,
f.comentnum, ----跟进次数
ISNULL(b.RegDate,'2017-01-13 11:18:50.000') FollowDate,---最新跟进日期
b.CommentText,--最新动态
d.isBid,---是否投标
c.BidResult,--投标结果
case when e.id is not null and e.Status = 50 then '合同评审完成'
 when e.id is not null and e.Status <> 50 then '合同评审中'
 when e.id is null then '尚未合同评审' end reviewStatus  ---合同评审状态
from PS_MK_ProjectInfo a left join V_PS_MK_NewComment b
on a.Id = b.KeyValue
left join PS_MK_BidTrack c
on a.Id = c.ProjectInfo_Guid
left join PS_MK_isBidReview d
on a.Id = d.ProjectInfo_Guid
left join PS_MK_ContractReview e
on a.Id = e.ProjectInfo_Guid
left join (select keyvalue,COUNT(*) comentnum from PB_Comment where KeyWord ='ProjectInfo'
group by keyvalue ) f
on a.Id = f.KeyValue

select FollowDate,* from PS_MK_ProjectInfo
select FollowDate,* from V_PS_MK_NewComment
select FollowDate,* from PS_MK_BidTrack
select FollowDate,* from PS_MK_isBidReview
select FollowDate,* from PS_MK_ContractReview
select FollowDate,* from PB_Comment


select * from PB_Widget where id='d84a7368-d211-4e4b-90b4-05e0eab84d48'
--/PowerPlat/FormXml/zh-CN/StdMarket/Win_Organize.htm
--/PowerPlat/FormXml/zh-CN/StdMarket/Win_ClientEvaluation.htm
--/PowerPlat/FormXml/zh-CN/StdMarket/Win_ProjectInfo.htm
--/PowerPlat/FormXml/zh-CN/StdMarket/Win_isBidReview.htm
--/PowerPlat/FormXml/zh-CN/StdMarket/Win_Organize.htm
--风险识别库
--/PowerPlat/FormXml/zh-CN/StdMarket/Win_RiskLibraryList.htm