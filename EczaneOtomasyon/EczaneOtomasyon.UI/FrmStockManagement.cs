using System;
using System.Linq;
using System.Collections.Generic;
using System.Windows.Forms;
using DevExpress.XtraEditors;
using EczaneOtomasyon.Business;
using EczaneOtomasyon.DataAccess;

namespace EczaneOtomasyon.UI
{
    public partial class FrmStockManagement : XtraForm
    {
        private readonly StockService _stockService;
        private readonly DrugService _drugService;
        private readonly BarcodeService _barcodeService;
        private List<Drug>? _cachedDrugs;

        public FrmStockManagement()
        {
            this.SuspendLayout();
            
            InitializeComponent();
            _stockService = new StockService();
            _drugService = new DrugService();
            _barcodeService = new BarcodeService();
            
            this.ResumeLayout(false);
            
            // Veri yüklemeyi constructor dışına al - lazy loading
            this.Load += (s, e) => {
                LoadData();
                UpdateStatistics();
            };
            
            // Barkod okuma eventi
            _barcodeService.BarcodeRead += BarcodeService_BarcodeRead;
        }

        private void BarcodeService_BarcodeRead(object? sender, BarcodeReadEventArgs e)
        {
            // Barkod okundu, arama kutusuna yazdır ve ara
            txtBarcodeSearch.Text = e.Barcode;
            SearchByBarcode(e.Barcode);
        }

        private void btnBarcodeSearch_Click(object sender, EventArgs e)
        {
            string barcode = txtBarcodeSearch.Text.Trim();
            
            if (string.IsNullOrWhiteSpace(barcode))
            {
                XtraMessageBox.Show(
                    "Lütfen bir barkod numarası girin.",
                    "Uyarı",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Warning);
                return;
            }
            
            SearchByBarcode(barcode);
        }

        private void txtBarcodeSearch_KeyDown(object sender, KeyEventArgs e)
        {
            // Enter tuşuna basıldığında ara
            if (e.KeyCode == Keys.Enter)
            {
                btnBarcodeSearch_Click(sender, e);
                e.Handled = true;
                e.SuppressKeyPress = true;
            }
        }

        private void SearchByBarcode(string barcode)
        {
            var drug = _barcodeService.FindDrugByBarcode(barcode);
            
            if (drug == null)
            {
                XtraMessageBox.Show(
                    $"'{barcode}' barkodlu ilaç bulunamadı!",
                    "Bulunamadı",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Warning);
                return;
            }
            
            // İlacı grid'de bul ve seç
            int rowHandle = -1;
            for (int i = 0; i < gridView1.DataRowCount; i++)
            {
                var rowDrug = gridView1.GetRow(i) as Drug;
                if (rowDrug != null && rowDrug.Id == drug.Id)
                {
                    rowHandle = i;
                    break;
                }
            }
            
            if (rowHandle >= 0)
            {
                gridView1.FocusedRowHandle = rowHandle;
                gridView1.SelectRow(rowHandle);
                
                // Seçili satırı görünür yap
                gridView1.MakeRowVisible(rowHandle);
                
                XtraMessageBox.Show(
                    $"İlaç bulundu!\n\n" +
                    $"Adı: {drug.Name}\n" +
                    $"Stok: {drug.Stock}\n" +
                    $"Fiyat: {drug.Price:C2}",
                    "Başarılı",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Information);
            }
            else
            {
                // Cache'de yok, tüm listeyi göster ve tekrar ara
                LoadData();
                SearchByBarcode(barcode);
            }
        }

        private void LoadData()
        {
            gridControl1.BeginUpdate();
            try
            {
                _cachedDrugs = _stockService.GetAllWithStock();
                gridControl1.DataSource = _cachedDrugs;
            }
            finally
            {
                gridControl1.EndUpdate();
            }
        }

        private void UpdateStatistics()
        {
            // Sadece gerekli istatistikleri çek
            var outOfStockCount = _cachedDrugs?.Count(d => d.Stock == 0) ?? 0;
            var lowStockCount = _cachedDrugs?.Count(d => d.Stock > 0 && d.Stock <= 10) ?? 0;

            lblOutOfStockCount.Text = outOfStockCount.ToString();
            lblLowStockCount.Text = lowStockCount.ToString();
        }

