--��۹���ʦ
--select  b.InboxStatus,a.WorkInfoID, b.UserName,b.SendDate,convert(varchar(10),b.SendDate,120),d.Picture,e.DeptName,e.PosiName,b.ActName,b.BeforeSequeID,coalesce(c.Content,'ͬ��') as Content,b.BeforeSequeID
--from pwf_Infos a
--left join pwf_pastNodes b on a.WorkInfoID = b.WorkInfoID---b�ǽڵ�
--left join pwf_Opinion c on b.WorkInfoID = c.WorkInfoID and  b.SequeID = c.SequeID
--left join PB_HumanSign d on b.UserID = d.HumanId
--left join PB_Human e on b.UserID = e.id
--where a.KeyValue ='ae0e1280-a077-480b-b8fb-0c77b506a8a9'  and (b.ActName='��ͬ/�в�רҵ����ʦ' or b.ActName='���/�в�רҵ����ʦ')  and b.FlowOperate!='Return' and  b.SendDate>=(select top 1 b.SendDate
--from pwf_Infos a
--left join pwf_pastNodes b on a.WorkInfoID = b.WorkInfoID---b�ǽڵ�
--left join pwf_Opinion c on b.WorkInfoID = c.WorkInfoID and  b.SequeID = c.SequeID
--left join PB_HumanSign d on b.UserID = d.HumanId
--left join PB_Human e on b.UserID = e.id
--where a.KeyValue ='ae0e1280-a077-480b-b8fb-0c77b506a8a9'   and b.ActName='��ʼ' and b.InboxStatus='60'  order by  SendDate desc)


--new
select top 1 a.KeyValue,b.WorkInfoID, b.SequeID ,b.ActName, b.UserName,Convert(nvarchar(50),b.SendDate,23) as SendDate, s.Picture,
       case when (c.Content is null or c.Content='') then 'ͬ��' else c.Content end as Content, 
       d.PosiName,d.DeptName 
from pwf_infos a 
right join pwf_pastNodes b on a.WorkInfoID=b.WorkInfoID 
left join PB_HumanSign s on b.UserID = s.HumanId
left join pwf_Opinion c on a.WorkInfoID=c.WorkInfoID and b.SequeID=c.SequeID 
left join (select dept.Name as DeptName,posi.Id as PosiId,posi.Name as PosiName from PB_Position posi 
left join PB_Department dept on posi.DeptId=dept.Id) d 
on case when b.DeptPositionID ='' then '00000000-0000-0000-0000-000000000000' when b.DeptPositionID is null then '00000000-0000-0000-0000-000000000000' else b.DeptPositionID end =d.PosiId
where KeyValue='[@KeyValue]' and ActName !='����' and ActName='��۹�������' and PosiName like '%����%'


select * from pb_user where name='����'