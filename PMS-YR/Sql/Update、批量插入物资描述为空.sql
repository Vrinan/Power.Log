update XLX_PUR_Request_List set model = (select b.matlongname from XLX_MDM_MAT_Middle b where b.MatCode = XLX_PUR_Request_List.MatCode) 
where XLX_PUR_Request_List.MatCode in (select XLX_MDM_MAT_Middle.MatCode from XLX_MDM_MAT_Middle)


select replace(MatCode,' ','') from XLX_MDM_MAT_Middle where MatCode is not null
select * from XLX_MDM_MAT_Middle where matcode='1381004670657'

select fk from XLX_PUR_Request_List where model is null
select * from XLX_PUR_Request_List
select MatDescription from PS_PUR_BOM where MatCode='1601106060004'

select * from XLX_MDM_MAT_Middle where MatCode in(select MatCode from XLX_MDM_MAT_Middle group by id  having count(id) > 1) order by id desc
select MatCode from XLX_MDM_MAT_Middle group by MatCode  having count(id) > 1

update PS_CM_SubContract_MatItem set PS_CM_SubContract_MatItem.MatModel = 
(select XLX_MDM_MAT_Middle.matlongname from XLX_MDM_MAT_Middle where a.matcode = b.matcode)