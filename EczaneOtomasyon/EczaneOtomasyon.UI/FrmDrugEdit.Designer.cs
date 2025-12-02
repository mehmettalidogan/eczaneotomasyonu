namespace EczaneOtomasyon.UI
{
    partial class FrmDrugEdit
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.lblName = new DevExpress.XtraEditors.LabelControl();
            this.txtName = new DevExpress.XtraEditors.TextEdit();
            this.lblActiveSubstance = new DevExpress.XtraEditors.LabelControl();
            this.txtActiveSubstance = new DevExpress.XtraEditors.TextEdit();
            this.lblForm = new DevExpress.XtraEditors.LabelControl();
            this.txtForm = new DevExpress.XtraEditors.TextEdit();
            this.lblDosage = new DevExpress.XtraEditors.LabelControl();
            this.txtDosage = new DevExpress.XtraEditors.SpinEdit();
            this.lblCompany = new DevExpress.XtraEditors.LabelControl();
            this.txtCompany = new DevExpress.XtraEditors.TextEdit();
            this.lblCategory = new DevExpress.XtraEditors.LabelControl();
            this.txtCategory = new DevExpress.XtraEditors.TextEdit();
            this.lblPrice = new DevExpress.XtraEditors.LabelControl();
            this.txtPrice = new DevExpress.XtraEditors.SpinEdit();
            this.btnSave = new DevExpress.XtraEditors.SimpleButton();
            this.btnCancel = new DevExpress.XtraEditors.SimpleButton();
            ((System.ComponentModel.ISupportInitialize)(this.txtName.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtActiveSubstance.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtForm.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtDosage.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtCompany.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtCategory.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtPrice.Properties)).BeginInit();
            this.SuspendLayout();
            
            // 
            // lblName
            // 
            this.lblName.Location = new System.Drawing.Point(20, 20);
            this.lblName.Name = "lblName";
            this.lblName.Size = new System.Drawing.Size(17, 13);
            this.lblName.TabIndex = 0;
            this.lblName.Text = "Ad:";
            
            // 
            // txtName
            // 
            this.txtName.Location = new System.Drawing.Point(120, 17);
            this.txtName.Name = "txtName";
            this.txtName.Size = new System.Drawing.Size(200, 20);
            this.txtName.TabIndex = 1;

            // 
            // lblActiveSubstance
            // 
            this.lblActiveSubstance.Location = new System.Drawing.Point(20, 50);
            this.lblActiveSubstance.Name = "lblActiveSubstance";
            this.lblActiveSubstance.Size = new System.Drawing.Size(66, 13);
            this.lblActiveSubstance.TabIndex = 2;
            this.lblActiveSubstance.Text = "Etken Madde:";

            // 
            // txtActiveSubstance
            // 
            this.txtActiveSubstance.Location = new System.Drawing.Point(120, 47);
            this.txtActiveSubstance.Name = "txtActiveSubstance";
            this.txtActiveSubstance.Size = new System.Drawing.Size(200, 20);
            this.txtActiveSubstance.TabIndex = 3;

            // 
            // lblForm
            // 
            this.lblForm.Location = new System.Drawing.Point(20, 80);
            this.lblForm.Name = "lblForm";
            this.lblForm.Size = new System.Drawing.Size(29, 13);
            this.lblForm.TabIndex = 4;
            this.lblForm.Text = "Form:";

            // 
            // txtForm
            // 
            this.txtForm.Location = new System.Drawing.Point(120, 77);
            this.txtForm.Name = "txtForm";
            this.txtForm.Size = new System.Drawing.Size(200, 20);
            this.txtForm.TabIndex = 5;

            // 
            // lblDosage
            // 
            this.lblDosage.Location = new System.Drawing.Point(20, 110);
            this.lblDosage.Name = "lblDosage";
            this.lblDosage.Size = new System.Drawing.Size(47, 13);
            this.lblDosage.TabIndex = 6;
            this.lblDosage.Text = "Doz (mg):";

            // 
            // txtDosage
            // 
            this.txtDosage.EditValue = new decimal(new int[] { 0, 0, 0, 0 });
            this.txtDosage.Location = new System.Drawing.Point(120, 107);
            this.txtDosage.Name = "txtDosage";
            this.txtDosage.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.txtDosage.Size = new System.Drawing.Size(100, 20);
            this.txtDosage.TabIndex = 7;

            // 
            // lblCompany
            // 
            this.lblCompany.Location = new System.Drawing.Point(20, 140);
            this.lblCompany.Name = "lblCompany";
            this.lblCompany.Size = new System.Drawing.Size(30, 13);
            this.lblCompany.TabIndex = 8;
            this.lblCompany.Text = "Firma:";

            // 
            // txtCompany
            // 
            this.txtCompany.Location = new System.Drawing.Point(120, 137);
            this.txtCompany.Name = "txtCompany";
            this.txtCompany.Size = new System.Drawing.Size(200, 20);
            this.txtCompany.TabIndex = 9;

            // 
            // lblCategory
            // 
            this.lblCategory.Location = new System.Drawing.Point(20, 170);
            this.lblCategory.Name = "lblCategory";
            this.lblCategory.Size = new System.Drawing.Size(44, 13);
            this.lblCategory.TabIndex = 10;
            this.lblCategory.Text = "Kategori:";

            // 
            // txtCategory
            // 
            this.txtCategory.Location = new System.Drawing.Point(120, 167);
            this.txtCategory.Name = "txtCategory";
            this.txtCategory.Size = new System.Drawing.Size(200, 20);
            this.txtCategory.TabIndex = 11;

            // 
            // lblPrice
            // 
            this.lblPrice.Location = new System.Drawing.Point(20, 200);
            this.lblPrice.Name = "lblPrice";
            this.lblPrice.Size = new System.Drawing.Size(28, 13);
            this.lblPrice.TabIndex = 12;
            this.lblPrice.Text = "Fiyat:";

            // 
            // txtPrice
            // 
            this.txtPrice.EditValue = new decimal(new int[] { 0, 0, 0, 0 });
            this.txtPrice.Location = new System.Drawing.Point(120, 197);
            this.txtPrice.Name = "txtPrice";
            this.txtPrice.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.txtPrice.Size = new System.Drawing.Size(100, 20);
            this.txtPrice.TabIndex = 13;

            // 
            // btnSave
            // 
            this.btnSave.Location = new System.Drawing.Point(120, 240);
            this.btnSave.Name = "btnSave";
            this.btnSave.Size = new System.Drawing.Size(75, 23);
            this.btnSave.TabIndex = 14;
            this.btnSave.Text = "Kaydet";
            this.btnSave.Click += new System.EventHandler(this.btnSave_Click);

            // 
            // btnCancel
            // 
            this.btnCancel.Location = new System.Drawing.Point(201, 240);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Size = new System.Drawing.Size(75, 23);
            this.btnCancel.TabIndex = 15;
            this.btnCancel.Text = "İptal";
            this.btnCancel.Click += new System.EventHandler(this.btnCancel_Click);

            // 
            // FrmDrugEdit
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(350, 300);
            this.Controls.Add(this.btnCancel);
            this.Controls.Add(this.btnSave);
            this.Controls.Add(this.txtPrice);
            this.Controls.Add(this.lblPrice);
            this.Controls.Add(this.txtCategory);
            this.Controls.Add(this.lblCategory);
            this.Controls.Add(this.txtCompany);
            this.Controls.Add(this.lblCompany);
            this.Controls.Add(this.txtDosage);
            this.Controls.Add(this.lblDosage);
            this.Controls.Add(this.txtForm);
            this.Controls.Add(this.lblForm);
            this.Controls.Add(this.txtActiveSubstance);
            this.Controls.Add(this.lblActiveSubstance);
            this.Controls.Add(this.txtName);
            this.Controls.Add(this.lblName);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "FrmDrugEdit";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "İlaç Düzenle";
            ((System.ComponentModel.ISupportInitialize)(this.txtName.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtActiveSubstance.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtForm.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtDosage.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtCompany.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtCategory.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtPrice.Properties)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private DevExpress.XtraEditors.LabelControl lblName;
        private DevExpress.XtraEditors.TextEdit txtName;
        private DevExpress.XtraEditors.LabelControl lblActiveSubstance;
        private DevExpress.XtraEditors.TextEdit txtActiveSubstance;
        private DevExpress.XtraEditors.LabelControl lblForm;
        private DevExpress.XtraEditors.TextEdit txtForm;
        private DevExpress.XtraEditors.LabelControl lblDosage;
        private DevExpress.XtraEditors.SpinEdit txtDosage;
        private DevExpress.XtraEditors.LabelControl lblCompany;
        private DevExpress.XtraEditors.TextEdit txtCompany;
        private DevExpress.XtraEditors.LabelControl lblCategory;
        private DevExpress.XtraEditors.TextEdit txtCategory;
        private DevExpress.XtraEditors.LabelControl lblPrice;
        private DevExpress.XtraEditors.SpinEdit txtPrice;
        private DevExpress.XtraEditors.SimpleButton btnSave;
        private DevExpress.XtraEditors.SimpleButton btnCancel;
    }
}

