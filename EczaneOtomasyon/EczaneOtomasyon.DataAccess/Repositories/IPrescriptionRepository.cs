using System.Collections.Generic;

namespace EczaneOtomasyon.DataAccess.Repositories
{
    public interface IPrescriptionRepository
    {
        List<Prescription> GetAll();
        Prescription? GetById(int id);
        List<Prescription> GetSold();
        List<Prescription> GetPending();
        void Add(Prescription prescription);
        void Update(Prescription prescription);
        void Delete(int id);
        List<PrescriptionItem> GetPrescriptionItems(int prescriptionId);
        void AddPrescriptionItem(PrescriptionItem item);
        void SaveChanges();
    }
}


