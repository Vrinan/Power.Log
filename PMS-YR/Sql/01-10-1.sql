--主表
select Code,Title,FinalSubContractAmount,(case CPL_CloseName when '014' then '银行承兑汇款' when '004' then '汇款'
 when '005' then '信用证'  when '009' then '现金' else '其他' end) AS CPL_CloseName,* from PS_CM_SubContractApplyMny
 where id='82be133d-b656-4186-948b-800842887354'

--合同
select SubContractCode,SubContractName,SubContractAmount,ChangeAmount,* from PS_CM_SubContract where
id=(select Subcontract_guid from PS_CM_SubContractApplyMny where id='82be133d-b656-4186-948b-800842887354')

--明细
select matbsname,matcode,MatName,MatModel,matunit,MatSpec,* from PS_CM_SubContractApplyMny_Mat



