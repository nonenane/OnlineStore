USE [dbase1]
GO
/****** Object:  StoredProcedure [OnlineStore].[getGoods]    Script Date: 11.09.2020 13:32:50 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Author:		Sporykhin G Y
-- Create date: 2020-09-11
-- Description:	Получение групп с ссылкой на наценку
-- =============================================
ALTER PROCEDURE [OnlineStore].[getGrp2VsPercentSettingsGroups]		
AS
BEGIN
	SET NOCOUNT ON;

	select 
	g.id,
	g.id_otdel,
	ltrim(rtrim(g.cname)) as cName,
	p.MarkUpPercent,
	p.salePercent,
	p.id as id_percent
from 
	dbo.s_grp2 g
		left join [OnlineStore].[s_PercentSettingsGroups] p on p.id_grp2 = g.id
where 
	g.ldeystv = 1

END
