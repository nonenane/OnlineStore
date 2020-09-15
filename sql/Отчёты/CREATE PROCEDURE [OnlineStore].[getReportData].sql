USE [dbase1]
GO
/****** Object:  StoredProcedure [OnlineStore].[getGoods]    Script Date: 11.09.2020 13:32:50 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Author:		Sporykhin G Y
-- Create date: 2020-09-14
-- Description:	Получение данных для отчёта
-- =============================================
ALTER PROCEDURE [OnlineStore].[getReportData]			
		@dateStart date, 
		@dateEnd date,
		@id_status int 
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
where s.id_Status = @id_status


IF @id_status = 4
	BEGIN
		Select 
			o.OrderNumber,
			o.DateOrder,
			(select SUM(oo.Netto*oo.Price) from OnlineStore.j_Orders oo where oo.id_tOrders = o.id) as sumOrder,
			t.Comment			
		from 
			@table t
			inner join OnlineStore.j_tOrders o on o.id = t.id_tOrders
		where 
			@dateStart<=o.DateOrder and o.DateOrder<=@dateEnd

		return;
	END
ELSE IF @id_status = 3
	BEGIN
		Select 
			o.OrderNumber,
			o.DeliveryDate,
			o.DeliveryCost,
			o.SummaDelivery,
			o.CountPackage,
			(select SUM(oo.Netto*oo.Price) from OnlineStore.j_Orders oo where oo.id_tOrders = o.id) as sumOrder,
			oo.CheckNumber,
			oo.KassNumber,
			isnull(oo.Summa,0) as sumNote,
			(select isnull(sum(isnull(op.Summa,0)),0) from OnlineStore.Check_vs_Order op where op.id_tOrder = o.id and op.isPackage = 1) as sumPackage			
		from 
			@table t
			inner join OnlineStore.j_tOrders o on o.id = t.id_tOrders
			inner join OnlineStore.Check_vs_Order oo on oo.id_tOrder = o.id and (oo.isPackage = 0 or oo.isPackage is null)
			--left join OnlineStore.Check_vs_Order op on op.id_tOrder = o.id and op.isPackage = 1
		where 
			@dateStart<=o.DeliveryDate and o.DeliveryDate<=@dateEnd

	END
END
