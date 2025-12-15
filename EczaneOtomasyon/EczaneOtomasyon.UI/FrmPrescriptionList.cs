using System;
using System.Linq;
using System.Collections.Generic;
using System.Windows.Forms;
using System.Drawing.Printing;
using DevExpress.XtraEditors;
using DevExpress.XtraPrinting;
using EczaneOtomasyon.Business;
using EczaneOtomasyon.DataAccess;

namespace EczaneOtomasyon.UI
{
    public partial class FrmPrescriptionList : DevExpress.XtraEditors.XtraForm
    {
        private readonly PrescriptionChecker _prescriptionChecker;
        private List<Prescription>? _cachedPrescriptions;

        public FrmPrescriptionList()
        {
            this.SuspendLayout();
            
            InitializeComponent();
            _prescriptionChecker = new PrescriptionChecker();
            ConfigureGridAppearance();
            
            this.ResumeLayout(false);
            
            // Veri yüklemeyi constructor dışına al - lazy loading
            this.Load += (s, e) => LoadData();
        }
        
        // Dışarıdan veri yenileme için public metod
        public void RefreshData()
        {
            LoadData();
        }

        private void ConfigureGridAppearance()
        {
            // Satış durumuna göre satırları renklendir
            gridView1.RowStyle += (sender, e) =>
            {
                if (e.RowHandle >= 0)
                {
                    var prescription = gridView1.GetRow(e.RowHandle) as Prescription;
                    if (prescription != null && prescription.IsSold)
                    {
                        e.Appearance.BackColor = System.Drawing.Color.LightGreen;
                        e.Appearance.BackColor2 = System.Drawing.Color.White;
                    }
                    else if (prescription != null && !prescription.IsSold)
                    {
                        e.Appearance.BackColor = System.Drawing.Color.LightYellow;
                        e.Appearance.BackColor2 = System.Drawing.Color.White;
                    }
                }
            };
        }

