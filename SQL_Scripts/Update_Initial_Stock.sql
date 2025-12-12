-- Tum ilaclara baslangic stok degeri (100) atamasi yapar
-- Bu script, Drug tablosuna Stock kolonu eklendikten sonra calistirilmalidir

USE EczaneOtomasyonDb;
GO

-- Once Stock kolonu var mi kontrol et, yoksa ekle
IF NOT EXISTS (SELECT * FROM sys.columns 
               WHERE object_id = OBJECT_ID(N'[dbo].[Drugs]') 
               AND name = 'Stock')
BEGIN
    ALTER TABLE [dbo].[Drugs] 
    ADD [Stock] INT NOT NULL DEFAULT 100;
    PRINT 'Stock kolonu basariyla eklendi ve varsayilan deger 100 olarak ayarlandi.';
END
ELSE
BEGIN
    PRINT 'Stock kolonu zaten mevcut.';
END
GO

-- Tum ilaclarin stok degerini 100 yap
UPDATE [dbo].[Drugs]
SET [Stock] = 100;

PRINT 'Tum ilaclarin stok miktarlari 100 olarak guncellendi.';
GO

-- Kontrol icin istatistikler
SELECT 
    COUNT(*) AS [Toplam Ilac Sayisi],
    AVG(Stock) AS [Ortalama Stok],
    MIN(Stock) AS [En Dusuk Stok],
    MAX(Stock) AS [En Yuksek Stok]
FROM [dbo].[Drugs];
GO

-- Ilk 10 ilacin stok durumunu goster
SELECT TOP 10
    [Id],
    [Name],
    [Category],
    [Stock]
FROM [dbo].[Drugs]
ORDER BY [Name];
GO

PRINT 'Stok guncelleme islemi basariyla tamamlandi!';
GO

