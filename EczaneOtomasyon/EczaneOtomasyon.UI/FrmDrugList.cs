using System;
using System.Linq;
using System.Windows.Forms;
using System.Collections.Generic;
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
        private FrmPrescriptionList? _prescriptionListForm;
        private FrmStockManagement? _stockManagementForm;
        
        // Veri cache için
        private List<Drug>? _cachedDrugs;
        private bool _isDataLoaded = false;

        public FrmDrugList()
        {
            // Performans için layout suspend
            this.SuspendLayout();
            
            InitializeComponent();
            
            // Global Skin
            UserLookAndFeel.Default.SkinName = "Office 2019 Colorful";
            
            // Uygulama ikonunu yükle
            LoadApplicationIcon();
            
            _drugService = new DrugService();

            // GridView double-click event
            gridView1.DoubleClick += GridView1_DoubleClick;
            
            // Ribbon sekme değiştiğinde kategori gruplandırmasını kontrol et
            ribbonControl1.SelectedPageChanged += RibbonControl1_SelectedPageChanged;
            
            this.ResumeLayout(false);
        }

        private void LoadApplicationIcon()
        {
            try
            {
                string iconPath = System.IO.Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "Resources", "eczane.ico");
                if (System.IO.File.Exists(iconPath))
                {
                    this.Icon = new Icon(iconPath);
                }
            }
            catch
            {
                // İkon yüklenemezse varsayılan ikon kullanılır
            }
        }

        private void RibbonControl1_SelectedPageChanged(object? sender, EventArgs e)
        {
            if (ribbonControl1.SelectedPage == ribbonPage1) // İlaç Yönetimi
            {
                // İlaç listesini göster
                ShowDrugList();
            }
            else if (ribbonControl1.SelectedPage == ribbonPage2) // Reçete Yönetimi
            {
                // Reçete listesini göster
                ShowPrescriptionList();
            }
            else if (ribbonControl1.SelectedPage == ribbonPage3) // Stok Yönetimi
            {
                // Stok yönetimini göster
                ShowStockManagement();
            }
        }

        private void ShowDrugList()
        {
            this.SuspendLayout();
            try
            {
                // Diğer formları gizle
                if (_prescriptionListForm != null && !_prescriptionListForm.IsDisposed)
                {
                    _prescriptionListForm.Visible = false;
                }
                if (_stockManagementForm != null && !_stockManagementForm.IsDisposed)
                {
                    _stockManagementForm.Visible = false;
                }
                
                // Grid'i ve yan paneli göster
                gridControl1.Visible = true;
                sidePanel.Visible = true;
                panelSearch.Visible = true;
                
                // Kategori gruplandırmasını aktif et (sadece ilk seferde)
                if (gridView1.GroupCount == 0)
                {
                    gridView1.BeginUpdate();
                    colCategory.GroupIndex = 0;
                    gridView1.EndUpdate();
                }
                
                // Veriyi sadece ilk seferde veya yenileme gerektiğinde yükle
                if (!_isDataLoaded)
                {
                    LoadData();
                    UpdateStatistics();
                }
            }
            finally
            {
                this.ResumeLayout(true);
            }
        }

        private void ShowPrescriptionList()
        {
            this.SuspendLayout();
            try
            {
                // Grid ve panelleri gizle
                gridControl1.Visible = false;
                sidePanel.Visible = false;
                panelSearch.Visible = false;
                
                // Stok formunu gizle
                if (_stockManagementForm != null && !_stockManagementForm.IsDisposed)
                {
                    _stockManagementForm.Visible = false;
                }
                
                // Reçete listesi formunu oluştur ve embed et (sadece ilk seferde)
                if (_prescriptionListForm == null || _prescriptionListForm.IsDisposed)
                {
                    _prescriptionListForm = new FrmPrescriptionList();
                    _prescriptionListForm.TopLevel = false;
                    _prescriptionListForm.FormBorderStyle = FormBorderStyle.None;
                    _prescriptionListForm.Dock = DockStyle.Fill;
                    this.Controls.Add(_prescriptionListForm);
                }
                
                _prescriptionListForm.Visible = true;
                _prescriptionListForm.BringToFront();
            }
            finally
            {
                this.ResumeLayout(true);
            }
        }

        private void ShowStockManagement()
        {
            this.SuspendLayout();
            try
            {
                // Grid ve panelleri gizle
                gridControl1.Visible = false;
                sidePanel.Visible = false;
                panelSearch.Visible = false;
                
                // Reçete formunu gizle
                if (_prescriptionListForm != null && !_prescriptionListForm.IsDisposed)
                {
                    _prescriptionListForm.Visible = false;
                }
                
                // Stok yönetimi formunu oluştur ve embed et (sadece ilk seferde)
                if (_stockManagementForm == null || _stockManagementForm.IsDisposed)
                {
                    _stockManagementForm = new FrmStockManagement();
                    _stockManagementForm.TopLevel = false;
                    _stockManagementForm.FormBorderStyle = FormBorderStyle.None;
                    _stockManagementForm.Dock = DockStyle.Fill;
                    this.Controls.Add(_stockManagementForm);
                }
                
                _stockManagementForm.Visible = true;
                _stockManagementForm.BringToFront();
            }
            finally
            {
                this.ResumeLayout(true);
            }
        }

        private void GridView1_DoubleClick(object? sender, EventArgs e)
        {
            if (sender == null || e == null) return;
            
            var ea = e as DevExpress.Utils.DXMouseEventArgs;
            var view = sender as DevExpress.XtraGrid.Views.Grid.GridView;
            
            if (ea == null || view == null) return;
            
            var info = view.CalcHitInfo(ea.Location);
            
            if (info.InRow || info.InRowCell)
            {
                var selectedRow = view.GetFocusedRow() as Drug;
                if (selectedRow != null)
                {
                    using (var detailsForm = new FrmDrugDetails(selectedRow))
                    {
                        detailsForm.ShowDialog();
                    }
                }
            }
        }

        protected override void OnLoad(EventArgs e)
        {
            base.OnLoad(e);
            
            // Başlangıçta İlaç Yönetimi sekmesini seç ve göster
            ribbonControl1.SelectedPage = ribbonPage1;
            ShowDrugList();
        }

        private void LoadData()
        {
            gridControl1.BeginUpdate();
            try
            {
                _cachedDrugs = _drugService.GetAll();
                gridControl1.DataSource = _cachedDrugs;
                lblLastUpdate.Caption = $"Son Güncelleme: {DateTime.Now:HH:mm:ss}";
                _isDataLoaded = true;
            }
            finally
            {
                gridControl1.EndUpdate();
            }
        }

        private void UpdateStatistics()
        {
            // Cache'den kullan, tekrar veritabanına gitme
            var drugs = _cachedDrugs ?? _drugService.GetAll();
            
            if (drugs.Count == 0) return;
            
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
                        _isDataLoaded = false; // Cache'i invalidate et
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
                        _isDataLoaded = false; // Cache'i invalidate et
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
                    _isDataLoaded = false; // Cache'i invalidate et
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
            gridControl1.BeginUpdate();
            try
            {
                var searchText = txtSearch.Text.ToLower();
                
                // Cache'den kullan
                var allDrugs = _cachedDrugs ?? _drugService.GetAll();
                
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
            finally
            {
                gridControl1.EndUpdate();
            }
        }

        private void btnNewPrescription_ItemClick(object sender, ItemClickEventArgs e)
        {
            using (var frm = new FrmPrescriptionEdit())
            {
                if (frm.ShowDialog() == DialogResult.OK)
                {
                    // Reçete eklendikten sonra listeyi yenile
                    if (_prescriptionListForm != null && !_prescriptionListForm.IsDisposed)
                    {
                        _prescriptionListForm.RefreshData(); // Close yerine refresh
                    }
                }
            }
        }

        private void btnPrescriptionList_ItemClick(object sender, ItemClickEventArgs e)
        {
            // Reçete listesi gösteriliyorsa yenile
            if (_prescriptionListForm != null && !_prescriptionListForm.IsDisposed)
            {
                _prescriptionListForm.RefreshData();
            }
            else
            {
                ShowPrescriptionList();
            }
        }

    }
}
