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
            // Seed Data (Örnek Kurallar)
            modelBuilder.Entity<Contraindication>().HasData(
                new Contraindication { Id = 1, Drug1Id = 1, Drug2Id = 2, Severity = "High", Message = "Bu iki ilaç birlikte kullanıldığında kanama riski artar." }
            );

            modelBuilder.Entity<DoseRule>().HasData(
                new DoseRule { Id = 1, DrugId = 1, MinAge = 0, MaxAge = 12, MaxDailyDoseMg = 500, Message = "12 yaş altı çocuklarda günlük 500mg aşılmamalıdır." }
            );
        }
    }
}
