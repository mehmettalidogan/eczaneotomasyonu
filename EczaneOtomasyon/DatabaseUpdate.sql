-- ====================================================================
-- Eczane Otomasyon Sistemi - Veritabanı Güncelleme Script'i
-- Tarih: 2024-12-12
-- Açıklama: Barkod sistemi için Drug tablosuna Barcode kolonu ekleniyor
-- ====================================================================

USE EczaneOtomasyonDb;
GO

-- Veritabanının var olup olmadığını kontrol et
IF NOT EXISTS (SELECT name FROM sys.databases WHERE name = 'EczaneOtomasyonDb')
BEGIN
    PRINT 'HATA: EczaneOtomasyonDb veritabanı bulunamadı!';
    PRINT 'Lütfen önce uygulamayı çalıştırarak veritabanını oluşturun.';
END
ELSE
BEGIN
    PRINT 'Veritabanı bulundu. Güncelleme başlatılıyor...';
    PRINT '';

    -- Drugs tablosunun var olup olmadığını kontrol et
    IF NOT EXISTS (SELECT * FROM sys.tables WHERE name = 'Drugs')
    BEGIN
        PRINT 'HATA: Drugs tablosu bulunamadı!';
        PRINT 'Lütfen önce uygulamayı çalıştırarak tabloları oluşturun.';
    END
    ELSE
    BEGIN
        PRINT 'Drugs tablosu bulundu.';
        
        -- Barcode kolonunun zaten var olup olmadığını kontrol et
        IF NOT EXISTS (SELECT * FROM sys.columns 
                       WHERE object_id = OBJECT_ID('Drugs') 
                       AND name = 'Barcode')
        BEGIN
            PRINT 'Barcode kolonu ekleniyor...';
            
            -- Barcode kolonunu ekle
            ALTER TABLE Drugs 
            ADD Barcode NVARCHAR(100) NULL;
            
            PRINT '✓ Barcode kolonu başarıyla eklendi!';
            PRINT '';
            
            -- Varolan kayıtlara varsayılan barkod değeri ata (opsiyonel)
            PRINT 'Mevcut ilaçlara otomatik barkod numaraları atanıyor...';
            
            UPDATE Drugs
            SET Barcode = 'ILC' + RIGHT('0000000000' + CAST(Id AS VARCHAR(10)), 10)
            WHERE Barcode IS NULL OR Barcode = '';
            
            PRINT '✓ Mevcut ilaçlara barkod numaraları atandı!';
            PRINT '';
            
            -- İstatistik bilgileri
            DECLARE @DrugCount INT;
            SELECT @DrugCount = COUNT(*) FROM Drugs;
            
            PRINT '====================================';
            PRINT 'Güncelleme Özeti:';
            PRINT '====================================';
            PRINT 'Toplam İlaç Sayısı: ' + CAST(@DrugCount AS VARCHAR(10));
            PRINT 'Eklenen Kolon: Barcode (NVARCHAR(100))';
            PRINT 'Durum: BAŞARILI ✓';
            PRINT '';
            PRINT 'Artık uygulamanızda barkod sistemi kullanabilirsiniz!';
        END
        ELSE
        BEGIN
            PRINT 'UYARI: Barcode kolonu zaten mevcut!';
            PRINT 'Herhangi bir değişiklik yapılmadı.';
        END
    END
END

GO

-- Tabloların güncel yapısını göster (kontrol için)
PRINT '';
PRINT '====================================';
PRINT 'Drugs Tablosu Yapısı:';
PRINT '====================================';

SELECT 
    COLUMN_NAME as [Kolon Adı],
    DATA_TYPE as [Veri Tipi],
    CHARACTER_MAXIMUM_LENGTH as [Uzunluk],
    IS_NULLABLE as [NULL Olabilir]
FROM INFORMATION_SCHEMA.COLUMNS
WHERE TABLE_NAME = 'Drugs'
ORDER BY ORDINAL_POSITION;

GO

-- Örnek barkod sorgulama
PRINT '';
PRINT '====================================';
PRINT 'İlk 5 İlaç ve Barkodları:';
PRINT '====================================';

SELECT TOP 5
    Id,
    Name as [İlaç Adı],
    Barcode as [Barkod],
    Stock as [Stok],
    Price as [Fiyat]
FROM Drugs
ORDER BY Id;

GO

PRINT '';
PRINT '====================================';
PRINT 'GÜNCELLEME TAMAMLANDI! ✓';
PRINT '====================================';


