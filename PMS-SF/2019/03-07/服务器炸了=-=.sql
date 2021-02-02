select * from PB_Widget where Id='9b4a7d76-984b-41fa-bace-9f9ed62f04e1'
--/PowerPlat/FormXml/zh-CN/SF_Complex/SF_ZH_SockNotice.htm

--alter table SF_ZH_SockNotice add OnePerson nvarchar(500) null

select * from SF_CG_PurchasePlanListAdjust where Code='JHD(永川水处理)19041-10'
select * from SF_CG_PurchasePlanListAdjust where Code='JHD(永川水处理)19041-11'


update SF_CG_PurchasePlanListAdjust set IsOld=0 where Code='JHD(永川水处理)19041-10'
update SF_CG_PurchasePlanListAdjust set IsOld=0 where Code='JHD(永川水处理)19041-11'
update SF_CG_PurchasePlanListAdjust set MatStatus='4' where Code='JHD(永川水处理)19041-10'
update SF_CG_PurchasePlanListAdjust set MatStatus='4' where Code='JHD(永川水处理)19041-11'



Select a.Id,a.Code,a.Title,a.LaborContractId,a.HumanId,a.LaborContractType,a.LaborLawNum,a.SockDate,a.ContractEndDate,a.ContractStartDate,a.Several_1,a.Several_2,a.WorkTerm,a.ContractStartDate1,a.ContractStartDate2,a.ContractStartDate3,a.ContractEndDate1,a.ContractEndDate2,a.ContractEndDate3,a.SF_ZH_SockNotice,b.TableName,b.BizAreaId,b.Sequ,b.Status,b.RegHumId,b.RegHumName,b.RegDate,b.RegPosiId,b.RegDeptId,b.EpsProjId,b.RecycleHumId,b.UpdHumId,b.UpdHumName,b.UpdDate,b.ApprHumId,b.ApprHumName,b.ApprDate,b.Memo,b.OwnProjId,b.OwnProjName From SF_ZH_SockNotice a join PB_DefaultField b on a.Id=b.DefaultFieldId Where a.Id='2979dc29-012b-4f5f-a130-18014997c363'


select a.Code,b.Name,a.OnePerson,
       ISNULL(DateName(year,a.ContractStartDate),'/')+' 年 '+ISNULL(DateName(MONTH,a.ContractStartDate),'/')+' 月 '+ISNULL(DateName(DAY,a.ContractStartDate),'/')+' 日 ' as ContractStartDate,
	   a.Several_1,
	   ISNULL(DateName(year,a.ContractStartDate1),'/')+' 年 '+ISNULL(DateName(MONTH,a.ContractStartDate1),'/')+' 月 '+ISNULL(DateName(DAY,a.ContractStartDate1),'/')+' 日 ' as ContractStartDate1,
	   ISNULL(DateName(year,a.ContractEndDate1),'/')+' 年 '+ISNULL(DateName(MONTH,a.ContractEndDate1),'/')+' 月 '+ISNULL(DateName(DAY,a.ContractEndDate1),'/')+' 日 ' as ContractEndDate1,
	   ISNULL(DateName(year,a.ContractStartDate2),'/')+' 年 '+ISNULL(DateName(MONTH,a.ContractStartDate2),'/')+' 月 '+ISNULL(DateName(DAY,a.ContractStartDate2),'/')+' 日 ' as ContractStartDate2,
	   ISNULL(DateName(year,a.ContractEndDate2),'/')+' 年 '+ISNULL(DateName(MONTH,a.ContractEndDate2),'/')+' 月 '+ISNULL(DateName(DAY,a.ContractEndDate2),'/')+' 日 ' as ContractEndDate2,
       ISNULL(a.WorkTerm,'/') as WorkTerm,a.Several_2,
	   ISNULL(DateName(year,a.ContractStartDate3),'/')+' 年 '+ISNULL(DateName(MONTH,a.ContractStartDate3),'/')+' 月 '+ISNULL(DateName(DAY,a.ContractStartDate3),'/')+' 日 ' as ContractStartDate3,
	   ISNULL(DateName(year,a.ContractEndDate3),'/')+' 年 '+ISNULL(DateName(MONTH,a.ContractEndDate3),'/')+' 月 '+ISNULL(DateName(DAY,a.ContractEndDate3),'/')+' 日 ' as ContractEndDate3
from SF_ZH_SockNotice a left join PB_Human b on a.HumanId = b.Id
where a.Id = '[@KeyValue]'


 select RenewalTerms,id,convert(nvarchar(100),oneStartDate,23) as oneStartDate,convert(nvarchar(100),oneEndDte,23) as oneEndDte,convert(nvarchar(100),twoStartDate,23) as twoStartDate,convert(nvarchar(100),twoEenDate,23) as twoEenDate,three,convert(nvarchar(100),LaborStartDate,23) as LaborStartDate,RenewalTerm,convert(nvarchar(100),RenewalBeginDate,23) as RenewalBeginDate,convert(nvarchar(100),RenewalEndDate,23) as RenewalEndDate from SF_LaborRenewalApply 
 where id='[@KeyValue]' 


 select * from PB_DocFiles where FolderId='84cbd300-40c0-4b5c-beee-a6b8b6cf987d'

 select * from PB_DocFileLog where FileId='BFCFA9AE-8F77-05D4-1169-6EF5182D9B4F' and Operate='UploadFile'

