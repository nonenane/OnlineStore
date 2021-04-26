USE [dbase1]
GO
/****** Object:  StoredProcedure [OnlineStore].[getDataComboForCategory]    Script Date: 23.04.2021 12:00:49 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Author:		SPG
-- Create date: 2021-04-23
-- Description:	«апись данных по св€занным категорий дл€ товара
-- =============================================
CREATE PROCEDURE [OnlineStore].[setGoodsVsCategory]	
	@id int = null,
	@id_Goods int,
	@id_Category int,
	@idUser int
AS
BEGIN
	SET NOCOUNT ON;

IF not Exists ( select * from OnlineStore.s_Goods_vs_Category where id_Goods = @id_Goods and id_Category = @id_Category) and @id is  null
	BEGIN
		INSERT INTO OnlineStore.[s_Goods_vs_Category] (id_Goods,id_Category,id_Editor,DateEdit) values (@id_Goods,@id_Category,@idUser,GETDATE())
		return
	END
ELSE
	IF @id is not null 
		BEGIN
			delete from OnlineStore.s_Goods_vs_Category where id_Goods = @id_Goods and id_Category = @id_Category and id = @id
			return
		END

END
