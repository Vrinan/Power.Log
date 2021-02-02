select * from SF_SubContract_AmountList


select    a.FinalApplyAmount,b.SubContractCode,b.SubContractName, 
       c.Name as PartyBName,c.BankName as PartyBBank,c.BankAccount as PartyBBankCode, 
	   a.*, 
	   dbo.fn_getformatmoney(FinalApplyAmount) as FinalApplyAmount1,
	   --REPLACE(CONVERT(VARCHAR(20),CAST(FinalApplyAmount AS MONEY),1),'.00','') as  FinalApplyAmount2, 
	   Convert(decimal(18,2),a.FinalApplyAmount) as FinalApplyAmount2,
	   convert(varchar(10),a.RegDate,120) as RegDate1,
	   d.Name as PayType1 
from PS_CM_SubContractApplyMny a 
left join PS_CM_SubContract b on a.SubContract_Guid=b.Id  
left join PB_Organize c on b.PartyB_Guid=c.Id 
left join (select Code,Name from PB_BaseDataList where BaseDataId=(select Id from PB_BaseData where DataType='PS_PayType')) d on a.PayType=d.Code 
where a.Id='[@KeyValue]'


select CONVERT(money,FinalSubContractAmount) as FinalSubContractAmount,* from PS_CM_SubContract

select   b.EPSProjectName,a.FinalApplyAmount,b.SubContractCode,b.SubContractName, 
       c.Name as PartyBName,c.BankName as PartyBBank,c.BankAccount as PartyBBankCode, 
	   a.*, 
	   dbo.fn_getformatmoney(FinalApplyAmount) as FinalApplyAmount1,
	   --REPLACE(CONVERT(VARCHAR(20),CAST(FinalApplyAmount AS MONEY),1),'.00','') as  FinalApplyAmount2, 
	   Convert(decimal(18,2),a.FinalApplyAmount) as FinalApplyAmount2,
	   convert(varchar(10),a.RegDate,120) as RegDate1,
	   d.Name as PayType1 
from PS_CM_SubContractApplyMny a 
left join PS_CM_SubContract b on a.SubContract_Guid=b.Id  
left join PB_Organize c on b.PartyB_Guid=c.Id 
left join (select Code,Name from PB_BaseDataList where BaseDataId=(select Id from PB_BaseData where DataType='PS_PayType')) d on a.PayType=d.Code 


		  EPSProjectName

select Picture,* from PB_HumanSign

--财务部门分管dt4
select a.KeyValue,b.WorkInfoID, b.SequeID ,b.ActName,b.UserName,e.Picture,Convert(nvarchar(50),b.SendDate,23) as SendDate, 
       case when (c.Content is null or c.Content='') then '同意' else c.Content end as Content, 
       d.PosiName,d.DeptName 
from pwf_infos a 
right join pwf_pastNodes b on a.WorkInfoID=b.WorkInfoID 
left join PB_HumanSign e on b.UserID = e.HumanId
left join pwf_Opinion c on a.WorkInfoID=c.WorkInfoID and b.SequeID=c.SequeID 
left join (select dept.Name as DeptName,posi.Id as PosiId,posi.Name as PosiName from PB_Position posi 
left join PB_Department dept on posi.DeptId=dept.Id) d 
on case when b.DeptPositionID ='' then '00000000-0000-0000-0000-000000000000' when b.DeptPositionID is null then '00000000-0000-0000-0000-000000000000' else b.DeptPositionID end =d.PosiId
where KeyValue = '[@KeyValue]' and PosiName ='副总经理（周）' and ActName='申请部门和财务分管'


--其他部门分管dt5
select a.KeyValue,b.WorkInfoID, b.SequeID ,b.ActName,b.UserName,e.Picture,Convert(nvarchar(50),b.SendDate,23) as SendDate, 
       case when (c.Content is null or c.Content='') then '同意' else c.Content end as Content, 
       d.PosiName,d.DeptName 
from pwf_infos a 
right join pwf_pastNodes b on a.WorkInfoID=b.WorkInfoID 
left join PB_HumanSign e on b.UserID = e.HumanId
left join pwf_Opinion c on a.WorkInfoID=c.WorkInfoID and b.SequeID=c.SequeID 
left join (select dept.Name as DeptName,posi.Id as PosiId,posi.Name as PosiName from PB_Position posi 
left join PB_Department dept on posi.DeptId=dept.Id) d 
on case when b.DeptPositionID ='' then '00000000-0000-0000-0000-000000000000' when b.DeptPositionID is null then '00000000-0000-0000-0000-000000000000' else b.DeptPositionID end =d.PosiId
where KeyValue = '[@KeyValue]' and PosiName !='副总经理（周）' and ActName='申请部门和财务分管'




select * from PB_Widget where id='696ec71e-d26a-46d4-9ed2-6d6de2c4f9ff'