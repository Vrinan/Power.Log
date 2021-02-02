--项目机会
select * from PB_Widget where id='4c7b197e-93e4-4534-8c46-575ccf60c76d'
--/PowerPlat/FormXml/zh-CN/StdMarket/Win_ProjectInfo.htm

select count(*) as BidCount from SF_OpenBidding left join PB_DefaultField on SF_OpenBidding.Id = PB_DefaultField.DefaultFieldId where PB_DefaultField.Status=50

select count(*) as SelfBidCount from SF_OpenBidding left join PB_DefaultField on SF_OpenBidding.Id = PB_DefaultField.DefaultFieldId where PB_DefaultField.Status=50 and SF_OpenBidding.radiobuttoncolumn = '01'

select * from pb_widget where id='9b283e34-b426-4506-b917-7a23e95a7385'
--/PowerPlat/FormXml/zh-CN/StdMarket/isBidReview.htm

select sum(a.ContractAmount) as Amount from (select EpsProjectId, SUM(isNull(FinalContractAmount, 0)) ContractAmount from PS_MK_ContractInfo where PS_MK_ContractInfo.Status=50 group by EpsProjectId) a 
where a.EPSProjectId in(select project_guid from PLN_project where STATE=1)

select sum(a.ContractAmount) as Amount from 
(select PS_MK_ContractInfo.EPSProjectId, SUM(isNull(PS_CM_ContractReceipt.ReceiveAmount, 0)) ContractAmount from PS_MK_ContractInfo left join PS_CM_ContractReceipt on PS_MK_ContractInfo.Id = PS_CM_ContractReceipt.Contract_Guid where PS_MK_ContractInfo.Status=50 group by EpsProjectId) a 
where a.EPSProjectId in(select project_guid from PLN_project where STATE=1)
/
select sum(a.ContractAmount) as Amount from (select EpsProjectId, SUM(isNull(FinalContractAmount, 0)) ContractAmount from PS_MK_ContractInfo where PS_MK_ContractInfo.Status=50 group by EpsProjectId) a 
where a.EPSProjectId in(select project_guid from PLN_project where STATE=1)


select COUNT(*) as ContractCount from PS_MK_ContractInfo where year(SignedDate) = year(GETDATE()) and Status=50
select sum(ContractAmount) as ContractAmount from 
(select EpsProjectId, SignedDate, isNull(FinalContractAmount, 0) ContractAmount from PS_MK_ContractInfo where Status=50 and year(SignedDate) = year(GETDATE())) a

select Count(1) ContractNum,SUM(ISNULL(ReceiveAmount,0)) as RealApplyAmout from PS_CM_ContractReceipt where YEAR(RegDate)=YEAR(GETDATE())  and  Status in (35,50)


select * from PB_Widget where id='6f4a02c7-1706-4b0e-82ba-40e3a9780e1c'
select COUNT(*) as ContractCount from PS_MK_ContractInfo where year(SignedDate) = year(GETDATE()) and Status=50


select SUM(Insum)Insum, SUM(OutSum)OutSum, SUM(P_Sum)P_Sum, SUM(S_Sum)S_Sum, SUM(E_Sum)E_Sum, SUM(C_Sum)C_Sum, SUM(InvoiceAmount)InvoiceAmount, SUM(OutvoiceAmount)OutvoiceAmount,sum(P_OutvoiceAmount)P_OutvoiceAmount, SUM(S_OutvoiceAmount)S_OutvoiceAmount,SUM(E_OutvoiceAmount)E_OutvoiceAmount, SUM(C_OutvoiceAmount)C_OutvoiceAmount, SUM(ReceiveAmount)ReceiveAmount,SUM(PaymentAmount)PaymentAmount, SUM(P_PaymentAmount)P_PaymentAmount,SUM(S_PaymentAmount)S_PaymentAmount, SUM(E_PaymentAmount)E_PaymentAmount, SUM(C_PaymentAmount)C_PaymentAmount from View_SF_EpsContract 