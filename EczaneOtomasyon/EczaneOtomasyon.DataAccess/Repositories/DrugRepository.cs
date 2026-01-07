using System.Collections.Generic;
using System.Linq;

namespace EczaneOtomasyon.DataAccess.Repositories
{
    /// <summary>
    /// İlaç veri erişim implementasyonu
    /// </summary>
    public class DrugRepository : IDrugRepository
    {
        private readonly IEczaneContext _context;

        public DrugRepository(IEczaneContext context)
        {
            _context = context;
        }

        public List<Drug> GetAll()
        {
            return _context.Drugs.ToList();
        }

        public Drug? GetById(int id)
        {
            return _context.Drugs.Find(id);
        }

        public Drug? GetByBarcode(string barcode)
        {
            return _context.Drugs.FirstOrDefault(d => d.Barcode == barcode);
        }

        public void Add(Drug drug)
        {
            _context.Drugs.Add(drug);
            _context.SaveChanges();
        }

        public void Update(Drug drug)
        {
            _context.Drugs.Update(drug);
            _context.SaveChanges();
        }

        public void Delete(int id)
        {
            var drug = GetById(id);
            if (drug != null)
            {
                _context.Drugs.Remove(drug);
                _context.SaveChanges();
            }
        }

        public bool Exists(int id)
        {
            return _context.Drugs.Any(d => d.Id == id);
        }
    }
}


