--»Îø‚¥Ú”°1
--'[@KeyValue]'
--dt1
select Code,StorageName,CONVERT(varchar(100),InStoreDate, 23) as InStoreDate from PS_PUR_MatInStore where Id='0162058c-9a6b-4171-b7ba-6a91626b8d4f'
--dt2
select ROW_NUMBER() OVER(ORDER BY Sequ ASC) as rowNo,dbo.GetBaseData('PackageType',MatType) as MatType,MatName,MatSpec,
MatUnit,InStoreNum, convert(varchar,convert(money,UnitPrice),1) as UnitPrice,convert(varchar,convert(money,InStoreAmount),1)  as InStoreAmount
from PS_PUR_MatInStore_Dtl 
where MasterId='0162058c-9a6b-4171-b7ba-6a91626b8d4f'
--dt3
select dbo.fn_getformatmoney(sum(InStoreAmount)) as TotalAmountF,convert(varchar,convert(money,sum(InStoreAmount)),1) as TotalAmount from PS_PUR_MatInStore_Dtl where MasterId='0162058c-9a6b-4171-b7ba-6a91626b8d4f'
--dt4
select Supplier,ContractName from PS_PUR_ArrivalCheck where Id=(select Arrival_Guid from PS_PUR_MatInStore where Id='0162058c-9a6b-4171-b7ba-6a91626b8d4f')



select * from PB_User where Code='0162'

select count(1) as RecordCount from View_WorkInfos where UserID='878eba8f-cce7-4472-a9b6-98312103f782'
Select Top 8 Id,KeyValue,KeyWord,DocumentCode, Title, wfDate,HtmlPath, EpsProjCode, EpsProjName,CreateUserName as UserName,CreateDeptPositionName, BeforeUserName as FromHumanName From View_WorkPastUsers Where UserID='878eba8f-cce7-4472-a9b6-98312103f782' Order By wfDate Desc
