namespace EczaneOtomasyon.UI
{
    partial class FrmDrugList
    {
        private System.ComponentModel.IContainer components = null;

        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FrmDrugList));
            this.ribbonControl1 = new DevExpress.XtraBars.Ribbon.RibbonControl();
            this.btnAdd = new DevExpress.XtraBars.BarButtonItem();
            this.btnEdit = new DevExpress.XtraBars.BarButtonItem();
            this.btnDelete = new DevExpress.XtraBars.BarButtonItem();
            this.btnNewPrescription = new DevExpress.XtraBars.BarButtonItem();
            this.btnPrescriptionList = new DevExpress.XtraBars.BarButtonItem();
            this.lblTotalDrugsStatus = new DevExpress.XtraBars.BarStaticItem();
            this.lblLastUpdate = new DevExpress.XtraBars.BarStaticItem();
            this.ribbonPage1 = new DevExpress.XtraBars.Ribbon.RibbonPage();
            this.ribbonPage2 = new DevExpress.XtraBars.Ribbon.RibbonPage();
            this.ribbonPage3 = new DevExpress.XtraBars.Ribbon.RibbonPage();
            this.ribbonPageGroup1 = new DevExpress.XtraBars.Ribbon.RibbonPageGroup();
            this.ribbonPageGroup2 = new DevExpress.XtraBars.Ribbon.RibbonPageGroup();
            this.ribbonStatusBar1 = new DevExpress.XtraBars.Ribbon.RibbonStatusBar();
            this.gridControl1 = new DevExpress.XtraGrid.GridControl();
            this.gridView1 = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.colId = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colName = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colActiveSubstance = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colForm = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colDosageMg = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colCompany = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colCategory = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colPrice = new DevExpress.XtraGrid.Columns.GridColumn();
            this.sidePanel = new DevExpress.XtraEditors.PanelControl();
            this.grpMaxPrice = new DevExpress.XtraEditors.GroupControl();
            this.lblMaxPriceVal = new DevExpress.XtraEditors.LabelControl();
            this.grpActiveSubstance = new DevExpress.XtraEditors.GroupControl();
            this.lblActiveSubstanceVal = new DevExpress.XtraEditors.LabelControl();
            this.grpTotalDrugs = new DevExpress.XtraEditors.GroupControl();
            this.lblTotalDrugsVal = new DevExpress.XtraEditors.LabelControl();
            this.panelSearch = new DevExpress.XtraEditors.PanelControl();
            this.btnSearch = new DevExpress.XtraEditors.SimpleButton();
            this.txtSearch = new DevExpress.XtraEditors.TextEdit();
            ((System.ComponentModel.ISupportInitialize)(this.ribbonControl1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridControl1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridView1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.sidePanel)).BeginInit();
            this.sidePanel.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.grpMaxPrice)).BeginInit();
            this.grpMaxPrice.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.grpActiveSubstance)).BeginInit();
            this.grpActiveSubstance.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.grpTotalDrugs)).BeginInit();
            this.grpTotalDrugs.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.panelSearch)).BeginInit();
            this.panelSearch.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.txtSearch.Properties)).BeginInit();
            this.SuspendLayout();
            
            // 
            // ribbonControl1
            // 
            this.ribbonControl1.ExpandCollapseItem.Id = 0;
            this.ribbonControl1.Items.AddRange(new DevExpress.XtraBars.BarItem[] {
            this.ribbonControl1.ExpandCollapseItem,
            this.btnAdd,
            this.btnEdit,
            this.btnDelete,
            this.btnNewPrescription,
            this.btnPrescriptionList,
            this.lblTotalDrugsStatus,
            this.lblLastUpdate});
            this.ribbonControl1.Location = new System.Drawing.Point(0, 0);
            this.ribbonControl1.MaxItemId = 8;
            this.ribbonControl1.Name = "ribbonControl1";
            this.ribbonControl1.Pages.AddRange(new DevExpress.XtraBars.Ribbon.RibbonPage[] {
            this.ribbonPage1,
            this.ribbonPage2,
            this.ribbonPage3});
            this.ribbonControl1.Size = new System.Drawing.Size(1100, 158);
            this.ribbonControl1.StatusBar = this.ribbonStatusBar1;
            
            // 
            // btnAdd
            // 
            this.btnAdd.Caption = "Ekle";
            this.btnAdd.Id = 1;
            this.btnAdd.Name = "btnAdd";
            this.btnAdd.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.btnAdd_ItemClick);
            
            // 
            // btnEdit
            // 
            this.btnEdit.Caption = "Düzenle";
            this.btnEdit.Id = 2;
            this.btnEdit.Name = "btnEdit";
            this.btnEdit.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.btnEdit_ItemClick);
            
            // 
            // btnDelete
            // 
            this.btnDelete.Caption = "Sil";
            this.btnDelete.Id = 3;
            this.btnDelete.Name = "btnDelete";
            this.btnDelete.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.btnDelete_ItemClick);

            // 
            // btnNewPrescription
            // 
            this.btnNewPrescription.Caption = "Yeni Reçete";
            this.btnNewPrescription.Id = 6;
            this.btnNewPrescription.Name = "btnNewPrescription";
            this.btnNewPrescription.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.btnNewPrescription_ItemClick);

            // 
            // btnPrescriptionList
            // 
            this.btnPrescriptionList.Caption = "Reçete Listesi";
            this.btnPrescriptionList.Id = 7;
            this.btnPrescriptionList.Name = "btnPrescriptionList";
            this.btnPrescriptionList.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.btnPrescriptionList_ItemClick);

            // 
            // lblTotalDrugsStatus
            // 
            this.lblTotalDrugsStatus.Caption = "Toplam İlaç: 0";
            this.lblTotalDrugsStatus.Id = 4;
            this.lblTotalDrugsStatus.Name = "lblTotalDrugsStatus";
            
            // 
            // lblLastUpdate
            // 
            this.lblLastUpdate.Alignment = DevExpress.XtraBars.BarItemLinkAlignment.Right;
            this.lblLastUpdate.Caption = "Son Güncelleme: -";
            this.lblLastUpdate.Id = 5;
            this.lblLastUpdate.Name = "lblLastUpdate";

            // 
            // ribbonPage1
            // 
            this.ribbonPage1.Groups.AddRange(new DevExpress.XtraBars.Ribbon.RibbonPageGroup[] {
            this.ribbonPageGroup1});
            this.ribbonPage1.Name = "ribbonPage1";
            this.ribbonPage1.Text = "İlaç Yönetimi";
            
            // 
            // ribbonPage2
            // 
            this.ribbonPage2.Groups.AddRange(new DevExpress.XtraBars.Ribbon.RibbonPageGroup[] {
            this.ribbonPageGroup2});
            this.ribbonPage2.Name = "ribbonPage2";
            this.ribbonPage2.Text = "Reçete Yönetimi";
            
            // 
            // ribbonPage3
            // 
            this.ribbonPage3.Name = "ribbonPage3";
            this.ribbonPage3.Text = "Stok Yönetimi";
            
            // 
            // ribbonPageGroup1
            // 
            this.ribbonPageGroup1.ItemLinks.Add(this.btnAdd);
            this.ribbonPageGroup1.ItemLinks.Add(this.btnEdit);
            this.ribbonPageGroup1.ItemLinks.Add(this.btnDelete);
            this.ribbonPageGroup1.Name = "ribbonPageGroup1";
            this.ribbonPageGroup1.Text = "Temel İşlemler";

            // 
            // ribbonPageGroup2
            // 
            this.ribbonPageGroup2.ItemLinks.Add(this.btnNewPrescription);
            this.ribbonPageGroup2.ItemLinks.Add(this.btnPrescriptionList);
            this.ribbonPageGroup2.Name = "ribbonPageGroup2";
            this.ribbonPageGroup2.Text = "Reçete İşlemleri";
            
            // 
            // ribbonStatusBar1
            // 
            this.ribbonStatusBar1.ItemLinks.Add(this.lblTotalDrugsStatus);
            this.ribbonStatusBar1.ItemLinks.Add(this.lblLastUpdate);
            this.ribbonStatusBar1.Location = new System.Drawing.Point(0, 776);
            this.ribbonStatusBar1.Name = "ribbonStatusBar1";
            this.ribbonStatusBar1.Ribbon = this.ribbonControl1;
            this.ribbonStatusBar1.Size = new System.Drawing.Size(1100, 24);

            // 
            // panelSearch
            // 
            this.panelSearch.Controls.Add(this.btnSearch);
            this.panelSearch.Controls.Add(this.txtSearch);
            this.panelSearch.Dock = System.Windows.Forms.DockStyle.Top;
            this.panelSearch.Location = new System.Drawing.Point(0, 158);
            this.panelSearch.Name = "panelSearch";
            this.panelSearch.Size = new System.Drawing.Size(1100, 50);
            this.panelSearch.TabIndex = 2;
            
            // 
            // txtSearch
            // 
            this.txtSearch.Location = new System.Drawing.Point(12, 15);
            this.txtSearch.MenuManager = this.ribbonControl1;
            this.txtSearch.Name = "txtSearch";
            this.txtSearch.Properties.NullText = "İlaç adı / etken madde ara...";
            this.txtSearch.Size = new System.Drawing.Size(250, 20);
            this.txtSearch.TabIndex = 0;
            
            // 
            // btnSearch
            // 
            this.btnSearch.Location = new System.Drawing.Point(270, 13);
            this.btnSearch.Name = "btnSearch";
            this.btnSearch.Size = new System.Drawing.Size(75, 23);
            this.btnSearch.TabIndex = 1;
            this.btnSearch.Text = "Ara";
            this.btnSearch.Click += new System.EventHandler(this.btnSearch_Click);

            // 
            // sidePanel
            // 
            this.sidePanel.Controls.Add(this.grpMaxPrice);
            this.sidePanel.Controls.Add(this.grpActiveSubstance);
            this.sidePanel.Controls.Add(this.grpTotalDrugs);
            this.sidePanel.Dock = System.Windows.Forms.DockStyle.Right;
            this.sidePanel.Location = new System.Drawing.Point(850, 208);
            this.sidePanel.Name = "sidePanel";
            this.sidePanel.Padding = new System.Windows.Forms.Padding(5);
            this.sidePanel.Size = new System.Drawing.Size(250, 568);
            this.sidePanel.TabIndex = 3;

            // 
            // grpTotalDrugs
            // 
            this.grpTotalDrugs.Controls.Add(this.lblTotalDrugsVal);
            this.grpTotalDrugs.Dock = System.Windows.Forms.DockStyle.Top;
            this.grpTotalDrugs.Location = new System.Drawing.Point(7, 7);
            this.grpTotalDrugs.Name = "grpTotalDrugs";
            this.grpTotalDrugs.Size = new System.Drawing.Size(236, 100);
            this.grpTotalDrugs.TabIndex = 0;
            this.grpTotalDrugs.Text = "Toplam İlaç";
            
            // 
            // lblTotalDrugsVal
            // 
            this.lblTotalDrugsVal.Appearance.Font = new System.Drawing.Font("Tahoma", 20F, System.Drawing.FontStyle.Bold);
            this.lblTotalDrugsVal.Appearance.Options.UseFont = true;
            this.lblTotalDrugsVal.Appearance.Options.UseTextOptions = true;
            this.lblTotalDrugsVal.Appearance.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.lblTotalDrugsVal.AutoSizeMode = DevExpress.XtraEditors.LabelAutoSizeMode.None;
            this.lblTotalDrugsVal.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lblTotalDrugsVal.Location = new System.Drawing.Point(2, 23);
            this.lblTotalDrugsVal.Name = "lblTotalDrugsVal";
            this.lblTotalDrugsVal.Size = new System.Drawing.Size(232, 75);
            this.lblTotalDrugsVal.TabIndex = 0;
            this.lblTotalDrugsVal.Text = "0";

            // 
            // grpActiveSubstance
            // 
            this.grpActiveSubstance.Controls.Add(this.lblActiveSubstanceVal);
            this.grpActiveSubstance.Dock = System.Windows.Forms.DockStyle.Top;
            this.grpActiveSubstance.Location = new System.Drawing.Point(7, 117);
            this.grpActiveSubstance.Name = "grpActiveSubstance";
            this.grpActiveSubstance.Size = new System.Drawing.Size(236, 100);
            this.grpActiveSubstance.TabIndex = 1;
            this.grpActiveSubstance.Text = "Farklı Etken Madde";

            // 
            // lblActiveSubstanceVal
            // 
            this.lblActiveSubstanceVal.Appearance.Font = new System.Drawing.Font("Tahoma", 20F, System.Drawing.FontStyle.Bold);
            this.lblActiveSubstanceVal.Appearance.Options.UseFont = true;
            this.lblActiveSubstanceVal.Appearance.Options.UseTextOptions = true;
            this.lblActiveSubstanceVal.Appearance.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.lblActiveSubstanceVal.AutoSizeMode = DevExpress.XtraEditors.LabelAutoSizeMode.None;
            this.lblActiveSubstanceVal.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lblActiveSubstanceVal.Location = new System.Drawing.Point(2, 23);
            this.lblActiveSubstanceVal.Name = "lblActiveSubstanceVal";
            this.lblActiveSubstanceVal.Size = new System.Drawing.Size(232, 75);
            this.lblActiveSubstanceVal.TabIndex = 0;
            this.lblActiveSubstanceVal.Text = "0";

            // 
            // grpMaxPrice
            // 
            this.grpMaxPrice.Controls.Add(this.lblMaxPriceVal);
            this.grpMaxPrice.Dock = System.Windows.Forms.DockStyle.Top;
            this.grpMaxPrice.Location = new System.Drawing.Point(7, 227);
            this.grpMaxPrice.Name = "grpMaxPrice";
            this.grpMaxPrice.Size = new System.Drawing.Size(236, 100);
            this.grpMaxPrice.TabIndex = 2;
            this.grpMaxPrice.Text = "En Yüksek Fiyatlı";
            
            // 
            // lblMaxPriceVal
            // 
            this.lblMaxPriceVal.Appearance.Font = new System.Drawing.Font("Tahoma", 12F, System.Drawing.FontStyle.Bold);
            this.lblMaxPriceVal.Appearance.Options.UseFont = true;
            this.lblMaxPriceVal.Appearance.Options.UseTextOptions = true;
            this.lblMaxPriceVal.Appearance.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.lblMaxPriceVal.Appearance.TextOptions.WordWrap = DevExpress.Utils.WordWrap.Wrap;
            this.lblMaxPriceVal.AutoSizeMode = DevExpress.XtraEditors.LabelAutoSizeMode.None;
            this.lblMaxPriceVal.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lblMaxPriceVal.Location = new System.Drawing.Point(2, 23);
            this.lblMaxPriceVal.Name = "lblMaxPriceVal";
            this.lblMaxPriceVal.Size = new System.Drawing.Size(232, 75);
            this.lblMaxPriceVal.TabIndex = 0;
            this.lblMaxPriceVal.Text = "-";

            // 
            // gridControl1
            // 
            this.gridControl1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.gridControl1.Location = new System.Drawing.Point(0, 208);
            this.gridControl1.MainView = this.gridView1;
            this.gridControl1.MenuManager = this.ribbonControl1;
            this.gridControl1.Name = "gridControl1";
            this.gridControl1.Size = new System.Drawing.Size(850, 568);
            this.gridControl1.TabIndex = 4;
            this.gridControl1.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] {
            this.gridView1});
            
            // 
            // gridView1
            // 
            this.gridView1.Columns.AddRange(new DevExpress.XtraGrid.Columns.GridColumn[] {
            this.colId,
            this.colName,
            this.colActiveSubstance,
            this.colForm,
            this.colDosageMg,
            this.colCompany,
            this.colCategory,
            this.colPrice});
            this.gridView1.GridControl = this.gridControl1;
            this.gridView1.GroupCount = 1;
            this.gridView1.Name = "gridView1";
            this.gridView1.OptionsBehavior.Editable = false;
            this.gridView1.OptionsFind.AlwaysVisible = true;
            this.gridView1.OptionsView.EnableAppearanceEvenRow = true;
            this.gridView1.OptionsView.ShowAutoFilterRow = true;
            this.gridView1.OptionsView.ShowGroupPanel = false;
            this.gridView1.SortInfo.AddRange(new DevExpress.XtraGrid.Columns.GridColumnSortInfo[] {
            new DevExpress.XtraGrid.Columns.GridColumnSortInfo(this.colCategory, DevExpress.Data.ColumnSortOrder.Ascending)});
            
            // 
            // colId
            // 
            this.colId.Caption = "Id";
            this.colId.FieldName = "Id";
            this.colId.Name = "colId";
            // 
            // colName
            // 
            this.colName.Caption = "İlaç Adı";
            this.colName.FieldName = "Name";
            this.colName.Name = "colName";
            this.colName.Visible = true;
            this.colName.VisibleIndex = 0;
            // 
            // colActiveSubstance
            // 
            this.colActiveSubstance.Caption = "Etken Madde";
            this.colActiveSubstance.FieldName = "ActiveSubstance";
            this.colActiveSubstance.Name = "colActiveSubstance";
            this.colActiveSubstance.Visible = true;
            this.colActiveSubstance.VisibleIndex = 1;
            // 
            // colForm
            // 
            this.colForm.Caption = "Form";
            this.colForm.FieldName = "Form";
            this.colForm.Name = "colForm";
            this.colForm.Visible = true;
            this.colForm.VisibleIndex = 2;
            // 
            // colDosageMg
            // 
            this.colDosageMg.Caption = "Doz (mg)";
            this.colDosageMg.FieldName = "DosageMg";
            this.colDosageMg.Name = "colDosageMg";
            this.colDosageMg.Visible = true;
            this.colDosageMg.VisibleIndex = 3;
            // 
            // colCompany
            // 
            this.colCompany.Caption = "Firma";
            this.colCompany.FieldName = "Company";
            this.colCompany.Name = "colCompany";
            this.colCompany.Visible = true;
            this.colCompany.VisibleIndex = 4;
            // 
            // colCategory
            // 
            this.colCategory.Caption = "Kategori";
            this.colCategory.FieldName = "Category";
            this.colCategory.Name = "colCategory";
            this.colCategory.Visible = true;
            this.colCategory.VisibleIndex = 5;
            // 
            // colPrice
            // 
            this.colPrice.Caption = "Fiyat";
            this.colPrice.DisplayFormat.FormatString = "c2";
            this.colPrice.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric;
            this.colPrice.FieldName = "Price";
            this.colPrice.Name = "colPrice";
            this.colPrice.Visible = true;
            this.colPrice.VisibleIndex = 6;

            // 
            // FrmDrugList
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1100, 800);
            this.Controls.Add(this.gridControl1);
            this.Controls.Add(this.sidePanel);
            this.Controls.Add(this.panelSearch);
            this.Controls.Add(this.ribbonStatusBar1);
            this.Controls.Add(this.ribbonControl1);
            this.Name = "FrmDrugList";
            this.Ribbon = this.ribbonControl1;
            this.StatusBar = this.ribbonStatusBar1;
            this.Text = "Eczane Otomasyon Sistemi - İlaç Yönetimi";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            ((System.ComponentModel.ISupportInitialize)(this.ribbonControl1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridControl1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridView1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.sidePanel)).EndInit();
            this.sidePanel.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.grpMaxPrice)).EndInit();
            this.grpMaxPrice.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.grpActiveSubstance)).EndInit();
            this.grpActiveSubstance.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.grpTotalDrugs)).EndInit();
            this.grpTotalDrugs.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.panelSearch)).EndInit();
            this.panelSearch.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.txtSearch.Properties)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private DevExpress.XtraBars.Ribbon.RibbonControl ribbonControl1;
        private DevExpress.XtraBars.Ribbon.RibbonPage ribbonPage1;
        private DevExpress.XtraBars.Ribbon.RibbonPage ribbonPage2;
        private DevExpress.XtraBars.Ribbon.RibbonPage ribbonPage3;
        private DevExpress.XtraBars.Ribbon.RibbonPageGroup ribbonPageGroup1;
        private DevExpress.XtraBars.Ribbon.RibbonPageGroup ribbonPageGroup2;
        private DevExpress.XtraBars.Ribbon.RibbonStatusBar ribbonStatusBar1;
        private DevExpress.XtraBars.BarButtonItem btnAdd;
        private DevExpress.XtraBars.BarButtonItem btnEdit;
        private DevExpress.XtraBars.BarButtonItem btnDelete;
        private DevExpress.XtraBars.BarButtonItem btnNewPrescription;
        private DevExpress.XtraBars.BarButtonItem btnPrescriptionList;
        private DevExpress.XtraBars.BarStaticItem lblTotalDrugsStatus;
        private DevExpress.XtraBars.BarStaticItem lblLastUpdate;
        private DevExpress.XtraGrid.GridControl gridControl1;
        private DevExpress.XtraGrid.Views.Grid.GridView gridView1;
        private DevExpress.XtraEditors.PanelControl sidePanel;
        private DevExpress.XtraEditors.PanelControl panelSearch;
        private DevExpress.XtraEditors.TextEdit txtSearch;
        private DevExpress.XtraEditors.SimpleButton btnSearch;
        private DevExpress.XtraEditors.GroupControl grpTotalDrugs;
        private DevExpress.XtraEditors.LabelControl lblTotalDrugsVal;
        private DevExpress.XtraEditors.GroupControl grpActiveSubstance;
        private DevExpress.XtraEditors.LabelControl lblActiveSubstanceVal;
        private DevExpress.XtraEditors.GroupControl grpMaxPrice;
        private DevExpress.XtraEditors.LabelControl lblMaxPriceVal;
        private DevExpress.XtraGrid.Columns.GridColumn colId;
        private DevExpress.XtraGrid.Columns.GridColumn colName;
        private DevExpress.XtraGrid.Columns.GridColumn colActiveSubstance;
        private DevExpress.XtraGrid.Columns.GridColumn colForm;
        private DevExpress.XtraGrid.Columns.GridColumn colDosageMg;
        private DevExpress.XtraGrid.Columns.GridColumn colCompany;
        private DevExpress.XtraGrid.Columns.GridColumn colCategory;
        private DevExpress.XtraGrid.Columns.GridColumn colPrice;
    }
}
