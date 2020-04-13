
/****** Object:  StoredProcedure [Caramel].[delCaramelRoute]    Script Date: 07.04.2020 13:50:12 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Author:		S.G.Y.
-- Create date: 07-04-2020
-- Description:	Установка статуса отправки товара на сайт
-- =============================================
CREATE PROCEDURE [OnlineStore].[setInsertGoods]	
		@id int,
		@id_user int
AS
BEGIN
	SET NOCOUNT ON;

	UPDATE  OnlineStore.s_Goods set isInsert = 1 , DateEdit = GETDATE(),id_Editor = @id_user
	where id = @id

END
