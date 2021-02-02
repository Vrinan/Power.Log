select * from PB_Widget where id='51c08867-424b-45b4-9cea-9cea9b96f401'

--/PowerPlat/FormXml/zh-CN/SF_YX/Win_SF_YX_DrugsControl.htm

select * from PB_User where Name='Ñî½¾'

select * from PB_Department where Id=
(
select case 
when SecondDeptId is null or SecondDeptId='00000000-0000-0000-0000-000000000000' then DeptId
else SecondDeptId 
end as DeptId  from PB_Human hu where hu.Id='[@HumanId]'
)


Id=(select case when SecondDeptId is null or SecondDeptId='00000000-0000-0000-0000-000000000000' then DeptId else SecondDeptId end as DeptId  from PB_Human where Id='[@HumanId]')

select DeptId,SecondDeptId,Name,* from PB_Human



select * from PB_Department where LongCode like '12%' and
 Id=(select case when SecondDeptId is null or SecondDeptId='00000000-0000-0000-0000-000000000000' then DeptId else SecondDeptId end as DeptId  from PB_Human where Id='3d8bc928-2add-45ce-80ed-f747a6c922d2')


 Select A.*,B.* From  PB_Department A join PB_DefaultField B on A.Id=B.DefaultFieldId Where   (0=0)  and  1=1  and A.LongCode like '12%' 
 and A.Id=(
 select case when SecondDeptId is null or SecondDeptId='00000000-0000-0000-0000-000000000000' then DeptId 
 else SecondDeptId end as DeptId  from PB_Human 
 where A.Id='3d8bc928-2add-45ce-80ed-f747a6c922d2'
 ) 
 and B.BizAreaId='00000000-0000-0000-0000-00000000000a'  Order By  B.Sequ asc

 select * from PB_Human where Name='Ñîæ¯'



 select RenewalTerm,RenewalTerms,* from SF_LaborRenewalApply
update SF_LaborRenewalApply set RenewalTerms = RenewalTerm

 alter table SF_LaborRenewalApply add RenewalTerms nvarchar(2000) null

 select * from PB_Widget where id='ee70466b-e07d-4ad5-926b-7bbdd351f5c4'
 --/PowerPlat/FormXml/zh-CN/SF_Complex/SF_LaborRenewalApply.htm

alter table PS_MK_ContractReview add IsTechnicalAgreement nvarchar(100) null


select * from PB_Widget where id='5c0640b9-fb52-4b58-bc90-b7af15a884c2'
--/PowerPlat/FormXml/zh-CN/SF_CM/PS_CM_ContractReview.htm