using System;
using System.Windows.Forms;
using DevExpress.XtraEditors;
using EczaneOtomasyon.DataAccess;
using EczaneOtomasyon.Business;
using EczaneOtomasyon.Business.Interfaces;
using EczaneOtomasyon.Business.Validation;

namespace EczaneOtomasyon.UI
{
    public partial class FrmDrugEdit : DevExpress.XtraEditors.XtraForm
    {
        public Drug Drug { get; set; }
        private readonly IBarcodeService _barcodeService;
        private readonly IValidator<Drug> _drugValidator;
        private bool _isWaitingForBarcode = false;

        public FrmDrugEdit(IBarcodeService barcodeService, IValidator<Drug> drugValidator)
        {
            InitializeComponent();
            Drug = new Drug();
            _barcodeService = barcodeService;
            _drugValidator = drugValidator;
            _barcodeService.BarcodeRead += BarcodeService_BarcodeRead;
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
                txtDosage.Value = Drug.DosageMg ?? 0; // Nullable int? to decimal conversion
                txtCompany.Text = Drug.Company;
                txtCategory.Text = Drug.Category;
                txtPrice.Value = Drug.Price;
                txtBarcode.Text = Drug.Barcode;
            }
        }

        protected override void OnKeyPress(KeyPressEventArgs e)
        {
            base.OnKeyPress(e);
            
            // Barkod okuma modunda ise tuş vuruşlarını topla
            if (_isWaitingForBarcode)
            {
                _barcodeService.ProcessKeyPress(e.KeyChar);
                e.Handled = true; // Tuşu form kontrollerine gönderme
            }
        }

        private void BarcodeService_BarcodeRead(object? sender, BarcodeReadEventArgs e)
        {
            // Barkod okundu
            txtBarcode.Text = e.Barcode;
            _isWaitingForBarcode = false;
            btnScanBarcode.Text = "Oku";
            
            // Barkod formatını kontrol et
            var format = _barcodeService.GetBarcodeFormat(e.Barcode);
            
            if (format == BarcodeFormat.EAN13)
            {
                // EAN-13 doğrulama
                if (!_barcodeService.ValidateEAN13(e.Barcode))
                {
                    XtraMessageBox.Show("Geçersiz EAN-13 barkodu!", "Uyarı", 
                        MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
            }
        }

        private void btnScanBarcode_Click(object sender, EventArgs e)
        {
            if (_isWaitingForBarcode)
            {
                // Okuma modunu iptal et
                _isWaitingForBarcode = false;
                btnScanBarcode.Text = "Oku";
            }
            else
            {
                // Okuma modunu başlat
                _isWaitingForBarcode = true;
                btnScanBarcode.Text = "İptal";
                XtraMessageBox.Show(
                    "Barkod okuyucu ile ilacın barkodunu okutun.\n\n" +
                    "Veya barkod numarasını manuel olarak 'Barkod' alanına yazabilirsiniz.",
                    "Barkod Okuma", 
                    MessageBoxButtons.OK, 
                    MessageBoxIcon.Information);
            }
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            Drug.Name = txtName.Text.Trim();
            Drug.ActiveSubstance = txtActiveSubstance.Text.Trim();
            Drug.Form = txtForm.Text.Trim();
            Drug.DosageMg = txtDosage.Value > 0 ? (int?)txtDosage.Value : null;
            Drug.Company = txtCompany.Text.Trim();
            Drug.Category = txtCategory.Text.Trim();
            Drug.Price = txtPrice.Value;
            Drug.Barcode = txtBarcode.Text.Trim();

            var validationResult = _drugValidator.Validate(Drug);
            if (!validationResult.IsValid)
            {
                XtraMessageBox.Show(validationResult.GetErrorMessage(), "Doğrulama Hatası", 
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            if (!string.IsNullOrWhiteSpace(Drug.Barcode))
            {
                if (!_barcodeService.ValidateBarcode(Drug.Barcode))
                {
                    XtraMessageBox.Show("Geçersiz barkod formatı!", "Uyarı", 
                        MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }
            }

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

