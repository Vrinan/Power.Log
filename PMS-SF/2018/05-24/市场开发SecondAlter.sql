--eps
select * from PB_Widget where id='1AC107F1-4C94-4ACB-B5E1-F8ABB2CA9DFA'
--EPS表单 EPS
--/PowerPlat/FormXML/zh-CN/StdSystem/EPSPage.htm
select * from PLN_project
alter table PLN_project add Abbreviation nvarchar(100) null
alter table PLN_project add ProjNature nvarchar(100) null
--EPS窗体
select * from PB_Widget where id='445f7bf3-f83e-4556-8207-94048f84da7d'
--/PowerPlat/FormXml/zh-CN/StdSystem/EPSPageList.htm

--市场开发，SecondAlter
--月度市场工作计划及反馈
select * from PB_Widget where id='a2546bcc-6b75-4e55-b69d-94d547a3ce3e'
--年度市场开发SF_AnnualMarketDev
--/PowerPlat/FormXml/zh-CN/SF_Market/Win_SF_AnnualMarketDev.htm
select * from SF_AnnualMarketDev
create table SF_AnnualMarketDev_dtl
(
	Id uniqueidentifier not null,
	MasterId uniqueidentifier null,
	Name nvarchar(100) null,
	Content nvarchar(200) null,
	Complate nvarchar(200) null,
	Memo nvarchar(200) null
)

--客户登记
select * from PB_Widget where id='415381b5-1566-4e5b-8a59-527f7377ceca'
--/PowerPlat/FormXml/zh-CN/StdMarket/Organize.htm

--项目跟踪
select * from PB_Widget where id='029d6895-3186-4565-adc3-61919e3ab1ed'
--项目机会PS_ProjectInfo
--/PowerPlat/FormXml/zh-CN/StdMarket/ProjectInfo.htm

select * from PB_BaseDataList where BaseDataId = (
select id from PB_BaseData where DataType='PS_ProjectType')

--delete from PB_BaseDataList where id='D98F9EC2-7F36-98E1-59AD-0065E2120FD7'
--update  PB_BaseDataList set Name='技术服务' where id='94BF2E13-2716-DC21-A6EE-0AD3869721DC'
select * from PS_MK_ProjectInfo
alter table PS_MK_ProjectInfo add TrackingProgress nvarchar(100) null
alter table PS_MK_ProjectInfo add ProjectProgress nvarchar(100) null
alter table PS_MK_ProjectInfo add ProjectManager nvarchar(100) null
alter table PS_MK_ProjectInfo add ProjectManagerId uniqueidentifier null


--招标文件购买记录
select * from PB_Widget where id='2621a19c-8939-4688-b6e6-745492c47b4e'
--招标文件购买记录SF_FilesBoughtRecord
--/PowerPlat/FormXml/zh-CN/SF_Market/SF_FilesBoughtRecord.htm

select * from SF_FilesBoughtRecord
alter table SF_FilesBoughtRecord add ProjectRange nvarchar(1000) null


--招标文件评审
select * from PB_Widget where id='ccdadd8e-a516-4ccb-861b-028e67016ed1'
--招标文件评审SF_BiddingFiles
--/PowerPlat/FormXml/zh-CN/SF_Market/SF_BiddingFiles.htm
--alter table SF_BiddingFiles add MarginDeadLine datetime null--保证金缴纳截止时间
--alter table SF_BiddingFiles add EstimatedCost float null--成本预估金额
--alter table SF_BiddingFiles add IsEstimated nvarchar(100) null--技术满足预估  是否
--alter table SF_BiddingFiles add EstimatedScore nvarchar(100) null--评分预估
--alter table SF_BiddingFiles add IsHardware nvarchar(100) null--硬件满足情况   是否
--alter table SF_BiddingFiles add HardwareMemo nvarchar(100) null--硬件满足情况备注
--alter table SF_BiddingFiles add Duration nvarchar(100) null--工期预估
select * from SF_BiddingFiles


