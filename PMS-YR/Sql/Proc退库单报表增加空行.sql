
CREATE PROC Single_refunding(@Id varchar(80))           
AS        
BEGIN        
        
declare @num int  
select @num=count(*) from PS_PUR_MatReturn_Dtl a left join PS_PUR_MatReturn b on a.MasterId=b.Id where b.Id=@Id 
 if @num<9  
 begin  
 if @num=1  
 begin  
  select a.MatCode,a.MatName,a.MatDescription,a.MatUnit,a.OutNum,a.ReturnNum,a.UnitPrice,a.ReturnAmount,a.Remarks,a.UpdDate from PS_PUR_MatReturn_Dtl a left join 
  PS_PUR_MatReturn b on a.MasterId=b.Id where b.Id=@Id  
  union all  
  select '' as MatCode,'' as MatName,NULL as MatDescription,NULL as MatUnit,NULL as OutNum,'' as ReturnNum,'' as UnitPrice,NULL as ReturnAmount,NULL as Remarks,NULL as UpdDate
  union all  
  select '' as MatCode,'' as MatName,NULL as MatDescription,NULL as MatUnit,NULL as OutNum,'' as ReturnNum,'' as UnitPrice,NULL as ReturnAmount,NULL as Remarks,NULL as UpdDate  
  union all  
  select '' as MatCode,'' as MatName,NULL as MatDescription,NULL as MatUnit,NULL as OutNum,'' as ReturnNum,'' as UnitPrice,NULL as ReturnAmount,NULL as Remarks,NULL as UpdDate  
  union all  
  select '' as MatCode,'' as MatName,NULL as MatDescription,NULL as MatUnit,NULL as OutNum,'' as ReturnNum,'' as UnitPrice,NULL as ReturnAmount,NULL as Remarks,NULL as UpdDate
  union all  
  select '' as MatCode,'' as MatName,NULL as MatDescription,NULL as MatUnit,NULL as OutNum,'' as ReturnNum,'' as UnitPrice,NULL as ReturnAmount,NULL as Remarks,NULL as UpdDate 
  union all  
  select '' as MatCode,'' as MatName,NULL as MatDescription,NULL as MatUnit,NULL as OutNum,'' as ReturnNum,'' as UnitPrice,NULL as ReturnAmount,NULL as Remarks,NULL as UpdDate
  union all  
  select '' as MatCode,'' as MatName,NULL as MatDescription,NULL as MatUnit,NULL as OutNum,'' as ReturnNum,'' as UnitPrice,NULL as ReturnAmount,NULL as Remarks,NULL as UpdDate  
  union all  
  select '' as MatCode,'' as MatName,NULL as MatDescription,NULL as MatUnit,NULL as OutNum,'' as ReturnNum,'' as UnitPrice,NULL as ReturnAmount,NULL as Remarks,NULL as UpdDate
 end  
