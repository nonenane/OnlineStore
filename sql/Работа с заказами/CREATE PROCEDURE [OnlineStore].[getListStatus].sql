USE [dbase1]
GO
/****** Object:  StoredProcedure [OnlineStore].[getGoods]    Script Date: 11.09.2020 13:32:50 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Author:		Sporykhin G Y
-- Create date: 2020-09-14
-- Description:	��������� ������ �������� ������
-- =============================================
ALTER PROCEDURE [OnlineStore].[getListStatus]			
AS
BEGIN
	SET NOCOUNT ON;

	

select  
	id,
	cName,
	isActive 
from 
	OnlineStore.s_Status

END
