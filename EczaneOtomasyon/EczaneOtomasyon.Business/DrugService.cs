using System.Collections.Generic;
using System.Linq;
using EczaneOtomasyon.DataAccess;

namespace EczaneOtomasyon.Business
{
    public class DrugService
    {
        private EczaneContext _context;

        public DrugService()
        {
            _context = new EczaneContext();
            // Ensure database is created
            _context.Database.EnsureCreated();
        }

        public List<Drug> GetAll()
        {
            return _context.Drugs.ToList();
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
            var drug = _context.Drugs.Find(id);
            if (drug != null)
            {
                _context.Drugs.Remove(drug);
                _context.SaveChanges();
            }
        }
    }
}

