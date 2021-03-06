USE [dbase1]
GO
/****** Object:  StoredProcedure [OnlineStore].[getCheckOrder]    Script Date: 14.09.2020 12:57:18 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Author:		KAV
-- Create date: 2020-06-01
-- Description:	Загрузка чеков по заказу
-- update:		kav 2020-07-06 поле isPackage
-- =============================================
ALTER PROCEDURE [OnlineStore].[getCheckOrder]	
	@id_tOrder int
AS
BEGIN


	select	id,
			CheckNumber,
			KassNumber,
			DateCheck
			,isnull(isPackage,0) as isPackage
			,isnull(Summa,0) as Summa
			from 
			OnlineStore.Check_vs_Order
	where id_tOrder = @id_tOrder

END
