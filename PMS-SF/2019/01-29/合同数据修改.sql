select Price,Remark,* from SF_CG_Enquiry where Id='c6687214-d6c0-46aa-8957-7ee24e1082f1'

select * from SF_CG_EnquiryCompany where MasterId='c6687214-d6c0-46aa-8957-7ee24e1082f1'
select * from SF_CG_EnquiryCompanyChlid where MasterId='74C8378D-9427-4DAA-B0D5-9D31056353A2'

--update SF_CG_Enquiry set Remark='��1�����ϱ��۾���˰���˷ѡ���2��÷����Ŀ��Ƶ���ϵͳ�ɹ������ҵ�λ�ȼۣ�÷�������ٿƼ����޹�˾��������ͨ���Ҽ۸���ͣ��۸�Ϊ34,320.00Ԫ����Э�̲�Ը�⽵�ۣ����ν����������������Э�̣��õ�λ��ͬ�⽵�ۣ����ν������Ƶ��زɹ��򱨼���͵�÷�������ٿƼ����޹�˾�ɹ����������ڣ�10�죬�ͻ��ص㣺�㶫ʡ÷����÷�����������������������񳡣��ջ���:�Ժ������绰��15123019929����3�����ʽ�� ��ͬǩ�ָ��º�,��������֧����ͬ�ܶ��20%��Ϊ�豸Ԥ�����ͬ�豸��װ������ϣ������պϸ���������֧����ͬ�ܼ۵�75 %��Ϊ�豸���ȿ����ͬ�ܼ۵�5 %��Ϊ������֤���ں�ͬһ���ʱ�������10������������������һ������Ϣ���塣' where Id='c6687214-d6c0-46aa-8957-7ee24e1082f1'
--��1�����ϱ��۾���˰���˷ѡ���2��÷����Ŀ��Ƶ���ϵͳ�ɹ������ҵ�λ�ȼۣ�÷�������ٿƼ����޹�˾��������ͨ���Ҽ۸���ͣ��۸�Ϊ34,320.00Ԫ����Э�̲�Ը�⽵�ۣ����ν����������������Э�̣��õ�λ��ͬ�⽵�ۣ����ν������Ƶ��زɹ��򱨼���͵�÷�������ٿƼ����޹�˾�ɹ����������ڣ�10�죬�ͻ��ص㣺�㶫ʡ÷����÷�����������������������񳡣��ջ���:�Ժ������绰��15123019929����3�����ʽ�� ��ͬǩ�ָ��º�,��������֧����ͬ�ܶ��20%��Ϊ�豸Ԥ�����ͬ�豸��װ������ϣ������պϸ���������֧����ͬ�ܼ۵�75 %��Ϊ�豸���ȿ����ͬ�ܼ۵�5 %��Ϊ������֤���ں�ͬһ���ʱ�������10������������������һ������Ϣ���塣


--update SF_CG_EnquiryCompanyChlid set TotalPrice='34320.00' where MasterId='74C8378D-9427-4DAA-B0D5-9D31056353A2'


select List.*,final.FinalPrice,final.TotalPrice FinalTotalPrice
from
SF_CG_EnquiryCompanyChlid chlid  left join SF_CG_EnquiryCompany com on chlid.MasterId=com.Id 
left join SF_CG_EnquiryList List on List.PlanId= chlid.PlanId 
left join (select PlanCode,Price FinalPrice,TotalPrice from SF_CG_EnquiryCompanyChlid  
         where MasterId=(select Id from SF_CG_EnquiryCompany 
                         where  CompanyId='ZZZZZZZZ-ZZZZ-ZZZZ-ZZZZ-ZZZZZZZZZZZZ')) final on chlid.PlanCode=final.PlanCode 
where chlid.MasterId in ( select Id from SF_CG_EnquiryCompany where  IsPass='��')
and IsSelected=1 
order by
Left(chlid.PlanCode,Len(chlid.PlanCode)-CHARINDEX('-' ,Reverse(chlid.PlanCode))),Cast(Right(chlid.PlanCode,CHARINDEX('-' ,Reverse(chlid.PlanCode))-1) AS INT) 


select * from SF_CG_EnquiryCompanyChlid where Id='7B894200-D847-448F-A891-429EC0053964'
--update SF_CG_EnquiryCompanyChlid set TotalPrice ='34320.00' where Id='7B894200-D847-448F-A891-429EC0053964'


select SubContractAmount,FinalSubContractAmount,* from PS_CM_SubContract where Id='3c31d829-1656-4cb6-b15b-e2855da57ffe'

select * from PS_MK_ContractReview where Id='c822078a-a787-46d8-933a-a4e0dd393317'
--update PS_MK_ContractReview set Status=50 where Id='c822078a-a787-46d8-933a-a4e0dd393317'

--update PS_CM_SubContract set Status=50 where id='3c31d829-1656-4cb6-b15b-e2855da57ffe'