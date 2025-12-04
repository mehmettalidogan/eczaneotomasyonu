using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Windows.Forms;
using DevExpress.XtraEditors;
using DevExpress.XtraGrid.Views.Grid;
using EczaneOtomasyon.Business;
using EczaneOtomasyon.DataAccess;

namespace EczaneOtomasyon.UI
{
    public partial class FrmPrescriptionEdit : DevExpress.XtraEditors.XtraForm
    {
        private readonly PrescriptionChecker _checker;
        private readonly DrugService _drugService;
        private BindingList<PrescriptionItemDto> _items;

        public FrmPrescriptionEdit()
        {
            InitializeComponent();
            _checker = new PrescriptionChecker();
            _drugService = new DrugService();
            _items = new BindingList<PrescriptionItemDto>();
            
            // Seed Data (İlk kullanımda tablo boşsa doldurur)
            _checker.EnsureSeedData();

            ConfigureGrid();
            LoadLookups();
            gridControl1.DataSource = _items;
            
            // Tarih varsayılan olarak bugün
            dateEdit1.EditValue = DateTime.Now;
        }

        private void ConfigureGrid()
        {
            // Kolonları manuel ekle
            this.gridView1.Columns.Clear();
            var colDrug = this.gridView1.Columns.AddVisible("DrugId", "İlaç");
            colDrug.ColumnEdit = this.repositoryItemLookUpEdit1;
            
            var colDose = this.gridView1.Columns.AddVisible("DailyDoseMg", "Günlük Doz (mg)");
        }

        private void LoadLookups()
        {
            var drugs = _drugService.GetAll();
            repositoryItemLookUpEdit1.DataSource = drugs;
            repositoryItemLookUpEdit1.DisplayMember = "Name";
            repositoryItemLookUpEdit1.ValueMember = "Id";
        }

        // Grid'de İlaç seçilince Adını DTO'ya set et
        private void gridView1_CellValueChanged(object sender, DevExpress.XtraGrid.Views.Base.CellValueChangedEventArgs e)
        {
            if (e.Column.FieldName == "DrugId")
            {
                var row = gridView1.GetRow(e.RowHandle) as PrescriptionItemDto;
                if (row != null && e.Value != null)
                {
                    var drug = _drugService.GetAll().FirstOrDefault(d => d.Id == (int)e.Value);
                    if (drug != null) row.DrugName = drug.Name;
                }
            }
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            // Validasyonlar
            if (string.IsNullOrWhiteSpace(txtPrescriptionNumber.Text))
            {
                XtraMessageBox.Show("Reçete numarası giriniz.", "Uyarı", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtPrescriptionNumber.Focus();
                return;
            }

            if (string.IsNullOrWhiteSpace(txtPatientName.Text))
            {
                XtraMessageBox.Show("Hasta adı giriniz.", "Uyarı", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtPatientName.Focus();
                return;
            }

            if (string.IsNullOrWhiteSpace(txtPatientSurname.Text))
            {
                XtraMessageBox.Show("Hasta soyadı giriniz.", "Uyarı", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtPatientSurname.Focus();
                return;
            }

            if (string.IsNullOrWhiteSpace(txtPatientTC.Text) || txtPatientTC.Text.Length != 11)
            {
                XtraMessageBox.Show("Geçerli bir TC Kimlik No giriniz (11 haneli).", "Uyarı", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtPatientTC.Focus();
                return;
            }

            if (_items.Count == 0)
            {
                XtraMessageBox.Show("Lütfen en az bir ilaç ekleyin.", "Uyarı", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            int age = (int)txtAge.Value;
            var itemList = _items.ToList();

            // 1. Analiz
            var interactionWarnings = _checker.CheckInteractions(itemList);
            var doseWarnings = _checker.CheckDoses(itemList, age);
            var allWarnings = interactionWarnings.Concat(doseWarnings).ToList();

            // 2. Uyarı varsa göster
            if (allWarnings.Count > 0)
            {
                using (var frmWarn = new FrmPrescriptionWarnings(allWarnings))
                {
                    frmWarn.ShowDialog();
                    if (!frmWarn.CanContinue) return;
                }
            }

            // 3. Kaydet
            try
            {
                var prescription = new Prescription
                {
                    PrescriptionNumber = txtPrescriptionNumber.Text.Trim(),
                    PatientName = txtPatientName.Text.Trim(),
                    PatientSurname = txtPatientSurname.Text.Trim(),
                    PatientTC = txtPatientTC.Text.Trim(),
                    PatientAge = age,
                    Date = dateEdit1.DateTime
                };

                var dbItems = itemList.Select(i => new PrescriptionItem
                {
                    DrugId = i.DrugId,
                    DailyDoseMg = i.DailyDoseMg
                }).ToList();

                _checker.SavePrescription(prescription, dbItems);
                XtraMessageBox.Show("Reçete başarıyla oluşturuldu.", "Başarılı", MessageBoxButtons.OK, MessageBoxIcon.Information);
                this.Close();
            }
            catch (Exception ex)
            {
                XtraMessageBox.Show($"Hata: {ex.Message}", "Hata", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

    }
}

