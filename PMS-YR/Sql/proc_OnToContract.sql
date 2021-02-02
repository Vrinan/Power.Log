
-- =============================================
-- Author:		����
-- Create date: 2017��8��17��
-- Description:	�ɹ�����-�ɹ����� ��ز���
-- =============================================
alter PROCEDURE [dbo].[Proc_XLX_PUR_Order] 
	@Type nvarchar(20),
	@OrderId nvarchar(50),
	@HumanId nvarchar(50) ='',	--������ԱID
	@HumanName nvarchar(50) =''	--������Ա����
AS
BEGIN
	-- SET NOCOUNT ON added to prevent extra result sets from
	-- interfering with SELECT statements.
	SET NOCOUNT ON;

	--�ɹ�����
	--select * from XLX_PUR_Order
	--select * from XLX_PUR_Order_List

	--�����ͬ����
	--select * from PS_CM_SubContractReview
	--�����ͬ����
	--select * from PS_CM_SubContract

	--exec Proc_XLX_PUR_Order '���ɺ�ͬ����','0E232223-A903-41D9-9969-87A85CBD5984','AD000000-0000-0000-0000-000000000000','ϵͳ����Ա'
	
	declare @Return nvarchar(200)='�ɹ�'
	declare @Count int=0
	declare @NewId nvarchar(50)
	declare @NewId1 nvarchar(50) 
	declare @OwnProjId nvarchar(50),@EpsProjId nvarchar(50),@OwnProjName nvarchar(50),@OrderCode nvarchar(50),@OrderName nvarchar(50),@BuyWay nvarchar(20)
	declare @BuyerId nvarchar(50),@BuyerName nvarchar(50), @PartyB_Guid nvarchar(50),@PartyB nvarchar(200),@PartyBPerson nvarchar(50)=''
	declare @SupplieName nvarchar(50),@SupplieId nvarchar(50),@LinkMan nvarchar(50),@LinkPhone nvarchar(50),@MatBS_Guid nvarchar(50),@MatUnit nvarchar(50)
	declare @MatBS_Name nvarchar(50),@MatId nvarchar(50),@MatCode nvarchar(50),@MatName nvarchar(50),@MatPrice nvarchar(50),@Qty_Order nvarchar(50)
	declare @BiddingType nvarchar(200),@DeptId uniqueidentifier
	select @BuyerId=BuyerId,@BuyerName=BuyerName, @HumanId=RegHumId,@HumanName=RegHumName, @OwnProjId=OwnProjId,@OwnProjName=OwnProjName,@OrderCode=OrderCode,@OrderName=Title,@BuyWay=BuyWay,@EpsProjId=EpsProjId,@BiddingType=BuyWay,@DeptId=RegDeptId from
	 XLX_PUR_Order where Id=@OrderId
	--select top 1 @PartyB_Guid=SupplieId,@PartyB=SupplieName,@PartyBPerson=LinkPhone from XLX_PUR_Order_List where FK=@OrderId
		if @Type='����ѯ��'
		--IF 1=2
		begin
		select @Count=count(*) from XLX_PUR_Inquiry where XLX_PUR_Order_Id=@OrderId
		if @Count>0
		begin
			set @Return='��ѯ�ۣ������ظ�����'
		end
		ELSE
		begin 
		--select * from XLX_PUR_Inquiry_MatList
		--select * from XLX_PUR_Order_List
		set @NewId1=NEWID()
		
		insert into XLX_PUR_Inquiry(
		TableName,BizAreaId,Sequ,Status,
		RegHumId,RegHumName,RegDate,EpsProjId,
		UpdHumId,UpdHumName,UpdDate,
		OwnProjId,OwnProjName,
		Title,
		Id,InquiryCode,InquiryDate,
		BuyerId,BuyerName,
		XLX_PUR_Order_Id,XLX_PUR_Order_Code,XLX_PUR_Order_Name)
		values(
		'XLX_PUR_Inquiry','00000000-0000-0000-0000-00000000000A',1,0,
		@HumanId,@HumanName,getdate(),@EpsProjId,
		@HumanId,@HumanName,getdate(),
		@OwnProjId,@OwnProjName,
		CONVERT(varchar(100), GETDATE(), 23)+'_�ɹ�������',
		@NewId1,'',CONVERT(varchar(100), GETDATE(), 23),
		@BuyerId,@BuyerName,
		@OrderId,@OrderCode,@OrderName)
		
		insert into XLX_PUR_Inquiry_MatList(
		Id,FK,RequestList_Id,
		MatBS_Guid,MatBS_Code,MatBS_Name,
		MatId,MatCode,MatName,
		Model,Standard,Texture,MatUnit,
		MatUnit2,Equ,Pressure,TaxRate,
		Qty_Request,Qty_Inquiry,InquiryUnit,Remark,
		RequestHumId,RequestHumName,UpdDate)
		select 
		newid(),@NewId1,InquiryMatList_Id,
		MatBS_Guid,MatBS_Code,MatBS_Name,
		MatId,MatCode,MatName,
		Model,Standard,Texture,MatUnit,
		MatUnit2,Equ,Pressure,TaxRate,
		Qty_Order,Qty_Order,MatUnit,Remark,
		@BuyerId,@BuyerName,getdate() from XLX_PUR_Order_List  where FK=@OrderId  
		 
		insert into XLX_PUR_Inquiry_SupplieList(Id,FK,Sequ,SupplieId,Name,Linkman,Phone ,UpdDate) 

			select newid(),@NewId1,0,*,getdate() from (	select distinct SupplieId,SupplieName,LinkMan,LinkPhone from XLX_PUR_order_list where FK=@OrderId ) a
		end
		end
		
		if @Type='�����б�ѯ��'
	begin
		select @Count=count(*) from PS_BID_Inquiry where Order_Guid=@OrderId
		if @Count>0
		begin
			set @Return='�����ɾ��귽���������ظ�����'
		end
		else
		begin
			--�����б�ѯ������
			set @NewId1=NEWID()
				--�����б�ѯ������select * from PS_BID_Inquiry
				insert into PS_BID_Inquiry(BiddingType,RegDeptId,Code,Title,InquiryType,Order_Guid,OrderCode,OrderName,ShortListNum,TenderWay,TenderMode,ReviewMethod,
				ControlCost,IsSecret,Id,UpdHumId,UpdHuman,UpdDate,RegDate,RegHumName,RegHumId,OwnProjName,OwnProjId,EpsProjId,ApprHumId,ApprHumName,Status,Memo,status2) 
				values(@BiddingType,@DeptId, '','',0,@OrderId,@ordercode,@OrderName,0,'','','',0,0,@NewId1,@HumanId,@HumanName,GETDATE(),GETDATE(),@HumanName,@HumanId,@OwnProjName,@OwnProjId,
				@OwnProjId,'00000000-0000-0000-0000-000000000000','',0,'','')
			--declare @maincur cursor
			--set @maincur = cursor for
			--	select distinct SupplieName,SupplieId from XLX_PUR_order_list where FK=@OrderId
			--open @maincur
			--FETCH NEXT FROM @maincur INTO @SupplieName,@SupplieId
			--WHILE (@@FETCH_STATUS = 0)
			--begin
				--����Ҫ���۵Ĺ�Ӧ�̡�������ϸ�����ӱ���
				--��Ӧ��
				--insert into PS_BID_Inquiry_LongList(Id,MasterId,Sequ,SubContractor,SubContractorId,Contacts,Telephone,Email,isPass,TenderFileStatus,InvitationStatus,QuoteStatus,CommercialBidStatus,
				--TechnicalBidStatus,BidBondStatus,Quote,CommercialScore,TechnologyScore,TotalScore,isWin,UpdDate) 
				--select distinct NEWID(),@NewId1,0,SupplieName,SupplieId,LinkMan,LinkPhone,'',0,'','','','','','','','','','','',GETDATE() from XLX_PUR_order_list where FK=@OrderId 
				--������ϸ
				insert into PS_BID_Inquiry_MatList(Id,Sequ,MasterId,MatBs_Guid,MatBs_Name,Mat_Guid,MatCode,MatName,MatDescription,TagNumber,MatUnit,MatAmount,XLX_Request_List_Id) 
				select NEWID(),0,@NewId1,MatBS_Guid,MatBS_Name,MatId,MatCode,MatName,Model,0,MatUnit,Qty_Order,InquiryMatList_Id from XLX_PUR_Order_List where FK=@OrderId 
			 

			--    FETCH NEXT FROM @maincur INTO @SupplieName,@SupplieId
			--end
			--CLOSE @maincur 
			--DEALLOCATE @maincur 
			
		set @Return='�ɹ����𾺼۷�����'
		end
		
	end

		if @Type='���ɺ�ͬ����'
	begin
		select @Count=count(*) from PS_CM_SubContractReview where Order_Guid=@OrderId
		if @Count>0
		begin
			set @Return='���ɺ�ͬ���󵥣������ظ�����'
		end
		else
		begin
			--select * from PS_CM_SubContractReview		delete PS_CM_SubContractReview
			set @NewId=NEWID()
			insert into PS_CM_SubContractReview(Status,RegHumId,RegHumName,RegDate,EpsProjId,OwnProjId,OwnProjName,SubContractName,Id,
				SubContractType,Order_Guid,OrderCode,OrderName,PurchaseWay,PartyB_Guid,PartyB) 
			values(0,@HumanId,@HumanName,GETDATE(),@OwnProjId,@OwnProjId,@OwnProjName,'_�ɹ�����',@NewId,
				'P',@OrderId,@OrderCode,@OrderName,@BuyWay,@PartyB_Guid,@PartyB)
			set @Return='�����ɺ�ͬ���󵥣�'+@NewId
		end
	end

		if @Type='���ɲɹ���ͬ'
	begin
		select @Count=count(*) from PS_CM_SubContract where Order_Guid=@OrderId
		if @Count>0
		begin
			set @Return='�Ѵ��ڲɹ���ͬ�������ظ����ɣ�'
		end
		else
		begin
		set @NewId=NEWID()
				insert into PS_CM_SubContract(Status,RegHumId,RegHumName,RegDate,EpsProjId,OwnProjId,OwnProjName,Id,SubContractCode,SubContractName,
					SubContractType,Order_Guid,OrderCode,OrderName,PurchaseWay,PartyB_Guid,PartyB,PartyBPerson,PartyAPersonId,PartyAPerson,PartyA) 
				values(0,@HumanId,@HumanName,GETDATE(),@OwnProjId,@OwnProjId,@OwnProjName,@NewId,'YRKJ-CGHT-','_�ɹ���ͬ',
					'P',@OrderId,@OrderCode,@OrderName,@BuyWay,@PartyB_Guid,@PartyB,@PartyBPerson,@HumanId,@HumanName,'�������ٿƼ����޹�˾')
		 
				insert into PS_CM_SubContract_MatItem(Id,MasterId,Sequ,MatBs_Guid,MatBsName,Mat_Guid,MatCode,MatName,MatSpec,MatModel,
				MatDescription,MatUnit,MatPrice,MatAmount,MatMoney,ArrivalNum,RequireDate,Cbs_Guid,CbsCode,CbsName,UpdDate,TagNumber,XLX_Request_List_Id,Remark)
				select NEWID(),@NewId,0,MatBS_Guid,MatBS_Name,MatId,MatCode,MatName,Standard,Model,'',MatUnit,MatPrice,Qty_Order,MatMoney,0,'','00000000-0000-0000-0000-000000000000','','',GETDATE(),'',InquiryMatList_Id,Remark
				from XLX_PUR_Order_List where FK=@OrderId
				
