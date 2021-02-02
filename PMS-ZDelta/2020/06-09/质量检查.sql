--�������
CREATE TABLE ZDelta_Qlty_InspectionNotice(
	Id uniqueidentifier NOT NULL,
	Code nvarchar(1999) NULL,
	Title nvarchar(1999) NULL,
	InspectionDeptName nvarchar(1999) NULL,--��鲿��
	InspectionDeptId uniqueidentifier NULL,
	InspectionHumanName nvarchar(1999) NULL,--�����Ա
	InspectionHumanId nvarchar(1999) NULL,--�����Ա
	InspectionDate datetime null,--�������
)
CREATE TABLE ZDelta_Qlty_InspectionNoticeDtl(
	Id uniqueidentifier NOT NULL,
	MasterId uniqueidentifier NULL,
	Code nvarchar(1999) NULL,
	Name nvarchar(1999) NULL,
	QuestionDescrip nvarchar(1999) NULL,--��������
	QuestionType nvarchar(1999) NULL,--�������
	RequireDate date null,--Ҫ����������
	PartyBName nvarchar(1999) NULL,--�ν���λ
	PartyBId nvarchar(1999) NULL,--�ν���λId
	ContractId uniqueidentifier NULL,
	ContractCode nvarchar(1999) NULL,--��ͬ���
	ContractName nvarchar(1999) NULL,--��ͬ����
	Remarks nvarchar(max) NULL,
	Sequ int NULL,
	UpdDate datetime NULL,
)