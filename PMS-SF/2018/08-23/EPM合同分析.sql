select * from View_SF_EpsContract where project_name='六安市垃圾填埋场渗滤液处理站应急处理工程'
select SUM(Insum)Insum, SUM(OutSum)OutSum, SUM(P_Sum)P_Sum, SUM(S_Sum)S_Sum, SUM(E_Sum)E_Sum, SUM(C_Sum)C_Sum, SUM(InvoiceAmount)InvoiceAmount, SUM(OutvoiceAmount)OutvoiceAmount,sum(P_OutvoiceAmount)P_OutvoiceAmount, SUM(S_OutvoiceAmount)S_OutvoiceAmount,SUM(E_OutvoiceAmount)E_OutvoiceAmount, SUM(C_OutvoiceAmount)C_OutvoiceAmount, SUM(ReceiveAmount)ReceiveAmount,SUM(PaymentAmount)PaymentAmount, SUM(P_PaymentAmount)P_PaymentAmount,SUM(S_PaymentAmount)S_PaymentAmount, SUM(E_PaymentAmount)E_PaymentAmount, SUM(C_PaymentAmount)C_PaymentAmount from View_SF_EpsContract

select * from View_SF_EpsContract
where Insum!=0 or OutSum!=0 or InvoiceAmount !=0 or OutvoiceAmount!=0

--EPM进行合同分析
select * from PB_Widget where id='48ba02bf-7897-4104-b2d0-1d57c5b733e7'
--/PowerPlat/FormXml/zh-CN/StdContract/Win_StdEPM_MKContractAnalyse.htm

select SUM(Insum)Insum, SUM(OutSum)OutSum, SUM(P_Sum)P_Sum, SUM(S_Sum)S_Sum, SUM(E_Sum)E_Sum, SUM(C_Sum)C_Sum, SUM(InvoiceAmount)InvoiceAmount, SUM(OutvoiceAmount)OutvoiceAmount,sum(P_OutvoiceAmount)P_OutvoiceAmount, SUM(S_OutvoiceAmount)S_OutvoiceAmount,SUM(E_OutvoiceAmount)E_OutvoiceAmount, SUM(C_OutvoiceAmount)C_OutvoiceAmount, SUM(ReceiveAmount)ReceiveAmount,SUM(PaymentAmount)PaymentAmount, SUM(P_PaymentAmount)P_PaymentAmount,SUM(S_PaymentAmount)S_PaymentAmount, SUM(E_PaymentAmount)E_PaymentAmount, SUM(C_PaymentAmount)C_PaymentAmount from View_SF_EpsContract

--EPM出项合同分析
select * from PB_Widget where id='2ce3adce-d536-4a4c-a10e-8803b46ebac0'
--/PowerPlat/FormXml/zh-CN/StdContract/Win_StdEPM_CXContractAnalyse.htm

select * from PS_CM_SubContract 
 where EPSProjectId in(select project_guid from PLN_project)
select * from PS_CM_SubContract a 
left join PLN_project b on a.EPSProjectId = b.project_guid

select  * from PLN_project where project_guid='9E097838-EAB1-44A9-BCEE-88DAAD76020D'
select * from PS_CM_SubContract where EPSProjectId != '04B4C04A-D52A-4C1D-A7F0-0993619BBEF7'
--9E097838-EAB1-44A9-BCEE-88DAAD76020D重庆市第三垃圾焚烧发电厂渗滤液处理工程（江津）
--A1F47E1D-46EF-412B-A591-E87553A6BD33六安市垃圾填埋场渗滤液处理站应急处理工程
--3F9B0070-9C6E-4156-BE9E-8B2425064434重庆市涪陵-长寿生活垃圾焚烧发电项目渗滤液处理系统

SELECT CASE WHEN SUM(SubContractAmount) IS NULL THEN 0 ELSE SUM(SubContractAmount) END FROM PS_CM_SubContract x1

SELECT COUNT(x1.Id) FROM PS_CM_SubContract x1 WHERE SubContractType='E'

SELECT COUNT(x1.Id) FROM PS_CM_SubContract x1 WHERE EPSProjectId=''

SELECT COUNT(x1.Id) FROM PS_CM_SubContract x1 WHERE EPSProjectId='00000000-0000-0000-0000-0000000000a4'  and SignDate >= '2018-01-01'  and SignDate <= '2018-08-23'  

SELECT CASE WHEN SUM(SubContractAmount) IS NULL THEN 0 ELSE SUM(SubContractAmount) END FROM PS_CM_SubContract x1 WHERE EPSProjectId='00000000-0000-0000-0000-0000000000a4'  and SignDate >= '2018-01-01'  and SignDate <= '2018-08-23'  

SELECT COUNT(x1.Id) FROM PS_CM_SubContract x1 WHERE SubContractType='E'


SELECT COUNT(x1.Id) FROM PS_CM_SubContract x1 WHERE EPSProjectId='9e097838-eab1-44a9-bcee-88daad76020d'  

alter VIEW View_SF_EpsOutContract
as
select TOP 1
(select count(*) from PS_CM_SubContract a where a.SubContractType!='Y') as ContractCount,
(select count(*) from PS_CM_SubContract a where a.SubContractType='E') as E_Count,
(select count(*) from PS_CM_SubContract a where a.SubContractType='P') as P_Count,
(select count(*) from PS_CM_SubContract a where a.SubContractType='C') as C_Count,
(select count(*) from PS_CM_SubContract a where a.SubContractType='S') as S_Count,
(select sum(FinalSubContractAmount) from PS_CM_SubContract a where a.SubContractType !='Y') as ContractAmount,
(select sum(FinalSubContractAmount) from PS_CM_SubContract a where a.SubContractType ='E') as E_ContractAmount,
(select sum(FinalSubContractAmount) from PS_CM_SubContract a where a.SubContractType ='P') as P_ContractAmount,
(select sum(FinalSubContractAmount) from PS_CM_SubContract a where a.SubContractType ='C') as C_ContractAmount,
(select sum(FinalSubContractAmount) from PS_CM_SubContract a where a.SubContractType ='S') as S_ContractAmount
from PS_CM_SubContract

select * from View_SF_EpsOutContract
select FinalSubContractAmount,* from PS_CM_SubContract

select id from dbo.returnEPSChildrenTreeIds('4b5d4678-5f00-4eb6-b14d-61e6bfc01674')
select * from PLN_project where project_name='公司项目'

sp_helptext View_SF_EpsContract
select RealApplyAmout,* from PS_CM_ContractApplyMoney 