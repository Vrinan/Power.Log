select * from PB_HumanSign al where al.HumanId in(
select distinct b.UserID
from pwf_infos a 
right join pwf_pastNodes b on a.WorkInfoID=b.WorkInfoID 
where a.KeyValue='233d33ea-aba8-46e4-b64a-6e13450c64fb'
and  b.InboxStatus ='60' and b.actname  ='根据需求选相关部门会签'
group by b.UserID)


select * from pwf_pastNodes
select * from PB_HumanSign where Name='陈居明'
--,s.Picture


select gr.UserName,pa.senddate,isnull(op.Content,'同意') as Content,s.Picture from (
	select a.WorkInfoID, b.UserID, b.UserName,b.SequeID as SequeID from pwf_infos a
	right join pwf_pastNodes b on  a.WorkInfoID=b.WorkInfoID 
	where a.KeyValue='233d33ea-aba8-46e4-b64a-6e13450c64fb'
	and  b.InboxStatus ='60' and b.actname  ='根据需求选相关部门会签' 
	group by a.WorkInfoID,b.UserID, b.UserName
)gr
left join pwf_Opinion op on gr.WorkInfoID = op.WorkInfoID and gr.SequeID = op.SequeID
left join pwf_pastNodes pa on gr.WorkInfoID = pa.WorkInfoID and gr.SequeID = pa.SequeID
left join PB_HumanSign s on gr.UserID = s.HumanId



select * from SF_HSE_Instruction order by RegDate

alter table SF_HSE_Instruction add RegDeptName nvarchar(200) null


--update SF_HSE_Instruction set RegDeptName = (
--select DeptName from PB_Human where PB_Human.Id = SF_HSE_Instruction.RegHumId
--)
select * from PB_User where Name='樊军'

select DeptName from PB_Human where Name='樊军'


select * from PB_Widget where Id='82e42807-d441-4453-8c42-2849f85ef19d'
--/PowerPlat/FormXml/zh-CN/SF_HSE/SF_HSE_Instruction.htm