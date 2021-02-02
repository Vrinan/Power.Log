Create Table AttentionPayment(
	Id uniqueidentifier not null primary key,
	InvoiceId uniqueidentifier null,
	InvoiceCode nvarchar(100) null,
	InvoiceTitle nvarchar(100) null,
	SubContractId uniqueidentifier null,
	SubContractCode nvarchar(100) null,
	SubContractTitle nvarchar(100) null,
	SubContractType nvarchar(100) null,
	Formid uniqueidentifier null,
	IsAttention nvarchar(100) null,
	RegDate datetime null
)

alter table AttentionPayment add RegHumId uniqueidentifier null
alter table AttentionPayment add RegHumName nvarchar(100) null
alter table AttentionPayment add RegDeptId uniqueidentifier null
alter table AttentionPayment add RegDeptName nvarchar(100) null
alter table AttentionPayment add ToHumanNames nvarchar(1000) null

--insert into AttentionPayment values(NEWID(),NEWID(),1,1,NEWID(),2,2,2,NEWID(),1,GETDATE())

select * from AttentionPayment
delete from AttentionPayment
--á¯ÕñÐË
--³Â½ú¿µ
--³Â×ÔÇ¿
select * from PB_User where Name='á¯ÕñÐË'



create view View_SF_AttentionPayment
as
select * from AttentionPayment

select * from View_SF_AttentionPayment