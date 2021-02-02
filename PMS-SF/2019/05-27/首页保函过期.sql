--ExpirationTime
create view View_SF_ExpirationTime
as
select DATEADD(M,-1,ExpirationTime) as ShouldRemind,* from SF_FK_MarginSubcontractorApply 
where IsReturn=0 and ExpirationTime is not null and DATEADD(M,-1,ExpirationTime)<GETDATE()

--onDrawCellExpirationTime
--View_SF_ExpirationTime
--GetExpirationTime

select * from PB_Widget where Id='a894cc31-b9d3-40b3-a76d-f39cb2bea59f'
--/PowerPlat/FormXml/zh-CN/Systems/WidgetMyNotifyInfo.htm

select * from PB_Widget where Id='21e23a33-9393-4a6d-b4c1-b8f67ab00b42'
--/PowerPlat/FormXml/zh-CN/SF_FK/Win_SF_FK_MarginSubcontractorApply.htm