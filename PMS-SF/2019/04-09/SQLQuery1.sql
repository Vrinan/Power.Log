select a.KeyValue,b.WorkInfoID, b.SequeID , replace(b.ActName,char(13)+char(10),'') as ActName,b.nodecode,
     case  when b.ActName = 'ֻ���ֹ�' and d.DeptName ='�쵼����' then '�ֹ��쵼'
           when b.ActName = '���ֹܺ��ܾ���' and d.DeptName ='�ۺϲ�'  and d.PosiName <> '�����ܼ�' then '�ۺϲ�������'
           when b.ActName = '���ֹܺ��ܾ���' and d.DeptName ='�ۺϲ�'  and d.PosiName = '�����ܼ�' then '�ֹ��쵼'
           when REPLACE(b.ActName,' ','') = '��˾�쵼'  then '1'
      else b.ActName end as ActNames,
      b.UserName,Convert(nvarchar(50),b.SendDate,23) as SendDate, s.Picture,
       case when (c.Content is null or c.Content='') then 'ͬ��' else c.Content end as Content, 
       d.PosiName,d.DeptName ,d.*
from pwf_infos a 
right join pwf_pastNodes b on a.WorkInfoID=b.WorkInfoID 
left join PB_HumanSign s on b.UserID = s.HumanId
left join pwf_Opinion c on a.WorkInfoID=c.WorkInfoID and b.SequeID=c.SequeID 
left join (select dept.Name as DeptName,posi.Id as PosiId,posi.Name as PosiName from PB_Position posi 
left join PB_Department dept on posi.DeptId=dept.Id) d 
on case when b.DeptPositionID ='' then '00000000-0000-0000-0000-000000000000' when b.DeptPositionID is null then '00000000-0000-0000-0000-000000000000' else b.DeptPositionID end =d.PosiId
where KeyValue='a40b5e8d-a95d-473b-8a5f-08f4e37b7024' and ActName !='��ʼ' and ActName !='����' order by SequeID


select * from pwf_pastNodes where WorkInfoID='AB6EB67A-AEAA-C08A-D0B0-7137729442AE'
--select * from pwf_infos where KeyValue='a40b5e8d-a95d-473b-8a5f-08f4e37b7024'



select * from PB_Widget where Id='cd3e67df-b7c2-4686-894c-0b6eef97fc9a'
--/PowerPlat/FormXml/zh-CN/SF_Market/Win_SF_Market_ContractMilepost.htm



select  * from PB_Widget where Id='2eabff35-ad32-4ce4-b07a-9e1d504cc7c6'
--/PowerPlat/FormXml/zh-CN/SF_YX/SF_YX_Requisition.htm


alter table SF_YX_Requisition add DeptId uniqueidentifier null
alter table SF_YX_Requisition add DeptName nvarchar(500) null

select * from PB_Department where Name='���в�'