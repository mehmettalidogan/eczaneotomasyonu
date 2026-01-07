using System.Collections.Generic;
using System.Linq;
using EczaneOtomasyon.DataAccess;
using EczaneOtomasyon.DataAccess.Repositories;
using EczaneOtomasyon.Business.Interfaces;

namespace EczaneOtomasyon.Business
{
    /// <summary>
    /// Stok yönetimi servisi - İlaç stok işlemleri
    /// </summary>
    public class StockService : IStockService
    {
        private readonly IDrugRepository _drugRepository;

        /// <summary>
        /// StockService constructor - Dependency Injection ile repository alır
        /// </summary>
        /// <param name="drugRepository">İlaç repository</param>
        public StockService(IDrugRepository drugRepository)
        {
            _drugRepository = drugRepository;
        }

        /// <summary>
        /// Tüm ilaçları stok bilgisiyle getirir
        /// </summary>
        /// <returns>İlaç listesi</returns>
        public List<Drug> GetAllWithStock()
        {
            return _drugRepository.GetAll();
        }

        /// <summary>
        /// Düşük stoklu ilaçları getirir
        /// </summary>
        /// <param name="threshold">Stok eşik değeri (varsayılan 10)</param>
        /// <returns>Düşük stoklu ilaç listesi</returns>
        public List<Drug> GetLowStockDrugs(int threshold = 10)
        {
            return _drugRepository.GetAll().Where(d => d.Stock <= threshold).ToList();
        }

        /// <summary>
        /// Stokta olmayan ilaçları getirir
        /// </summary>
        /// <returns>Stokta olmayan ilaç listesi</returns>
        public List<Drug> GetOutOfStockDrugs()
        {
            return _drugRepository.GetAll().Where(d => d.Stock <= 0).ToList();
        }

        /// <summary>
        /// İlacın stokta olup olmadığını kontrol eder
        /// </summary>
        /// <param name="drugId">İlaç ID</param>
        /// <param name="quantity">İstenen miktar (varsayılan 1)</param>
        /// <returns>Stokta varsa true, yoksa false</returns>
        public bool IsInStock(int drugId, int quantity = 1)
        {
            var drug = _drugRepository.GetById(drugId);
            return drug != null && drug.Stock >= quantity;
        }

        /// <summary>
        /// İlaç stoğuna miktar ekler
        /// </summary>
        /// <param name="drugId">İlaç ID</param>
        /// <param name="quantity">Eklenecek miktar</param>
        public void AddStock(int drugId, int quantity)
        {
            var drug = _drugRepository.GetById(drugId);
            if (drug != null)
            {
                drug.Stock += quantity;
                _drugRepository.Update(drug);
            }
        }

        /// <summary>
        /// İlaç stoğundan miktar çıkarır
        /// </summary>
        /// <param name="drugId">İlaç ID</param>
        /// <param name="quantity">Çıkarılacak miktar</param>
        /// <returns>Başarılıysa true, değilse false</returns>
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

        /// <summary>
        /// İlaç stoğunu belirli bir değere ayarlar
        /// </summary>
        /// <param name="drugId">İlaç ID</param>
        /// <param name="quantity">Yeni stok miktarı</param>
        public void SetStock(int drugId, int quantity)
        {
            var drug = _drugRepository.GetById(drugId);
            if (drug != null)
            {
                drug.Stock = quantity;
                _drugRepository.Update(drug);
            }
        }

        /// <summary>
        /// Tüm ilaçların stoklarını belirli bir değere ayarlar
        /// </summary>
        /// <param name="initialStock">Başlangıç stok miktarı (varsayılan 100)</param>
        public void InitializeAllStocks(int initialStock = 100)
        {
            var drugs = _drugRepository.GetAll();
            foreach (var drug in drugs)
            {
                drug.Stock = initialStock;
                _drugRepository.Update(drug);
            }
        }

        /// <summary>
        /// Reçete için gerekli ilaçların stok durumunu kontrol eder
        /// </summary>
        /// <param name="drugIds">Kontrol edilecek ilaç ID listesi</param>
        /// <returns>Stokta olmayan ilaçların bilgi mesajları</returns>
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

