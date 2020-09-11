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
-- Description:	ѕолучение товаров с ссылкой на наценку
-- =============================================
ALTER PROCEDURE [OnlineStore].[getGoodsVsPercentSettingsGoods]	
	
AS
BEGIN
	SET NOCOUNT ON;

select 
	t.id,
	t.id_otdel,
	t.id_grp1,
	t.id_grp2,
	ltrim(rtrim(t.ean)) as ean,
	ltrim(rtrim(isnull(tv.cName+' ','')+ ltrim(rtrim(tt.cname)))) as cName,
	p.MarkUpPercent,
	p.salePercent,
	p.id as id_percent
from 
	dbo.s_tovar  t
		left join [OnlineStore].[s_PercentSettingsGoods] p on p.id_Tovar = t.id
		left join dbo.v_tovar tt on tt.id_tovar = t.id
		left join dbo.s_TypeTovar tv on tv.id = tt.ntypetovar 
--order by t.id_otdel asc, t.ean asc

END