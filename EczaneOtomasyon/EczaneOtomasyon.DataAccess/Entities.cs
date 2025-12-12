using System;

namespace EczaneOtomasyon.DataAccess
{
    public class Prescription
    {
        public int Id { get; set; }
        public string PrescriptionNumber { get; set; } = string.Empty;
        public string PatientName { get; set; } = string.Empty;
        public string PatientSurname { get; set; } = string.Empty;
        public string PatientTC { get; set; } = string.Empty;
        public int PatientAge { get; set; }
        public DateTime Date { get; set; }
        
        // Satış Bilgileri
        public bool IsSold { get; set; } = false;
        public DateTime? SaleDate { get; set; }
        public decimal TotalAmount { get; set; } = 0;
        public string SaleStatus { get; set; } = "Bekliyor"; // "Bekliyor", "Satıldı"
    }

    public class PrescriptionItem
    {
        public int Id { get; set; }
        public int PrescriptionId { get; set; }
        public int DrugId { get; set; }
        public int DailyDoseMg { get; set; }
    }

    public class Contraindication
    {
        public int Id { get; set; }
        public int Drug1Id { get; set; }
        public int Drug2Id { get; set; }
        public string Severity { get; set; } = string.Empty; // "Low", "Medium", "High"
        public string Message { get; set; } = string.Empty;
    }

    public class DoseRule
    {
        public int Id { get; set; }
        public int DrugId { get; set; }
        public int MinAge { get; set; }
        public int MaxAge { get; set; }
        public int MaxDailyDoseMg { get; set; }
        public string Message { get; set; } = string.Empty;
    }
}

