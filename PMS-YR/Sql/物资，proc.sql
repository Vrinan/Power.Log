
--修改到货生成入库单存储过程
-- =============================================
-- Author:		尹明
-- Create date: 2017年8月22日14:26:09
-- Description:	物资管理-到货检查：相关操作
-- =============================================
alter PROCEDURE [dbo].[Proc_PS_PUR_ArrivalCheck]
	@Type nvarchar(20),
	@Id nvarchar(50)
AS
BEGIN
	-- SET NOCOUNT ON added to prevent extra result sets from
	-- interfering with SELECT statements.
	SET NOCOUNT ON;

	--到货检查 (PS_ArrivalCheck)
	--select * from PS_PUR_ArrivalCheck		--update PS_PUR_ArrivalCheck set Status=0
	--到货检查-明细
	--select * from PS_PUR_ArrivalCheck_Dtl

    declare @Return nvarchar(200)='成功',@Count int=0
	declare @NewId nvarchar(50)
	declare @Other nvarchar(50)
	declare @date nvarchar(50)
	declare @InStoreCode nvarchar(50)
	declare @Code1 nvarchar(50)
	declare @Count2 nvarchar(50)

	declare @OwnProjId nvarchar(50),@OwnProjName nvarchar(50),@RegHumId nvarchar(50),@RegHumName nvarchar(20)
	declare @Code nvarchar(200),@Title nvarchar(50),@Contract_Guid nvarchar(50),@XLX_Contract_Code nvarchar(100),@ContractName nvarchar(200),@Storage_Guid nvarchar(50),@StorageName nvarchar(20),@SupplierId nvarchar(50),@Supplier nvarchar(100)

	select  
			@OwnProjId=OwnProjId,@OwnProjName=OwnProjName,@RegHumId=RegHumId,@RegHumName=RegHumName,@Other=Other,
			@Code=Code,@Title=Title,@Contract_Guid=Contract_Guid,@XLX_Contract_Code=XLX_Contract_Code,@ContractName=ContractName,
			@Storage_Guid=Storage_Guid,@StorageName=StorageName,@SupplierId=SupplierId,@Supplier=Supplier
	from PS_PUR_ArrivalCheck where Id=@Id
	if @Type='到货入库'
	begin
		select @Count=count(*) from PS_PUR_MatInStore where Arrival_Guid=@Id
		if @Count>0
		begin
			set @Return='已生成入库单，不能重复！'
		end
		else
		begin	
			--到货检查 (PS_ArrivalCheck)
			--select * from PS_PUR_ArrivalCheck
			--入库单
			--select * from PS_PUR_MatInStore  update PS_PUR_MatInStore set InStoreFrom='yi'
			--入库单明细
			--select * from PS_PUR_MatInStore_Dtl
			set @date = CONVERT (nvarchar(12),GETDATE(),112)
			select @Code1=max(code) from PS_PUR_MatInStore
			--判断当天YRKJ-WZRK-yyMMdd-001是否存在
			set @InStoreCode = 'YRKJ-WZRK-'+@date+'-'+'001'
			select @Count2=count(*) from PS_PUR_MatInStore where code=@InStoreCode
			if(@Count2=0)
				begin
					set @InStoreCode = 'YRKJ-WZRK-'+@date+'-'+'001'
				end
			else 
				begin
					set @Code1 = CONVERT(int,stuff(@Code1,1,len(@Code1)-3,''))
					set @Code1 = @Code1 + 1
					if(len(@Code1)=1)
						begin
							set @InStoreCode = 'YRKJ-WZRK-'+@date+'-'+'00'+ @Code1
						end
					if(len(@Code1)=2)
						begin
							set @InStoreCode = 'YRKJ-WZRK-'+@date+'-'+'0'+ @Code1
						end
					if(len(@Code1)=3)
						begin
							set @InStoreCode = 'YRKJ-WZRK-'+@date+'-'+ @Code1
						end
				end

				set @NewId=NEWID()
				insert into PS_PUR_MatInStore(Status,EpsProjId,OwnProjId,OwnProjName,RegHumId,RegHumName,RegDate,UpdDate,Id,Memo,
					Arrival_Guid,ArrivalCode,Storage_Guid,StorageName,InStoreDate,InStoreFrom,code) 
				values(0,@OwnProjId,@OwnProjId,@OwnProjName,@RegHumId,@RegHumName,GETDATE(),GETDATE(),@NewId,@Other,
					@Id,@Code,@Storage_Guid,@StorageName,GETDATE(),'yi',@InStoreCode)
				 
				insert into PS_PUR_MatInStore_Dtl(Id,MasterId,Mat_Guid,ArrivalMat_Guid,Sequ,MatCode,MatName,MatDescription,MatUnit,UnitPrice,InStoreNum,InStoreAmount,Freight,TotalAmount,BatchCode,UpdDate,XLX_RequestId,MatSpec,TagNumber,Remarks)
				select
					NEWID(),@NewId,Mat_Guid,Id,Sequ,MatCode,MatName,MatDescription,MatUnit,UnitPrice,ArrivalNum,UnitPrice*ArrivalNum,0,0,'',GETDATE(),XLX_RequestId,MatSpec,TagNumber,Remarks
				from PS_PUR_ArrivalCheck_Dtl where MasterId=@Id

			set @Return='生成入库单成功！'+@NewId
		end
	end

	if @Type='不合格项处理'
	begin
		select @Count=count(*) from XLX_PUR_NonComformProduct where Arrival_Guid=@Id
		if @Count>0
		begin
			set @Return='已存在不合格项处理，不能重复生成！'
		end
		else
		begin
			--不合格项处理(PS_NonConformProduct)  CheckPhase:到货检查（A）；制造过程（M） 
			--select * from XLX_PUR_NonComformProduct  update XLX_PUR_NonComformProduct set tablename='XLX_PUR_NonComformProduct',bizareaid='00000000-0000-0000-0000-00000000000A',sequ=1 where id='A4C9A269-4A25-4E6F-BB51-6E97291489DE'
			--不合格项处理-明细
			--select * from XLX_PUR_NonComformProduct_List

			set @NewId=NEWID()
			insert into XLX_PUR_NonComformProduct(TableName,BizAreaId,Sequ,Status,Title,EpsProjId,OwnProjId,OwnProjName,RegHumId,RegHumName,RegDate,UpdDate,Id,
				Contract_Guid,ContractCode,ContractName,SupplierId,Supplier,Arrival_Guid,ArrivalCode,ArrivalTitle,HandleDate) 
			values('XLX_PUR_NonComformProduct','00000000-0000-0000-0000-00000000000A',0,0,'不合格项处理',@OwnProjId,@OwnProjId,@OwnProjName,@RegHumId,@RegHumName,GETDATE(),GETDATE(),@NewId,
				@Contract_Guid,@XLX_Contract_Code,@ContractName,@SupplierId,@Supplier,@Id,@Code,@Title,CONVERT(varchar(10),getdate(),120))

			insert into XLX_PUR_NonComformProduct_List(Id,FK,MatBS_Guid,MatBS_Code,MatBS_Name,MatId,MatCode,MatName,Model,Standard,Texture,MatUnit,ContractNum,ArrivalNum,UnPassNum,HandleWay,Remark,UpdDate)
			select
				NEWID(),@NewId,MatBS_Guid,'',MatBS_Name,Mat_Guid,MatCode,MatName,MatModel,MatSpec,MatDescription,MatUnit,ContractNum,ArrivalNum,UnPassNum,'','',GETDATE()
			from PS_PUR_ArrivalCheck_Dtl where MasterId=@Id and UnPassNum>0

			set @Return='已生成不合格项处理！'+@NewId
		
		end		
	end

	if @Type='领料出库'
	begin
		select @Count=count(*) from PS_PUR_MatOutStore where Requisition_Guid=@Id
		if @Count>0
		begin
			set @Return='已生成出库单，不能重复！'
		end
		else
		begin	
			--领料申请
			--select * from PS_PUR_MatRequisitions
			--select * from PS_PUR_MatRequisitions_Dtl

			--出库单
			--select * from PS_PUR_MatOutStore
			--select * from PS_PUR_MatOutStore_Dtl
			select  
					@OwnProjId=OwnProjId,@OwnProjName=OwnProjName,@RegHumId=RegHumId,@RegHumName=RegHumName,
					@Code=Code,@Title=Title
			from PS_PUR_MatRequisitions where Id=@Id

			set @NewId=NEWID()
			insert into PS_PUR_MatOutStore(Status,EpsProjId,OwnProjId,OwnProjName,RegHumId,RegHumName,RegDate,UpdDate,Id,
				Code,Title,Requisition_Guid,RequisitionTitle,OutStoreDate,OutStoreFrom) 
			values(0,@OwnProjId,@OwnProjId,@OwnProjName,@RegHumId,@RegHumName,GETDATE(),GETDATE(),@NewId,
				'','',@Id,@Title,GETDATE(),'yi')

			--RequisitionNum:领料数量
			--OutStoreNum: 出库数量
			--OutStoreAmount:出库金额
			insert into PS_PUR_MatOutStore_Dtl(Id,MasterId,Mat_Guid,Requisition_Guid,Sequ,MatCode,MatName,MatDescription,MatUnit,UnitPrice,OutStoreAmount,OutStoreNum,RequisitionNum,BatchCode,Storage_Guid,StorageName,UpdDate,TagNumber,MatSpec)
			select
				NEWID(),@NewId,Mat_Guid,Id,0,MatCode,MatName,MatDescription,MatUnit,0,0,RequestNum,RequestNum,'',Storage_Guid,'',GETDATE(),TagNumber,MatSpec
			from PS_PUR_MatRequisitions_Dtl where MasterId=@Id
			--ArrivalNum:到货数量
			--KcNum:库存数量
			--RequestNum:需求数量
			--ActualNum:实发数量

			set @Return='生成出库单成功！'+@NewId
		end
	end

	select @Return
END





