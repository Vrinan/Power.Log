use AlroyDB
declare @dt nvarchar(500)
set  @dt= CONVERT(nvarchar(500),GETDATE());
insert into PB_Files values(@dt,@dt,null)
