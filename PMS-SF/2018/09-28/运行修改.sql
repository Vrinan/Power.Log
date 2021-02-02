--运行修改，验收的时候开始测试了:)

--设备检修年度计划统计
select * from PB_Widget where id='60c1765a-e5d4-44a4-a17b-4e20006f3af3'
--/PowerPlat/FormXml/zh-CN/SF_YX/Win_View_SF_YX_EquYearCheck.htm

--1
--设备检修月度计划
select * from SF_YX_EquMonthCheck
select * from SF_YX_EquMonthCheck_list
select ROW_NUMBER() OVER(PARTITION BY a.RunStation ORDER BY Date DESC) AS SerialNumber,
 a.Id,a.Month,a.RunStation,b.Description,b.Date,b.EndDate,b.Amount,b.Id as ListId,b.Type,b.Remark 
from SF_YX_EquMonthCheck a left join SF_YX_EquMonthCheck_list b on a.Id = b.MasterId where a.Status=50
and DATEPART(year, a.Month) ='9' and DATEPART(year, a.Month) = '2018'

--2
--设备检修周计划
select * from PB_Widget where id='22ee9872-830b-4770-b1d4-bc42462df39f'
--/PowerPlat/FormXml/zh-CN/SF_YX/SF_YX_EquWeekCheck.htm
select * from SF_YX_EquWeekCheck where id='a4bb6010-4189-4e43-a2dd-111d8242b59b'
select * from SF_YX_EquWeekCheck_list
select * from SF_YX_EquWeekCheck_dtl

select max(regdate) as maxRegdate,max(Id) as maxMainId from SF_YX_EquWeekCheck where Status=50 and RunStationId='3E5D0E38-DA06-40F7-9349-D10038508DBD' and Type=0
select max(regdate) as maxRegdate,max(Id) as maxMainId from SF_YX_EquWeekCheck where Status=50 and RunStationId='3e5d0e38-da06-40f7-9349-d10038508dbd'

Select XCode_T1.* From (Select A.*, row_number() over(Order By a.Id) as rowNumber From  SF_YX_EquWeekCheck_list A Where   (0=0)  and  1=1  and A.MasterId='731191ec-43b1-45c1-866e-f108523af096') XCode_T1 Where rowNumber Between 1 And 10
Select count(*) as RecordCount From  SF_YX_EquWeekCheck_list A Where   (0=0)  and  (0=0)  and  1=1  and A.MasterId='731191ec-43b1-45c1-866e-f108523af096'
select * from PB_Wizard where WizardId='f0b8cc9e-f5c0-6c6a-8157-a016d3de0964'


select * from (
select hum_1.Id AS HumId, hum_1.Code AS HumCode, hum_1.Name AS HumName, hum_1.DeptId,hum_1.SecondDept,isnull(hum_1.SecondDeptId,'00000000-0000-0000-0000-000000000000') as SecondDeptId,
 hum_1.DeptName, hum_1.PosiId, hum_1.PosiName, hum_1.EpsProjId AS HumEpsProjId, hum_1.OwnProjId AS HumOwnProjId, 
                hum_1.OwnProjName AS HumOwnProjName, us_1.Id AS UserId, us_1.Code AS UserCode, us_1.Name AS UserName, 
                us_1.EpsProjId AS EpsProjId, us_1.OwnProjId AS UserOwnProjId,us_1.Actived, us_1.OwnProjName AS UserOwnProjName,us_1.BizAreaId 
from 
 (SELECT   hum.Id, hum.Code, hum.Name, hum.DeptId, hum.DeptName, hum.PosiId,hum.SecondDept,hum.SecondDeptId, hum.PosiName, df.EpsProjId,
                                 df.OwnProjId, df.OwnProjName
                 FROM      dbo.PB_Human AS hum INNER JOIN
                                 dbo.PB_DefaultField AS df ON hum.Id = df.DefaultFieldId) AS hum_1 inner JOIN
                    (SELECT   us.Id, us.Code, us.Name, us.HumanId,us.Actived, us.HumanName, df.EpsProjId, df.OwnProjId, df.OwnProjName, df.BizAreaId
                     FROM      dbo.PB_User AS us INNER JOIN
                                     dbo.PB_DefaultField AS df ON us.Id = df.DefaultFieldId) AS us_1 ON hum_1.Id = us_1.HumanId) asb
--3--检修班检修周计划select * from PB_Widget where id='96cb32b7-9204-4d44-9ea8-25b3eb2ddb24'--/PowerPlat/FormXml/zh-CN/SF_YX/SF_YX_EquWeekCheckHum.htm--4--水质指标select * from SF_YX_Waterqualityselect * from SF_YX_Waterquality_dtl--设备水质监测数据select * from PB_Widget where id='97db983a-65f1-4184-a505-9c93dd824633'--/PowerPlat/FormXml/zh-CN/SF_YX/Win_SF_YX_EquWaterTesting.htm--水质指标汇总select a.Department,a.RegDate,b.* from SF_YX_Waterquality a left join SF_YX_Waterquality_dtl b on a.Id = b.MasterId--报表select * from PB_Widget where id='739802c3-8c1b-4fd4-8122-ef872624d138'--/PowerPlat/FormXml/zh-CN/SF_YX/Win_View_SF_YX_EquWaterTesting.htmSelect Count(*) From SF_YX_Waterquality a left join SF_YX_Waterquality_dtl b on a.Id = b.MasterId Where  a.Status = 50 and  1=1   and Type='1'and Date>='2018-09-01' and Date<='2018-09-30' and Department is null