--费用工作接待申请dtl
CREATE TABLE SF_FK_Reimbursement_Receptiondtl(
	[Id] [uniqueidentifier] NOT NULL,
	[MasterId] [uniqueidentifier] NULL,
	[UpdDate] [datetime] NULL,
	[Memo] [nvarchar](500) NULL,
	[Sequ] int null,
	Code nvarchar(100) null,
	Title nvarchar(100) null,
	ReceptionDate datetime null,
	Amount numeric(18,2) null,
	ReceptionReason nvarchar(max) null
) 
alter table SF_FK_Reimbursement_Receptiondtl add ReceptionId uniqueidentifier null
select * from SF_FK_Reimbursement_Receptiondtl
--差旅dtl
CREATE TABLE SF_FK_Reimbursement_Traveldtl(
	[Id] [uniqueidentifier] NOT NULL,
	[MasterId] [uniqueidentifier] NULL,
	[UpdDate] [datetime] NULL,
	[Memo] [nvarchar](500) NULL,
	[Sequ] int null,
	Code nvarchar(100) null,
	Title nvarchar(100) null,
	TravelDate datetime null,
	TravelReason nvarchar(max) null
) 
alter table SF_FK_Reimbursement_Traveldtl add TravelId uniqueidentifier null
select * from SF_FK_Reimbursement_Traveldtl
--接待
select * from SF_FK_Reception where status = 50 and id not in(select ReceptionId from SF_FK_Reimbursement_Receptiondtl) and ApplicationHumanId=
select * from SF_FK_Reimbursement_Receptiondtl
--出差
select * from SF_ZH_BusinessTravel where status = 50 and id not in(select TravelId from SF_FK_Reimbursement_Traveldtl) and PurchaserId=
select * from SF_FK_Reimbursement_Traveldtl
--费用报销
select * from PB_Human where name = '余明锐'



Select XCode_T1.* From (Select A.*, row_number() over(Order By a.Id) as rowNumber From SF_FK_Reception A
 Where (0=0) and A.Status = 50 and A.Id not in(select ReceptionId from SF_FK_Reimbursement_Receptiondtl) 
 and A.ApplicantHumanId='6edc3907-d77b-4ad9-b74e-92bf230eb262') XCode_T1 Where rowNumber Between 1 And 15
