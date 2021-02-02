select * from SF_YX_RunProduction
select CONVERT(varchar(100), date, 23) from SF_YX_RunProduction
alter table SF_YX_RunProduction add Datebak nvarchar(100) null
update SF_YX_RunProduction set Datebak =  CONVERT(varchar(100), date, 23)
alter table SF_YX_RunProduction drop column date
alter table SF_YX_RunProduction add Date nvarchar(100) null
update SF_YX_RunProduction set Date = Datebak


select * from SF_YX_RunTechnology
alter table SF_YX_RunTechnology add Datebak nvarchar(100) null
update SF_YX_RunTechnology set Datebak =  CONVERT(varchar(100), date, 23)
alter table SF_YX_RunTechnology drop column date
alter table SF_YX_RunTechnology add Date nvarchar(100) null
update SF_YX_RunTechnology set Date = Datebak


select * from SF_YX_RunMedicine
alter table SF_YX_RunMedicine add Datebak nvarchar(100) null
update SF_YX_RunMedicine set Datebak =  CONVERT(varchar(100), date, 23)
alter table SF_YX_RunMedicine drop column date
alter table SF_YX_RunMedicine add Date nvarchar(100) null
update SF_YX_RunMedicine set Date = Datebak



select * from SF_YX_RunFlyingDust
alter table SF_YX_RunFlyingDust add Datebak nvarchar(100) null
update SF_YX_RunFlyingDust set Datebak =  CONVERT(varchar(100), date, 23)
alter table SF_YX_RunFlyingDust drop column date
alter table SF_YX_RunFlyingDust add Date nvarchar(100) null
update SF_YX_RunFlyingDust set Date = Datebak