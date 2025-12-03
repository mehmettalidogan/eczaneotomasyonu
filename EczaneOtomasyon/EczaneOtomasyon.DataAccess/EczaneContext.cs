using Microsoft.EntityFrameworkCore;

namespace EczaneOtomasyon.DataAccess
{
    public class EczaneContext : DbContext
    {
        public DbSet<Drug> Drugs { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            // Gerçek SQL Server bağlantısı (SQLEXPRESS)
            // TrustServerCertificate=True: SSL sertifika hatasını önler (özellikle yeni SQL sürümlerinde)
            optionsBuilder.UseSqlServer("Server=.\\SQLEXPRESS;Database=EczaneOtomasyonDb;Trusted_Connection=True;TrustServerCertificate=True;");
        }
    }
}

