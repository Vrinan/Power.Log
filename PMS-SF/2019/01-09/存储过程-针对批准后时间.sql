--SF_RecruitmentDocumentsPlan
--�б��ļ����Ƽƻ���׼��дʱ��

create proc Proc_UpdateApprDate(@Id nvarchar(2000))
as
--���ҵ��ӱ�
select * from SF_RecruitmentDocumentsPlan_dtl where MasterId=@Id





select dbo.GetApprDate ('c1adfbf9-c793-4362-aebf-c94376760603','�����Ÿ�����','') as ApprDate

    select *
	from pwf_infos a 
	right join pwf_pastNodes b on a.WorkInfoID=b.WorkInfoID 
	left join PB_HumanSign s on b.UserID = s.HumanId
	left join pwf_Opinion c on a.WorkInfoID=c.WorkInfoID and b.SequeID=c.SequeID 
	left join (select dept.Name as DeptName,posi.Id as PosiId,posi.Name as PosiName from PB_Position posi 
	left join PB_Department dept on posi.DeptId=dept.Id) d 
	on case when b.DeptPositionID ='' then '00000000-0000-0000-0000-000000000000' when b.DeptPositionID is null then '00000000-0000-0000-0000-000000000000' else b.DeptPositionID end =d.PosiId
	where KeyValue='c1adfbf9-c793-4362-aebf-c94376760603'