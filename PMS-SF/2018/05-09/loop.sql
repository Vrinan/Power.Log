--1000���ڣ���ѭ�����ٴ�@numΪ100��@num��1��100֮��
declare @i int--��ʱ��
declare @num varchar(3000)--����
declare @tableLength int --����
set @tableLength = 1000
set @i = 1
while @i<=@tableLength
begin
--floorΪ0��100-1֮��
--ceilingΪ1��100֮��
--select @num='��'+convert(varchar(3000),@i) +'�Σ�'+ convert(varchar(3000),cast(ceiling(rand()*100) as int))
select @num= convert(varchar(3000),cast(ceiling(rand()*100) as int))
print '��'+convert(varchar(3000),@i)+'��:'
print @num
if(@num = '100')
break;
set @i+=1
end

--ѭ�����������ƣ�ѭ�����ٴκ�@num=��ĳ���
declare @i int--��ʱ��
declare @num varchar(3000)--����
declare @tableLength int --����
select @tableLength=count(*) from PB_Messages
--print @tableLength
set @i = 1
while 1<2
begin
--floorΪ0��100-1֮��
--ceilingΪ1��100֮��
--select @num='��'+convert(varchar(3000),@i) +'�Σ�'+ convert(varchar(3000),cast(ceiling(rand()*100) as int))
select @num= convert(varchar(3000),cast(ceiling(rand()* @tableLength ) as int))
print '��'+convert(varchar(3000),@i)+'��:'
print @num
if(@num = convert(varchar(3000),@tableLength))
break;
set @i+=1
end

--select ROUND(15.258, 2)

--DECLARE @Result INT
--DECLARE @Upper INT
--DECLARE @Lower INT
--SET @Lower = 1
--SET @Upper = 10
--SELECT @Result = ROUND(((@Upper - @Lower -1) * RAND() + @Lower), 0)
--SELECT @Result

select * from(
select *,number = row_number() over(order by Id desc) from PB_Messages) 
m where number = 2

