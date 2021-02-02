--形象进度月报表
select left(CONVERT(varchar(100),signdate, 102),7) as Sign ,* from SF_FK_ImageProgress
select convert(nvarchar(100),(rate*100))+'%' as ratee,ROW_NUMBER() over(order by sequ) as row,* from SF_FK_ImageProgress_dtl 


select * from PB_Widget where id='94c3bd67-3890-41d5-b424-402d7823005b'
--/PowerPlat/FormXml/zh-CN/SF_FK/SF_FK_Establishfour.htm


select EPSProjectCode,* from PS_CM_SubContract where EPSProjectCode is null or EPSProjectCode=''

select * from PB_Wizard where WizardId='779d4185-ddab-4610-8ed3-bc50b74dbb49'
--/PowerPlat/FormXml/zh-CN/StdContract/WizardSubContractList.htm

select project_shortname,* from PLN_project


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
where KeyValue='[@KeyValue]' order by SequeID