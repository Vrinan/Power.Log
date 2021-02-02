select * from PB_Messages where istextmessage = 1


--select * from PS_COM_FileContact a 
--left join
--pb_docfile

select a.ToDept,a.Title,dbo.GetBaseData('PS_FileType',a.FileType) as FileType,
b.Id,b.FolderId,b.BOKeyWord,b.Name,b.FileExt,b.ServerUrl,b.RegHumName,b.RegDate from PS_COM_FileContact a
left join
PB_DocFiles b on a.Id = b.FolderId where  BOKeyWord='PS_FileContact'


select * from PB_DocFiles