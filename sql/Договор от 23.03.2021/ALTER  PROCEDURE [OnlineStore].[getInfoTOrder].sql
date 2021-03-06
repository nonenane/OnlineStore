USE [dbase1]
GO
/****** Object:  StoredProcedure [OnlineStore].[getInfoTOrder]    Script Date: 23.03.2021 9:33:27 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Author:		KAV
-- Create date: 2020-11-19/2020-12-16
-- Description:	Загрузка информации о заказе
-- =============================================
ALTER  PROCEDURE [OnlineStore].[getInfoTOrder]	
	@id_tOrder int
AS
BEGIN
	SET NOCOUNT ON;

	select	t.id,
			OrderNumber,
			DateOrder,
			LastnameBuyer + ' ' + NameBuyer as FIO,
			(select sum(Price) from OnlineStore.j_Orders where id_tOrders = @id_tOrder) as sumOrder,
			SummaDelivery,
			p.cName as namePayment,
			t.LastnameBuyer,
			t.NameBuyer,
			t.Email,
			t.Phone
	from OnlineStore.j_tOrders t
	left join OnlineStore.s_Payment p on t.id_Payment = p.id
	where t.id = @id_tOrder
END