--设计提资
--select ProjectCodeId,
--DisposeScale,LabourCrew,ProcessObject,ProjectProperty,DisposeCraft,ProjectSite,FloorSpace,WorkShift,DurableYears,
--* from SF_SJ_DesignInformation

alter proc Proc_SF_DesignInformation(@ProjId nvarchar(200),@Id nvarchar(200))
as
declare @a nvarchar(1000)
declare @b nvarchar(1000)
declare @c nvarchar(1000)
declare @d nvarchar(1000)
declare @e nvarchar(1000)
declare @f nvarchar(1000)
declare @g nvarchar(1000)
declare @h nvarchar(1000)
declare @i nvarchar(1000)
select top 1 @a=DisposeScale,@b=LabourCrew,@c=ProcessObject,@d=ProjectProperty,@e=DisposeCraft,@f=ProjectSite,@g=FloorSpace,
@h=WorkShift,@i=DurableYears
from SF_SJ_DesignInformation where ProjectCodeId = @ProjId and Status=50 order by RegDate desc

update SF_SJ_DesignInformation set DisposeScale =@a where Id=@Id
update SF_SJ_DesignInformation set LabourCrew =@b where Id=@Id
update SF_SJ_DesignInformation set ProcessObject =@c where Id=@Id
update SF_SJ_DesignInformation set ProjectProperty =@d where Id=@Id
update SF_SJ_DesignInformation set DisposeCraft =@e where Id=@Id
update SF_SJ_DesignInformation set ProjectSite =@f where Id=@Id
update SF_SJ_DesignInformation set FloorSpace =@g where Id=@Id
update SF_SJ_DesignInformation set WorkShift =@h where Id=@Id
update SF_SJ_DesignInformation set DurableYears =@i where Id=@Id


select * from PB_Widget where Id='b9fc1dd8-ec04-4ef8-bcbc-1ee8a48cdbb3'
--/PowerPlat/FormXml/zh-CN/SF_Design/SF_DesignInformation.htm


select * from SF_SJ_DesignInformation where id='42D643DF-FDF7-44A1-8CA7-B549C09E2190'

Exec [dbo].[getLeiDong] '[@KeyValue]'

sp_helptext getLeiDong

  
CREATE proc [dbo].[getLeiDong](@KeyValue nvarchar(100))  
as  
declare @deptid nvarchar(100)  
declare @sta nvarchar(50)  
declare @RegHumanId nvarchar(100)  
  
select @RegHumanId=RegHumId from SF_FK_Reimbursement where id=@KeyValue  
select @deptid = DeptId from PB_Human where Id=@RegHumanId  
select @sta = Status from SF_FK_Reimbursement where Id=@KeyValue  
if(@deptid = '3E5D0E38-DA06-40F7-9349-D10038508DBD' and @sta = '50')  

--综合部
--select * from PB_Department where Id='3E5D0E38-DA06-40F7-9349-D10038508DBD'
begin  
  
select a.Code,a.Name,b.Picture   
from PB_Human a join PB_HumanSign b on a.Id = b.HumanId  
where a.Name = '雷东'  
end
  
else  
begin  
select * from (  
select b.UserName,b.UserID,b.ActName,d.Picture,row_number() over(order by b.SendDate desc) rn  
from pwf_infos a left join pwf_pastNodes b on a.WorkInfoID = b.WorkInfoID  
        left join pwf_Opinion c on b.WorkInfoID = c.WorkInfoID and b.SequeID = c.SequeID  
     left join PB_HumanSign d on b.UserID = d.HumanId  
where a.KeyValue = @KeyValue and b.ActName = '申请部门和财务分管' and b.InboxStatus = '60' and b.UserID in(  
select b.Id  
from PB_HumanRelation a left join PB_Human b on a.HumanId = b.Id  
      left join PB_HumanSign c on b.Id = c.HumanId  
where a.RelationId in(select b.ParentId  
                   from PB_HumanRelation a  join PB_Position b on a.RelationId = b.Id  
                           join (select b.UserName,b.UserID  
                              from pwf_infos a left join pwf_pastNodes b on a.WorkInfoID = b.WorkInfoID  
                                                              left join pwf_Opinion c on b.WorkInfoID = c.WorkInfoID and b.SequeID = c.SequeID  
                                                           left join PB_HumanSign d on b.UserID = d.HumanId  
                                                      where a.KeyValue = @KeyValue and b.ActName = '申请人部长') c   
       on a.HumanId = c.UserID)  
)) t
where t.rn<=1  
  
end  