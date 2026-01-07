using System.Collections.Generic;

namespace EczaneOtomasyon.DataAccess.Repositories
{
    /// <summary>
    /// İlaç veri erişim interface'i
    /// </summary>
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

