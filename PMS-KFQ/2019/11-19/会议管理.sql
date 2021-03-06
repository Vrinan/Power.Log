CREATE TABLE KFQ_ZH_MeetingManage(
	Id uniqueidentifier NOT NULL,
	Code nvarchar(max) NULL,
	Title nvarchar(max) NULL,
	UpdHumId uniqueidentifier NULL,
	UpdHuman nvarchar(max) NULL,
	UpdDate datetime NULL,
	RegDate datetime NULL,
	RegHumName nvarchar(max) NULL,
	RegHumId uniqueidentifier NULL,
	OwnProjName nvarchar(max) NULL,
	OwnProjId uniqueidentifier NULL,
	EpsProjId uniqueidentifier NULL,
	ApprHumId uniqueidentifier NULL,
	ApprHumName nvarchar(max) NULL,
	ApprDate datetime NULL,
	Status tinyint NULL,
	Memo nvarchar(max) NULL,
	MeetingRoom nvarchar(max) null,
	Convener nvarchar(max) null,
	ConvenerId uniqueidentifier null,
	BeginDate datetime null,
	EndDate datetime null,
	UndertakeDept nvarchar(max) null,
	UndertakeDeptId uniqueidentifier null,
	Attendants nvarchar(max) null,
	AttendantsIds nvarchar(max) null,
	OutAttendants nvarchar(max) null,
	OutAttendantsIds nvarchar(max) null,
)