select * from View_WorkPastUsers where UserID='460e2345-c510-4414-aa4c-0471ec9b00c8' and 1=1


sp_helptext View_WorkPastUsers

Select A.WorkInfoID as Id,a.UserID, A.KeyValue,A.KeyWord,A.DocumentCode, A.Title,a.CreateUserName,A.UserName,a.CreateDeptPositionName, a.BeforeUserName, A.lastUPdateTime as wfDate,A.HtmlPath,A.EpsProjCode as EpsProjCode,A.EpsProjName as EpsProjName
 From  pw_PastUsers A Where   (0=0)   and (TransFlag !=1 or TransFlag is null)
 union

Select A.WorkInfoID as Id,a.UserID, A.KeyValue,A.KeyWord,A.DocumentCode, A.Title,a.CreateUserName,A.UserName,a.CreateDeptPositionName,
a.BeforeUserName,A.lastUPdateTime as wfDate,A.HtmlPath,A.EpsProjCode as EpsProjCode,A.EpsProjName as EpsProjName
From pwf_PastUsers A where UserID='460e2345-c510-4414-aa4c-0471ec9b00c8';


select * from pwf_PastUsers a where a.workinfoid='040BE6FD-C389-FF9C-A477-7417EE037E95'

update pwf_PastUsers set Title='永川区城市生活垃圾处理厂渗滤液及膜下水处理工程PPP项目方案二投标文件校审' where workinfoid='040BE6FD-C389-FF9C-A477-7417EE037E95'

select * from PB_User where code='2306'