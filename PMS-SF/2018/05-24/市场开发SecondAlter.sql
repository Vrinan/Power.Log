--eps
select * from PB_Widget where id='1AC107F1-4C94-4ACB-B5E1-F8ABB2CA9DFA'
--EPS�� EPS
--/PowerPlat/FormXML/zh-CN/StdSystem/EPSPage.htm
select * from PLN_project
alter table PLN_project add Abbreviation nvarchar(100) null
alter table PLN_project add ProjNature nvarchar(100) null
--EPS����
select * from PB_Widget where id='445f7bf3-f83e-4556-8207-94048f84da7d'
--/PowerPlat/FormXml/zh-CN/StdSystem/EPSPageList.htm

--�г�������SecondAlter
--�¶��г������ƻ�������
select * from PB_Widget where id='a2546bcc-6b75-4e55-b69d-94d547a3ce3e'
--����г�����SF_AnnualMarketDev
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

--�ͻ��Ǽ�
select * from PB_Widget where id='415381b5-1566-4e5b-8a59-527f7377ceca'
--/PowerPlat/FormXml/zh-CN/StdMarket/Organize.htm

--��Ŀ����
select * from PB_Widget where id='029d6895-3186-4565-adc3-61919e3ab1ed'
--��Ŀ����PS_ProjectInfo
--/PowerPlat/FormXml/zh-CN/StdMarket/ProjectInfo.htm

select * from PB_BaseDataList where BaseDataId = (
select id from PB_BaseData where DataType='PS_ProjectType')

--delete from PB_BaseDataList where id='D98F9EC2-7F36-98E1-59AD-0065E2120FD7'
--update  PB_BaseDataList set Name='��������' where id='94BF2E13-2716-DC21-A6EE-0AD3869721DC'
select * from PS_MK_ProjectInfo
alter table PS_MK_ProjectInfo add TrackingProgress nvarchar(100) null
alter table PS_MK_ProjectInfo add ProjectProgress nvarchar(100) null
alter table PS_MK_ProjectInfo add ProjectManager nvarchar(100) null
alter table PS_MK_ProjectInfo add ProjectManagerId uniqueidentifier null


--�б��ļ������¼
select * from PB_Widget where id='2621a19c-8939-4688-b6e6-745492c47b4e'
--�б��ļ������¼SF_FilesBoughtRecord
--/PowerPlat/FormXml/zh-CN/SF_Market/SF_FilesBoughtRecord.htm

select * from SF_FilesBoughtRecord
alter table SF_FilesBoughtRecord add ProjectRange nvarchar(1000) null


--�б��ļ�����
select * from PB_Widget where id='ccdadd8e-a516-4ccb-861b-028e67016ed1'
--�б��ļ�����SF_BiddingFiles
--/PowerPlat/FormXml/zh-CN/SF_Market/SF_BiddingFiles.htm
--alter table SF_BiddingFiles add MarginDeadLine datetime null--��֤����ɽ�ֹʱ��
--alter table SF_BiddingFiles add EstimatedCost float null--�ɱ�Ԥ�����
--alter table SF_BiddingFiles add IsEstimated nvarchar(100) null--��������Ԥ��  �Ƿ�
--alter table SF_BiddingFiles add EstimatedScore nvarchar(100) null--����Ԥ��
--alter table SF_BiddingFiles add IsHardware nvarchar(100) null--Ӳ���������   �Ƿ�
--alter table SF_BiddingFiles add HardwareMemo nvarchar(100) null--Ӳ�����������ע
--alter table SF_BiddingFiles add Duration nvarchar(100) null--����Ԥ��
select * from SF_BiddingFiles


