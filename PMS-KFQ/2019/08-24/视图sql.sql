select * from PB_User where name='李刚'

--View_WorkPastUsers
--View_WorkInfos
sp_helptext View_WorkPastUsers

--这是新的
--1
alter view [dbo].[View_WorkInfos]  
as  
Select k.Description,
A.WorkInfoID as Id,a.UserID, A.KeyValue,A.KeyWord, A.RecordStatus as RecordStatus, A.WorkFlowID,A.Version,a.DocumentCode,A.Title,A.UserName,a.DeptPositionName, 
A.CreateDate as wfDate,A.HtmlPath,a.EpsProjectId, A.EpsProjectCode as EpsProjCode,A.EpsProjectName as EpsProjName,'workflow' as  WorkType  
From  pw_Infos A left join pp_KeyWord k on A.KeyWord=k.KeyWord Where    (TransFlag !=1 or TransFlag is null) and  recordstatus!=40  
union all  
Select k.Description,
b.WorkInfoID as Id,b.UserID,b.KeyValue,b.KeyWord,B.RecordStatus as RecordStatus,b.WorkFlowID,b.Version,b.DocumentCode,b.Title,b.UserName,b.DeptPositionID, 
b.CreateDate as wfDate,b.HtmlPath,b.EpsProjectId, b.EpsProjectCode as EpsProjCode,b.EpsProjectName as EpsProjName,'workflows' as  WorkType  
From  pwf_Infos B left join pp_KeyWord k on B.KeyWord=k.KeyWord where  recordstatus!=40
--2
alter view [dbo].[View_WorkPastUsers]  
as  
Select k.Description,A.WorkInfoID as Id,a.UserID, A.KeyValue,A.KeyWord,A.DocumentCode, A.Title,a.CreateUserName,A.UserName,a.CreateDeptPositionName, 
       a.BeforeUserName, A.lastUPdateTime as wfDate,A.HtmlPath,A.EpsProjCode as EpsProjCode,A.EpsProjName as EpsProjName,I.RecordStatus as RecordStatus
From  pw_PastUsers A left join pp_KeyWord k on A.KeyWord=k.KeyWord 
      join pw_Infos I on A.keyword = I.keyword and A.keyvalue = I.keyvalue
Where   (0=0)   and (A.TransFlag !=1 or A.TransFlag is null)  
union  
Select k.Description,A.WorkInfoID as Id,a.UserID, A.KeyValue,A.KeyWord,A.DocumentCode, A.Title,a.CreateUserName,A.UserName,a.CreateDeptPositionName,
       a.BeforeUserName,A.lastUPdateTime as wfDate,A.HtmlPath,A.EpsProjCode as EpsProjCode,A.EpsProjName as EpsProjName,I.RecordStatus as RecordStatus
From  pwf_PastUsers A left join pp_KeyWord k on A.KeyWord=k.KeyWord 
	  left join pwf_Infos I on A.keyword = I.keyword and A.keyvalue = I.keyvalue
Where   (0=0)  
; 








--这是旧的备份
--1
/****** Object:  View [dbo].[View_WorkInfos]    Script Date: 2019-02-12 15:21:59 ******/


create view [dbo].[View_WorkInfos]
as
	Select A.WorkInfoID as Id,a.UserID, A.KeyValue,A.KeyWord,A.RecordStatus, A.WorkFlowID,A.Version,a.DocumentCode,A.Title,A.UserName,a.DeptPositionName, A.CreateDate as wfDate,A.HtmlPath,a.EpsProjectId, A.EpsProjectCode as EpsProjCode,A.EpsProjectName as Ep
sProjName,'workflow' as  WorkType
 From  pw_Infos A Where    (TransFlag !=1 or TransFlag is null)
 union all
Select b.WorkInfoID as Id,b.UserID,b.KeyValue,b.KeyWord,B.RecordStatus,b.WorkFlowID,b.Version,b.DocumentCode,b.Title,b.UserName,b.DeptPositionID, b.CreateDate as wfDate,b.HtmlPath,b.EpsProjectId, b.EpsProjectCode as EpsProjCode,b.EpsProjectName as EpsProj
Name,'workflows' as  WorkType
 From  pwf_Infos B
 ;


--2
/****** Object:  View [dbo].[View_WorkPastUsers]    Script Date: 2019-02-12 15:21:59 ******/


 create view [dbo].[View_WorkPastUsers]
as
	 Select A.WorkInfoID as Id,a.UserID, A.KeyValue,A.KeyWord,A.DocumentCode, A.Title,a.CreateUserName,A.UserName,a.CreateDeptPositionName, a.BeforeUserName, A.lastUPdateTime as wfDate,A.HtmlPath,A.EpsProjCode as EpsProjCode,A.EpsProjName as EpsProjName
 From  pw_PastUsers A Where   (0=0)   and (TransFlag !=1 or TransFlag is null)
 union
Select A.WorkInfoID as Id,a.UserID, A.KeyValue,A.KeyWord,A.DocumentCode, A.Title,a.CreateUserName,A.UserName,a.CreateDeptPositionName,a.BeforeUserName,A.lastUPdateTime as wfDate,A.HtmlPath,A.EpsProjCode as EpsProjCode,A.EpsProjName as EpsProjName
 From  pwf_PastUsers A Where   (0=0)
 ;
 
