--通信费报销

--费用报销
select * from PB_Widget where id='97a55580-329e-4f81-9dd8-787173094af8'
--/PowerPlat/FormXml/zh-CN/SF_FK/SF_FK_Reimbursement.htm

select * from SF_FK_CommunicateReimburse
select * from SF_FK_CommunicateReimburse_dtl
delete from SF_FK_CommunicateReimburse_dtl


select * from PB_User

--计划的向导
--通讯费用报销计划
--View_SF_CommunicateReimburse
select a.Code,a.Month,b.* from SF_ZH_CommunicationFeeMonthPlan a left join SF_ZH_CommunicationFeeMonthPlan_dtl b on a.Id = b.MasterId
where a.Status = 50


--向导swhere
select convert(nvarchar(6),a.Month,112) as ym,a.* from
(
select a.Code,a.Month,b.* from SF_ZH_CommunicationFeeMonthPlan a left join SF_ZH_CommunicationFeeMonthPlan_dtl b on a.Id = b.MasterId
) a  where convert(nvarchar(6),a.Month,112) ='201901'


exec P_DeleteWorkFlow_Sam '5a68808c-1d7c-4f9b-aee2-9fb214e2e66e','SF_FK_CommunicateReimburse'


--根据人员Id获取
select * from SF_ZH_CommunicationFeeMonthPlan_dtl
update SF_ZH_CommunicationFeeMonthPlan set Status=0

--可报销费用(人员Id,年)
select * from dbo.GetAllAmount('531D0B65-2ED1-4925-9099-C8DA5613CB68','2019')
--已报销费用
select * from [dbo].GetUsedAmount('531D0B65-2ED1-4925-9099-C8DA5613CB68','2019')