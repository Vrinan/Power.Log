

CREATE TABLE FeedBack(
	uniqueid int IDENTITY(1,1) NOT NULL,
	model nvarchar(200) null,
	descripe nvarchar(2000) null,
	advice nvarchar(2000) null,
	feedTime datetime null,
	adviceName nvarchar(200) null
)
