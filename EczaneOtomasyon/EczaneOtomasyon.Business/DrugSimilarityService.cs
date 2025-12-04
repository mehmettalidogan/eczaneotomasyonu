using System;
using System.Collections.Generic;
using System.Linq;
using EczaneOtomasyon.DataAccess;

namespace EczaneOtomasyon.Business
{
    public class DrugRecommendation
    {
        public Drug Drug { get; set; } = null!;
        public int SimilarityScore { get; set; }
    }

    public static class DrugSimilarityService
    {
        public static List<DrugRecommendation> GetAlternatives(Drug selected, List<Drug> allDrugs)
        {
            var recommendations = new List<DrugRecommendation>();

            foreach (var drug in allDrugs)
            {
                // Kendi kendisiyle karşılaştırma
                if (drug.Id == selected.Id)
                    continue;

                int score = 0;

                // 1. Etken Madde (En önemli kriter) - Case-insensitive
                if (string.Equals(drug.ActiveSubstance, selected.ActiveSubstance, StringComparison.OrdinalIgnoreCase))
                {
                    score += 50;
                }

                // 2. Form (Tablet, Şurup vb.)
                if (string.Equals(drug.Form, selected.Form, StringComparison.OrdinalIgnoreCase))
                {
                    score += 20;
                }

                // 3. Dozaj farkı (Mutlak değer) - Sadece her iki ilaçta da doz bilgisi varsa
                if (drug.DosageMg.HasValue && selected.DosageMg.HasValue)
                {
                    if (Math.Abs(drug.DosageMg.Value - selected.DosageMg.Value) <= 100)
                    {
                        score += 10;
                    }
                }
                else if (!drug.DosageMg.HasValue && !selected.DosageMg.HasValue)
                {
                    // Her iki ilaçta da doz bilgisi yoksa (jel, krem vb.) aynı kategori sayılabilir
                    score += 5;
                }

                // 4. Kategori
                if (string.Equals(drug.Category, selected.Category, StringComparison.OrdinalIgnoreCase))
                {
                    score += 10;
                }

                // 5. Firma (Aynı firma olması bir tercih sebebi olabilir)
                if (string.Equals(drug.Company, selected.Company, StringComparison.OrdinalIgnoreCase))
                {
                    score += 5;
                }

                // 6. Fiyat Yakınlığı
                if (Math.Abs(drug.Price - selected.Price) <= 20)
                {
                    score += 5;
                }

                if (score > 0)
                {
                    recommendations.Add(new DrugRecommendation
                    {
                        Drug = drug,
                        SimilarityScore = score
                    });
                }
            }

            // Skora göre azalan sırala ve en iyi 10 taneyi al
            return recommendations.OrderByDescending(r => r.SimilarityScore)
                                  .Take(10)
                                  .ToList();
        }
    }
}

