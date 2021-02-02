--ÅÐ¶ÏÇë¹ºµ¥ºÅÊÇ·ñÖØ¸´£¬ÊÇ·µ»Ø1£¬·ñ·µ»Ø0
create PROCEDURE [dbo].[Proc_XLX_Request_btnSave]   
 @RequestCode nvarchar(50)
AS  
BEGIN  

 SET NOCOUNT ON;  

 declare @Return int  
 declare @count int 
   
  select @count=count(*) from XLX_PUR_Request where RequestCode=@RequestCode group by RequestCode  having count(RequestCode) > 1
   if @Count>0
	begin  
		set @Return=1
	end  
  else
	begin 
		set @Return=0
	end
  select @Return
END


--exec Proc_XLX_Request_btnSave '2017040038'
