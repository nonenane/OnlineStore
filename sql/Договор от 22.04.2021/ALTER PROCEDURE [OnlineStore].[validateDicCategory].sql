USE [dbase1]
GO
/****** Object:  StoredProcedure [OnlineStore].[validateDicCategory]    Script Date: 22.04.2021 13:33:11 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Author:		S.G.Y.
-- Create date: 07-04-2020
-- Description:	Проверка категории для удаления
-- Update:		Комментирована проверка (Света сказала)
-- update:		kav 2021-01-05 проверка при добавлении родительской категории
-- =============================================
ALTER PROCEDURE [OnlineStore].[validateDicCategory]	
		@id int,		
		@cName	varchar(max) = null,
		@id_ParentCategory int = null
AS
BEGIN
	SET NOCOUNT ON;
 IF @cName is not null
	 BEGIN
		IF EXISTS(select id from OnlineStore.s_Category where id <> @id and NameCategory = @cName)
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
		IF NOT EXISTS (select id from OnlineStore.s_Category where id = @id)
			BEGIN
				select -1 as id;
				return
			END

		--IF EXISTS (select * from OnlineStore.s_Category where id_ParentCategory = @id )
		--	BEGIN
		--		select -2 as id;
		--		return
		--	END

		IF EXISTS (select * from OnlineStore.s_Goods where id_Category = @id and @id_ParentCategory is null)
			BEGIN
				select -2 as id;
				return
			END

		--при подкидывании родительской категори надо проверять отсутствие товаров у родительской категории
		if exists (select * from OnlineStore.s_Goods where @id_ParentCategory is not null and id_Category = @id_ParentCategory)
		begin
			select -3 as id
			return
		end
		select 0 as id;
	END
END

--select * from OnlineStore.s_Category where NameCategory = 'Конфеты'

--select * from OnlineStore.s_Goods where id_Category = 6
