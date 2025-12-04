-- AI Reçete Kontrol Kuralları - Gerçek İlaçlarla
USE EczaneOtomasyonDb;
GO

-- Önce mevcut kuralları temizle
DELETE FROM Contraindications;
DELETE FROM DoseRules;
GO

-- ASPIRIN + WARFARIN ETKİLEŞİMLERİ (Tüm kombinasyonlar)
-- Coraspin (60) + Warfarin'ler
INSERT INTO Contraindications (Drug1Id, Drug2Id, Severity, Message) VALUES
(60, 201, 'High', N'Kanama riski önemli ölçüde artar. Birlikte kullanımdan kaçınılmalıdır.'),
(60, 202, 'High', N'Kanama riski önemli ölçüde artar. Birlikte kullanımdan kaçınılmalıdır.'),
(60, 203, 'High', N'Kanama riski önemli ölçüde artar. Birlikte kullanımdan kaçınılmalıdır.'),
(60, 204, 'High', N'Kanama riski önemli ölçüde artar. Birlikte kullanımdan kaçınılmalıdır.');

-- Diğer Aspirin'ler + Warfarin'ler
INSERT INTO Contraindications (Drug1Id, Drug2Id, Severity, Message)
SELECT a.Id, w.Id, 'High', N'Kanama riski önemli ölçüde artar. Birlikte kullanımdan kaçınılmalıdır.'
FROM Drugs a
CROSS JOIN Drugs w
WHERE a.ActiveSubstance = N'Asetilsalisilik Asit' 
  AND w.ActiveSubstance = N'Warfarin'
  AND NOT EXISTS (
    SELECT 1 FROM Contraindications c 
    WHERE (c.Drug1Id = a.Id AND c.Drug2Id = w.Id) 
       OR (c.Drug1Id = w.Id AND c.Drug2Id = a.Id)
  );

-- ASPIRIN + KLOPIDOGREL
INSERT INTO Contraindications (Drug1Id, Drug2Id, Severity, Message)
SELECT a.Id, k.Id, 'High', N'Gastrointestinal kanama riski artar. Dikkatli kullanılmalıdır.'
FROM Drugs a
CROSS JOIN Drugs k
WHERE a.ActiveSubstance = N'Asetilsalisilik Asit' 
  AND k.ActiveSubstance = N'Klopidogrel';

-- İBUPROFEN + DİKLOFENAK (İki NSAID)
INSERT INTO Contraindications (Drug1Id, Drug2Id, Severity, Message)
SELECT i.Id, d.Id, 'High', N'İki NSAID birlikte kullanımı gastrointestinal yan etki riskini artırır.'
FROM Drugs i
CROSS JOIN Drugs d
WHERE i.ActiveSubstance = N'Ibuprofen' 
  AND d.ActiveSubstance IN (N'Diklofenak', N'Diklofenak Potasyum');

-- METOPROLOL + VERAPAMIL
INSERT INTO Contraindications (Drug1Id, Drug2Id, Severity, Message)
SELECT m.Id, v.Id, 'High', N'Ciddi bradikardi ve hipotansiyon riski. Birlikte kullanımdan kaçınılmalıdır.'
FROM Drugs m
CROSS JOIN Drugs v
WHERE m.ActiveSubstance = N'Metoprolol' 
  AND v.ActiveSubstance = N'Verapamil';

-- FLUOKSETİN + TRAMADOL
INSERT INTO Contraindications (Drug1Id, Drug2Id, Severity, Message)
SELECT f.Id, t.Id, 'High', N'Serotonin sendromu riski. Birlikte kullanımdan kaçınılmalıdır.'
FROM Drugs f
CROSS JOIN Drugs t
WHERE f.ActiveSubstance = N'Fluoksetin' 
  AND t.ActiveSubstance = N'Tramadol';

-- SERTRALİN + ASPIRIN
INSERT INTO Contraindications (Drug1Id, Drug2Id, Severity, Message)
SELECT s.Id, a.Id, 'Medium', N'Kanama riski artabilir.'
FROM Drugs s
CROSS JOIN Drugs a
WHERE s.ActiveSubstance = N'Sertralin' 
  AND a.ActiveSubstance = N'Asetilsalisilik Asit';

