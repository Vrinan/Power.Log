declare @cursor cursor
declare @fksq_id uniqueidentifier--付款申请
declare @fksq_Code nvarchar(500)
declare @fksq_name nvarchar(500)
declare @fksq_finalAmount numeric(18,4)

declare @invoice_id uniqueidentifier--发票Id
declare @je numeric(18,4)--金额
declare @cid uniqueidentifier --合同Id
declare @code nvarchar(500)
declare @name nvarchar(500)
declare @guid nvarchar(50)
--设定游标欲操作的数据集
set @cursor=cursor for
select 合同原始编号,合同名称,金额 from 合同支付$
--打开游标
open @cursor
--移动游标指向到第一条数据，提取第一条数据存放在变量中
fetch next from @cursor into @code,@name,@je
--如果上一次操作成功则继续循环
while(@@fetch_status=0)begin
 	--新建guid
 	 set @guid = newid()
	 --查询合同Id
	 select @cid=Id from PS_CM_SubContract a where a.SubContractCode=@code
	 --查询付款申请信息
	 select @fksq_id = id,
	 @fksq_Code=code,
	 @fksq_name=Title,
	 @fksq_finalAmount=finalapplyamount from PS_CM_SubContractApplyMny where code=@code
	 --查询发票Id
	 select @invoice_id=id from PS_CM_SubContractInvoice where code=@code

	insert into PS_CM_SubContractPayment(id,Status,SubContractType,SubContract_Guid,SubContractInvoice_Guid,Code,Title,TotalPaymentAmount,PaymentWay,
	PaymentAmount,PaymentDate,SubContractApplyCode,SubContractApplyName,SubContractApplyId,SubContractApplyAmount,
	UpdDate,RegDate,RegHumName,RegHumId,OwnProjName,OwnProjId,EpsProjId)
	select @guid, 0,'P',@cid,@invoice_id,合同编号,合同名称,@je,'F2',
	@je,getdate(),@fksq_Code,@fksq_name,@fksq_id,@fksq_finalAmount,
	getdate(),getdate(),'系统管理员','AD000000-0000-0000-0000-000000000000','三峰科技','00000000-0000-0000-0000-0000000000A4','00000000-0000-0000-0000-0000000000A4'
	from 付款申请$ where 合同编号 = @code
	
	--添加金额明细
	insert into SF_Contract_AmountList(id,masterid,amounttype,totalamount)
    values(NewID(),@guid,'03',@je)
	
    --继续提下一行
    fetch next from @cursor into @code,@name,@je
end
--关闭游标
close @cursor
--删除游标
deallocate @cursor



--select * from PS_CM_SubContractPayment where SubContractType='P' and RegHumName='系统管理员'
--delete from PS_CM_SubContractPayment where SubContractType='P' and RegHumName='系统管理员'