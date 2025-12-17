using System;
using System.Collections.Generic;
using System.Drawing;
using System.Drawing.Printing;
using System.Linq;
using EczaneOtomasyon.DataAccess;
using EczaneOtomasyon.DataAccess.Repositories;
using EczaneOtomasyon.Business.Interfaces;

namespace EczaneOtomasyon.Business
{
    /// <summary>
    /// Fiş ve Fatura yazdırma servisi - SOLID prensipleri uygulanmış
    /// </summary>
    public class ReceiptPrinter : IReceiptPrinter
    {
        private readonly IPrescriptionRepository _prescriptionRepository;
        private readonly IDrugRepository _drugRepository;
        private Prescription? _currentPrescription;
        private List<ReceiptItem>? _receiptItems;
        private Font _titleFont = new Font("Arial", 14, FontStyle.Bold);
        private Font _headerFont = new Font("Arial", 10, FontStyle.Bold);
        private Font _normalFont = new Font("Arial", 9, FontStyle.Regular);
        private Font _smallFont = new Font("Arial", 8, FontStyle.Regular);

        // Dependency Injection ile repository'ler alınıyor
        public ReceiptPrinter(
            IPrescriptionRepository prescriptionRepository,
            IDrugRepository drugRepository)
        {
            _prescriptionRepository = prescriptionRepository;
            _drugRepository = drugRepository;
        }

        /// <summary>
        /// Reçete için fiş verilerini hazırlar
        /// </summary>
        public void PreparePrescriptionReceipt(int prescriptionId)
        {
            _currentPrescription = _prescriptionRepository.GetById(prescriptionId);
            
            if (_currentPrescription == null)
                throw new Exception("Reçete bulunamadı!");

            var items = _prescriptionRepository.GetPrescriptionItems(prescriptionId);
            
            _receiptItems = new List<ReceiptItem>();
            
            foreach (var item in items)
            {
                var drug = _drugRepository.GetById(item.DrugId);
                if (drug != null)
                {
                    _receiptItems.Add(new ReceiptItem
                    {
                        Name = drug.Name,
                        Quantity = 1,
                        UnitPrice = drug.Price,
                        TotalPrice = drug.Price
                    });
                }
            }
        }

        /// <summary>
        /// Fiş yazdırma
        /// </summary>
        public void Print()
        {
            if (_currentPrescription == null || _receiptItems == null)
                throw new Exception("Yazdırılacak fiş bulunamadı!");

            PrintDocument printDoc = new PrintDocument();
            printDoc.PrintPage += PrintDoc_PrintPage;
            
            try
            {
                printDoc.Print();
            }
            catch (Exception ex)
            {
                throw new Exception($"Yazdırma hatası: {ex.Message}");
            }
        }

        /// <summary>
        /// Yazdırma önizleme için PrintDocument döndürür
        /// </summary>
        public PrintDocument GetPrintDocument()
        {
            if (_currentPrescription == null || _receiptItems == null)
                throw new Exception("Yazdırılacak fiş bulunamadı!");

            PrintDocument printDoc = new PrintDocument();
            printDoc.PrintPage += PrintDoc_PrintPage;
            return printDoc;
        }

