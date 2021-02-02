select * from PS_BID_Inquiry where id='bcd7e9a8-ead5-4eab-90b4-ccfeecc4bdf4'
select * from PS_BID_Inquiry_MatList where MasterId ='bcd7e9a8-ead5-4eab-90b4-ccfeecc4bdf4'

update PS_BID_Inquiry_MatList set requestcode ='123'  where MasterId ='bcd7e9a8-ead5-4eab-90b4-ccfeecc4bdf4' 
update PS_BID_Inquiry_MatList set Request_Id ='bcd7e9a8-ead5-4eab-90b4-ccfeecc4bdf4'  where MasterId ='bcd7e9a8-ead5-4eab-90b4-ccfeecc4bdf4' 

select * from XLX_PUR_Inquiry_MatList

alter table XLX_PUR_Inquiry_MatList add sequ int null


select * from pb_widget where id='4b140dee-6936-46e8-bfc0-d37bc9478c69'

select * from XLX_PUR_Inquiry where id='c8ce0191-6761-4780-88e7-0fd058a0e0b6'
select * from XLX_PUR_Inquiry_SupplieList where fk = 'c8ce0191-6761-4780-88e7-0fd058a0e0b6'
select sequ,* from XLX_PUR_Inquiry_MatList where sequ is not null

select Sequ,* from XLX_PUR_Request_List where Sequ <> 0

sp_helptext View_XLX_PUR_InquirySupplie