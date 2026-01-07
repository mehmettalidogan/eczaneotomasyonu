using Microsoft.EntityFrameworkCore;

namespace EczaneOtomasyon.DataAccess
{
    /// <summary>
    /// Database context interface - Dependency Inversion için
    /// </summary>
    public interface IEczaneContext
    {
        DbSet<Drug> Drugs { get; }
        DbSet<Prescription> Prescriptions { get; }
        DbSet<PrescriptionItem> PrescriptionItems { get; }
        DbSet<Contraindication> Contraindications { get; }
        DbSet<DoseRule> DoseRules { get; }
        
        int SaveChanges();
        Microsoft.EntityFrameworkCore.Infrastructure.DatabaseFacade Database { get; }
    }
}

