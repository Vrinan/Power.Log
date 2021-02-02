alter table SF_FK_ProjCarryOut add ProjectName nvarchar(200) null
alter table SF_FK_ProjCarryOut add ProjectId uniqueidentifier null


select * from SF_FK_ProjCarryOut

select * from PLN_project where project_name = '公司项目'


select id as Project_guid from dbo.[returnEPSChildrenTreeIds]('4b5d4678-5f00-4eb6-b14d-61e6bfc01674')

Select A.* From  PLN_project A Where   (0=0)  and  1=1  and  1=1 and 
(A.project_guid in(select id  from dbo.[returnEPSChildrenTreeIds]('4b5d4678-5f00-4eb6-b14d-61e6bfc01674')))

alter table SF_FK_ProjCarryOut add ProjectName nvarchar(200) null
alter table SF_FK_ProjCarryOut add ProjectId uniqueidentifier null



select * from PB_Widget where id='b92fc059-9e0d-4147-85e3-39e8757ac94f'
--/PowerPlat/FormXml/zh-CN/SF_Market/Win_WorkFlowsModel.htm



select * from View_SF_WorkFlowModels

sp_helptext View_SF_WorkFlowModels

alter view View_SF_WorkFlowModels
as
select q1.KeyValue,q1.KeyWord,q1.WorkInfoID,q1.RecordStatus,q1.Title,q1.UserName as RegHumName,q1.EpsProjectName ,q1.EpsProjectId,q1.CreateDate,
q2.SequeID,q2.BeforeUserName,
case when q1.RecordStatus = 50 then '-' else q2.UserName end as UserName,
q2.RecvDate,q2.ReadDate,q2.SendDate,
case when q1.RecordStatus = 50 then '-' else CONVERT(nvarchar(100),DATEDIFF(day,q2.RecvDate,getdate())) end as delayDays ,
q3.Content from pwf_Infos q1
left join
(select * from pwf_PastNodes al
where al.sequeid = (select max(alr.sequeid) from pwf_PastNodes as alr where alr.WorkInfoID = al.WorkInfoID)) q2
on q1.WorkInfoID = q2.WorkInfoID
left join
pwf_Opinion q3 on q2.SequeID-1 = q3.SequeID and q2.WorkInfoID = q3.WorkInfoID