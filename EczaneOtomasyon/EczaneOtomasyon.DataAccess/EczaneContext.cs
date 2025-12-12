using Microsoft.EntityFrameworkCore;

namespace EczaneOtomasyon.DataAccess
{
    public class EczaneContext : DbContext
    {
        public DbSet<Drug> Drugs { get; set; }
        public DbSet<Prescription> Prescriptions { get; set; }
        public DbSet<PrescriptionItem> PrescriptionItems { get; set; }
        public DbSet<Contraindication> Contraindications { get; set; }
        public DbSet<DoseRule> DoseRules { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer("Server=.\\SQLEXPRESS;Database=EczaneOtomasyonDb;Trusted_Connection=True;TrustServerCertificate=True;");
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            // Seed data EnsureSeedData() metodu ile PrescriptionChecker tarafından yönetiliyor
            base.OnModelCreating(modelBuilder);
        }
    }
}