        /// <summary>
        /// Yazdırma işlemi
        /// </summary>
        private void PrintDoc_PrintPage(object sender, PrintPageEventArgs e)
        {
            if (e.Graphics == null || _currentPrescription == null || _receiptItems == null)
                return;

            Graphics graphics = e.Graphics;
            float yPos = 20;
            float leftMargin = 50;
            float rightMargin = e.PageBounds.Width - 50;

            // Logo/Başlık
            graphics.DrawString("ECZANE OTOMASYON SİSTEMİ", _titleFont, Brushes.Black, leftMargin, yPos);
            yPos += 30;

            graphics.DrawString("Adres: Örnek Mahalle, No: 123", _smallFont, Brushes.Black, leftMargin, yPos);
            yPos += 15;
            graphics.DrawString("Tel: 0212 555 1234", _smallFont, Brushes.Black, leftMargin, yPos);
            yPos += 15;
            graphics.DrawString("Vergi No: 1234567890", _smallFont, Brushes.Black, leftMargin, yPos);
            yPos += 25;

            // Çizgi
            graphics.DrawLine(Pens.Black, leftMargin, yPos, rightMargin, yPos);
            yPos += 10;

            // Fiş Bilgileri
            graphics.DrawString("FİŞ", _headerFont, Brushes.Black, leftMargin, yPos);
            yPos += 20;

            graphics.DrawString($"Fiş No: {_currentPrescription.Id}", _normalFont, Brushes.Black, leftMargin, yPos);
            yPos += 15;

            graphics.DrawString($"Tarih: {_currentPrescription.SaleDate?.ToString("dd.MM.yyyy HH:mm") ?? _currentPrescription.Date.ToString("dd.MM.yyyy HH:mm")}", 
                _normalFont, Brushes.Black, leftMargin, yPos);
            yPos += 15;

            if (!string.IsNullOrEmpty(_currentPrescription.PrescriptionNumber))
            {
                graphics.DrawString($"Reçete No: {_currentPrescription.PrescriptionNumber}", _normalFont, Brushes.Black, leftMargin, yPos);
                yPos += 15;
            }

            graphics.DrawString($"Hasta: {_currentPrescription.PatientName} {_currentPrescription.PatientSurname}", 
                _normalFont, Brushes.Black, leftMargin, yPos);
            yPos += 15;

            graphics.DrawString($"TC No: {_currentPrescription.PatientTC}", _normalFont, Brushes.Black, leftMargin, yPos);
            yPos += 25;

            // Çizgi
            graphics.DrawLine(Pens.Black, leftMargin, yPos, rightMargin, yPos);
            yPos += 10;

            // Ürün Başlıkları
            graphics.DrawString("Ürün", _headerFont, Brushes.Black, leftMargin, yPos);
            graphics.DrawString("Adet", _headerFont, Brushes.Black, rightMargin - 150, yPos);
            graphics.DrawString("Fiyat", _headerFont, Brushes.Black, rightMargin - 100, yPos);
            graphics.DrawString("Toplam", _headerFont, Brushes.Black, rightMargin - 50, yPos);
            yPos += 20;

            graphics.DrawLine(Pens.Black, leftMargin, yPos, rightMargin, yPos);
            yPos += 10;

            // Ürünler
            decimal grandTotal = 0;
            foreach (var item in _receiptItems)
            {
                // Uzun ürün adlarını kes
                string productName = item.Name.Length > 35 ? item.Name.Substring(0, 35) + "..." : item.Name;
                
                graphics.DrawString(productName, _normalFont, Brushes.Black, leftMargin, yPos);
                graphics.DrawString(item.Quantity.ToString(), _normalFont, Brushes.Black, rightMargin - 150, yPos);
                graphics.DrawString(item.UnitPrice.ToString("C2"), _normalFont, Brushes.Black, rightMargin - 100, yPos);
                graphics.DrawString(item.TotalPrice.ToString("C2"), _normalFont, Brushes.Black, rightMargin - 50, yPos);
                
                grandTotal += item.TotalPrice;
                yPos += 20;
            }

            yPos += 10;
            graphics.DrawLine(Pens.Black, leftMargin, yPos, rightMargin, yPos);
            yPos += 10;

            // Toplam
            graphics.DrawString("GENEL TOPLAM:", _headerFont, Brushes.Black, rightMargin - 150, yPos);
            graphics.DrawString(grandTotal.ToString("C2"), _headerFont, Brushes.Black, rightMargin - 50, yPos);
            yPos += 30;

            // Alt bilgi
            graphics.DrawLine(Pens.Black, leftMargin, yPos, rightMargin, yPos);
            yPos += 10;

            string footerText = "İYİ GÜNLER DİLERİZ";
            SizeF footerSize = graphics.MeasureString(footerText, _normalFont);
            graphics.DrawString(footerText, _normalFont, Brushes.Black, 
                (e.PageBounds.Width - footerSize.Width) / 2, yPos);
            yPos += 20;

            string dateText = DateTime.Now.ToString("dd.MM.yyyy HH:mm:ss");
            SizeF dateSize = graphics.MeasureString(dateText, _smallFont);
            graphics.DrawString(dateText, _smallFont, Brushes.Gray, 
                (e.PageBounds.Width - dateSize.Width) / 2, yPos);
        }

