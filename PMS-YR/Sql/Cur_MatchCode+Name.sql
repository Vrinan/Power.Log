declare 
--���ʷ�����
@MatBsCode nvarchar(50),
--���ʷ�����Id
@MatBsGuid nvarchar(50),
--���ʷ�������
@MatBsName nvarchar(50)
--�����α�
declare @cursor cursor
set @cursor=cursor for
select MatBs_Guid from XLX_MDM_MAT_Middle
--���α�
open @cursor
--�ƶ��α�ָ�򵽵�һ�����ݣ���ȡ��һ�����ݴ���ڱ�����
fetch next from @cursor into @MatBsGuid
--�����һ�β����ɹ������ѭ��
	while(@@fetch_status=0)
	begin
--�������������
		select @MatBsCode=LongCode,@MatBsName=MatBsName from PS_MDM_MatBS where Id = @MatBsGuid
		update XLX_MDM_MAT_Middle set MatBs_Code=@MatBsCode,MatBs_Name=@MatBsName where MatBs_Guid = @MatBsGuid
		print 'Guid��'+ @MatBsGuid
		print 'Name��'+ @MatBsName
		print 'Code��'+ @MatBsCode
		fetch next from @cursor into @MatBsGuid
	end
--�ر��α�
close @cursor
--ɾ���α�
deallocate @cursor


--select * from XLX_MDM_MAT_Middle
--declare @MatBsCode nvarchar(50),@MatBsName nvarchar(50)
--select LongCode=@MatBsCode,MatBsName=@MatBsName from PS_MDM_MatBS where Id = @MatBsGuid
