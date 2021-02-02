select * from SF_LaborRenewalApply

alter table SF_LaborRenewalApply add HumanName nvarchar(100) null
alter table SF_LaborRenewalApply add Sex nvarchar(100) null
alter table SF_LaborRenewalApply add HumanCode nvarchar(100) null
alter table SF_LaborRenewalApply add Birthday datetime null
alter table SF_LaborRenewalApply add Education nvarchar(100) null
alter table SF_LaborRenewalApply add Profession nvarchar(100) null
alter table SF_LaborRenewalApply add GraduatedSchool nvarchar(100) null
alter table SF_LaborRenewalApply add HumDepartment nvarchar(100) null
alter table SF_LaborRenewalApply add HumPost nvarchar(100) null


select * from PB_Widget where id='ee70466b-e07d-4ad5-926b-7bbdd351f5c4'
--/PowerPlat/FormXml/zh-CN/SF_Complex/SF_LaborRenewalApply.htm

select * from PB_Widget where id='c4e52a29-cc84-4b65-b34c-fdc3a892d837'
--/PowerPlat/FormXml/zh-CN/StdSystem/HumanPage.htm

select * from PB_human where Name='÷£”¿∏’'

select * from PB_Wizard where wizardid='4ffed8ff-b1b1-4421-b39b-e60bef74f372'
--/PowerPlat/FormXML/zh-CN/StdSystem/Wizard_EPDeptHumanList.htm

select dbo.GetBaseData('BD_Sex',a.Sex) as Sex,CONVERT(varchar(100), Birthday, 23) as Birthday,dbo.GetBaseData('BD_Degree',a.Education) as Education,Profession,
GraduatedSchool,HumDepartment,HumPost from SF_LaborRenewalApply a where a.Id=


select a.KeyValue,b.WorkInfoID, b.SequeID ,b.ActName, b.UserName,Convert(nvarchar(50),b.SendDate,23) as SendDate,s.Picture,
       case when (c.Content is null or c.Content='') then 'Õ¨“‚' else c.Content end as Content, 
       d.PosiName,d.DeptName 
from pwf_infos a 
right join pwf_pastNodes b on a.WorkInfoID=b.WorkInfoID 
left join PB_HumanSign s on b.UserID = s.HumanId
left join pwf_Opinion c on a.WorkInfoID=c.WorkInfoID and b.SequeID=c.SequeID 
left join (select dept.Name as DeptName,posi.Id as PosiId,posi.Name as PosiName from PB_Position posi 
left join PB_Department dept on posi.DeptId=dept.Id) d 
on case when b.DeptPositionID ='' then '00000000-0000-0000-0000-000000000000' when b.DeptPositionID is null then '00000000-0000-0000-0000-000000000000' else b.DeptPositionID end =d.PosiId
where  KeyValue='407c6484-d9be-4e26-9fe0-1abcd10e27b1' and ActName='…Í«Î»À'

