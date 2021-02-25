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
-- Description:	ѕолучение настроек по пользователю
-- =============================================
CREATE PROCEDURE [OnlineStore].[GetPropertyList]	
	@id_prog int,
	@id_user int,
	@id_val varchar(4) -- = 'bvso'
AS
BEGIN
	SET NOCOUNT ON;



select val from dbo.property_list where id_prog = @id_prog and id_user = @id_user and id_val = @id_val
	
END
