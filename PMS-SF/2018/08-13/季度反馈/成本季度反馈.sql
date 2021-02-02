--³É±¾·´À¡
select convert(int,max(SeasonNum))+1 as MaxSeasonNum from SF_FK_EquipmentCostFeedback where EpsProjectId='' and CostType=''

update SF_FK_EquipmentCostFeedback set SeasonNum=null

select convert(int,max(SeasonNum))+1 as MaxSeasonNum from SF_FK_EquipmentCostFeedback where EpsProjectId='17863072-cbd6-4931-b573-aacc720d6101' and CostType='1'