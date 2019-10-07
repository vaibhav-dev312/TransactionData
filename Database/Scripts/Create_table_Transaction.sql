-- =============================================
-- Create date: 2019-10-06 18:02:16.544
-- Description:	Script to create Transaction table.
-- =============================================

USE TXN_Database

IF NOT EXISTS (SELECT * FROM INFORMATION_SCHEMA.TABLES
           WHERE TABLE_NAME = N'Transaction')
BEGIN
	CREATE TABLE [Transaction] (
		TransactionId BIGINT NOT NULL IDENTITY(1,1),
		TransactionIdentificator VARCHAR(MAX) NOT NULL,
		Amount DECIMAL(16,2) NOT NULL,
		CurrencyCode VARCHAR(3) NOT NULL,
		TransactionDate DateTime NOT NULL,
		Status VARCHAR(MAX)
		PRIMARY KEY (TransactionId)
);
END