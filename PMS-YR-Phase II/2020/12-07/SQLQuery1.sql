Select * From View_XLX_HR_HumanInnerJoinUser 
Where  BizAreaId='00000000-0000-0000-0000-00000000000a' 
	   and  EpsProjId='345ed76d-18fa-42a4-b666-4842a12310a0'


SELECT   hum_1.Id AS HumId, hum_1.Code AS HumCode, hum_1.Name AS HumName, hum_1.DeptId, hum_1.DeptName, 
                hum_1.PosiId, hum_1.PosiName, hum_1.EpsProjId AS HumEpsProjId, hum_1.OwnProjId AS HumOwnProjId, 
                hum_1.OwnProjName AS HumOwnProjName, us_1.Id AS UserId, us_1.Code AS UserCode, us_1.Name AS UserName, 
                us_1.EpsProjId AS EpsProjId, us_1.OwnProjId AS UserOwnProjId,us_1.Actived, us_1.OwnProjName AS UserOwnProjName,us_1.BizAreaId 
FROM      (

SELECT   hum.Id, hum.Code, hum.Name, hum.DeptId, hum.DeptName, hum.PosiId, hum.PosiName, df.EpsProjId,
                                 df.OwnProjId, df.OwnProjName
                 FROM      dbo.PB_Human AS hum inner JOIN
                                 dbo.PB_DefaultField AS df ON hum.Id = df.DefaultFieldId) AS hum_1 inner JOIN
                    (SELECT   us.Id, us.Code, us.Name, us.HumanId,us.Actived, us.HumanName, df.EpsProjId, df.OwnProjId, df.OwnProjName, df.BizAreaId
                     FROM      dbo.PB_User AS us inner JOIN
                                     dbo.PB_DefaultField AS df ON us.Id = df.DefaultFieldId) AS us_1 ON hum_1.Id = us_1.HumanId




select * from PB_Human hum left JOIN PB_DefaultField df ON hum.Id = df.DefaultFieldId














---------------------------------------

select 
(select name from pb_department where pb_department.id = XLX_PS_BID_Inquiry.RegDeptId) as a,
* from XLX_PS_BID_Inquiry


alter table XLX_PS_BID_Inquiry add RegDeptName nvarchar(max) null

update XLX_PS_BID_Inquiry set RegDeptName = (select name from pb_department where pb_department.id = XLX_PS_BID_Inquiry.RegDeptId)
select* from pb_human order by regdate desc