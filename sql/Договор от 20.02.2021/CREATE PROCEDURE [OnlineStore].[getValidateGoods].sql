USE [dbase1]
GO
/****** Object:  StoredProcedure [OnlineStore].[getGoods]    Script Date: 27.10.2020 15:02:10 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Author:		Sporykhin G.Y.
-- Create date: 2021-02-19
-- Description:	Получение различия по товарам на кассе и онлайн магазине
-- =============================================
ALTER PROCEDURE [OnlineStore].[getValidateGoods]	
AS
BEGIN
	SET NOCOUNT ON;

	
select 
	cast(0 as bit) as isSelect,
	t.id_tovar,
	trim(t.ean) as ean,
	trim(t.cname) as nameTovarTerminal,
	trim(g.ShortName) as nameTovarOnlineStore,
	t.id_otdel,
	t.id_grp1,
	t.id_grp2,
	g.id
from 
	dbo.v_tovar t 
		left join OnlineStore.s_Goods g on g.id_Tovar = t.id_tovar and trim(g.ShortName) not like trim(t.cname)
where g.id is not null and g.isActive = 1

END