        private void LoadData()
        {
            gridControl1.BeginUpdate();
            try
            {
                _cachedPrescriptions = _prescriptionChecker.GetAllPrescriptions();
                gridControl1.DataSource = _cachedPrescriptions;
                
                // İstatistikleri hesapla
                var soldCount = _cachedPrescriptions.Count(p => p.IsSold);
                var pendingCount = _cachedPrescriptions.Count(p => !p.IsSold);
                var totalSales = _cachedPrescriptions.Where(p => p.IsSold).Sum(p => p.TotalAmount);
                
                // Başlığı güncelle
                lblTitle.Text = $"Reçete Listesi | Toplam: {_cachedPrescriptions.Count} | Satıldı: {soldCount} | Bekliyor: {pendingCount} | Toplam Satış: {totalSales:C2}";
            }
            catch (Exception ex)
            {
                XtraMessageBox.Show($"Reçeteler yüklenirken hata oluştu: {ex.Message}", "Hata", 
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            finally
            {
                gridControl1.EndUpdate();
            }
        }

        private void btnRefresh_Click(object sender, EventArgs e)
        {
            LoadData();
            // Gereksiz mesaj kutusu kaldırıldı - performans için
        }

        private void btnViewDetails_Click(object sender, EventArgs e)
        {
            ShowPrescriptionDetails();
        }

        private void gridView1_DoubleClick(object sender, EventArgs e)
        {
            ShowPrescriptionDetails();
        }

        private void ShowPrescriptionDetails()
        {
            var selectedPrescription = gridView1.GetFocusedRow() as Prescription;
            if (selectedPrescription == null)
            {
                XtraMessageBox.Show("Lütfen bir reçete seçiniz.", "Uyarı", 
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            try
            {
                using (var frm = new FrmPrescriptionDetails(selectedPrescription.Id))
                {
                    frm.ShowDialog();
                }
            }
            catch (Exception ex)
            {
                XtraMessageBox.Show($"Detaylar gösterilirken hata oluştu: {ex.Message}", "Hata", 
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnSellPrescription_Click(object sender, EventArgs e)
        {
            var selectedPrescription = gridView1.GetFocusedRow() as Prescription;
            if (selectedPrescription == null)
            {
                XtraMessageBox.Show("Lütfen bir reçete seçiniz.", "Uyarı", 
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            // Zaten satılmış mı kontrol et
            if (selectedPrescription.IsSold)
            {
                XtraMessageBox.Show("Bu reçete zaten satılmış.", "Bilgi", 
                    MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }

            try
            {
                // İlaçları getir ve toplam tutarı hesapla
                var items = _prescriptionChecker.GetPrescriptionItems(selectedPrescription.Id);
                var drugService = new DrugService();
                decimal totalAmount = 0;

                foreach (var item in items)
                {
                    var drug = drugService.GetAll().FirstOrDefault(d => d.Id == item.DrugId);
                    if (drug != null)
                    {
                        totalAmount += drug.Price;
                    }
                }

                // Onay al
                var result = XtraMessageBox.Show(
                    $"Reçete No: {selectedPrescription.PrescriptionNumber}\n" +
                    $"Hasta: {selectedPrescription.PatientName} {selectedPrescription.PatientSurname}\n" +
                    $"Toplam Tutar: {totalAmount:C2}\n\n" +
                    $"Satış işlemini onaylıyor musunuz?",
                    "Satış Onayı",
                    MessageBoxButtons.YesNo,
                    MessageBoxIcon.Question);

                if (result == DialogResult.Yes)
                {
                    _prescriptionChecker.MarkAsSold(selectedPrescription.Id, totalAmount);
                    LoadData();
                    XtraMessageBox.Show($"Satış başarıyla tamamlandı!\n\nToplam Tutar: {totalAmount:C2}", 
                        "Başarılı", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
            catch (Exception ex)
            {
                XtraMessageBox.Show($"Satış işlemi sırasında hata oluştu: {ex.Message}", "Hata", 
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnPrintReceipt_Click(object sender, EventArgs e)
        {
            var selectedPrescription = gridView1.GetFocusedRow() as Prescription;
            if (selectedPrescription == null)
            {
                XtraMessageBox.Show("Lütfen bir reçete seçiniz.", "Uyarı", 
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            // Sadece satılmış reçeteler için fiş yazdırılabilir
            if (!selectedPrescription.IsSold)
            {
                XtraMessageBox.Show(
                    "Sadece satılmış reçeteler için fiş yazdırabilirsiniz.\n\n" +
                    "Önce 'Reçete Sat' butonuna tıklayarak satışı gerçekleştirin.",
                    "Bilgi",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Information);
                return;
            }

            try
            {
                var printer = new ReceiptPrinter();
                printer.PreparePrescriptionReceipt(selectedPrescription.Id);
                
                // Önizleme göster
                var result = XtraMessageBox.Show(
                    "Fiş yazdırmak istiyor musunuz?\n\n" +
                    "Evet = Yazıcıya gönder\n" +
                    "Hayır = Önizleme göster\n" +
                    "İptal = İşlemi iptal et",
                    "Yazdırma",
                    MessageBoxButtons.YesNoCancel,
                    MessageBoxIcon.Question);

                if (result == DialogResult.Yes)
                {
                    // Doğrudan yazdır
                    printer.Print();
                    XtraMessageBox.Show("Fiş yazıcıya gönderildi.", "Başarılı", 
                        MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                else if (result == DialogResult.No)
                {
                    // Önizleme göster
                    var printDoc = printer.GetPrintDocument();
                    using (var previewDialog = new PrintPreviewDialog())
                    {
                        previewDialog.Document = printDoc;
                        previewDialog.Width = 800;
                        previewDialog.Height = 600;
                        previewDialog.ShowDialog();
                    }
                }
            }
            catch (Exception ex)
            {
                XtraMessageBox.Show($"Yazdırma hatası: {ex.Message}", "Hata", 
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}

