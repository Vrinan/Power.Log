--alter table PB_HumanRelation add IsDeptLeader nvarchar(100) null

select * from PB_Widget where id='126f543f-09d5-49a4-96a8-9951a35dc6dc'
--/PowerPlat/FormXml/zh-CN/StdSystem/DeptHumPageList.htm

select * from PB_Department where name='×ÛºÏ²¿'


create view View_SF_DeptLeaders
as
select a.IsDeptLeader,a.RelationId,b.* from PB_HumanRelation a
left join 
PB_Human b on a.HumanId = b.Id
where a.RelationType=2 and a.IsDeptLeader='1'

select * from View_SF_DeptLeaders

select * from PB_User where HumanId='FF528BB6-B2D8-4D47-8952-C69E987ADCB0'




select * from SF_ZH_DeptContact

update SF_ZH_DeptContact set IsAlreadyReply=0