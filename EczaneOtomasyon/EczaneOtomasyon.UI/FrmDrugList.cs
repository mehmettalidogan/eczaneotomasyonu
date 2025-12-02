using System;
using System.Linq;
using System.Windows.Forms;
using DevExpress.XtraEditors;
using DevExpress.XtraBars;
using EczaneOtomasyon.Business;
using EczaneOtomasyon.DataAccess;
using DevExpress.LookAndFeel;
using System.Drawing;

namespace EczaneOtomasyon.UI
{
    public partial class FrmDrugList : DevExpress.XtraBars.Ribbon.RibbonForm
    {
        private readonly DrugService _drugService;

        public FrmDrugList()
        {
            InitializeComponent();
            
            // Global Skin
            UserLookAndFeel.Default.SkinName = "Office 2019 Colorful";
            
            _drugService = new DrugService();
        }

        protected override void OnLoad(EventArgs e)
        {
            base.OnLoad(e);
            LoadData();
            UpdateStatistics();
        }

        private void LoadData()
        {
            var drugs = _drugService.GetAll();
            gridControl1.DataSource = drugs;
            lblLastUpdate.Caption = $"Son Güncelleme: {DateTime.Now:HH:mm:ss}";
        }

        private void UpdateStatistics()
        {
            var drugs = _drugService.GetAll();
            
            int totalDrugs = drugs.Count;
            int distinctSubstances = drugs.Select(d => d.ActiveSubstance).Distinct().Count();
            var mostExpensive = drugs.OrderByDescending(d => d.Price).FirstOrDefault();

            lblTotalDrugsVal.Text = totalDrugs.ToString();
            lblActiveSubstanceVal.Text = distinctSubstances.ToString();
            lblMaxPriceVal.Text = mostExpensive != null ? $"{mostExpensive.Price:C2}\n({mostExpensive.Name})" : "-";
            
            lblTotalDrugsStatus.Caption = $"Toplam İlaç: {totalDrugs}";
        }

        private void btnAdd_ItemClick(object sender, ItemClickEventArgs e)
        {
            using (var frm = new FrmDrugEdit())
            {
                if (frm.ShowDialog() == DialogResult.OK)
                {
                    try
                    {
                        _drugService.Add(frm.Drug);
                        LoadData();
                        UpdateStatistics();
                    }
                    catch (Exception ex)
                    {
                        XtraMessageBox.Show($"Hata: {ex.Message}", "Hata", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
            }
        }

        private void btnEdit_ItemClick(object sender, ItemClickEventArgs e)
        {
            var selectedRow = gridView1.GetFocusedRow() as Drug;
            if (selectedRow == null) return;

            using (var frm = new FrmDrugEdit())
            {
                frm.Drug = selectedRow; 
                if (frm.ShowDialog() == DialogResult.OK)
                {
                    try
                    {
                        _drugService.Update(frm.Drug);
                        LoadData();
                        UpdateStatistics();
                    }
                    catch (Exception ex)
                    {
                        XtraMessageBox.Show($"Hata: {ex.Message}", "Hata", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
            }
        }

        private void btnDelete_ItemClick(object sender, ItemClickEventArgs e)
        {
            var selectedRow = gridView1.GetFocusedRow() as Drug;
            if (selectedRow == null) return;

            if (XtraMessageBox.Show($"{selectedRow.Name} adlı ilacı silmek istiyor musunuz?", "Onay", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            {
                try
                {
                    _drugService.Delete(selectedRow.Id);
                    LoadData();
                    UpdateStatistics();
                }
                catch (Exception ex)
                {
                    XtraMessageBox.Show($"Hata: {ex.Message}", "Hata", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        private void btnSearch_Click(object sender, EventArgs e)
        {
            var searchText = txtSearch.Text.ToLower();
            var allDrugs = _drugService.GetAll();
            
            if (string.IsNullOrWhiteSpace(searchText))
            {
                gridControl1.DataSource = allDrugs;
            }
            else
            {
                var filtered = allDrugs.Where(d => 
                    d.Name.ToLower().Contains(searchText) || 
                    d.ActiveSubstance.ToLower().Contains(searchText)).ToList();
                gridControl1.DataSource = filtered;
            }
        }
    }
}
