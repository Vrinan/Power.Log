select * from PB_Widget where id='86613942-549b-4a0d-bd0e-05f4a499ba90'

--/PowerPlat/FormXml/zh-CN/StdMarket/Win_Organize.htm

select id from PB_DocFiles where FolderId in 
('97141d0f-b383-4874-991c-37979589625f','1f668f34-a865-4996-815b-d0a379567c28','4e3096d0-fdd1-4e20-9318-6184022bafa6')

select FolderId, Id = (stuff((select ',' + CONVERT(varchar(8000),Id) from PB_DocFiles where FolderId =  a.FolderId for xml 
path('')),1,1,'')) from PB_DocFiles a where FolderId in 
('97141d0f-b383-4874-991c-37979589625f','1f668f34-a865-4996-815b-d0a379567c28','4e3096d0-fdd1-4e20-9318-6184022bafa6') group by FolderId 


select stuff((select ','+ CONVERT(varchar(8000),Id) from PB_DocFiles where FolderId in 
('97141d0f-b383-4874-991c-37979589625f','1f668f34-a865-4996-815b-d0a379567c28','4e3096d0-fdd1-4e20-9318-6184022bafa6')
 for xml path('')),1,1,'') as idColumns

select a.* from
(select stuff((select ','+ CONVERT(varchar(8000),Id) from PB_DocFiles where FolderId in 
('97141d0f-b383-4874-991c-37979589625f','1f668f34-a865-4996-815b-d0a379567c28','4e3096d0-fdd1-4e20-9318-6184022bafa6') 
for xml path('')),1,1,'') as idColumns) a
