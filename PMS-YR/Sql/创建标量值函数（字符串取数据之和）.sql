create function fun_RetunrnSum(@str varchar(80))
RETURNS varchar(80)    
AS
BEGIN
declare @i int,@sum float
set @i =1
set @str = '{"9d588228-245f-1da2-a787-290faa3edb3c":2,"e8beb0b1-b7b9-0613-9800-4e9de87f91e1":2,"e8beb0b1-b7b9-0613-9800-4e9de87f91e1":2,"e8beb0b1-b7b9-0613-9800-4e9de87f91e1":2}'
--ɾ��{}
set @str = stuff(@str,1,1,'')
set @str = stuff(@str,len(@str),1,'')
set @sum = 0
--��ʼѭ��
while @str<>null or @str <>''

begin
set @str = stuff(@str,1,PATINDEX('%:%',@str),'')
if(PATINDEX('%[^0-9]%',@str))=0
set @sum = @sum +CONVERT(float,@str)
else
set @sum = @sum+CONVERT(float,stuff(@str,PATINDEX('%,%',@str),len(@str)-@i+1,''))
set @str = stuff(@str,1,@i,'')
end
 RETURN @sum     
END


declare @str nvarchar(500)
set @str='{"9d588228-245f-1da2-a787-290faa3edb3c":2,"e8beb0b1-b7b9-0613-9800-4e9de87f91e1":2,"e8beb0b1-b7b9-0613-9800-4e9de87f91e1":2,"e8beb0b1-b7b9-0613-9800-4e9de87f91e1":2}'
--select len(@str)
select dbo.fun_RetunrnSum(@str)
select dbo.fun_RetunrnPrice(@str)