
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Author:		SPG
-- Create date: 2020-04-07
-- Description:	ѕолучение данных дл€ выпадающих списков
-- =============================================
ALTER PROCEDURE [OnlineStore].[getDataComboForCategory]	
	@isDep bit = null,
	@isCategory bit = null
AS
BEGIN
	SET NOCOUNT ON;

IF @isDep is not null
	BEGIN		
		SELECT cast(id as int) as id , ltrim(rtrim(name)) as cName 
		from dbo.departments
		where ldeyst = 1 and if_comm = 1
	END
ELSE IF @isCategory is not null
	BEGIN
		select null as id,'' as cName
		union all
		select id,ltrim(rtrim(NameCategory)) as cName 
		from OnlineStore.s_Category
		where id_ParentCategory is null
	END

END
