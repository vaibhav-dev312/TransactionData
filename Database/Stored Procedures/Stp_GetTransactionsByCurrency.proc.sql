
-- =============================================
-- Create date: 2019-10-06 19:27:16.530
-- Description:	To get transactions by currency code
-- =============================================

IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[Stp_GetTransactionsByCurrency]') AND type in (N'P', N'PC'))
	DROP PROCEDURE [dbo].[Stp_GetTransactionsByCurrency]
GO
CREATE PROCEDURE [Stp_GetTransactionsByCurrency]
	@currencyCode NVARCHAR(3)
AS
BEGIN
	-- SET NOCOUNT ON added to prevent extra result sets from
	-- interfering with SELECT statements.
	SET NOCOUNT ON;
	
	SELECT
		TransactionIdentificator as ID
		,CONCAT(Amount,' ', CurrencyCode) AS Payment
		,(CASE 
			WHEN [Status] = 'Approved' THEN 'A' 
			WHEN [Status] = 'Failed'	OR [Status] = 'Rejected'	THEN 'R' 
			WHEN [Status] = 'Finished'  OR [Status] = 'Done'		THEN 'D'
			ELSE [Status]
		END) As [Status]
	FROM [dbo].[Transaction]
	WHERE CurrencyCode = @currencyCode

END
GO
