select * from PB_Organize where Name in(
select Name from PB_Organize group by Name having COUNT(Name)>1) order by Name


select * from PB_Organize where Name='ROCHEM GmbH'


select * from PS_MK_ProjectInfo where Client_Guid ='f2f0e5ec-1a8c-4573-95d3-661881aebbbe'

--update PS_MK_ProjectInfo set Client_Guid ='7a94d4fe-65f0-47bd-80df-7feb25015922' where Client_Guid ='f2f0e5ec-1a8c-4573-95d3-661881aebbbe'

select * from PS_MK_ProjectInfo where Client_Guid ='38b3aa82-e434-4259-9064-17561b244fe8'