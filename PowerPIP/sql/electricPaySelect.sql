update DATAGRID_record set jsContent = 'function datagrid_import_row()//���Ӽ�¼����'+char(13)+'{   '+char(13)+'    var treeid=document.forms[0].sid.value;'+char(13)+'    var program_id=document.forms[0].program_id.value;'+char(13)+'    add_payment_nopact(treeid,program_id);'+char(13)+'}'+char(13)+''+char(13)+'function datagrid_delete_row()//ɾ����¼����'+char(13)+'{'+char(13)+''+char(9)+'var o = objGrid.getSelectedRow();'+char(13)+'          if(!confirm("���ȷ��Ҫɾ��������¼��")) return false;'+char(13)+'         var url=_app_url + "locale/contract_manage/payment_NoPact/action.asp?act=del&RecordId="+o.uid;'+char(13)+''+char(9)+'document.frames["action"].location=url;'+char(13)+'}'+char(13)+''+char(13)+'objGrid.onRowClick = function(o)//�����¼�����'+char(13)+'{'+char(13)+'}'+char(13)+''+char(13)+''+char(13)+'objGrid.onRowDblClick = function(o)//˫���¼�����'+char(13)+'{'+char(13)+'   show_detail_nopact(o.uid,"1",o.program_id);'+char(13)+'}' where sid=14033

update DATAGRID_view_config set [name]='�õ�֧��������ͼ' where DataGrid_record_sid=14033

update DATAGRID_view_config set ConfigContent = 'qid����Ŧ�40��1��normal��0��0��center��0��normal��0��1��state��״̬��60��1��normal��1��1��center��0��normal��1��1��code�����릤80��1��normal��2��2��center��0��normal��1��1��name�����Ʀ�220��1��normal��3��3��left��0��normal��1��1��apply_Money�������80��1��normal��4��4��center��0��normal��0��1��adder_name�������˦�80��1��normal��5��5��left��0��normal��0��1��add_Date���������ڦ�80��1��normal��6��6��center��0��datetime��1��1��electricType���õ���ত80��1��normal��7��7��left��0��normal��0��1��' where DataGRID_record_sid=14033

delete datagrid_record where sid = 14033
delete datagrid_view_config where datagrid_record_sid = 14033
--datagrid_record ����
insert into datagrid_record values('14033','14','ʩ��-�õ�֧��','','�õ�֧��', 1 ,'locale/contract_manage/payment_Electric/action.asp?act=loadXML','', 1 ,'1','function datagrid_import_row()//���Ӽ�¼����'+char(13)+'{   '+char(13)+'    var treeid=document.forms[0].sid.value;'+char(13)+'    var program_id=document.forms[0].program_id.value;'+char(13)+'    add_payment_nopact(treeid,program_id);'+char(13)+'}'+char(13)+''+char(13)+'function datagrid_delete_row()//ɾ����¼����'+char(13)+'{'+char(13)+'	var o = objGrid.getSelectedRow();'+char(13)+'          if(!confirm("���ȷ��Ҫɾ��������¼��")) return false;'+char(13)+'         var url=_app_url + "locale/contract_manage/payment_Electric/action.asp?act=del&RecordId="+o.uid;'+char(13)+'	document.frames["action"].location=url;'+char(13)+'}'+char(13)+''+char(13)+'objGrid.onRowClick = function(o)//�����¼�����'+char(13)+'{'+char(13)+'}'+char(13)+''+char(13)+''+char(13)+'objGrid.onRowDblClick = function(o)//˫���¼�����'+char(13)+'{'+char(13)+'   show_detail_nopact(o.uid,"1",o.program_id);'+char(13)+'}','0|1|2|0|3|4|5|0|6|7|9|10,1','0')
--DATAGRID_view_config ����
insert into datagrid_view_config( name,PublicOrNot,ConfigContent,DATAGRID_record_sid,user_sid,pagesize ) values( '�õ�֧������Ĭ����ͼ','1','qid����Ŧ�40��1��normal��0��0��center��0��normal��0��1��state��״̬��60��1��normal��1��1��center��0��normal��1��1��code�����릤80��1��normal��2��2��center��0��normal��1��1��name�����Ʀ�220��1��normal��3��3��left��0��normal��1��1��apply_Money�������80��1��normal��4��4��center��0��normal��0��1��adder_name�������˦�80��1��normal��5��5��left��0��normal��0��1��add_Date���������ڦ�80��1��normal��6��6��center��0��datetime��1��1��electricType���õ���ত80��1��normal��7��7��left��0��normal��1��1��','14033','-1','15')

update DATAGRID_record set jsContent = 'function datagrid_import_row()//���Ӽ�¼����'+char(13)+'{   '+char(13)+'    var treeid=document.forms[0].sid.value;'+char(13)+'    var program_id=document.forms[0].program_id.value;'+char(13)+'    add_payment_Electric(treeid,program_id);'+char(13)+'}'+char(13)+''+char(13)+'function datagrid_delete_row()//ɾ����¼����'+char(13)+'{'+char(13)+''+char(9)+'var o = objGrid.getSelectedRow();'+char(13)+'          if(!confirm("���ȷ��Ҫɾ��������¼��")) return false;'+char(13)+'         var url=_app_url + "locale/contract_manage/payment_Electric/action.asp?act=del&RecordId="+o.uid;'+char(13)+''+char(9)+'document.frames["action"].location=url;'+char(13)+'}'+char(13)+''+char(13)+'objGrid.onRowClick = function(o)//�����¼�����'+char(13)+'{'+char(13)+'}'+char(13)+''+char(13)+''+char(13)+'objGrid.onRowDblClick = function(o)//˫���¼�����'+char(13)+'{'+char(13)+'   show_detail_Electric(o.uid,"1",o.program_id);'+char(13)+'}' where sid=14033
--Action.asp
--1��14027��14033
--2��Payment_NoPact��Payment_Electric
--3��Payment_NoPact_Content��Payment_Electric_CONTENT
--4���޺�ͬ���õ�
--5��rec_type=�½���ID��1421��

select * from Payment_NoPact
select * from Payment_NoPact_CONTENT

select * from Payment_Electric
select * from Payment_Electric_CONTENT

select * from DATAGRID_record where sid=14033
select * from DATAGRID_view_config where DATAGRID_record_sid = 14033

select * from doc_type
select * from PACT_CHANGE_EI_EXP

select * from PAY_WBS_PI_PLAN
select * from PAY_Exp_plan
select * from PLN_PROJWBS
select * from PAY_EXP_share
select * from PAY_EXP_Detail

