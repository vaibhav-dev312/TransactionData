-- =============================================
-- Create date: 2019-10-07
-- Description:	User defined table type 
-- =============================================

CREATE TYPE [dbo].[TransactionTableType] AS TABLE(
	TransactionIdentificator VARCHAR(50) NOT NULL,
	Amount DECIMAL(16,2) NOT NULL,
	CurrencyCode VARCHAR(3) NOT NULL,
	TransactionDate DateTime NOT NULL,
	[Status] VARCHAR(50)
)
GO


