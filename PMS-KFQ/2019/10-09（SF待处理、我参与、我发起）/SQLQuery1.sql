--待审批
select
x4.RecordStatus,Description,x1.Id,x4.DocumentCode,x1.Title,x1.IsPowerMessage,x1.LinkUrl, x1.FromDate as wfDate,x1.FromHumanName,x1.KeyWord,x1.KeyValue,x1.ContentText as HtmlPath,x1.MessageType,x1.EpsProjCode as EpsProjCode,x1.EpsProjName as EpsProjName,x4.UserName as UserName,x3.WeChat
from
PB_Messages x1 left join PB_Human x3 on x1.ToHumanId=x3.Id left join View_WorkInfos x4 on x1.KeyValue=x4.KeyValue and x1.KeyWord=x4.KeyWord

select DocumentCode,* from View_WorkInfos

--我发起的
select
RecordStatus,Description,Id,KeyValue,KeyWord,WorkFlowID,Version,DocumentCode,Title,UserName, wfDate,HtmlPath, EpsProjCode, EpsProjName
from
View_WorkInfos

--我参与的
select
RecordStatus,Description,Id,KeyValue,KeyWord,DocumentCode, Title, wfDate,HtmlPath, EpsProjCode, EpsProjName,CreateUserName as UserName,CreateDeptPositionName, BeforeUserName as FromHumanName
from
View_WorkPastUsers

