USE [dbase1]
GO
/****** Object:  StoredProcedure [OnlineStore].[setCheckOrder]    Script Date: 14.09.2020 12:27:19 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Author:		KAV
-- Create date: 2020-06-01
-- Description:	Добавление/удаление чека
-- UPDATE:		kav 2020-07-06 поле isPackage - признак пакетного чека
-- =============================================
ALTER PROCEDURE [OnlineStore].[setCheckOrder]	
	@id int = null,
	@CheckNumber int = null,
	@KassNumber int = null,
	@DateCheck datetime = null,
	@summa numeric(16,2) = null,
	@id_tOrder int = null,
	@id_Editor int = null,
	@isPackage bit = null
AS
BEGIN
	
	if (@id is null)
		begin
			insert into OnlineStore.Check_vs_Order (id_tOrder, CheckNumber,KassNumber,DateEdit,id_Editor,DateCheck, isPackage,Summa)
			values (@id_tOrder,@CheckNumber, @KassNumber, getdate(), @id_Editor,@DateCheck, @isPackage,@summa)
		end
	else
		begin
			delete from OnlineStore.Check_vs_Order
			where id = @id
		end

END
