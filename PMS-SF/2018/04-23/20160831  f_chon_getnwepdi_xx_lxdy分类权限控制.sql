           
alter function f_chon_getnwepdi_xx_lxdy ( @human_id bigint ,@proj_id varchar(50))                
returns @t table(ID bigint)                
as                 
/*        
  1.增加函数,根据当前用户数据分类权限控制树状结构显示与否;  Create by Huang 2016-08-31        
  2.调整 权限组根据对应权限组 不受权限控制,均可以查阅;         
  3.        
*/        
begin                
 /*  select  * from lmt_user where userName='王祥'          
     select  *  from tbl_nwepdi_xx_lxdy  where project_id='default' and type='监理单位'        
     select  *  from tbl_nwepdi_pro where type_sid='1604'         
     select  id  from f_chon_getnwepdi_xx_lxdy(28,'default')        
        
  */               
              
 DECLARE   @jllxdlimitid_3 table  (ID bigint)                 
  declare @cursor cursor;--游标                
  declare @masterId bigint                
  set @cursor=cursor for                 
    select  distinct a.type_sid  from tbl_nwepdi_pro a         
     join  tbl_nwepdi_xx_lxdy b on a.type_sid=b.sid            
    where user_sid=@human_id   and b.project_id=@proj_id  -- and type='监理单位'           
  open @cursor                
  fetch next from @cursor into @masterId;                
  while @@FETCH_STATUS=0                
  begin                
  insert into @jllxdlimitid_3  select @masterId  --插入当前值              
                 
  insert into @jllxdlimitid_3    --插入子节点              
   select distinct sid from tbl_nwepdi_xx_lxdy  a               
   where   longname like  (select longname from tbl_nwepdi_xx_lxdy where sid =@masterId)+'.%'                
       and not exists (select 1 from @jllxdlimitid_3  b where a.sid=b.ID )              
                     
  fetch next from @cursor into @masterId;                
end                
close @cursor                
deallocate @cursor                
                
insert into @t                
select ID from  @jllxdlimitid_3     
    
----计算出当前用户仅拥有查询权限得节点及子节点    
  DECLARE   @jllxdlimitid_4 table  (ID bigint)                 
  declare @cursor2 cursor;--游标                
         
  set @cursor2=cursor for                 
    select  distinct a.type_sid   from tbl_nwepdi_pro a         
     join  tbl_nwepdi_xx_lxdy b on a.type_sid=b.sid            
    where user_sid=@human_id   and b.project_id=@proj_id   and isnull(a.chenk,'False')='False'   -- and type='监理单位'           
  open @cursor2                
  fetch next from @cursor2 into @masterId;                
  while @@FETCH_STATUS=0                
  begin                
  insert into @jllxdlimitid_4  select @masterId  --插入当前值              
                 
  insert into @jllxdlimitid_4    --插入子节点              
   select distinct sid from tbl_nwepdi_xx_lxdy  a               
   where   longname like  (select longname from tbl_nwepdi_xx_lxdy where sid =@masterId)+'.%'                
       and not exists (select 1 from @jllxdlimitid_4  b where a.sid=b.ID )       
       --条件:属于子节点但该用户子节点有数据权限    
       and not exists ( select 1 from tbl_nwepdi_pro c  where a.sid=c.type_sid and c.user_sid=@human_id and isnull(c.chenk,'False')='True'  )         
                     
  fetch next from @cursor2 into @masterId;                
end                
close @cursor2                
deallocate @cursor2     
--删除当前用户没分发数据得子分类    
 declare @hum_sid bigint      
 select @hum_sid=humen_sid from LMT_user  where user_sid=@human_id      
/*delete  from  @t      
where ID in  (select ID from @jllxdlimitid_4 )     
   and ID not in   (  select c.parent_sid from  REC_distribute_list c where   human_sid=@hum_sid  )    
   */    
--------------------------------------------------              
  declare @cont int           
  set  @cont=0        
 ---判断超级权限组人员              
  select @cont=COUNT(*)        
      from LMT_user_role a         
      left outer join lmt_user b on a.user_sid = b.user_sid        
      left join LMT_role c on a.role_sid=c.role_sid        
      where  b.user_sid = @human_id   and  (a.project_id= @proj_id or a.project_id='default')       
      and  role_name in (select lmt_name from tbl_nwepdi_limitgrop where (projectid='default' or projectid=@proj_id ))          
               
 if (@cont>0)             
 begin       
 insert into @t            
 select sid from tbl_nwepdi_xx_lxdy  a         
 where  not exists (select 1 from @t b where a.sid=b.ID )  and a.project_id=@proj_id -- and type='监理单位'        
 end          
          
return                
end 


