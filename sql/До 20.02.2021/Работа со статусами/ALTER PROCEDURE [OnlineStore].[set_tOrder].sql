USE [dbase1]
GO
/****** Object:  StoredProcedure [OnlineStore].[set_tOrder]    Script Date: 14.09.2020 17:01:49 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Author:		KAV
-- Create date: 14-04-2020
-- Description:	Добавление шапки заказа
-- Update:		KAV 2020-05-06 - =null все входные (чтобы для обновления чего-то не использовать кучу процедур)
--				+ countPackage
-- =============================================
ALTER PROCEDURE [OnlineStore].[set_tOrder]	
	@orderNum int = null,
	@dateOrder datetime = null,
	@lastname varchar(max) = null,
	@name varchar(max) = null,
	@email varchar(max) = null,
	@phone varchar(max) = null,
	@address varchar(max) = null,
	@summaDelivery numeric(16,2) = null,
	@commentOrder varchar(max) = null,
	@id_person int = null,
	@typePay varchar(max) = null,
	@countPackage int = null,
	@idOrder int = null,
	@DeliveriCost numeric(10,2) = null,
	@DeliveryDate date = null,	
	@id_status int = null
AS
BEGIN
	SET NOCOUNT ON;

	declare @id_payment int
	set @id_payment = (select distinct id from OnlineStore.s_Payment where cName = @typePay)
	if not exists (select * from OnlineStore.j_tOrders where OrderNumber = @orderNum or id = @idOrder)
	begin
		insert into OnlineStore.j_tOrders
		(OrderNumber,
		DateOrder,
		LastnameBuyer,
		NameBuyer,
		Email,
		Phone,
		Address,
		SummaDelivery,
		CommentOrder,
		DateCreate,
		id_Creator,
		DateEdit,
		id_Editor,
		id_Payment,
		CountPackage)
		values
		(@orderNum, @dateOrder, @lastname, @name, @email, @phone, @address,@summaDelivery,@commentOrder,GETDATE(),@id_person,getdate(),@id_person, @id_payment,@countPackage)
	end
	else if (@countPackage is not null)
	begin
		update OnlineStore.j_tOrders
		set CountPackage = @countPackage, id_Editor = @id_person, DateEdit = GETDATE()
		where id = @idOrder
	end
	else if (@idOrder is not null and @DeliveriCost is not null)
		BEGIN
			UPDATE 
				OnlineStore.j_tOrders
			set
				DeliveryCost = @DeliveriCost,
				DeliveryDate = @DeliveryDate,
				id_Editor = @id_person,
				DateEdit = GETDATE()
			where	
				id = @idOrder

			INSERT INTO 
				OnlineStore.j_JournalStatus (id_tOrders,id_Status,Comment,id_Editor,DateEdit)
			VALUES
				(@idOrder,@id_status,@commentOrder,@id_person,GETDATE())

		END
	ELSE IF (@idOrder is not null and @commentOrder is not null)
		BEGIN
			INSERT INTO 
				OnlineStore.j_JournalStatus (id_tOrders,id_Status,Comment,id_Editor,DateEdit)
			VALUES
				(@idOrder,@id_status,@commentOrder,@id_person,GETDATE())
		END
	ELSE IF (@idOrder is not null and @id_status is not null)
		BEGIN
			INSERT INTO 
				OnlineStore.j_JournalStatus (id_tOrders,id_Status,Comment,id_Editor,DateEdit)
			VALUES
				(@idOrder,@id_status,@commentOrder,@id_person,GETDATE())
		END
	ELSE IF (@summaDelivery is not null and @idOrder is not null)
		BEGIN
			UPDATE 
				OnlineStore.j_tOrders
			set
				SummaDelivery = @summaDelivery,
				id_Editor = @id_person,
				DateEdit = GETDATE()
			where	
				id = @idOrder
		END
	ELSE
	begin
		update OnlineStore.j_tOrders
		set DateEdit = getdate(), id_Editor = @id_person 
		where OrderNumber = @orderNum
			
	end
	select SCOPE_IDENTITY()


END