--��Ͷ���������¼
select * from PB_Widget where id='f774fd08-e149-4b27-8772-8040f1d74ef6'
--��Ͷ���������¼SF_BiddingStartMeetingRecord
--/PowerPlat/FormXml/zh-CN/SF_Market/SF_BiddingStartMeetingRecord.htm
select * from SF_BiddingStartMeetingRecord
alter table SF_BiddingStartMeetingRecord add BiddingFilesId uniqueidentifier null
--BiddingFilesCode
--BiddingFilesTitle
--EstimatedCost�ɱ�Ԥ�����
--IsEstimated��������Ԥ��  �Ƿ�
--EstimatedScore����Ԥ��
--IsHardwareӲ���������  �Ƿ�
--HardwareMemoӲ�����������ע
--Duration ����Ԥ��


--Ͷ�걣֤�𣨱���������
select * from PB_Widget where id='c9fa7a76-4c89-430a-89b1-ea64e8db3be9'
--Ͷ�걣֤������SF_BidDepositApplication
--/PowerPlat/FormXml/zh-CN/SF_Market/SF_BidDepositApplication.htm
select * from SF_BidDepositApplication
alter table SF_BidDepositApplication add ApplyType nvarchar(100) null 
select * from SF_AuctionResultRegistration
--delete from SF_AuctionResultRegistration


--��������Ǽ�
alter table SF_OpenBidding add BidCompanyName nvarchar(100) null
alter table SF_OpenBidding_dtl add IsBid nvarchar(100) null

select * from SF_OpenBidding
select * from SF_OpenBidding_dtl
delete from SF_OpenBidding_dtl
delete from SF_OpenBidding

select * from pb_wizard where id='f0b8cc9e-f5c0-6c6a-8157-a016d3de0964'

update PB_DefaultField set Status=0 where DefaultFieldId='4111D3B3-2AA3-466D-A761-453FA223708B'

--��Ŀ���ӵ�
select * from PB_Widget where id='abd9f2b5-0330-4c53-91b8-ffc7be72da17'
--��Ŀ����ӵ�PS_ProjectHandover
--/PowerPlat/FormXml/zh-CN/StdMarket/PS_ProjectHandover.htm
select * from PS_MK_ProjectHandover
alter table PS_MK_ProjectHandover add BidAmount float null--Ͷ�����Ԫ��
alter table PS_MK_ProjectHandover add Duration nvarchar(100) null--�ƻ�����
alter table PS_MK_ProjectHandover add ProjSchedule nvarchar(100) null--��Ŀ���ȣ��ͻ���
alter table PS_MK_ProjectHandover add DutyAmount float null--��Լ��֤�𣨱����� ���
 
select * from PB_Organize  
--��Ŀ
select * from PB_Widget where id='52a324af-b225-49aa-8552-654e539b9008'
--��Ŀά��EPSProject
--/PowerPlat/FormXml/zh-CN/StdSystem/ProjectPageList.htm
select * from PB_Widget where id='b7ba65fb-5c19-4c32-b43f-362340ff7bc8'
--��Ŀ��Project
--/PowerPlat/FormXML/zh-CN/StdSystem/ProjectPage.htm


select * from SF_RecruitmentDocumentsPlan_dtl

alter table SF_RecruitmentDocumentsPlan_dtl add PlanBidType nvarchar(100) null--�������
alter table SF_RecruitmentDocumentsPlan_dtl add RegDepart nvarchar(100) null--���Ʋ���
alter table SF_RecruitmentDocumentsPlan_dtl add RegDepartId uniqueidentifier null--���Ʋ���Id
alter table SF_RecruitmentDocumentsPlan_dtl add FinishDateA datetime null--���ʱ��A
alter table SF_RecruitmentDocumentsPlan_dtl add FinishDateB datetime null--���ʱ��B
alter table SF_RecruitmentDocumentsPlan_dtl add DutyHumNameId uniqueidentifier null--�����
alter table SF_RecruitmentDocumentsPlan_dtl add DutyHumNameA nvarchar(100) null--�����A
alter table SF_RecruitmentDocumentsPlan_dtl add DutyHumNameAId uniqueidentifier null--�����AId


select * from PB_Widget where id='bfe2c5d3-d71f-498d-ac13-77ef50aa8e4d'
--/PowerPlat/FormXml/zh-CN/SF_Market/SF_RecruitmentDocumentsPlan.htm

select * from PB_Human