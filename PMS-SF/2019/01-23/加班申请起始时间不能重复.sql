select * from SF_ZH_OverTime

select * from SF_ZH_OverTime_list where MasterId = '564a7339-f087-4016-be05-434c8dee3149'

select * from SF_ZH_OverTime_list where MasterId in (select Id from SF_ZH_OverTime where HumId='1BA0A28B-73BE-4552-A696-54F1F0664EBB')

select * from PB_Widget where id='78e5026e-60d3-477a-b3f5-ccc2eeb18fc3'
--/PowerPlat/FormXml/zh-CN/SF_ZH/SF_ZH_OverTime.htm


--delete from PS_CM_SubContractPayment where IsAuto='自动生成'

--delete from SF_Contract_AmountList where MasterId in(select Id from PS_CM_SubContractPayment where IsAuto='自动生成')


select * from SF_ZH_Overtime where Id='4f91928e-5514-44b6-9831-0a95ac8273af'



select * from SF_ZH_OverTime_list where MasterId in (select Id from SF_ZH_OverTime where HumId='01613EF3-AC1B-4F6B-BE34-150BB4306B10')

delete from SF_ZH_OverTime_list where id='5EB2332C-21E7-8934-BDDB-F7BC9AFEB34C'

select * from PB_Human where Name='陈令川'



select * from SF_ZH_OverTime_list a where a.MasterId !='4f91928e-5514-44b6-9831-0a95ac8273af' and a.MasterId in(select Id from SF_ZH_Overtime b where b.HumId ='01613EF3-AC1B-4F6B-BE34-150BB4306B10')
and a.OverDate in (select c.OverDate from SF_ZH_OverTime_list c where c.MasterId='4f91928e-5514-44b6-9831-0a95ac8273af')
