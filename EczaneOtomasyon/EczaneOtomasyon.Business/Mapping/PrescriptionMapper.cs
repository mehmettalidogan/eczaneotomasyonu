using System.Collections.Generic;
using System.Linq;
using EczaneOtomasyon.Business.DTOs;
using EczaneOtomasyon.DataAccess;

namespace EczaneOtomasyon.Business.Mapping
{
    public static class PrescriptionMapper
    {
        public static PrescriptionDto ToDto(Prescription prescription)
        {
            if (prescription == null) return null!;

            return new PrescriptionDto
            {
                Id = prescription.Id,
                PrescriptionNumber = prescription.PrescriptionNumber,
                PatientName = prescription.PatientName,
                PatientSurname = prescription.PatientSurname,
                PatientTC = prescription.PatientTC,
                PatientAge = prescription.PatientAge,
                Date = prescription.Date,
                IsSold = prescription.IsSold,
                SaleDate = prescription.SaleDate,
                TotalAmount = prescription.TotalAmount,
                SaleStatus = prescription.SaleStatus
            };
        }

        public static Prescription ToEntity(PrescriptionDto dto)
        {
            if (dto == null) return null!;

            return new Prescription
            {
                Id = dto.Id,
                PrescriptionNumber = dto.PrescriptionNumber,
                PatientName = dto.PatientName,
                PatientSurname = dto.PatientSurname,
                PatientTC = dto.PatientTC,
                PatientAge = dto.PatientAge,
                Date = dto.Date,
                IsSold = dto.IsSold,
                SaleDate = dto.SaleDate,
                TotalAmount = dto.TotalAmount,
                SaleStatus = dto.SaleStatus
            };
        }

        public static Prescription ToEntity(CreatePrescriptionDto dto)
        {
            if (dto == null) return null!;

            return new Prescription
            {
                PrescriptionNumber = dto.PrescriptionNumber,
                PatientName = dto.PatientName,
                PatientSurname = dto.PatientSurname,
                PatientTC = dto.PatientTC,
                PatientAge = dto.PatientAge,
                Date = dto.Date
            };
        }

        public static List<PrescriptionDto> ToDtoList(List<Prescription> prescriptions)
        {
            return prescriptions?.Select(ToDto).ToList() ?? new List<PrescriptionDto>();
        }

        public static PrescriptionItemDto ToItemDto(PrescriptionItem item, string drugName)
        {
            if (item == null) return null!;

            return new PrescriptionItemDto
            {
                DrugId = item.DrugId,
                DrugName = drugName,
                DailyDoseMg = item.DailyDoseMg
            };
        }

        public static PrescriptionItem ToItemEntity(PrescriptionItemDto dto)
        {
            if (dto == null) return null!;

            return new PrescriptionItem
            {
                DrugId = dto.DrugId,
                DailyDoseMg = dto.DailyDoseMg
            };
        }
    }
}

