--╤сап
select * from PB_Messages where IsTextMessage=1

select * from PB_Widget where id='6d673167-51fb-4284-969c-08a7625a6c37'
--/PowerPlat/FormXml/zh-CN/StdCommunicate/PS_ReceivePaper.htm


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
pwf_Opinion q3 on q2.SequeID-1 = q3.SequeID and q2.WorkInfoID = q3.WorkInfoID where q1.KeyWord='PS_FileContact'


select * from pwf_PastNodes
