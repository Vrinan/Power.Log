--付款申请👉合同支付
--游标
--每日自动生成，已批准的付款申请生成合同支付
alter proc Proc_AutomaticGeneratePayment
as
declare @SubContract_Guid nvarchar(200)
declare @SubContractType nvarchar(200)
declare @MainCode nvarchar(200)
declare @MainTitle nvarchar(200)
declare @FinalApplyAmount float
declare @ApprDate datetime
declare @RegHumId nvarchar(200)
declare @RegHumName nvarchar(200)
declare @ApplyCode nvarchar(200)
declare @ApplyTitle nvarchar(200)
declare @ApplyId nvarchar(200)
declare @CurrencyType nvarchar(200)
declare @Memo nvarchar(4000)
declare @MainId uniqueidentifier
declare @IsAuto nvarchar(200)='自动生成'
----------1、找到所有未生成合同支付的已批准的付款申请
declare Cur cursor for
--定义循环集合
select SubContract_Guid,SubContractType,REPLACE(Code,'FKSQ','HTZF') AS Code,REPLACE(Title,'申请','') as Title,
FinalApplyAmount,isnull(ApprDate,GETDATE()) as ApprDate,RegHumId,RegHumName,Code,Title,Id,CurrencyType,Memo
from PS_CM_SubContractApplyMny a where a.Status=50 and Id not in (
select SubContractApplyId from PS_CM_SubContractPayment)
open Cur
 --取游标指向的当前行的数据赋值给变量
FETCH NEXT FROM Cur INTO @SubContract_Guid,@SubContractType,@MainCode,@MainTitle,@FinalApplyAmount,@ApprDate,@RegHumId,@RegHumName,@ApplyCode,@ApplyTitle,@ApplyId,@CurrencyType,@Memo
WHILE(@@FETCH_STATUS = 0) --游标读取下一条数据是否成功
	begin
		set @MainId=newid()
		----------2、生成主表
		insert into PS_CM_SubContractPayment values(@MainId,@SubContract_Guid,@SubContractType,null,@MainCode,@MainTitle,
		'F2',@FinalApplyAmount,@ApprDate,null,null,GETDATE(),GETDATE(),@RegHumName,@RegHumId,
		'三峰科技','00000000-0000-0000-0000-0000000000A4','00000000-0000-0000-0000-0000000000A4',@RegHumId,@RegHumName,null,50,@Memo,
		@FinalApplyAmount,@ApplyCode,@ApplyTitle,@ApplyId,@FinalApplyAmount,@CurrencyType,@IsAuto)
		----------3、生成子表
		insert into SF_Contract_AmountList
		select NEWID(),@MainId,FinancialDocumentNumber,AmountType,NoTaxAmount,TaxRate,TaxAmount,TotalAmount,Memo,updDate,PayDescription from SF_Contract_AmountList where MasterId=@ApplyId
		--取游标指向的当前行的数据赋值给变量@id
		print '已生成'+@MainCode
		FETCH NEXT FROM Cur INTO @SubContract_Guid,@SubContractType,@MainCode,@MainTitle,@FinalApplyAmount,@ApprDate,@RegHumId,@RegHumName,@ApplyCode,@ApplyTitle,@ApplyId,@CurrencyType,@Memo
	END 
CLOSE Cur
DEALLOCATE Cur