--����
select Code,Title,FinalSubContractAmount,(case CPL_CloseName when '014' then '���гжһ��' when '004' then '���'
 when '005' then '����֤'  when '009' then '�ֽ�' else '����' end) AS CPL_CloseName,* from PS_CM_SubContractApplyMny
 where id='82be133d-b656-4186-948b-800842887354'

--��ͬ
select SubContractCode,SubContractName,SubContractAmount,ChangeAmount,* from PS_CM_SubContract where
id=(select Subcontract_guid from PS_CM_SubContractApplyMny where id='82be133d-b656-4186-948b-800842887354')

--��ϸ
select matbsname,matcode,MatName,MatModel,matunit,MatSpec,* from PS_CM_SubContractApplyMny_Mat



