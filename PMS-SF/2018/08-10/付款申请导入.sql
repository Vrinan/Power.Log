declare @cursor cursor
declare @sqje numeric(18,4)--������
declare @sbf numeric(18,4)--�豸��
declare @cid uniqueidentifier --��ͬId
declare @code nvarchar(500)
declare @name nvarchar(500)
declare @PartyB_Guid nvarchar(50)--��Ӧ��id
declare @PartyB_Name nvarchar(500)--��Ӧ������
declare @guid nvarchar(50)
--�趨�α������������ݼ�
set @cursor=cursor for
select ��ͬ���,��ͬ����,��Ӧ������,������,�豸�� from ��������$ order by ��ͬ���
--���α�
open @cursor
--�ƶ��α�ָ�򵽵�һ�����ݣ���ȡ��һ�����ݴ���ڱ�����
fetch next from @cursor into @code,@name,@PartyB_Name,@sqje,@sbf
--�����һ�β����ɹ������ѭ��
while(@@fetch_status=0)begin
 	--�½�guid
 	 set @guid = newid()
	 --��ѯ��ͬId
	 select @cid=Id from PS_CM_SubContract a where a.SubContractCode=@code
 	--��ѯ�ҷ���λid
 	select top 1 @PartyB_Guid = id from dbo.PB_Organize where name = @PartyB_Name

	insert into PS_CM_SubContractApplyMny(id,Status,SubContractType,SubContract_Guid,Code,Title,ApplyAmount,ApprAmount,
	TotalApplyAmount,TotalApprAmount,FromDate,ToDate,UpdDate,RegDate,RegHumName,RegHumId,OwnProjName,OwnProjId,EpsProjId,PayType,FinalApplyAmount)
	select @guid, 0,'P',@cid,��ͬ���,��ͬ����,@sqje,@sqje,
	@sqje,@sqje,getdate(),getdate(),getdate(),getdate(),'ϵͳ����Ա','AD000000-0000-0000-0000-000000000000','����Ƽ�','00000000-0000-0000-0000-0000000000A4','00000000-0000-0000-0000-0000000000A4','P2',@sqje
	from ��������$ where ��ͬ��� = @code
	
	--��ӽ����ϸ
	insert into SF_Contract_AmountList(id,masterid,amounttype,totalamount)
    values(NewID(),@guid,'03',@sbf)
	
    --��������һ��
    fetch next from @cursor into @code,@name,@PartyB_Name,@sqje,@sbf
end
--�ر��α�
close @cursor
--ɾ���α�
deallocate @cursor
