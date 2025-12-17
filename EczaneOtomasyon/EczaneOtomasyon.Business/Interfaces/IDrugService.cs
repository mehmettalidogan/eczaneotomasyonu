using System.Collections.Generic;
using EczaneOtomasyon.DataAccess;

namespace EczaneOtomasyon.Business.Interfaces
{
    public interface IDrugService
    {
        List<Drug> GetAll();
        Drug? GetById(int id);
        void Add(Drug drug);
        void Update(Drug drug);
        void Delete(int id);
    }
}
