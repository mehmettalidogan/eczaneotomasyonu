namespace EczaneOtomasyon.UI
{
    partial class FrmPrescriptionDetails
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
            this.panelTop = new DevExpress.XtraEditors.PanelControl();
            this.grpPatientInfo = new DevExpress.XtraEditors.GroupControl();
            this.lblPrescriptionNumberValue = new DevExpress.XtraEditors.LabelControl();
            this.lblPrescriptionNumber = new DevExpress.XtraEditors.LabelControl();
            this.lblDateValue = new DevExpress.XtraEditors.LabelControl();
            this.lblDate = new DevExpress.XtraEditors.LabelControl();
            this.lblAgeValue = new DevExpress.XtraEditors.LabelControl();
            this.lblAge = new DevExpress.XtraEditors.LabelControl();
            this.lblTCValue = new DevExpress.XtraEditors.LabelControl();
            this.lblTC = new DevExpress.XtraEditors.LabelControl();
            this.lblPatientNameValue = new DevExpress.XtraEditors.LabelControl();
            this.lblPatientName = new DevExpress.XtraEditors.LabelControl();
            this.grpDrugs = new DevExpress.XtraEditors.GroupControl();
            this.gridControl1 = new DevExpress.XtraGrid.GridControl();
            this.gridView1 = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.colDrugName = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colDailyDose = new DevExpress.XtraGrid.Columns.GridColumn();
            this.panelBottom = new DevExpress.XtraEditors.PanelControl();
            this.btnClose = new DevExpress.XtraEditors.SimpleButton();

            ((System.ComponentModel.ISupportInitialize)(this.panelTop)).BeginInit();
            this.panelTop.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.grpPatientInfo)).BeginInit();
            this.grpPatientInfo.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.grpDrugs)).BeginInit();
            this.grpDrugs.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.gridControl1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridView1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.panelBottom)).BeginInit();
            this.panelBottom.SuspendLayout();
            this.SuspendLayout();

            // 
            // panelTop
            // 
            this.panelTop.Controls.Add(this.grpPatientInfo);
            this.panelTop.Dock = System.Windows.Forms.DockStyle.Top;
            this.panelTop.Location = new System.Drawing.Point(0, 0);
            this.panelTop.Name = "panelTop";
            this.panelTop.Size = new System.Drawing.Size(700, 180);
            this.panelTop.TabIndex = 0;

            // 
            // grpPatientInfo
            // 
            this.grpPatientInfo.Controls.Add(this.lblPrescriptionNumberValue);
            this.grpPatientInfo.Controls.Add(this.lblPrescriptionNumber);
            this.grpPatientInfo.Controls.Add(this.lblDateValue);
            this.grpPatientInfo.Controls.Add(this.lblDate);
            this.grpPatientInfo.Controls.Add(this.lblAgeValue);
            this.grpPatientInfo.Controls.Add(this.lblAge);
            this.grpPatientInfo.Controls.Add(this.lblTCValue);
            this.grpPatientInfo.Controls.Add(this.lblTC);
            this.grpPatientInfo.Controls.Add(this.lblPatientNameValue);
            this.grpPatientInfo.Controls.Add(this.lblPatientName);
            this.grpPatientInfo.Dock = System.Windows.Forms.DockStyle.Fill;
            this.grpPatientInfo.Location = new System.Drawing.Point(2, 2);
            this.grpPatientInfo.Name = "grpPatientInfo";
            this.grpPatientInfo.Size = new System.Drawing.Size(696, 176);
            this.grpPatientInfo.TabIndex = 0;
            this.grpPatientInfo.Text = "Reçete Bilgileri";

            // 
            // lblPrescriptionNumber
            // 
            this.lblPrescriptionNumber.Appearance.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Bold);
            this.lblPrescriptionNumber.Appearance.Options.UseFont = true;
            this.lblPrescriptionNumber.Location = new System.Drawing.Point(20, 35);
            this.lblPrescriptionNumber.Name = "lblPrescriptionNumber";
            this.lblPrescriptionNumber.Size = new System.Drawing.Size(70, 14);
            this.lblPrescriptionNumber.TabIndex = 0;
            this.lblPrescriptionNumber.Text = "Reçete No:";

            // 
            // lblPrescriptionNumberValue
            // 
            this.lblPrescriptionNumberValue.Location = new System.Drawing.Point(150, 35);
            this.lblPrescriptionNumberValue.Name = "lblPrescriptionNumberValue";
            this.lblPrescriptionNumberValue.Size = new System.Drawing.Size(10, 13);
            this.lblPrescriptionNumberValue.TabIndex = 1;
            this.lblPrescriptionNumberValue.Text = "-";

            // 
            // lblPatientName
            // 
            this.lblPatientName.Appearance.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Bold);
            this.lblPatientName.Appearance.Options.UseFont = true;
            this.lblPatientName.Location = new System.Drawing.Point(20, 65);
            this.lblPatientName.Name = "lblPatientName";
            this.lblPatientName.Size = new System.Drawing.Size(95, 14);
            this.lblPatientName.TabIndex = 2;
            this.lblPatientName.Text = "Hasta Adı Soyad:";

            // 
            // lblPatientNameValue
            // 
            this.lblPatientNameValue.Location = new System.Drawing.Point(150, 65);
            this.lblPatientNameValue.Name = "lblPatientNameValue";
            this.lblPatientNameValue.Size = new System.Drawing.Size(10, 13);
            this.lblPatientNameValue.TabIndex = 3;
            this.lblPatientNameValue.Text = "-";

            // 
            // lblTC
            // 
            this.lblTC.Appearance.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Bold);
            this.lblTC.Appearance.Options.UseFont = true;
            this.lblTC.Location = new System.Drawing.Point(20, 95);
            this.lblTC.Name = "lblTC";
            this.lblTC.Size = new System.Drawing.Size(70, 14);
            this.lblTC.TabIndex = 4;
            this.lblTC.Text = "TC Kimlik No:";

            // 
            // lblTCValue
            // 
            this.lblTCValue.Location = new System.Drawing.Point(150, 95);
            this.lblTCValue.Name = "lblTCValue";
            this.lblTCValue.Size = new System.Drawing.Size(10, 13);
            this.lblTCValue.TabIndex = 5;
            this.lblTCValue.Text = "-";

            // 
            // lblAge
            // 
            this.lblAge.Appearance.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Bold);
            this.lblAge.Appearance.Options.UseFont = true;
            this.lblAge.Location = new System.Drawing.Point(20, 125);
            this.lblAge.Name = "lblAge";
            this.lblAge.Size = new System.Drawing.Size(25, 14);
            this.lblAge.TabIndex = 6;
            this.lblAge.Text = "Yaş:";

            // 
            // lblAgeValue
            // 
            this.lblAgeValue.Location = new System.Drawing.Point(150, 125);
            this.lblAgeValue.Name = "lblAgeValue";
            this.lblAgeValue.Size = new System.Drawing.Size(10, 13);
            this.lblAgeValue.TabIndex = 7;
            this.lblAgeValue.Text = "-";

            // 
            // lblDate
            // 
            this.lblDate.Appearance.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Bold);
            this.lblDate.Appearance.Options.UseFont = true;
            this.lblDate.Location = new System.Drawing.Point(400, 35);
            this.lblDate.Name = "lblDate";
            this.lblDate.Size = new System.Drawing.Size(35, 14);
            this.lblDate.TabIndex = 8;
            this.lblDate.Text = "Tarih:";

            // 
            // lblDateValue
            // 
            this.lblDateValue.Location = new System.Drawing.Point(480, 35);
            this.lblDateValue.Name = "lblDateValue";
            this.lblDateValue.Size = new System.Drawing.Size(10, 13);
            this.lblDateValue.TabIndex = 9;
            this.lblDateValue.Text = "-";

            // 
            // grpDrugs
            // 
            this.grpDrugs.Controls.Add(this.gridControl1);
            this.grpDrugs.Dock = System.Windows.Forms.DockStyle.Fill;
            this.grpDrugs.Location = new System.Drawing.Point(0, 180);
            this.grpDrugs.Name = "grpDrugs";
            this.grpDrugs.Size = new System.Drawing.Size(700, 270);
            this.grpDrugs.TabIndex = 1;
            this.grpDrugs.Text = "Reçetedeki İlaçlar";

            // 
            // gridControl1
            // 
            this.gridControl1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.gridControl1.Location = new System.Drawing.Point(2, 23);
            this.gridControl1.MainView = this.gridView1;
            this.gridControl1.Name = "gridControl1";
            this.gridControl1.Size = new System.Drawing.Size(696, 245);
            this.gridControl1.TabIndex = 0;
            this.gridControl1.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] {
            this.gridView1});

            // 
            // gridView1
            // 
            this.gridView1.Columns.AddRange(new DevExpress.XtraGrid.Columns.GridColumn[] {
            this.colDrugName,
            this.colDailyDose});
            this.gridView1.GridControl = this.gridControl1;
            this.gridView1.Name = "gridView1";
            this.gridView1.OptionsBehavior.Editable = false;
            this.gridView1.OptionsView.EnableAppearanceEvenRow = true;
            this.gridView1.OptionsView.ShowGroupPanel = false;

            // 
            // colDrugName
            // 
            this.colDrugName.Caption = "İlaç Adı";
            this.colDrugName.FieldName = "DrugName";
            this.colDrugName.Name = "colDrugName";
            this.colDrugName.Visible = true;
            this.colDrugName.VisibleIndex = 0;
            this.colDrugName.Width = 400;

            // 
            // colDailyDose
            // 
            this.colDailyDose.Caption = "Günlük Doz (mg)";
            this.colDailyDose.FieldName = "DailyDoseMg";
            this.colDailyDose.Name = "colDailyDose";
            this.colDailyDose.Visible = true;
            this.colDailyDose.VisibleIndex = 1;
            this.colDailyDose.Width = 150;

            // 
            // panelBottom
            // 
            this.panelBottom.Controls.Add(this.btnClose);
            this.panelBottom.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.panelBottom.Location = new System.Drawing.Point(0, 450);
            this.panelBottom.Name = "panelBottom";
            this.panelBottom.Size = new System.Drawing.Size(700, 50);
            this.panelBottom.TabIndex = 2;

            // 
            // btnClose
            // 
            this.btnClose.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnClose.Location = new System.Drawing.Point(570, 10);
            this.btnClose.Name = "btnClose";
            this.btnClose.Size = new System.Drawing.Size(120, 30);
            this.btnClose.TabIndex = 0;
            this.btnClose.Text = "Kapat";
            this.btnClose.Click += new System.EventHandler(this.btnClose_Click);

            // 
            // FrmPrescriptionDetails
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(700, 500);
            this.Controls.Add(this.grpDrugs);
            this.Controls.Add(this.panelBottom);
            this.Controls.Add(this.panelTop);
            this.Name = "FrmPrescriptionDetails";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Reçete Detayları";
            ((System.ComponentModel.ISupportInitialize)(this.panelTop)).EndInit();
            this.panelTop.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.grpPatientInfo)).EndInit();
            this.grpPatientInfo.ResumeLayout(false);
            this.grpPatientInfo.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.grpDrugs)).EndInit();
            this.grpDrugs.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.gridControl1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridView1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.panelBottom)).EndInit();
            this.panelBottom.ResumeLayout(false);
            this.ResumeLayout(false);
        }

        #endregion

        private DevExpress.XtraEditors.PanelControl panelTop;
        private DevExpress.XtraEditors.PanelControl panelBottom;
        private DevExpress.XtraEditors.GroupControl grpPatientInfo;
        private DevExpress.XtraEditors.GroupControl grpDrugs;
        private DevExpress.XtraEditors.LabelControl lblPrescriptionNumber;
        private DevExpress.XtraEditors.LabelControl lblPrescriptionNumberValue;
        private DevExpress.XtraEditors.LabelControl lblPatientName;
        private DevExpress.XtraEditors.LabelControl lblPatientNameValue;
        private DevExpress.XtraEditors.LabelControl lblTC;
        private DevExpress.XtraEditors.LabelControl lblTCValue;
        private DevExpress.XtraEditors.LabelControl lblAge;
        private DevExpress.XtraEditors.LabelControl lblAgeValue;
        private DevExpress.XtraEditors.LabelControl lblDate;
        private DevExpress.XtraEditors.LabelControl lblDateValue;
        private DevExpress.XtraGrid.GridControl gridControl1;
        private DevExpress.XtraGrid.Views.Grid.GridView gridView1;
        private DevExpress.XtraGrid.Columns.GridColumn colDrugName;
        private DevExpress.XtraGrid.Columns.GridColumn colDailyDose;
        private DevExpress.XtraEditors.SimpleButton btnClose;
    }
}