select * from PB_DefaultField where DefaultFieldId='BFCFA9AE-8F77-05D4-1169-6EF5182D9B4F'

--update PB_DefaultField set RegDate='2018-07-06 11:42:10.000' where DefaultFieldId='767F8561-385D-53EE-337C-D74A572C1B94'

select a.KeyValue,b.WorkInfoID, b.SequeID ,b.ActName, b.UserName,Convert(nvarchar(50),b.SendDate,23) as SendDate, s.Picture,
       case when (c.Content is null or c.Content='') then '同意' else c.Content end as Content, 
       d.PosiName,d.DeptName 
from pwf_infos a 
right join pwf_pastNodes b on a.WorkInfoID=b.WorkInfoID 
left join PB_HumanSign s on b.UserID = s.HumanId
left join pwf_Opinion c on a.WorkInfoID=c.WorkInfoID and b.SequeID=c.SequeID 
left join (select dept.Name as DeptName,posi.Id as PosiId,posi.Name as PosiName from PB_Position posi 
left join PB_Department dept on posi.DeptId=dept.Id) d 
on case when b.DeptPositionID ='' then '00000000-0000-0000-0000-000000000000' when b.DeptPositionID is null then '00000000-0000-0000-0000-000000000000' else b.DeptPositionID end =d.PosiId
where KeyValue='84cbd300-40c0-4b5c-beee-a6b8b6cf987d' order by SequeID


select ROW_NUMBER() OVER(ORDER BY Sequ ASC) as rowNo,dbo.GetBaseData('PackageType',MatType) as MatType,MatName,MatSpec,
MatUnit,InStoreNum, convert(varchar,convert(money,UnitPriceNoTax),1) as UnitPrice,convert(varchar,convert(money,InStoreAmountNoTax),1)  as InStoreAmount
from PS_PUR_MatInStore_Dtl 
where MasterId='[@KeyValue]'  and MatType = '5'

select case when dbo.fn_getformatmoney(sum(InStoreAmountNoTax)) = '(负)' then null else dbo.fn_getformatmoney(sum(InStoreAmountNoTax)) end as TotalAmountF,
convert(varchar,convert(money,sum(InStoreAmountNoTax)),1) as TotalAmount from PS_PUR_MatInStore_Dtl 
where MasterId='[@KeyValue]'  and MatType = '5'






select ROW_NUMBER() OVER(ORDER BY Sequ ASC) as rowNo,dbo.GetBaseData('PackageType',b.MatType) as MatType,a.MatName,a.MatDescription,
a.MatUnit,a.ActualNum, convert(varchar,convert(money,b.UnitPriceNoTax),1) as UnitPrice,convert(varchar,convert(money,a.ActualNum*b.UnitPriceNoTax),1)  as InStoreAmount
from PS_PUR_MatRequisitions_Dtl a left join PS_PUR_MatInStore_Dtl b on a.ArrivalMat_Guid = b.ArrivalMat_Guid
where a.MasterId='[@KeyValue]' and MatType='5'


select case when dbo.fn_getformatmoney(sum(b.InStoreAmountNoTax)) = '(负)' then null else dbo.fn_getformatmoney(sum(b.InStoreAmountNoTax)) end as TotalAmountF,
convert(varchar,convert(money,sum(b.InStoreAmountNoTax)),1) as TotalAmount 
from PS_PUR_MatRequisitions_Dtl a left join PS_PUR_MatInStore_Dtl b on a.ArrivalMat_Guid = b.ArrivalMat_Guid
where a.MasterId='[@KeyValue]' and MatType='5'


select MatType,Sequ,MatName,Spec,Unit, 
       convert(nvarchar,cast(UnitPrice as money),1) UnitPrice, 
	   convert(nvarchar,cast(StoreNum as money),1) StoreNum, 
	   convert(nvarchar,cast(StoreAmount as money),1) StoreAmount, 
       convert(nvarchar,cast(oldStoreNum as money),1) oldStoreNum, 
	   convert(nvarchar,cast(oldStoreAmount as money),1) oldStoreAmount, 
	   convert(nvarchar,cast(outStoreNum as money),1) outStoreNum, 
	   convert(nvarchar,cast(outStoreAmount as money),1) outStoreAmount, 
	   convert(nvarchar,cast(ActualNum as money),1) ActualNum, 
	   convert(nvarchar,cast(ActualAmount as money),1) ActualAmount 
from PS_PUR_MatInventory_Dtl where MasterId='[@KeyValue]' and  MatType='备品备件' 
order by Sequ 