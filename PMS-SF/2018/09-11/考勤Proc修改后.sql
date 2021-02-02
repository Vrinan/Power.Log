

ALTER proc [dbo].[CheckWorkAll]
@DayTime nvarchar(50),--日期
@Month int,--月
@Day varchar(10),--日
@Year int,--年
@DeptId nvarchar(50),--部门id
@MainId nvarchar(50)
as
begin
    declare @count int
	declare @count1 int
	declare @count2 int
	declare @count3 int
	declare @count4 int
	declare @count5 int
	declare @count6 int
	declare @count7 int
	declare @count8 int
	declare @count9 int
	declare @Total int
	declare @HumanId nvarchar(50)
	declare @DayNumber nvarchar(20)
	declare @CheckOnWorkType nvarchar(10)
	declare @StartDate datetime
	declare @EndDate datetime
	declare @dd int
	declare @sqlStr nvarchar(500)

			--如果人员是在统计表中不存在，更新人员
			--第一个循环
			declare MyCur cursor for --建立名称为MyCur的游标
			select distinct HumanId from SF_HumanCheckOnWork where DeptId in (select Id from PB_Department where (ParentId in (select isnull(ParentId,'00000000-0000-0000-0000-000000000000') from PB_Department where Id=@DeptId) and ParentId<>'00000000-0000-0000-0000-000000000000')  or Id=@DeptId ) and Month=@Month and Year=@Year --找到当前部门在考勤表里面的所有人员，有‘借调’，因此不能用masterid,用deptid
			open MyCur --打开游标
			FETCH NEXT FROM MyCur INTO @HumanId  --取游标指向的当前行的数据赋值给变量@id
			WHILE(@@FETCH_STATUS = 0) --游标读取下一条数据是否成功
				begin
				--要执行循环的SQL语句
				--因为是重新生成，明细为空，不用判断人员是否存在
				--select @count1=count(*) from SF_ZH_CheckWork_All where HumanId=@HumanId and Month=@Month and Year=@Year
				--	if(@count1=0)
				--		begin
							insert into SF_ZH_CheckWork_All(Id,HumanId,MasterId,DeptId,DayTime,HumanCode,HumanName,CheckOnWorkType,Month,Year,CheckOnWorkId,Actived,IsMain) 
							select top 1 newid(),@HumanId,@MainId,@DeptId,@DayTime,HumanCode,HumanName,CheckOnWorkType,@Month,@Year,'00000000-0000-0000-0000-000000000000',0,0 from SF_HumanCheckOnWork where HumanId=@HumanId 
				--		end
				FETCH NEXT FROM MyCur INTO @HumanId  --取游标指向的当前行的数据赋值给变量@id
				END 
				CLOSE MyCur --关闭游标
				DEALLOCATE MyCur --删除游标
			--人员存在
			--第二个循环
			declare MyCur cursor for --建立名称为MyCur的游标
			select HumanId,CheckOnWorkType,day from SF_HumanCheckOnWork where DeptId in (select Id from PB_Department where  (ParentId in (select isnull(ParentId,'00000000-0000-0000-0000-000000000000') from PB_Department where Id=@DeptId) and ParentId<>'00000000-0000-0000-0000-000000000000')  or Id=@DeptId ) and Month=@Month and Year=@Year --取循环数据行
			open MyCur --打开游标
			FETCH NEXT FROM MyCur INTO @HumanId,@CheckOnWorkType,@day  --取游标指向的当前行的数据赋值给变量@id
			WHILE(@@FETCH_STATUS = 0) --游标读取下一条数据是否成功
				begin
				--要执行循环的SQL语句
				--select @count1=count(*) from SF_ZH_CheckWork_All where HumanId=@HumanId and Month=@Month and Year=@Year
				set @dd = 1
				while(@dd <=31)
				begin
				    if(@Day = @dd)
					begin
					   set @sqlStr  ='update SF_ZH_CheckWork_All set Day'+@dd +'  ' +@CheckOnWorkType + ' where HumanId= '+ @HumanId + ' and Month='+ @Month + ' and Year='+@Year
					   print @sqlStr
					   exec @sqlStr
					   --print @sqlStr
					   --update SF_ZH_CheckWork_All set Day1=@CheckOnWorkType where HumanId=@HumanId and Month=@Month and Year=@Year 
					end 

				    set @dd = @dd +1 
				end 

				if(@day=1)
					begin
						update SF_ZH_CheckWork_All set Day1=@CheckOnWorkType where HumanId=@HumanId and Month=@Month and Year=@Year
					end
				if(@day=2)
					begin
						update SF_ZH_CheckWork_All set Day2=@CheckOnWorkType where HumanId=@HumanId and Month=@Month and Year=@Year
					end
				if(@day=3)
					begin
						update SF_ZH_CheckWork_All set Day3=@CheckOnWorkType where HumanId=@HumanId and Month=@Month and Year=@Year
					end
                if(@day=4)
					begin
						update SF_ZH_CheckWork_All set Day4=@CheckOnWorkType where HumanId=@HumanId and Month=@Month and Year=@Year
					end
				if(@day=5)
					begin
						update SF_ZH_CheckWork_All set Day5=@CheckOnWorkType where HumanId=@HumanId and Month=@Month and Year=@Year
					end
				if(@day=6)
					begin
						update SF_ZH_CheckWork_All set Day6=@CheckOnWorkType where HumanId=@HumanId and Month=@Month and Year=@Year
					end
				if(@day=7)
					begin
						update SF_ZH_CheckWork_All set Day7=@CheckOnWorkType where HumanId=@HumanId and Month=@Month and Year=@Year
					end
				if(@day=8)
					begin
						update SF_ZH_CheckWork_All set Day8=@CheckOnWorkType where HumanId=@HumanId and Month=@Month and Year=@Year
					end
				if(@day=9)
					begin
						update SF_ZH_CheckWork_All set Day9=@CheckOnWorkType where HumanId=@HumanId and Month=@Month and Year=@Year
					end
                if(@day=10)
					begin
						update SF_ZH_CheckWork_All set Day10=@CheckOnWorkType where HumanId=@HumanId and Month=@Month and Year=@Year
					end
				if(@day=11)
					begin
						update SF_ZH_CheckWork_All set Day11=@CheckOnWorkType where HumanId=@HumanId and Month=@Month and Year=@Year
					end
				if(@day=12)
					begin
						update SF_ZH_CheckWork_All set Day12=@CheckOnWorkType where HumanId=@HumanId and Month=@Month and Year=@Year
					end
				if(@day=13)
					begin
						update SF_ZH_CheckWork_All set Day13=@CheckOnWorkType where HumanId=@HumanId and Month=@Month and Year=@Year
					end
				if(@day=14)
					begin
						update SF_ZH_CheckWork_All set Day14=@CheckOnWorkType where HumanId=@HumanId and Month=@Month and Year=@Year
					end
				if(@day=15)
					begin
						update SF_ZH_CheckWork_All set Day15=@CheckOnWorkType where HumanId=@HumanId and Month=@Month and Year=@Year
					end
                if(@day=16)
					begin
						update SF_ZH_CheckWork_All set Day16=@CheckOnWorkType where HumanId=@HumanId and Month=@Month and Year=@Year
					end
				if(@day=17)
					begin
						update SF_ZH_CheckWork_All set Day17=@CheckOnWorkType where HumanId=@HumanId and Month=@Month and Year=@Year
					end
				if(@day=18)
					begin
						update SF_ZH_CheckWork_All set Day18=@CheckOnWorkType where HumanId=@HumanId and Month=@Month and Year=@Year
					end
				if(@day=19)
					begin
						update SF_ZH_CheckWork_All set Day19=@CheckOnWorkType where HumanId=@HumanId and Month=@Month and Year=@Year
					end
				if(@day=20)
					begin
						update SF_ZH_CheckWork_All set Day20=@CheckOnWorkType where HumanId=@HumanId and Month=@Month and Year=@Year
					end
				if(@day=21)
					begin
						update SF_ZH_CheckWork_All set Day21=@CheckOnWorkType where HumanId=@HumanId and Month=@Month and Year=@Year
					end
                if(@day=22)
					begin
						update SF_ZH_CheckWork_All set Day22=@CheckOnWorkType where HumanId=@HumanId and Month=@Month and Year=@Year
					end
				if(@day=23)
					begin
						update SF_ZH_CheckWork_All set Day23=@CheckOnWorkType where HumanId=@HumanId and Month=@Month and Year=@Year
					end
				if(@day=24)
					begin
						update SF_ZH_CheckWork_All set Day24=@CheckOnWorkType where HumanId=@HumanId and Month=@Month and Year=@Year
					end
				if(@day=25)
					begin
						update SF_ZH_CheckWork_All set Day25=@CheckOnWorkType where HumanId=@HumanId and Month=@Month and Year=@Year
					end
				if(@day=26)
					begin
						update SF_ZH_CheckWork_All set Day26=@CheckOnWorkType where HumanId=@HumanId and Month=@Month and Year=@Year
					end
				if(@day=27)
					begin
						update SF_ZH_CheckWork_All set Day27=@CheckOnWorkType where HumanId=@HumanId and Month=@Month and Year=@Year
					end
				if(@day=28)
					begin
						update SF_ZH_CheckWork_All set Day28=@CheckOnWorkType where HumanId=@HumanId and Month=@Month and Year=@Year
					end
                if(@day=29)
					begin
						update SF_ZH_CheckWork_All set Day29=@CheckOnWorkType where HumanId=@HumanId and Month=@Month and Year=@Year
					end
				if(@day=30)
					begin
						update SF_ZH_CheckWork_All set Day30=@CheckOnWorkType where HumanId=@HumanId and Month=@Month and Year=@Year
					end
				if(@day=31)
					begin
						update SF_ZH_CheckWork_All set Day31=@CheckOnWorkType where HumanId=@HumanId and Month=@Month and Year=@Year
					end
				--更新多少白班，多少夜班....
				select @count2=count(*) from SF_HumanCheckOnWork where  HumanId=@HumanId and Month=@Month and Year=@Year and CheckOnWorkType='1'
				select @count3=count(*) from SF_HumanCheckOnWork where  HumanId=@HumanId and Month=@Month and Year=@Year and CheckOnWorkType='2'
				select @count4=count(*) from SF_HumanCheckOnWork where  HumanId=@HumanId and Month=@Month and Year=@Year and CheckOnWorkType='3'
				select @count5=count(*) from SF_HumanCheckOnWork where  HumanId=@HumanId and Month=@Month and Year=@Year and CheckOnWorkType='4'
				select @count6=count(*) from SF_HumanCheckOnWork where  HumanId=@HumanId and Month=@Month and Year=@Year and CheckOnWorkType='5'
				select @count7=count(*) from SF_HumanCheckOnWork where  HumanId=@HumanId and Month=@Month and Year=@Year and CheckOnWorkType='6'
				select @count8=count(*) from SF_HumanCheckOnWork where  HumanId=@HumanId and Month=@Month and Year=@Year and CheckOnWorkType='7'
				select @count9=count(*) from SF_HumanCheckOnWork where  HumanId=@HumanId and Month=@Month and Year=@Year and CheckOnWorkType='8'
				set @Total=@count2+@count3+@count4+@count5
				update SF_ZH_CheckWork_All set @DayNumber=@CheckOnWorkType,DayShift1=@count2,DayShift2=@count3,DayShift3=@count4,DayShift4=@count5,DayShift5=@count6,
				DayShift6=@count7,DayShift7=@count8,DayShift8=@count9,Total=@Total where HumanId=@HumanId and Month=@Month and Year=@Year
				
				FETCH NEXT FROM MyCur INTO @HumanId,@CheckOnWorkType,@day  --取游标指向的当前行的数据赋值给变量@id
				END 
				CLOSE MyCur --关闭游标
				DEALLOCATE MyCur --删除游标

	select'ok'
end

GO


