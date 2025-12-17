using System.Collections.Generic;
using System.Linq;

namespace EczaneOtomasyon.DataAccess.Repositories
{
    public class PrescriptionRepository : IPrescriptionRepository
    {
        private readonly IEczaneContext _context;

        public PrescriptionRepository(IEczaneContext context)
        {
            _context = context;
        }

        public List<Prescription> GetAll()
        {
            return _context.Prescriptions.OrderByDescending(p => p.Date).ToList();
        }

        public Prescription? GetById(int id)
        {
            return _context.Prescriptions.FirstOrDefault(p => p.Id == id);
        }

        public List<Prescription> GetSold()
        {
            return _context.Prescriptions
                .Where(p => p.IsSold)
                .OrderByDescending(p => p.SaleDate)
                .ToList();
        }

        public List<Prescription> GetPending()
        {
            return _context.Prescriptions
                .Where(p => !p.IsSold)
                .OrderByDescending(p => p.Date)
                .ToList();
        }

        public void Add(Prescription prescription)
        {
            _context.Prescriptions.Add(prescription);
            _context.SaveChanges();
        }

        public void Update(Prescription prescription)
        {
            _context.Prescriptions.Update(prescription);
            _context.SaveChanges();
        }

        public void Delete(int id)
        {
            var prescription = GetById(id);
            if (prescription != null)
            {
                _context.Prescriptions.Remove(prescription);
                _context.SaveChanges();
            }
        }

        public List<PrescriptionItem> GetPrescriptionItems(int prescriptionId)
        {
            return _context.PrescriptionItems
                .Where(pi => pi.PrescriptionId == prescriptionId)
                .ToList();
        }

        public void AddPrescriptionItem(PrescriptionItem item)
        {
            _context.PrescriptionItems.Add(item);
            _context.SaveChanges();
        }

        public void SaveChanges()
        {
            _context.SaveChanges();
        }
    }
}


