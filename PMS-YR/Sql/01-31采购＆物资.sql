select * from pb_widget where id='0172ef6c-e0e9-497a-bab6-1eb81a298f82'

--���ʼƻ�
select * from ps_pur_bomfile where id ='40207202-b286-4b07-a7cc-16ca18c1867f'
select * from ps_pur_bom where masterid='40207202-b286-4b07-a7cc-16ca18c1867f'
--�빺��
--����order_guidΪ���ʼƻ�Id
--��ϸ���BomIDΪ���ʼƻ���ϸId
select * from xlx_pur_request where id='ca39d54f-f5d3-4d58-9e26-ed41ee01023b'
select * from xlx_pur_request_list where fk='ca39d54f-f5d3-4d58-9e26-ed41ee01023b'
--�ɹ��ְ�
--���������û����
--inquiryMatList_IdΪ�빺����ϸId
select * from xlx_pur_order
select * from xlx_pur_order_list where inquiryMatList_Id in (
select id from xlx_pur_request_list where BomID in(
select id from ps_pur_bom where masterid='40207202-b286-4b07-a7cc-16ca18c1867f'))
--�ɹ�������
--�����вɹ��ְ������Id��name��code,��ͬ��Code
--��ϸ���빺����ϸid��requestlist_id���빺��Id��Code
select * from XLX_PUR_Inquiry
select * from XLX_PUR_Inquiry_matlist where requestlist_id in(select id from xlx_pur_request_list where BomID in(
select id from ps_pur_bom where masterid='40207202-b286-4b07-a7cc-16ca18c1867f'))
--���۷���
--�����вɹ��ְ���Id��Code
--�ӱ����빺��RequestCode��Request_Id���빺����ϸxlx_request_list_id
select * from PS_bid_Inquiry
select * from PS_bid_Inquiry_matlist where xlx_request_list_id in(
select id from xlx_pur_request_list where BomID in(
select id from ps_pur_bom where masterid='40207202-b286-4b07-a7cc-16ca18c1867f'))
--���۱���
--�����зְ�Id,Code,Name:Order_Guid,OrderCode,OrderName
--�ӱ��о��۷�����ϸ��Id:Inquiry_Matlistid,�빺����ϸ��Id��xlx_request_list_id,�빺��Code��Id��RequestCode��Request_Id
select * from XLX_PS_BID_Inquiry
select * from XLX_PS_BID_Inquiry_matlist
--��ͬ
--�����вɹ�������/���۳ɹ�֪ͨ��Id,Name,Code��Order_Guid,OrderName,OrderCode
--�ӱ���xlx_request_list_id
select * from ps_cm_subcontract
select * from ps_cm_subcontract_matitem
--�������
--����
--�ӱ�contractlistidΪ��ͬ��ϸId
select * from PS_PUR_ArrivalCheck
select * from PS_pur_ArrivalCheck_Dtl
--�������
--����
--�ӱ�Arrivalmat_guidΪ������ϸId
select * from PS_PUR_MatInStore
select Arrivalmat_guid,* from PS_PUR_MatInStore_dtl
--��������
--����
--�ӱ�Arrivalmat_guidΪ���ʼƻ���ϸId
select * from ps_pur_MatRequisitions
select * from ps_pur_MatRequisitions_dtl
--���ʳ���
--����
--�ӱ�requisition_guidΪ������ϸId
select * from PS_pur_MatOutStore
select requisition_guid,* from PS_pur_MatOutStore_dtl



