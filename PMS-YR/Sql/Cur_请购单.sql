

declare
--�빺����
@qg_id varchar(50),
--�빺�ӱ�����
@qg_z_id varchar(50),
--�ƻ�����
@order_grid varchar(50),
--���ʱ���
@matcode varchar(500),
--װ��
@pur_major varchar(500),
--λ��
@UnitName varchar(500),
--����
@Design_Qty numeric(18,4)
--�����α�
declare @cursor cursor
--�趨�α������������ݼ�
set @cursor=cursor for
select id,order_guid from XLX_PUR_Request
--���α�
open @cursor
--�ƶ��α�ָ�򵽵�һ�����ݣ���ȡ��һ�����ݴ���ڱ�����
fetch next from @cursor into @qg_id,@order_grid
--�����һ�β����ɹ������ѭ��
while(@@fetch_status=0)begin
--�������������
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
            print '�빺������'+@order_grid 
            print '���ʱ���:'+@matcode
            print 'װ��:'+@pur_major
            print 'λ��:'+@UnitName
            --print '����:'+@Design_Qty
            print '������' +@qg_z_id
        fetch next from @cursor_new into @qg_z_id,@matcode,@pur_major,@UnitName,@Design_Qty
    end
    close @cursor_new
    deallocate @cursor_new
    
    --��������һ��
    fetch next from @cursor into @qg_id,@order_grid
end
--�ر��α�
close @cursor
--ɾ���α�
deallocate @cursor
