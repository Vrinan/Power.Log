--sp_helptext View_KFQ_FilesWorkFlow

select * from pb_user where name='王国栋'
select * from pb_user where name='文秘'

select WorkFlowID,* from pwf_Infos
--超期的
select * from View_KFQ_FilesWorkFlow where RecordStatus=20 and delayDays>=7
select KeyWord,KeyValue,Title,RegHumName,RegHumId,UserName,UserId,NodeCode,Memo from View_KFQ_FilesWorkFlow where RecordStatus=20 and delayDays>=7
and Memo not in(select Memo from PB_MessagesHistorys)


select * from PB_Messages where IsTextMessage=1
select * from PB_Messages where IsTextMessage =2 order by UpdDate Desc
select * from PB_MessagesHistorys
--delete from PB_Messages where IsTextMessage=1
--delete from PB_MessagesHistorys

select count(*) as ct from PB_DocFiles where FolderId='74d476b5-942e-4996-aa8a-f312a2ed1eee'
