select * from PB_Widget where id='126f543f-09d5-49a4-96a8-9951a35dc6dc'
--/PowerPlat/FormXml/zh-CN/StdSystem/DeptHumPageList.htm



select * from SF_HumanCheckOnWork

update SF_HumanCheckOnWork set daytime='2018-04-26 00:00:00.000'  where id='5524960A-E447-3C07-FA61-2F6674612E66'

select * from PB_Department where id='909580a9-4f23-46a9-a689-63eed58dd2fc'

select * from PB_User

select * from v_UserHuman where id='909580a9-4f23-46a9-a689-63eed58dd2fc'


sp_helptext v_UserHuman

create view v_DeptUser
as
Select A.*,B.*,c.Code HumanCode,d.Id DeptId,d.code DeptCode,c.DeptName From  PB_User A 
join PB_DefaultField B on A.Id=B.DefaultFieldId 
left join PB_Human C on a.HumanId=c.Id
left join PB_Department D on c.DeptId=D.Id
Where  A.ITAdminFlag='N' 

select * from v_DeptUser where DeptId='909580a9-4f23-46a9-a689-63eed58dd2fc'
select * from PB_User

select * from PB_HumanRelation where RelationId='909580a9-4f23-46a9-a689-63eed58dd2fc'







create view v_DeptUser
as
select a.HumanId,a.Code,a.Name,b.RelationId as DeptId from PB_User a left join PB_HumanRelation b on a.HumanId = b.HumanId

select * from v_DeptUser where DeptId='5da7d6f0-be51-4b66-bf1a-9ed77c538a3e'

select * from SF_HumanCheckOnWork
delete from SF_HumanCheckOnWork where humanid <> '00000000-0000-0000-0000-000000000000'


select * from PB_Widget where id='126f543f-09d5-49a4-96a8-9951a35dc6dc'
select * from PB_HumanRelation where RelationId='5da7d6f0-be51-4b66-bf1a-9ed77c538a3e'
sp_helptext v_DeptUser
alter view v_DeptUser
as
select a.ID HumanId,a.Code,a.Name,b.RelationId as DeptId from PB_Human a left join PB_HumanRelation b on a.Id = b.HumanId
select * from PB_Human
select * from PB_HumanRelation where HumanId='6DD4CC0D-AA59-4805-B596-00259E8B7F82'