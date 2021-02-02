--select * from PB_Widget where id='2ed807ac-6654-4f2d-8592-973f8d7e9e19'
----/PowerPlat/FormXml/zh-CN/StdPurchase/Organize_Supplier.htm

--人员调拨
select * from PB_Widget where id='185cf2bf-d7be-46f2-b396-033c18767321'
--/PowerPlat/FormXml/zh-CN/SF_YX/SF_YX_Allocation.htm

--alter table SF_YX_Allocation_list add OldPositionId uniqueidentifier null
--alter table SF_YX_Allocation_list add OldPosition nvarchar(100) null
--alter table SF_YX_Allocation_list add NewPositionId uniqueidentifier null
--alter table SF_YX_Allocation_list add NewPosition nvarchar(100) null


select * from PB_Department where Name='运行部'
select * from PB_Wizard where wizardid='5421fb3a-c5be-4d46-aba4-21629f9ff53d'
--/PowerPlat/FormXML/zh-CN/StdSystem/WizardDeptHumanList.htm


select * from PB_Widget where ExtJson like '%%'

select * from SF_YX_Allocation_list
select * from PB_Human where ID='C4CAD721-815B-45B9-8B3D-C476CD148F1A'


select * from PB_HumanRelation where HumanId='B6B4B148-2686-4CE0-A15B-C9DB54EBA617' and RelationId='7F2B84EC-48EA-4203-9D93-8F3A93C0FF7B'