CREATE TABLE [dbo].[Payment_Electric](
	[UniqueId] [int] IDENTITY(1,1) NOT NULL,
	[ProjectId] [int] NULL,
	[code] [varchar](100) NULL,
	[name] [nvarchar](500) NULL,
	[state] [varchar](50) NULL,
	[apply_money] [money] NULL,
	[adder_sid] [int] NULL,
	[adder_name] [varchar](20) NULL,
	[add_date] [datetime] NULL,
	electricalType int null,
	[bookFinishedOrNot] [bit] NULL DEFAULT ((0)),
	[authorizePersonId] [int] NULL,
	[authorizePerson] [varchar](20) NULL,
	[authorizeDate] [datetime] NULL,
	[auditorId] [int] NULL,
	[auditor] [varchar](20) NULL,
	[auditingDate] [datetime] NULL,
	[authorizeStatus] [tinyint] NULL DEFAULT ((0)),
	[auditingStatus] [tinyint] NULL DEFAULT ((0)),
	[remark] [text] NULL,
	[rec_type] [int] NULL,
	[program_id] [int] NULL,
	[fukuanrenId] [int] NULL,
	[fukuanrenName] [nvarchar](50) NULL,
	[check_Fk] [int] NULL  DEFAULT ((0)),
 CONSTRAINT [PK_Payment_Electrical] PRIMARY KEY CLUSTERED 
(
	[UniqueId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]

CREATE TABLE Payment_Electrical_Content(
	[UniqueId] [int] IDENTITY(1,1) NOT NULL,
	[Pay_NoPact_Id] [int] NULL,
	[record_money] [money] NULL,
	[record_note] [varchar](100) NULL,
	[bigId] [int] NULL,
	[smallId] [int] NULL,
 CONSTRAINT [PK_Payment_ElectricalContent] PRIMARY KEY CLUSTERED 
(
	[UniqueId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]


--流程配置表
insert into RECORD_TRANSFER (RECORD_ID, SYSTEM_MODULE_SID, RECORD_NAME, TABLE_NAME, KEY_NAME, EDIT_NAME, CONDITION_COLUMN, CONDITION_NAME, STATUS_COLUMN, PROJECT_ID_COLUMN, AUDITINGORNOT, RECRIGHTORNOT, RECTYPEORNOT, AUTOCODEORNOT, REMARKORNOT, RECRELATIONORNOT, COMORNOT, ADDABLEORNOT, TASKRELATIONORNOT, ATTACHORNOT, USEORNOT, CODE, NAME, EDIT_TIME)
values (1421, 14, '用电支付记录', 'Payment_Electric', 'uniqueId', 'Adder_Sid', '', '', 'state', '', 1, 0, 1, 1, 0, 0, 0, 0, 0, 0, 1, 'code', 'name', 'Add_Date');

insert into TRANSFER_ITEMS (RECORD_ID, TRAN_ITEM_NAME, TRAN_ITEM_ID, ID_COLUMN, NAME_COLUMN, DATE_COLUMN, STATUS_COLUMN)
values (1421, '审核', 2, 'Auditorid', 'Auditor', 'Auditingdate', 'Auditingstatus');

insert into TRANSFER_ITEMS (RECORD_ID, TRAN_ITEM_NAME, TRAN_ITEM_ID, ID_COLUMN, NAME_COLUMN, DATE_COLUMN, STATUS_COLUMN)
values (1421, '批准', 3, 'Authorizepersonid', 'Authorizeperson', 'Authorizedate', 'authorizestatus');

insert into doc_type (DOC_TYPE_SID, DOC_TYPE_NAME, REC_TYPE_SID, SYSTEM_MODULE_SID, DOC_TYPE_ID, PARENT_ID, HASCHILD, TREELEVEL, DISPLAYID, DISCOLOR, OBSID, REC_VS_DOCTYPESID, USEORNOT, FOLDER_SID, REC_CLASS_SID)
values (1421, '用电支付记录', 1421, 14, '1421', 0, 0.0000, 1.0000, 1421, 2.0000, null, null, 1, null, null);

insert into Rec_Right (REC_SID, CODE, NAME, REC_TYPE_SID, SYSTEM_MODULE_SID, PARENT_ID, HASCHILD, TREELEVEL, DISPLAYID, DISCOLOR, OBS_SID, USEORNOT)
values (1421, '', '用电支付记录', 1421, 14, 0, 0.0000, 1.0000, 3, 2.0000, 1, 1);

--对应设置里面的编号规则
insert into AUTO_CODE (SID, CODE, NAME, SELECTEDORNOT, REC_TYPE, DESCRIPTION)
values (1421, '1421', '用电支付记录默认规则', 1, 1421.0000, '【这里写项目ID，194】');

--流程记录表
select * from AUDITING_RECORD

select * from fun where fun_sid=16000458

SELECT a.*,d.doc_type_name as rec_typeName From Payment_NoPact a left join doc_type d on a.rec_type=d.doc_type_sid

select * from doc_type where doc_type_sid = 1421 or doc_type_sid = 1410

update PAY_Electric_gather set state='已批准' where code = 'YDZF-2017600004'

select * from Payment_Electric
Select a.*,c.rec_sid as record_sid From send_rec_lc a left join auditing_record b on a.ddi_sid=b.sid left join auditing_record_detail c on b.sid=c.aud_sid where a.rec_type_sid='1410'
select * from Payment_Electric where state='已批准' or state = '已审核'

CREATE TABLE Electric_bak(
	[UniqueId] [int] NOT NULL,
	[ProjectId] [int] NULL,
	[code] [varchar](100) NULL,
	[name] [nvarchar](500) NULL,
	[state] [varchar](50) NULL,
	[apply_money] [money] NULL,
	[adder_sid] [int] NULL,
	[adder_name] [varchar](20) NULL,
	[add_date] [datetime] NULL,
	electricalType nvarchar(50) null,
	[bookFinishedOrNot] [bit] NULL DEFAULT ((0)),
	[authorizePersonId] [int] NULL,
	[authorizePerson] [varchar](20) NULL,
	[authorizeDate] [datetime] NULL,
	[auditorId] [int] NULL,
	[auditor] [varchar](20) NULL,
	[auditingDate] [datetime] NULL,
	[authorizeStatus] [tinyint] NULL DEFAULT ((0)),
	[auditingStatus] [tinyint] NULL DEFAULT ((0)),
	[remark] [text] NULL,
	[rec_type] [int] NULL,
	[program_id] [int] NULL,
	[fukuanrenId] [int] NULL,
	[fukuanrenName] [nvarchar](50) NULL,
	[check_Fk] [int] NULL  DEFAULT ((0))
	)

select * from Payment_Electric

update Payment_Electric set add_date='2017-05-12 00:00:00.000' where UniqueId='35'
insert into Electric_bak select * from Payment_Electric where Payment_Electric.UniqueId not in (select UniqueId from Electric_bak)

select * from Electric_bak
delete from Electric_bak
select * from pact_record

update Electric_bak set state='未批准'

--本次申请金额
select sum(apply_money) from Electric_bak where Convert(varchar,add_date,120) like '2017-06%' and Electric_bak.state = '未批准'
--累计支付金额
select sum(apply_money) from Electric_bak where Convert(varchar,add_date,120) like '2017-06%' and Electric_bak.state = '已批准'

--获取数量，从payment表，当月已批准的
select count(*) as amount from Payment_Electric where Payment_Electric.UniqueId not in (select UniqueId from Electric_bak) and Convert(varchar,Payment_Electric.add_date,120) like '2017-06%' and state = '已批准'
--从payment表获取然后插入到表bak，当月已批准的（针对payment表），并设置bak表中取来的数据状态为未批准
insert into Electric_bak(UniqueId,ProjectId,code,name,state,apply_money,add_date,remark,rec_type,program_id,electricalType) select UniqueId,ProjectId,code,name,'未批准' as state,apply_money,add_date,remark,rec_type,program_id,electricalType from Payment_Electric where Payment_Electric.UniqueId not in (select UniqueId from Electric_bak) and Convert(varchar,Payment_Electric.add_date,120) like '2017-06%' and Payment_Electric.state = '已批准'
--content页面显示，显示当月未批准的（针对bak表）
select * from Electric_bak where Convert(varchar,add_date,120) like '2017-06%' and Electric_bak.state = '未批准'
select * from qbs_qi
select  * from USER_list
select * from Rec_attach where rec_type ='1410'
select  * from rpt_record where parentid=1
insert into rpt_record values(1,2,0,0,1,0,'用电支付表','2017-0001',null,'0',null,null,'',0,0,0)
delete from rpt_record where uniqueId=36
update RPT_RECORD set rpt_file ='print/Contract/search_electric.asp' where uniqueId = 37


select * from Electric_bak eb where eb.uniqueid>0