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
-- Description:	ѕолучение истории статусов по заказу
-- =============================================
ALTER PROCEDURE [OnlineStore].[getHistoryJournalStatus]		
	@id_tOrders int  
AS
BEGIN
	SET NOCOUNT ON;

	

select distinct
	convert(varchar(100),j.DateEdit,120) as DateEdit,
	s.cName,
	l.FIO,
	j.Comment
from 
	OnlineStore.j_JournalStatus j
		left join OnlineStore.s_Status s on s.id = j.id_Status
		left join dbo.ListUsers l on l.id = j.id_Editor
where 
	id_tOrders = @id_tOrders

END
