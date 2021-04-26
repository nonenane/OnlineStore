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
-- Description:	ѕолучение данных по св€занным категорий дл€ товара
-- =============================================
ALTER PROCEDURE [OnlineStore].[getGoodsVsCategory]	
	@id_goods int
AS
BEGIN
	SET NOCOUNT ON;

	select 
	g.id,
	g.id_Category,
	c.NameCategory as cName
from 
	OnlineStore.[s_Goods_vs_Category]  g
		left join OnlineStore.s_Category c on c.id = g.id_Category
where 
	g.id_Goods = @id_goods


END
