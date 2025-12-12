namespace EczaneOtomasyon.UI
{
    partial class FrmStockManagement
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
            this.layoutControl1 = new DevExpress.XtraLayout.LayoutControl();
            this.gridControl1 = new DevExpress.XtraGrid.GridControl();
            this.gridView1 = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.colId = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colName = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colActiveSubstance = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colCategory = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colStock = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colPrice = new DevExpress.XtraGrid.Columns.GridColumn();
            this.panelControl1 = new DevExpress.XtraEditors.PanelControl();
            this.btnInitializeStocks = new DevExpress.XtraEditors.SimpleButton();
            this.btnRefresh = new DevExpress.XtraEditors.SimpleButton();
            this.btnShowLowStock = new DevExpress.XtraEditors.SimpleButton();
            this.btnShowAll = new DevExpress.XtraEditors.SimpleButton();
            this.groupControl1 = new DevExpress.XtraEditors.GroupControl();
            this.lblOutOfStockCount = new DevExpress.XtraEditors.LabelControl();
            this.labelControl1 = new DevExpress.XtraEditors.LabelControl();
            this.groupControl2 = new DevExpress.XtraEditors.GroupControl();
            this.lblLowStockCount = new DevExpress.XtraEditors.LabelControl();
            this.labelControl3 = new DevExpress.XtraEditors.LabelControl();
            this.groupControl3 = new DevExpress.XtraEditors.GroupControl();
            this.btnSetStock = new DevExpress.XtraEditors.SimpleButton();
            this.btnRemoveStock = new DevExpress.XtraEditors.SimpleButton();
            this.btnAddStock = new DevExpress.XtraEditors.SimpleButton();
            this.txtQuantity = new DevExpress.XtraEditors.SpinEdit();
            this.labelControl4 = new DevExpress.XtraEditors.LabelControl();
            this.layoutControlGroup1 = new DevExpress.XtraLayout.LayoutControlGroup();
            this.layoutControlItem1 = new DevExpress.XtraLayout.LayoutControlItem();
            this.layoutControlItem2 = new DevExpress.XtraLayout.LayoutControlItem();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControl1)).BeginInit();
            this.layoutControl1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.gridControl1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridView1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.panelControl1)).BeginInit();
            this.panelControl1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.groupControl1)).BeginInit();
            this.groupControl1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.groupControl2)).BeginInit();
            this.groupControl2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.groupControl3)).BeginInit();
            this.groupControl3.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.txtQuantity.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlGroup1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem2)).BeginInit();
            this.SuspendLayout();

            // 
            // layoutControl1
            // 
            this.layoutControl1.Controls.Add(this.gridControl1);
            this.layoutControl1.Controls.Add(this.panelControl1);
            this.layoutControl1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.layoutControl1.Location = new System.Drawing.Point(0, 0);
            this.layoutControl1.Name = "layoutControl1";
            this.layoutControl1.Root = this.layoutControlGroup1;
            this.layoutControl1.Size = new System.Drawing.Size(1200, 700);
            this.layoutControl1.TabIndex = 0;
            this.layoutControl1.Text = "layoutControl1";

            // 
            // gridControl1
            // 
            this.gridControl1.Location = new System.Drawing.Point(12, 12);
            this.gridControl1.MainView = this.gridView1;
            this.gridControl1.Name = "gridControl1";
            this.gridControl1.Size = new System.Drawing.Size(876, 676);
            this.gridControl1.TabIndex = 0;
            this.gridControl1.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] {
            this.gridView1});

            // 
            // gridView1
            // 
            this.gridView1.Columns.AddRange(new DevExpress.XtraGrid.Columns.GridColumn[] {
            this.colId,
            this.colName,
            this.colActiveSubstance,
            this.colCategory,
            this.colStock,
            this.colPrice});
            this.gridView1.GridControl = this.gridControl1;
            this.gridView1.Name = "gridView1";
            this.gridView1.OptionsBehavior.Editable = false;
            this.gridView1.OptionsView.ShowGroupPanel = false;
            this.gridView1.OptionsView.ShowAutoFilterRow = true;

            // 
            // colId
            // 
            this.colId.Caption = "ID";
            this.colId.FieldName = "Id";
            this.colId.Name = "colId";
            this.colId.Width = 50;

            // 
            // colName
            // 
            this.colName.Caption = "İlaç Adı";
            this.colName.FieldName = "Name";
            this.colName.Name = "colName";
            this.colName.Visible = true;
            this.colName.VisibleIndex = 0;
            this.colName.Width = 200;

            // 
            // colActiveSubstance
            // 
            this.colActiveSubstance.Caption = "Etken Madde";
            this.colActiveSubstance.FieldName = "ActiveSubstance";
            this.colActiveSubstance.Name = "colActiveSubstance";
            this.colActiveSubstance.Visible = true;
            this.colActiveSubstance.VisibleIndex = 1;
            this.colActiveSubstance.Width = 150;

            // 
            // colCategory
            // 
            this.colCategory.Caption = "Kategori";
            this.colCategory.FieldName = "Category";
            this.colCategory.Name = "colCategory";
            this.colCategory.Visible = true;
            this.colCategory.VisibleIndex = 2;
            this.colCategory.Width = 120;

            // 
            // colStock
            // 
            this.colStock.Caption = "Stok Miktarı";
            this.colStock.FieldName = "Stock";
            this.colStock.Name = "colStock";
            this.colStock.Visible = true;
            this.colStock.VisibleIndex = 3;
            this.colStock.Width = 100;

            // 
            // colPrice
            // 
            this.colPrice.Caption = "Fiyat";
            this.colPrice.DisplayFormat.FormatString = "c2";
            this.colPrice.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric;
            this.colPrice.FieldName = "Price";
            this.colPrice.Name = "colPrice";
            this.colPrice.Visible = true;
            this.colPrice.VisibleIndex = 4;
            this.colPrice.Width = 100;

            // 
            // panelControl1
            // 
            this.panelControl1.Controls.Add(this.groupControl3);
            this.panelControl1.Controls.Add(this.groupControl2);
            this.panelControl1.Controls.Add(this.groupControl1);
            this.panelControl1.Controls.Add(this.btnShowAll);
            this.panelControl1.Controls.Add(this.btnShowLowStock);
            this.panelControl1.Controls.Add(this.btnRefresh);
            this.panelControl1.Controls.Add(this.btnInitializeStocks);
            this.panelControl1.Location = new System.Drawing.Point(892, 12);
            this.panelControl1.Name = "panelControl1";
            this.panelControl1.Size = new System.Drawing.Size(296, 676);
            this.panelControl1.TabIndex = 1;

            // 
            // btnInitializeStocks
            // 
            this.btnInitializeStocks.Location = new System.Drawing.Point(15, 15);
            this.btnInitializeStocks.Name = "btnInitializeStocks";
            this.btnInitializeStocks.Size = new System.Drawing.Size(266, 35);
            this.btnInitializeStocks.TabIndex = 0;
            this.btnInitializeStocks.Text = "Tüm Stokları Sıfırla (0)";
            this.btnInitializeStocks.Click += new System.EventHandler(this.btnInitializeStocks_Click);

            // 
            // btnRefresh
            // 
            this.btnRefresh.Location = new System.Drawing.Point(15, 60);
            this.btnRefresh.Name = "btnRefresh";
            this.btnRefresh.Size = new System.Drawing.Size(266, 35);
            this.btnRefresh.TabIndex = 1;
            this.btnRefresh.Text = "Yenile";
            this.btnRefresh.Click += new System.EventHandler(this.btnRefresh_Click);

            // 
            // btnShowLowStock
            // 
            this.btnShowLowStock.Location = new System.Drawing.Point(15, 105);
            this.btnShowLowStock.Name = "btnShowLowStock";
            this.btnShowLowStock.Size = new System.Drawing.Size(130, 35);
            this.btnShowLowStock.TabIndex = 2;
            this.btnShowLowStock.Text = "Düşük Stoklar";
            this.btnShowLowStock.Click += new System.EventHandler(this.btnShowLowStock_Click);

            // 
            // btnShowAll
            // 
            this.btnShowAll.Location = new System.Drawing.Point(151, 105);
            this.btnShowAll.Name = "btnShowAll";
            this.btnShowAll.Size = new System.Drawing.Size(130, 35);
            this.btnShowAll.TabIndex = 3;
            this.btnShowAll.Text = "Tümünü Göster";
            this.btnShowAll.Click += new System.EventHandler(this.btnShowAll_Click);

            // 
            // groupControl1
            // 
            this.groupControl1.Controls.Add(this.lblOutOfStockCount);
            this.groupControl1.Controls.Add(this.labelControl1);
            this.groupControl1.Location = new System.Drawing.Point(15, 155);
            this.groupControl1.Name = "groupControl1";
            this.groupControl1.Size = new System.Drawing.Size(266, 80);
            this.groupControl1.TabIndex = 4;
            this.groupControl1.Text = "Stokta Yok";

            // 
            // labelControl1
            // 
            this.labelControl1.Appearance.Font = new System.Drawing.Font("Tahoma", 8F);
            this.labelControl1.Appearance.Options.UseFont = true;
            this.labelControl1.Location = new System.Drawing.Point(15, 30);
            this.labelControl1.Name = "labelControl1";
            this.labelControl1.Size = new System.Drawing.Size(60, 13);
            this.labelControl1.TabIndex = 0;
            this.labelControl1.Text = "İlaç Sayısı:";

            // 
            // lblOutOfStockCount
            // 
            this.lblOutOfStockCount.Appearance.Font = new System.Drawing.Font("Tahoma", 20F, System.Drawing.FontStyle.Bold);
            this.lblOutOfStockCount.Appearance.ForeColor = System.Drawing.Color.Red;
            this.lblOutOfStockCount.Appearance.Options.UseFont = true;
            this.lblOutOfStockCount.Appearance.Options.UseForeColor = true;
            this.lblOutOfStockCount.Location = new System.Drawing.Point(15, 45);
            this.lblOutOfStockCount.Name = "lblOutOfStockCount";
            this.lblOutOfStockCount.Size = new System.Drawing.Size(17, 33);
            this.lblOutOfStockCount.TabIndex = 1;
            this.lblOutOfStockCount.Text = "0";

            // 
            // groupControl2
            // 
            this.groupControl2.Controls.Add(this.lblLowStockCount);
            this.groupControl2.Controls.Add(this.labelControl3);
            this.groupControl2.Location = new System.Drawing.Point(15, 245);
            this.groupControl2.Name = "groupControl2";
            this.groupControl2.Size = new System.Drawing.Size(266, 80);
            this.groupControl2.TabIndex = 5;
            this.groupControl2.Text = "Düşük Stok (<= 10)";

            // 
            // labelControl3
            // 
            this.labelControl3.Appearance.Font = new System.Drawing.Font("Tahoma", 8F);
            this.labelControl3.Appearance.Options.UseFont = true;
            this.labelControl3.Location = new System.Drawing.Point(15, 30);
            this.labelControl3.Name = "labelControl3";
            this.labelControl3.Size = new System.Drawing.Size(60, 13);
            this.labelControl3.TabIndex = 0;
            this.labelControl3.Text = "İlaç Sayısı:";

            // 
            // lblLowStockCount
            // 
            this.lblLowStockCount.Appearance.Font = new System.Drawing.Font("Tahoma", 20F, System.Drawing.FontStyle.Bold);
            this.lblLowStockCount.Appearance.ForeColor = System.Drawing.Color.Orange;
            this.lblLowStockCount.Appearance.Options.UseFont = true;
            this.lblLowStockCount.Appearance.Options.UseForeColor = true;
            this.lblLowStockCount.Location = new System.Drawing.Point(15, 45);
            this.lblLowStockCount.Name = "lblLowStockCount";
            this.lblLowStockCount.Size = new System.Drawing.Size(17, 33);
            this.lblLowStockCount.TabIndex = 1;
            this.lblLowStockCount.Text = "0";

            // 
            // groupControl3
            // 
            this.groupControl3.Controls.Add(this.btnSetStock);
            this.groupControl3.Controls.Add(this.btnRemoveStock);
            this.groupControl3.Controls.Add(this.btnAddStock);
            this.groupControl3.Controls.Add(this.txtQuantity);
            this.groupControl3.Controls.Add(this.labelControl4);
            this.groupControl3.Location = new System.Drawing.Point(15, 340);
            this.groupControl3.Name = "groupControl3";
            this.groupControl3.Size = new System.Drawing.Size(266, 180);
            this.groupControl3.TabIndex = 6;
            this.groupControl3.Text = "Stok İşlemleri";

            // 
            // labelControl4
            // 
            this.labelControl4.Location = new System.Drawing.Point(15, 35);
            this.labelControl4.Name = "labelControl4";
            this.labelControl4.Size = new System.Drawing.Size(35, 13);
            this.labelControl4.TabIndex = 0;
            this.labelControl4.Text = "Miktar:";

            // 
            // txtQuantity
            // 
            this.txtQuantity.EditValue = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.txtQuantity.Location = new System.Drawing.Point(70, 32);
            this.txtQuantity.Name = "txtQuantity";
            this.txtQuantity.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.txtQuantity.Properties.IsFloatValue = false;
            this.txtQuantity.Properties.Mask.EditMask = "N00";
            this.txtQuantity.Properties.MaxValue = new decimal(new int[] {
            10000,
            0,
            0,
            0});
            this.txtQuantity.Properties.MinValue = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.txtQuantity.Size = new System.Drawing.Size(181, 20);
            this.txtQuantity.TabIndex = 1;

            // 
            // btnAddStock
            // 
            this.btnAddStock.Location = new System.Drawing.Point(15, 70);
            this.btnAddStock.Name = "btnAddStock";
            this.btnAddStock.Size = new System.Drawing.Size(236, 28);
            this.btnAddStock.TabIndex = 2;
            this.btnAddStock.Text = "Stok Ekle (+)";
            this.btnAddStock.Click += new System.EventHandler(this.btnAddStock_Click);

            // 
            // btnRemoveStock
            // 
            this.btnRemoveStock.Location = new System.Drawing.Point(15, 105);
            this.btnRemoveStock.Name = "btnRemoveStock";
            this.btnRemoveStock.Size = new System.Drawing.Size(236, 28);
            this.btnRemoveStock.TabIndex = 3;
            this.btnRemoveStock.Text = "Stok Çıkar (-)";
            this.btnRemoveStock.Click += new System.EventHandler(this.btnRemoveStock_Click);

            // 
            // btnSetStock
            // 
            this.btnSetStock.Location = new System.Drawing.Point(15, 140);
            this.btnSetStock.Name = "btnSetStock";
            this.btnSetStock.Size = new System.Drawing.Size(236, 28);
            this.btnSetStock.TabIndex = 4;
            this.btnSetStock.Text = "Stok Belirle (=)";
            this.btnSetStock.Click += new System.EventHandler(this.btnSetStock_Click);

            // 
            // layoutControlGroup1
            // 
            this.layoutControlGroup1.EnableIndentsWithoutBorders = DevExpress.Utils.DefaultBoolean.True;
            this.layoutControlGroup1.GroupBordersVisible = false;
            this.layoutControlGroup1.Items.AddRange(new DevExpress.XtraLayout.BaseLayoutItem[] {
            this.layoutControlItem1,
            this.layoutControlItem2});
            this.layoutControlGroup1.Name = "layoutControlGroup1";
            this.layoutControlGroup1.Size = new System.Drawing.Size(1200, 700);
            this.layoutControlGroup1.TextVisible = false;

            // 
            // layoutControlItem1
            // 
            this.layoutControlItem1.Control = this.gridControl1;
            this.layoutControlItem1.Location = new System.Drawing.Point(0, 0);
            this.layoutControlItem1.Name = "layoutControlItem1";
            this.layoutControlItem1.Size = new System.Drawing.Size(880, 680);
            this.layoutControlItem1.TextSize = new System.Drawing.Size(0, 0);
            this.layoutControlItem1.TextVisible = false;

            // 
            // layoutControlItem2
            // 
            this.layoutControlItem2.Control = this.panelControl1;
            this.layoutControlItem2.Location = new System.Drawing.Point(880, 0);
            this.layoutControlItem2.Name = "layoutControlItem2";
            this.layoutControlItem2.Size = new System.Drawing.Size(300, 680);
            this.layoutControlItem2.TextSize = new System.Drawing.Size(0, 0);
            this.layoutControlItem2.TextVisible = false;

            // 
            // FrmStockManagement
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1200, 700);
            this.Controls.Add(this.layoutControl1);
            this.Name = "FrmStockManagement";
            this.Text = "Stok Yönetimi";
            ((System.ComponentModel.ISupportInitialize)(this.layoutControl1)).EndInit();
            this.layoutControl1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.gridControl1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridView1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.panelControl1)).EndInit();
            this.panelControl1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.groupControl1)).EndInit();
            this.groupControl1.ResumeLayout(false);
            this.groupControl1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.groupControl2)).EndInit();
            this.groupControl2.ResumeLayout(false);
            this.groupControl2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.groupControl3)).EndInit();
            this.groupControl3.ResumeLayout(false);
            this.groupControl3.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.txtQuantity.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlGroup1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem2)).EndInit();
            this.ResumeLayout(false);
        }

        #endregion

        private DevExpress.XtraLayout.LayoutControl layoutControl1;
        private DevExpress.XtraLayout.LayoutControlGroup layoutControlGroup1;
        private DevExpress.XtraGrid.GridControl gridControl1;
        private DevExpress.XtraGrid.Views.Grid.GridView gridView1;
        private DevExpress.XtraGrid.Columns.GridColumn colId;
        private DevExpress.XtraGrid.Columns.GridColumn colName;
        private DevExpress.XtraGrid.Columns.GridColumn colActiveSubstance;
        private DevExpress.XtraGrid.Columns.GridColumn colCategory;
        private DevExpress.XtraGrid.Columns.GridColumn colStock;
        private DevExpress.XtraGrid.Columns.GridColumn colPrice;
        private DevExpress.XtraEditors.PanelControl panelControl1;
        private DevExpress.XtraEditors.SimpleButton btnInitializeStocks;
        private DevExpress.XtraEditors.SimpleButton btnRefresh;
        private DevExpress.XtraEditors.SimpleButton btnShowLowStock;
        private DevExpress.XtraEditors.SimpleButton btnShowAll;
        private DevExpress.XtraEditors.GroupControl groupControl1;
        private DevExpress.XtraEditors.LabelControl lblOutOfStockCount;
        private DevExpress.XtraEditors.LabelControl labelControl1;
        private DevExpress.XtraEditors.GroupControl groupControl2;
        private DevExpress.XtraEditors.LabelControl lblLowStockCount;
        private DevExpress.XtraEditors.LabelControl labelControl3;
        private DevExpress.XtraEditors.GroupControl groupControl3;
        private DevExpress.XtraEditors.SimpleButton btnSetStock;
        private DevExpress.XtraEditors.SimpleButton btnRemoveStock;
        private DevExpress.XtraEditors.SimpleButton btnAddStock;
        private DevExpress.XtraEditors.SpinEdit txtQuantity;
        private DevExpress.XtraEditors.LabelControl labelControl4;
        private DevExpress.XtraLayout.LayoutControlItem layoutControlItem1;
        private DevExpress.XtraLayout.LayoutControlItem layoutControlItem2;
    }
}

