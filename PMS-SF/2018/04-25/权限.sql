select * from SF_KM_DocFolderLimit
select * from SF_KM_DocFolder

select * from V_SF_DocFolder

sp_helptext V_SF_DocFolder
alter view V_SF_DocFolder
as
select * from 	
SF_KM_DocFolder x1
join PB_DefaultField x2 on x1.Id=x2.DefaultFieldId

Create view V_SFPI_DocFolder
as
select x1.*,x2.*,x3.HumanId,x3.HumanName,x3.MasterId from SF_KM_DocFolder x1 join PB_DefaultField x2 on x1.Id=x2.DefaultFieldId 
join SF_KM_DocFolderLimit x3 on x1.Id = x3.MasterId

select * from V_SF_DocFolder where 1=1
and (Id in(select MasterId from SF_KM_DocFolderLimit where HumanId='ECA6EC63-3B88-4AF9-8E5B-4CE3487749A8') or ParentId in(select MasterId from SF_KM_DocFolderLimit where HumanId='ECA6EC63-3B88-4AF9-8E5B-4CE3487749A8') or Id in(select ParentId from V_SFPI_DocFolder where HumanId =''))
select * from PB_User
select * from PB_Wizard where id='b79f928a-e86a-4cbd-b338-7368de63d0af'



select * from V_SF_DocFolder where id='4CC85BC6-56F3-B490-2432-EEE8B9494294'
select * from V_PS_DocFile where 1=1 and BOKeyWord='SF_KM_DocFolder'
or FolderId in (select Id from V_SF_DocFolder)

Select * From V_PS_DocFile VPDFE Where   1=1   and VPDFE.FolderId='4bf0adda-bb09-3256-c4b8-fe5f9450799d'
or FolderId in (select id from V_SF_DocFolder where ParentId = '4BF0ADDA-BB09-3256-C4B8-FE5F9450799D')

Select * From V_PS_DocFile where 
FolderId in (select id from V_SF_DocFolder where ParentId = '4BF0ADDA-BB09-3256-C4B8-FE5F9450799D')

Select Count(*) From V_PS_DocFile VPDFE Where  1=1 or 
VPDFE.FolderId in (select VPDFE.Id from V_SF_DocFolder where ParentId = '4bf0adda-bb09-3256-c4b8-fe5f9450799d') 
 and (VPDFE.BizAreaId='00000000-0000-0000-0000-00000000000a' and (VPDFE.EpsProjId='ba529d9e-e622-40f5-a906-147fda54f666') )


 --所有附件
 select * from V_PS_DocFile where BOKeyWord='SF_KM_DocFolder'
 --左侧层级
  select * from V_SF_DocFolder 

 Select Count(*) From V_PS_DocFile VPDFE Where   1=1   
 and VPDFE.FolderId='d2fe5fe7-a69d-b1db-33e2-42db9d33ff8c' 

select * from V_PS_DocFile VPDFE where BOKeyWord='SF_KM_DocFolder' and
VPDFE.FolderId='4BF0ADDA-BB09-3256-C4B8-FE5F9450799D' or 
VPDFE.FolderId in (select x1.Id from V_SF_DocFolder x1 where ParentId = '4bf0adda-bb09-3256-c4b8-fe5f9450799d') 

select * from V_PS_DocFile where FolderId in (select x1.Id from V_SF_DocFolder x1 where ParentId = '4bf0adda-bb09-3256-c4b8-fe5f9450799d') 


Select XCode_T1.* From (Select *, row_number() over(Order By Regdate DESC ) as rowNumber From V_PS_DocFile VPDFE Where 1=1 and VPDFE.FolderId='fb058b1b-032f-c283-e0b3-e09ad8bd9977' 
or VPDFE.FolderId in (select x1.Id from V_SF_DocFolder x1 where ParentId = 'fb058b1b-032f-c283-e0b3-e09ad8bd9977') 
and (VPDFE.BizAreaId='00000000-0000-0000-0000-00000000000a' and (VPDFE.EpsProjId='ba529d9e-e622-40f5-a906-147fda54f666') )) XCode_T1 Where rowNumber Between 1 And 15

select * from PB_User

select * from V_SFPI_DocFolder

select x3.Id from
(select x1.Id from V_SFPI_DocFolder x1 where HumanId='' 
union
select x2.Id from V_SFPI_DocFolderPoisition x2 where PoisitionId='') x3


Select XCode_T1.* From (Select *, row_number() over(Order By Regdate DESC ) as rowNumber From V_PS_DocFile VPDFE 
Where 1=1 and VPDFE.FolderId='fb058b1b-032f-c283-e0b3-e09ad8bd9977' 
or VPDFE.FolderId in (select x1.Id from V_SF_DocFolder x1 where ParentId = 'fb058b1b-032f-c283-e0b3-e09ad8bd9977') 
and VPDFE.FolderId in (select x3.Id from(select x1.Id from V_SFPI_DocFolder x1 where HumanId='fb058b1b-032f-c283-e0b3-e09ad8bd9977' 
union select x2.Id from V_SFPI_DocFolderPoisition x2 where PositionId='fb058b1b-032f-c283-e0b3-e09ad8bd9977') x3)
and (VPDFE.BizAreaId='00000000-0000-0000-0000-00000000000a' 
and (VPDFE.EpsProjId='ba529d9e-e622-40f5-a906-147fda54f666') )) XCode_T1 Where rowNumber Between 1 And 15