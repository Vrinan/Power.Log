select * from PS_PUR_ArrivalCheck where id='d138ebb8-58e5-4bec-868f-5d8143f5345a'
select * from pb_widget where id='b1dbbe05-1300-4f20-9057-7b318f5af220'
select ArrivalNum,IsChange,* from PS_CM_SubContract_MatItem
update PS_PUR_ArrivalCheck set Status =35 where id='d138ebb8-58e5-4bec-868f-5d8143f5345a'

select IsChange,* from ps_cm_subcontract_matitem where MasterId ='908e97c2-91a3-4f55-a648-641f3372ddb8'

select * from ps_cm_subcontract_matitem where MasterId='908e97c2-91a3-4f55-a648-641f3372ddb8' or MasterId in (select q.id from PS_cm_SubContract q where q.AddSubContractId = '908e97c2-91a3-4f55-a648-641f3372ddb8')
