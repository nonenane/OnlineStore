USE [dbase1]
GO
/****** Object:  StoredProcedure [OnlineStore].[getDataComboForCategory]    Script Date: 23.04.2021 12:00:49 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Author:		SPG
-- Create date: 2020-04-07
-- Description:	ѕолучение товаров используемых в категории
-- =============================================
ALTER PROCEDURE [OnlineStore].[getUseGoodsCategoryToMultyCategory]	
	@id_Category int
AS
BEGIN
	SET NOCOUNT ON;

select 
	c.id,
	trim(v.ean) as ean,
	trim(v.cname) as cname,
	v.id_otdel,
	v.id_grp1,
	v.id_grp2,
	c.id_Goods
from 
	[OnlineStore].[s_Goods_vs_Category] c
		inner join OnlineStore.s_Goods g on g.id = c.id_Goods
		inner join dbo.v_tovar v on v.id_tovar = g.id_Tovar
where
	c.id_Category =	@id_Category



END
