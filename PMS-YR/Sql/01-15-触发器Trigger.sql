--1、创建一个触发器
CREATE TRIGGER Test_Trigger
ON a
FOR INSERT, UPDATE, DELETE 
AS
print  'Don''t forget to print a report for the distributors.'
--insert into a values('3','2','6')

--2、重命名触发器

--3、删除触发器,可以先判断是否存在
if Exists(select name from sysobjects where name='Test_Trigger' and xtype='TR')
print '存在'
--INSTEAD OF
create trigger Tr_insteadof
on a
instead of delete
as
insert into a values('3','2','1')
--select * from a
--delete from a where id='1'

--4、检查是否更新了某一列，用于 insert 或 update，不能用于 delete。例：
create trigger Tr_ifupdate
on a
for update
as
if update(id) or update(value)
print '更新了 id 或 title 列'
--update a set id='10' where id='1'

--5、查看当前数据库有哪些触发器
select * from sysobjects where xtype='TR'
sp_helptext Test_Trigger
--6、触发器回滚
create trigger tr_rollback
on a
for update
as
    if update(userName)
        rollback tran

--7、表复制与触发器
--由于 select..into..from.. 要求目的表不存在，所以不讨论触发器。
--而 insert..into..select..form 的目的表，很可能含有触发器，要说明的是，如果目的表含有 insert 类型的触发器，那么对于一次批量插入的记录，只有最后一条记录会触发触发器。

--8、我们不能在视图上创建 FOR 触发器，而应该创建 INSTEAD OF

--9、禁用和启用触发器
--禁用：alter table 表名 disable trigger 触发器名称
--启用：alter table 表名 enable trigger 触发器名称

--10、