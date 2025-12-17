using System.Collections.Generic;

namespace EczaneOtomasyon.DataAccess.Repositories
{
    public interface IDrugRepository
    {
        List<Drug> GetAll();
        Drug? GetById(int id);
        Drug? GetByBarcode(string barcode);
        void Add(Drug drug);
        void Update(Drug drug);
        void Delete(int id);
        bool Exists(int id);
    }
}

