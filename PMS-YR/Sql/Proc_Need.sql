create PROCEDURE [dbo].[Proc_MatMatch] 
	@FK_Id nvarchar(50)
AS
BEGIN

	SET NOCOUNT ON;

	declare @Return nvarchar(200)='³É¹¦'
	declare @CbsValue nvarchar(1000)
	declare @Cbs_Guid nvarchar(50)
	declare @Price nvarchar(200)
	declare @VersionCode nvarchar(20)

			SELECT @VersionCode=MAX(VersionCode) FROM PS_CC_ContractBudget 
			declare  MainCur cursor for
			SELECT CbsValue,Cbs_Guid FROM PS_CC_ContractBudget_CBS a left join PS_CC_ContractBudget b on a.MasterId=b.Id where Cbs_Guid in (select Cbs_Guid from XLX_PUR_Need_CBS where XLX_PUR_Need_Id=@OrderId) and b.Status=50 and b.VersionCode=@VersionCode
			--SELECT CbsValue,Cbs_Guid,b.islastversion FROM PS_CC_ContractBudget_CBS a left join PS_CC_ContractBudget b on a.MasterId=b.Id 
--where Cbs_Guid in (select Cbs_Guid from XLX_PUR_Need_CBS where XLX_PUR_Need_Id='0043cafc-78e5-4318-82fc-261a815838e6') and
 --b.islastversion =0
				open MainCur
				FETCH NEXT FROM MainCur INTO @CbsValue,@Cbs_Guid
				WHILE (@@FETCH_STATUS = 0)
				begin
					--if(@CbsValue<>null)
					--begin
					SELECT @Price = dbo.fun_RetunrnPrice(@CbsValue)
					
					update XLX_PUR_Need_CBS set BudgetPrice=@Price  where Cbs_Guid=@Cbs_Guid
					
					--end
				FETCH NEXT FROM MainCur INTO @CbsValue,@Cbs_Guid
				end
				CLOSE MainCur 
				DEALLOCATE MainCur 			
		
	select @Price
END


