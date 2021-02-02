USE [PowerPMS_218_bak]
GO

/****** Object:  View [dbo].[View_CPL_OrderMat]    Script Date: 2018-1-11 10:50:43 ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO


ALTER VIEW [dbo].[View_CPL_OrderMat]
AS

select * from XLX_PUR_Request_List  a left join(
select Id as RequestId,Title as RequestTitle,RequestCode,RequestDate,ProMajor as RequestProMajor,IsUrgency,Order_Guid,PurchaseHuman,PurchaseHumanId
from xlx_pur_request) as b on  a.FK = b.RequestId


GO


