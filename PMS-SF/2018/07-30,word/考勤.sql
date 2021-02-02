select * from SF_ZH_OverTime where Mouthtime='114'
select * from PB_Human where name in
(select distinct HumName from SF_ZH_OverTime where  HumId='00000000-0000-0000-0000-000000000000' or HumId is null )

update SF_ZH_OverTime set HumId = (select distinct Id from PB_Human a  where a.Code =SF_ZH_OverTime.HumCode) where SF_ZH_OverTime.HumId is null or SF_ZH_OverTime.HumId='00000000-0000-0000-0000-000000000000'


update SF_ZH_OverTime set Mouthtime = t1.total
from (
 select sum(OverTime) as total,humid,OverType from  SF_ZH_OverTime
 where year(regdate) = 2018 and month(regdate) = 6
 group by humid,OverType
)t1
where SF_ZH_OverTime.humid = t1.humid and SF_ZH_OverTime.OverType = t1.OverType 
and year(regdate) = 2018 and month(regdate) = 6

select request_session_id spid,OBJECT_NAME(resource_associated_entity_id) tableName from sys.dm_tran_locks where resource_type='OBJECT';