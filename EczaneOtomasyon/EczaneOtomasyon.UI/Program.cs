namespace EczaneOtomasyon.UI;

static class Program
{
    /// <summary>
    ///  The main entry point for the application.
    /// </summary>
    [STAThread]
    static void Main()
    {
        // Performans iyileştirmeleri
        Application.SetHighDpiMode(HighDpiMode.SystemAware);
        
        // To customize application configuration such as set high DPI settings or default font,
        // see https://aka.ms/applicationconfiguration.
        ApplicationConfiguration.Initialize();
        
        // DevExpress için performans ayarları
        DevExpress.XtraEditors.WindowsFormsSettings.LoadApplicationSettings();
        DevExpress.Utils.AppearanceObject.DefaultMenuFont = new System.Drawing.Font("Tahoma", 8.25F);
        
        Application.Run(new FrmDrugList());
    }    
}
