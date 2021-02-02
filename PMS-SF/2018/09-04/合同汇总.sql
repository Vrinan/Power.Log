--出项合同列表
select * from PB_Widget where id='6cd09cf8-a271-498f-bb09-0278ac1d1cea'
--/PowerPlat/FormXml/zh-CN/StdContract/Win_SubContractList.htm

sp_helptext V_PS_SubContractList
CREATE VIEW [dbo].[V_PS_SubContractList]
as
SELECT * FROM PS_CM_SubContract


Select Count(*) From PS_CM_SubContract Where    EPSProjectId='04b4c04a-d52a-4c1d-a7f0-0993619bbef7' and SubContractType='P' and SignDate BETWEEN '2018-01-01' AND '2018-09-04' and status=50

select * from PS_MK_ContractInfo

select * from pb_wizard where WizardId='242f4cd3-312b-312b-7780-85dd7596f349'
--/PowerPlat/FormXml/zh-CN/Wizard/进项合同支付选择合同请款.html