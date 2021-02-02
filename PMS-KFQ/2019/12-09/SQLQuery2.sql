select * from View_KFQ_SG_HumanChange
--ViewKFQSGHumanChange


select * from KFQ_NotificationNotice

--EventsText


select * from PB_User where name='钟运飞'
select * from PB_User where name='唐思'
select * from pb_user where name='任昕玥'
select * from pb_user where name='会务'
select * from pb_user where name='会议室管理员'


select * from KFQ_ZH_MeetingManage

update KFQ_ZH_MeetingManage set reghumid='19030DBA-D6EC-4E06-B559-EEECBD4923CA'

select * from PB_Messages where tohumanname='王国栋'
and MessageType='notify' and KeyWord='ZyxTest' order by FromDate desc
--IsSend = 1是已查看
--IsSend = 0是未查看
delete from PB_Messages where tohumanname='王国栋'


create view KFQ_IsHWSend
as
select * from PB_Messages where tohumanname='会务'
and MessageType='notify' and KeyWord='KFQ_ZH_MeetingManage' order by FromDate desc


select * from PB_Widget where id='971638f7-fa5c-47a3-91ef-7bc47c449968'
--/PowerPlat/FormXml/zh-CN/KFQ_APP/Win_WorkFlowsModel.htm
--收文流程跟踪


select * from KFQ_MeetingRoomCompared


select b.UserName,b.UserID from pwf_infos a right join pwf_pastNodes b on a.WorkInfoID=b.WorkInfoID 
left join PB_HumanSign s on b.UserID = s.HumanId left join pwf_Opinion c on a.WorkInfoID=c.WorkInfoID 
and b.SequeID=c.SequeID left join (select dept.Name as DeptName,posi.Id as PosiId,posi.Name as PosiName from PB_Position posi 
left join PB_Department dept on posi.DeptId=dept.Id) d on 
case when b.DeptPositionID ='' then '00000000-0000-0000-0000-000000000000' when b.DeptPositionID is null 
then '00000000-0000-0000-0000-000000000000' else b.DeptPositionID end =d.PosiId 
where KeyValue='fa0ef7ba-33b5-4649-a45b-bb463f2c54cf'  and b.SendDate is null order by b.SequeID Desc


select * from PB_Messages where ToHumanName='王国栋' order by FromDate
delete from PB_Messages where IsTextMessage=1