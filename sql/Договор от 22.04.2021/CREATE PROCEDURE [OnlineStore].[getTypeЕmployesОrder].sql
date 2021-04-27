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
-- Description:	Получение отственных сотрудников для доставки по заказу
-- =============================================
ALTER PROCEDURE [OnlineStore].[getTypeЕmployesОrder]	
	 @id_tOrders int
AS
BEGIN
	SET NOCOUNT ON;

select
	t.id as idTypeЕmployesОrder,
	k.id,
	trim(k.lastname)+' '+isnull(substring(k.firstname,1,1)+'.','')+isnull(substring(k.secondname,1,1)+'.','') as FIO,
	t.Collector,
	t.KassCheck,
	t.Delivery
from 
	OnlineStore.j_TypeЕmployesОrder t
		left join dbo.s_kadr k on k.id = t.id_Kadr
where t.id_tOrders = @id_tOrders

END

