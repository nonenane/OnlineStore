USE [dbase1]
GO
/****** Object:  StoredProcedure [OnlineStore].[getGoods]    Script Date: 11.09.2020 13:32:50 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Author:		Sporykhin G Y
-- Create date: 2020-09-11
-- Description:	Запись процентов на наценку
-- =============================================
ALTER PROCEDURE [OnlineStore].[setPercentSettingsGroups]		
	@id int,
	@MarkUpPercent numeric(5,2) = null,
	@salePercent numeric(5,2) = null,
	@isGroup bit,
	@id_user int,
	@result int,
	@isDel bit
AS
BEGIN
	SET NOCOUNT ON;

BEGIN TRY
IF @isDel = 0
	BEGIN
		IF @isGroup = 1
			BEGIN
				IF NOT EXISTS (select id from OnlineStore.s_PercentSettingsGroups where id_grp2 = @id)
					BEGIN
						INSERT INTO OnlineStore.s_PercentSettingsGroups (id_grp2,MarkUpPercent,salePercent,DateCreate,DateEdit,id_Creator,id_Editor)
						values (@id,@MarkUpPercent,@salePercent,GETDATE(),GETDATE(),@id_user,@id_user)

						select cast(SCOPE_IDENTITY() as int ) as id
						return;
					END
				ELSE
					BEGIN
						UPDATE 
							OnlineStore.s_PercentSettingsGroups 
						set 
							MarkUpPercent=@MarkUpPercent,
							salePercent = @salePercent,
							DateEdit = GETDATE(),
							id_Editor = @id_user
						where
							id_grp2 = @id

						select @id as id
						return;
					END
				
			END
		ELSE
			BEGIN
				IF NOT EXISTS (select id from OnlineStore.s_PercentSettingsGoods where id_Tovar = @id)
					BEGIN
						INSERT INTO OnlineStore.s_PercentSettingsGoods (id_Tovar,MarkUpPercent,salePercent,DateCreate,DateEdit,id_Creator,id_Editor)
						values (@id,@MarkUpPercent,@salePercent,GETDATE(),GETDATE(),@id_user,@id_user)

						select cast(SCOPE_IDENTITY() as int ) as id
						return;
					END
				ELSE
					BEGIN
						UPDATE 
							OnlineStore.s_PercentSettingsGoods 
						set 
							MarkUpPercent=@MarkUpPercent,
							salePercent = @salePercent,
							DateEdit = GETDATE(),
							id_Editor = @id_user
						where
							id_Tovar = @id

						select @id as id
						return;
					END
			END
	END
ELSE
	BEGIN
		IF @isGroup = 1
			BEGIN
				IF NOT EXISTS (select id from OnlineStore.s_PercentSettingsGroups where id_grp2 = @id) and @result = 0
					BEGIN
						select -1 as id
						return
					END



					IF @result = 1
					BEGIN
						DELETE FROM OnlineStore.s_PercentSettingsGroups where id_grp2 = @id
						select @id as id
						return
					END else BEGIN select 0 as id; return; END

			END
		ELSE
			BEGIN
				IF NOT EXISTS (select id from OnlineStore.s_PercentSettingsGoods where id_Tovar = @id) and @result = 0
					BEGIN
						select -1 as id
						return
					END

				IF @result = 1
					BEGIN
						DELETE FROM OnlineStore.s_PercentSettingsGoods where id_Tovar = @id
						select @id as id
						return
					END else BEGIN select 0 as id; return; END

			END
	END
END TRY
BEGIN CATCH
	select -9999 as id, ERROR_MESSAGE() as msg
END CATCH

END
