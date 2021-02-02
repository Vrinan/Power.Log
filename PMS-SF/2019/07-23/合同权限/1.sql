--1、输出；2、导出第二个【项目实施启动书】；3、页面

--
--项目实施启动书
select * from PB_Widget where id='7892ed51-c787-4477-a006-fb2ea7df6ce1'
--/PowerPlat/FormXml/zh-CN/SF_PD/SF_ProjectImplementStartBook.htm

select ProjectNameId ,* from SF_PD_ProjectImplementStartBook


select * from PS_CM_SubContract
select * from PS_SubContract_View
delete from PS_SubContract_View where humanName is null
select * from SF_ProjectImplementStartBook_dtl


select * from SF_ProjectImplementStartBook_dtl where MasterId='D10FEBE4-8E22-4C2D-8E4D-E643E30AFB76'
and HumanId not in(select humanid from PS_SubContract_View where masterid='bde37867-0e99-4787-a7c6-9c997d47d2bc')

Select A.* From  SF_ProjectImplementStartBook_dtl A Where   (0=0)  and A.MasterId='d10febe4-8e22-4c2d-8e4d-e643e30afb76'
and A.HumanId not in(select BB.HumanId from PS_SubContract_View BB where BB.MasterId='8892f88a-6118-4d4a-949b-0016813e7e4d')


select masterid from PS_SubContract_View where masterid not in
(
	select id from PS_CM_SubContract where EPSProjectName='重庆市第三垃圾焚烧发电厂渗滤液处理工程（江津）'
)