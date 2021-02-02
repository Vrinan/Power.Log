--付款申请PS_SubContractApplyMoney
--PS_CM_SubContractApplyMny
--合同支付PS_SubContractPayment
--PS_CM_SubContractPayment

--金额明细SF_Contract_AmountList

--1695
select SubContract_Guid,SubContractType,* from PS_CM_SubContractApplyMny 
--136
select SubContract_Guid,SubContractType,* from PS_CM_SubContractPayment
select * from PS_CM_SubContractPayment

select SubContract_Guid,SubContractType,REPLACE(Code,'FKSQ','HTZF') AS Code,REPLACE(Title,'申请','') as Title,
FinalApplyAmount,isnull(ApprDate,GETDATE()) as ApprDate,RegHumId,RegHumName,Code,Title,Id,CurrencyType,Memo
from PS_CM_SubContractApplyMny a where a.Status=50 and SubContract_Guid not in (
select SubContract_Guid from PS_CM_SubContractPayment) 



insert into PS_CM_SubContractPayment values(NEWID(),'3F1752F0-3484-4EA2-89FA-848C983497F4','Y',null,'HTZF-181115-019','SK2018（备）-116丰盛运行站支付',
'F2',50350,'2018-11-29 15:47:33.000',null,null,GETDATE(),GETDATE(),'郑永刚','75F3A79F-2794-408D-8AE1-AF32686E15F6',
'三峰科技','00000000-0000-0000-0000-0000000000A4','00000000-0000-0000-0000-0000000000A4','75F3A79F-2794-408D-8AE1-AF32686E15F6','郑永刚',null,0,'memo',
50350,'FKSQ-181115-019','SK2018（备）-116丰盛运行站支付申请','F77DCCCE-F747-492F-B868-002BEFFF7847',50350,'CNY'
)

select Id,MasterId,FinancialDocumentNumber,AmountType,NoTaxAmount,TaxRate,TaxAmount,TotalAmount,Memo,updDate,PayDescription from SF_Contract_AmountList where MasterId='22A16383-BF5E-4FD8-ACC5-005A5AD570CC'

select GETDATE()

alter table PS_CM_SubContractPayment add IsAuto nvarchar(200) null