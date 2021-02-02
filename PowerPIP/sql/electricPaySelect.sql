update DATAGRID_record set jsContent = 'function datagrid_import_row()//增加记录函数'+char(13)+'{   '+char(13)+'    var treeid=document.forms[0].sid.value;'+char(13)+'    var program_id=document.forms[0].program_id.value;'+char(13)+'    add_payment_nopact(treeid,program_id);'+char(13)+'}'+char(13)+''+char(13)+'function datagrid_delete_row()//删除记录函数'+char(13)+'{'+char(13)+''+char(9)+'var o = objGrid.getSelectedRow();'+char(13)+'          if(!confirm("真的确定要删除该条记录吗？")) return false;'+char(13)+'         var url=_app_url + "locale/contract_manage/payment_NoPact/action.asp?act=del&RecordId="+o.uid;'+char(13)+''+char(9)+'document.frames["action"].location=url;'+char(13)+'}'+char(13)+''+char(13)+'objGrid.onRowClick = function(o)//单击事件函数'+char(13)+'{'+char(13)+'}'+char(13)+''+char(13)+''+char(13)+'objGrid.onRowDblClick = function(o)//双击事件函数'+char(13)+'{'+char(13)+'   show_detail_nopact(o.uid,"1",o.program_id);'+char(13)+'}' where sid=14033

update DATAGRID_view_config set [name]='用电支付申请视图' where DataGrid_record_sid=14033

update DATAGRID_view_config set ConfigContent = 'qidΔ序号Δ40Δ1ΔnormalΔ0Δ0ΔcenterΔ0ΔnormalΔ0Δ1ΘstateΔ状态Δ60Δ1ΔnormalΔ1Δ1ΔcenterΔ0ΔnormalΔ1Δ1ΘcodeΔ代码Δ80Δ1ΔnormalΔ2Δ2ΔcenterΔ0ΔnormalΔ1Δ1ΘnameΔ名称Δ220Δ1ΔnormalΔ3Δ3ΔleftΔ0ΔnormalΔ1Δ1Θapply_MoneyΔ申请金额Δ80Δ1ΔnormalΔ4Δ4ΔcenterΔ0ΔnormalΔ0Δ1Θadder_nameΔ编制人Δ80Δ1ΔnormalΔ5Δ5ΔleftΔ0ΔnormalΔ0Δ1Θadd_DateΔ编制日期Δ80Δ1ΔnormalΔ6Δ6ΔcenterΔ0ΔdatetimeΔ1Δ1ΘelectricTypeΔ用电分类Δ80Δ1ΔnormalΔ7Δ7ΔleftΔ0ΔnormalΔ0Δ1Θ' where DataGRID_record_sid=14033

delete datagrid_record where sid = 14033
delete datagrid_view_config where datagrid_record_sid = 14033
--datagrid_record 数据
insert into datagrid_record values('14033','14','施工-用电支付','','用电支付', 1 ,'locale/contract_manage/payment_Electric/action.asp?act=loadXML','', 1 ,'1','function datagrid_import_row()//增加记录函数'+char(13)+'{   '+char(13)+'    var treeid=document.forms[0].sid.value;'+char(13)+'    var program_id=document.forms[0].program_id.value;'+char(13)+'    add_payment_nopact(treeid,program_id);'+char(13)+'}'+char(13)+''+char(13)+'function datagrid_delete_row()//删除记录函数'+char(13)+'{'+char(13)+'	var o = objGrid.getSelectedRow();'+char(13)+'          if(!confirm("真的确定要删除该条记录吗？")) return false;'+char(13)+'         var url=_app_url + "locale/contract_manage/payment_Electric/action.asp?act=del&RecordId="+o.uid;'+char(13)+'	document.frames["action"].location=url;'+char(13)+'}'+char(13)+''+char(13)+'objGrid.onRowClick = function(o)//单击事件函数'+char(13)+'{'+char(13)+'}'+char(13)+''+char(13)+''+char(13)+'objGrid.onRowDblClick = function(o)//双击事件函数'+char(13)+'{'+char(13)+'   show_detail_nopact(o.uid,"1",o.program_id);'+char(13)+'}','0|1|2|0|3|4|5|0|6|7|9|10,1','0')
--DATAGRID_view_config 数据
insert into datagrid_view_config( name,PublicOrNot,ConfigContent,DATAGRID_record_sid,user_sid,pagesize ) values( '用电支付申请默认视图','1','qidΔ序号Δ40Δ1ΔnormalΔ0Δ0ΔcenterΔ0ΔnormalΔ0Δ1ΘstateΔ状态Δ60Δ1ΔnormalΔ1Δ1ΔcenterΔ0ΔnormalΔ1Δ1ΘcodeΔ代码Δ80Δ1ΔnormalΔ2Δ2ΔcenterΔ0ΔnormalΔ1Δ1ΘnameΔ名称Δ220Δ1ΔnormalΔ3Δ3ΔleftΔ0ΔnormalΔ1Δ1Θapply_MoneyΔ申请金额Δ80Δ1ΔnormalΔ4Δ4ΔcenterΔ0ΔnormalΔ0Δ1Θadder_nameΔ编制人Δ80Δ1ΔnormalΔ5Δ5ΔleftΔ0ΔnormalΔ0Δ1Θadd_DateΔ编制日期Δ80Δ1ΔnormalΔ6Δ6ΔcenterΔ0ΔdatetimeΔ1Δ1ΘelectricTypeΔ用电分类Δ80Δ1ΔnormalΔ7Δ7ΔleftΔ0ΔnormalΔ1Δ1Θ','14033','-1','15')

update DATAGRID_record set jsContent = 'function datagrid_import_row()//增加记录函数'+char(13)+'{   '+char(13)+'    var treeid=document.forms[0].sid.value;'+char(13)+'    var program_id=document.forms[0].program_id.value;'+char(13)+'    add_payment_Electric(treeid,program_id);'+char(13)+'}'+char(13)+''+char(13)+'function datagrid_delete_row()//删除记录函数'+char(13)+'{'+char(13)+''+char(9)+'var o = objGrid.getSelectedRow();'+char(13)+'          if(!confirm("真的确定要删除该条记录吗？")) return false;'+char(13)+'         var url=_app_url + "locale/contract_manage/payment_Electric/action.asp?act=del&RecordId="+o.uid;'+char(13)+''+char(9)+'document.frames["action"].location=url;'+char(13)+'}'+char(13)+''+char(13)+'objGrid.onRowClick = function(o)//单击事件函数'+char(13)+'{'+char(13)+'}'+char(13)+''+char(13)+''+char(13)+'objGrid.onRowDblClick = function(o)//双击事件函数'+char(13)+'{'+char(13)+'   show_detail_Electric(o.uid,"1",o.program_id);'+char(13)+'}' where sid=14033
--Action.asp
--1、14027→14033
--2、Payment_NoPact→Payment_Electric
--3、Payment_NoPact_Content→Payment_Electric_CONTENT
--4、无合同→用电
--5、rec_type=新建的ID（1421）

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

