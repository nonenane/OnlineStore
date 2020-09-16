USE [dbase1]
GO
/****** Object:  StoredProcedure [OnlineStore].[get_tOrders]    Script Date: 14.09.2020 19:14:55 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Author:		Sporykhin G Y
-- Create date: 16-09-2020
-- Description:	Получение данных по популярным товарам
-- =============================================
ALTER PROCEDURE [OnlineStore].[getPopularTovarInfo]	
	@dateStart datetime,
	@dateEnd datetime,
	@id_period int
AS
BEGIN
	SET NOCOUNT ON;

DECLARE @countOrder numeric(20,2)
	select @countOrder = count(t.id) from OnlineStore.j_tOrders t
	where  @dateStart <= t.DateOrder and t.DateOrder<=@dateEnd

select 	
	convert(varchar(12),@dateStart,104)+ ' - ' + convert(varchar(12),@dateEnd,104) as namePeriod,
	ltrim(rtrim(tov.ean)) as ean,
	count(t.id) as cntUseTovar,
	g.ShortName as cName,	
	sum(o.BasicPrice)/count(tov.ean) as midPrice,
	count(tov.ean) as countTovar,
	round(count(t.id)*100 / @countOrder,2) as prcBuy,
	o.id_Departments,
	@id_period as id_period
from 
	OnlineStore.j_tOrders t
		inner join OnlineStore.j_Orders o on o.id_tOrders = t.id
		inner join OnlineStore.s_Goods g on g.id_Tovar = o.id_Tovar
		inner join dbo.s_tovar tov on tov.id = o.id_Tovar
where 
	@dateStart <= t.DateOrder and t.DateOrder<=@dateEnd
group by 
	tov.ean,
	g.ShortName,
	o.id_Departments
END