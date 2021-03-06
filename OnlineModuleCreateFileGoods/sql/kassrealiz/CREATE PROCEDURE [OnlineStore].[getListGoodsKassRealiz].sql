USE [KassRealiz]
GO
/****** Object:  StoredProcedure [sendFrontol].[getListGoodsKassRealiz]    Script Date: 17.02.2021 12:16:27 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO


-- =============================================
-- Description:	<Получение списка актуальных товаров из goods_updates>
-- =============================================

CREATE PROCEDURE [OnlineStore].[getListGoodsKassRealiz] 

AS
BEGIN

select
	g.id,
	g.r_time,
	ltrim(rtrim(g.ean)) as ean,
	isnull(ltrim(rtrim(g.name)),'') as name,
	isnull(g.price/100.0,0.0) as price,
	cast(g.grp as int) as grp,
	--g.tax,
	cast(case when g.tax<>20 then g.tax else 18 end as int)  as tax,
	g.id_departments
from 
	dbo.goods_updates g
where 
	ActualRow = 1

END



