create function [dbo].GetUsedAmount
(
	@id nvarchar(500),
	@year nvarchar(100)
)
returns @re table
(
	TrafficUsed numeric(18,2),CommunicationUsed numeric(18,2)
)
 as      
 begin           
     
insert into @re 
	select isnull(sum(c.ApproveTrafficAmount),0),isnull(sum(c.ApproveComAmount),0) from
	(
	select a.Code,year(a.AddYearMonth) as year,b.* from SF_FK_CommunicateReimburse a left join SF_FK_CommunicateReimburse_dtl b on a.Id = b.MasterId 
	where a.status =50 and b.HumanId ='531D0B65-2ED1-4925-9099-C8DA5613CB68' and year(a.AddYearMonth)='2019'
	) c
  return
 end 

 --531D0B65-2ED1-4925-9099-C8DA5613CB68





