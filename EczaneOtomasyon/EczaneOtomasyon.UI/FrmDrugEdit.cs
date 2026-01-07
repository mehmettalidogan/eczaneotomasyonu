using System;
using System.Windows.Forms;
using DevExpress.XtraEditors;
using EczaneOtomasyon.DataAccess;
using EczaneOtomasyon.Business;
using EczaneOtomasyon.Business.Interfaces;

namespace EczaneOtomasyon.UI
{
    public partial class FrmDrugEdit : DevExpress.XtraEditors.XtraForm
    {
        public Drug Drug { get; set; }
        private readonly IBarcodeService _barcodeService;
        private bool _isWaitingForBarcode = false;

        // Dependency Injection ile servis alınıyor
        public FrmDrugEdit(IBarcodeService barcodeService)
        {
            InitializeComponent();
            Drug = new Drug(); // Default new drug
            _barcodeService = barcodeService;
            
            // Barkod okuma eventi
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
            // Basic Validation
            if (string.IsNullOrWhiteSpace(txtName.Text))
            {
                XtraMessageBox.Show("İlaç adı boş olamaz!", "Uyarı", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            // Barkod validasyonu
            if (!string.IsNullOrWhiteSpace(txtBarcode.Text))
            {
                if (!_barcodeService.ValidateBarcode(txtBarcode.Text))
                {
                    XtraMessageBox.Show("Geçersiz barkod formatı!", "Uyarı", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }
            }

            Drug.Name = txtName.Text;
            Drug.ActiveSubstance = txtActiveSubstance.Text;
            Drug.Form = txtForm.Text;
            Drug.DosageMg = txtDosage.Value > 0 ? (int?)txtDosage.Value : null; // 0 ise null olarak kaydet
            Drug.Company = txtCompany.Text;
            Drug.Category = txtCategory.Text;
            Drug.Price = txtPrice.Value;
            Drug.Barcode = txtBarcode.Text.Trim();

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

