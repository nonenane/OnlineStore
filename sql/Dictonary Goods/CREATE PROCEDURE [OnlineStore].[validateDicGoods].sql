
/****** Object:  StoredProcedure [Caramel].[validateCaramelTRoute]    Script Date: 07.04.2020 13:52:57 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Author:		S.G.Y.
-- Create date: 07-04-2020
-- Description:	Проверка на добавление и удаление товара из справочника товаров
-- =============================================
ALTER PROCEDURE [OnlineStore].[validateDicGoods]	
		@id int,		
		@id_tovar int = null
AS
BEGIN
	SET NOCOUNT ON;
 IF @id_tovar is not null
	 BEGIN
		IF EXISTS(select id from OnlineStore.s_Goods where id <> @id and id_Tovar = @id_tovar)
			BEGIN
				select -1 as id;
				return;
			END
		ELSE
			BEGIN
				select 0 as id;
				return;
			END
	END
ELSE
	BEGIN
		IF NOT EXISTS (select id from OnlineStore.s_Goods where id = @id)
			BEGIN
				select -1 as id;
				return
			END

		--IF EXISTS (select * from OnlineStore.s_Goods where id_ParentCategory = @id )
		--	BEGIN
		--		select -2 as id;
		--		return
		--	END
	
		select 0 as id;
	END
END
