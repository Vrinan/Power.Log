--delete from SF_HSE_RectificationNotice
--delete from SF_HSE_RectificationNotice_dtl
--delete from SF_HSE_RectificationReturn 
--delete from SF_HSE_RectificationReturn_dtl

--select * from SF_HSE_RectificationNotice
select * from SF_HSE_RectificationNotice

--select * from SF_HSE_RectificationReturn 
--select * from SF_HSE_RectificationReturn_dtl
--delete from SF_HSE_RectificationReturn
--ע����������ť

--HSE���Ͷ���
--HSEType 1���ˡ�2���š�3��λ

alter table SF_HSE_RewardsAndPunishments add HSEType nvarchar(100) null
alter table SF_HSE_RewardsAndPunishments add HumanName nvarchar(100) null
alter table SF_HSE_RewardsAndPunishments add HumanId nvarchar(100) null
alter table SF_HSE_RewardsAndPunishments add DeptName nvarchar(100) null
alter table SF_HSE_RewardsAndPunishments add DeptId nvarchar(100) null
--���´��弰ҳ��

alter table SF_HSE_DelegateYAppy_dtl add MonitorId uniqueidentifier null
alter table SF_HSE_DelegateOAppy_dtl add MonitorId uniqueidentifier null

alter table SF_HSE_MonitorIssued add DeleDeptName nvarchar(100) null
alter table SF_HSE_MonitorIssued add DeleDeptId uniqueidentifier null

alter table PS_HSE_AccidentsReport add DealWay nvarchar(500) null

create view View_SF_EmergencyDtl
as
select al.Code,al.Title,al.Status,aq.* from SF_HSE_EmergencyPre al left join SF_HSE_EmergencyPre_dtl aq on al.Id=aq.MasterId
go

alter table SF_HSE_EmergencyPlan_dtl add EmergencyDtlId uniqueidentifier null

