using System.Collections.Generic;
using System.Linq;
using EczaneOtomasyon.DataAccess;

namespace EczaneOtomasyon.Business
{
    public class StockService
    {
        private EczaneContext _context;

        public StockService()
        {
            _context = new EczaneContext();
        }

        /// <summary>
        /// Tüm ilaçların stok bilgilerini getirir
        /// </summary>
        public List<Drug> GetAllWithStock()
        {
            return _context.Drugs.ToList();
        }

        /// <summary>
        /// Stok miktarına göre ilaçları filtreler
        /// </summary>
        public List<Drug> GetLowStockDrugs(int threshold = 10)
        {
            return _context.Drugs.Where(d => d.Stock <= threshold).ToList();
        }

        /// <summary>
        /// Stokta olmayan ilaçları getirir
        /// </summary>
        public List<Drug> GetOutOfStockDrugs()
        {
            return _context.Drugs.Where(d => d.Stock <= 0).ToList();
        }

        /// <summary>
        /// Belirli bir ilacın stok durumunu kontrol eder
        /// </summary>
        public bool IsInStock(int drugId, int quantity = 1)
        {
            var drug = _context.Drugs.Find(drugId);
            return drug != null && drug.Stock >= quantity;
        }

        /// <summary>
        /// İlaç stoğunu artırır
        /// </summary>
        public void AddStock(int drugId, int quantity)
        {
            var drug = _context.Drugs.Find(drugId);
            if (drug != null)
            {
                drug.Stock += quantity;
                _context.SaveChanges();
            }
        }

        /// <summary>
        /// İlaç stoğunu azaltır
        /// </summary>
        public bool RemoveStock(int drugId, int quantity)
        {
            var drug = _context.Drugs.Find(drugId);
            if (drug != null && drug.Stock >= quantity)
            {
                drug.Stock -= quantity;
                _context.SaveChanges();
                return true;
            }
            return false;
        }

        /// <summary>
        /// İlaç stoğunu belirli bir değere ayarlar
        /// </summary>
        public void SetStock(int drugId, int quantity)
        {
            var drug = _context.Drugs.Find(drugId);
            if (drug != null)
            {
                drug.Stock = quantity;
                _context.SaveChanges();
            }
        }

        /// <summary>
        /// Tüm ilaçların stoklarını başlangıç değerine (100) ayarlar
        /// </summary>
        public void InitializeAllStocks(int initialStock = 100)
        {
            var drugs = _context.Drugs.ToList();
            foreach (var drug in drugs)
            {
                drug.Stock = initialStock;
            }
            _context.SaveChanges();
        }

        /// <summary>
        /// Reçete ilaçlarının stoğunu kontrol eder
        /// </summary>
        public List<string> CheckPrescriptionStock(List<int> drugIds)
        {
            var outOfStockDrugs = new List<string>();
            
            foreach (var drugId in drugIds)
            {
                var drug = _context.Drugs.Find(drugId);
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

