Select A.* From  PS_COM_FileContact A Where   (0=0)  and a.Id='64c0a378-96b4-4c78-be61-bb32a81c8201' 
and (A.RegHumId= '01d0fbd5-ad65-4cc3-92b0-fc62fd9036e8' 
		or A.Id in (select rx1.KeyValue from View_WorkPastUsers rx1 where rx1.KeyWord='PS_FileContact' and rx1.UserID='01d0fbd5-ad65-4cc3-92b0-fc62fd9036e8') 
		or A.RegHumId= '01d0fbd5-ad65-4cc3-92b0-fc62fd9036e8') 
		and (A.RegHumId in (select ss.KeyValue from PB_Messages ss where ss.ToHumanId='01d0fbd5-ad65-4cc3-92b0-fc62fd9036e8' and ss.Title like'%转发%'))  
and (A.EpsProjId='00000000-0000-0000-0000-0000000000a4') 


select * from PB_User a left join PB_Human b on a.humanid =b.id
 where password is null and b.deptid in(select Id from dbo.returnDeptIds('C977DCE4-8EDB-4BDE-A3B1-9BCBA9BA36F6'))


 select * from pb_department
 select * from PB_Human


 select * from PB_Widget where id='baed5ac2-1698-40d0-827c-cd9e68048cef'
 --/PowerPlat/FormXML/zh-CN/Systems/NotifyListMore.htm

 select * from PB_User where name='文秘'

 Select A.* From  PS_COM_FileContact A Where   (0=0)  
 and a.Id='64c0a378-96b4-4c78-be61-bb32a81c8201' 
 and (A.RegHumId= '01d0fbd5-ad65-4cc3-92b0-fc62fd9036e8' 
		or A.Id in (select rx1.KeyValue from View_WorkPastUsers rx1 where rx1.KeyWord='PS_FileContact' and rx1.UserID='01d0fbd5-ad65-4cc3-92b0-fc62fd9036e8'))  
		and (A.EpsProjId='00000000-0000-0000-0000-0000000000a4') 



--in ([@SQLHumanJoinWorkFlow]) or RegHumId = '[@HumanId]'  or Id  in (select ss.KeyValue from PB_Messages ss where ss.ToHumanId='[@HumanId]' and ss.Title like'%转发%')

  = '[@HumanId]' or Id  in (select ss.KeyValue from PB_Messages ss where ss.ToHumanId='[@HumanId]' and ss.Title like'%转发%') or  RegHumId in ([@SQLHumanJoinWorkFlow])



  Select A.* From  PS_COM_FileContact A Where 
    (0=0)  and a.Id='64c0a378-96b4-4c78-be61-bb32a81c8201' 
	and (A.RegHumId= '01d0fbd5-ad65-4cc3-92b0-fc62fd9036e8' 
	or A.Id in (select rx1.KeyValue from View_WorkPastUsers rx1 where rx1.KeyWord='PS_FileContact' and rx1.UserID='01d0fbd5-ad65-4cc3-92b0-fc62fd9036e8'))  and (A.EpsProjId='00000000-0000-0000-0000-0000000000a4') 


id in(
select sa.KeyValue from View_WorkPastUsers sa where  sa.KeyWord='PS_FileContact' and sa.UserID ='[@HumanId]')
or id in (select ss.KeyValue from PB_Messages ss where ss.ToHumanId='[@HumanId]' and ss.Title like '%转发%')




Select A.* From  PS_COM_FileContact A Where   (0=0)  and a.Id='64c0a378-96b4-4c78-be61-bb32a81c8201' 
and (A.Id in( select sa.KeyValue from View_WorkPastUsers sa where  sa.KeyWord='PS_FileContact' and sa.UserID ='01d0fbd5-ad65-4cc3-92b0-fc62fd9036e8') or A.Id in (select ss.KeyValue from PB_Messages ss where ss.ToHumanId='01d0fbd5-ad65-4cc3-92b0-fc62fd9036e8' and ss.Title like '%转发%'))  and A.EpsProjId='00000000-0000-0000-0000-0000000000a4'


Select A.* From  PS_COM_FileContact A Where   (0=0)  and a.Id='64c0a378-96b4-4c78-be61-bb32a81c8201' 
and (A.RegHumId= '01d0fbd5-ad65-4cc3-92b0-fc62fd9036e8') and 
(A.Id in( select sa.KeyValue from View_WorkPastUsers sa where  sa.KeyWord='PS_FileContact' and sa.UserID ='01d0fbd5-ad65-4cc3-92b0-fc62fd9036e8') or A.RegHumId ='01d0fbd5-ad65-4cc3-92b0-fc62fd9036e8' or A.Id in (select ss.KeyValue from PB_Messages ss where ss.ToHumanId='01d0fbd5-ad65-4cc3-92b0-fc62fd9036e8' and ss.Title like '%转发%'))  and (A.EpsProjId='00000000-0000-0000-0000-0000000000a4') 