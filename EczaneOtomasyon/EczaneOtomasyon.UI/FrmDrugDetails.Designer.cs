namespace EczaneOtomasyon.UI
{
    partial class FrmDrugDetails
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
            this.grpDetails = new DevExpress.XtraEditors.GroupControl();
            this.lblPrice = new DevExpress.XtraEditors.LabelControl();
            this.lblCompany = new DevExpress.XtraEditors.LabelControl();
            this.lblCategory = new DevExpress.XtraEditors.LabelControl();
            this.lblDosage = new DevExpress.XtraEditors.LabelControl();
            this.lblForm = new DevExpress.XtraEditors.LabelControl();
            this.lblActiveSubstance = new DevExpress.XtraEditors.LabelControl();
            this.lblName = new DevExpress.XtraEditors.LabelControl();
            this.btnGetAlternatives = new DevExpress.XtraEditors.SimpleButton();
            this.gridControl1 = new DevExpress.XtraGrid.GridControl();
            this.gridView1 = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.colRecName = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colRecActiveSubstance = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colRecForm = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colRecDosage = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colRecPrice = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colRecScore = new DevExpress.XtraGrid.Columns.GridColumn();
            this.repositoryItemProgressBar1 = new DevExpress.XtraEditors.Repository.RepositoryItemProgressBar();
            this.panelTop = new DevExpress.XtraEditors.PanelControl();

            ((System.ComponentModel.ISupportInitialize)(this.grpDetails)).BeginInit();
            this.grpDetails.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.gridControl1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridView1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.repositoryItemProgressBar1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.panelTop)).BeginInit();
            this.panelTop.SuspendLayout();
            this.SuspendLayout();

            // 
            // panelTop
            // 
            this.panelTop.Controls.Add(this.grpDetails);
            this.panelTop.Controls.Add(this.btnGetAlternatives);
            this.panelTop.Dock = System.Windows.Forms.DockStyle.Top;
            this.panelTop.Location = new System.Drawing.Point(0, 0);
            this.panelTop.Name = "panelTop";
            this.panelTop.Size = new System.Drawing.Size(800, 180);
            this.panelTop.TabIndex = 0;

            // 
            // grpDetails
            // 
            this.grpDetails.Controls.Add(this.lblPrice);
            this.grpDetails.Controls.Add(this.lblCompany);
            this.grpDetails.Controls.Add(this.lblCategory);
            this.grpDetails.Controls.Add(this.lblDosage);
            this.grpDetails.Controls.Add(this.lblForm);
            this.grpDetails.Controls.Add(this.lblActiveSubstance);
            this.grpDetails.Controls.Add(this.lblName);
            this.grpDetails.Location = new System.Drawing.Point(12, 12);
            this.grpDetails.Name = "grpDetails";
            this.grpDetails.Size = new System.Drawing.Size(600, 150);
            this.grpDetails.TabIndex = 0;
            this.grpDetails.Text = "Seçili İlaç Bilgileri";

            // 
            // lblName
            // 
            this.lblName.Appearance.Font = new System.Drawing.Font("Tahoma", 14F, System.Drawing.FontStyle.Bold);
            this.lblName.Appearance.Options.UseFont = true;
            this.lblName.Location = new System.Drawing.Point(15, 35);
            this.lblName.Name = "lblName";
            this.lblName.Size = new System.Drawing.Size(107, 23);
            this.lblName.TabIndex = 0;
            this.lblName.Text = "İlaç Adı...";

            // 
            // lblActiveSubstance
            // 
            this.lblActiveSubstance.Location = new System.Drawing.Point(15, 70);
            this.lblActiveSubstance.Name = "lblActiveSubstance";
            this.lblActiveSubstance.Size = new System.Drawing.Size(66, 13);
            this.lblActiveSubstance.TabIndex = 1;
            this.lblActiveSubstance.Text = "Etken Madde:";

            // 
            // lblForm
            // 
            this.lblForm.Location = new System.Drawing.Point(15, 95);
            this.lblForm.Name = "lblForm";
            this.lblForm.Size = new System.Drawing.Size(29, 13);
            this.lblForm.TabIndex = 2;
            this.lblForm.Text = "Form:";

            // 
            // lblDosage
            // 
            this.lblDosage.Location = new System.Drawing.Point(250, 95);
            this.lblDosage.Name = "lblDosage";
            this.lblDosage.Size = new System.Drawing.Size(22, 13);
            this.lblDosage.TabIndex = 3;
            this.lblDosage.Text = "Doz:";

            // 
            // lblCategory
            // 
            this.lblCategory.Location = new System.Drawing.Point(15, 120);
            this.lblCategory.Name = "lblCategory";
            this.lblCategory.Size = new System.Drawing.Size(44, 13);
            this.lblCategory.TabIndex = 4;
            this.lblCategory.Text = "Kategori:";

            // 
            // lblCompany
            // 
            this.lblCompany.Location = new System.Drawing.Point(250, 120);
            this.lblCompany.Name = "lblCompany";
            this.lblCompany.Size = new System.Drawing.Size(30, 13);
            this.lblCompany.TabIndex = 5;
            this.lblCompany.Text = "Firma:";

            // 
            // lblPrice
            // 
            this.lblPrice.Appearance.Font = new System.Drawing.Font("Tahoma", 12F, System.Drawing.FontStyle.Bold);
            this.lblPrice.Appearance.ForeColor = System.Drawing.Color.Green;
            this.lblPrice.Appearance.Options.UseFont = true;
            this.lblPrice.Appearance.Options.UseForeColor = true;
            this.lblPrice.Location = new System.Drawing.Point(450, 35);
            this.lblPrice.Name = "lblPrice";
            this.lblPrice.Size = new System.Drawing.Size(41, 19);
            this.lblPrice.TabIndex = 6;
            this.lblPrice.Text = "0.00 ₺";

            // 
            // btnGetAlternatives
            // 
            this.btnGetAlternatives.Appearance.Font = new System.Drawing.Font("Tahoma", 10F, System.Drawing.FontStyle.Bold);
            this.btnGetAlternatives.Appearance.Options.UseFont = true;
            this.btnGetAlternatives.Location = new System.Drawing.Point(630, 47);
            this.btnGetAlternatives.Name = "btnGetAlternatives";
            this.btnGetAlternatives.Size = new System.Drawing.Size(140, 50);
            this.btnGetAlternatives.TabIndex = 1;
            this.btnGetAlternatives.Text = "Muadil Önerilerini\nGetir";
            this.btnGetAlternatives.Click += new System.EventHandler(this.btnGetAlternatives_Click);

            // 
            // gridControl1
            // 
            this.gridControl1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.gridControl1.Location = new System.Drawing.Point(0, 180);
            this.gridControl1.MainView = this.gridView1;
            this.gridControl1.Name = "gridControl1";
            this.gridControl1.RepositoryItems.AddRange(new DevExpress.XtraEditors.Repository.RepositoryItem[] {
            this.repositoryItemProgressBar1});
            this.gridControl1.Size = new System.Drawing.Size(800, 420);
            this.gridControl1.TabIndex = 1;
            this.gridControl1.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] {
            this.gridView1});

            // 
            // gridView1
            // 
            this.gridView1.Columns.AddRange(new DevExpress.XtraGrid.Columns.GridColumn[] {
            this.colRecName,
            this.colRecActiveSubstance,
            this.colRecForm,
            this.colRecDosage,
            this.colRecPrice,
            this.colRecScore});
            this.gridView1.GridControl = this.gridControl1;
            this.gridView1.Name = "gridView1";
            this.gridView1.OptionsBehavior.Editable = false;
            this.gridView1.OptionsView.ShowGroupPanel = false;
            this.gridView1.ViewCaption = "Önerilen Muadiller";

            // 
            // colRecName
            // 
            this.colRecName.Caption = "İlaç Adı";
            this.colRecName.FieldName = "Drug.Name";
            this.colRecName.Name = "colRecName";
            this.colRecName.Visible = true;
            this.colRecName.VisibleIndex = 0;

            // 
            // colRecActiveSubstance
            // 
            this.colRecActiveSubstance.Caption = "Etken Madde";
            this.colRecActiveSubstance.FieldName = "Drug.ActiveSubstance";
            this.colRecActiveSubstance.Name = "colRecActiveSubstance";
            this.colRecActiveSubstance.Visible = true;
            this.colRecActiveSubstance.VisibleIndex = 1;

            // 
            // colRecForm
            // 
            this.colRecForm.Caption = "Form";
            this.colRecForm.FieldName = "Drug.Form";
            this.colRecForm.Name = "colRecForm";
            this.colRecForm.Visible = true;
            this.colRecForm.VisibleIndex = 2;

            // 
            // colRecDosage
            // 
            this.colRecDosage.Caption = "Doz (mg)";
            this.colRecDosage.FieldName = "Drug.DosageMg";
            this.colRecDosage.Name = "colRecDosage";
            this.colRecDosage.Visible = true;
            this.colRecDosage.VisibleIndex = 3;

            // 
            // colRecPrice
            // 
            this.colRecPrice.Caption = "Fiyat";
            this.colRecPrice.DisplayFormat.FormatString = "c2";
            this.colRecPrice.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric;
            this.colRecPrice.FieldName = "Drug.Price";
            this.colRecPrice.Name = "colRecPrice";
            this.colRecPrice.Visible = true;
            this.colRecPrice.VisibleIndex = 4;

            // 
            // colRecScore
            // 
            this.colRecScore.Caption = "Benzerlik Skoru";
            this.colRecScore.ColumnEdit = this.repositoryItemProgressBar1;
            this.colRecScore.FieldName = "SimilarityScore";
            this.colRecScore.Name = "colRecScore";
            this.colRecScore.Visible = true;
            this.colRecScore.VisibleIndex = 5;

            // 
            // repositoryItemProgressBar1
            // 
            this.repositoryItemProgressBar1.Maximum = 100;
            this.repositoryItemProgressBar1.Name = "repositoryItemProgressBar1";
            this.repositoryItemProgressBar1.ShowTitle = true;

            // 
            // FrmDrugDetails
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 600);
            this.Controls.Add(this.gridControl1);
            this.Controls.Add(this.panelTop);
            this.Name = "FrmDrugDetails";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "İlaç Detayı ve Muadil Önerileri";
            ((System.ComponentModel.ISupportInitialize)(this.grpDetails)).EndInit();
            this.grpDetails.ResumeLayout(false);
            this.grpDetails.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.gridControl1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridView1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.repositoryItemProgressBar1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.panelTop)).EndInit();
            this.panelTop.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private DevExpress.XtraEditors.PanelControl panelTop;
        private DevExpress.XtraEditors.GroupControl grpDetails;
        private DevExpress.XtraEditors.LabelControl lblName;
        private DevExpress.XtraEditors.LabelControl lblActiveSubstance;
        private DevExpress.XtraEditors.LabelControl lblForm;
        private DevExpress.XtraEditors.LabelControl lblDosage;
        private DevExpress.XtraEditors.LabelControl lblCategory;
        private DevExpress.XtraEditors.LabelControl lblCompany;
        private DevExpress.XtraEditors.LabelControl lblPrice;
        private DevExpress.XtraEditors.SimpleButton btnGetAlternatives;
        private DevExpress.XtraGrid.GridControl gridControl1;
        private DevExpress.XtraGrid.Views.Grid.GridView gridView1;
        private DevExpress.XtraGrid.Columns.GridColumn colRecName;
        private DevExpress.XtraGrid.Columns.GridColumn colRecActiveSubstance;
        private DevExpress.XtraGrid.Columns.GridColumn colRecForm;
        private DevExpress.XtraGrid.Columns.GridColumn colRecDosage;
        private DevExpress.XtraGrid.Columns.GridColumn colRecPrice;
        private DevExpress.XtraGrid.Columns.GridColumn colRecScore;
        private DevExpress.XtraEditors.Repository.RepositoryItemProgressBar repositoryItemProgressBar1;
    }
}

