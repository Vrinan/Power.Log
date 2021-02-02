--SF_RecruitmentDocumentsPlan
--招标文件编制计划批准后反写时间

create proc Proc_UpdateApprDate(@Id nvarchar(2000))
as
--先找到子表
select * from SF_RecruitmentDocumentsPlan_dtl where MasterId=@Id





select dbo.GetApprDate ('c1adfbf9-c793-4362-aebf-c94376760603','各部门负责人','') as ApprDate

    select *
	from pwf_infos a 
	right join pwf_pastNodes b on a.WorkInfoID=b.WorkInfoID 
	left join PB_HumanSign s on b.UserID = s.HumanId
	left join pwf_Opinion c on a.WorkInfoID=c.WorkInfoID and b.SequeID=c.SequeID 
	left join (select dept.Name as DeptName,posi.Id as PosiId,posi.Name as PosiName from PB_Position posi 
	left join PB_Department dept on posi.DeptId=dept.Id) d 
	on case when b.DeptPositionID ='' then '00000000-0000-0000-0000-000000000000' when b.DeptPositionID is null then '00000000-0000-0000-0000-000000000000' else b.DeptPositionID end =d.PosiId
	where KeyValue='c1adfbf9-c793-4362-aebf-c94376760603'