using System.Collections.Generic;
using System.Linq;
using EczaneOtomasyon.Business.DTOs;
using EczaneOtomasyon.DataAccess;

namespace EczaneOtomasyon.Business.Mapping
{
    public static class DrugMapper
    {
        public static DrugDto ToDto(Drug drug)
        {
            if (drug == null) return null!;

            return new DrugDto
            {
                Id = drug.Id,
                Name = drug.Name,
                ActiveSubstance = drug.ActiveSubstance,
                Form = drug.Form,
                DosageMg = drug.DosageMg,
                Company = drug.Company,
                Category = drug.Category,
                Price = drug.Price,
                Stock = drug.Stock,
                Barcode = drug.Barcode
            };
        }

        public static Drug ToEntity(DrugDto dto)
        {
            if (dto == null) return null!;

            return new Drug
            {
                Id = dto.Id,
                Name = dto.Name,
                ActiveSubstance = dto.ActiveSubstance,
                Form = dto.Form,
                DosageMg = dto.DosageMg,
                Company = dto.Company,
                Category = dto.Category,
                Price = dto.Price,
                Stock = dto.Stock,
                Barcode = dto.Barcode
            };
        }

        public static List<DrugDto> ToDtoList(List<Drug> drugs)
        {
            return drugs?.Select(ToDto).ToList() ?? new List<DrugDto>();
        }

        public static List<Drug> ToEntityList(List<DrugDto> dtos)
        {
            return dtos?.Select(ToEntity).ToList() ?? new List<Drug>();
        }
    }
}

