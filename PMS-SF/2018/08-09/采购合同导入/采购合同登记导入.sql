declare @cursor cursor
declare @code nvarchar(500)
declare @yf nvarchar(500)
declare @qk nvarchar(50)
declare @xs nvarchar(50)
declare @money numeric(18,4)
declare @PartyB_Guid nvarchar(50)--�ҷ�id
declare @RunStatus nvarchar(50)--ִ�����
declare @ContractForm nvarchar(50)--��ͬ��ʽ
declare @guid nvarchar(50)
--�趨�α������������ݼ�
set @cursor=cursor for
select ��ͬ���,�ҷ�, ִ����� ,��ͬ��ʽ,��ͬ��� from dbo.��ͬ�Ǽ�$ order by ��ͬ���
--���α�
open @cursor
--�ƶ��α�ָ�򵽵�һ�����ݣ���ȡ��һ�����ݴ���ڱ�����
fetch next from @cursor into @code,@yf,@qk,@xs,@money
--�����һ�β����ɹ������ѭ��
while(@@fetch_status=0)begin
 	--����guid
 	 set @guid = newid()
 	--��ѯ�ҷ���λid
 	select @PartyB_Guid = id from dbo.PB_Organize where name = @yf
 	--ִ�����
 	if(@qk = '��ǩ')
 		begin
 		   set @RunStatus = 1
 		end
 	else if(@qk = 'ִ����')
 		begin
 		   set @RunStatus = 2
 		end
 	else
 		begin
 		  set @RunStatus = 3
 		end 
 	
 	--��ͬ��ʽ
 	if(@xs = '���ں�ͬ')
 		begin
 		   set @ContractForm = 1
 		end
 	else
 		begin
	 	   set @ContractForm = 2 
 		end 
	insert into PS_CM_SubContract(id,status,SubContractType,SubContractCode,SubContractName,SubContractAmount,FinalSubContractAmount,
	PartyA,PartyAPerson,PartyAPersonId,PartyB,PartyB_Guid,SignDate,UpdDate,RegDate,RegHumName,RegHumId,OwnProjName,OwnProjId,EpsProjId,
	EPSProjectId,EPSProjectCode,EPSProjectName,RunStatus,ContractType,ContractForm)
	select @guid, 0,'P',��ͬ���,��ͬ����,��ͬ���,��ͬ���,'��������Ƽ����޹�˾','�׶�','FF528BB6-B2D8-4D47-8952-C69E987ADCB0',
	�ҷ�,@PartyB_Guid,ǩ������,getdate(),getdate(),'ϵͳ����Ա','AD000000-0000-0000-0000-000000000000','����Ƽ�','00000000-0000-0000-0000-0000000000A4','00000000-0000-0000-0000-0000000000A4',
	'ADA801CA-1937-4111-8555-4096EAC88EB4','mzz','Ĥ������Ŀ',@RunStatus,'03',@ContractForm
	from ��ͬ�Ǽ�$ where ��ͬ��� = @code
	
	--��ӽ����ϸ
	insert into SF_Contract_AmountList(id,masterid,amounttype,taxamount,totalamount)
    values(NewID(),@guid,'03',@money,@money)
		
	--���֧���ڵ�	
	insert into PS_CM_SubContract_PayNodes(id,masterid,sequ,Paytype,paypercent,payAmount)
    values(newid(),@guid,1,'JD',100,@money)
	
    --��������һ��
    fetch next from @cursor into @code,@yf,@qk,@xs,@money
end
--�ر��α�
close @cursor
--ɾ���α�
deallocate @cursor
