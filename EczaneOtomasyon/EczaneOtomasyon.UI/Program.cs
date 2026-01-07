using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using EczaneOtomasyon.DataAccess;
using EczaneOtomasyon.DataAccess.Repositories;
using EczaneOtomasyon.Business;
using EczaneOtomasyon.Business.Interfaces;
using EczaneOtomasyon.Business.Validation;

namespace EczaneOtomasyon.UI;

static class Program
{
    public static IServiceProvider? ServiceProvider { get; private set; }

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
        
        // ===== DEPENDENCY INJECTION CONTAINER KURULUMU =====
        var host = Host.CreateDefaultBuilder()
            .ConfigureServices((context, services) =>
            {
                // Database Context
                services.AddScoped<IEczaneContext, EczaneContext>();
                
                // Repositories
                services.AddScoped<IDrugRepository, DrugRepository>();
                services.AddScoped<IPrescriptionRepository, PrescriptionRepository>();
                
                // Business Services
                services.AddScoped<IDrugService, DrugService>();
                services.AddScoped<IStockService, StockService>();
                services.AddScoped<IBarcodeService, BarcodeService>();
                services.AddScoped<IPrescriptionChecker, PrescriptionChecker>();
                services.AddScoped<IReceiptPrinter, ReceiptPrinter>();
                services.AddScoped<IPrescriptionService, PrescriptionService>();
                
                // Validators
                services.AddScoped<IValidator<Prescription>, PrescriptionValidator>();
                
                // Forms - Transient olarak kaydedilir (her açılışta yeni instance)
                services.AddTransient<FrmDrugList>();
                services.AddTransient<FrmDrugEdit>();
                services.AddTransient<FrmDrugDetails>();
                services.AddTransient<FrmStockManagement>();
                services.AddTransient<FrmPrescriptionList>();
                services.AddTransient<FrmPrescriptionEdit>();
                services.AddTransient<FrmPrescriptionDetails>();
                services.AddTransient<FrmPrescriptionWarnings>();
            })
            .Build();
        
        ServiceProvider = host.Services;
        
        // Veritabanını başlangıçta hazırla
        using (var scope = ServiceProvider.CreateScope())
        {
            var context = scope.ServiceProvider.GetRequiredService<IEczaneContext>();
            context.Database.EnsureCreated();
        }
        
        // Ana formu DI ile al
        var mainForm = ServiceProvider.GetRequiredService<FrmDrugList>();
        Application.Run(mainForm);
    }    
}
