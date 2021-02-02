select * from SF_WJSP
--费用报销
select * from SF_FK_Reimbursement
--drop table SF_FK_Reimbursement_Taxi
alter table SF_FK_Reimbursement_Taxi add TaxiReason nvarchar(500) null
create table SF_FK_Reimbursement_Taxi
(
 Id uniqueidentifier null,
 MasterId uniqueidentifier null,
 UpdDate datetime null,
 Sequ int null,
 Memo text null,
 StartDate datetime null,
 EndDate datetime null,
 StartLocation nvarchar(1000) null,
 EndLocation nvarchar(1000) null,
 ApplyDate datetime null,
 TaxiAmount numeric(18,2) null
)

create table SF_FK_Reimbursement_Memo
(
 Id uniqueidentifier null,
 MasterId uniqueidentifier null,
 UpdDate datetime null,
 Sequ int null,
 Memo text null,
 EeventsText text null,
 EeventsMemo nvarchar(100) null,
)

drop table SF_FK_Reimbursement_Memo

create table SF_FK_Reimbursement_PartyB
(
 Id uniqueidentifier null,
 MasterId uniqueidentifier null,
 UpdDate datetime null,
 Sequ int null,
 Memo text null,
 PartyBName text null,
 BankName nvarchar(100) null,
 Code nvarchar(100) null,
)

select * from PB_Widget where id='97a55580-329e-4f81-9dd8-787173094af8'
--/PowerPlat/FormXml/zh-CN/SF_FK/SF_FK_Reimbursement.htm

--文件审批
select * from pb_widget where id='f501ce51-96b4-4583-b9a9-6fd66b5ffc08'
--/PowerPlat/FormXml/zh-CN/SF_Market/SF_WJSP.htm

--alter table SF_FK_Reimbursement add EeventsMemo text null
--alter table SF_FK_Reimbursement add EeventsText text null

select * from SF_FK_Reimbursement


select * from PB_Widget where id='78e5026e-60d3-477a-b3f5-ccc2eeb18fc3'
--/PowerPlat/FormXml/zh-CN/SF_ZH/SF_ZH_OverTime.htm

Select * From SF_FK_Reimbursement_Memo a Where a.Id='2120b645-3a3f-407c-abe9-2a7ee96c2de5'


select *from SF_FK_Reimbursement
--对方单位
select * from SF_FK_Reimbursement_PartyB where MasterId='[@KeyValue]'
--出租车
select RANK() OVER (ORDER BY Sequ asc) as Sequu, *from SF_FK_Reimbursement_Taxi where MasterId='04802051-77d7-489a-a341-115c3517cee8' order by Sequ
select * from PB_User where Name='石敏'
--说明
select * from SF_FK_Reimbursement where Id='[@KeyValue]'

--费用报销
--dt3
--select * from SF_FK_Reimbursement_PartyB where MasterId='[@KeyValue]'

--乘坐出租车申请单
--dt1
--select * from SF_FK_Reimbursement where Id='[@KeyValue]'
--dt2
--select RANK() OVER (ORDER BY Sequ asc) as Sequu,* from SF_FK_Reimbursement_Taxi where MasterId='[@KeyValue]' order by Sequ

--费用报销说明
--dt1
--select * from SF_FK_Reimbursement where Id='[@KeyValue]'