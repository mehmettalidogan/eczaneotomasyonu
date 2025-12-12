using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;
using DevExpress.XtraEditors;
using EczaneOtomasyon.Business;
using EczaneOtomasyon.DataAccess;

namespace EczaneOtomasyon.UI
{
    public partial class FrmPrescriptionDetails : DevExpress.XtraEditors.XtraForm
    {
        private readonly PrescriptionChecker _prescriptionChecker;
        private readonly DrugService _drugService;
        private readonly int _prescriptionId;

        public FrmPrescriptionDetails(int prescriptionId)
        {
            InitializeComponent();
            _prescriptionChecker = new PrescriptionChecker();
            _drugService = new DrugService();
            _prescriptionId = prescriptionId;
            
            LoadPrescriptionDetails();
        }

        private void LoadPrescriptionDetails()
        {
            try
            {
                // Reçete bilgilerini yükle
                var prescription = _prescriptionChecker.GetPrescriptionById(_prescriptionId);
                if (prescription == null)
                {
                    XtraMessageBox.Show("Reçete bulunamadı!", "Hata", 
                        MessageBoxButtons.OK, MessageBoxIcon.Error);
                    this.Close();
                    return;
                }

                // Reçete bilgilerini göster
                lblPrescriptionNumberValue.Text = prescription.PrescriptionNumber;
                lblPatientNameValue.Text = $"{prescription.PatientName} {prescription.PatientSurname}";
                lblTCValue.Text = prescription.PatientTC;
                lblAgeValue.Text = prescription.PatientAge.ToString();
                lblDateValue.Text = prescription.Date.ToString("dd.MM.yyyy HH:mm");

                // İlaçları yükle
                var prescriptionItems = _prescriptionChecker.GetPrescriptionItems(_prescriptionId);
                var allDrugs = _drugService.GetAll();

                var drugDetails = prescriptionItems.Select(item => new
                {
                    DrugName = allDrugs.FirstOrDefault(d => d.Id == item.DrugId)?.Name ?? "Bilinmeyen İlaç",
                    item.DailyDoseMg
                }).ToList();

                gridControl1.DataSource = drugDetails;

                // Grup başlığını güncelle
                grpDrugs.Text = $"Reçetedeki İlaçlar ({drugDetails.Count} adet)";
            }
            catch (Exception ex)
            {
                XtraMessageBox.Show($"Detaylar yüklenirken hata oluştu: {ex.Message}", "Hata", 
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}


