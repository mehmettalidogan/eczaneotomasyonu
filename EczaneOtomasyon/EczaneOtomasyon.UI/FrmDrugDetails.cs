using System;
using System.Windows.Forms;
using DevExpress.XtraEditors;
using EczaneOtomasyon.Business;
using EczaneOtomasyon.Business.Interfaces;
using EczaneOtomasyon.DataAccess;

namespace EczaneOtomasyon.UI
{
    public partial class FrmDrugDetails : DevExpress.XtraEditors.XtraForm
    {
        public Drug Drug { get; set; } = null!;
        private readonly IDrugService _drugService;

        // Dependency Injection ile servis alınıyor
        public FrmDrugDetails(IDrugService drugService)
        {
            InitializeComponent();
            _drugService = drugService;
        }

        protected override void OnLoad(EventArgs e)
        {
            base.OnLoad(e);
            if (Drug != null)
            {
                LoadDetails();
            }
        }

        private void LoadDetails()
        {
            lblName.Text = Drug.Name;
            lblActiveSubstance.Text = $"Etken Madde: {Drug.ActiveSubstance}";
            lblForm.Text = $"Form: {Drug.Form}";
            lblDosage.Text = $"Doz: {Drug.DosageMg} mg";
            lblCategory.Text = $"Kategori: {Drug.Category}";
            lblCompany.Text = $"Firma: {Drug.Company}";
            lblPrice.Text = $"{Drug.Price:C2}";
        }

        private void btnGetAlternatives_Click(object sender, EventArgs e)
        {
            try
            {
                var allDrugs = _drugService.GetAll();
                var alternatives = DrugSimilarityService.GetAlternatives(Drug, allDrugs);
                
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

