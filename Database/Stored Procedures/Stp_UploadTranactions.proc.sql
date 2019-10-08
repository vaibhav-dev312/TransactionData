
-- =============================================
-- Create date: 2019-10-07
-- Description: Insert file data to transaction table
-- =============================================

IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[Stp_UploadTranactions]') AND type in (N'P', N'PC'))
	DROP PROCEDURE [dbo].[Stp_UploadTranactions]
GO

CREATE PROCEDURE Stp_UploadTranactions
	@TransactionTableType TransactionTableType READONLY
AS
BEGIN
	-- SET NOCOUNT ON added to prevent extra result sets from
	SET NOCOUNT ON;

	BEGIN TRY

   BEGIN TRANSACTION

   INSERT INTO [dbo].[Transaction] (
		TransactionIdentificator, 
		Amount
		,CurrencyCode
		,TransactionDate
		,[Status])
   SELECT 
		TransactionIdentificator
		,Amount
		,CurrencyCode
		,TransactionDate
		,[Status]  
	FROM 
		@TransactionTableType

   COMMIT TRANSACTION

   END TRY

   BEGIN CATCH
   IF(@@ROWCOUNT > 0)
   BEGIN
		ROLLBACK TRANSACTION
   END
   END CATCH
END