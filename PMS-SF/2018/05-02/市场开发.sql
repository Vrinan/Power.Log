--年度指标录入
select * from PB_Widget where id='c1149c24-4bfb-4bd1-a825-a1f6dc7c08c0'
create table AnnualIndicators
(
id uniqueidentifier not null,
Code nvarchar(50) null,
Title nvarchar(50) null,
Amount float null,
Years datetime null
)
EXEC sp_rename 'AnnualIndicators','SF_AnnualIndicators'
select * from SF_AnnualIndicators