declare
@BeginDate datetime,
--װ��
@DeviceName nvarchar(100),
--λ��
@UnitName nvarchar(50),
--cbsid
@CBS_Id nvarchar(50),
--CBS_Name
@CBS_Name nvarchar(50),
--�빺����ϸId
@RequestListId nvarchar(50)
declare @cursor cursor
set @cursor=cursor for
select XLX_Request_List_Id from PS_CM_SubContract_MatItem where masterid=(select distinct id from PS_CM_SubContract where Order_Guid=@OrderId)
--select XLX_Request_List_Id from PS_CM_SubContract_MatItem where masterid=(select distinct id from PS_CM_SubContract where Order_Guid='e37f0833-d9ca-40dd-bcdd-6a02286db3d7')
--select BeginDate,DeviceName,UnitName,CBS_Id,CBS_Name from xlx_pur_request_list where id='18B9726E-4572-42EB-B6A0-00AAAD72CAE8'
--select * from PS_CM_SubContract_MatItem where XLX_Request_List_Id='18B9726E-4572-42EB-B6A0-00AAAD72CAE8'
open @cursor
fetch next from @cursor into @RequestListId
	while(@@fetch_status=0)
	begin
		select @BeginDate=BeginDate,@DeviceName=DeviceName,@UnitName=UnitName,@CBS_Id=CBS_Id,@CBS_Name=CBS_Name from xlx_pur_request_list where id=@RequestListId
		update PS_CM_SubContract_MatItem set RequireDate=@BeginDate,MatSpec=@DeviceName,TagNumber=@UnitName,Cbs_Guid=@CBS_Id,CBSName=@CBS_Name where XLX_Request_List_Id =@RequestListId
