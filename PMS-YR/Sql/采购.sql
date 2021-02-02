----物资库
--select matcode from PS_MDM_Mat group by matcode having count(matcode)>1
----物资计划
--select * from PS_PUR_BOMFile
--select * from PS_PUR_BOM where MasterId='514b9fe3-8a2e-48c3-acfa-d78c50b0e1dd'
--insert into PS_PUR_BOM values(newid(),'514B9FE3-8A2E-48C3-ACFA-D78C50B0E1DD',11999,newid())
----请购单
--select * from XLX_PUR_Request
--select * from XLX_PUR_Request_List
----中间表
--select * from XLX_MDM_MAT_Middle
--select matcode from XLX_MDM_MAT_Middle group by MatCode having count(MatCode)>1


--1、中间表
select matshortname,matlongname,* from XLX_MDM_MAT_Middle where matcode='1601106060001'
--delete from XLX_MDM_MAT_Middle where id='007070FB-3F55-4AD8-A4DE-00DD89F6EC34'
--fk:C7DA344C-8BBA-4499-A279-2B8A7A82F64A 物资计划主表ID
--update XLX_MDM_MAT_Middle set matcode='1329901070007' where id='C69A4C33-B6C1-4E30-B976-BA564638E908'
--2、物资计划
select * from PS_PUR_BOMFile where id='CD3CC83A-FFEA-4845-B47B-D5D4B47B919A'
select matcode,matname,matdescription,* from PS_PUR_BOM where MasterId='799454B3-BDA7-45B4-BD3F-1D3B54715D41'
--update PS_PUR_BOM set matcode='1329901070007' where id='A9C21F63-E3AD-4CF5-9D12-A74B8656BE88'
--3、请购单
select Id,* from XLX_PUR_Request where Order_Guid='799454B3-BDA7-45B4-BD3F-1D3B54715D41'
select matcode,matname,Model,* from XLX_PUR_Request_list where fk='C082C506-7468-4CE8-AE40-10E3367AA222'
--update XLX_PUR_Request_list set matcode='1329901070007' where id='A49FF94F-AEFD-48C6-9CBD-5D548C118B21'
--4、合同
select * from PS_CM_SubContract where order_guid='C082C506-7468-4CE8-AE40-10E3367AA222'
select matcode,MatName,MatModel,* from PS_CM_SubContract_MatItem where masterid='7E216686-47E6-4288-82CC-292E665B1B91'
--update PS_CM_SubContract_MatItem set MatCode='1329901070007' where id='4C6DD2BC-16B6-4A19-81AC-E370532483C7'

select Id,* from XLX_PUR_Request
select matcode,matname,Model,* from XLX_PUR_Request_list where fk='541F108F-5A39-4F93-BCDD-0199FF99A54E'


select * from PS_PUR_BOMfile where code='2017110067'
select * from PS_PUR_BOM where MasterId='D5175842-C987-484F-905F-A0FD6FAD8191'
--update PS_PUR_BOM set matbscode = '1.09.06.06.02' where id='EAC58B60-F42D-41B4-B5F2-9F21B3949B5D'
select matshortname,matlongname,matbs_code,ID from PS_MDM_Mat 
where matshortname='同心异径管' and matlongname='同心异径管Ф60.3*4.5/Ф33.7*3.520#GB/T12459-2017,Ⅰ'
select * from PB_Widget where id='04e4b031-3973-4f3d-8e7c-5cde4e2fbda0'

