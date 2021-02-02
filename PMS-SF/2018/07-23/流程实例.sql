select * from View_SF_WorkFlow
sp_helptext View_SF_WorkFlow
create view View_SF_WorkFlow
as
select  al.*,alr.Content,alr.SequeID,alr.VoteText,alr.VoteValue from pwf_Infos al 
left join pwf_Opinion alr on al.WorkInfoID = alr.WorkInfoID 

select * from pwf_Infos
select * from pwf_PastNodes
select * from pwf_Opinion
where sequeid = (select max(sequeid) from pwf_PastNodes as aa where aa.WorkInfoID = pwf_PastNodes.WorkInfoID)-1
order by sequeid

alter view View_SF_WorkFlowModels
as
select q1.KeyValue,q1.KeyWord,q1.WorkInfoID,q1.RecordStatus,q1.Title,q1.UserName as RegHumName,q1.EpsProjectName ,q1.EpsProjectId,q1.CreateDate,
q2.SequeID,q2.BeforeUserName,q2.UserName,q2.RecvDate,q2.ReadDate,q2.SendDate,
case when q1.RecordStatus = 50 then 0 else DATEDIFF(day,q2.RecvDate,getdate()) end as delayDays ,
q3.Content from pwf_Infos q1
left join
(select * from pwf_PastNodes al
where al.sequeid = (select max(alr.sequeid) from pwf_PastNodes as alr where alr.WorkInfoID = al.WorkInfoID)) q2
on q1.WorkInfoID = q2.WorkInfoID
left join
pwf_Opinion q3 on q2.SequeID-1 = q3.SequeID and q2.WorkInfoID = q3.WorkInfoID

select * from View_SF_WorkFlowModels where workinfoid='4236490D-FF9F-CE6B-DE67-0499DCB1F89D'
select * from pwf_Opinion

select q1.*,q2.*,q3.* from pwf_Infos q1
left join
(select * from pwf_PastNodes al
where al.sequeid = (select max(alr.sequeid) from pwf_PastNodes as alr where alr.WorkInfoID = al.WorkInfoID)) q2
on q1.WorkInfoID = q2.WorkInfoID
left join
pwf_Opinion q3 on q2.SequeID-1 = q3.SequeID and q2.WorkInfoID = q3.WorkInfoID


select * from pwf_PastNodes   where workinfoid='871C13CA-3FF3-3B6F-921B-DBB192C1DD8D'


Select * From View_SF_WorkFlowModels Where   CreateDate>='2018-07-01' and CreateDate<='2018-07-31' and EpsProjectName ='Èı·å¿Æ¼¼' and Title = '1'

declare @receivedate datetime
set @receivedate = '2018-07-23 11:51:06.000'
select getdate();
select DATEDIFF(day,@receivedate,getdate())