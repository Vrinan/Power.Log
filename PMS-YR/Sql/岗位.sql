
--delete from PB_Position where id not in(select id from PB_Position where code like 'YR%')
select * from PB_Position

select * from PB_DefaultField where TableName='PB_Position' and DefaultFieldId in (select Id from PB_Position where code like 'YR%')

select * from PB_DefaultField where TableName ='PB_Position'

--delete from PB_DefaultField1 where DefaultFieldId not in (select DefaultFieldId from PB_DefaultField1 where DefaultFieldId in (select id from PB_Position))
--!!!
select * from PB_DefaultField where TableName='PB_Position' and OwnProjId ='345ED76D-18FA-42A4-B666-4842A12310A0' and OwnProjName='�������ٿƼ����޹�˾'

--update PB_DefaultField set EpsProjId='00000000-0000-0000-0000-0000000000A4',OwnProjId='00000000-0000-0000-0000-0000000000A4',OwnProjName='���ٿعɼ���' where TableName='PB_Position' and OwnProjId ='345ED76D-18FA-42A4-B666-4842A12310A0' and OwnProjName='�������ٿƼ����޹�˾'


select EpsProjId,OwnProjId,OwnProjName from PB_DefaultField where TableName <> 'PB_Position'
select EpsProjId,* from PLN_project