if @num=2
 begin  
  select a.MatCode,a.MatName,a.MatDescription,a.MatUnit,a.OutNum,a.ReturnNum,a.UnitPrice,a.ReturnAmount,a.Remarks,a.UpdDate from PS_PUR_MatReturn_Dtl a left join 
  PS_PUR_MatReturn b on a.MasterId=b.Id where b.Id=@Id 
  union all  
  select '' as MatCode,'' as MatName,NULL as MatDescription,NULL as MatUnit,NULL as OutNum,'' as ReturnNum,'' as UnitPrice,NULL as ReturnAmount,NULL as Remarks,NULL as UpdDate  
  union all  
  select '' as MatCode,'' as MatName,NULL as MatDescription,NULL as MatUnit,NULL as OutNum,'' as ReturnNum,'' as UnitPrice,NULL as ReturnAmount,NULL as Remarks,NULL as UpdDate  
  union all  
  select '' as MatCode,'' as MatName,NULL as MatDescription,NULL as MatUnit,NULL as OutNum,'' as ReturnNum,'' as UnitPrice,NULL as ReturnAmount,NULL as Remarks,NULL as UpdDate
  union all  
  select '' as MatCode,'' as MatName,NULL as MatDescription,NULL as MatUnit,NULL as OutNum,'' as ReturnNum,'' as UnitPrice,NULL as ReturnAmount,NULL as Remarks,NULL as UpdDate 
  union all  
  select '' as MatCode,'' as MatName,NULL as MatDescription,NULL as MatUnit,NULL as OutNum,'' as ReturnNum,'' as UnitPrice,NULL as ReturnAmount,NULL as Remarks,NULL as UpdDate
  union all  
  select '' as MatCode,'' as MatName,NULL as MatDescription,NULL as MatUnit,NULL as OutNum,'' as ReturnNum,'' as UnitPrice,NULL as ReturnAmount,NULL as Remarks,NULL as UpdDate  
  union all  
  select '' as MatCode,'' as MatName,NULL as MatDescription,NULL as MatUnit,NULL as OutNum,'' as ReturnNum,'' as UnitPrice,NULL as ReturnAmount,NULL as Remarks,NULL as UpdDate
 end  
 if @num=3
 begin  
  select a.MatCode,a.MatName,a.MatDescription,a.MatUnit,a.OutNum,a.ReturnNum,a.UnitPrice,a.ReturnAmount,a.Remarks,a.UpdDate from PS_PUR_MatReturn_Dtl a left join 
  PS_PUR_MatReturn b on a.MasterId=b.Id where b.Id=@Id 
  union all  
  select '' as MatCode,'' as MatName,NULL as MatDescription,NULL as MatUnit,NULL as OutNum,'' as ReturnNum,'' as UnitPrice,NULL as ReturnAmount,NULL as Remarks,NULL as UpdDate  
  union all  
  select '' as MatCode,'' as MatName,NULL as MatDescription,NULL as MatUnit,NULL as OutNum,'' as ReturnNum,'' as UnitPrice,NULL as ReturnAmount,NULL as Remarks,NULL as UpdDate
  union all  
  select '' as MatCode,'' as MatName,NULL as MatDescription,NULL as MatUnit,NULL as OutNum,'' as ReturnNum,'' as UnitPrice,NULL as ReturnAmount,NULL as Remarks,NULL as UpdDate 
  union all  
  select '' as MatCode,'' as MatName,NULL as MatDescription,NULL as MatUnit,NULL as OutNum,'' as ReturnNum,'' as UnitPrice,NULL as ReturnAmount,NULL as Remarks,NULL as UpdDate
  union all  
  select '' as MatCode,'' as MatName,NULL as MatDescription,NULL as MatUnit,NULL as OutNum,'' as ReturnNum,'' as UnitPrice,NULL as ReturnAmount,NULL as Remarks,NULL as UpdDate  
  union all  
  select '' as MatCode,'' as MatName,NULL as MatDescription,NULL as MatUnit,NULL as OutNum,'' as ReturnNum,'' as UnitPrice,NULL as ReturnAmount,NULL as Remarks,NULL as UpdDate
 end 
 if @num=4
 begin  
  select a.MatCode,a.MatName,a.MatDescription,a.MatUnit,a.OutNum,a.ReturnNum,a.UnitPrice,a.ReturnAmount,a.Remarks,a.UpdDate from PS_PUR_MatReturn_Dtl a left join 
  PS_PUR_MatReturn b on a.MasterId=b.Id where b.Id=@Id 
  union all   
  select '' as MatCode,'' as MatName,NULL as MatDescription,NULL as MatUnit,NULL as OutNum,'' as ReturnNum,'' as UnitPrice,NULL as ReturnAmount,NULL as Remarks,NULL as UpdDate
  union all  
  select '' as MatCode,'' as MatName,NULL as MatDescription,NULL as MatUnit,NULL as OutNum,'' as ReturnNum,'' as UnitPrice,NULL as ReturnAmount,NULL as Remarks,NULL as UpdDate 
  union all  
  select '' as MatCode,'' as MatName,NULL as MatDescription,NULL as MatUnit,NULL as OutNum,'' as ReturnNum,'' as UnitPrice,NULL as ReturnAmount,NULL as Remarks,NULL as UpdDate
  union all  
  select '' as MatCode,'' as MatName,NULL as MatDescription,NULL as MatUnit,NULL as OutNum,'' as ReturnNum,'' as UnitPrice,NULL as ReturnAmount,NULL as Remarks,NULL as UpdDate  
  union all  
  select '' as MatCode,'' as MatName,NULL as MatDescription,NULL as MatUnit,NULL as OutNum,'' as ReturnNum,'' as UnitPrice,NULL as ReturnAmount,NULL as Remarks,NULL as UpdDate
 end 
  if @num=5
 begin  
  select a.MatCode,a.MatName,a.MatDescription,a.MatUnit,a.OutNum,a.ReturnNum,a.UnitPrice,a.ReturnAmount,a.Remarks,a.UpdDate from PS_PUR_MatReturn_Dtl a left join 
  PS_PUR_MatReturn b on a.MasterId=b.Id where b.Id=@Id 
  union all  
  select '' as MatCode,'' as MatName,NULL as MatDescription,NULL as MatUnit,NULL as OutNum,'' as ReturnNum,'' as UnitPrice,NULL as ReturnAmount,NULL as Remarks,NULL as UpdDate 
  union all  
  select '' as MatCode,'' as MatName,NULL as MatDescription,NULL as MatUnit,NULL as OutNum,'' as ReturnNum,'' as UnitPrice,NULL as ReturnAmount,NULL as Remarks,NULL as UpdDate
  union all  
  select '' as MatCode,'' as MatName,NULL as MatDescription,NULL as MatUnit,NULL as OutNum,'' as ReturnNum,'' as UnitPrice,NULL as ReturnAmount,NULL as Remarks,NULL as UpdDate  
  union all  
  select '' as MatCode,'' as MatName,NULL as MatDescription,NULL as MatUnit,NULL as OutNum,'' as ReturnNum,'' as UnitPrice,NULL as ReturnAmount,NULL as Remarks,NULL as UpdDate
 end 
   if @num=6
 begin  
  select a.MatCode,a.MatName,a.MatDescription,a.MatUnit,a.OutNum,a.ReturnNum,a.UnitPrice,a.ReturnAmount,a.Remarks,a.UpdDate from PS_PUR_MatReturn_Dtl a left join 
  PS_PUR_MatReturn b on a.MasterId=b.Id where b.Id=@Id 
  union all  
  select '' as MatCode,'' as MatName,NULL as MatDescription,NULL as MatUnit,NULL as OutNum,'' as ReturnNum,'' as UnitPrice,NULL as ReturnAmount,NULL as Remarks,NULL as UpdDate
  union all  
  select '' as MatCode,'' as MatName,NULL as MatDescription,NULL as MatUnit,NULL as OutNum,'' as ReturnNum,'' as UnitPrice,NULL as ReturnAmount,NULL as Remarks,NULL as UpdDate  
  union all  
  select '' as MatCode,'' as MatName,NULL as MatDescription,NULL as MatUnit,NULL as OutNum,'' as ReturnNum,'' as UnitPrice,NULL as ReturnAmount,NULL as Remarks,NULL as UpdDate
 end 
 if @num=7
 begin  
  select a.MatCode,a.MatName,a.MatDescription,a.MatUnit,a.OutNum,a.ReturnNum,a.UnitPrice,a.ReturnAmount,a.Remarks,a.UpdDate from PS_PUR_MatReturn_Dtl a left join 
  PS_PUR_MatReturn b on a.MasterId=b.Id where b.Id=@Id 
  union all  
  select '' as MatCode,'' as MatName,NULL as MatDescription,NULL as MatUnit,NULL as OutNum,'' as ReturnNum,'' as UnitPrice,NULL as ReturnAmount,NULL as Remarks,NULL as UpdDate  
  union all  
  select '' as MatCode,'' as MatName,NULL as MatDescription,NULL as MatUnit,NULL as OutNum,'' as ReturnNum,'' as UnitPrice,NULL as ReturnAmount,NULL as Remarks,NULL as UpdDate
 end 
 if @num=8
 begin  
  select a.MatCode,a.MatName,a.MatDescription,a.MatUnit,a.OutNum,a.ReturnNum,a.UnitPrice,a.ReturnAmount,a.Remarks,a.UpdDate from PS_PUR_MatReturn_Dtl a left join 
  PS_PUR_MatReturn b on a.MasterId=b.Id where b.Id=@Id 
  union all  
  select '' as MatCode,'' as MatName,NULL as MatDescription,NULL as MatUnit,NULL as OutNum,'' as ReturnNum,'' as UnitPrice,NULL as ReturnAmount,NULL as Remarks,NULL as UpdDate
 end 
  end 
  select 'OK'
end
