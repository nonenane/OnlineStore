
/****** Object:  StoredProcedure [Caramel].[delCaramelRoute]    Script Date: 07.04.2020 13:50:12 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Author:		S.G.Y.
-- Create date: 07-04-2020
-- Description:	Добавление,Редактирование, Удаление товара из справочника
-- =============================================
CREATE PROCEDURE [OnlineStore].[setDicGoods]	
		@id int,
		@id_tovar int = null,
		@ShortName varchar(50)=null,
		@FullName varchar(max) = null,
		@id_Category int = null,
		@BasicPrice numeric (16,2) = null,
		@StockPrice numeric (16,2) = null,		
		@isActive bit,
		@isInsert int  = null,
		@isAdd bit,
		@result int = null,
		@id_user int
AS
BEGIN
	SET NOCOUNT ON;

IF @isAdd = 1
	BEGIN
		IF @id = 0
			BEGIN
				INSERT INTO OnlineStore.s_Goods
				(id_Tovar,ShortName,FullName,id_Category,BasicPrice,StockPrice,isActive,isInsert,id_Creator,id_Editor,DateCreate,DateEdit)
				VALUES (@id_tovar,@ShortName,@FullName,@id_Category,@BasicPrice,@StockPrice,@isActive,@isInsert,@id_user,@id_user,GETDATE(),GETDATE())

				SELECT cast(SCOPE_IDENTITY() as int) as id
			END
		ELSE
			BEGIN
				UPDATE OnlineStore.s_Goods
				SET ShortName = @ShortName, FullName = @FullName,id_Category = @id_Category,
				BasicPrice  =@BasicPrice,StockPrice = @StockPrice,isActive = @isActive, id_Editor = @id_user,DateEdit = GETDATE()
				WHERE id = @id
				
				SELECT @id as id
			END
	END
ELSE
	BEGIN
		IF @result = 0
			BEGIN				
				DELETE OnlineStore.s_Goods where id = @id
			END
		ELSE
			BEGIN
				UPDATE OnlineStore.s_Goods 
				SET isActive  = @isActive,id_Editor = @id_user,DateEdit = GETDATE()
				WHERE id = @id
			END
	END

END
