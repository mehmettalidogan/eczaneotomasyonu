-- Reçete tablosuna satış alanlarını ekle
-- Migration Script: Add Sales Fields to Prescriptions Table
-- Date: 2025-12-04

USE EczaneOtomasyonDb;
GO

-- Satış alanlarını ekle
IF NOT EXISTS (SELECT * FROM sys.columns WHERE object_id = OBJECT_ID(N'[dbo].[Prescriptions]') AND name = 'IsSold')
BEGIN
    ALTER TABLE [dbo].[Prescriptions]
    ADD [IsSold] BIT NOT NULL DEFAULT 0;
    PRINT 'IsSold alanı eklendi.';
END

IF NOT EXISTS (SELECT * FROM sys.columns WHERE object_id = OBJECT_ID(N'[dbo].[Prescriptions]') AND name = 'SaleDate')
BEGIN
    ALTER TABLE [dbo].[Prescriptions]
    ADD [SaleDate] DATETIME2(7) NULL;
    PRINT 'SaleDate alanı eklendi.';
END

IF NOT EXISTS (SELECT * FROM sys.columns WHERE object_id = OBJECT_ID(N'[dbo].[Prescriptions]') AND name = 'TotalAmount')
BEGIN
    ALTER TABLE [dbo].[Prescriptions]
    ADD [TotalAmount] DECIMAL(18, 2) NOT NULL DEFAULT 0;
    PRINT 'TotalAmount alanı eklendi.';
END

IF NOT EXISTS (SELECT * FROM sys.columns WHERE object_id = OBJECT_ID(N'[dbo].[Prescriptions]') AND name = 'SaleStatus')
BEGIN
    ALTER TABLE [dbo].[Prescriptions]
    ADD [SaleStatus] NVARCHAR(50) NOT NULL DEFAULT N'Bekliyor';
    PRINT 'SaleStatus alanı eklendi.';
END

PRINT 'Migration tamamlandı!';
GO

