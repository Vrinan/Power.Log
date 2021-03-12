create table PS_ToMapAndUse
(
	Id uniqueidentifier null,
	Code nvarchar(max) null,
	ProjName nvarchar(max) null,
	NameOfDrawing nvarchar(max) null,
	PSWBSId uniqueidentifier null,
	PSWBSCode nvarchar(max) null,
	PSWBSName nvarchar(max) null,
	DesignUnit nvarchar(max) null,
	DrawingNumber nvarchar(max) null,
	TypeOfDrawing nvarchar(max) null,
	ToMapAndUseNumber numeric(23,2) null,
	ArkNumber nvarchar(max) null,
	DrawingToDrawDate datetime null,
	NumberOfDrawings numeric(23,2) null
)