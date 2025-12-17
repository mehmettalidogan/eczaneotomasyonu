using System.Collections.Generic;
using System.Linq;
using EczaneOtomasyon.DataAccess;
using EczaneOtomasyon.DataAccess.Repositories;
using EczaneOtomasyon.Business.Interfaces;

namespace EczaneOtomasyon.Business
{
    public class StockService : IStockService
    {
        private readonly IDrugRepository _drugRepository;

        public StockService(IDrugRepository drugRepository)
        {
            _drugRepository = drugRepository;
        }

        public List<Drug> GetAllWithStock()
        {
            return _drugRepository.GetAll();
        }

        public List<Drug> GetLowStockDrugs(int threshold = 10)
        {
            return _drugRepository.GetAll().Where(d => d.Stock <= threshold).ToList();
        }

        public List<Drug> GetOutOfStockDrugs()
        {
            return _drugRepository.GetAll().Where(d => d.Stock <= 0).ToList();
        }

        public bool IsInStock(int drugId, int quantity = 1)
        {
            var drug = _drugRepository.GetById(drugId);
            return drug != null && drug.Stock >= quantity;
        }

        public void AddStock(int drugId, int quantity)
        {
            var drug = _drugRepository.GetById(drugId);
            if (drug != null)
            {
                drug.Stock += quantity;
                _drugRepository.Update(drug);
            }
        }

        public bool RemoveStock(int drugId, int quantity)
        {
            var drug = _drugRepository.GetById(drugId);
            if (drug != null && drug.Stock >= quantity)
            {
                drug.Stock -= quantity;
                _drugRepository.Update(drug);
                return true;
            }
            return false;
        }

        public void SetStock(int drugId, int quantity)
        {
            var drug = _drugRepository.GetById(drugId);
            if (drug != null)
            {
                drug.Stock = quantity;
                _drugRepository.Update(drug);
            }
        }

        public void InitializeAllStocks(int initialStock = 100)
        {
            var drugs = _drugRepository.GetAll();
            foreach (var drug in drugs)
            {
                drug.Stock = initialStock;
                _drugRepository.Update(drug);
            }
        }

        public List<string> CheckPrescriptionStock(List<int> drugIds)
        {
            var outOfStockDrugs = new List<string>();
            
            foreach (var drugId in drugIds)
            {
                var drug = _drugRepository.GetById(drugId);
                if (drug == null)
                {
                    outOfStockDrugs.Add($"İlaç bulunamadı (ID: {drugId})");
                }
                else if (drug.Stock <= 0)
                {
                    outOfStockDrugs.Add($"{drug.Name} - Stokta yok!");
                }
            }
            
            return outOfStockDrugs;
        }
    }
}

