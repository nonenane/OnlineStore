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
-- Description:	Проверка на заполненость сотрудников по заказу
-- =============================================
CREATE PROCEDURE [OnlineStore].[validateypeЕmployesОrder]	
	 @id_tOrders int
AS
BEGIN
	SET NOCOUNT ON;

if not exists(select * from OnlineStore.j_TypeЕmployesОrder where id_tOrders = @id_tOrders and Collector = 1)	BEGIN select -1 as id,'' as msg return END
if not exists(select * from OnlineStore.j_TypeЕmployesОrder where id_tOrders = @id_tOrders and KassCheck = 1)	BEGIN select -1 as id,'' as msg return END
if not exists(select * from OnlineStore.j_TypeЕmployesОrder where id_tOrders = @id_tOrders and Delivery = 1)	BEGIN select -1 as id,'' as msg return END

select 0 as id,'' as msg
END

