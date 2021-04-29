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
-- Description:	Обновление комментария к заказу
-- =============================================
CREATE PROCEDURE [OnlineStore].[setCommenttOrder]	
	 @id_tOrders int,
	 @comment varchar(max)
AS
BEGIN
	SET NOCOUNT ON;

	UPDATE OnlineStore.j_tOrders set Comment = @comment where id = @id_tOrders

END

