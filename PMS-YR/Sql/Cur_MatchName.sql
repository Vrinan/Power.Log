declare 
--���ʷ�����Id
@MatBsCode nvarchar(50),
--���ʷ�������
@MatBsName nvarchar(50)
--�����α�
declare @cursor cursor
set @cursor=cursor for
select MatBS_Code from XLX_PUR_Request_List
--���α�
open @cursor
--�ƶ��α�ָ�򵽵�һ�����ݣ���ȡ��һ�����ݴ���ڱ�����
fetch next from @cursor into @MatBsCode
--�����һ�β����ɹ������ѭ��
	while(@@fetch_status=0)
	begin
--�������������
		select @MatBsName=MatBsName from PS_MDM_MatBS where LongCode = @MatBsCode
		update XLX_PUR_Request_List set MatBS_Name=@MatBsName where MatBS_Code = @MatBsCode
		print 'Code��'+ @MatBsCode
		print 'Name��'+ @MatBsName
		fetch next from @cursor into @MatBsCode
	end
--�ر��α�
close @cursor
--ɾ���α�
deallocate @cursor


--select * from XLX_MDM_MAT_Middle
--declare @MatBsCode nvarchar(50),@MatBsName nvarchar(50)
--select LongCode=@MatBsCode,MatBsName=@MatBsName from PS_MDM_MatBS where Id = @MatBsGuid
--select MatBS_Code from XLX_PUR_Request_List
--select MatBsName,MatBSCode,LongCode from PS_MDM_MatBS where LongCode = '1.52.01.05.01'
--select * from XLX_PUR_Request_List
