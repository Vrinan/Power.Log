alter PROCEDURE [dbo].[Proc_XLX_BomFileTORequest]
 @OrderId nvarchar(50), 
 @HumanId nvarchar(50) ='', --操作人员ID  
 @HumanName nvarchar(50) ='' --操作人员姓名  
AS  
BEGIN  
 SET NOCOUNT ON;  
 declare @Return nvarchar(200)='成功'  
 declare @Count int=0  
 declare @NewId nvarchar(50)
 declare @OrderCode nvarchar(200)
 declare @OrderName nvarchar(200)
 declare @OwnProjName nvarchar(200)  
 declare @OwnProjId nvarchar(50)
 declare @ProMajor nvarchar(50)
   
  select @OrderCode=Code,@OrderName=Title,@OwnProjName=OwnProjName,@OwnProjId=OwnProjId,@ProMajor=ProMajor from PS_PUR_BOMFile where Id=@OrderId
  select @Count=count(*) from XLX_PUR_Request where Order_Guid=@OrderId  
  if @Count>0  
  begin  
   set @Return='已存在请购单，不能重复生成！'  
  end  
  else  
	begin  

    set @NewId=NEWID()

insert into XLX_PUR_Request(TableName,BizAreaId,RequestCode,Status,Title,ProMajor,RequestDate,RegHumId,RegHumName,RegDate,EpsProjId,OwnProjId,OwnProjName,Id,Order_Guid)   
values('XLX_PUR_Request','00000000-0000-0000-0000-00000000000A',@OrderCode,0,@OrderName,@ProMajor,'',@HumanId,@HumanName,GETDATE(),@OwnProjId,@OwnProjId,@OwnProjName,@NewId,@OrderId)  
     
insert into XLX_PUR_Request_List(Standard,UnitName,BeginDate,Id,FK,MatBS_Guid,MatBS_Code,MatBS_Name,MatId,MatCode,MatName,MatUnit,equ,TaxRate,Qty_Bom,Qty_Requested,Qty_Req,DeviceName,UpdDate)  
select MatDescription,UnitName,RequestDate,NEWID(),@NewId,'00000000-0000-0000-0000-000000000000',MatBsCode,(select MatBsname from PS_MDM_MATBS where longcode = MatBsCode),Mat_Guid,MatCode,MatName,MatUnit,0,0,Design_Qty,0,Design_Qty,Pur_Major,GETDATE() from PS_PUR_BOM where MasterId=@OrderId
	end  
  

 select @Return  
END 