        /// <summary>
        /// HTML formatında fiş oluşturur (e-posta veya web için)
        /// </summary>
        public string GenerateHtmlReceipt()
        {
            if (_currentPrescription == null || _receiptItems == null)
                throw new Exception("Fiş verisi bulunamadı!");

            decimal grandTotal = _receiptItems.Sum(i => i.TotalPrice);

            string html = $@"
<!DOCTYPE html>
<html>
<head>
    <meta charset='utf-8'>
    <style>
        body {{ font-family: Arial, sans-serif; margin: 20px; }}
        .header {{ text-align: center; margin-bottom: 20px; }}
        .title {{ font-size: 20px; font-weight: bold; }}
        .info {{ margin: 10px 0; }}
        table {{ width: 100%; border-collapse: collapse; margin: 20px 0; }}
        th, td {{ border: 1px solid #ddd; padding: 8px; text-align: left; }}
        th {{ background-color: #f2f2f2; font-weight: bold; }}
        .total {{ text-align: right; font-weight: bold; font-size: 16px; }}
        .footer {{ text-align: center; margin-top: 30px; font-size: 12px; }}
    </style>
</head>
<body>
    <div class='header'>
        <div class='title'>ECZANE OTOMASYON SİSTEMİ</div>
        <div>Adres: Örnek Mahalle, No: 123</div>
        <div>Tel: 0212 555 1234</div>
        <div>Vergi No: 1234567890</div>
    </div>
    
    <hr>
    
    <div class='info'>
        <strong>Fiş No:</strong> {_currentPrescription.Id}<br>
        <strong>Tarih:</strong> {_currentPrescription.SaleDate?.ToString("dd.MM.yyyy HH:mm") ?? _currentPrescription.Date.ToString("dd.MM.yyyy HH:mm")}<br>
        <strong>Reçete No:</strong> {_currentPrescription.PrescriptionNumber}<br>
        <strong>Hasta:</strong> {_currentPrescription.PatientName} {_currentPrescription.PatientSurname}<br>
        <strong>TC No:</strong> {_currentPrescription.PatientTC}
    </div>
    
    <table>
        <thead>
            <tr>
                <th>Ürün</th>
                <th style='text-align: center;'>Adet</th>
                <th style='text-align: right;'>Birim Fiyat</th>
                <th style='text-align: right;'>Toplam</th>
            </tr>
        </thead>
        <tbody>";

            foreach (var item in _receiptItems)
            {
                html += $@"
            <tr>
                <td>{item.Name}</td>
                <td style='text-align: center;'>{item.Quantity}</td>
                <td style='text-align: right;'>{item.UnitPrice:C2}</td>
                <td style='text-align: right;'>{item.TotalPrice:C2}</td>
            </tr>";
            }

            html += $@"
        </tbody>
    </table>
    
    <div class='total'>
        GENEL TOPLAM: {grandTotal:C2}
    </div>
    
    <hr>
    
    <div class='footer'>
        <strong>İYİ GÜNLER DİLERİZ</strong><br>
        <small>{DateTime.Now:dd.MM.yyyy HH:mm:ss}</small>
    </div>
</body>
</html>";

            return html;
        }

        /// <summary>
        /// Eczane bilgilerini ayarlar (opsiyonel)
        /// </summary>
        public PharmacyInfo? PharmacyInfo { get; set; }
    }

    /// <summary>
    /// Fiş satırı bilgisi
    /// </summary>
    public class ReceiptItem
    {
        public string Name { get; set; } = string.Empty;
        public int Quantity { get; set; }
        public decimal UnitPrice { get; set; }
        public decimal TotalPrice { get; set; }
    }

    /// <summary>
    /// Eczane bilgileri (fiş üstünde görünecek)
    /// </summary>
    public class PharmacyInfo
    {
        public string Name { get; set; } = "ECZANE OTOMASYON SİSTEMİ";
        public string Address { get; set; } = "Örnek Mahalle, No: 123";
        public string Phone { get; set; } = "0212 555 1234";
        public string TaxNumber { get; set; } = "1234567890";
        public string? Email { get; set; }
        public string? Website { get; set; }
    }
}



