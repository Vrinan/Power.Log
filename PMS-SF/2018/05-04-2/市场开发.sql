--Ͷ�걣֤������
Create table SF_BidDepositApplication
(
	Id uniqueidentifier not null,
	Code nvarchar(100) null,
	Title nvarchar(100) null,
	ProjId uniqueidentifier null,
	ClientId uniqueidentifier null,
	BiddingFilesId uniqueidentifier null,
	Amount float null,
	AmountCapital nvarchar(100) null, 
)
alter table SF_BidDepositApplication add OpenBiddingDate datetime null
alter table SF_BidDepositApplication add EndBiddingDate datetime null
--���
--ProjCode
--ProjName
--ProjSize
--ClientName
--BankName
--BankAccount
--BiddingFilesCode
--BiddingFilesTitle


--�ͻ�
select * from PB_Organize
--��Ŀ����
select * from PS_MK_ProjectInfo
--�б��ļ�����
select * from SF_FilesBoughtRecord
--�б��ļ�����
select * from SF_BiddingFiles


--select * from PB_Widget where id='89c1361c-2b73-419d-a5c3-4af416f8ea9b'
----��Ӫ�ܲ���
----/PowerPlat/FormXml/zh-CN/StdMarket/Win_StdMarketMain.htm
--select * from V_PS_ProjectInfo

select * from PB_Widget where id='9b283e34-b426-4506-b917-7a23e95a7385'
--��������
--/PowerPlat/FormXml/zh-CN/StdMarket/isBidReview.htm

--Ͷ�걣֤������
--���
--ProjCode
--ProjName
--ProjSize
--ClientName
--BiddingFilesCode
--BiddingFilesTitle

declare @money nvarchar(100)
set @money = 231.32
select [dbo].[fn_getformatmoney](@money) as a