using System.Collections.Generic;
using EczaneOtomasyon.DataAccess;

namespace EczaneOtomasyon.Business.Interfaces
{
    public interface IStockService
    {
        List<Drug> GetAllWithStock();
        List<Drug> GetLowStockDrugs(int threshold = 10);
        List<Drug> GetOutOfStockDrugs();
        bool IsInStock(int drugId, int quantity = 1);
        void AddStock(int drugId, int quantity);
        bool RemoveStock(int drugId, int quantity);
        void SetStock(int drugId, int quantity);
        void InitializeAllStocks(int initialStock = 100);
        List<string> CheckPrescriptionStock(List<int> drugIds);
    }
}
