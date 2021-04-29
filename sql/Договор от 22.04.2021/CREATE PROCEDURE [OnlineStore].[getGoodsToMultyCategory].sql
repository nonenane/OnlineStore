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
-- Description:	ѕолучение товаров дл€ добавлени€ в категории
-- =============================================
CREATE PROCEDURE [OnlineStore].[getGoodsToMultyCategory]	
	@id_deps int
AS
BEGIN
	SET NOCOUNT ON;

select 
	g.id,
	v.ean,
	v.cname,
	v.id_otdel,
	v.id_grp1,
	v.id_grp2
from 
	OnlineStore.s_Goods g 
		inner join dbo.v_tovar v on v.id_tovar = g.id_Tovar
where
	v.id_otdel = @id_deps 



END
