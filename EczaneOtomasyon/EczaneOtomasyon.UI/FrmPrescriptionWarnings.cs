using System;
using System.Collections.Generic;
using System.Windows.Forms;
using DevExpress.XtraEditors;
using EczaneOtomasyon.Business;

namespace EczaneOtomasyon.UI
{
    public partial class FrmPrescriptionWarnings : DevExpress.XtraEditors.XtraForm
    {
        public bool CanContinue { get; private set; } = false;
        public List<InteractionWarning>? Warnings { get; set; }

        public FrmPrescriptionWarnings()
        {
            InitializeComponent();
        }

        protected override void OnLoad(EventArgs e)
        {
            base.OnLoad(e);
            if (Warnings != null)
            {
                gridControl1.DataSource = Warnings;
            }
        }

        private void btnBack_Click(object sender, EventArgs e)
        {
            CanContinue = false;
            this.Close();
        }

        private void btnContinue_Click(object sender, EventArgs e)
        {
            CanContinue = true;
            this.Close();
        }
    }
}
