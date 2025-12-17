using System;
using System.Collections.Generic;

namespace EczaneOtomasyon.Business.DTOs
{
    public class PrescriptionDto
    {
        public int Id { get; set; }
        public string PrescriptionNumber { get; set; } = string.Empty;
        public string PatientName { get; set; } = string.Empty;
        public string PatientSurname { get; set; } = string.Empty;
        public string PatientTC { get; set; } = string.Empty;
        public int PatientAge { get; set; }
        public DateTime Date { get; set; }
        public bool IsSold { get; set; }
        public DateTime? SaleDate { get; set; }
        public decimal TotalAmount { get; set; }
        public string SaleStatus { get; set; } = "Bekliyor";
        public string PatientFullName => $"{PatientName} {PatientSurname}";
        public string FormattedDate => Date.ToString("dd.MM.yyyy");
        public string FormattedTotalAmount => TotalAmount.ToString("C2");
    }

    public class PrescriptionItemDto
    {
        public int Id { get; set; }
        public int PrescriptionId { get; set; }
        public int DrugId { get; set; }
        public string DrugName { get; set; } = string.Empty;
        public int DailyDoseMg { get; set; }
    }

    public class CreatePrescriptionDto
    {
        public string PrescriptionNumber { get; set; } = string.Empty;
        public string PatientName { get; set; } = string.Empty;
        public string PatientSurname { get; set; } = string.Empty;
        public string PatientTC { get; set; } = string.Empty;
        public int PatientAge { get; set; }
        public DateTime Date { get; set; }
        public List<PrescriptionItemDto> Items { get; set; } = new List<PrescriptionItemDto>();
    }
}

