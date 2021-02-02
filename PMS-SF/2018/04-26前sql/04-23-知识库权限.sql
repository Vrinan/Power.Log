select * from PB_Widget where id='e2b4384a-00ef-4a39-a533-2d1d9206f0fd'
--/PowerPlat/FormXml/zh-CN/StdKM/Win_PS_KM_DocFolder.htm

--权限表
select * from SF_LibraryRight
--左右的视图
select * from V_PS_DocFolder
select * from PB_DocFolder x1 join PB_DefaultField x2 on x1.Id=x2.DefaultFieldId
--企业知识分类
select * from PS_KM_DocFolder
select Id from PS_KM_DocFolder a left join PB_DefaultField b on a.Id =b.DefaultFieldId where OwnProjName is null
select * from V_PS_KM_DocFolder
delete from PS_KM_DocFolder where id in (select Id from PS_KM_DocFolder a left join PB_DefaultField b on a.Id =b.DefaultFieldId where OwnProjName is null)
Select MAX(Sequ) as Sequ From PS_KM_DocFolder a join PB_DefaultField b on a.Id=b.DefaultFieldId

update PB_DefaultField set EpsProjId='BA529D9E-E622-40F5-A906-147FDA54F666' where DefaultFieldId in(select id from PS_KM_DocFolder)
update PB_DefaultField set BizAreaId='00000000-0000-0000-0000-000000000000' where DefaultFieldId in(select id from PS_KM_DocFolder)
update PB_DefaultField set OwnProjId='BA529D9E-E622-40F5-A906-147FDA54F666' where DefaultFieldId in(select id from PS_KM_DocFolder)
update PB_DefaultField set OwnProjName='某电厂EPC项目计划' where DefaultFieldId in(select id from PS_KM_DocFolder)

select Pro_owners_name,EpsProjId,* from PLN_project where project_name='某电厂EPC项目计划'
select * from PLN_project

--SF知识库
select * from V_SF_DocFolder
select * from V_PS_DocFolder
select * from V_PS_KM_DocFolder
sp_helptext V_SF_KM_DocFolder

create view V_SF_KM_DocFolder
as
select a.*,Name+isNull(' (-'+replace(str(b.filenum),' ','')+'-)','') Name2,
c.EpsProjId,c.BizAreaId from
SF_KM_DocFolder a left join
(select FolderId,count(1) filenum from  PB_DocFiles group by FolderId) b
on a.id = b.FolderId
left join PB_DefaultField c
on a.Id = c.DefaultFieldId


select * from SF_KM_DocFolder x1
join PB_DefaultField x2 on x1.Id=x2.DefaultFieldId

select * from PB_DocFolder x1
join PB_DefaultField x2 on x1.Id=x2.DefaultFieldId

select * from SF_KM_DocFolder
select * from PB_DocFolder



select * from information_schema.tables where TABLE_NAME = 'V_SF_DocFolder'
select * from syscolumns where id=OBJECT_ID('V_SF_DocFolder')
select * from syscolumns where id=OBJECT_ID('V_PS_DocFolder')

select * from SF_KM_DocFolder x1 join PB_DefaultField x2 on x1.Id=x2.DefaultFieldId
set IDENTITY_INSERT PB_DefaultField ON
select * from V_PS_DocFile

select a.*,isNull(b.countNum,0)countNum,c.BizAreaId,c.RegDate,c.RegHumId,c.RegHumName,ISNULL(c.EpsProjId,'00000000-0000-0000-0000-000000000000'),
c.sequ from PB_DocFiles a
left join
(select keyvalue,count(1) countNum from PB_Comment where KeyWord = 'docfile' group by KeyValue) b
on a.id = b.KeyValue
left join PB_DefaultField c
on a.id = c.DefaultFieldId

select * from PB_DocFiles
select * from PB_Comment where KeyWord = 'docfile'
select * from PB_DefaultField

select * from information_schema.tables where TABLE_NAME like '%right%'
select * from PB_Right
select * from PB_RightGroup
select * from PB_RightTreeType

select * from PB_Widget where id='31da163b-0b03-4b32-ac12-38c9b61828ee'
--/PowerPlat/FormXml/zh-CN/StdDocument/Win_PS_DocFile.htm

Select XCode_T1.* From (Select *, row_number() over(Order By Regdate DESC ) as rowNumber From V_PS_DocFile VPDFE
 Where 1=1 and VPDFE.FolderId='b3cbc82c-f732-9295-8448-fd700bb19255' and (VPDFE.BizAreaId='00000000-0000-0000-0000-00000000000a' 
 and VPDFE.EpsProjId='ba529d9e-e622-40f5-a906-147fda54f666' )) XCode_T1 Where rowNumber Between 1 And 15


 SELECT * FROM V_PS_DocFile where EpsProjId is not null
 SELECT * FROM V_PS_DocFile where sequ ='233'
 select * from PB_Organize a join PB_DefaultField b on a.Id = b.DefaultFieldId
select * from V_PS_DocFile 

alter view [dbo].[V_PS_DocFile]
as
select a.*,isNull(b.countNum,0)countNum,c.BizAreaId,c.RegDate,c.RegHumId,c.RegHumName,ISNULL(c.EpsProjId,'00000000-0000-0000-0000-000000000000') as EpsProjId,
c.sequ from PB_DocFiles a
left join
(select keyvalue,count(1) countNum from PB_Comment where KeyWord = 'docfile' group by KeyValue) b
on a.id = b.KeyValue
left join PB_DefaultField c
on a.id = c.DefaultFieldId

--所有附件
select * from PB_DocFiles
--所有评论
select * from PB_Comment
--缺省表
select * from PB_DefaultField

--——————————————
select * from V_SF_DocFolder
sp_helptext V_SF_DocFolder
create view V_SF_DocFolder
as
select * from 	
SF_KM_DocFolder x1
join PB_DefaultField x2 on x1.Id=x2.DefaultFieldId



