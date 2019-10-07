-- =============================================
-- Create date: 2019-10-06 17:55:17.521
-- Description:	Script to create Transaction database
-- =============================================

IF NOT EXISTS (SELECT name FROM master.dbo.sysdatabases WHERE name = N'TXN_Database')
BEGIN
	CREATE DATABASE [TXN_Database]
END
