using System;
using System.Collections.Generic;
using System.Linq;
using EczaneOtomasyon.Business.Common;
using EczaneOtomasyon.Business.Interfaces;
using EczaneOtomasyon.Business.Validation;
using EczaneOtomasyon.DataAccess;
using EczaneOtomasyon.DataAccess.Repositories;

namespace EczaneOtomasyon.Business
{
    /// <summary>
    /// Reçete yönetimi servisi - Reçete CRUD ve satış işlemleri
    /// </summary>
    public class PrescriptionService : IPrescriptionService
    {
        private readonly IPrescriptionRepository _prescriptionRepository;
        private readonly IDrugRepository _drugRepository;
        private readonly IStockService _stockService;
        private readonly IValidator<Prescription> _validator;

        /// <summary>
        /// PrescriptionService constructor - Dependency Injection ile servisler alır
        /// </summary>
        /// <param name="prescriptionRepository">Reçete repository</param>
        /// <param name="drugRepository">İlaç repository</param>
        /// <param name="stockService">Stok servisi</param>
        /// <param name="validator">Reçete validator</param>
        public PrescriptionService(
            IPrescriptionRepository prescriptionRepository,
            IDrugRepository drugRepository,
            IStockService stockService,
            IValidator<Prescription> validator)
        {
            _prescriptionRepository = prescriptionRepository;
            _drugRepository = drugRepository;
            _stockService = stockService;
            _validator = validator;
        }

        /// <summary>
        /// Reçeteyi kaydeder (satış olmadan)
        /// </summary>
        /// <param name="prescription">Reçete bilgileri</param>
        /// <param name="items">Reçetedeki ilaçlar</param>
        /// <returns>İşlem sonucu</returns>
        public Result SavePrescription(Prescription prescription, List<PrescriptionItem> items)
        {
            var validationResult = _validator.Validate(prescription);
            if (!validationResult.IsValid)
                return Result.Failure(validationResult.Errors);

            if (items == null || items.Count == 0)
                return Result.Failure("Reçete en az bir ilaç içermelidir.");

            try
            {
                _prescriptionRepository.Add(prescription);
                foreach (var item in items)
                {
                    item.PrescriptionId = prescription.Id;
                    _prescriptionRepository.AddPrescriptionItem(item);
                }
                _prescriptionRepository.SaveChanges();
                return Result.Success();
            }
            catch (Exception ex)
            {
                return Result.Failure($"Reçete kaydedilirken hata oluştu: {ex.Message}");
            }
        }

        /// <summary>
        /// Reçeteyi kaydeder ve satışını gerçekleştirir (stok düşer)
        /// </summary>
        /// <param name="prescription">Reçete bilgileri</param>
        /// <param name="items">Reçetedeki ilaçlar</param>
        /// <returns>İşlem sonucu</returns>
        public Result SavePrescriptionWithSale(Prescription prescription, List<PrescriptionItem> items)
        {
            var validationResult = _validator.Validate(prescription);
            if (!validationResult.IsValid)
                return Result.Failure(validationResult.Errors);

            if (items == null || items.Count == 0)
                return Result.Failure("Reçete en az bir ilaç içermelidir.");

            try
            {
                var totalAmountResult = CalculateTotalAmount(items.Select(i => i.DrugId).ToList());
                if (!totalAmountResult.IsSuccess)
                    return Result.Failure(totalAmountResult.ErrorMessage);

                prescription.IsSold = true;
                prescription.SaleDate = DateTime.Now;
                prescription.TotalAmount = totalAmountResult.Data;
                prescription.SaleStatus = "Satıldı";

                _prescriptionRepository.Add(prescription);
                foreach (var item in items)
                {
                    item.PrescriptionId = prescription.Id;
                    _prescriptionRepository.AddPrescriptionItem(item);
                    
                    if (!_stockService.RemoveStock(item.DrugId, 1))
                        return Result.Failure($"İlaç stoğu güncellenemedi (ID: {item.DrugId})");
                }
                _prescriptionRepository.SaveChanges();
                return Result.Success();
            }
            catch (Exception ex)
            {
                return Result.Failure($"Satış işlemi sırasında hata oluştu: {ex.Message}");
            }
        }

        /// <summary>
        /// Reçetedeki ilaçların toplam tutarını hesaplar
        /// </summary>
        /// <param name="drugIds">İlaç ID listesi</param>
        /// <returns>Toplam tutar</returns>
        public Result<decimal> CalculateTotalAmount(List<int> drugIds)
        {
            try
            {
                decimal total = 0;
                foreach (var drugId in drugIds)
                {
                    var drug = _drugRepository.GetById(drugId);
                    if (drug == null)
                        return Result<decimal>.Failure($"İlaç bulunamadı (ID: {drugId})");
                    
                    total += drug.Price;
                }
                return Result<decimal>.Success(total);
            }
            catch (Exception ex)
            {
                return Result<decimal>.Failure($"Fiyat hesaplanırken hata oluştu: {ex.Message}");
            }
        }

        /// <summary>
        /// Tüm reçeteleri getirir
        /// </summary>
        /// <returns>Reçete listesi</returns>
        public Result<List<Prescription>> GetAllPrescriptions()
        {
            try
            {
                var prescriptions = _prescriptionRepository.GetAll();
                return Result<List<Prescription>>.Success(prescriptions);
            }
            catch (Exception ex)
            {
                return Result<List<Prescription>>.Failure($"Reçeteler getirilirken hata oluştu: {ex.Message}");
            }
        }

        /// <summary>
        /// ID'ye göre reçete getirir
        /// </summary>
        /// <param name="id">Reçete ID</param>
        /// <returns>Reçete nesnesi</returns>
        public Result<Prescription> GetPrescriptionById(int id)
        {
            try
            {
                var prescription = _prescriptionRepository.GetById(id);
                if (prescription == null)
                    return Result<Prescription>.Failure("Reçete bulunamadı.");
                
                return Result<Prescription>.Success(prescription);
            }
            catch (Exception ex)
            {
                return Result<Prescription>.Failure($"Reçete getirilirken hata oluştu: {ex.Message}");
            }
        }
    }
}

