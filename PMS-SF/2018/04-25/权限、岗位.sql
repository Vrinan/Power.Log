CREATE TABLE SF_KM_DocFolderPoisitionLimit(
	[Id] [uniqueidentifier] NOT NULL,
	[MasterId] [uniqueidentifier] NULL,
	[BoType] [nvarchar](50) NULL,
	[Position] [nvarchar](50) NULL,
	[PositionId] [uniqueidentifier] NULL,
	[HumanName] [nvarchar](50) NULL,
	[HumanId] [uniqueidentifier] NULL,
	[ReadOnly] [int] NULL,
	[CanEdit] [int] NULL,
	[CanUpdate] [int] NULL,
	[AllLimit] [int] NULL,
	[Updatetime] [datetime] NULL,
	[UpdateHuman] [nvarchar](50) NULL,
	[UpdateHumanId] [uniqueidentifier] NULL
) 

select * from SF_KM_DocFolderPoisitionLimit
select MasterId from SF_KM_DocFolderPoisitionLimit where PositionId='9be1ff92-11de-4460-8d51-8b618a9e5afd'
select * from PB_Position where Id='9be1ff92-11de-4460-8d51-8b618a9e5afd'
select * from PB_Position where id='9992AC9E-75B4-4180-B5CB-30AB407871B6'

select * from V_SFPI_DocFolderPoisition

alter view V_SFPI_DocFolderPoisition
as
select x1.*,x2.*,x3.PositionId,x3.Position,x3.MasterId from SF_KM_DocFolder x1 join PB_DefaultField x2 on x1.Id=x2.DefaultFieldId 
join SF_KM_DocFolderPoisitionLimit x3 on x1.Id = x3.MasterId

select * from V_SF_DocFolder

Select Count(*) From V_PS_DocFile VPDFE Where  1=1 
and VPDFE.FolderId='4bf0adda-bb09-3256-c4b8-fe5f9450799d' 
or VPDFE.FolderId in(select Id from V_SF_DocFolder where ParentId='4bf0adda-bb09-3256-c4b8-fe5f9450799d')
or VPDFE.FolderId in (select x1.Id from V_SF_DocFolder x1 where ParentId = '4bf0adda-bb09-3256-c4b8-fe5f9450799d')  
and (VPDFE.FolderId in (select x3.Id from(select x1.Id from V_SFPI_DocFolder x1 where HumanId='eca6ec63-3b88-4af9-8e5b-4ce3487749a8' 
union select x2.Id from V_SFPI_DocFolderPoisition x2 where PositionId='9be1ff92-11de-4460-8d51-8b618a9e5afd') x3) 
or VPDFE.FolderId in (select MasterId from SF_KM_DocFolderPoisitionLimit where PositionId='9be1ff92-11de-4460-8d51-8b618a9e5afd') 
or VPDFE.FolderId in (select ParentId from V_SFPI_DocFolder where HumanId ='eca6ec63-3b88-4af9-8e5b-4ce3487749a8'))  
and (VPDFE.BizAreaId='00000000-0000-0000-0000-00000000000a' and (VPDFE.EpsProjId='ba529d9e-e622-40f5-a906-147fda54f666'))


select * from V_PS_DocFile
Select Count(*) From V_PS_DocFile VPDFE Where  1=1 
and VPDFE.FolderId='ab717613-d170-9641-4205-9998be9a69f9' 
or VPDFE.FolderId in (select x1.Id from V_SF_DocFolder x1 where ParentId = 'ab717613-d170-9641-4205-9998be9a69f9') 
or VPDFE.FolderId in (select x1.Id from V_SF_DocFolder x1 where ParentId = 'ab717613-d170-9641-4205-9998be9a69f9')  
and (VPDFE.FolderId in (select x3.Id from(select x1.Id from V_SFPI_DocFolder x1 
where HumanId='eca6ec63-3b88-4af9-8e5b-4ce3487749a8' 
union select x2.Id from V_SFPI_DocFolderPoisition x2 where PositionId='9be1ff92-11de-4460-8d51-8b618a9e5afd') x3) 
or VPDFE.FolderId in (select MasterId from SF_KM_DocFolderPoisitionLimit where PositionId='9be1ff92-11de-4460-8d51-8b618a9e5afd') 
or VPDFE.FolderId in (select ParentId from V_SFPI_DocFolder where HumanId ='eca6ec63-3b88-4af9-8e5b-4ce3487749a8'))  
and (VPDFE.BizAreaId='00000000-0000-0000-0000-00000000000a' and (VPDFE.EpsProjId='ba529d9e-e622-40f5-a906-147fda54f666') )

sp_helptext V_PS_DocFile
CREATE view [dbo].[V_PS_DocFile]
as
select a.*,isNull(b.countNum,0)countNum,c.BizAreaId,c.RegDate,c.RegHumId,c.RegHumName,ISNULL(c.EpsProjId,'00000000-0000-0000-0000-000000000000') as EpsProjId,
c.sequ from PB_DocFiles a
left join
(select keyvalue,count(1) countNum from PB_Comment where KeyWord = 'docfile' group by KeyValue) b
on a.id = b.KeyValue
left join PB_DefaultField c
on a.id = c.DefaultFieldId
