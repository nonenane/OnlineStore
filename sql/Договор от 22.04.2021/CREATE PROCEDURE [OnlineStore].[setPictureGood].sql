USE [dbase1]
GO
/****** Object:  StoredProcedure [OnlineStore].[getDataComboForCategory]    Script Date: 23.04.2021 12:00:49 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Author:		Sporykhin G.Y.
-- Create date: 2021-04-27
-- Description:	Изменения наличия картинки у товара
-- =============================================
CREATE PROCEDURE [OnlineStore].[setPictureGood]	
	@id_good int,
	@isPicture bit
AS
BEGIN
	SET NOCOUNT ON;

	UPDATE OnlineStore.s_Goods set isPicture = @isPicture where id = @id_good

END