        private void btnInitializeStocks_Click(object sender, EventArgs e)
        {
            var result = XtraMessageBox.Show(
                "Tüm ilaçların stok miktarları 0 olarak ayarlanacak. Devam etmek istiyor musunuz?",
                "Onay",
                MessageBoxButtons.YesNo,
                MessageBoxIcon.Warning);

            if (result == DialogResult.Yes)
            {
                try
                {
                    _stockService.InitializeAllStocks(0);
                    LoadData();
                    UpdateStatistics();
                    XtraMessageBox.Show(
                        "Tüm ilaçların stokları başarıyla 0 olarak ayarlandı.",
                        "Başarılı",
                        MessageBoxButtons.OK,
                        MessageBoxIcon.Information);
                }
                catch (Exception ex)
                {
                    XtraMessageBox.Show(
                        $"Hata: {ex.Message}",
                        "Hata",
                        MessageBoxButtons.OK,
                        MessageBoxIcon.Error);
                }
            }
        }

        private void btnRefresh_Click(object sender, EventArgs e)
        {
            LoadData();
            UpdateStatistics();
        }

        private void btnShowLowStock_Click(object sender, EventArgs e)
        {
            gridControl1.BeginUpdate();
            try
            {
                // Cache'den filtrele, tekrar veritabanına gitme
                var lowStockDrugs = _cachedDrugs?.Where(d => d.Stock > 0 && d.Stock <= 10).ToList() 
                    ?? _stockService.GetLowStockDrugs(10);
                gridControl1.DataSource = lowStockDrugs;
            }
            finally
            {
                gridControl1.EndUpdate();
            }
        }

        private void btnShowAll_Click(object sender, EventArgs e)
        {
            gridControl1.BeginUpdate();
            try
            {
                gridControl1.DataSource = _cachedDrugs;
            }
            finally
            {
                gridControl1.EndUpdate();
            }
        }

        private void btnAddStock_Click(object sender, EventArgs e)
        {
            var selectedRow = gridView1.GetFocusedRow() as Drug;
            if (selectedRow == null)
            {
                XtraMessageBox.Show(
                    "Lütfen bir ilaç seçin.",
                    "Uyarı",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Warning);
                return;
            }

            int quantity = (int)txtQuantity.Value;
            
            try
            {
                _stockService.AddStock(selectedRow.Id, quantity);
                LoadData();
                UpdateStatistics();
                XtraMessageBox.Show(
                    $"{selectedRow.Name} ilacının stoğuna {quantity} adet eklendi.",
                    "Başarılı",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Information);
            }
            catch (Exception ex)
            {
                XtraMessageBox.Show(
                    $"Hata: {ex.Message}",
                    "Hata",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Error);
            }
        }

        private void btnRemoveStock_Click(object sender, EventArgs e)
        {
            var selectedRow = gridView1.GetFocusedRow() as Drug;
            if (selectedRow == null)
            {
                XtraMessageBox.Show(
                    "Lütfen bir ilaç seçin.",
                    "Uyarı",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Warning);
                return;
            }

            int quantity = (int)txtQuantity.Value;

            if (selectedRow.Stock < quantity)
            {
                XtraMessageBox.Show(
                    $"Yetersiz stok! Mevcut stok: {selectedRow.Stock}",
                    "Uyarı",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Warning);
                return;
            }

            try
            {
                _stockService.RemoveStock(selectedRow.Id, quantity);
                LoadData();
                UpdateStatistics();
                XtraMessageBox.Show(
                    $"{selectedRow.Name} ilacının stoğundan {quantity} adet çıkarıldı.",
                    "Başarılı",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Information);
            }
            catch (Exception ex)
            {
                XtraMessageBox.Show(
                    $"Hata: {ex.Message}",
                    "Hata",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Error);
            }
        }

        private void btnSetStock_Click(object sender, EventArgs e)
        {
            var selectedRow = gridView1.GetFocusedRow() as Drug;
            if (selectedRow == null)
            {
                XtraMessageBox.Show(
                    "Lütfen bir ilaç seçin.",
                    "Uyarı",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Warning);
                return;
            }

            int quantity = (int)txtQuantity.Value;

            try
            {
                _stockService.SetStock(selectedRow.Id, quantity);
                LoadData();
                UpdateStatistics();
                XtraMessageBox.Show(
                    $"{selectedRow.Name} ilacının stoğu {quantity} olarak ayarlandı.",
                    "Başarılı",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Information);
            }
            catch (Exception ex)
            {
                XtraMessageBox.Show(
                    $"Hata: {ex.Message}",
                    "Hata",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Error);
            }
        }
    }
}