fetch next from @cursor into @RequestListId
	end
close @cursor
deallocate @cursor

		set @Return='������1�ݲɹ���ͬ����鿴�ɹ���ͬ�����ܡ�'
		end
		--select * from PS_CM_SubContract where id='57dd6640-3be2-4252-a482-ea742539a92b'
		--select * from PS_CM_SubContract_MatItem where masterid='57dd6640-3be2-4252-a482-ea742539a92b'
			--�ɹ�����
			--select * from XLX_PUR_Order
			--select * from XLX_PUR_Order_List
			--select * from PS_CM_SubContract where SubContractType='P'			delete XLX_PUR_Order
			--select * from PS_CM_SubContract_MatItem
		--	declare @i int=0
		--	--ѭ�����ɲɹ���ͬ
		--	declare  MainCur cursor for
		--		select distinct SupplieId,SupplieName from XLX_PUR_Order_List where FK=@OrderId
		--	open MainCur
		--	FETCH NEXT FROM MainCur INTO @PartyB_Guid,@PartyB
		--	WHILE (@@FETCH_STATUS = 0)
		--	begin
		--		set @NewId=NEWID()
		--		insert into PS_CM_SubContract(Status,RegHumId,RegHumName,RegDate,EpsProjId,OwnProjId,OwnProjName,Id,SubContractCode,SubContractName,
		--			SubContractType,Order_Guid,OrderCode,OrderName,PurchaseWay,PartyB_Guid,PartyB,PartyBPerson,PartyAPersonId,PartyAPerson) 
		--		values(0,@HumanId,@HumanName,GETDATE(),@OwnProjId,@OwnProjId,@OwnProjName,@NewId,'JSZX-CGHT-123','_�ɹ���ͬ',
		--			'P',@OrderId,@OrderCode,@OrderName,@BuyWay,@PartyB_Guid,@PartyB,@PartyBPerson,@HumanId,@HumanName)
		 
		--		insert into PS_CM_SubContract_MatItem(Id,MasterId,Sequ,MatBs_Guid,MatBsName,Mat_Guid,MatCode,MatName,MatSpec,MatModel,
		--		MatDescription,MatUnit,MatPrice,MatAmount,MatMoney,ArrivalNum,RequireDate,Cbs_Guid,CbsCode,CbsName,UpdDate,TagNumber,XLX_Request_List_Id)
		--		select NEWID(),@NewId,0,MatBS_Guid,MatBS_Name,MatId,MatCode,MatName,Standard,Model,'',MatUnit,MatPrice,Qty_Order,MatMoney,0,'','00000000-0000-0000-0000-000000000000','','',GETDATE(),'',InquiryMatList_Id
		--		from XLX_PUR_Order_List where FK=@OrderId and SupplieId=@PartyB_Guid

		--		set @i=@i+1
		--	FETCH NEXT FROM MainCur INTO @PartyB_Guid,@PartyB
		--	end
		--	CLOSE MainCur 
		--	DEALLOCATE MainCur 			

		--	set @Return='�����ɲɹ�'+cast(@i as varchar(10))+'�ݺ�ͬ����鿴�ɹ���ͬ�����ܡ�'
		
		--end		
	end

	select @Return
END