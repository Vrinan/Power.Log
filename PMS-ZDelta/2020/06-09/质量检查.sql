--质量检查
CREATE TABLE ZDelta_Qlty_InspectionNotice(
	Id uniqueidentifier NOT NULL,
	Code nvarchar(1999) NULL,
	Title nvarchar(1999) NULL,
	InspectionDeptName nvarchar(1999) NULL,--检查部门
	InspectionDeptId uniqueidentifier NULL,
	InspectionHumanName nvarchar(1999) NULL,--检察人员
	InspectionHumanId nvarchar(1999) NULL,--检察人员
	InspectionDate datetime null,--检查日期
)
CREATE TABLE ZDelta_Qlty_InspectionNoticeDtl(
	Id uniqueidentifier NOT NULL,
	MasterId uniqueidentifier NULL,
	Code nvarchar(1999) NULL,
	Name nvarchar(1999) NULL,
	QuestionDescrip nvarchar(1999) NULL,--问题描述
	QuestionType nvarchar(1999) NULL,--问题类别
	RequireDate date null,--要求整改日期
	PartyBName nvarchar(1999) NULL,--参建单位
	PartyBId nvarchar(1999) NULL,--参建单位Id
	ContractId uniqueidentifier NULL,
	ContractCode nvarchar(1999) NULL,--合同编号
	ContractName nvarchar(1999) NULL,--合同名称
	Remarks nvarchar(max) NULL,
	Sequ int NULL,
	UpdDate datetime NULL,
)