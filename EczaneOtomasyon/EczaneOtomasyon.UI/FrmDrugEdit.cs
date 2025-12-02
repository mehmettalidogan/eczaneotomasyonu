using System;
using System.Windows.Forms;
using DevExpress.XtraEditors;
using EczaneOtomasyon.DataAccess;

namespace EczaneOtomasyon.UI
{
    public partial class FrmDrugEdit : DevExpress.XtraEditors.XtraForm
    {
        public Drug Drug { get; set; }

        public FrmDrugEdit()
        {
            InitializeComponent();
            Drug = new Drug(); // Default new drug
        }

        protected override void OnLoad(EventArgs e)
        {
            base.OnLoad(e);
            if (Drug != null && Drug.Id > 0)
            {
                // Edit mode
                txtName.Text = Drug.Name;
                txtActiveSubstance.Text = Drug.ActiveSubstance;
                txtForm.Text = Drug.Form;
                txtDosage.Value = Drug.DosageMg;
                txtCompany.Text = Drug.Company;
                txtCategory.Text = Drug.Category;
                txtPrice.Value = Drug.Price;
            }
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            // Basic Validation
            if (string.IsNullOrWhiteSpace(txtName.Text))
            {
                XtraMessageBox.Show("İlaç adı boş olamaz!", "Uyarı", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            Drug.Name = txtName.Text;
            Drug.ActiveSubstance = txtActiveSubstance.Text;
            Drug.Form = txtForm.Text;
            Drug.DosageMg = (int)txtDosage.Value;
            Drug.Company = txtCompany.Text;
            Drug.Category = txtCategory.Text;
            Drug.Price = txtPrice.Value;

            this.DialogResult = DialogResult.OK;
            this.Close();
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.Cancel;
            this.Close();
        }
    }
}

