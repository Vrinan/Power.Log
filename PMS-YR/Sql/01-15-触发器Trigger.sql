--1������һ��������
CREATE TRIGGER Test_Trigger
ON a
FOR INSERT, UPDATE, DELETE 
AS
print  'Don''t forget to print a report for the distributors.'
--insert into a values('3','2','6')

--2��������������

--3��ɾ��������,�������ж��Ƿ����
if Exists(select name from sysobjects where name='Test_Trigger' and xtype='TR')
print '����'
--INSTEAD OF
create trigger Tr_insteadof
on a
instead of delete
as
insert into a values('3','2','1')
--select * from a
--delete from a where id='1'

--4������Ƿ������ĳһ�У����� insert �� update���������� delete������
create trigger Tr_ifupdate
on a
for update
as
if update(id) or update(value)
print '������ id �� title ��'
--update a set id='10' where id='1'

--5���鿴��ǰ���ݿ�����Щ������
select * from sysobjects where xtype='TR'
sp_helptext Test_Trigger
--6���������ع�
create trigger tr_rollback
on a
for update
as
    if update(userName)
        rollback tran

--7�������봥����
--���� select..into..from.. Ҫ��Ŀ�ı����ڣ����Բ����۴�������
--�� insert..into..select..form ��Ŀ�ı��ܿ��ܺ��д�������Ҫ˵�����ǣ����Ŀ�ı��� insert ���͵Ĵ���������ô����һ����������ļ�¼��ֻ�����һ����¼�ᴥ����������

--8�����ǲ�������ͼ�ϴ��� FOR ����������Ӧ�ô��� INSTEAD OF

--9�����ú����ô�����
--���ã�alter table ���� disable trigger ����������
--���ã�alter table ���� enable trigger ����������

--10��