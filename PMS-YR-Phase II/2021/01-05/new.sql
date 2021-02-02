

  
-- Batch submitted through debugger: SQLQuery4.sql|0|0|C:\Users\FZ\AppData\Local\Temp\~vs80DE.sql
-- =============================================
-- Author:		李建市
-- Create date: 2017年11月17日
-- Description:	采购管理-物资计划 相关操作
-- Update:xuzhimin 20171129,将@MatBS_Code加入中间表，以便以后做区分
-- Update:wangguodong 20200105，编码六位
-- =============================================
alter PROCEDURE [dbo].[Proc_PS_PUR_BOM] 
	
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
	declare @count3 int;
	declare @Max int;
	declare @Id nvarchar(50);
	declare @i int;
	declare @MatName nvarchar(500);
	declare @MatCode nvarchar(50);
	declare @Bom_Id nvarchar(50);
	declare @MatBS_Code nvarchar(50);
	declare @MatBS_Code2 nvarchar(50);
	declare @MatDescription nvarchar(500);
	declare @MatUnit nvarchar(20)  
	declare @Pattern nvarchar(200);
	declare @Specifi nvarchar(200);
	declare @Standard nvarchar(200);
	declare @Texture nvarchar(200)
	
	set @i=0
	--去空行、回车符号
	update PS_PUR_BOM set MatBsCode = REPLACE(MatBsCode,char(13),'') where MasterId=@OrderId
	update PS_PUR_BOM set MatBsCode = REPLACE(MatBsCode,char(10),'') where MasterId=@OrderId
	--去空格
	update PS_PUR_BOM set MatBsCode = REPLACE(MatBsCode,' ','') where MasterId=@OrderId
	--select @count=count(*) from PS_PUR_BOM where MasterId = @OrderId
    --while @i< @count

	select @count3=count(*) from PS_PUR_BOM where MasterId = @OrderId and (MatDescription is null OR MatBsCode IS NULL)
	if(@count3=0)
	begin
		declare MainCur cursor for
				--物资计划获取数据
		select MatName,MatCode,MatBsCode,MatDescription,MatUnit,Id,isnull(Pattern,''),isnull(Specifi,''),isnull(Standard,''),isnull(Texture,'') from PS_PUR_BOM where MasterId = @OrderId
		open MainCur

		FETCH NEXT FROM MainCur INTO @MatName,@MatCode,@MatBS_Code,@MatDescription,@MatUnit,@Bom_Id,@Pattern,@Specifi,@Standard,@Texture
			WHILE(@@fetch_status=0)
			begin
				--通过物资小类找到物资分类的id
				select @Id=Id from PS_MDM_MatBS where LongCode=@MatBS_Code
				--判断通过长描述,规格型号，制造标准，材质，型式，能否找到匹配数据
				select @count1=count(*) from XLX_MDM_MAT_Middle  where isnull(MatLongName,'')=@MatDescription and isnull(MatShortName,'')=@MatName and MatBS_Guid=@Id and  isnull(Pattern,'')=@Pattern  
				and isnull(Specifi,'')=@Specifi and isnull(Texture,'')=@Texture and isnull(Standard,'')=@Standard and MatBS_Code =@MatBS_Code
				if(@count1=0)
					begin
						set @MatBS_Code2=@MatBS_Code;--完成的待.的code，需要保存到中间表
						--获取当前物资编号流水号
						set @MatBS_Code = replace(@MatBS_Code,'.','')
						select @Max=max(convert(int,stuff(replace(REPLACE(MatCode,char(13)+char(10),''),' ',''),1,9,''))) from XLX_MDM_MAT_Middle where MatCode like '%'+@MatBS_Code+'%'
						--当前流水号加1
						set @Max= isnull(@Max,0)+1;
						--判断流水号有几位
						if(len(@Max)=1)
							begin 
								--把1变成xxxx xxxx x 000001
								set @MatCode=@MatBS_Code+'00000'+convert(varchar,@Max)
								--往物资库中间表插入数据
								insert into XLX_MDM_MAT_Middle(Id,MatBS_Guid,MatBS_Code,MatBS_Name,MatCode,MatShortName,MatLongName,MatUnit,UpdHumId,UpdHuman,UpdDate,RegDate,
									RegHumName,RegHumId,OwnProjName,OwnProjId,EpsProjId,ApprHumId,ApprHumName,ApprDate,Status,Memo,BizAreaId,FK,IsInsert,Bom_Id,Pattern,Specifi,Standard,Texture) 
									VALUES(NewId(),@Id,@MatBS_Code2,'',@MatCode,@MatName,@MatDescription,@MatUnit,@HumanId,@HumanName,GETDATE(),GETDATE(),
									@HumanName,@HumanId,@OwnProjName,@EpsProjId,@EpsProjId,@HumanId,@HumanName,GETDATE(),0,'','00000000-0000-0000-0000-00000000000A',@OrderId,0,@Bom_Id,@Pattern,@Specifi,@Standard,@Texture)
							end
						if(len(@Max)=2)
							begin 
								--把11变成xxxx xxxx x 000011
								set @MatCode=@MatBS_Code+'0000'+convert(varchar,@Max)
								--往物资库中间表插入数据
								insert into XLX_MDM_MAT_Middle(Id,MatBS_Guid,MatBS_Code,MatBS_Name,MatCode,MatShortName,MatLongName,MatUnit,UpdHumId,UpdHuman,UpdDate,RegDate,
									RegHumName,RegHumId,OwnProjName,OwnProjId,EpsProjId,ApprHumId,ApprHumName,ApprDate,Status,Memo,BizAreaId,FK,IsInsert,Bom_Id,Pattern,Specifi,Standard,Texture)
									VALUES(NewId(),@Id,@MatBS_Code2,'',@MatCode,@MatName,@MatDescription,@MatUnit,@HumanId,@HumanName,GETDATE(),GETDATE(),
									@HumanName,@HumanId,@OwnProjName,@EpsProjId,@EpsProjId,@HumanId,@HumanName,GETDATE(),0,'','00000000-0000-0000-0000-00000000000A',@OrderId,0,@Bom_Id,@Pattern,@Specifi,@Standard,@Texture)
							end
						if(len(@Max)=3)
							begin 
								--把111变成xxxx xxxx x 000111
								set @MatCode=@MatBS_Code+'000'+convert(varchar,@Max)
								--往物资库中间表插入数据
								insert into XLX_MDM_MAT_Middle(Id,MatBS_Guid,MatBS_Code,MatBS_Name,MatCode,MatShortName,MatLongName,MatUnit,UpdHumId,UpdHuman,UpdDate,RegDate,
									RegHumName,RegHumId,OwnProjName,OwnProjId,EpsProjId,ApprHumId,ApprHumName,ApprDate,Status,Memo,BizAreaId,FK,IsInsert,Bom_Id,Pattern,Specifi,Standard,Texture)
									VALUES(NewId(),@Id,@MatBS_Code2,'',@MatCode,@MatName,@MatDescription,@MatUnit,@HumanId,@HumanName,GETDATE(),GETDATE(),
									@HumanName,@HumanId,@OwnProjName,@EpsProjId,@EpsProjId,@HumanId,@HumanName,GETDATE(),0,'','00000000-0000-0000-0000-00000000000A',@OrderId,0,@Bom_Id,@Pattern,@Specifi,@Standard,@Texture)
							end
						if(len(@Max)=4)
							begin 
								--把1111变成xxxx xxxx x 001111
								set @MatCode=@MatBS_Code+'00'+convert(varchar,@Max)
								--往物资库中间表插入数据
								insert into XLX_MDM_MAT_Middle(Id,MatBS_Guid,MatBS_Code,MatBS_Name,MatCode,MatShortName,MatLongName,MatUnit,UpdHumId,UpdHuman,UpdDate,RegDate,
									RegHumName,RegHumId,OwnProjName,OwnProjId,EpsProjId,ApprHumId,ApprHumName,ApprDate,Status,Memo,BizAreaId,FK,IsInsert,Bom_Id,Pattern,Specifi,Standard,Texture)
									VALUES(NewId(),@Id,@MatBS_Code2,'',@MatCode,@MatName,@MatDescription,@MatUnit,@HumanId,@HumanName,GETDATE(),GETDATE(),
									@HumanName,@HumanId,@OwnProjName,@EpsProjId,@EpsProjId,@HumanId,@HumanName,GETDATE(),0,'','00000000-0000-0000-0000-00000000000A',@OrderId,0,@Bom_Id,@Pattern,@Specifi,@Standard,@Texture)
							end
						if(len(@Max)=5)
							begin 
								--把111变成xxxx xxxx x 011111
								set @MatCode=@MatBS_Code+'0'+convert(varchar,@Max)
								--往物资库中间表插入数据
								insert into XLX_MDM_MAT_Middle(Id,MatBS_Guid,MatBS_Code,MatBS_Name,MatCode,MatShortName,MatLongName,MatUnit,UpdHumId,UpdHuman,UpdDate,RegDate,
									RegHumName,RegHumId,OwnProjName,OwnProjId,EpsProjId,ApprHumId,ApprHumName,ApprDate,Status,Memo,BizAreaId,FK,IsInsert,Bom_Id,Pattern,Specifi,Standard,Texture)
									VALUES(NewId(),@Id,@MatBS_Code2,'',@MatCode,@MatName,@MatDescription,@MatUnit,@HumanId,@HumanName,GETDATE(),GETDATE(),
									@HumanName,@HumanId,@OwnProjName,@EpsProjId,@EpsProjId,@HumanId,@HumanName,GETDATE(),0,'','00000000-0000-0000-0000-00000000000A',@OrderId,0,@Bom_Id,@Pattern,@Specifi,@Standard,@Texture)
							end
						if(len(@Max)=6)
							begin 
								--把1111变成xxxx xxxx x 111111
								set @MatCode=@MatBS_Code+convert(varchar,@Max)
								--往物资库中间表插入数据
								insert into XLX_MDM_MAT_Middle(Id,MatBS_Guid,MatBS_Code,MatBS_Name,MatCode,MatShortName,MatLongName,MatUnit,UpdHumId,UpdHuman,UpdDate,RegDate,
									RegHumName,RegHumId,OwnProjName,OwnProjId,EpsProjId,ApprHumId,ApprHumName,ApprDate,Status,Memo,BizAreaId,FK,IsInsert,Bom_Id,Pattern,Specifi,Standard,Texture)
									VALUES(NewId(),@Id,@MatBS_Code2,'',@MatCode,@MatName,@MatDescription,@MatUnit,@HumanId,@HumanName,GETDATE(),GETDATE(),
									@HumanName,@HumanId,@OwnProjName,@EpsProjId,@EpsProjId,@HumanId,@HumanName,GETDATE(),0,'','00000000-0000-0000-0000-00000000000A',@OrderId,0,@Bom_Id,@Pattern,@Specifi,@Standard,@Texture)
							end
					end
				FETCH NEXT FROM MainCur INTO @MatName,@MatCode,@MatBS_Code,@MatDescription,@MatUnit,@Bom_Id,@Pattern,@Specifi,@Standard,@Texture
			end
		CLOSE MainCur 
		DEALLOCATE MainCur 
	
			--往物资库插入数据
			--insert into PS_MDM_Mat(Id,MatBS_Guid,MatBS_Code,MatBS_Name,MatCode,MatShortName,MatLongName,MatUnit,UpdHumId,UpdHuman,UpdDate,RegDate,
			--	RegHumName,RegHumId,OwnProjName,OwnProjId,EpsProjId,ApprHumId,ApprHumName,ApprDate,Status,Memo,BizAreaId,Middle_Id) --,Pattern,Specifi,Standard,Texture
			--select NEWID(),MatBS_Guid,MatBS_Code,MatBS_Name,MatCode,MatShortName,MatLongName,MatUnit,UpdHumId,UpdHuman,UpdDate,RegDate,
			--	RegHumName,RegHumId,OwnProjName,OwnProjId,EpsProjId,ApprHumId,ApprHumName,ApprDate,Status,Memo,BizAreaId,Id from XLX_MDM_MAT_Middle where FK=@OrderId and IsInsert=0
			--update XLX_MDM_MAT_Middle set IsInsert=1 where FK=@OrderId
		select @Return
	end
end

