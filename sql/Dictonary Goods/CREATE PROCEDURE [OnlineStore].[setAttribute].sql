
/****** Object:  StoredProcedure [Caramel].[delCaramelRoute]    Script Date: 07.04.2020 13:50:12 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Author:		S.G.Y.
-- Create date: 13-04-2020
-- Description:	Добавление,Редактирование, аттрибутов товара
-- =============================================
ALTER PROCEDURE [OnlineStore].[setAttribute]	
		@id int,
		@id_Goods int,		
		@MinOrder numeric (16,2),
		@MaxOrder numeric (16,2),		
		@Step numeric (16,2),		
		@DefaultNetto numeric (16,2),		
		@PriceSuffix varchar(50),
		@QuantitySuffix varchar(50),
		@id_user int
AS
BEGIN
	SET NOCOUNT ON;

IF NOT exists (select id from  OnlineStore.s_AttributeGoods where id_Goods = @id_Goods)
	BEGIN
		INSERT INTO OnlineStore.s_AttributeGoods
		(id_Goods,MinOrder,MaxOrder,Step,DefaultNetto,PriceSuffix,QuantitySuffix,id_Creator,id_Editor,DateCreate,DateEdit)
		VALUES (@id_Goods,@MinOrder,@MaxOrder,@Step,@DefaultNetto,@PriceSuffix,@QuantitySuffix,@id_user,@id_user,GETDATE(),GETDATE())

		SELECT cast(SCOPE_IDENTITY() as int) as id
	END
ELSE
	BEGIN
		UPDATE OnlineStore.s_AttributeGoods
		SET id_Goods=@id_Goods,MinOrder=@MinOrder,MaxOrder=@MaxOrder,Step=@Step,DefaultNetto=@DefaultNetto,
		PriceSuffix=@PriceSuffix,QuantitySuffix=@QuantitySuffix, id_Editor = @id_user,DateEdit = GETDATE()
		WHERE id_Goods = @id_Goods
				
		SELECT @id as id
	END


END
