declare @cursor cursor
declare @sqje numeric(18,4)--申请金额
declare @sbf numeric(18,4)--设备费
declare @cid uniqueidentifier --合同Id
declare @code nvarchar(500)
declare @name nvarchar(500)
declare @PartyB_Guid nvarchar(50)--供应商id
declare @PartyB_Name nvarchar(500)--供应商名称
declare @guid nvarchar(50)
--设定游标欲操作的数据集
set @cursor=cursor for
select 合同编号,合同名称,供应商名称,申请金额,设备费 from 付款申请$ order by 合同编号
--打开游标
open @cursor
--移动游标指向到第一条数据，提取第一条数据存放在变量中
fetch next from @cursor into @code,@name,@PartyB_Name,@sqje,@sbf
--如果上一次操作成功则继续循环
while(@@fetch_status=0)begin
 	--新建guid
 	 set @guid = newid()
	 --查询合同Id
	 select @cid=Id from PS_CM_SubContract a where a.SubContractCode=@code
 	--查询乙方单位id
 	select top 1 @PartyB_Guid = id from dbo.PB_Organize where name = @PartyB_Name

	insert into PS_CM_SubContractApplyMny(id,Status,SubContractType,SubContract_Guid,Code,Title,ApplyAmount,ApprAmount,
	TotalApplyAmount,TotalApprAmount,FromDate,ToDate,UpdDate,RegDate,RegHumName,RegHumId,OwnProjName,OwnProjId,EpsProjId,PayType,FinalApplyAmount)
	select @guid, 0,'P',@cid,合同编号,合同名称,@sqje,@sqje,
	@sqje,@sqje,getdate(),getdate(),getdate(),getdate(),'系统管理员','AD000000-0000-0000-0000-000000000000','三峰科技','00000000-0000-0000-0000-0000000000A4','00000000-0000-0000-0000-0000000000A4','P2',@sqje
	from 付款申请$ where 合同编号 = @code
	
	--添加金额明细
	insert into SF_Contract_AmountList(id,masterid,amounttype,totalamount)
    values(NewID(),@guid,'03',@sbf)
	
    --继续提下一行
    fetch next from @cursor into @code,@name,@PartyB_Name,@sqje,@sbf
end
--关闭游标
close @cursor
--删除游标
deallocate @cursor
