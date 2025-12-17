using System;
using System.Collections.Generic;
using EczaneOtomasyon.DataAccess;
using EczaneOtomasyon.DataAccess.Repositories;
using EczaneOtomasyon.Business.Interfaces;
using EczaneOtomasyon.Business.Logging;

namespace EczaneOtomasyon.Business
{
    public class DrugService : IDrugService
    {
        private readonly IDrugRepository _drugRepository;
        private readonly ILogger _logger;

        public DrugService(IDrugRepository drugRepository, ILogger logger)
        {
            _drugRepository = drugRepository;
            _logger = logger;
        }

        public List<Drug> GetAll()
        {
            try
            {
                _logger.LogInfo("Tüm ilaçlar listeleniyor");
                return _drugRepository.GetAll();
            }
            catch (Exception ex)
            {
                _logger.LogError("İlaçlar listelenirken hata oluştu", ex);
                throw;
            }
        }

        public Drug? GetById(int id)
        {
            try
            {
                _logger.LogInfo($"İlaç getiriliyor - ID: {id}");
                return _drugRepository.GetById(id);
            }
            catch (Exception ex)
            {
                _logger.LogError($"İlaç getirilirken hata oluştu - ID: {id}", ex);
                throw;
            }
        }

        public void Add(Drug drug)
        {
            try
            {
                _logger.LogInfo($"Yeni ilaç ekleniyor - Ad: {drug.Name}");
                _drugRepository.Add(drug);
                _logger.LogInfo($"İlaç başarıyla eklendi - ID: {drug.Id}, Ad: {drug.Name}");
            }
            catch (Exception ex)
            {
                _logger.LogError($"İlaç eklenirken hata oluştu - Ad: {drug.Name}", ex);
                throw;
            }
        }

        public void Update(Drug drug)
        {
            try
            {
                _logger.LogInfo($"İlaç güncelleniyor - ID: {drug.Id}, Ad: {drug.Name}");
                _drugRepository.Update(drug);
                _logger.LogInfo($"İlaç başarıyla güncellendi - ID: {drug.Id}");
            }
            catch (Exception ex)
            {
                _logger.LogError($"İlaç güncellenirken hata oluştu - ID: {drug.Id}", ex);
                throw;
            }
        }

        public void Delete(int id)
        {
            try
            {
                _logger.LogWarning($"İlaç siliniyor - ID: {id}");
                _drugRepository.Delete(id);
                _logger.LogInfo($"İlaç başarıyla silindi - ID: {id}");
            }
            catch (Exception ex)
            {
                _logger.LogError($"İlaç silinirken hata oluştu - ID: {id}", ex);
                throw;
            }
        }
    }
}

