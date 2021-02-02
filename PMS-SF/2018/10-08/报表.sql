declare @begindate nvarchar(500)
declare @enddate nvarchar(500)
select @begindate=ContractSignBegin,@enddate=ContractSignEnd from SF_Hires where Id='4B937BDE-A08D-451A-9E95-5BC90A01473E'
select DATEDIFF(YY,@begindate,@enddate) as years

--alter table SF_Hires add WorkExp nvarchar(500) null
--alter table SF_Hires add WorkAbility nvarchar(500) null

select DATEDIFF(YYYY,ContractSignBegin,ContractSignEnd) AS years,* from SF_Hires


select * from PB_Widget where id='549c2b4e-2688-476a-adc0-1175e78e6a4d'
--/PowerPlat/FormXml/zh-CN/SF_Complex/SF_Hires.htm