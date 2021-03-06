USE [dbase1]
GO
/****** Object:  StoredProcedure [sendFrontol].[GetSpravTerminal]    Script Date: 17.02.2021 12:18:29 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

-- =============================================
-- Author:		Sporykhi  G.Y.
-- Create date: 22.12.2020
-- Description:	Получение списка касс для справочника 
-- =============================================
CREATE PROCEDURE [OnlineStore].[GetSpravTerminal]		
AS
BEGIN
SET NOCOUNT ON

select 
	t.id,
	t.Number,
	tt.Type as NameTerminalType,
	t.id_TerminalType,
	isnull(t.id_gu,0) as id_gu,
	isnull(t.last_id_gu,0) as last_id_gu,
	t.DateGoodsSend,
	cast(0 as bit) as isSelect,
	t.IP,
	t.Path
from 
	sendFrontol.s_Terminal t
	inner join sendFrontol.s_TerminalType tt on tt.id =  t.id_TerminalType

END	
