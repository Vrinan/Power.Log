--整改通知导入
select * from PB_Widget where id='a3eb726e-ffa3-47d3-b364-98ae345060cd'
--/PowerPlat/FormXml/zh-CN/SF_HSE/SF_HSE_RectificationNotice.htm
select * from SF_HSE_RectificationNotice_dtl


--检查通报导入
select * from PB_Widget where id='fad00fc5-5ab5-4cf0-a4d1-d52b3b76db04'
--/PowerPlat/FormXml/zh-CN/SF_HSE/SF_HSE_InspectionNotice.htm
select * from SF_HSE_NotifiedDetails where masterid='4d8d364d-a837-455c-a8ba-cb1059af0441'

select * from PB_Human


Select A.* From  SF_HSE_NotifiedDetails A Where   (0=0)  and A.MasterId='4d8d364d-a837-455c-a8ba-cb1059af0441' and  A.EpsProjId='00000000-0000-0000-0000-0000000000a4'


Select A.*,B.* From  PB_Organize A join PB_DefaultField B on A.Id=B.DefaultFieldId Where   (0=0)  and A.RoleType='6' and A.Name='重庆骊业汽车有限公司' and B.BizAreaId='00000000-0000-0000-0000-00000000000a' 