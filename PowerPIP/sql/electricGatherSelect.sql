--14034grid
select * from datagrid_record where sid=14034
select * from doc_type where rec_type_sid =1409
delete from doc_type where dd=6 or dd=7 or dd=8

delete datagrid_record where sid = 14034
delete datagrid_view_config where datagrid_record_sid = 14034
--datagrid_record ����
insert into datagrid_record values('14034','14','�õ�֧���¶Ȼ���','','�õ�֧���¶Ȼ���', 1 ,'locale/contract_exe/Electric_Gather/action.asp?act=showxml','', 1 ,'1','function datagrid_import_row()//���Ӽ�¼����'+char(13)+'{'+char(13)+'   var treeid=document.forms[0].sid.value;'+char(13)+'   var program_id=document.forms[0].program_id.value;'+char(13)+'         var url=_app_url + "locale/contract_exe/Electric_Gather/action.asp?act=add&sid="+treeid+"&program_id="+program_id;'+char(13)+'  '+char(13)+'    document.frames["action"].location=url;'+char(13)+'}'+char(13)+''+char(13)+'function datagrid_delete_row()//ɾ����¼����'+char(13)+'{'+char(13)+'if (confirm("ȷ��ɾ���˼�¼��")){'+char(13)+'	var o = objGrid.getSelectedRow();'+char(13)+''+char(13)+'	var hsid = o.uid;'+char(13)+'			document.frames["action"].location=_app_url + "locale/contract_exe/Electric_Gather/action.asp?act=del&sid="+hsid;'+char(13)+'	}'+char(13)+'}'+char(13)+''+char(13)+'objGrid.onRowClick = function(o)//�����¼�����'+char(13)+'{'+char(13)+''+char(13)+'}'+char(13)+''+char(13)+''+char(13)+'objGrid.onRowDblClick = function(o)//˫���¼�����'+char(13)+'{'+char(13)+'show_detail_Electric_Gather(o.uid);'+char(13)+''+char(13)+'}'+char(13)+''+char(13)+'','0|1|2|0|3|4|5|6|7,1','')
--DATAGRID_view_config ����
 insert into datagrid_view_config(name,PublicOrNot,ConfigContent,DATAGRID_record_sid,user_sid,pagesize) values ( 'ʩ����֧ͬ�����б�','1','qid����Ŧ�37��1��normal��0��0��center��0��normal��0��0��state��״̬��50��1��normal��1��1��left��0��normal��0��0��code����Ŧ�60��1��normal��2��2��left��0��normal��0��0��name�����Ʀ�280��1��normal��3��3��left��0��normal��0��0��booker�������˦�80��1��normal��4��4��left��0��normal��0��0��bookDate������ʱ�䦤80��1��normal��5��5��left��0��normal��0��0��','14034','-1','15')
 select * from PACT_record
 select * from Payment_Electric where state = '����׼'
 select * from Payment_Electric_CONTENT
 select uniqueId,code,name,apply_money,state from Payment_Electric where state <> '����׼'
 select * from PAY_PLAN_BILL

 select isnull(sum(apply_money),0) from Payment_Electric
 select isnull(sum(apply_money),0) from Payment_Electric where state='����׼'

select project_id,project_shortname,project_name from pln_project where  project_id=(select top 1 proj_id from pln_projcont
select project_id,project_shortname,project_name from pln_project
select sum(apply_money),sum(payingfee) from PAY_CONTPAY_RECORD
select sum(apply_money) from Payment_Electric where  add_date<='2017-06-13 10:03:31'
select LastAuditPrice from PAY_SETTLE_RECORD
select sum(apply_money) from Payment_Electric where state='����׼'

select * from PAY_CONTPAY_RECORD
select * from PACT_record
select * from PAY_PLAN_BILL
select a.uniqueID,a.remark,a.apply_money, a.adder_name as Associator,a.adder_sid as com_id,a.add_date,b.uniqueId as pact_sid,b.Pay_NoPact_Id as stockContId, b.record_note as stockContName from Payment_Electric a left outer join Payment_Electric_CONTENT b on a.UniqueId = b.Pay_NoPact_Id

select project_id,project_shortname,project_name from pln_project where project_id=228
select  * from PAY_Electric_gather

select * from Payment_Electric where Convert(varchar,add_date,120) LIKE '2017-06%'
select * from  Payment_Electric where add_date < '2017-06-14 16:49:24'
select * from  Payment_Electric where state='����׼' and Convert(varchar,add_date,120) LIKE '2017-06%'
select sum(apply_money) from  Payment_Electric

SELECT * FROM PAY_Electric_gather



select top 1 Auto_code.*,r_t.key_name,r_t.code,r_t.table_name from Auto_code 
inner join RECORD_TRANSFER r_t on Auto_code.rec_type=r_t.record_id  
where Auto_code.SelectedOrNot=1 and Auto_code.rec_type=1410 
and Auto_code.program_id=194

select * from��Auto_code��where��rec_type =1410

update Auto_code set program_id = 194
delete from auto_code where sid=1201402
 
insert into auto_code values(1410,1410,'�õ�֧���¶Ȼ��ܼ�¼Ĭ�Ϲ���',1,1410,194,194)


select * from doc_type where doc_type_sid= 1410

select*from��Rec_Right where rec_sid = 1410

select * from RECORD_TRANSFER where record_id = 1410

select  * from record_transfer where record_id=1410

select  * from AUDITING_RECORD_DETAIL where rec_sid =1427
select  * from AUDITING_RECORD_DETAIL where rec_type_sid=14

insert into AUDITING_RECORD_DETAIL 
values(1427,14,2866)

delete from AUDITING_RECORD_DETAIL where sid=2865 or sid=2866
select * from record_transfer where record_id=1410 or record_id=1421

update RECORD_TRANSFER set project_id_column = 'payContUniqueId' where record_id=1421 or record_id=1410
