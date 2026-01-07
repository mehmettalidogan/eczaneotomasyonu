using System.Collections.Generic;
using EczaneOtomasyon.DataAccess;
using EczaneOtomasyon.DataAccess.Repositories;
using EczaneOtomasyon.Business.Interfaces;

namespace EczaneOtomasyon.Business
{
    /// <summary>
    /// İlaç yönetimi servisi - CRUD operasyonları
    /// </summary>
    public class DrugService : IDrugService
    {
        private readonly IDrugRepository _drugRepository;

        /// <summary>
        /// DrugService constructor - Dependency Injection ile repository alır
        /// </summary>
        /// <param name="drugRepository">İlaç repository</param>
        public DrugService(IDrugRepository drugRepository)
        {
            _drugRepository = drugRepository;
        }

        /// <summary>
        /// Tüm ilaçları getirir
        /// </summary>
        /// <returns>İlaç listesi</returns>
        public List<Drug> GetAll()
        {
            return _drugRepository.GetAll();
        }

        /// <summary>
        /// ID'ye göre ilaç getirir
        /// </summary>
        /// <param name="id">İlaç ID</param>
        /// <returns>İlaç nesnesi veya null</returns>
        public Drug? GetById(int id)
        {
            return _drugRepository.GetById(id);
        }

        /// <summary>
        /// Yeni ilaç ekler
        /// </summary>
        /// <param name="drug">Eklenecek ilaç</param>
        public void Add(Drug drug)
        {
            _drugRepository.Add(drug);
        }

        /// <summary>
        /// Mevcut ilacı günceller
        /// </summary>
        /// <param name="drug">Güncellenecek ilaç</param>
        public void Update(Drug drug)
        {
            _drugRepository.Update(drug);
        }

        /// <summary>
        /// İlacı siler
        /// </summary>
        /// <param name="id">Silinecek ilaç ID</param>
        public void Delete(int id)
        {
            _drugRepository.Delete(id);
        }
    }
}

