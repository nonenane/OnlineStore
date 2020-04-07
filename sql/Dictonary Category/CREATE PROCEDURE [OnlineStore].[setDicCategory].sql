
/****** Object:  StoredProcedure [Caramel].[delCaramelRoute]    Script Date: 07.04.2020 13:50:12 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Author:		S.G.Y.
-- Create date: 07-04-2020
-- Description:	Добавление,Редактирование, Удаление категории из справочника
-- =============================================
ALTER PROCEDURE [OnlineStore].[setDicCategory]	
		@id int,
		@cName varchar(max) = null,
		@id_dep int = null,
		@id_parentCategory int = null,
		@isActive bit,
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
				INSERT INTO OnlineStore.s_Category
				(NameCategory,id_Departments,id_ParentCategory,isActive,id_Creator,id_Editor,DateCreate,DateEdit)
				VALUES (@cName,@id_dep,@id_parentCategory,@isActive,@id_user,@id_user,GETDATE(),GETDATE())

				SELECT cast(SCOPE_IDENTITY() as int) as id
			END
		ELSE
			BEGIN
				UPDATE OnlineStore.s_Category
				SET NameCategory = @cName, id_Departments = @id_dep,id_ParentCategory = @id_parentCategory,id_Editor = @id_user,DateEdit = GETDATE()
				WHERE id = @id
				
				SELECT @id as id
			END
	END
ELSE
	BEGIN
		IF @result = 0
			BEGIN				
				DELETE OnlineStore.s_Category where id = @id
			END
		ELSE
			BEGIN
				UPDATE OnlineStore.s_Category 
				SET isActive  = @isActive,id_Editor = @id_user,DateEdit = GETDATE()
				WHERE id = @id
			END
	END

END
