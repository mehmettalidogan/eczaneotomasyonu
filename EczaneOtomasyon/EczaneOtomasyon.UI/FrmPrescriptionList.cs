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
        }

        private void LoadData()
        {
            try
            {
                var prescriptions = _prescriptionChecker.GetAllPrescriptions();
                gridControl1.DataSource = prescriptions;
                
                // Başlığı güncelle
                lblTitle.Text = $"Reçete Listesi ({prescriptions.Count} kayıt)";
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
    }
}

