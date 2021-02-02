select * from PB_Widget where id='696ec71e-d26a-46d4-9ed2-6d6de2c4f9ff'
--/PowerPlat/FormXml/zh-CN/StdMarket/ContractReview.htm
select * from PB_Widget where id='5c0640b9-fb52-4b58-bc90-b7af15a884c2'
--/PowerPlat/FormXml/zh-CN/SF_CM/PS_CM_ContractReview.htm
--主表
select * from PS_MK_ContractReview where Id='d1b6ab50-23b6-4339-933f-a2dee886abb8'
select * from PS_MK_ContractReview where Id='[@KeyValue]'

--<div id="btnPrint" class="btn-group"></div>
--1
select * from PS_MK_ContractReview where Id='[@KeyValue]'

--2
select b.SequeID ,b.ActName, b.UserName,Convert(nvarchar(50),b.SendDate,23) as SendDate, 
       case when (c.Content is null or c.Content='') then '同意' else c.Content end as Content, 
       d.PosiName,d.DeptName 
from pwf_infos a 
right join pwf_pastNodes b on a.WorkInfoID=b.WorkInfoID 
left join pwf_Opinion c on a.WorkInfoID=c.WorkInfoID and b.SequeID=c.SequeID 
left join (select dept.Name as DeptName,posi.Id as PosiId,posi.Name as PosiName from PB_Position posi 
left join PB_Department dept on posi.DeptId=dept.Id) d 
on case when b.DeptPositionID ='' then '00000000-0000-0000-0000-000000000000' when b.DeptPositionID is null then '00000000-0000-0000-0000-000000000000' else b.DeptPositionID end =d.PosiId
where KeyValue='[@KeyValue]'  and ActName = '评审部门'
order by  b.SequeID 

--3
select b.SequeID ,b.ActName, b.UserName,Convert(nvarchar(50),b.SendDate,23) as SendDate, 
       case when (c.Content is null or c.Content='') then '同意' else c.Content end as Content, 
       d.PosiName,d.DeptName 
from pwf_infos a 
right join pwf_pastNodes b on a.WorkInfoID=b.WorkInfoID 
left join pwf_Opinion c on a.WorkInfoID=c.WorkInfoID and b.SequeID=c.SequeID 
left join (select dept.Name as DeptName,posi.Id as PosiId,posi.Name as PosiName from PB_Position posi 
left join PB_Department dept on posi.DeptId=dept.Id) d 
on case when b.DeptPositionID ='' then '00000000-0000-0000-0000-000000000000' when b.DeptPositionID is null then '00000000-0000-0000-0000-000000000000' else b.DeptPositionID end =d.PosiId
where KeyValue='[@KeyValue]'  and ActName = '公司领导'
order by  b.SequeID 