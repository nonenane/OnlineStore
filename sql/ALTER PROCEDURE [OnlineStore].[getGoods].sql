USE [dbase1]
GO
/****** Object:  StoredProcedure [OnlineStore].[getGoods]    Script Date: 27.10.2020 15:02:10 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Author:		SPG
-- Create date: 2020-04-07
-- Description:	Получение товара по EAN
-- Update:		2020-05-08 подпихивается процент наценки для товара (KAV)
-- =============================================
ALTER PROCEDURE [OnlineStore].[getGoods]	
	@ean varchar(13),
	@id_deps int
AS
BEGIN
	SET NOCOUNT ON;


declare @id_tovar int, @ntypetovar int, @rcena numeric(17,2), @cName varchar(max), @id_dep_tovar int, @percent numeric (16,2)

select 
	@id_tovar = id ,@id_dep_tovar = id_otdel
from 
	dbo.s_tovar 
where 
	ltrim(rtrim(ean)) = ltrim(rtrim(@ean)) and (@id_deps=0 or id_otdel = @id_deps)
	--UPD:
	select @percent  = MarkUpPercent
		from OnlineStore.s_SettingsPercent
		where id_Department = @id_dep_tovar
if(@id_tovar is null)
	begin
		select -1 as id
		return;
	end




select 
	top(1) @ntypetovar = ntypetovar,  @cName = ltrim(rtrim(cname))
from 
	dbo.s_ntovar
where id_tovar = @id_tovar and tdate_n<=GETDATE()
order by tdate_n desc


if(@ntypetovar!=0 or @ntypetovar is null)
	begin
		select -2 as id
		return;
	end

select 
	TOP(1) @rcena = rcena 
from 
	dbo.s_rcena where id_tovar = @id_tovar and tdate_n<=GETDATE()
order by tdate_n desc

select
	0 as id,
	@id_tovar as id_tovar,
	@cName as cNameShort,
	dbo.f_SprGetFullNameTovar (@id_tovar) as cNameFull,
	@rcena as rcena,
	@id_dep_tovar as id_otdel,
	[OnlineStore].[fGetPercentsTovar](@id_tovar,0) as MarkUpPercent

END
