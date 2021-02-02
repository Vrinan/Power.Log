select SubContractType, * from PS_CM_SubContract where SubContractCode like '%265%'


select * from PS_CM_SubContractInvoice where Id='48b70d2d-b823-4126-bda1-9fb68a2610cb'
update PS_CM_SubContractInvoice set Status =50 where Id='48b70d2d-b823-4126-bda1-9fb68a2610cb'


--select * from PS_CM_SubContractInvoice where Code like '%1022-015%'

='fbe45af1-81d7-437a-bda3-bc0d1530357f'


select a.KeyValue,b.WorkInfoID, b.SequeID ,b.ActName, b.UserName,Convert(nvarchar(50),b.SendDate,23) as SendDate, s.Picture,
       case when (c.Content is null or c.Content='') then '同意' else c.Content end as Content, 
       d.PosiName,d.DeptName 
from pwf_infos a 
right join pwf_pastNodes b on a.WorkInfoID=b.WorkInfoID 
left join PB_HumanSign s on b.UserID = s.HumanId
left join pwf_Opinion c on a.WorkInfoID=c.WorkInfoID and b.SequeID=c.SequeID 
left join (select dept.Name as DeptName,posi.Id as PosiId,posi.Name as PosiName from PB_Position posi 
left join PB_Department dept on posi.DeptId=dept.Id) d 
on case when b.DeptPositionID ='' then '00000000-0000-0000-0000-000000000000' when b.DeptPositionID is null then '00000000-0000-0000-0000-000000000000' else b.DeptPositionID end =d.PosiId
where KeyValue='42181739-a07a-44d6-976d-5d365710a8b9'


select distinct  a.WorkInfoID,convert(varchar(10),b.SendDate,120) as NewSendDate, b.UserName,b.SendDate,d.Picture,e.DeptName,e.PosiName,b.ActName,b.BeforeSequeID,coalesce(c.Content,'同意') as Content,b.BeforeSequeID
from pwf_Infos a
left join pwf_pastNodes b on a.WorkInfoID = b.WorkInfoID---b是节点
left join pwf_Opinion c on b.WorkInfoID = c.WorkInfoID and  b.SequeID = c.SequeID
left join PB_HumanSign d on b.UserID = d.HumanId
left join PB_Human e on b.UserID = e.id
left join PB_Department h on e.DeptId = h.Id
where a.KeyValue ='42181739-a07a-44d6-976d-5d365710a8b9'
and b.ActName='调入调出部门负责人'and b.SendDate>=( select max(b.SendDate) as SendDate from pwf_Infos a
left join pwf_pastNodes b on a.WorkInfoID = b.WorkInfoID---b是节点
left join pwf_Opinion c on b.WorkInfoID = c.WorkInfoID and  b.SequeID = c.SequeID
left join PB_HumanSign d on b.UserID = d.HumanId
left join PB_Human e on b.UserID = e.id
where a.KeyValue = '42181739-a07a-44d6-976d-5d365710a8b9' and b.ActName ='开始') and
(h.Id IN (select top(1) b.OldDeptId from SF_ZH_Allocation a join SF_ZH_Allocation_list b on a.Id = b.MasterId where a.Id='42181739-a07a-44d6-976d-5d365710a8b9') 
or h.ParentId IN (select ParentId from PB_Department where Id IN
(select top(1) b.OldDeptId from SF_ZH_Allocation a join SF_ZH_Allocation_list b on a.Id = b.MasterId where a.Id='42181739-a07a-44d6-976d-5d365710a8b9')))