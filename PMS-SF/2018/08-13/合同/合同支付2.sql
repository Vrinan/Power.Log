declare @cursor cursor
declare @fksq_id uniqueidentifier--��������
declare @fksq_Code nvarchar(500)
declare @fksq_name nvarchar(500)
declare @fksq_finalAmount numeric(18,4)

declare @invoice_id uniqueidentifier--��ƱId
declare @je numeric(18,4)--���
declare @cid uniqueidentifier --��ͬId
declare @code nvarchar(500)
declare @name nvarchar(500)
declare @guid nvarchar(50)
--�趨�α������������ݼ�
set @cursor=cursor for
select ��ͬԭʼ���,��ͬ����,��� from ��֧ͬ��$
--���α�
open @cursor
--�ƶ��α�ָ�򵽵�һ�����ݣ���ȡ��һ�����ݴ���ڱ�����
fetch next from @cursor into @code,@name,@je
--�����һ�β����ɹ������ѭ��
while(@@fetch_status=0)begin
 	--�½�guid
 	 set @guid = newid()
	 --��ѯ��ͬId
	 select @cid=Id from PS_CM_SubContract a where a.SubContractCode=@code
	 --��ѯ����������Ϣ
	 select @fksq_id = id,
	 @fksq_Code=code,
	 @fksq_name=Title,
	 @fksq_finalAmount=finalapplyamount from PS_CM_SubContractApplyMny where code=@code
	 --��ѯ��ƱId
	 select @invoice_id=id from PS_CM_SubContractInvoice where code=@code

	insert into PS_CM_SubContractPayment(id,Status,SubContractType,SubContract_Guid,SubContractInvoice_Guid,Code,Title,TotalPaymentAmount,PaymentWay,
	PaymentAmount,PaymentDate,SubContractApplyCode,SubContractApplyName,SubContractApplyId,SubContractApplyAmount,
	UpdDate,RegDate,RegHumName,RegHumId,OwnProjName,OwnProjId,EpsProjId)
	select @guid, 0,'P',@cid,@invoice_id,��ͬ���,��ͬ����,@je,'F2',
	@je,getdate(),@fksq_Code,@fksq_name,@fksq_id,@fksq_finalAmount,
	getdate(),getdate(),'ϵͳ����Ա','AD000000-0000-0000-0000-000000000000','����Ƽ�','00000000-0000-0000-0000-0000000000A4','00000000-0000-0000-0000-0000000000A4'
	from ��������$ where ��ͬ��� = @code
	
	--��ӽ����ϸ
	insert into SF_Contract_AmountList(id,masterid,amounttype,totalamount)
    values(NewID(),@guid,'03',@je)
	
    --��������һ��
    fetch next from @cursor into @code,@name,@je
end
--�ر��α�
close @cursor
--ɾ���α�
deallocate @cursor



--select * from PS_CM_SubContractPayment where SubContractType='P' and RegHumName='ϵͳ����Ա'
--delete from PS_CM_SubContractPayment where SubContractType='P' and RegHumName='ϵͳ����Ա'