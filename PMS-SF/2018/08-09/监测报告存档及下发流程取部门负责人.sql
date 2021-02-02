select * from PB_Widget where id='5ca9f76b-1cae-4821-bb07-532bb9ef4ef0'
--/PowerPlat/FormXml/zh-CN/SF_ZH/SF_ZH_OvertimeBatch.htm

select a.Id,a.Name,a.PosiId,a.PosiName,b.IsDeptLeader from PB_Human a left join PB_HumanRelation b on a.Id = b.HumanId where b.IsDeptLeader='1'  and  b.RelationId in
( 
select Id from PB_Department where Id in ( select DeleDeptId from SF_HSE_MonitorIssued where Id = '18d97077-0181-4b6a-8bcb-364b9855e6c7' 
union
 select ParentId as DeleDeptId from PB_Department where Id=(select DeleDeptId from SF_HSE_MonitorIssued where Id = '18d97077-0181-4b6a-8bcb-364b9855e6c7')) 
 or ParentId in( select DeleDeptId from SF_HSE_MonitorIssued where Id = '18d97077-0181-4b6a-8bcb-364b9855e6c7' 
 union
  select ParentId as DeleDeptId from PB_Department where Id=(select DeleDeptId from SF_HSE_MonitorIssued where Id = '18d97077-0181-4b6a-8bcb-364b9855e6c7') ) 
)


select DelegateRegHuman,DelegateRegHumanId from SF_HSE_MonitorIssued