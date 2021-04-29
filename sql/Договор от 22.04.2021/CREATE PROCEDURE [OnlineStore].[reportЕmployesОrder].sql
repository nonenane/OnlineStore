USE [dbase1]
GO
/****** Object:  StoredProcedure [OnlineStore].[get_tOrders]    Script Date: 27.04.2021 13:17:25 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Author:		Sporykhin G.Y.
-- Create date: 2021-04-27
-- Description:	Получение отчёта по сотрудникам которые обрабатывали заказ
-- =============================================
ALTER PROCEDURE [OnlineStore].[reportЕmployesОrder]	
	 @dateStart date, 
	 @dateEnd date
AS
BEGIN
	SET NOCOUNT ON;

	
select 
	t.id,
	t.OrderNumber,
	isnull(t.DeliveryDate,getdate()) as DeliveryDate,
	e.id_Kadr,
	trim(k.lastname)+' '+isnull(substring(k.firstname,1,1)+'.','')+isnull(substring(k.secondname,1,1)+'.','') as FIO,
	(select  count(*) from OnlineStore.j_Orders o where o.id_tOrders = t.id and o.Netto>0)  as countRow,
	e.Collector,
	e.KassCheck,
	e.Delivery
	from 
	OnlineStore.j_tOrders t
		inner join OnlineStore.j_TypeЕmployesОrder e on e.id_tOrders = t.id
		inner join dbo.s_kadr k on k.id = e.id_Kadr
where 
	@dateStart<= t.DeliveryDate and t.DeliveryDate <=@dateEnd


END

