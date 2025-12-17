using System.Collections.Generic;
using EczaneOtomasyon.DataAccess;

namespace EczaneOtomasyon.Business.Interfaces
{
    public interface IPrescriptionChecker
    {
        List<InteractionWarning> CheckInteractions(List<PrescriptionItemDto> items);
        List<InteractionWarning> CheckDoses(List<PrescriptionItemDto> items, int patientAge);
        void EnsureSeedData();
        
        // Reçete CRUD operasyonları
        void SavePrescription(Prescription prescription, List<PrescriptionItem> items);
        List<Prescription> GetAllPrescriptions();
        List<PrescriptionItem> GetPrescriptionItems(int prescriptionId);
        Prescription? GetPrescriptionById(int id);
        
        // Satış işlemleri
        void SavePrescriptionWithSale(Prescription prescription, List<PrescriptionItem> items, decimal totalAmount);
        void MarkAsSold(int prescriptionId, decimal totalAmount);
        List<Prescription> GetSoldPrescriptions();
        List<Prescription> GetPendingPrescriptions();
    }
}
