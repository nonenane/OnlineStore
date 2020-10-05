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
-- Description:	ѕолучение статистики по заказам за период
-- =============================================
ALTER PROCEDURE [OnlineStore].[getStasticOrder]	
	@dateStart datetime,
	@dateEnd datetime,
	@id_period int
AS
BEGIN
	SET NOCOUNT ON;


	DECLARE @table table (id_tOrders int ,id_Status int,Comment varchar(max))

	insert into @table
	select distinct
		s.id_tOrders,
		s.id_Status,
		s.Comment
	from(
	select 
		id_tOrders,
		max(DateEdit) as DateEdit
	from 
		OnlineStore.j_JournalStatus 
	group by id_tOrders) as a inner join OnlineStore.j_JournalStatus s on s.id_tOrders = a.id_tOrders and s.DateEdit = a.DateEdit
	where s.id_Status = 3

	select 
		a.id_period,	
		count(a.id) as cntOrder,
		sum(a.DeliveryCost) as DeliveryCost,
		sum(a.SummaDelivery) as SummaDelivery,
		sum(a.CountPackage) as CountPackage,
		sum(a.sumOrder) as sumOrder,
		sum(a.sumPackage) as sumPackage,
		sum(a.sumGoods) as sumGoods,
		0.0 as sumResult,
		0.0 as ostDelivery,
		0.0 as delta,
		'' as namePeriod
	from(
			Select 
				@id_period as id_period,
				o.id,
				o.OrderNumber,
				o.DeliveryDate,
				o.DeliveryCost,
				o.SummaDelivery,
				o.CountPackage,
				(select SUM(oo.Netto*oo.Price) from OnlineStore.j_Orders oo where oo.id_tOrders = o.id) as sumOrder,
				--oo.CheckNumber,
				--oo.KassNumber,
				--isnull(oo.Summa,0) as sumNote,
				(select isnull(sum(isnull(op.Summa,0)),0) from OnlineStore.Check_vs_Order op where op.id_tOrder = o.id and op.isPackage = 1) as sumPackage,			
				(select isnull(sum(isnull(op.Summa,0)),0) from OnlineStore.Check_vs_Order op where op.id_tOrder = o.id and op.isPackage = 0) as sumGoods			
			from 
				@table t
				inner join OnlineStore.j_tOrders o on o.id = t.id_tOrders
			where 
				--@dateStart<=cast(o.DateOrder as date) and cast(o.DateOrder as date)<=@dateEnd ) as a
				@dateStart<=cast(o.DeliveryDate as date) and cast(o.DeliveryDate as date)<=@dateEnd ) as a
	group by a.id_period

END