--�������ñ�
insert into RECORD_TRANSFER (RECORD_ID, SYSTEM_MODULE_SID, RECORD_NAME, TABLE_NAME, KEY_NAME, EDIT_NAME, CONDITION_COLUMN, CONDITION_NAME, STATUS_COLUMN, PROJECT_ID_COLUMN, AUDITINGORNOT, RECRIGHTORNOT, RECTYPEORNOT, AUTOCODEORNOT, REMARKORNOT, RECRELATIONORNOT, COMORNOT, ADDABLEORNOT, TASKRELATIONORNOT, ATTACHORNOT, USEORNOT, CODE, NAME, EDIT_TIME)
values (1410, 14, '�õ�֧���¶Ȼ���', 'PAY_Electric_gather', 'uniqueId', 'bookerId', 'apply_money', '������', 'state', '', 1, 0, 1, 1, 0, 0, 0, 0, 0, 0, 1, 'code', 'name', 'bookDate');

insert into TRANSFER_ITEMS (RECORD_ID, TRAN_ITEM_NAME, TRAN_ITEM_ID, ID_COLUMN, NAME_COLUMN, DATE_COLUMN, STATUS_COLUMN)
values (1410, '���', 2, 'Auditorid', 'Auditor', 'Auditingdate', 'Auditingstatus');

insert into TRANSFER_ITEMS (RECORD_ID, TRAN_ITEM_NAME, TRAN_ITEM_ID, ID_COLUMN, NAME_COLUMN, DATE_COLUMN, STATUS_COLUMN)
values (1410, '��׼', 3, 'Authorizepersonid', 'Authorizeperson', 'Authorizedate', 'authorizestatus');

insert into doc_type (DOC_TYPE_SID, DOC_TYPE_NAME, REC_TYPE_SID, SYSTEM_MODULE_SID, DOC_TYPE_ID, PARENT_ID, HASCHILD, TREELEVEL, DISPLAYID, DISCOLOR, OBSID, REC_VS_DOCTYPESID, USEORNOT, FOLDER_SID, REC_CLASS_SID)
values (1410, '�õ�֧���¶Ȼ��ܼ�¼', 1410, 14, '1410', 0, 0.0000, 1.0000, 1410, 2.0000, null, null, 1, null, null);

insert into Rec_Right (REC_SID, CODE, NAME, REC_TYPE_SID, SYSTEM_MODULE_SID, PARENT_ID, HASCHILD, TREELEVEL, DISPLAYID, DISCOLOR, OBS_SID, USEORNOT)
values (1410, '', '�õ�֧���¶Ȼ��ܼ�¼', 1410, 14, 0, 0.0000, 1.0000, 3, 2.0000, 1, 1);

insert into AUTO_CODE (SID, CODE, NAME, SELECTEDORNOT, REC_TYPE, DESCRIPTION)
values (1410, '1410', '�õ�֧���¶Ȼ��ܼ�¼Ĭ�Ϲ���', 1, 1410.0000, '194');


select * from Rec_Right where REC_SID = 1410
delete from Rec_Right where REC_SID = 1410