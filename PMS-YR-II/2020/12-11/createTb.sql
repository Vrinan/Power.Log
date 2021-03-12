--采办超概算分析报告
create table YR_ProOfBudget
(
	Id uniqueidentifier null,
	Code nvarchar(max) null,
	Title nvarchar(max) null,
	ExecDeptCode nvarchar(max) null,
	ExecDeptName nvarchar(max) null,
	ExecDeptId uniqueidentifier null,
	Content nvarchar(max) null,
	Reasons nvarchar(max) null,
	ConClusion nvarchar(max) null,
)