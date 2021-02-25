SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO



ALTER FUNCTION [OnlineStore].[fGetPercentsTovar] (
	@id_tovar int,	
	@isSale bit
)
returns numeric(10,2) 
as
begin

	DECLARE 
		@id_grp2 int,
		@id_dep int

	select @id_grp2 = id_grp2, @id_dep = id_otdel from dbo.s_tovar where id = @id_tovar

	DECLARE @prc numeric(10,2) = null

	if exists (select * from OnlineStore.s_PercentSettingsGoods where id_Tovar = @id_tovar)
		BEGIN
			select @prc =  case when @isSale = 0 then MarkUpPercent else salePercent end from OnlineStore.s_PercentSettingsGoods where id_Tovar = @id_tovar	
		END
	else if exists (select * from OnlineStore.s_PercentSettingsGroups where id_grp2 = @id_grp2)
		BEGIN
			select @prc =  case when @isSale = 0 then MarkUpPercent else salePercent end from OnlineStore.s_PercentSettingsGroups where  id_grp2 = @id_grp2	
		END
	else if exists (select * from OnlineStore.s_SettingsPercent where id_Department = @id_dep)
		BEGIN
			select @prc =  case when @isSale = 0 then MarkUpPercent else salePercent end from OnlineStore.s_SettingsPercent where  id_Department = @id_dep		
		END

	IF @isSale = 0
		SET @prc =  case when @prc is null then 10 else @prc end
	ELSE
		SET @prc = case when @prc is null then null else @prc end
	
	return @prc
end;

