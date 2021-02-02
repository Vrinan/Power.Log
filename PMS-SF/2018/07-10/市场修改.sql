create view View_SF_DeptHumans
as
select a.Code,a.Id as Id, a.Name as Name,b.Id as HumanId,
b.Name as HumanName,c.Id as HumanAID,c.Name as HumanNameA from PB_Department a 
left join 
(select * from pb_human where PosiId in(
select Id from PB_Position  where (Name like '%����%' or Name='����_���Ÿ�����') and Name not like '%������%')) b
on b.DeptId = a.Id 
left join
(select * from PB_Human where PosiId in(
select Id from PB_Position where Name like '%���ܾ���%')) c on c.DeptId = a.Id where a.Name<>'�쵼����' 


select a.Code,a.Id,a.Name,
case when a.HumanId is null then 'E87B1084-180B-48DE-BFEA-0D80EACF7337' else a.HumanId end as HumanId,
case when a.HumanName is null then '������' else a.HumanName end as HumanName,
case when a.Name like '%վ%' or a.Name='���в�' then 'CF990F95-5872-4D6F-9D60-7A263E9CEE2F'
     when a.Name = '��ȫ������' or a.Name='��Ŀ����' or a.Name='��Ʋ�' then '10C90E39-5C25-406D-BF0D-9E3EEC2AAA69' 
	 when a.Name = '�ۺϲ�' or a.Name='�г�������' or a.Name='���첿' or a.Name='����ҵ��' then 'FF528BB6-B2D8-4D47-8952-C69E987ADCB0' 
	 when a.Name = '����' or a.Name='��ͬ����' or a.Name='�б�ɹ���' then '1CB8AF7C-74A6-473C-9E7C-0C4251213684' 
	 else null end as HumanAID,
case when a.Name like '%վ%' or a.Name='���в�' then '����'
     when a.Name = '��ȫ������' or a.Name='��Ŀ����' or a.Name='��Ʋ�' then '������'
	 when a.Name = '�ۺϲ�' or a.Name='�г�������' or a.Name='���첿' or a.Name='����ҵ��' then '�׶�' 
	 when a.Name = '����' or a.Name='��ͬ����' or a.Name='�б�ɹ���' then '������' 
	 else null end as HumanNameA
from View_SF_DeptHumans a order by Code



select * from PB_Human where Code='1705'
select * from pb_human where PosiId in(
select Id from PB_Position  where Name like '%���ܾ���%')
--����CF990F95-5872-4D6F-9D60-7A263E9CEE2F
--������10C90E39-5C25-406D-BF0D-9E3EEC2AAA69
--������1CB8AF7C-74A6-473C-9E7C-0C4251213684
--�׶�FF528BB6-B2D8-4D47-8952-C69E987ADCB0
select * from SF_RecruitmentDocumentsPlan_dtl
select * from PB_Department
select * from PB_Position
