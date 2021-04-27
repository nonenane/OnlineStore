USE [dbase1]
GO
/****** Object:  StoredProcedure [OnlineStore].[get_tOrders]    Script Date: 27.04.2021 13:17:25 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Author:		Sporykhin G.Y.
-- Create date: 2021-04-27
-- Description:	Получение списка сотрудников для доставки
-- =============================================
ALTER PROCEDURE [OnlineStore].[getDeliverKadr]	
	 @id_prog int ,
	 @isDeps bit = 0

AS
BEGIN
	SET NOCOUNT ON;

IF @isDeps = 0
	BEGIN
		select 
			k.id,
			trim(k.lastname)+' '+isnull(substring(k.firstname,1,1)+'.','')+isnull(substring(k.secondname,1,1)+'.','') as FIO
		from 	
			dbo.s_kadr k
		where 
			k.id_departments in ( select value from dbo.prog_config where id_value = 'dson' and id_prog = @id_prog)
			and k.id_WorkStatus in (2,4,7)

		return;
	END
ELSE
	BEGIN

		select 0 as id, 'Все отделы' as cName, 0 as isMain
		UNION all
		select cast(d.id as int) as id,d.name as cName, 1 as isMain from dbo.departments d where d.id in (select value from dbo.prog_config where id_value = 'dson' and id_prog = @id_prog)
		order by isMain asc, id asc

	END
END

