USE [dbase1]
GO
/****** Object:  StoredProcedure [OnlineStore].[get_tOrders]    Script Date: 14.09.2020 19:14:55 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Author:		SPorykhin Georgiy Yurievich
-- Create date: 11-02-2021
-- Description:	Получение списка заказов на текущую дату
-- =============================================
ALTER PROCEDURE [OnlineStore].[GetOrderNow]	
AS
BEGIN
	SET NOCOUNT ON;

DECLARE @isVOO bit = 0

CREATE TABLE #TovarToBuy (OrderNumber int, id_Tovar int, Price numeric(16,2),BasicPrice numeric(16,2),ShortName varchar(max))
	
INSERT INTO #TovarToBuy
	select 
		o.OrderNumber,
		g.id_Tovar,
		o.Price,
		g.BasicPrice,
		g.ShortName
	from 
		----OnlineStore.j_tOrders t
		----	left join OnlineStore.j_Orders o on o.id_tOrders = t.id		
		----	left join OnlineStore.s_Goods g on g.id_Tovar = o.id_Tovar

		OnlineStore.s_Goods  g
			left join (select o.id_Tovar,o.BasicPrice,t.OrderNumber,o.Price from  OnlineStore.j_Orders o inner join OnlineStore.j_tOrders t on t.id = o.id_tOrders where  cast(t.PlanDeliveryDate as date)  = cast(getdate() as date)) as o on g.id_Tovar = o.id_Tovar
	--where 
	--	cast(t.PlanDeliveryDate as date)  = cast(getdate() as date)

select 
	f.id_tovar,f.ntypeorg 
INTO 
	#ntypeorgTovar
from (
select  
	max(date) as date,
	id_tovar
from 
	[dbo].[goods_vs_firms]
where
	CAST(GETDATE() as date) >= date
	and 
	ntypeorg not in (6,17)									
group by
	id_tovar) as a inner join [dbo].[goods_vs_firms] f on f.id_tovar = a.id_tovar and f.date = a.date

select 
	ntypeorg ,id_departments
INTO 
	#ntypeorgDeps
from 
	[firms_vs_departments]
where
	DateStart < GETDATE() and DateEnd > GETDATE()
	and [default] = 1
order by id_departments

select 
	m.id_Post,
	m.nTypeOrg
INTO 
	#mainOrg
from  
	[dbo].[s_MainOrg] m
where 
	m.DateStart < GETDATE()
	and m.DateEnd > GETDATE()

select 
	tov.ean,
	tov.id_grp1,
	tov.id_otdel,
	tov.id as id_tovar,
	isnull(nTov.ntypeorg,nDeps.ntypeorg) as ntypeorg,
	cast(n.nds as int) as nds,
	tov.id_otdel as id_departments
INTO 
	#tableEAN
from dbo.s_tovar tov
	left join #ntypeorgTovar nTov on nTov.id_tovar = tov.id
	left join #ntypeorgDeps nDeps on nDeps.id_departments= tov.id_otdel
	left join dbo.s_nds n on n.id = tov.id_nds
where 
	(@isVOO = 1 and id_otdel = 6) or (@isVOO = 0 and id_otdel <> 6  )  

select
	tb.OrderNumber,
	t.ean,
	getdate() as r_time,
	tb.ShortName as name,	
	tb.Price as price,
	isnull(tb.BasicPrice,0.00) as BasicPrice,	
	t.id_grp1 as grp,
	t.nds as 'tax',
	case 
			when len(t.id_tovar) = 3 then '0'+cast(t.id_tovar as varchar(3))
			when len(t.id_tovar) = 2 then '00'+cast(t.id_tovar as varchar(2))
			else cast(t.id_tovar as varchar)
			end as id_tovar, 
	'' as kodVVO,
	p.cname as  firm,
	m.id_Post as id_post,	
	t.id_grp1,
	t.id_departments
from 
	#TovarToBuy tb
		left join #tableEAN t on t.id_tovar = tb.id_Tovar
		left join #mainOrg m on m.nTypeOrg = t.ntypeorg
		left join dbo.s_post p on p.id = m.id_Post

DROP TABLE #tableEAN, #ntypeorgTovar,#ntypeorgDeps,#mainOrg,#TovarToBuy



END