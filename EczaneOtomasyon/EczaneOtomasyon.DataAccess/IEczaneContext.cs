using Microsoft.EntityFrameworkCore;

namespace EczaneOtomasyon.DataAccess
{
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

