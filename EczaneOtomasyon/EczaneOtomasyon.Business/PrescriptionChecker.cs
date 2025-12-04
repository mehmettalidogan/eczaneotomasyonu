using System;
using System.Collections.Generic;
using System.Linq;
using EczaneOtomasyon.DataAccess;

namespace EczaneOtomasyon.Business
{
    // DTOs
    public class PrescriptionItemDto
    {
        public int DrugId { get; set; }
        public string DrugName { get; set; } = string.Empty;
        public int DailyDoseMg { get; set; }
    }

    public class InteractionWarning
    {
        public string Type { get; set; } = string.Empty; // "Interaction" or "Dose"
        public string Severity { get; set; } = string.Empty; // "Low", "Medium", "High"
        public string Message { get; set; } = string.Empty;
    }

    public class PrescriptionChecker
    {
        private readonly EczaneContext _context;

        public PrescriptionChecker()
        {
            _context = new EczaneContext();
            _context.Database.EnsureCreated(); // Tabloların oluştuğundan emin ol
        }

        public List<InteractionWarning> CheckInteractions(List<PrescriptionItemDto> items)
        {
            var warnings = new List<InteractionWarning>();
            var drugIds = items.Select(i => i.DrugId).ToList();

            // Veritabanındaki tüm etkileşim kurallarını çek (Performans için sadece ilgili ilaçlar filtrelenebilir)
            var allContraindications = _context.Contraindications.ToList();

            for (int i = 0; i < items.Count; i++)
            {
                for (int j = i + 1; j < items.Count; j++)
                {
                    var d1 = items[i];
                    var d2 = items[j];

                    // Çift yönlü kontrol (A-B veya B-A)
                    var match = allContraindications.FirstOrDefault(c => 
                        (c.Drug1Id == d1.DrugId && c.Drug2Id == d2.DrugId) ||
                        (c.Drug1Id == d2.DrugId && c.Drug2Id == d1.DrugId));

                    if (match != null)
                    {
                        warnings.Add(new InteractionWarning
                        {
                            Type = "Interaction",
                            Severity = match.Severity,
                            Message = $"'{d1.DrugName}' ile '{d2.DrugName}' arasında etkileşim: {match.Message}"
                        });
                    }
                }
            }

            return warnings;
        }

        public List<InteractionWarning> CheckDoses(List<PrescriptionItemDto> items, int patientAge)
        {
            var warnings = new List<InteractionWarning>();

            foreach (var item in items)
            {
                // İlgili ilaç için kuralları bul
                var rules = _context.DoseRules.Where(r => r.DrugId == item.DrugId).ToList();

                foreach (var rule in rules)
                {
                    // Yaş Kontrolü
                    if (patientAge >= rule.MinAge && patientAge <= rule.MaxAge)
                    {
                        if (item.DailyDoseMg > rule.MaxDailyDoseMg)
                        {
                            warnings.Add(new InteractionWarning
                            {
                                Type = "Dose",
                                Severity = "High",
                                Message = $"'{item.DrugName}' için doz aşımı! ({patientAge} yaş için Max: {rule.MaxDailyDoseMg} mg, Girilen: {item.DailyDoseMg} mg). {rule.Message}"
                            });
                        }
                    }
                }
            }

            return warnings;
        }
        
        // Seed Data Helper (UI'dan çağırıp test verisi oluşturmak için)
        public void EnsureSeedData()
        {
            if (!_context.DoseRules.Any())
            {
                var firstDrug = _context.Drugs.FirstOrDefault();
                var secondDrug = _context.Drugs.Skip(1).FirstOrDefault();

                if (firstDrug != null)
                {
                    _context.DoseRules.Add(new DoseRule 
                    { 
                        DrugId = firstDrug.Id, 
                        MinAge = 0, 
                        MaxAge = 12, 
                        MaxDailyDoseMg = 200, 
                        Message = "Çocuklarda yüksek doz riski." 
                    });
                }

                if (firstDrug != null && secondDrug != null)
                {
                    _context.Contraindications.Add(new Contraindication
                    {
                        Drug1Id = firstDrug.Id,
                        Drug2Id = secondDrug.Id,
                        Severity = "High",
                        Message = "Birlikte kullanımda toksik etki riski."
                    });
                }
                _context.SaveChanges();
            }
        }
        
        public void SavePrescription(Prescription prescription, List<PrescriptionItem> items)
        {
            _context.Prescriptions.Add(prescription);
            _context.SaveChanges(); // Id oluşsun

            foreach (var item in items)
            {
                item.PrescriptionId = prescription.Id;
                _context.PrescriptionItems.Add(item);
            }
            _context.SaveChanges();
        }
    }
}

