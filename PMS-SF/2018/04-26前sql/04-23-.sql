           
alter function f_chon_getnwepdi_xx_lxdy ( @human_id bigint ,@proj_id varchar(50))                
returns @t table(ID bigint)                
as
begin                                
 DECLARE   @jllxdlimitid_3 table  (ID bigint)                 
  declare @cursor cursor;--�α�                
  declare @masterId bigint                
  set @cursor=cursor for                 
    select  distinct a.type_sid  from tbl_nwepdi_pro a         
     join  tbl_nwepdi_xx_lxdy b on a.type_sid=b.sid            
    where user_sid=@human_id and b.project_id=@proj_id  -- and type='����λ'           
  open @cursor                
  fetch next from @cursor into @masterId;                
  while @@FETCH_STATUS=0                
  begin                
  insert into @jllxdlimitid_3  select @masterId  --���뵱ǰֵ              
                 
  insert into @jllxdlimitid_3    --�����ӽڵ�              
   select distinct sid from tbl_nwepdi_xx_lxdy  a               
   where   longname like  (select longname from tbl_nwepdi_xx_lxdy where sid =@masterId)+'.%'                
       and not exists (select 1 from @jllxdlimitid_3  b where a.sid=b.ID )              
                     
  fetch next from @cursor into @masterId;                
end                
close @cursor                
deallocate @cursor                         
insert into @t                
select ID from  @jllxdlimitid_3     

----�������ǰ�û���ӵ�в�ѯȨ�޵ýڵ㼰�ӽڵ�    
  DECLARE   @jllxdlimitid_4 table  (ID bigint)                 
  declare @cursor2 cursor;--�α�                
  set @cursor2=cursor for                 
    select distinct a.type_sid   from tbl_nwepdi_pro a         
	join  tbl_nwepdi_xx_lxdy b on a.type_sid=b.sid            
    where user_sid=@human_id   and b.project_id=@proj_id   and isnull(a.chenk,'False')='False'   -- and type='����λ'           
  open @cursor2                
  fetch next from @cursor2 into @masterId;                
  while @@FETCH_STATUS=0                
  begin                
  insert into @jllxdlimitid_4  select @masterId  --���뵱ǰֵ               
  insert into @jllxdlimitid_4    --�����ӽڵ�              
   select distinct sid from tbl_nwepdi_xx_lxdy  a               
   where   longname like  (select longname from tbl_nwepdi_xx_lxdy where sid =@masterId)+'.%'                
       and not exists (select 1 from @jllxdlimitid_4  b where a.sid=b.ID )       
       and not exists ( select 1 from tbl_nwepdi_pro c  where a.sid=c.type_sid and c.user_sid=@human_id and isnull(c.chenk,'False')='True'  )         
                     
  fetch next from @cursor2 into @masterId;                
end                
close @cursor2                
deallocate @cursor2      
 declare @hum_sid bigint      
 select @hum_sid=humen_sid from LMT_user  where user_sid=@human_id                   
  declare @cont int           
  set  @cont=0        
 ---�жϳ���Ȩ������Ա              
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
 where  not exists (select 1 from @t b where a.sid=b.ID )  and a.project_id=@proj_id -- and type='����λ'        
 end          
          
return                
end 


