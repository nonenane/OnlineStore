
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Author:		SPG
-- Create date: 2020-04-07
-- Description:	Получение списка категорий
-- =============================================
ALTER PROCEDURE [OnlineStore].[getDicCategory]	
	 @id int = null,
	 @id_deps int 
AS
BEGIN
	SET NOCOUNT ON;


IF @id is null
	BEGIN
		select 
			c.id,
			ltrim(rtrim(c.NameCategory)) as cName,
			ltrim(rtrim(d.name)) as nameDep,
			ltrim(rtrim(isnull(cc.NameCategory,''))) as cNameParent,
			c.isActive
		from 
			OnlineStore.s_Category c
				left join dbo.departments d on d.id = c.id_Departments
				left join OnlineStore.s_Category cc on cc.id = c.id_ParentCategory
		where 
			c.id_Departments = @id_deps or @id_deps = 0
	END
ELSE
	BEGIN
		select 			
			ltrim(rtrim(c.NameCategory)) as cName,
			ltrim(rtrim(d.name)) as nameDep,
			ltrim(rtrim(isnull(cc.NameCategory,''))) as cNameParent,
			c.isActive,
			c.id_ParentCategory,
			c.id_Departments
		from 
			OnlineStore.s_Category c
				left join dbo.departments d on d.id = c.id_Departments
				left join OnlineStore.s_Category cc on cc.id = c.id_ParentCategory
		where c.id = @id
	END
END
