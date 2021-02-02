CREATE TABLE [dbo].PAY_Electric_gather(
	[uniqueId] [int] IDENTITY(1,1) NOT NULL,
	[code] [varchar](50) NULL,
	[name] [varchar](100) NULL,
	[state] [varchar](20) NULL,
	[apply_money] [money] NULL,
	[payingfee] [money] NULL,
	[booker] [varchar](50) NULL,
	[bookerId] [int] NULL,
	[bookDate] [datetime] NULl DEFAULT (getdate()),
	[bookFinishedOrNot] [int] NULL DEFAULT ((0)),
	[authorizePerson] [varchar](50) NULL,
	[authorizePersonId] [int] NULL,
	[authorizeDate] [datetime] NULL,
	[auditor] [varchar](50) NULL,
	[auditorId] [int] NULL,
	[auditingDate] [datetime] NULL,
	[authorizeStatus] [tinyint] NULL DEFAULT ((0)),
	[auditingStatus] [tinyint] NULL DEFAULT ((0)),
	[rec_right] [int] NULL,
	[program_id] [int] NULL,
	[rec_type] [int] NULL DEFAULT ((1410)),
 CONSTRAINT [PK_PAY_Electric_gather] PRIMARY KEY CLUSTERED 
(
	[uniqueId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]


--流程配置表
insert into record_transfer (RECORD_ID, SYSTEM_MODULE_SID, RECORD_NAME, TABLE_NAME, KEY_NAME, EDIT_NAME, CONDITION_COLUMN, CONDITION_NAME, STATUS_COLUMN, PROJECT_ID_COLUMN, AUDITINGORNOT, RECRIGHTORNOT, RECTYPEORNOT, AUTOCODEORNOT, REMARKORNOT, RECRELATIONORNOT, COMORNOT, ADDABLEORNOT, TASKRELATIONORNOT, ATTACHORNOT, USEORNOT, CODE, NAME, EDIT_TIME)
values (1410, 14, '用电支付月度汇总', 'PAY_Electric_gather', 'uniqueId', 'bookerId', 'apply_money', '申请金额', 'state', '', 1, 0, 1, 1, 0, 0, 0, 0, 0, 0, 1, 'code', 'name', 'bookDate');

insert into TRANSFER_ITEMS (RECORD_ID, TRAN_ITEM_NAME, TRAN_ITEM_ID, ID_COLUMN, NAME_COLUMN, DATE_COLUMN, STATUS_COLUMN)
values (1410, '审核', 2, 'Auditorid', 'Auditor', 'Auditingdate', 'Auditingstatus');

insert into TRANSFER_ITEMS (RECORD_ID, TRAN_ITEM_NAME, TRAN_ITEM_ID, ID_COLUMN, NAME_COLUMN, DATE_COLUMN, STATUS_COLUMN)
values (1410, '批准', 3, 'Authorizepersonid', 'Authorizeperson', 'Authorizedate', 'authorizestatus');

insert into doc_type (DOC_TYPE_SID, DOC_TYPE_NAME, REC_TYPE_SID, SYSTEM_MODULE_SID, DOC_TYPE_ID, PARENT_ID, HASCHILD, TREELEVEL, DISPLAYID, DISCOLOR, OBSID, REC_VS_DOCTYPESID, USEORNOT, FOLDER_SID, REC_CLASS_SID)
values (1410, '用电支付月度汇总记录', 1410, 14, '1410', 0, 0.0000, 1.0000, 1410, 2.0000, null, null, 1, null, null);

insert into Rec_Right (REC_SID, CODE, NAME, REC_TYPE_SID, SYSTEM_MODULE_SID, PARENT_ID, HASCHILD, TREELEVEL, DISPLAYID, DISCOLOR, OBS_SID, USEORNOT)
values (1410, '', '用电支付月度汇总记录', 1410, 14, 0, 0.0000, 1.0000, 3, 2.0000, 1, 1);

insert into AUTO_CODE (SID, CODE, NAME, SELECTEDORNOT, REC_TYPE, DESCRIPTION)
values (1410, '1410', '用电支付月度汇总记录默认规则', 1, 1410.0000, '194');


select * from Rec_Right where REC_SID = 1410
delete from Rec_Right where REC_SID = 1410

select * from RECORD_TRANSFER where record_id=1410 or record_id=1409
select * from TRANSFER_ITEMS where record_id=1410 or record_id=1409
select * from doc_type where doc_type_sid=1410 or doc_type_sid=1409
update doc_type set program_id=194 where doc_type_sid=1410




