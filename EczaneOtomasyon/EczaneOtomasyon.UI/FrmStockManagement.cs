using System;
using System.Linq;
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

        public FrmStockManagement()
        {
            InitializeComponent();
            _stockService = new StockService();
            _drugService = new DrugService();
            
            LoadData();
            UpdateStatistics();
        }

        private void LoadData()
        {
            var drugs = _stockService.GetAllWithStock();
            gridControl1.DataSource = drugs;
        }

        private void UpdateStatistics()
        {
            var outOfStockDrugs = _stockService.GetOutOfStockDrugs();
            var lowStockDrugs = _stockService.GetLowStockDrugs(10);

            lblOutOfStockCount.Text = outOfStockDrugs.Count.ToString();
            lblLowStockCount.Text = lowStockDrugs.Count.ToString();
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
            var lowStockDrugs = _stockService.GetLowStockDrugs(10);
            gridControl1.DataSource = lowStockDrugs;
        }

        private void btnShowAll_Click(object sender, EventArgs e)
        {
            LoadData();
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

