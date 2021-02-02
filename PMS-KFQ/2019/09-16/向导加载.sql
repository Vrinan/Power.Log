select * from pb_widget where id='3f16d26f-7085-43bb-8262-0760c01e142d'
--\PowerPlat\FormXml\zh-CN\KFQ_HT\KFQ_HT_PAY_CHANGE_BILL.htm

select * from PB_Wizard where wizardid='5d2b0a66-e064-2c13-df49-6e3e89770b15'
--/PowerPlat/FormXml/zh-CN/KFQ_Wizard/Wizard_KFQ_PAY_BOQ.htm、

--old
--5d2b0a66-e064-2c13-df49-6e3e89770b15
---new
--83cd700c-65af-8230-3bc4-c3dbb07319c2

Select * From View_KFQ_ContractDetailedList

sp_helptext View_KFQ_ContractDetailedList

CREATE view [dbo].[View_KFQ_ContractDetailedList]    
as    
select m.Id Contract_Id,m.Id OriginId,x2.uniqueId,x2.guid,x2.parent_guid,x2.Pact_sid_kfq,x2.Code,x2.Name,x2.ms_name,x2.scale,x2.human_unit,x2.sequ,    
       x1.pifee,x1.PItoACTOrNot,x1.contCount,x1.unitSum,x1.Id KFQ_PI_Content_Id    
from KFQ_PACT_record m
left join KFQ_PAY_BOQ x2 on m.Id= x2.MasterId  
left join KFQ_PAY_STOCK_PI_CONTENT x1 on x2.guid = x1.BOQuniqueId_kfq  
and m.Id = x1.MasterId  
where m.Status in(35,50)
--变更项（老数据）
--Union
--select m.Id Contract_Id,m.PACT_record_UniqueId_kfq OriginId,x2.uniqueId,x2.guid,x2.parent_guid,x2.Pact_sid_kfq,x2.Code,x2.Name,x2.ms_name,x2.scale,x2.human_unit,x2.sequ,    
--       x1.pifee,x1.PItoACTOrNot,x1.contCount,x1.unitSum,x1.Id KFQ_PI_Content_Id    
--from KFQ_PAY_CHANGE_BILL m
--left join KFQ_PAY_STOCK_PI_CONTENT x1 on m.Id= x1.MasterId  
--left join KFQ_PAY_BOQ x2 on x2.guid = x1.BOQuniqueId_kfq
--where m.Status in(35,50) and m.IsOldData=1
--变更项（新数据）
Union
select m.Id Contract_Id,m.PACT_record_UniqueId_kfq OriginId,x2.uniqueId,x2.guid,x2.parent_guid,x2.Pact_sid_kfq,x2.Code,x2.Name,x2.ms_name,x2.scale,x2.human_unit,x2.sequ,    
       x1.pifee,x1.PItoACTOrNot,x1.contCount,x1.unitSum,x1.Id KFQ_PI_Content_Id    
from KFQ_PAY_CHANGE_BILL m
inner join KFQ_PAY_BOQ x2 on m.Id= x2.masterid  
left join KFQ_PAY_STOCK_PI_CONTENT x1 on x2.guid = x1.BOQuniqueId_kfq  --and x1.MasterId = m.Id  
where m.Status in(35,50) and m.IsOldData=0 