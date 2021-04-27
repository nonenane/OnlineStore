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
-- Description:	������ ��� �������� ���������� ����������� ��� �������� �� ������
-- =============================================
CREATE PROCEDURE [OnlineStore].[setType�mployes�rder]	
	 @idType�mployes�rder int,
	 @id_tOrders int,
	 @idKadr int,
	 @Collector bit,
	 @KassCheck bit,
	 @Delivery bit,
	 @id_user int,
	 @isDel bit
AS
BEGIN
	SET NOCOUNT ON;

IF @isDel = 0
	BEGIN
		IF NOT EXISTS(select * from OnlineStore.j_Type�mployes�rder where id_tOrders =  @id_tOrders and id_Kadr = @idKadr)
			INSERT INTO	OnlineStore.j_Type�mployes�rder (id_tOrders,id_Kadr,Collector,KassCheck,Delivery,id_Editor,DateEdit) values (@id_tOrders,@idKadr,@Collector,@KassCheck,@Delivery,@id_user,GETDATE())
		return;
	END
ELSE
	BEGIN
		delete from OnlineStore.j_Type�mployes�rder where id = @idType�mployes�rder 
		return;
	END
END

