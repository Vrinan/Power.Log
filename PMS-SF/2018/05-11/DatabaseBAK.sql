CREATE PROCEDURE sp_BackupDatabases 	
AS
BEGIN
	--���ñ������ݿ�Ĵ��Ŀ¼
	DECLARE @diskPath NVARCHAR(300)
	SET @diskPath='D:\Download\bak\Database\YR_PowerPlat_'
	+CONVERT(VARCHAR, GETDATE(),112)+'_'
	+REPLACE(CONVERT(VARCHAR, GETDATE(),108),':','')+'.BAK'
	BACKUP DATABASE YR_PowerPlat TO DISK = @diskPath WITH FORMAT;
END

EXEC YR_PowerPlat.dbo.sp_BackupDatabases


--sqlcmd -S . -E -Q "EXEC YR_PowerPlat.dbo.sp_BackupDatabases"