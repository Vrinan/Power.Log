
CREATE TABLE SF_HumanCheckOnWork(
	[Id] [uniqueidentifier] NOT NULL,
	[HumanId] [uniqueidentifier] NOT NULL,
	[CheckOnWorkType] [tinyint] NOT NULL,
	[CheckOnWorkId] [uniqueidentifier] NOT NULL,
	[Actived] [tinyint] NOT NULL,
	[IsMain] [tinyint] NOT NULL,
	[Sequ] [int] NULL,
	[AllocationType] [int] NULL,
	MasterId uniqueidentifier null,
	DayTime datetime null)

alter table SF_HumanCheckOnWork add HumanCode nvarchar(50)
alter table SF_HumanCheckOnWork add HumanName nvarchar(50)


select * from SF_KM_DocFolder

select * from SF_KM_DocFolderLimit

select * from SF_HumanCheckOnWork
delete from SF_HumanCheckOnWork
update SF_HumanCheckOnWork set DayTime = '2018-04-27'

Select XCode_T1.* From (Select A.*, row_number() over(Order By A.Sequ) as rowNumber From SF_HumanCheckOnWork A 
Where (0=0) and 1=1 and A.MasterId='909580a9-4f23-46a9-a689-63eed58dd2fc' and A.DayTime = 2018-04-27 and 1=1 ) XCode_T1 Where rowNumber Between 1 And 10

2018-04-27 00:00:00.000

Select XCode_T1.* From (Select A.*, row_number() over(Order By A.Sequ) as rowNumber From SF_HumanCheckOnWork A 
Where (0=0) and 1=1 and A.MasterId='909580a9-4f23-46a9-a689-63eed58dd2fc'and A.DayTime = 2018-04-27 + '00:00:00.000' and 1=1 ) XCode_T1 Where rowNumber Between 1 And 10