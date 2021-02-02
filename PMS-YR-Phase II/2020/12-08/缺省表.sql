declare @strsql varchar(500), @cr cursor, 
        @tbname varchar(30), @fdname varchar(30), @fdtype varchar(30), @fddefault varchar(30), @fdtitle varchar(50)

set @tbname='PS_ToMapAndUse'  --�����������������

create table #fdinfo
(
   fdname varchar(30),
   fdtype varchar(50),
   fddefault varchar(50),
   fdtitle varchar(50)
)
insert into #fdinfo(fdname, fdtype, fddefault, fdtitle)
  select 'BizAreaId','uniqueidentifier',null,'ҵ����'
  union all select 'Sequ','int','0','���'
  union all select 'Status','tinyint','0','״̬'		
  union all select 'RegHumId','uniqueidentifier',null,'¼����Id'	  union all select 'RegHumName','nvarchar(80)',null,'¼����'     union all select 'RegDate','datetime',null,'¼������' 
  union all select 'RegPosiId','uniqueidentifier',null,'¼��������λ' union all select 'RegDeptId','uniqueidentifier',null,'¼����������'
  union all select 'EpsProjId','uniqueidentifier',null,'��ĿId' union all select 'EpsProjName','nvarchar(255)',null,'��Ŀ����'
  union all select 'RecycleHumId','uniqueidentifier',null,'ɾ����Id'
  union all select 'UpdHumId','uniqueidentifier',null,'����޸���Id'  union all select 'UpdHumName','nvarchar(80)',null,'����޸���' union all select 'UpdDate','datetime',null,'����޸�����'
  union all select 'ApprHumId','uniqueidentifier',null,'��׼��id'     union all select 'ApprHumName','nvarchar(80)',null,'��׼��'    union all select 'ApprDate','datetime',null,'��׼����'
  union all select 'Memo','nvarchar(1999)',null,'��ע'
  union all select 'OwnProjId','uniqueidentifier',null,'��ĿId'             

set @cr = cursor for
   select fdname,fdtype, fddefault, fdtitle from #fdinfo
open @cr
fetch next from @cr into @fdname, @fdtype, @fddefault, @fdtitle
while @@FETCH_STATUS=0
begin
  set @strsql = 'alter table '+ @tbname+' add '+@fdname+' '+@fdtype
  if (@fddefault is not null or len(@fddefault)>0)
    set @strsql = @strsql + ' default('+@fddefault+')'
  --ִ������ֶ�
  exec(@strsql)
  if (len(@fdtitle)>0)
  begin
    set @strsql = 'EXEC sys.sp_addextendedproperty @name=N''MS_Description'', @value=N'''+@fdtitle+''', @level0type=N''SCHEMA'','
         +'@level0name=N''dbo'', @level1type=N''TABLE'',@level1name=N'''+@tbname+''', @level2type=N''COLUMN'',@level2name=N'''+@fdname+''''
	--ִ������ֶ�˵��
    exec(@strsql)
  end
  set @strsql = 'update x1 set x1.'+@fdname+'=x2.'+@fdname+' from '+@tbname+' x1 join PB_DefaultField x2 on x1.Id=x2.DefaultFieldId'
  ---���PB_DefaultField����Ǩ��sql
  print @strsql
  ---���ɾ�� PB_DefaultField sql
  set @strsql = '-- delete x2 from '+@tbname+' x1 join PB_DefaultField x2 on x1.Id=x2.DefaultFieldId'
  print @strsql
  fetch next from @cr into @fdname, @fdtype, @fddefault, @fdtitle
end
close @cr
deallocate @cr

drop table #fdinfo
go