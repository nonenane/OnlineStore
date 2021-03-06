USE [dbase1]
GO
/****** Object:  StoredProcedure [OnlineStore].[setGoodsOnlinePrice]    Script Date: 18.09.2020 9:29:59 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Author:		K.A.V.
-- Create date: 2020-04-22
-- Description:	Изменение цен товаров с учетом наценки (id_dep если по отделу, id если по товарам)
-- UPD:			ooooops, забыл при обновлении запихать id_user и дату обновления :) (2020-05-07 KAV)
-- UPD:			2020-05-08 (KAV) махинации со StockPrice - если там базовая по скидке меньше новой базовой, то в сток пишем старую базовую, а иначе пардоньте
-- =============================================
ALTER PROCEDURE [OnlineStore].[setGoodsOnlinePrice]	
		@id varchar(max) = null,
		@id_dep int = null,
		@id_prog int,
		@id_user int,
		@useSale bit
AS
BEGIN
	SET NOCOUNT ON;
    -- УСТАРЕЛО )))

	if (@id_dep is null)
	begin
		--парсим строку с idшниками
		select @id='select ''' + replace(@id,',',''' as id_tovar union all select ''') + ''''
		declare @t table (id int identity, id_tovar int)
		insert into @t
		exec (@id)
		--update базы, где id_tovar в распаршенной @id
		update OnlineStore.s_Goods 
		--если у нас распродажа И старая базовая цена*100/(100+процент распродажи)>=цена с наценкой то 
		set BasicPrice = round( (select TOP(1) rcena from dbo.s_rcena r where r.id_tovar=id_Tovar and tdate_n<GETDATE() order by tdate_n desc) * 
		(([OnlineStore].[fGetPercentsTovar](id_Tovar,0)) +100 )/100,2,1)
		, StockPrice = case when (@useSale=1 and
		
		round (  (BasicPrice*(100 - ([OnlineStore].[fGetPercentsTovar](id_Tovar,1))/100 )),2,1)>= 

					round( (select TOP(1) rcena from dbo.s_rcena r	where r.id_tovar=id_Tovar 
																	and tdate_n<GETDATE() order by tdate_n desc)*
					 ( 100 + ([OnlineStore].[fGetPercentsTovar](id_Tovar,0))/100),2,1))
				then BasicPrice else null end,
			id_Editor = @id_user,
			DateEdit = GETDATE()	
		where id_Tovar in (select id_tovar from @t)
	end
	else
	begin
		--update базы, где у товара с id закинутой id_dep (если ноль закинули, то все апдейтятся)
		update OnlineStore.s_Goods
		set BasicPrice = round( (select TOP(1) rcena from dbo.s_rcena r where r.id_tovar=id_Tovar and tdate_n<GETDATE() order by tdate_n desc)* 
		( ([OnlineStore].[fGetPercentsTovar](id_Tovar,0)) +100 )/100,2,1)
		
		,StockPrice = case when (@useSale=1 and 
				round (  (BasicPrice*(100 - ([OnlineStore].[fGetPercentsTovar](id_Tovar,1))/100 )),2,1)>= 				
					round( (select TOP(1) rcena from dbo.s_rcena r	where r.id_tovar=id_Tovar 
																	and tdate_n<GETDATE() order by tdate_n desc)*
					 ( 100 + ([OnlineStore].[fGetPercentsTovar](id_Tovar,0))/100),2,1))
				then BasicPrice else null end,		
		id_Editor = @id_user,
		DateEdit = GETDATE()
		where OnlineStore.s_Goods.id_Tovar in (select id from dbo.s_tovar st where st.id_otdel=@id_dep or @id_dep=0)
	end

END


