using System;
using System.Linq;
using EczaneOtomasyon.DataAccess;
using EczaneOtomasyon.DataAccess.Repositories;
using EczaneOtomasyon.Business.Interfaces;

namespace EczaneOtomasyon.Business
{
    /// <summary>
    /// Barkod okuma ve yönetim servisi - Barkod okuyucu entegrasyonu
    /// </summary>
    public class BarcodeService : IBarcodeService
    {
        private readonly IDrugRepository _drugRepository;
        private string _barcodeBuffer = string.Empty;
        private DateTime _lastKeyPress = DateTime.Now;

        /// <summary>
        /// BarcodeService constructor - Dependency Injection ile repository alır
        /// </summary>
        /// <param name="drugRepository">İlaç repository</param>
        public BarcodeService(IDrugRepository drugRepository)
        {
            _drugRepository = drugRepository;
        }

        /// <summary>
        /// Barkod okuyucudan gelen tuş vuruşlarını işler
        /// </summary>
        /// <param name="key">Basılan tuş</param>
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
        /// Barkod okunduğunda tetiklenen event
        /// </summary>
        public event EventHandler<BarcodeReadEventArgs>? BarcodeRead;

        /// <summary>
        /// BarcodeRead eventini tetikler
        /// </summary>
        /// <param name="barcode">Okunan barkod</param>
        protected virtual void OnBarcodeRead(string barcode)
        {
            BarcodeRead?.Invoke(this, new BarcodeReadEventArgs(barcode));
        }

        /// <summary>
        /// Barkoda göre ilacı bulur
        /// </summary>
        /// <param name="barcode">Barkod numarası</param>
        /// <returns>İlaç nesnesi veya null</returns>
        public Drug? FindDrugByBarcode(string barcode)
        {
            if (string.IsNullOrWhiteSpace(barcode))
                return null;

            return _drugRepository.GetByBarcode(barcode.Trim());
        }

        /// <summary>
        /// Barkod formatını doğrular
        /// </summary>
        /// <param name="barcode">Barkod numarası</param>
        /// <returns>Geçerliyse true, değilse false</returns>
        public bool ValidateBarcode(string barcode)
        {
            if (string.IsNullOrWhiteSpace(barcode))
                return false;

            // Sadece rakam ve harf içermeli
            return barcode.All(c => char.IsLetterOrDigit(c) || c == '-');
        }

        /// <summary>
        /// Barkod formatını belirler (EAN-13, EAN-8, Code128 vb.)
        /// </summary>
        /// <param name="barcode">Barkod numarası</param>
        /// <returns>Barkod formatı</returns>
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
        /// EAN-13 barkod doğrulaması yapar (checksum kontrolü)
        /// </summary>
        /// <param name="barcode">EAN-13 barkod</param>
        /// <returns>Geçerliyse true, değilse false</returns>
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
        /// İlacın barkodunu günceller
        /// </summary>
        /// <param name="drugId">İlaç ID</param>
        /// <param name="barcode">Yeni barkod</param>
        public void UpdateDrugBarcode(int drugId, string barcode)
        {
            var drug = _drugRepository.GetById(drugId);
            if (drug != null)
            {
                drug.Barcode = barcode.Trim();
                _drugRepository.Update(drug);
            }
        }

        /// <summary>
        /// İlaç için otomatik barkod üretir
        /// </summary>
        /// <param name="drugId">İlaç ID</param>
        /// <returns>Üretilen barkod</returns>
        public string GenerateBarcode(int drugId)
        {
            // Örnek: "ILC" + 10 haneli ID (sıfır doldurmalı)
            return $"ILC{drugId:D10}";
        }
    }

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

    public enum BarcodeFormat
    {
        Unknown,
        EAN13,      // 13 haneli (yaygın perakende)
        EAN8,       // 8 haneli
        Code128,    // Değişken uzunluk
        QRCode      // QR kod
    }
}



