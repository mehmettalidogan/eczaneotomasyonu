using System;
using System.Collections.Generic;
using System.Linq;
using EczaneOtomasyon.Business.Common;
using EczaneOtomasyon.Business.Interfaces;
using EczaneOtomasyon.Business.Validation;
using EczaneOtomasyon.Business.Logging;
using EczaneOtomasyon.DataAccess;
using EczaneOtomasyon.DataAccess.Repositories;

namespace EczaneOtomasyon.Business
{
    public class PrescriptionService : IPrescriptionService
    {
        private readonly IPrescriptionRepository _prescriptionRepository;
        private readonly IDrugRepository _drugRepository;
        private readonly IStockService _stockService;
        private readonly IValidator<Prescription> _validator;
        private readonly ILogger _logger;

        public PrescriptionService(
            IPrescriptionRepository prescriptionRepository,
            IDrugRepository drugRepository,
            IStockService stockService,
            IValidator<Prescription> validator,
            ILogger logger)
        {
            _prescriptionRepository = prescriptionRepository;
            _drugRepository = drugRepository;
            _stockService = stockService;
            _validator = validator;
            _logger = logger;
        }

        public Result SavePrescription(Prescription prescription, List<PrescriptionItem> items)
        {
            _logger.LogInfo($"Reçete kaydediliyor - No: {prescription.PrescriptionNumber}, Hasta: {prescription.PatientName} {prescription.PatientSurname}");
            
            var validationResult = _validator.Validate(prescription);
            if (!validationResult.IsValid)
            {
                _logger.LogWarning($"Reçete validasyon hatası: {validationResult.GetErrorMessage()}");
                return Result.Failure(validationResult.Errors);
            }

            if (items == null || items.Count == 0)
            {
                _logger.LogWarning("Reçete ilaç içermiyor");
                return Result.Failure("Reçete en az bir ilaç içermelidir.");
            }

            try
            {
                _prescriptionRepository.Add(prescription);
                foreach (var item in items)
                {
                    item.PrescriptionId = prescription.Id;
                    _prescriptionRepository.AddPrescriptionItem(item);
                }
                _prescriptionRepository.SaveChanges();
                _logger.LogInfo($"Reçete başarıyla kaydedildi - ID: {prescription.Id}");
                return Result.Success();
            }
            catch (Exception ex)
            {
                _logger.LogError($"Reçete kaydedilirken hata oluştu - No: {prescription.PrescriptionNumber}", ex);
                return Result.Failure($"Reçete kaydedilirken hata oluştu: {ex.Message}");
            }
        }

        public Result SavePrescriptionWithSale(Prescription prescription, List<PrescriptionItem> items)
        {
            _logger.LogInfo($"Reçete satışı başlatıldı - No: {prescription.PrescriptionNumber}");
            
            var validationResult = _validator.Validate(prescription);
            if (!validationResult.IsValid)
            {
                _logger.LogWarning($"Satış validasyon hatası: {validationResult.GetErrorMessage()}");
                return Result.Failure(validationResult.Errors);
            }

            if (items == null || items.Count == 0)
            {
                _logger.LogWarning("Satış için reçete ilaç içermiyor");
                return Result.Failure("Reçete en az bir ilaç içermelidir.");
            }

            try
            {
                var totalAmountResult = CalculateTotalAmount(items.Select(i => i.DrugId).ToList());
                if (!totalAmountResult.IsSuccess)
                {
                    _logger.LogError($"Fiyat hesaplanamadı: {totalAmountResult.ErrorMessage}");
                    return Result.Failure(totalAmountResult.ErrorMessage);
                }

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
                    {
                        _logger.LogError($"Stok güncellenemedi - DrugID: {item.DrugId}");
                        return Result.Failure($"İlaç stoğu güncellenemedi (ID: {item.DrugId})");
                    }
                }
                _prescriptionRepository.SaveChanges();
                _logger.LogInfo($"Reçete satışı başarılı - ID: {prescription.Id}, Tutar: {prescription.TotalAmount:C2}");
                return Result.Success();
            }
            catch (Exception ex)
            {
                _logger.LogCritical($"Satış işlemi kritik hata - No: {prescription.PrescriptionNumber}", ex);
                return Result.Failure($"Satış işlemi sırasında hata oluştu: {ex.Message}");
            }
        }

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

