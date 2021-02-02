--1000次内，看循环多少次@num为100，@num在1到100之间
declare @i int--计时器
declare @num varchar(3000)--行数
declare @tableLength int --长度
set @tableLength = 1000
set @i = 1
while @i<=@tableLength
begin
--floor为0到100-1之间
--ceiling为1到100之间
--select @num='第'+convert(varchar(3000),@i) +'次：'+ convert(varchar(3000),cast(ceiling(rand()*100) as int))
select @num= convert(varchar(3000),cast(ceiling(rand()*100) as int))
print '第'+convert(varchar(3000),@i)+'次:'
print @num
if(@num = '100')
break;
set @i+=1
end

--循环次数无限制，循环多少次后@num=表的长度
declare @i int--计时器
declare @num varchar(3000)--行数
declare @tableLength int --长度
select @tableLength=count(*) from PB_Messages
--print @tableLength
set @i = 1
while 1<2
begin
--floor为0到100-1之间
--ceiling为1到100之间
--select @num='第'+convert(varchar(3000),@i) +'次：'+ convert(varchar(3000),cast(ceiling(rand()*100) as int))
select @num= convert(varchar(3000),cast(ceiling(rand()* @tableLength ) as int))
print '第'+convert(varchar(3000),@i)+'次:'
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

