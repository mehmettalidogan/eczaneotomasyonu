using System.Collections.Generic;
using EczaneOtomasyon.Business.Common;
using EczaneOtomasyon.DataAccess;

namespace EczaneOtomasyon.Business.Interfaces
{
    public interface IPrescriptionService
    {
        Result SavePrescription(Prescription prescription, List<PrescriptionItem> items);
        Result SavePrescriptionWithSale(Prescription prescription, List<PrescriptionItem> items);
        Result<decimal> CalculateTotalAmount(List<int> drugIds);
        Result<List<Prescription>> GetAllPrescriptions();
        Result<Prescription> GetPrescriptionById(int id);
    }
}

