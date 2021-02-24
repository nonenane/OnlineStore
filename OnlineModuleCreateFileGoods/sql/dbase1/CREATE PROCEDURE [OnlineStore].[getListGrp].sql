USE [dbase1]
GO
/****** Object:  StoredProcedure [sendFrontol].[getListGrp]    Script Date: 17.02.2021 12:19:48 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO


-- =============================================
-- Author:		<SGU>
-- Create date: <2016-06-28>
-- Description:	<Получение групп не по ЕГАИС>
-- =============================================

CREATE PROCEDURE [OnlineStore].[getListGrp] 

AS
BEGIN

select 
	id,
	ltrim(rtrim(cname)) as cname,
	id_otdel 
from 
	dbo.s_grp1 
--where 
--	id_otdel<>6

END



