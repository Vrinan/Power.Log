select Price,Remark,* from SF_CG_Enquiry where Id='c6687214-d6c0-46aa-8957-7ee24e1082f1'

select * from SF_CG_EnquiryCompany where MasterId='c6687214-d6c0-46aa-8957-7ee24e1082f1'
select * from SF_CG_EnquiryCompanyChlid where MasterId='74C8378D-9427-4DAA-B0D5-9D31056353A2'

--update SF_CG_Enquiry set Remark='（1）以上报价均含税和运费。（2）梅州项目视频监控系统采购，三家单位比价，梅州市祥荣科技有限公司技术评审通过且价格最低，价格为34,320.00元，经协商不愿意降价，本次建议让其承揽，与其协商，该单位不同意降价，本次建议该视频监控采购向报价最低的梅州市祥荣科技有限公司采购，供货周期：10天，送货地点：广东省梅州市梅江区西阳镇奇龙坑垃圾填埋场，收货人:赵红坤，电话：15123019929。（3）付款方式： 合同签字盖章后,买方向卖方支付合同总额的20%作为设备预付款；合同设备安装调试完毕，经验收合格，买方向卖方支付合同总价的75 %作为设备进度款；留合同总价的5 %作为质量保证金，在合同一年质保期满后10个工作日内买方向卖方一次性无息付清。' where Id='c6687214-d6c0-46aa-8957-7ee24e1082f1'
--（1）以上报价均含税和运费。（2）梅州项目视频监控系统采购，三家单位比价，梅州市祥荣科技有限公司技术评审通过且价格最低，价格为34,320.00元，经协商不愿意降价，本次建议让其承揽，与其协商，该单位不同意降价，本次建议该视频监控采购向报价最低的梅州市祥荣科技有限公司采购，供货周期：10天，送货地点：广东省梅州市梅江区西阳镇奇龙坑垃圾填埋场，收货人:赵红坤，电话：15123019929。（3）付款方式： 合同签字盖章后,买方向卖方支付合同总额的20%作为设备预付款；合同设备安装调试完毕，经验收合格，买方向卖方支付合同总价的75 %作为设备进度款；留合同总价的5 %作为质量保证金，在合同一年质保期满后10个工作日内买方向卖方一次性无息付清。


--update SF_CG_EnquiryCompanyChlid set TotalPrice='34320.00' where MasterId='74C8378D-9427-4DAA-B0D5-9D31056353A2'


select List.*,final.FinalPrice,final.TotalPrice FinalTotalPrice
from
SF_CG_EnquiryCompanyChlid chlid  left join SF_CG_EnquiryCompany com on chlid.MasterId=com.Id 
left join SF_CG_EnquiryList List on List.PlanId= chlid.PlanId 
left join (select PlanCode,Price FinalPrice,TotalPrice from SF_CG_EnquiryCompanyChlid  
         where MasterId=(select Id from SF_CG_EnquiryCompany 
                         where  CompanyId='ZZZZZZZZ-ZZZZ-ZZZZ-ZZZZ-ZZZZZZZZZZZZ')) final on chlid.PlanCode=final.PlanCode 
where chlid.MasterId in ( select Id from SF_CG_EnquiryCompany where  IsPass='是')
and IsSelected=1 
order by
Left(chlid.PlanCode,Len(chlid.PlanCode)-CHARINDEX('-' ,Reverse(chlid.PlanCode))),Cast(Right(chlid.PlanCode,CHARINDEX('-' ,Reverse(chlid.PlanCode))-1) AS INT) 


select * from SF_CG_EnquiryCompanyChlid where Id='7B894200-D847-448F-A891-429EC0053964'
--update SF_CG_EnquiryCompanyChlid set TotalPrice ='34320.00' where Id='7B894200-D847-448F-A891-429EC0053964'


select SubContractAmount,FinalSubContractAmount,* from PS_CM_SubContract where Id='3c31d829-1656-4cb6-b15b-e2855da57ffe'

select * from PS_MK_ContractReview where Id='c822078a-a787-46d8-933a-a4e0dd393317'
--update PS_MK_ContractReview set Status=50 where Id='c822078a-a787-46d8-933a-a4e0dd393317'

--update PS_CM_SubContract set Status=50 where id='3c31d829-1656-4cb6-b15b-e2855da57ffe'