using Microsoft.EntityFrameworkCore;

namespace EczaneOtomasyon.DataAccess
{
    public class EczaneContext : DbContext
    {
        public DbSet<Drug> Drugs { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            // SQL Server yerine geçici olarak InMemory veritabanı kullanıyoruz.
            optionsBuilder.UseInMemoryDatabase("EczaneOtomasyonDb");
        }
    }
}

