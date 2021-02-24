USE [dbase1]
GO
/****** Object:  StoredProcedure [xpos].[getSettings]    Script Date: 30.11.2020 23:15:09 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Author:		Sporykhyn G.Y.
-- Create date: 2020-11-30
-- Description:	Получение настроек
-- =============================================
CREATE PROCEDURE [OnlineStore].[getSettings]	
	@id_prog int,
	@id_value varchar(4)
AS
BEGIN
	SET NOCOUNT ON;

	select value from dbo.prog_config where id_prog = @id_prog and id_value= @id_value
	
END
