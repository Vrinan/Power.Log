select * from PB_Widget where id='b1dbbe05-1300-4f20-9057-7b318f5af220'
--dt1,������������
select ApplyNo,CPL_BankName,CPL_Bankcode,ApplyAmount,* from PS_CM_SubContractApplyMny
--dt2,��Ŀ
select project_shortname,* from PLN_project where project_guid=(select OwnProjId from PS_CM_SubContractApplyMny where id='F97D8297-C060-413A-956E-54EC0CC86FEE')
--dt3,��ͬ
select FinalSubContractAmount,SignDate,SubContractName,* from PS_CM_SubContract where id=(select subcontract_guid from PS_CM_SubContractApplyMny where id='F97D8297-C060-413A-956E-54EC0CC86FEE')
--dt4,�������������֧����ʽ
select (case CPL_CloseName when '014' then '���гжһ��' when '004' then '���'
when '005' then '����֤'  when '009' then '�ֽ�' else '����' end) AS CPL_CloseName from PS_CM_SubContractApplyMny where id='F97D8297-C060-413A-956E-54EC0CC86FEE'
--dt5,����д
declare @a money
set @a = 123
select @a = ApplyAmount from PS_CM_SubContractApplyMny where id='F97D8297-C060-413A-956E-54EC0CC86FEE'
select @a
select dbo.fn_getformatmoney(@a) as money


