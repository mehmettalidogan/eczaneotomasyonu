namespace EczaneOtomasyon.UI
{
    partial class FrmPrescriptionEdit
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
            this.txtPrescriptionNumber = new DevExpress.XtraEditors.TextEdit();
            this.txtPatientName = new DevExpress.XtraEditors.TextEdit();
            this.txtPatientSurname = new DevExpress.XtraEditors.TextEdit();
            this.txtPatientTC = new DevExpress.XtraEditors.TextEdit();
            this.txtAge = new DevExpress.XtraEditors.SpinEdit();
            this.dateEdit1 = new DevExpress.XtraEditors.DateEdit();
            this.gridControl1 = new DevExpress.XtraGrid.GridControl();
            this.gridView1 = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.repositoryItemLookUpEdit1 = new DevExpress.XtraEditors.Repository.RepositoryItemLookUpEdit();
            this.btnSave = new DevExpress.XtraEditors.SimpleButton();
            this.lblPrescriptionNumber = new DevExpress.XtraEditors.LabelControl();
            this.lblName = new DevExpress.XtraEditors.LabelControl();
            this.lblSurname = new DevExpress.XtraEditors.LabelControl();
            this.lblTC = new DevExpress.XtraEditors.LabelControl();
            this.lblAge = new DevExpress.XtraEditors.LabelControl();
            this.lblDate = new DevExpress.XtraEditors.LabelControl();
            this.panelTop = new DevExpress.XtraEditors.PanelControl();
            this.panelBottom = new DevExpress.XtraEditors.PanelControl();

            ((System.ComponentModel.ISupportInitialize)(this.txtPrescriptionNumber.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtPatientName.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtPatientSurname.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtPatientTC.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtAge.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dateEdit1.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dateEdit1.Properties.CalendarTimeProperties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridControl1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridView1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.repositoryItemLookUpEdit1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.panelTop)).BeginInit();
            this.panelTop.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.panelBottom)).BeginInit();
            this.panelBottom.SuspendLayout();
            this.SuspendLayout();

            // panelTop
            this.panelTop.Controls.Add(this.lblDate);
            this.panelTop.Controls.Add(this.dateEdit1);
            this.panelTop.Controls.Add(this.lblAge);
            this.panelTop.Controls.Add(this.txtAge);
            this.panelTop.Controls.Add(this.lblTC);
            this.panelTop.Controls.Add(this.txtPatientTC);
            this.panelTop.Controls.Add(this.lblSurname);
            this.panelTop.Controls.Add(this.txtPatientSurname);
            this.panelTop.Controls.Add(this.lblName);
            this.panelTop.Controls.Add(this.txtPatientName);
            this.panelTop.Controls.Add(this.lblPrescriptionNumber);
            this.panelTop.Controls.Add(this.txtPrescriptionNumber);
            this.panelTop.Dock = System.Windows.Forms.DockStyle.Top;
            this.panelTop.Location = new System.Drawing.Point(0, 0);
            this.panelTop.Name = "panelTop";
            this.panelTop.Size = new System.Drawing.Size(784, 100);
            this.panelTop.TabIndex = 0;

            // lblPrescriptionNumber
            this.lblPrescriptionNumber.Location = new System.Drawing.Point(12, 13);
            this.lblPrescriptionNumber.Name = "lblPrescriptionNumber";
            this.lblPrescriptionNumber.Size = new System.Drawing.Size(60, 13);
            this.lblPrescriptionNumber.TabIndex = 0;
            this.lblPrescriptionNumber.Text = "Reçete No:";

            // txtPrescriptionNumber
            this.txtPrescriptionNumber.Location = new System.Drawing.Point(90, 10);
            this.txtPrescriptionNumber.Name = "txtPrescriptionNumber";
            this.txtPrescriptionNumber.Size = new System.Drawing.Size(150, 20);
            this.txtPrescriptionNumber.TabIndex = 1;

            // lblName
            this.lblName.Location = new System.Drawing.Point(280, 13);
            this.lblName.Name = "lblName";
            this.lblName.Size = new System.Drawing.Size(50, 13);
            this.lblName.TabIndex = 2;
            this.lblName.Text = "Hasta Adı:";

            // txtPatientName
            this.txtPatientName.Location = new System.Drawing.Point(340, 10);
            this.txtPatientName.Name = "txtPatientName";
            this.txtPatientName.Size = new System.Drawing.Size(150, 20);
            this.txtPatientName.TabIndex = 3;

            // lblSurname
            this.lblSurname.Location = new System.Drawing.Point(510, 13);
            this.lblSurname.Name = "lblSurname";
            this.lblSurname.Size = new System.Drawing.Size(37, 13);
            this.lblSurname.TabIndex = 4;
            this.lblSurname.Text = "Soyad:";

            // txtPatientSurname
            this.txtPatientSurname.Location = new System.Drawing.Point(560, 10);
            this.txtPatientSurname.Name = "txtPatientSurname";
            this.txtPatientSurname.Size = new System.Drawing.Size(150, 20);
            this.txtPatientSurname.TabIndex = 5;

            // lblTC
            this.lblTC.Location = new System.Drawing.Point(12, 48);
            this.lblTC.Name = "lblTC";
            this.lblTC.Size = new System.Drawing.Size(62, 13);
            this.lblTC.TabIndex = 6;
            this.lblTC.Text = "TC Kimlik No:";

            // txtPatientTC
            this.txtPatientTC.Location = new System.Drawing.Point(90, 45);
            this.txtPatientTC.Name = "txtPatientTC";
            this.txtPatientTC.Properties.MaxLength = 11;
            this.txtPatientTC.Size = new System.Drawing.Size(150, 20);
            this.txtPatientTC.TabIndex = 7;

            // lblAge
            // 
            this.lblAge.Location = new System.Drawing.Point(280, 48);
            this.lblAge.Name = "lblAge";
            this.lblAge.Size = new System.Drawing.Size(22, 13);
            this.lblAge.TabIndex = 8;
            this.lblAge.Text = "Yaş:";

            // txtAge
            // 
            this.txtAge.EditValue = new decimal(new int[] { 0, 0, 0, 0 });
            this.txtAge.Location = new System.Drawing.Point(340, 45);
            this.txtAge.Name = "txtAge";
            this.txtAge.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.txtAge.Properties.MaxValue = new decimal(new int[] { 120, 0, 0, 0 });
            this.txtAge.Size = new System.Drawing.Size(60, 20);
            this.txtAge.TabIndex = 9;

            // lblDate
            this.lblDate.Location = new System.Drawing.Point(430, 48);
            this.lblDate.Name = "lblDate";
            this.lblDate.Size = new System.Drawing.Size(28, 13);
            this.lblDate.TabIndex = 10;
            this.lblDate.Text = "Tarih:";

            // dateEdit1
            // 
            this.dateEdit1.EditValue = null;
            this.dateEdit1.Location = new System.Drawing.Point(470, 45);
            this.dateEdit1.Name = "dateEdit1";
            this.dateEdit1.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.dateEdit1.Properties.CalendarTimeProperties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.dateEdit1.Size = new System.Drawing.Size(120, 20);
            this.dateEdit1.TabIndex = 11;

            // panelBottom
            this.panelBottom.Controls.Add(this.btnSave);
            this.panelBottom.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.panelBottom.Location = new System.Drawing.Point(0, 451);
            this.panelBottom.Name = "panelBottom";
            this.panelBottom.Size = new System.Drawing.Size(784, 50);
            this.panelBottom.TabIndex = 2;

            // btnSave
            // 
            this.btnSave.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnSave.Location = new System.Drawing.Point(622, 10);
            this.btnSave.Name = "btnSave";
            this.btnSave.Size = new System.Drawing.Size(150, 30);
            this.btnSave.TabIndex = 0;
            this.btnSave.Text = "Kaydet ve Kontrol Et";
            this.btnSave.Click += new System.EventHandler(this.btnSave_Click);

            // gridControl1
            // 
            this.gridControl1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.gridControl1.Location = new System.Drawing.Point(0, 100);
            this.gridControl1.MainView = this.gridView1;
            this.gridControl1.Name = "gridControl1";
            this.gridControl1.RepositoryItems.AddRange(new DevExpress.XtraEditors.Repository.RepositoryItem[] {
            this.repositoryItemLookUpEdit1});
            this.gridControl1.Size = new System.Drawing.Size(784, 351);
            this.gridControl1.TabIndex = 1;
            this.gridControl1.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] {
            this.gridView1});

            // gridView1
            // 
            this.gridView1.GridControl = this.gridControl1;
            this.gridView1.Name = "gridView1";
            this.gridView1.OptionsView.NewItemRowPosition = DevExpress.XtraGrid.Views.Grid.NewItemRowPosition.Top;
            this.gridView1.OptionsView.ShowGroupPanel = false;
            this.gridView1.CellValueChanged += new DevExpress.XtraGrid.Views.Base.CellValueChangedEventHandler(this.gridView1_CellValueChanged);

            // repositoryItemLookUpEdit1
            // 
            this.repositoryItemLookUpEdit1.AutoHeight = false;
            this.repositoryItemLookUpEdit1.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.repositoryItemLookUpEdit1.Name = "repositoryItemLookUpEdit1";
            this.repositoryItemLookUpEdit1.NullText = "Seçiniz...";

            // FrmPrescriptionEdit
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(784, 501);
            this.Controls.Add(this.gridControl1);
            this.Controls.Add(this.panelBottom);
            this.Controls.Add(this.panelTop);
            this.Name = "FrmPrescriptionEdit";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Yeni Reçete Girişi";
            ((System.ComponentModel.ISupportInitialize)(this.txtPrescriptionNumber.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtPatientName.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtPatientSurname.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtPatientTC.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtAge.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dateEdit1.Properties.CalendarTimeProperties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dateEdit1.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridControl1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridView1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.repositoryItemLookUpEdit1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.panelTop)).EndInit();
            this.panelTop.ResumeLayout(false);
            this.panelTop.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.panelBottom)).EndInit();
            this.panelBottom.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private DevExpress.XtraEditors.PanelControl panelTop;
        private DevExpress.XtraEditors.PanelControl panelBottom;
        private DevExpress.XtraEditors.TextEdit txtPrescriptionNumber;
        private DevExpress.XtraEditors.TextEdit txtPatientName;
        private DevExpress.XtraEditors.TextEdit txtPatientSurname;
        private DevExpress.XtraEditors.TextEdit txtPatientTC;
        private DevExpress.XtraEditors.SpinEdit txtAge;
        private DevExpress.XtraEditors.DateEdit dateEdit1;
        private DevExpress.XtraGrid.GridControl gridControl1;
        private DevExpress.XtraGrid.Views.Grid.GridView gridView1;
        private DevExpress.XtraEditors.Repository.RepositoryItemLookUpEdit repositoryItemLookUpEdit1;
        private DevExpress.XtraEditors.SimpleButton btnSave;
        private DevExpress.XtraEditors.LabelControl lblPrescriptionNumber;
        private DevExpress.XtraEditors.LabelControl lblName;
        private DevExpress.XtraEditors.LabelControl lblSurname;
        private DevExpress.XtraEditors.LabelControl lblTC;
        private DevExpress.XtraEditors.LabelControl lblAge;
        private DevExpress.XtraEditors.LabelControl lblDate;
    }
}






