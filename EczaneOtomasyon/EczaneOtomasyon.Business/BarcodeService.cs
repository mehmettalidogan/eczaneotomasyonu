using System;
using System.Linq;
using System.Windows.Forms;
using EczaneOtomasyon.DataAccess;

namespace EczaneOtomasyon.Business
{
    /// <summary>
    /// Barkod okuma ve işleme servisi
    /// USB/Serial barkod okuyuculardan gelen verileri yakalar
    /// </summary>
    public class BarcodeService
    {
        private readonly EczaneContext _context;
        private string _barcodeBuffer = string.Empty;
        private DateTime _lastKeyPress = DateTime.Now;

        public BarcodeService()
        {
            _context = new EczaneContext();
        }

        /// <summary>
        /// Barkod okuyucudan gelen tuş vuruşlarını toplar
        /// </summary>
        public void ProcessKeyPress(char key)
        {
            // 100ms'den fazla süre geçtiyse buffer'ı sıfırla
            if ((DateTime.Now - _lastKeyPress).TotalMilliseconds > 100)
            {
                _barcodeBuffer = string.Empty;
            }

            _lastKeyPress = DateTime.Now;

            // Enter tuşu barkod okuma sonunu belirtir
            if (key == '\r' || key == '\n')
            {
                if (!string.IsNullOrWhiteSpace(_barcodeBuffer))
                {
                    // Barkod okundu
                    OnBarcodeRead(_barcodeBuffer.Trim());
                    _barcodeBuffer = string.Empty;
                }
            }
            else
            {
                _barcodeBuffer += key;
            }
        }

        /// <summary>
        /// Barkod okunduğunda tetiklenir
        /// </summary>
        public event EventHandler<BarcodeReadEventArgs>? BarcodeRead;

        protected virtual void OnBarcodeRead(string barcode)
        {
            BarcodeRead?.Invoke(this, new BarcodeReadEventArgs(barcode));
        }

        /// <summary>
        /// Barkoda göre ilacı veritabanında arar
        /// </summary>
        public Drug? FindDrugByBarcode(string barcode)
        {
            if (string.IsNullOrWhiteSpace(barcode))
                return null;

            return _context.Drugs.FirstOrDefault(d => d.Barcode == barcode.Trim());
        }

        /// <summary>
        /// Manuel barkod girişi için doğrulama
        /// </summary>
        public bool ValidateBarcode(string barcode)
        {
            if (string.IsNullOrWhiteSpace(barcode))
                return false;

            // Sadece rakam ve harf içermeli
            return barcode.All(c => char.IsLetterOrDigit(c) || c == '-');
        }

        /// <summary>
        /// Barkod formatını kontrol eder (EAN-13, Code128, vb.)
        /// </summary>
        public BarcodeFormat GetBarcodeFormat(string barcode)
        {
            if (string.IsNullOrWhiteSpace(barcode))
                return BarcodeFormat.Unknown;

            // EAN-13 (13 haneli rakam)
            if (barcode.Length == 13 && barcode.All(char.IsDigit))
                return BarcodeFormat.EAN13;

            // EAN-8 (8 haneli rakam)
            if (barcode.Length == 8 && barcode.All(char.IsDigit))
                return BarcodeFormat.EAN8;

            // Code128 (değişken uzunluk, harf+rakam)
            if (barcode.Length >= 6 && barcode.All(c => char.IsLetterOrDigit(c) || c == '-'))
                return BarcodeFormat.Code128;

            return BarcodeFormat.Unknown;
        }

        /// <summary>
        /// EAN-13 barkod için check digit doğrulaması
        /// </summary>
        public bool ValidateEAN13(string barcode)
        {
            if (barcode.Length != 13 || !barcode.All(char.IsDigit))
                return false;

            int sum = 0;
            for (int i = 0; i < 12; i++)
            {
                int digit = int.Parse(barcode[i].ToString());
                sum += (i % 2 == 0) ? digit : digit * 3;
            }

            int checkDigit = (10 - (sum % 10)) % 10;
            return checkDigit == int.Parse(barcode[12].ToString());
        }

        /// <summary>
        /// Barkod bilgisini günceller
        /// </summary>
        public void UpdateDrugBarcode(int drugId, string barcode)
        {
            var drug = _context.Drugs.Find(drugId);
            if (drug != null)
            {
                drug.Barcode = barcode.Trim();
                _context.SaveChanges();
            }
        }

        /// <summary>
        /// Otomatik barkod üretir (ilaç ID'sine göre)
        /// </summary>
        public string GenerateBarcode(int drugId)
        {
            // Örnek: "ILC" + 10 haneli ID (sıfır doldurmalı)
            return $"ILC{drugId:D10}";
        }
    }

    /// <summary>
    /// Barkod okunduğunda event argümanı
    /// </summary>
    public class BarcodeReadEventArgs : EventArgs
    {
        public string Barcode { get; }
        public DateTime Timestamp { get; }

        public BarcodeReadEventArgs(string barcode)
        {
            Barcode = barcode;
            Timestamp = DateTime.Now;
        }
    }

    /// <summary>
    /// Barkod formatları
    /// </summary>
    public enum BarcodeFormat
    {
        Unknown,
        EAN13,      // 13 haneli (yaygın perakende)
        EAN8,       // 8 haneli
        Code128,    // Değişken uzunluk
        QRCode      // QR kod
    }
}



