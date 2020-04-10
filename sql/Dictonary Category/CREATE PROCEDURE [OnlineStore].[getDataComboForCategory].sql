
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
	@isCategory bit = null,
	@id_deps int = 0,
	@isTu bit = null,
	@isInv bit = null
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
		select null as id,'' as cName, 0 as id_Departments
		union all
		select id,ltrim(rtrim(NameCategory)) as cName,id_Departments
		from OnlineStore.s_Category
		where id_ParentCategory is null and (@id_deps=0 or id_Departments = @id_deps)
	END
ELSE IF @isTu is not null
	BEGIN
		select 0 as id, '' as cName
		union all
		select id,ltrim(rtrim(cname)) as cName from dbo.s_grp1 where id_otdel = @id_deps and ldeystv = 1
		order by id asc
	END
ELSE IF @isInv is not null
	BEGIN
		select 0 as id, '' as cName
		union all
		select id,ltrim(rtrim(cname)) as cName from dbo.s_grp2 where id_otdel = @id_deps and ldeystv = 1
		order by id asc
	END

END
