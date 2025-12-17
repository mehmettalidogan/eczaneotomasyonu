using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;
using DevExpress.XtraEditors;
using EczaneOtomasyon.Business.Interfaces;
using EczaneOtomasyon.DataAccess;

namespace EczaneOtomasyon.UI
{
    public partial class FrmPrescriptionDetails : DevExpress.XtraEditors.XtraForm
    {
        private readonly IPrescriptionChecker _prescriptionChecker;
        private readonly IDrugService _drugService;
        public int PrescriptionId { get; set; }

        // Dependency Injection ile servisler alınıyor
        public FrmPrescriptionDetails(
            IPrescriptionChecker prescriptionChecker,
            IDrugService drugService)
        {
            InitializeComponent();
            _prescriptionChecker = prescriptionChecker;
            _drugService = drugService;
        }

        protected override void OnLoad(EventArgs e)
        {
            base.OnLoad(e);
            LoadPrescriptionDetails();
        }

        private void LoadPrescriptionDetails()
        {
            try
            {
                // Reçete bilgilerini yükle
                var prescription = _prescriptionChecker.GetPrescriptionById(PrescriptionId);
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
                var prescriptionItems = _prescriptionChecker.GetPrescriptionItems(PrescriptionId);
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




