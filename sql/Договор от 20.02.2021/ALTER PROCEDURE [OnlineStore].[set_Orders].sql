USE [dbase1]
GO
/****** Object:  StoredProcedure [OnlineStore].[set_Orders]    Script Date: 25.02.2021 11:52:44 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Author:		KAV
-- Create date: 14-04-2020
-- Description:	Добавление заказа в j_Orders и в журнал
-- Update:		28-04-2020 (KAV) - id отдела берется из s_tovar
-- Update:		01-06-2020 (KAV) - поле NettoStore - кол-во товара с сайта (не изменяется)
-- =============================================
ALTER PROCEDURE [OnlineStore].[set_Orders]	
	@id_tOrder int,
	@id_tovar int,
	@category varchar(max),
	@position int,
	@netto numeric(16,3),
	@price numeric(16,2),
	@id_person int
AS
BEGIN
	SET NOCOUNT ON;

	declare @id_dep int
	set @id_dep = (select top(1) id_otdel from dbo.s_tovar where id = @id_tovar)
	
	if not exists (select id from OnlineStore.j_Orders where id_tOrders=@id_tOrder and id_Tovar=@id_tovar)
	begin
	insert into OnlineStore.j_Orders 
		(id_Tovar,
		id_tOrders,
		id_Departments,
		Position,
		Netto,
		Price,
		DateCreate,
		id_Creator,
		DateEdit,
		id_Editor,
		NettoStore)
		values
		(@id_tovar, @id_tOrder, @id_dep,@position,@netto,@price,getdate(),@id_person,GETDATE(),@id_person, @netto)
	end
	else
		begin
			update OnlineStore.j_Orders
			set Netto = @netto,
				id_Editor = @id_person,
				DateEdit = getdate()
			where id_tOrders = @id_tOrder and id_Tovar = @id_tovar
		end
	
	if not exists (select id from OnlineStore.j_JournalStatus where  id_tOrders=@id_tOrder)
		begin
			insert into OnlineStore.j_JournalStatus (id_tOrders,id_Status,DateEdit,id_Editor)
			values (@id_tOrder, 1,getdate(),@id_person)
		end


END