--招投标启动会记录
select * from PB_Widget where id='f774fd08-e149-4b27-8772-8040f1d74ef6'
--招投标启动会记录SF_BiddingStartMeetingRecord
--/PowerPlat/FormXml/zh-CN/SF_Market/SF_BiddingStartMeetingRecord.htm
select * from SF_BiddingStartMeetingRecord
alter table SF_BiddingStartMeetingRecord add BiddingFilesId uniqueidentifier null
--BiddingFilesCode
--BiddingFilesTitle
--EstimatedCost成本预估金额
--IsEstimated技术满足预估  是否
--EstimatedScore评分预估
--IsHardware硬件满足情况  是否
--HardwareMemo硬件满足情况备注
--Duration 工期预估


--投标保证金（保函）申请
select * from PB_Widget where id='c9fa7a76-4c89-430a-89b1-ea64e8db3be9'
--投标保证金申请SF_BidDepositApplication
--/PowerPlat/FormXml/zh-CN/SF_Market/SF_BidDepositApplication.htm
select * from SF_BidDepositApplication
alter table SF_BidDepositApplication add ApplyType nvarchar(100) null 
select * from SF_AuctionResultRegistration
--delete from SF_AuctionResultRegistration


--开标情况登记
alter table SF_OpenBidding add BidCompanyName nvarchar(100) null
alter table SF_OpenBidding_dtl add IsBid nvarchar(100) null

select * from SF_OpenBidding
select * from SF_OpenBidding_dtl
delete from SF_OpenBidding_dtl
delete from SF_OpenBidding

select * from pb_wizard where id='f0b8cc9e-f5c0-6c6a-8157-a016d3de0964'

update PB_DefaultField set Status=0 where DefaultFieldId='4111D3B3-2AA3-466D-A761-453FA223708B'

--项目交接单
select * from PB_Widget where id='abd9f2b5-0330-4c53-91b8-ffc7be72da17'
--项目立项交接单PS_ProjectHandover
--/PowerPlat/FormXml/zh-CN/StdMarket/PS_ProjectHandover.htm
select * from PS_MK_ProjectHandover
alter table PS_MK_ProjectHandover add BidAmount float null--投标金额（万元）
alter table PS_MK_ProjectHandover add Duration nvarchar(100) null--计划工期
alter table PS_MK_ProjectHandover add ProjSchedule nvarchar(100) null--项目进度（客户）
alter table PS_MK_ProjectHandover add DutyAmount float null--履约保证金（保函） 金额
 
select * from PB_Organize  
--项目
select * from PB_Widget where id='52a324af-b225-49aa-8552-654e539b9008'
--项目维护EPSProject
--/PowerPlat/FormXml/zh-CN/StdSystem/ProjectPageList.htm
select * from PB_Widget where id='b7ba65fb-5c19-4c32-b43f-362340ff7bc8'
--项目表单Project
--/PowerPlat/FormXML/zh-CN/StdSystem/ProjectPage.htm


select * from SF_RecruitmentDocumentsPlan_dtl

alter table SF_RecruitmentDocumentsPlan_dtl add PlanBidType nvarchar(100) null--标书分类
alter table SF_RecruitmentDocumentsPlan_dtl add RegDepart nvarchar(100) null--编制部门
alter table SF_RecruitmentDocumentsPlan_dtl add RegDepartId uniqueidentifier null--编制部门Id
alter table SF_RecruitmentDocumentsPlan_dtl add FinishDateA datetime null--完成时间A
alter table SF_RecruitmentDocumentsPlan_dtl add FinishDateB datetime null--完成时间B
alter table SF_RecruitmentDocumentsPlan_dtl add DutyHumNameId uniqueidentifier null--审核人
alter table SF_RecruitmentDocumentsPlan_dtl add DutyHumNameA nvarchar(100) null--审核人A
alter table SF_RecruitmentDocumentsPlan_dtl add DutyHumNameAId uniqueidentifier null--审核人AId


select * from PB_Widget where id='bfe2c5d3-d71f-498d-ac13-77ef50aa8e4d'
--/PowerPlat/FormXml/zh-CN/SF_Market/SF_RecruitmentDocumentsPlan.htm

select * from PB_Human