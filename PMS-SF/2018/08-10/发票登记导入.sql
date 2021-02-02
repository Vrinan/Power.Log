declare @cursor cursor
declare @invoiceAmount numeric(18,4)--��Ʊ���
declare @sbf numeric(18,4)--�豸��
declare @cid uniqueidentifier --��ͬId
declare @code nvarchar(500)
declare @name nvarchar(500)
declare @guid nvarchar(50)
--�趨�α������������ݼ�
set @cursor=cursor for
select ��ͬ���,��ͬ����,��Ʊ���,�豸�� from ��ͬ��Ʊ$ order by ��ͬ���
--���α�
open @cursor
--�ƶ��α�ָ�򵽵�һ�����ݣ���ȡ��һ�����ݴ���ڱ�����
fetch next from @cursor into @code,@name,@invoiceAmount,@sbf
--�����һ�β����ɹ������ѭ��
while(@@fetch_status=0)begin
 	--�½�guid
 	 set @guid = newid()
	 --��ѯ��ͬId
	 select @cid=Id from PS_CM_SubContract a where a.SubContractCode=@code

	insert into PS_CM_SubContractInvoice(id,Status,SubContractType,SubContract_Guid,Code,Title,InvoiceAmount,TotalInvoiceAmount,InvoiceType,
	AddNoTaxAmount,AddTaxAmount,TaxAmount,InvoiceDate,
	UpdDate,RegDate,RegHumName,RegHumId,OwnProjName,OwnProjId,EpsProjId)
	select @guid, 0,'P',@cid,��ͬ���,��ͬ����,@invoiceAmount,@invoiceAmount,'02',
	@invoiceAmount,@invoiceAmount,0,getdate(),
	getdate(),getdate(),'ϵͳ����Ա','AD000000-0000-0000-0000-000000000000','����Ƽ�','00000000-0000-0000-0000-0000000000A4','00000000-0000-0000-0000-0000000000A4'
	from ��ͬ��Ʊ$ where ��ͬ��� = @code
	
	--��ӷ�Ʊ��ϸ
	insert into PS_CM_SubContractInvoice_Dtl(id,MasterId,InvoiceAmount,UpdDate)
	values(NewID(),@guid,@invoiceAmount,getdate())

	--��ӽ����ϸ
	insert into SF_Contract_AmountList(id,masterid,amounttype,totalamount)
    values(NewID(),@guid,'03',@sbf)
	
    --��������һ��
    fetch next from @cursor into @code,@name,@invoiceAmount,@sbf
end
--�ر��α�
close @cursor
--ɾ���α�
deallocate @cursor
