select * from PB_Widget where id='1d8707f1-f8ed-4264-853a-d3cbd39bb6d8'
--/PowerPlat/FormXml/zh-CN/SF_CM/SubContractInvoice_E.htm

select * from PB_Widget where id='6665fd96-4c31-4f88-a262-d011ab0d8524'
--/PowerPlat/FormXml/zh-CN/StdContract/ContractSettlement.htm

select * from PB_Widget where id='9f17627b-b9f0-4bb1-9f1f-91ef137de070'
--/PowerPlat/FormXml/zh-CN/SF_CM/SubContractSettlement_E.htm

exec dbo.P_DeleteWorkFlow_Sam 'b4c1fd5a-f46f-4307-bde9-ae3009344c1b','PS_CM_SubContractSettle'
select * from PB_Widget where id='c56cea22-6dcd-46a7-bceb-57e26ddfb4db'
--/PowerPlat/FormXml/zh-CN/SF_CM/SubContract_E.htm

select * from PS_CM_SubContractSettle
Select MAX(A.Code) as Code From  PS_CM_SubContractSettle A Where   (0=0)  and A.Code like 'CON/-SCS/-____' escape '/'

select request_session_id spid,OBJECT_NAME(resource_associated_entity_id) tableName from sys.dm_tran_locks where resource_type='OBJECT';


Select XCode_T1.* From (Select A.*,B.PartyB as PartyB ,B.PartyB_Guid as PartyB_Guid ,B.SubContractAmount as SubContractAmount ,B.SubContractCode as SubContractCode ,B.SubContractName as SubContractName , row_number() over(Order By a.Id) as rowNumber From PS_CM_SubContractSettle A left join PS_CM_SubContract B on A.SubContract_Guid = B.Id Where (0=0) and 1=1 and A.MasterId='1239963b-1dc6-4e80-9f0e-6cbbaa00987e') XCode_T1 Where rowNumber Between 1 And 15


alter table PS_CM_SubContract add IsSettle int null

select * from PB_Widget where id='f1340eae-0d30-4e12-9c64-7b13e97f4ee8'
--/PowerPlat/FormXml/zh-CN/StdContract/Win_SubContract_E.htm

select * from PS_CM_SubContract order by issettle



update PS_CM_SubContract set issettle =1 where id in(
select SubContract_Guid from PS_CM_SubContractSettle where Status=50)