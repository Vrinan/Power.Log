create function IsExistData
(
	@deptid nvarchar(100),
	@date nvarchar(100)
)	
returns nvarchar(100)
as
begin
declare @count nvarchar(100)
select @count=count(*) from SF_HumanCheckOnWork where MasterId=convert(uniqueidentifier,@deptid) and DayTime=@date
return @count
end

select dbo.IsExistData('31440F0E-7E09-4EE9-A99D-88A72B7040D7','2018-08-07 00:00:00.000') 