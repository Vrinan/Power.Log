declare 
--物资分类码Id
@MatBsCode nvarchar(50),
--物资分类名称
@MatBsName nvarchar(50)
--创建游标
declare @cursor cursor
set @cursor=cursor for
select MatBS_Code from XLX_PUR_Request_List
--打开游标
open @cursor
--移动游标指向到第一条数据，提取第一条数据存放在变量中
fetch next from @cursor into @MatBsCode
--如果上一次操作成功则继续循环
	while(@@fetch_status=0)
	begin
--操作提出的数据
		select @MatBsName=MatBsName from PS_MDM_MatBS where LongCode = @MatBsCode
		update XLX_PUR_Request_List set MatBS_Name=@MatBsName where MatBS_Code = @MatBsCode
		print 'Code：'+ @MatBsCode
		print 'Name：'+ @MatBsName
		fetch next from @cursor into @MatBsCode
	end
--关闭游标
close @cursor
--删除游标
deallocate @cursor


--select * from XLX_MDM_MAT_Middle
--declare @MatBsCode nvarchar(50),@MatBsName nvarchar(50)
--select LongCode=@MatBsCode,MatBsName=@MatBsName from PS_MDM_MatBS where Id = @MatBsGuid
--select MatBS_Code from XLX_PUR_Request_List
--select MatBsName,MatBSCode,LongCode from PS_MDM_MatBS where LongCode = '1.52.01.05.01'
--select * from XLX_PUR_Request_List