-- ERİTROMİSİN + SİMVASTATİN
INSERT INTO Contraindications (Drug1Id, Drug2Id, Severity, Message)
SELECT e.Id, s.Id, 'High', N'Kas hasarı (rabdomiyoliz) riski artabilir.'
FROM Drugs e
CROSS JOIN Drugs s
WHERE e.ActiveSubstance = N'Eritromisin' 
  AND s.ActiveSubstance = N'Simvastatin';

-- ENALAPRİL + SPİRONOLAKTON
INSERT INTO Contraindications (Drug1Id, Drug2Id, Severity, Message)
SELECT e.Id, s.Id, 'Medium', N'Hiperkalemi riski. Potasyum seviyeleri takip edilmelidir.'
FROM Drugs e
CROSS JOIN Drugs s
WHERE e.ActiveSubstance = N'Enalapril' 
  AND s.ActiveSubstance = N'Spironolakton';

-- OMEPRAZOL + KLOPİDOGREL
INSERT INTO Contraindications (Drug1Id, Drug2Id, Severity, Message)
SELECT o.Id, k.Id, 'Medium', N'Klopidogrelin etkinliği azalabilir.'
FROM Drugs o
CROSS JOIN Drugs k
WHERE o.ActiveSubstance = N'Omeprazol' 
  AND k.ActiveSubstance = N'Klopidogrel';

-- DOZ KURALLARI

-- PARASETAMOL doz kuralları (tüm parasetamol ilaçlar için)
INSERT INTO DoseRules (DrugId, MinAge, MaxAge, MaxDailyDoseMg, Message)
SELECT Id, 0, 1, 60, N'Bebeklerde günlük maksimum doz: 60mg/kg'
FROM Drugs WHERE ActiveSubstance = N'Parasetamol';

INSERT INTO DoseRules (DrugId, MinAge, MaxAge, MaxDailyDoseMg, Message)
SELECT Id, 1, 6, 1000, N'1-6 yaş çocuklarda günlük maksimum doz: 1000mg (60mg/kg)'
FROM Drugs WHERE ActiveSubstance = N'Parasetamol';

INSERT INTO DoseRules (DrugId, MinAge, MaxAge, MaxDailyDoseMg, Message)
SELECT Id, 6, 12, 2000, N'6-12 yaş çocuklarda günlük maksimum doz: 2000mg'
FROM Drugs WHERE ActiveSubstance = N'Parasetamol';

INSERT INTO DoseRules (DrugId, MinAge, MaxAge, MaxDailyDoseMg, Message)
SELECT Id, 12, 18, 3000, N'12-18 yaş ergenlerde günlük maksimum doz: 3000mg'
FROM Drugs WHERE ActiveSubstance = N'Parasetamol';

INSERT INTO DoseRules (DrugId, MinAge, MaxAge, MaxDailyDoseMg, Message)
SELECT Id, 18, 65, 4000, N'Yetişkinlerde günlük maksimum doz: 4000mg'
FROM Drugs WHERE ActiveSubstance = N'Parasetamol';

INSERT INTO DoseRules (DrugId, MinAge, MaxAge, MaxDailyDoseMg, Message)
SELECT Id, 65, 120, 3000, N'65 yaş üzeri hastalarda günlük maksimum doz: 3000mg (karaciğer fonksiyonu nedeniyle)'
FROM Drugs WHERE ActiveSubstance = N'Parasetamol';

-- İBUPROFEN doz kuralları
INSERT INTO DoseRules (DrugId, MinAge, MaxAge, MaxDailyDoseMg, Message)
SELECT Id, 0, 6, 400, N'6 ay-6 yaş arası çocuklarda günlük maksimum: 400mg (40mg/kg)'
FROM Drugs WHERE ActiveSubstance = N'Ibuprofen';

