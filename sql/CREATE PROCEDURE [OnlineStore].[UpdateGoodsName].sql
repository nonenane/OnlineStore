USE [dbase1]
GO
/****** Object:  StoredProcedure [OnlineStore].[setGoodsByGroups]    Script Date: 06.10.2020 12:16:31 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Author:		Sporykhin G.Y.
-- Create date: 2021-02-19
-- Description:	Обновление наименования товаров
-- =============================================
CREATE PROCEDURE [OnlineStore].[UpdateGoodsName]	
	@id int,
	@ShortName varchar(150),
	@ShortDescription varchar(1500),
	@FullName varchar(150)
AS
BEGIN
	SET NOCOUNT ON;

	UPDATE 
		OnlineStore.s_Goods
	SET 
		ShortName  = ShortName,
		ShortDescription = ShortDescription,
		FullName = FullName
	WHERE
		id = @id
	
END