CREATE PROCEDURE [dbo].[Proc_PS_PUR_BOM] 
	
	@OrderId nvarchar(50),
	@HumanId nvarchar(50),	--操作人员ID
	@HumanName nvarchar(50),	--操作人员姓名
	@EpsProjId nvarchar(50),
	@OwnProjName nvarchar(500)

AS
BEGIN
	SET NOCOUNT ON;
	
	declare @Return varchar(50)='成功';
	declare @count int;
	declare @count1 int;
	declare @count2 int;
	declare @Max int;
	declare @Id nvarchar(50);
	declare @i int;
	declare @MatName nvarchar(500);
	declare @MatCode nvarchar(50);
	declare @MatBS_Code nvarchar(50);
	declare @MatDescription nvarchar(500);
	declare @MatUnit nvarchar(20)
	
	set @i=0
	--select @count=count(*) from PS_PUR_BOM where MasterId = @OrderId
    --while @i< @count
	declare MainCur cursor for
			--物资计划获取数据
	select MatName,MatCode,MatBsCode,MatDescription,MatUnit from PS_PUR_BOM where MasterId = @OrderId

	open MainCur

	FETCH NEXT FROM MainCur INTO @MatName,@MatCode,@MatBS_Code,@MatDescription,@MatUnit
		WHILE(@@fetch_status=0)
		begin
			--通过物资小类找到物资分类的id
			select @Id=Id from PS_MDM_MatBS where LongCode=@MatBS_Code
			--判断通过长描述能否找到匹配数据
			select @count1=count(*) from XLX_MDM_MAT_Middle where MatLongName=@MatDescription
			if(@count1=0)
				begin
					--获取当前物资编号流水号
					set @MatBS_Code = replace(@MatBS_Code,'.','')
					select @Max=max(convert(int,stuff(MatCode,1,9,''))) from XLX_MDM_MAT_Middle where MatCode like '%'+@MatBS_Code+'%'
					--当前流水号加1
					set @Max= isnull(@Max,0)+1;
					--判断流水号有几位
					if(len(@Max)=1)
						begin 
							--把1变成xxxx xxxx x 0001
							set @MatCode=@MatBS_Code+'000'+convert(varchar,@Max)
							--往物资库中间表插入数据
							insert into XLX_MDM_MAT_Middle(Id,MatBS_Guid,MatBS_Code,MatBS_Name,MatCode,MatShortName,MatLongName,MatUnit,UpdHumId,UpdHuman,UpdDate,RegDate,
								RegHumName,RegHumId,OwnProjName,OwnProjId,EpsProjId,ApprHumId,ApprHumName,ApprDate,Status,Memo,BizAreaId,FK,IsInsert)
								VALUES(NewId(),@Id,'','',@MatCode,@MatName,@MatDescription,@MatUnit,@HumanId,@HumanName,GETDATE(),GETDATE(),
								@HumanName,@HumanId,@OwnProjName,@EpsProjId,@EpsProjId,@HumanId,@HumanName,GETDATE(),0,'','00000000-0000-0000-0000-00000000000A',@OrderId,0)
						end
					if(len(@Max)=2)
						begin 
							--把11变成xxxx xxxx x 0011
							set @MatCode=@MatBS_Code+'00'+convert(varchar,@Max)
							--往物资库中间表插入数据
							insert into XLX_MDM_MAT_Middle(Id,MatBS_Guid,MatBS_Code,MatBS_Name,MatCode,MatShortName,MatLongName,MatUnit,UpdHumId,UpdHuman,UpdDate,RegDate,
								RegHumName,RegHumId,OwnProjName,OwnProjId,EpsProjId,ApprHumId,ApprHumName,ApprDate,Status,Memo,BizAreaId,FK,IsInsert)
								VALUES(NewId(),@Id,'','',@MatCode,@MatName,@MatDescription,@MatUnit,@HumanId,@HumanName,GETDATE(),GETDATE(),
								@HumanName,@HumanId,@OwnProjName,@EpsProjId,@EpsProjId,@HumanId,@HumanName,GETDATE(),0,'','00000000-0000-0000-0000-00000000000A',@OrderId,0)
						end
					if(len(@Max)=3)
						begin 
							--把111变成xxxx xxxx x 0111
							set @MatCode=@MatBS_Code+'0'+convert(varchar,@Max)
							--往物资库中间表插入数据
							insert into XLX_MDM_MAT_Middle(Id,MatBS_Guid,MatBS_Code,MatBS_Name,MatCode,MatShortName,MatLongName,MatUnit,UpdHumId,UpdHuman,UpdDate,RegDate,
								RegHumName,RegHumId,OwnProjName,OwnProjId,EpsProjId,ApprHumId,ApprHumName,ApprDate,Status,Memo,BizAreaId,FK,IsInsert)
								VALUES(NewId(),@Id,'','',@MatCode,@MatName,@MatDescription,@MatUnit,@HumanId,@HumanName,GETDATE(),GETDATE(),
								@HumanName,@HumanId,@OwnProjName,@EpsProjId,@EpsProjId,@HumanId,@HumanName,GETDATE(),0,'','00000000-0000-0000-0000-00000000000A',@OrderId,0)
						end
					if(len(@Max)=4)
						begin 
							--把1111变成xxxx xxxx x 1111
							set @MatCode=@MatBS_Code+convert(varchar,@Max)
							--往物资库中间表插入数据
							insert into XLX_MDM_MAT_Middle(Id,MatBS_Guid,MatBS_Code,MatBS_Name,MatCode,MatShortName,MatLongName,MatUnit,UpdHumId,UpdHuman,UpdDate,RegDate,
								RegHumName,RegHumId,OwnProjName,OwnProjId,EpsProjId,ApprHumId,ApprHumName,ApprDate,Status,Memo,BizAreaId,FK,IsInsert)
								VALUES(NewId(),@Id,'','',@MatCode,@MatName,@MatDescription,@MatUnit,@HumanId,@HumanName,GETDATE(),GETDATE(),
								@HumanName,@HumanId,@OwnProjName,@EpsProjId,@EpsProjId,@HumanId,@HumanName,GETDATE(),0,'','00000000-0000-0000-0000-00000000000A',@OrderId,0)
						end
				end
			FETCH NEXT FROM MainCur INTO @MatName,@MatCode,@MatBS_Code,@MatDescription,@MatUnit
		end
	CLOSE MainCur 
	DEALLOCATE MainCur 
	
		--往物资库插入数据
		insert into PS_MDM_Mat(Id,MatBS_Guid,MatBS_Code,MatBS_Name,MatCode,MatShortName,MatLongName,MatUnit,UpdHumId,UpdHuman,UpdDate,RegDate,
			RegHumName,RegHumId,OwnProjName,OwnProjId,EpsProjId,ApprHumId,ApprHumName,ApprDate,Status,Memo,BizAreaId) 
		select NEWID(),MatBS_Guid,MatBS_Code,MatBS_Name,MatCode,MatShortName,MatLongName,MatUnit,UpdHumId,UpdHuman,UpdDate,RegDate,
			RegHumName,RegHumId,OwnProjName,OwnProjId,EpsProjId,ApprHumId,ApprHumName,ApprDate,Status,Memo,BizAreaId from XLX_MDM_MAT_Middle where FK=@OrderId and IsInsert=0
		update XLX_MDM_MAT_Middle set IsInsert=1 where FK=@OrderId
	select @Return
end