select * from PB_Human where id='76C0AD8E-BB9D-405C-9024-F5DB21ADDBD3'

select * from PB_HumanRelation where HumanId='76C0AD8E-BB9D-405C-9024-F5DB21ADDBD3'

select * from SF_YX_Allocation
select * from SF_YX_Allocation_list where MasterId='d1ffaa74-862c-434f-82d4-dd4e33daf1ae'

select * from PB_Department where id='CB16BCA1-0347-404E-ABB2-EF6A85AC106A'--长生桥（站）
select * from PB_Department where id='56702E05-B46D-47D1-9B51-32D1BC29EA9F'--昆明（站）
select * from PB_Position where id='5DAB7B88-8BD8-49BC-95E7-6B69ED968EFD'--水处理操作工
select * from PB_Position where id='0441A582-A9E0-41E6-9568-3CD329C04797'--站长


select * from PB_Department where Name='南宁（站）'--941F5D4C-909E-4EEA-B4D2-7A70D89D387F


--oldPosi   5DAB7B88-8BD8-49BC-95E7-6B69ED968EFD
--old       水处理操作工
--newPosi   65AEBF4D-42DB-4136-9834-210BB27BE29F
--new       负责人

--岗位3  部门2
--0441A582-A9E0-41E6-9568-3CD329C04797
--5DAB7B88-8BD8-49BC-95E7-6B69ED968EFD

Select A.*,B.Name as  HumanName ,B.Code as  HumanCode  From  PB_HumanRelation A 
join PB_Human B on A.HumanId = B.Id 
Where   (0=0)  
and A.HumanId='76C0AD8E-BB9D-405C-9024-F5DB21ADDBD3' 
and A.RelationType='2' and a.RelationId='C334CAEF-DFEA-4442-B42D-BE32281BF8A2' and 1=1 

select * from PB_HumanRelation where HumanId='12a6d6e1-fca4-42b1-9ce0-5c5c777e5dad'  and RelationId='cb16bca1-0347-404e-abb2-ef6a85ac106a'