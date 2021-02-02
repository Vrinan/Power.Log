alter TRIGGER Tr_YRservicePack
ON pb_messages
FOR INSERT, UPDATE, DELETE 
AS
	declare @ToHumanId varchar(50),@code varchar(50),@count varchar(50);
	if (exists(select @ToHumanId = ToHumanId from inserted))
	select @code=Code from PB_User where HumanId in(select ToHumanId from pb_messages where ToHumanId=@ToHumanId)
	select @count=count(*) from pb_messages where ToHumanId=@ToHumanId
	exec IPCC_WEBSERVICE_PACKID @code,@count,'outText'
go


sp_configure 'show advanced options', 1;
GO
RECONFIGURE;
GO
sp_configure 'Ole Automation Procedures', 1;
GO
RECONFIGURE;
GO
EXEC sp_configure 'Ole Automation Procedures';
GO

CREATE PROCEDURE P_GET_HttpRequestData(
	@URL varchar(500),
	@status int=0 OUT,
	@returnText varchar(2000)='' OUT
)
AS
BEGIN
	DECLARE @object int,
	@errSrc int
	/*初始化对*/
	EXEC @status = SP_OACreate 'Msxml2.ServerXMLHTTP.3.0', @object OUT
	IF @status <> 0
	BEGIN
	 EXEC SP_OAGetErrorInfo @object, @errSrc OUT, @returnText OUT
	 RETURN
	END

	/*创建链接*/
	EXEC @status= SP_OAMethod @object,'open',NULL,'GET',@URL
	IF @status <> 0
	BEGIN
	 EXEC SP_OAGetErrorInfo @object, @errSrc OUT, @returnText OUT
	 RETURN
	END
	EXEC @status=SP_OAMethod @object,'setRequestHeader','Content-Type','application/x-www-form-urlencoded'
	/*发起请求*/
	EXEC @status= SP_OAMethod @object,'send',NULL 
	IF @status <> 0 
	BEGIN 
	 EXEC SP_OAGetErrorInfo @object, @errSrc OUT, @returnText OUT
	 RETURN
	END
     
	/*获取返回*/
	EXEC @status= SP_OAGetProperty @object,'responseText',@returnText OUT
	IF @status <> 0 
	BEGIN 
	 EXEC SP_OAGetErrorInfo @object, @errSrc OUT, @returnText OUT
	 RETURN
	END
END;

----测试
alter PROCEDURE IPCC_WEBSERVICE_PACKID(@UserCode VARCHAR(100),@badge varchar(10),@outText VARCHAR(255) OUT)
AS
BEGIN
  --@ts,时间戳
  declare @four varchar(10) = stuff(replace(stuff(CONVERT(VARCHAR(100), GETDATE(), 20),1,11,''),':',''),4,2,'')
  DECLARE @ts varchar(100) =  CONVERT(VARCHAR(100), GETDATE(), 112)+@four+''
  select @ts
  --@token
  DECLARE @token VARCHAR(500) = 'acce8f421b3eab1ac43bd172ea2f44bc'
  DECLARE @modulecode VARCHAR(500) = 'pms'
  DECLARE @returnText VARCHAR(500)
  DECLARE @status int
  DECLARE @urlStr VARCHAR(255)
  SET @urlStr = 'http://172.30.30.216:8080/ssoBadge/LoginSimple2.html?token='+@token+'&ts='+@ts+'&modulecode=pms&badge='+@badge+'&usercode='+@UserCode+'';
  EXEC P_GET_HttpRequestData @urlStr, @status OUTPUT, @returnText OUTPUT;
  SET @outText = @returnText;
  print @urlStr
  print @outText ---打印
END


exec IPCC_WEBSERVICE_PACKID 'MTYxOTU5','3','outText'


select * from PB_Widget where id='9963eeb2-03c5-4620-bce4-e09782d27db1'