INSERT INTO DoseRules (DrugId, MinAge, MaxAge, MaxDailyDoseMg, Message)
SELECT Id, 6, 12, 600, N'6-12 yaş çocuklarda günlük maksimum: 600mg'
FROM Drugs WHERE ActiveSubstance = N'Ibuprofen';

INSERT INTO DoseRules (DrugId, MinAge, MaxAge, MaxDailyDoseMg, Message)
SELECT Id, 12, 18, 1200, N'12-18 yaş ergenlerde günlük maksimum: 1200mg'
FROM Drugs WHERE ActiveSubstance = N'Ibuprofen';

INSERT INTO DoseRules (DrugId, MinAge, MaxAge, MaxDailyDoseMg, Message)
SELECT Id, 18, 65, 2400, N'Yetişkinlerde günlük maksimum: 2400mg'
FROM Drugs WHERE ActiveSubstance = N'Ibuprofen';

INSERT INTO DoseRules (DrugId, MinAge, MaxAge, MaxDailyDoseMg, Message)
SELECT Id, 65, 120, 1200, N'Yaşlılarda düşük doz önerilir: 1200mg (GI yan etki riski)'
FROM Drugs WHERE ActiveSubstance = N'Ibuprofen';

-- ASPİRİN yaş kısıtlaması (16 yaş altı YASAK!)
INSERT INTO DoseRules (DrugId, MinAge, MaxAge, MaxDailyDoseMg, Message)
SELECT Id, 0, 16, 0, N'16 yaş altında Reye sendromu riski nedeniyle ASPİRİN KULLANILMAMALIDIR!'
FROM Drugs WHERE ActiveSubstance = N'Asetilsalisilik Asit';

INSERT INTO DoseRules (DrugId, MinAge, MaxAge, MaxDailyDoseMg, Message)
SELECT Id, 16, 65, 4000, N'Yetişkinlerde günlük maksimum doz: 4000mg'
FROM Drugs WHERE ActiveSubstance = N'Asetilsalisilik Asit';

INSERT INTO DoseRules (DrugId, MinAge, MaxAge, MaxDailyDoseMg, Message)
SELECT Id, 65, 120, 2000, N'Yaşlılarda kanama riski nedeniyle düşük doz: 2000mg'
FROM Drugs WHERE ActiveSubstance = N'Asetilsalisilik Asit';

-- METFORMİN doz kuralları (yaşlılarda önemli)
INSERT INTO DoseRules (DrugId, MinAge, MaxAge, MaxDailyDoseMg, Message)
SELECT Id, 0, 10, 0, N'10 yaş altında kullanılmamalıdır.'
FROM Drugs WHERE ActiveSubstance = N'Metformin';

INSERT INTO DoseRules (DrugId, MinAge, MaxAge, MaxDailyDoseMg, Message)
SELECT Id, 10, 18, 2000, N'Çocuklarda maksimum: 2000mg'
FROM Drugs WHERE ActiveSubstance = N'Metformin';

INSERT INTO DoseRules (DrugId, MinAge, MaxAge, MaxDailyDoseMg, Message)
SELECT Id, 18, 65, 2550, N'Yetişkinlerde maksimum: 2550mg'
FROM Drugs WHERE ActiveSubstance = N'Metformin';

INSERT INTO DoseRules (DrugId, MinAge, MaxAge, MaxDailyDoseMg, Message)
SELECT Id, 65, 80, 2000, N'Yaşlılarda böbrek fonksiyonu kontrolü ile: 2000mg'
FROM Drugs WHERE ActiveSubstance = N'Metformin';

INSERT INTO DoseRules (DrugId, MinAge, MaxAge, MaxDailyDoseMg, Message)
SELECT Id, 80, 120, 1000, N'80 yaş üzeri hastalarda dikkatli kullanım: 1000mg'
FROM Drugs WHERE ActiveSubstance = N'Metformin';

SELECT 'AI Kurallari basariyla yuklendi!' as Durum;
SELECT COUNT(*) as EtkilesimKurallari FROM Contraindications;
SELECT COUNT(*) as DozKurallari FROM DoseRules;
GO

