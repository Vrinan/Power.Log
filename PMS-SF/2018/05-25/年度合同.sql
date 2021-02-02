--年度合同
--合同审批
--窗体
select * from PB_Widget where id='a5f1606f-d871-43bd-b971-684c3c458d0b'
--采购合同V_PS_SubContract
--/PowerPlat/FormXml/zh-CN/StdContract/Win_SubContract_P.htm
--表单
select * from PB_Widget where id='689f81fa-3adb-4f1f-ac32-20f99cd76266'
--出项合同-采购合同PS_SubContract
--/PowerPlat/FormXml/zh-CN/SF_CM/SubContract_P.htm
select * from PS_CM_SubContract

--付款申请
--窗体
select * from PB_Widget where id='b1a91e89-3158-45a8-a739-c6f84f3916bd'
--采购合同-支付申请V_PS_SubContractApplyMny
--/PowerPlat/FormXml/zh-CN/StdContract/Win_SubContractApplyMoney_P.htm
--表单
select * from PB_Widget where id='37802d42-62c5-4374-af62-676656453965'
--采购合同-支付申请PS_SubContractApplyMoney
--/PowerPlat/FormXml/zh-CN/SF_CM/SubContractApplyMoney_P.htm

--发票登记
--窗体
select * from PB_Widget where id='c6c52a70-a6a2-4d0b-836a-9f53a2d9e06c'
--服务合同-收票记录PS_SubContractInvoice
--/PowerPlat/FormXml/zh-CN/StdContract/Win_SubContractInvoice_S.htm
--表单
select * from PB_Widget where id='a10695fa-bb17-4e22-8a8b-6ccd33a68575'
--服务合同-收票记录PS_SubContractInvoice
--/PowerPlat/FormXml/zh-CN/SF_CM/SubContractInvoice_S.htm


--合同支付
--窗体
select * from PB_Widget where id='ca908e9e-1e6f-4e58-9d2a-bdb771a62a7b'
--采购合同-付款记录PS_SubContractPayment
--/PowerPlat/FormXml/zh-CN/StdContract/Win_SubContractPayment_P.htm
--表单
select * from PB_Widget where id='b9bd19f5-2536-42c3-997f-55bbe4082fa7'
--采购合同-付款记录PS_SubContractPayment
--/PowerPlat/FormXml/zh-CN/SF_CM/SubContractPayment_P.htm

--合同结算
--窗体
select * from PB_Widget where id='fc12b43c-8416-472f-a358-37708fa0fd90'
--采购合同-合同结算PS_SubContractSettlement
--/PowerPlat/FormXml/zh-CN/StdContract/Win_SubContractSettlement_P.htm
--表单
select * from PB_Widget where id='c0a1b9bf-9ba2-4c2a-b3eb-1e2bd096d589'
--采购合同-合同结算PS_SubContractSettlement
--/PowerPlat/FormXml/zh-CN/SF_CM/SubContractSettlement_P.htm
select * from PS_CM_SubContract
--统计
select * from PB_Widget where id='70f719dd-8487-4837-847a-74616de4a532'
--/PowerPlat/FormXml/zh-CN/StdContract/Win_SubContractAnalysis.htm




Select count(*) as RecordCount From  PS_CM_SubContractSettle A 
left  join PS_CM_SubContract B 
on A.SubContract_Guid = B.Id 
Where   (0=0)  and  (0=0)  and  1=1   
and A.SubContract_Guid='62326ffb-2a8d-4bc6-a1b4-df6c64fb35b2' 
and 
(exists 
(select * from PLN_project rr where rr.project_guid=A.EpsProjId 
and (rr.LongCode='1' or charindex('1.',rr.LongCode)=1))) 

Select * From V_PS_CM_SubContract vpcsc 
Where   
--vpcsc.SignDate>='2018-05-01' and vpcsc.SignDate<='2018-05-31' 
--and 
vpcsc.LongCode Like '1%'  
and ((
exists 
(select * from PLN_project rr where rr.project_guid=vpcsc.EpsProjId 
and (rr.LongCode='1' or charindex('1.',rr.LongCode)=1))) ) Order By  RegDate