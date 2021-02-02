--14034grid
select * from datagrid_record where sid=14034
select * from doc_type where rec_type_sid =1409
delete from doc_type where dd=6 or dd=7 or dd=8

delete datagrid_record where sid = 14034
delete datagrid_view_config where datagrid_record_sid = 14034
--datagrid_record 数据
insert into datagrid_record values('14034','14','用电支付月度汇总','','用电支付月度汇总', 1 ,'locale/contract_exe/Electric_Gather/action.asp?act=showxml','', 1 ,'1','function datagrid_import_row()//增加记录函数'+char(13)+'{'+char(13)+'   var treeid=document.forms[0].sid.value;'+char(13)+'   var program_id=document.forms[0].program_id.value;'+char(13)+'         var url=_app_url + "locale/contract_exe/Electric_Gather/action.asp?act=add&sid="+treeid+"&program_id="+program_id;'+char(13)+'  '+char(13)+'    document.frames["action"].location=url;'+char(13)+'}'+char(13)+''+char(13)+'function datagrid_delete_row()//删除记录函数'+char(13)+'{'+char(13)+'if (confirm("确定删除此记录？")){'+char(13)+'	var o = objGrid.getSelectedRow();'+char(13)+''+char(13)+'	var hsid = o.uid;'+char(13)+'			document.frames["action"].location=_app_url + "locale/contract_exe/Electric_Gather/action.asp?act=del&sid="+hsid;'+char(13)+'	}'+char(13)+'}'+char(13)+''+char(13)+'objGrid.onRowClick = function(o)//单击事件函数'+char(13)+'{'+char(13)+''+char(13)+'}'+char(13)+''+char(13)+''+char(13)+'objGrid.onRowDblClick = function(o)//双击事件函数'+char(13)+'{'+char(13)+'show_detail_Electric_Gather(o.uid);'+char(13)+''+char(13)+'}'+char(13)+''+char(13)+'','0|1|2|0|3|4|5|6|7,1','')
--DATAGRID_view_config 数据
 insert into datagrid_view_config(name,PublicOrNot,ConfigContent,DATAGRID_record_sid,user_sid,pagesize) values ( '施工合同支付项列表','1','qidΔ序号Δ37Δ1ΔnormalΔ0Δ0ΔcenterΔ0ΔnormalΔ0Δ0ΘstateΔ状态Δ50Δ1ΔnormalΔ1Δ1ΔleftΔ0ΔnormalΔ0Δ0ΘcodeΔ编号Δ60Δ1ΔnormalΔ2Δ2ΔleftΔ0ΔnormalΔ0Δ0ΘnameΔ名称Δ280Δ1ΔnormalΔ3Δ3ΔleftΔ0ΔnormalΔ0Δ0ΘbookerΔ编制人Δ80Δ1ΔnormalΔ4Δ4ΔleftΔ0ΔnormalΔ0Δ0ΘbookDateΔ编制时间Δ80Δ1ΔnormalΔ5Δ5ΔleftΔ0ΔnormalΔ0Δ0Θ','14034','-1','15')
 select * from PACT_record
 select * from Payment_Electric where state = '已批准'
 select * from Payment_Electric_CONTENT
 select uniqueId,code,name,apply_money,state from Payment_Electric where state <> '已批准'
 select * from PAY_PLAN_BILL

 select isnull(sum(apply_money),0) from Payment_Electric
 select isnull(sum(apply_money),0) from Payment_Electric where state='已批准'

select project_id,project_shortname,project_name from pln_project where  project_id=(select top 1 proj_id from pln_projcont
select project_id,project_shortname,project_name from pln_project
select sum(apply_money),sum(payingfee) from PAY_CONTPAY_RECORD
select sum(apply_money) from Payment_Electric where  add_date<='2017-06-13 10:03:31'
select LastAuditPrice from PAY_SETTLE_RECORD
select sum(apply_money) from Payment_Electric where state='已批准'

select * from PAY_CONTPAY_RECORD
select * from PACT_record
select * from PAY_PLAN_BILL
select a.uniqueID,a.remark,a.apply_money, a.adder_name as Associator,a.adder_sid as com_id,a.add_date,b.uniqueId as pact_sid,b.Pay_NoPact_Id as stockContId, b.record_note as stockContName from Payment_Electric a left outer join Payment_Electric_CONTENT b on a.UniqueId = b.Pay_NoPact_Id

select project_id,project_shortname,project_name from pln_project where project_id=228
select  * from PAY_Electric_gather

select * from Payment_Electric where Convert(varchar,add_date,120) LIKE '2017-06%'
select * from  Payment_Electric where add_date < '2017-06-14 16:49:24'
select * from  Payment_Electric where state='已批准' and Convert(varchar,add_date,120) LIKE '2017-06%'
select sum(apply_money) from  Payment_Electric

SELECT * FROM PAY_Electric_gather



select top 1 Auto_code.*,r_t.key_name,r_t.code,r_t.table_name from Auto_code 
inner join RECORD_TRANSFER r_t on Auto_code.rec_type=r_t.record_id  
where Auto_code.SelectedOrNot=1 and Auto_code.rec_type=1410 
and Auto_code.program_id=194

select * from　Auto_code　where　rec_type =1410

update Auto_code set program_id = 194
delete from auto_code where sid=1201402
 
insert into auto_code values(1410,1410,'用电支付月度汇总记录默认规则',1,1410,194,194)


select * from doc_type where doc_type_sid= 1410

select*from　Rec_Right where rec_sid = 1410

select * from RECORD_TRANSFER where record_id = 1410

select  * from record_transfer where record_id=1410

select  * from AUDITING_RECORD_DETAIL where rec_sid =1427
select  * from AUDITING_RECORD_DETAIL where rec_type_sid=14

insert into AUDITING_RECORD_DETAIL 
values(1427,14,2866)

delete from AUDITING_RECORD_DETAIL where sid=2865 or sid=2866
select * from record_transfer where record_id=1410 or record_id=1421

update RECORD_TRANSFER set project_id_column = 'payContUniqueId' where record_id=1421 or record_id=1410
