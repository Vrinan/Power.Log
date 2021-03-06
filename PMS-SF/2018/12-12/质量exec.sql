create proc  Proc_QulityfilesTem(@epsid uniqueidentifier)
as
declare @tj uniqueidentifier
declare @dq uniqueidentifier
declare @gy uniqueidentifier
set @tj=newid()
set @dq=newid()
set @gy=newid()
--先删除原来的分类
delete from PB_QulityTree where MasterId = @epsid
insert into PB_QulityTree values(@tj,@epsid,null,'','土建',NULL,NULL,NULL,'',NULL,NULL,0)
insert into PB_QulityTree values(@dq,@epsid,null,'','电气',NULL,NULL,NULL,'',NULL,NULL,0)
insert into PB_QulityTree values(@gy,@epsid,null,'','工艺',NULL,NULL,NULL,'',NULL,NULL,0)

insert into PB_QulityTree values(newid(),@epsid,@tj,null,'独立基础',NULL,NULL,NULL,'',NULL,NULL,0)
insert into PB_QulityTree values(newid(),@epsid,@tj,null,'桩基',NULL,NULL,NULL,'',NULL,NULL,0)
insert into PB_QulityTree values(newid(),@epsid,@tj,null,'主材',NULL,NULL,NULL,'',NULL,NULL,0)
insert into PB_QulityTree values(newid(),@epsid,@tj,null,'主体结构',NULL,NULL,NULL,'',NULL,NULL,0)
insert into PB_QulityTree values(newid(),@epsid,@tj,null,'试水',NULL,NULL,NULL,'',NULL,NULL,0)
insert into PB_QulityTree values(newid(),@epsid,@tj,null,'试压',NULL,NULL,NULL,'',NULL,NULL,0)
insert into PB_QulityTree values(newid(),@epsid,@tj,null,'闭水',NULL,NULL,NULL,'',NULL,NULL,0)
insert into PB_QulityTree values(newid(),@epsid,@tj,null,'池体、液氧罐沉降观测',NULL,NULL,NULL,'',NULL,NULL,0)
insert into PB_QulityTree values(newid(),@epsid,@tj,null,'管口坡度及冲水检测',NULL,NULL,NULL,'',NULL,NULL,0)

insert into PB_QulityTree values(newid(),@epsid,@dq,null,'送电前试验记录',NULL,NULL,NULL,'',NULL,NULL,0)
insert into PB_QulityTree values(newid(),@epsid,@dq,null,'仪表、强电检验',NULL,NULL,NULL,'',NULL,NULL,0)
insert into PB_QulityTree values(newid(),@epsid,@dq,null,'电缆检测',NULL,NULL,NULL,'',NULL,NULL,0)

insert into PB_QulityTree values(newid(),@epsid,@gy,null,'气压试验',NULL,NULL,NULL,'',NULL,NULL,0)
insert into PB_QulityTree values(newid(),@epsid,@gy,null,'双模试验',NULL,NULL,NULL,'',NULL,NULL,0)
insert into PB_QulityTree values(newid(),@epsid,@gy,null,'装置与实施技术协议对比检测',NULL,NULL,NULL,'',NULL,NULL,0)

go


