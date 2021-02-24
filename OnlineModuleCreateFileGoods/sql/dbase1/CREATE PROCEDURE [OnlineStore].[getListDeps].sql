USE [dbase1]
GO
/****** Object:  StoredProcedure [sendFrontol].[getListDeps]    Script Date: 17.02.2021 12:19:17 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO


-- =============================================
-- Description:	<Получение списка отделов>
-- =============================================

CREATE PROCEDURE [OnlineStore].[getListDeps] 

AS
BEGIN

select 
	id,
	rtrim(name) as name 
from 
	[departments] 
where  
	if_comm =1 and ldeyst=1

END



