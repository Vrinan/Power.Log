CREATE PROCEDURE [dbo].[Proc_PS_PUR_BOM] 
	
	@OrderId nvarchar(50),
	@HumanId nvarchar(50),	--������ԱID
	@HumanName nvarchar(50),	--������Ա����
	@EpsProjId nvarchar(50),
	@OwnProjName nvarchar(500)

AS
BEGIN
	SET NOCOUNT ON;
	
	declare @Return varchar(50)='�ɹ�';
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
			--���ʼƻ���ȡ����
	select MatName,MatCode,MatBsCode,MatDescription,MatUnit from PS_PUR_BOM where MasterId = @OrderId

	open MainCur

	FETCH NEXT FROM MainCur INTO @MatName,@MatCode,@MatBS_Code,@MatDescription,@MatUnit
		WHILE(@@fetch_status=0)
		begin
			--ͨ������С���ҵ����ʷ����id
			select @Id=Id from PS_MDM_MatBS where LongCode=@MatBS_Code
			--�ж�ͨ���������ܷ��ҵ�ƥ������
			select @count1=count(*) from XLX_MDM_MAT_Middle where MatLongName=@MatDescription
			if(@count1=0)
				begin
					--��ȡ��ǰ���ʱ����ˮ��
					set @MatBS_Code = replace(@MatBS_Code,'.','')
					select @Max=max(convert(int,stuff(MatCode,1,9,''))) from XLX_MDM_MAT_Middle where MatCode like '%'+@MatBS_Code+'%'
					--��ǰ��ˮ�ż�1
					set @Max= isnull(@Max,0)+1;
					--�ж���ˮ���м�λ
					if(len(@Max)=1)
						begin 
							--��1���xxxx xxxx x 0001
							set @MatCode=@MatBS_Code+'000'+convert(varchar,@Max)
							--�����ʿ��м���������
							insert into XLX_MDM_MAT_Middle(Id,MatBS_Guid,MatBS_Code,MatBS_Name,MatCode,MatShortName,MatLongName,MatUnit,UpdHumId,UpdHuman,UpdDate,RegDate,
								RegHumName,RegHumId,OwnProjName,OwnProjId,EpsProjId,ApprHumId,ApprHumName,ApprDate,Status,Memo,BizAreaId,FK,IsInsert)
								VALUES(NewId(),@Id,'','',@MatCode,@MatName,@MatDescription,@MatUnit,@HumanId,@HumanName,GETDATE(),GETDATE(),
								@HumanName,@HumanId,@OwnProjName,@EpsProjId,@EpsProjId,@HumanId,@HumanName,GETDATE(),0,'','00000000-0000-0000-0000-00000000000A',@OrderId,0)
						end
					if(len(@Max)=2)
						begin 
							--��11���xxxx xxxx x 0011
							set @MatCode=@MatBS_Code+'00'+convert(varchar,@Max)
							--�����ʿ��м���������
							insert into XLX_MDM_MAT_Middle(Id,MatBS_Guid,MatBS_Code,MatBS_Name,MatCode,MatShortName,MatLongName,MatUnit,UpdHumId,UpdHuman,UpdDate,RegDate,
								RegHumName,RegHumId,OwnProjName,OwnProjId,EpsProjId,ApprHumId,ApprHumName,ApprDate,Status,Memo,BizAreaId,FK,IsInsert)
								VALUES(NewId(),@Id,'','',@MatCode,@MatName,@MatDescription,@MatUnit,@HumanId,@HumanName,GETDATE(),GETDATE(),
								@HumanName,@HumanId,@OwnProjName,@EpsProjId,@EpsProjId,@HumanId,@HumanName,GETDATE(),0,'','00000000-0000-0000-0000-00000000000A',@OrderId,0)
						end
					if(len(@Max)=3)
						begin 
							--��111���xxxx xxxx x 0111
							set @MatCode=@MatBS_Code+'0'+convert(varchar,@Max)
							--�����ʿ��м���������
							insert into XLX_MDM_MAT_Middle(Id,MatBS_Guid,MatBS_Code,MatBS_Name,MatCode,MatShortName,MatLongName,MatUnit,UpdHumId,UpdHuman,UpdDate,RegDate,
								RegHumName,RegHumId,OwnProjName,OwnProjId,EpsProjId,ApprHumId,ApprHumName,ApprDate,Status,Memo,BizAreaId,FK,IsInsert)
								VALUES(NewId(),@Id,'','',@MatCode,@MatName,@MatDescription,@MatUnit,@HumanId,@HumanName,GETDATE(),GETDATE(),
								@HumanName,@HumanId,@OwnProjName,@EpsProjId,@EpsProjId,@HumanId,@HumanName,GETDATE(),0,'','00000000-0000-0000-0000-00000000000A',@OrderId,0)
						end
					if(len(@Max)=4)
						begin 
							--��1111���xxxx xxxx x 1111
							set @MatCode=@MatBS_Code+convert(varchar,@Max)
							--�����ʿ��м���������
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
	
		--�����ʿ��������
		insert into PS_MDM_Mat(Id,MatBS_Guid,MatBS_Code,MatBS_Name,MatCode,MatShortName,MatLongName,MatUnit,UpdHumId,UpdHuman,UpdDate,RegDate,
			RegHumName,RegHumId,OwnProjName,OwnProjId,EpsProjId,ApprHumId,ApprHumName,ApprDate,Status,Memo,BizAreaId) 
		select NEWID(),MatBS_Guid,MatBS_Code,MatBS_Name,MatCode,MatShortName,MatLongName,MatUnit,UpdHumId,UpdHuman,UpdDate,RegDate,
			RegHumName,RegHumId,OwnProjName,OwnProjId,EpsProjId,ApprHumId,ApprHumName,ApprDate,Status,Memo,BizAreaId from XLX_MDM_MAT_Middle where FK=@OrderId and IsInsert=0
		update XLX_MDM_MAT_Middle set IsInsert=1 where FK=@OrderId
	select @Return
end