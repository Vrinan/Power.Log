create Function [dbo].[GetApprDate]
(
    @keyvalue nvarchar(500), --主键
    @nodename nvarchar(500), --流程Id
	@name nvarchar(500)	 --姓名
)
Returns datetime
As
Begin
    declare @ReturnStr datetime
    select @ReturnStr = b.SendDate
	from pwf_infos a 
	right join pwf_pastNodes b on a.WorkInfoID=b.WorkInfoID 
	left join PB_HumanSign s on b.UserID = s.HumanId
	left join pwf_Opinion c on a.WorkInfoID=c.WorkInfoID and b.SequeID=c.SequeID 
	left join (select dept.Name as DeptName,posi.Id as PosiId,posi.Name as PosiName from PB_Position posi 
	left join PB_Department dept on posi.DeptId=dept.Id) d 
	on case when b.DeptPositionID ='' then '00000000-0000-0000-0000-000000000000' when b.DeptPositionID is null then '00000000-0000-0000-0000-000000000000' else b.DeptPositionID end =d.PosiId
	where ActName=@nodename and KeyValue=@keyvalue and b.UserName = @name
    return @ReturnStr
End

select 
