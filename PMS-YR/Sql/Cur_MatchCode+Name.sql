declare 
--物资分类码
@MatBsCode nvarchar(50),
--物资分类码Id
@MatBsGuid nvarchar(50),
--物资分类名称
@MatBsName nvarchar(50)
--创建游标
declare @cursor cursor
set @cursor=cursor for
select MatBs_Guid from XLX_MDM_MAT_Middle
--打开游标
open @cursor
--移动游标指向到第一条数据，提取第一条数据存放在变量中
fetch next from @cursor into @MatBsGuid
--如果上一次操作成功则继续循环
	while(@@fetch_status=0)
	begin
--操作提出的数据
		select @MatBsCode=LongCode,@MatBsName=MatBsName from PS_MDM_MatBS where Id = @MatBsGuid
		update XLX_MDM_MAT_Middle set MatBs_Code=@MatBsCode,MatBs_Name=@MatBsName where MatBs_Guid = @MatBsGuid
		print 'Guid：'+ @MatBsGuid
		print 'Name：'+ @MatBsName
		print 'Code：'+ @MatBsCode
		fetch next from @cursor into @MatBsGuid
	end
--关闭游标
close @cursor
--删除游标
deallocate @cursor


--select * from XLX_MDM_MAT_Middle
--declare @MatBsCode nvarchar(50),@MatBsName nvarchar(50)
--select LongCode=@MatBsCode,MatBsName=@MatBsName from PS_MDM_MatBS where Id = @MatBsGuid
