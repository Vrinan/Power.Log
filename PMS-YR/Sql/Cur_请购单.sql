

declare
--请购主键
@qg_id varchar(50),
--请购子表主键
@qg_z_id varchar(50),
--计划主键
@order_grid varchar(50),
--物资编码
@matcode varchar(500),
--装置
@pur_major varchar(500),
--位号
@UnitName varchar(500),
--数量
@Design_Qty numeric(18,4)
--创建游标
declare @cursor cursor
--设定游标欲操作的数据集
set @cursor=cursor for
select id,order_guid from XLX_PUR_Request
--打开游标
open @cursor
--移动游标指向到第一条数据，提取第一条数据存放在变量中
fetch next from @cursor into @qg_id,@order_grid
--如果上一次操作成功则继续循环
while(@@fetch_status=0)begin
--操作提出的数据
    declare @cursor_new cursor
    set @cursor_new=cursor for
    select id,matcode,Devicename,UnitName,Qty_Bom from XLX_PUR_Request_List where fk =@qg_id
    open @cursor_new
    fetch next from @cursor_new into @qg_z_id,@matcode,@pur_major,@UnitName,@Design_Qty
    while(@@fetch_status=0)begin
            --update XLX_PUR_Request_List set bomid = 'F623A883-48B0-4BAA-A17C-0000154B7817' where id = @qg_z_id
            update XLX_PUR_Request_List set bomid =(
            select max(id) from PS_PUR_BOM where MasterId = @order_grid and matcode=@matcode and pur_major=@pur_major and UnitName= @UnitName and Design_Qty=@Design_Qty
            ) where id = @qg_z_id
            print '请购单主表：'+@order_grid 
            print '物资编码:'+@matcode
            print '装置:'+@pur_major
            print '位号:'+@UnitName
            --print '数量:'+@Design_Qty
            print '主键：' +@qg_z_id
        fetch next from @cursor_new into @qg_z_id,@matcode,@pur_major,@UnitName,@Design_Qty
    end
    close @cursor_new
    deallocate @cursor_new
    
    --继续提下一行
    fetch next from @cursor into @qg_id,@order_grid
end
--关闭游标
close @cursor
--删除游标
deallocate @cursor
