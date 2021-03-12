declare @strsql varchar(500), @cr cursor, 
        @tbname varchar(30), @fdname varchar(30), @fdtype varchar(30), @fddefault varchar(30), @fdtitle varchar(50)

set @tbname='PS_ToMapAndUse'  --请在这里输入表名称

create table #fdinfo
(
   fdname varchar(30),
   fdtype varchar(50),
   fddefault varchar(50),
   fdtitle varchar(50)
)
insert into #fdinfo(fdname, fdtype, fddefault, fdtitle)
  select 'BizAreaId','uniqueidentifier',null,'业务域'
  union all select 'Sequ','int','0','序号'
  union all select 'Status','tinyint','0','状态'		
  union all select 'RegHumId','uniqueidentifier',null,'录入人Id'	  union all select 'RegHumName','nvarchar(80)',null,'录入人'     union all select 'RegDate','datetime',null,'录入日期' 
  union all select 'RegPosiId','uniqueidentifier',null,'录入人主岗位' union all select 'RegDeptId','uniqueidentifier',null,'录入人主部门'
  union all select 'EpsProjId','uniqueidentifier',null,'项目Id' union all select 'EpsProjName','nvarchar(255)',null,'项目名称'
  union all select 'RecycleHumId','uniqueidentifier',null,'删除人Id'
  union all select 'UpdHumId','uniqueidentifier',null,'最后修改人Id'  union all select 'UpdHumName','nvarchar(80)',null,'最后修改人' union all select 'UpdDate','datetime',null,'最后修改日期'
  union all select 'ApprHumId','uniqueidentifier',null,'批准人id'     union all select 'ApprHumName','nvarchar(80)',null,'批准人'    union all select 'ApprDate','datetime',null,'批准日期'
  union all select 'Memo','nvarchar(1999)',null,'备注'
  union all select 'OwnProjId','uniqueidentifier',null,'项目Id'             

set @cr = cursor for
   select fdname,fdtype, fddefault, fdtitle from #fdinfo
open @cr
fetch next from @cr into @fdname, @fdtype, @fddefault, @fdtitle
while @@FETCH_STATUS=0
begin
  set @strsql = 'alter table '+ @tbname+' add '+@fdname+' '+@fdtype
  if (@fddefault is not null or len(@fddefault)>0)
    set @strsql = @strsql + ' default('+@fddefault+')'
  --执行添加字段
  exec(@strsql)
  if (len(@fdtitle)>0)
  begin
    set @strsql = 'EXEC sys.sp_addextendedproperty @name=N''MS_Description'', @value=N'''+@fdtitle+''', @level0type=N''SCHEMA'','
         +'@level0name=N''dbo'', @level1type=N''TABLE'',@level1name=N'''+@tbname+''', @level2type=N''COLUMN'',@level2name=N'''+@fdname+''''
	--执行添加字段说明
    exec(@strsql)
  end
  set @strsql = 'update x1 set x1.'+@fdname+'=x2.'+@fdname+' from '+@tbname+' x1 join PB_DefaultField x2 on x1.Id=x2.DefaultFieldId'
  ---输出PB_DefaultField数据迁移sql
  print @strsql
  ---输出删除 PB_DefaultField sql
  set @strsql = '-- delete x2 from '+@tbname+' x1 join PB_DefaultField x2 on x1.Id=x2.DefaultFieldId'
  print @strsql
  fetch next from @cr into @fdname, @fdtype, @fddefault, @fdtitle
end
close @cr
deallocate @cr

drop table #fdinfo
go