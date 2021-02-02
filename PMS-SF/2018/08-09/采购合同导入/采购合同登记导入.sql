declare @cursor cursor
declare @code nvarchar(500)
declare @yf nvarchar(500)
declare @qk nvarchar(50)
declare @xs nvarchar(50)
declare @money numeric(18,4)
declare @PartyB_Guid nvarchar(50)--乙方id
declare @RunStatus nvarchar(50)--执行情况
declare @ContractForm nvarchar(50)--合同形式
declare @guid nvarchar(50)
--设定游标欲操作的数据集
set @cursor=cursor for
select 合同编号,乙方, 执行情况 ,合同形式,合同金额 from dbo.合同登记$ order by 合同编号
--打开游标
open @cursor
--移动游标指向到第一条数据，提取第一条数据存放在变量中
fetch next from @cursor into @code,@yf,@qk,@xs,@money
--如果上一次操作成功则继续循环
while(@@fetch_status=0)begin
 	--生产guid
 	 set @guid = newid()
 	--查询乙方单位id
 	select @PartyB_Guid = id from dbo.PB_Organize where name = @yf
 	--执行情况
 	if(@qk = '待签')
 		begin
 		   set @RunStatus = 1
 		end
 	else if(@qk = '执行中')
 		begin
 		   set @RunStatus = 2
 		end
 	else
 		begin
 		  set @RunStatus = 3
 		end 
 	
 	--合同形式
 	if(@xs = '开口合同')
 		begin
 		   set @ContractForm = 1
 		end
 	else
 		begin
	 	   set @ContractForm = 2 
 		end 
	insert into PS_CM_SubContract(id,status,SubContractType,SubContractCode,SubContractName,SubContractAmount,FinalSubContractAmount,
	PartyA,PartyAPerson,PartyAPersonId,PartyB,PartyB_Guid,SignDate,UpdDate,RegDate,RegHumName,RegHumId,OwnProjName,OwnProjId,EpsProjId,
	EPSProjectId,EPSProjectCode,EPSProjectName,RunStatus,ContractType,ContractForm)
	select @guid, 0,'P',合同编号,合同名称,合同金额,合同金额,'重庆三峰科技有限公司','雷东','FF528BB6-B2D8-4D47-8952-C69E987ADCB0',
	乙方,@PartyB_Guid,签订日期,getdate(),getdate(),'系统管理员','AD000000-0000-0000-0000-000000000000','三峰科技','00000000-0000-0000-0000-0000000000A4','00000000-0000-0000-0000-0000000000A4',
	'ADA801CA-1937-4111-8555-4096EAC88EB4','mzz','膜制造项目',@RunStatus,'03',@ContractForm
	from 合同登记$ where 合同编号 = @code
	
	--添加金额明细
	insert into SF_Contract_AmountList(id,masterid,amounttype,taxamount,totalamount)
    values(NewID(),@guid,'03',@money,@money)
		
	--添加支付节点	
	insert into PS_CM_SubContract_PayNodes(id,masterid,sequ,Paytype,paypercent,payAmount)
    values(newid(),@guid,1,'JD',100,@money)
	
    --继续提下一行
    fetch next from @cursor into @code,@yf,@qk,@xs,@money
end
--关闭游标
close @cursor
--删除游标
deallocate @cursor
