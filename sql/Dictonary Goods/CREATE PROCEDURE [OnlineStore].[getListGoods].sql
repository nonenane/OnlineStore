
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Author:		SPG
-- Create date: 2020-04-07
-- Description:	Получение продаваемых товаров онлайн
-- =============================================
ALTER PROCEDURE [OnlineStore].[getListGoods]	
	@id_deps int 
AS
BEGIN
	SET NOCOUNT ON;

select 
	g.id, 
	g.id_Tovar,
	ltrim(rtrim(t.ean)) as ean,
	g.ShortName,
	ltrim(rtrim(c.NameCategory)) as nameCategory,
	cast(0 as numeric(17,3)) as countOnlineSell,
	0 as moveNow,
	0 as ostNow,
	(select TOP(1) rcena from dbo.s_rcena r where r.id_tovar = g.id_Tovar and tdate_n<GETDATE() order by tdate_n desc) as rcena,
	g.BasicPrice as rcenaOnline,
	isnull(g.StockPrice,0) as rcenaPromo,
	t.id_grp1,
	t.id_grp2,
	g.id_Category,
	g.isActive,
	g.FullName,
	t.id_otdel
from 
	OnlineStore.s_Goods g
		left join dbo.s_tovar t on t.id = g.id_Tovar
		left join OnlineStore.s_Category c on c.id = g.id_Category		
where 
	@id_deps = 0 or t.id_otdel  = @id_deps

END
