using System;
using System.Linq;
using System.Windows.Forms;
using DevExpress.XtraEditors;
using EczaneOtomasyon.Business;
using EczaneOtomasyon.DataAccess;

namespace EczaneOtomasyon.UI
{
    public partial class FrmPrescriptionList : DevExpress.XtraEditors.XtraForm
    {
        private readonly PrescriptionChecker _prescriptionChecker;

        public FrmPrescriptionList()
        {
            InitializeComponent();
            _prescriptionChecker = new PrescriptionChecker();
            LoadData();
            ConfigureGridAppearance();
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
            try
            {
                var prescriptions = _prescriptionChecker.GetAllPrescriptions();
                gridControl1.DataSource = prescriptions;
                
                // İstatistikleri hesapla
                var soldCount = prescriptions.Count(p => p.IsSold);
                var pendingCount = prescriptions.Count(p => !p.IsSold);
                var totalSales = prescriptions.Where(p => p.IsSold).Sum(p => p.TotalAmount);
                
                // Başlığı güncelle
                lblTitle.Text = $"Reçete Listesi | Toplam: {prescriptions.Count} | Satıldı: {soldCount} | Bekliyor: {pendingCount} | Toplam Satış: {totalSales:C2}";
            }
            catch (Exception ex)
            {
                XtraMessageBox.Show($"Reçeteler yüklenirken hata oluştu: {ex.Message}", "Hata", 
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnRefresh_Click(object sender, EventArgs e)
        {
            LoadData();
            XtraMessageBox.Show("Liste yenilendi.", "Bilgi", MessageBoxButtons.OK, MessageBoxIcon.Information);
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
    }
}

