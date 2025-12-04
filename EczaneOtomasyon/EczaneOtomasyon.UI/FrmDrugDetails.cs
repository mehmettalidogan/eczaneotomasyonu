using System;
using System.Windows.Forms;
using DevExpress.XtraEditors;
using EczaneOtomasyon.Business;
using EczaneOtomasyon.DataAccess;

namespace EczaneOtomasyon.UI
{
    public partial class FrmDrugDetails : DevExpress.XtraEditors.XtraForm
    {
        private readonly Drug _selectedDrug;
        private readonly DrugService _drugService;

        public FrmDrugDetails(Drug drug)
        {
            InitializeComponent();
            _selectedDrug = drug;
            _drugService = new DrugService();
            LoadDetails();
        }

        private void LoadDetails()
        {
            lblName.Text = _selectedDrug.Name;
            lblActiveSubstance.Text = $"Etken Madde: {_selectedDrug.ActiveSubstance}";
            lblForm.Text = $"Form: {_selectedDrug.Form}";
            lblDosage.Text = $"Doz: {_selectedDrug.DosageMg} mg";
            lblCategory.Text = $"Kategori: {_selectedDrug.Category}";
            lblCompany.Text = $"Firma: {_selectedDrug.Company}";
            lblPrice.Text = $"{_selectedDrug.Price:C2}";
        }

        private void btnGetAlternatives_Click(object sender, EventArgs e)
        {
            try
            {
                var allDrugs = _drugService.GetAll();
                var alternatives = DrugSimilarityService.GetAlternatives(_selectedDrug, allDrugs);
                
                gridControl1.DataSource = alternatives;
                
                if (alternatives.Count == 0)
                {
                    XtraMessageBox.Show("Uygun kriterlerde muadil ilaç bulunamadı.", "Bilgi", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
            catch (Exception ex)
            {
                XtraMessageBox.Show($"Öneriler getirilirken hata oluştu: {ex.Message}", "Hata", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}

