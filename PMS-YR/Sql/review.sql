--º¯Êý
declare @a nvarchar(100)
set @a = '111222333aaabbbccc'
select len(@a)
select substring(@a,CHARINDEX('aaa',@a), 3)
select CHARINDEX('aaa',@a)
select STUFF('abcdefg',2,3,'')
select STUFF('abcdefg',2,0,'123')
select STUFF('abcdefg',2,3,'123')

--Óï·¨
select id,sum(CONVERT(float,value)) from a group by id
select id from a group by id having count(id)>1
select * from a
select id, value = (stuff(
(select ',' + value from a where id =   
a.id for xml path('')),1,1,'')) from a a group by id 

select stuff((select ',' + value from a where id = a.id for xml path('')),1,1,'')

insert into alroy(id,strValue,floatValue) select id,value,statue from a
insert into alroy select id,value,233 from a

select ',' + strValue from alroy where id = a.id for xml path('')

