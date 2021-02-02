
select Title from pwf_Infos group by Title having count(Title)>1

create view View_SF_WorkFlow
as
select  al.*,alr.Content,alr.SequeID,alr.VoteText,alr.VoteValue from pwf_Infos al 
left join pwf_Opinion alr on al.WorkInfoID = alr.WorkInfoID order by KeyWord,Title
--case al.RecordStatus when 1 then 1 else '' end as status,
select * from View_SF_WorkFlow

select distinct userid,keyword,title from pwf_Infos order by KeyWord,Title

SELECT * FROM pwf_Infos GROUP BY  keyword  ORDER BY UpdDate DESC 

select * from pwf_Infos

select * from pb_widget where id='4a1a1d71-02e6-49af-908c-a57fc1b7054f'
--/PowerPlat/FormXml/zh-CN/StdContract/Win_IncomeAnalysis.htm


Select * From View_SF_WorkFlow Where   CreateDate>='2018-07-01' and CreateDate<='2018-07-31' and EpsProjectName ='Èı·å¿Æ¼¼' and FinishDate ='' Order By  KeyWord,Title