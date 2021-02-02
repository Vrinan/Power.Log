select * from PB_Widget where id='71781861-b9a8-46c2-a865-c033730919c1'

--ProjectType_Info
select * from PB_BaseData a left join PB_BaseDataList b on a.Id = b.BaseDataId where a.DataType='ProjectType_Info'

--项目负责人都是空的
select * from SF_PS_MK_ProjectInfo where FollowHuman is not null

select ProjectType_Info,* from SF_PS_MK_ProjectInfo where ProjectType_Info is not null

select * from PB_Widget where id='71781861-b9a8-46c2-a865-c033730919c1'
--/PowerPlat/FormXml/zh-CN/StdMarket/Win_StdMarketMain_Infos.htm