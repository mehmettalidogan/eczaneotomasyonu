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
            if (_context.DoseRules.Any() && _context.Contraindications.Any())
            {
                return; // Zaten veri var
            }

            var allDrugs = _context.Drugs.ToList();
            if (allDrugs.Count < 2) return;

            // Yaygın ilaç etkileşimleri (Gerçek medikal bilgiye dayalı)
            var interactionsToAdd = new List<(string drug1Pattern, string drug2Pattern, string severity, string message)>
            {
                // Aspirin ve Warfarin etkileşimi
                ("aspirin", "warfarin", "High", "Kanama riski önemli ölçüde artar. Birlikte kullanımdan kaçınılmalıdır."),
                ("aspirin", "klopidogrel", "High", "Gastrointestinal kanama riski artar. Dikkatli kullanılmalıdır."),
                
                // NSAID'ler arası etkileşim
                ("ibuprofen", "diklofenak", "High", "İki NSAID birlikte kullanımı gastrointestinal yan etki riskini artırır."),
                ("naproksen", "ibuprofen", "High", "Aynı anda iki NSAID kullanımından kaçının."),
                
                // Antibiyotik etkileşimleri
                ("eritromisin", "simvastatin", "High", "Kas hasarı (rabdomiyoliz) riski artabilir."),
                ("klaritromisin", "warfarin", "Medium", "Antikoagülan etkisi artabilir, INR takibi önerilir."),
                
                // ACE inhibitörleri ve diüretikler
                ("enalapril", "spironolakton", "Medium", "Hiperkalemi riski. Potasyum seviyeleri takip edilmelidir."),
                ("kaptopril", "amilorid", "Medium", "Potasyum seviyesi yükselebilir."),
                
                // Parasetamol ve alkol
                ("parasetamol", "alkol", "High", "Karaciğer hasarı riski artar. Günlük 2000mg üzeri parasetamol dikkatli kullanılmalı."),
                
                // SSRI antidepresanlar
                ("fluoksetin", "tramadol", "High", "Serotonin sendromu riski. Birlikte kullanımdan kaçınılmalıdır."),
                ("sertralin", "aspirin", "Medium", "Kanama riski artabilir."),
                
                // Antidiyabetikler
                ("metformin", "kontrast madde", "High", "Laktik asidoz riski. Kontrast öncesi metformin kesilmelidir."),
                
                // Beta blokerler ve kalsiyum kanal blokerleri
                ("metoprolol", "verapamil", "High", "Ciddi bradikardi ve hipotansiyon riski."),
                ("atenolol", "diltiazem", "Medium", "Kalp hızı ve kan basıncı düşebilir."),
                
                // Genel uyarılar
                ("amoksisilin", "allopurinol", "Medium", "Cilt döküntüsü riski artar."),
                ("tetrasiklin", "demir", "Medium", "Tetrasiklinin emilimi azalır. Farklı zamanlarda alınmalıdır."),
                ("omeprazol", "klopidogrel", "Medium", "Klopidogrelin etkinliği azalabilir.")
            };

            foreach (var interaction in interactionsToAdd)
            {
                var drug1 = allDrugs.FirstOrDefault(d => 
                    d.Name.ToLower().Contains(interaction.drug1Pattern) || 
                    d.ActiveSubstance.ToLower().Contains(interaction.drug1Pattern));
                
                var drug2 = allDrugs.FirstOrDefault(d => 
                    d.Name.ToLower().Contains(interaction.drug2Pattern) || 
                    d.ActiveSubstance.ToLower().Contains(interaction.drug2Pattern));

                if (drug1 != null && drug2 != null && !_context.Contraindications.Any(c => 
                    (c.Drug1Id == drug1.Id && c.Drug2Id == drug2.Id) || 
                    (c.Drug1Id == drug2.Id && c.Drug2Id == drug1.Id)))
                {
                    _context.Contraindications.Add(new Contraindication
                    {
                        Drug1Id = drug1.Id,
                        Drug2Id = drug2.Id,
                        Severity = interaction.severity,
                        Message = interaction.message
                    });
                }
            }

            // Yaşa göre doz kuralları (Gerçek pediatrik/geriatrik dozlara dayalı)
            var doseRulesToAdd = new List<(string drugPattern, int minAge, int maxAge, int maxDose, string message)>
            {
                // Parasetamol (Ağrı kesici)
                ("parasetamol", 0, 1, 60, "Bebeklerde günlük maksimum doz: 60mg/kg"),
                ("parasetamol", 1, 6, 1000, "1-6 yaş çocuklarda günlük maksimum doz: 1000mg (60mg/kg)"),
                ("parasetamol", 6, 12, 2000, "6-12 yaş çocuklarda günlük maksimum doz: 2000mg"),
                ("parasetamol", 12, 18, 3000, "12-18 yaş ergenlerde günlük maksimum doz: 3000mg"),
                ("parasetamol", 18, 65, 4000, "Yetişkinlerde günlük maksimum doz: 4000mg"),
                ("parasetamol", 65, 120, 3000, "65 yaş üzeri hastalarda günlük maksimum doz: 3000mg (karaciğer fonksiyonu nedeniyle)"),

                // İbuprofen (NSAID)
                ("ibuprofen", 0, 6, 400, "6 ay-6 yaş arası çocuklarda günlük maksimum: 400mg (40mg/kg)"),
                ("ibuprofen", 6, 12, 600, "6-12 yaş çocuklarda günlük maksimum: 600mg"),
                ("ibuprofen", 12, 18, 1200, "12-18 yaş ergenlerde günlük maksimum: 1200mg"),
                ("ibuprofen", 18, 65, 2400, "Yetişkinlerde günlük maksimum: 2400mg"),
                ("ibuprofen", 65, 120, 1200, "Yaşlılarda düşük doz önerilir: 1200mg (GI yan etki riski)"),

                // Aspirin
                ("aspirin", 0, 16, 0, "16 yaş altında Reye sendromu riski nedeniyle ASPİRİN KULLANILMAMALIDIR!"),
                ("aspirin", 16, 65, 4000, "Yetişkinlerde günlük maksimum doz: 4000mg"),
                ("aspirin", 65, 120, 2000, "Yaşlılarda kanama riski nedeniyle düşük doz: 2000mg"),

                // Amoksisilin (Antibiyotik)
                ("amoksisilin", 0, 3, 30, "Bebeklerde günlük maksimum: 30mg/kg"),
                ("amoksisilin", 3, 12, 1500, "Çocuklarda günlük maksimum: 1500mg (40mg/kg)"),
                ("amoksisilin", 12, 65, 3000, "Yetişkinlerde günlük maksimum: 3000mg"),
                ("amoksisilin", 65, 120, 2000, "Yaşlılarda böbrek fonksiyonuna göre: 2000mg"),

                // Metformin (Antidiyabetik)
                ("metformin", 0, 10, 0, "10 yaş altında kullanılmamalıdır."),
                ("metformin", 10, 18, 2000, "Çocuklarda maksimum: 2000mg"),
                ("metformin", 18, 65, 2550, "Yetişkinlerde maksimum: 2550mg"),
                ("metformin", 65, 80, 2000, "Yaşlılarda böbrek fonksiyonu kontrolü ile: 2000mg"),
                ("metformin", 80, 120, 1000, "80 yaş üzeri hastalarda dikkatli kullanım: 1000mg"),

                // Omeprazol (Proton pompası inhibitörü)
                ("omeprazol", 0, 1, 0, "1 yaş altında önerilmez."),
                ("omeprazol", 1, 12, 20, "Çocuklarda günlük maksimum: 20mg"),
                ("omeprazol", 12, 120, 40, "Yetişkin ve yaşlılarda günlük maksimum: 40mg"),

                // Enalapril (ACE inhibitörü)
                ("enalapril", 0, 18, 0, "18 yaş altında kullanımı önerilmez."),
                ("enalapril", 18, 65, 40, "Yetişkinlerde günlük maksimum: 40mg"),
                ("enalapril", 65, 120, 20, "Yaşlılarda başlangıç dozu düşük tutulmalı: 20mg"),

                // Simvastatin (Statin)
                ("simvastatin", 0, 18, 0, "18 yaş altında kullanımı önerilmez."),
                ("simvastatin", 18, 65, 80, "Yetişkinlerde günlük maksimum: 80mg (yüksek doz myopati riski)"),
                ("simvastatin", 65, 120, 40, "Yaşlılarda maksimum önerilen doz: 40mg")
            };

            foreach (var rule in doseRulesToAdd)
            {
                var drug = allDrugs.FirstOrDefault(d => 
                    d.Name.ToLower().Contains(rule.drugPattern) || 
                    d.ActiveSubstance.ToLower().Contains(rule.drugPattern));

                if (drug != null && !_context.DoseRules.Any(dr => 
                    dr.DrugId == drug.Id && dr.MinAge == rule.minAge && dr.MaxAge == rule.maxAge))
                {
                    _context.DoseRules.Add(new DoseRule
                    {
                        DrugId = drug.Id,
                        MinAge = rule.minAge,
                        MaxAge = rule.maxAge,
                        MaxDailyDoseMg = rule.maxDose,
                        Message = rule.message
                    });
                }
            }

            _context.SaveChanges();
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

        public List<Prescription> GetAllPrescriptions()
        {
            return _context.Prescriptions.OrderByDescending(p => p.Date).ToList();
        }

        public List<PrescriptionItem> GetPrescriptionItems(int prescriptionId)
        {
            return _context.PrescriptionItems.Where(pi => pi.PrescriptionId == prescriptionId).ToList();
        }

        public Prescription? GetPrescriptionById(int id)
        {
            return _context.Prescriptions.FirstOrDefault(p => p.Id == id);
        }
    }
}

