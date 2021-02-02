select Id,ContractCode,RegHumName,pwf.SendDate,DATEDIFF(DAY,GETDATE(),pwf.SendDate) from PS_MK_ContractReview con
left join
(
	select aa.WorkInfoID,aa.KeyValue,bb.SendDate from pwf_infos aa inner join pwf_pastNodes bb on aa.WorkInfoID = bb.WorkInfoID
	where bb.SequeID=1
) pwf
on con.Id = pwf.KeyValue where con.Type=1 and con.Status != 40 and con.Status != 50

--and con,Status !=40  and pwf.SendDate is not null 


select status from PS_MK_ContractReview where id='718233a1-3344-4534-94e2-c351b818886b'