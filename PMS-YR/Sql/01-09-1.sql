select * from pb_widget where id='e482b7c0-7fb0-4277-9775-0217b6968934'
select * from PB_Wizard where id='85ec3f0f-4c3a-466b-b877-184e150a37f1'

--alter table PS_cm_SubContractChange add AddSubContractId uniqueidentifier
--alter table PS_cm_SubContractChange add AddSubContractCode nvarchar(500)
--alter table PS_cm_SubContractChange add AddSubContractName nvarchar(500)
--alter table PS_cm_SubContractChange add AddSubContractMoney float
--alter table PS_cm_SubContractChange add SubContractMoney float
--alter table PS_CM_SubContract add ParentId uniqueidentifier
--增补合同ID
--alter table PS_CM_SubContract add AddSubContractId uniqueidentifier
--alter table PS_CM_SubContract add AddSubContractCode nvarchar(500)
--alter table PS_CM_SubContract add AddSubContractName nvarchar(500)
--alter table PS_CM_SubContractApplyMny add FinalSubcontractAmount float

select SubContractAmount,ChangeAmount,* from PS_CM_SubContract
select * from PS_cm_SubContractChange

-------------------向导
select * from PS_cm_SubContract
--合同
select * from PS_cm_SubContract
select * from PS_CM_SubContract_MatItem

--wizard
select * from PS_CM_SubContract_MatItem where (MasterId = 'C974D862-F584-4431-853E-2C1D42F10CEA' or MasterId in (select id from PS_cm_SubContract q where q.AddSubContractId = 'C974D862-F584-4431-873E-2C1D42F10CEA'))
and Id not in(SELECT ContractMat_Guid FROM PS_CM_SubContractApplyMny_Mat b where b.MasterId='f23cad1c-2409-42d8-b0ba-b521b2c9bff2')

select * from V_PS_SubContractApplyMny

select FinalSubcontractAmount from PS_CM_SubContractApplyMny


select * from View_XLX_PUR_InquirySupplie where matcode='1030701160088'

select * from XLX_PUR_InquirySupplie_List where MatCode='1030701160088'

select * from V_PS_SubContract where id='12cf7c1c-2fd7-4734-92dd-e420f909d37f'


--付款申请
select * from PS_CM_SubContractApplyMny 
select * from PS_CM_SubContractApplyMny_Mat