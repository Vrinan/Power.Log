alter proc GetFinancialManager(@id uniqueidentifier)
as
declare @count int
--declare @Picture image
--��ȡ����
select @count=count(*) from pwf_Infos a 
right join pwf_pastNodes b on a.WorkInfoID=b.WorkInfoID 
where a.KeyValue=@id and ActName='���񾭰���' 
--����һ�����ϵĲ��񾭰��ˣ�˵����ί��
if @count>1
begin
select t.* from(

select c.Picture,row_number() over(order by b.SequeID) as rows
from pwf_Infos a 
right join pwf_pastNodes b on a.WorkInfoID=b.WorkInfoID 
right join pb_humansign c on b.UserID = c.HumanId
where a.KeyValue=@id and ActName='���񾭰���'

) t where rows=2
end
--����һ����û��
if(@count = 1)
begin
select c.Picture
 from pwf_Infos a 
right join pwf_pastNodes b on a.WorkInfoID=b.WorkInfoID 
right join pb_humansign c on b.UserID = c.HumanId
where a.KeyValue=@id and ActName='���񾭰���' 
end


--exec GetFinancialManager '2b3720ec-9fdd-44c3-a5b9-64a6cbb76a9b'
--exec GetFinancialManager '4ee23dac-073b-490e-9e4e-f16c579be3b9'
--select t.* from(
--select c.Picture,row_number() over(order by b.SequID) rows
--from pwf_Infos a 
--right join pwf_pastNodes b on a.WorkInfoID=b.WorkInfoID 
--right join pb_humansign c on b.UserID = c.HumanId
--where a.KeyValue='2b3720ec-9fdd-44c3-a5b9-64a6cbb76a9b' and ActName='���񾭰���') t