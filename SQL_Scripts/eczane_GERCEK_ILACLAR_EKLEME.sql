-- Gerçek Türkiye İlaçları - Ek Liste (Test için kritik ilaçlar dahil)
-- Bu ilaçlar AI reçete kontrol sistemi için özel seçilmiştir

INSERT INTO Drugs (Name, ActiveSubstance, Form, DosageMg, Company, Category, Price)
VALUES
-- WARFARIN ve ANTİKOAGÜLANLAR (Test için çok önemli!)
(N'Coumadin', N'Warfarin', N'Tablet', 5, N'Bristol-Myers Squibb', N'Antikoagülan', 35.00),
(N'Orfarin', N'Warfarin', N'Tablet', 5, N'Orion Pharma', N'Antikoagülan', 32.00),
(N'Warfin', N'Warfarin', N'Tablet', 2, N'Abdi İbrahim', N'Antikoagülan', 28.00),
(N'Marevan', N'Warfarin', N'Tablet', 5, N'Zentiva', N'Antikoagülan', 30.00),
(N'Plavix', N'Klopidogrel', N'Tablet', 75, N'Sanofi', N'Antikoagülan', 95.00),
(N'Zyllt', N'Klopidogrel', N'Tablet', 75, N'Abdi İbrahim', N'Antikoagülan', 85.00),
(N'Clopivas', N'Klopidogrel', N'Tablet', 75, N'Deva', N'Antikoagülan', 80.00),
(N'Clexane', N'Enoksaparin', N'Enjeksiyon', 60, N'Sanofi', N'Antikoagülan', 180.00),
(N'Fraxiparine', N'Nadroparin', N'Enjeksiyon', 2850, N'Aspen', N'Antikoagülan', 175.00),
(N'Pradaxa', N'Dabigatran', N'Kapsül', 110, N'Boehringer', N'Antikoagülan', 250.00),

-- ASPİRİN çeşitleri (Çocuklarda yasaklı - test için önemli!)
(N'Aspirin', N'Asetilsalisilik Asit', N'Tablet', 500, N'Bayer', N'Ağrı Kesici', 20.00),
(N'Aspirin Cardio', N'Asetilsalisilik Asit', N'Tablet', 100, N'Bayer', N'Kardiyoloji', 22.00),
(N'Aspirin Protect', N'Asetilsalisilik Asit', N'Tablet', 100, N'Bayer', N'Kardiyoloji', 24.00),
(N'Ecopirin', N'Asetilsalisilik Asit', N'Tablet', 100, N'Deva', N'Kardiyoloji', 18.00),
(N'Miraspin', N'Asetilsalisilik Asit', N'Tablet', 100, N'Abdi İbrahim', N'Kardiyoloji', 19.00),
(N'Asawin', N'Asetilsalisilik Asit', N'Tablet', 100, N'Sandoz', N'Kardiyoloji', 17.00),

-- BETA BLOKERLER (Etkileşim testleri için)
(N'Beloc', N'Metoprolol', N'Tablet', 100, N'AstraZeneca', N'Kardiyoloji', 60.00),
(N'Corvitol', N'Metoprolol', N'Tablet', 50, N'Berlin-Chemie', N'Kardiyoloji', 52.00),
(N'Metocard', N'Metoprolol', N'Tablet', 50, N'Deva', N'Kardiyoloji', 48.00),
(N'Concor', N'Bisoprolol', N'Tablet', 5, N'Merck', N'Kardiyoloji', 70.00),
(N'Bisocard', N'Bisoprolol', N'Tablet', 5, N'Deva', N'Kardiyoloji', 62.00),
(N'Tenormin', N'Atenolol', N'Tablet', 50, N'AstraZeneca', N'Kardiyoloji', 55.00),
(N'Atenol', N'Atenolol', N'Tablet', 50, N'Abdi İbrahim', N'Kardiyoloji', 48.00),
(N'Carvedilol', N'Karvedilol', N'Tablet', 25, N'Roche', N'Kardiyoloji', 85.00),

-- KALSİYUM KANAL BLOKERLERİ (Beta bloker etkileşimi için)
(N'Isoptin', N'Verapamil', N'Tablet', 80, N'Abbott', N'Kardiyoloji', 65.00),
(N'Veramex', N'Verapamil', N'Tablet', 80, N'Deva', N'Kardiyoloji', 58.00),
(N'Diltiazem', N'Diltiazem', N'Tablet', 60, N'Sanofi', N'Kardiyoloji', 62.00),
(N'Tilazem', N'Diltiazem', N'Tablet', 60, N'Abdi İbrahim', N'Kardiyoloji', 55.00),
(N'Adalat', N'Nifedipin', N'Tablet', 10, N'Bayer', N'Kardiyoloji', 68.00),
(N'Amipin', N'Amlodipin', N'Tablet', 5, N'Sandoz', N'Kardiyoloji', 48.00),
(N'Amlocard', N'Amlodipin', N'Tablet', 10, N'Deva', N'Kardiyoloji', 52.00),

-- ACE İNHİBİTÖRLERİ (Hiperkalemi riski testleri için)
(N'Renitec', N'Enalapril', N'Tablet', 5, N'Merck', N'Kardiyoloji', 58.00),
(N'Envas', N'Enalapril', N'Tablet', 10, N'Abdi İbrahim', N'Kardiyoloji', 52.00),
(N'Enalapril', N'Enalapril', N'Tablet', 5, N'Deva', N'Kardiyoloji', 45.00),
(N'Accupro', N'Quinapril', N'Tablet', 10, N'Pfizer', N'Kardiyoloji', 72.00),
(N'Capoten', N'Kaptopril', N'Tablet', 25, N'Bristol-Myers', N'Kardiyoloji', 42.00),
(N'Kaptopril', N'Kaptopril', N'Tablet', 25, N'Abdi İbrahim', N'Kardiyoloji', 35.00),
(N'Lisinopril', N'Lisinopril', N'Tablet', 10, N'Sandoz', N'Kardiyoloji', 48.00),
(N'Perindopril', N'Perindopril', N'Tablet', 5, N'Servier', N'Kardiyoloji', 65.00),

-- DİÜRETİKLER (ACE inhibitörü etkileşimi için)
(N'Aldactone 25', N'Spironolakton', N'Tablet', 25, N'Pfizer', N'Kardiyoloji', 55.00),
(N'Spirix', N'Spironolakton', N'Tablet', 50, N'Deva', N'Kardiyoloji', 62.00),
(N'Amilorid', N'Amilorid', N'Tablet', 5, N'Sandoz', N'Kardiyoloji', 38.00),
(N'Moduretic', N'Amilorid + Hidroklorotiazid', N'Tablet', NULL, N'Merck', N'Kardiyoloji', 52.00),
(N'Furosemid', N'Furosemid', N'Tablet', 40, N'Sanofi', N'Kardiyoloji', 28.00),
(N'Diuril', N'Hidroklorotiazid', N'Tablet', 25, N'Abdi İbrahim', N'Kardiyoloji', 32.00),

-- STATİNLER (Eritromisin etkileşimi için)
(N'Simvastatin', N'Simvastatin', N'Tablet', 20, N'Sandoz', N'Kolesterol', 85.00),
(N'Zocor', N'Simvastatin', N'Tablet', 40, N'Merck', N'Kolesterol', 98.00),
(N'Simvor', N'Simvastatin', N'Tablet', 20, N'Abdi İbrahim', N'Kolesterol', 75.00),
(N'Atoris', N'Atorvastatin', N'Tablet', 10, N'Krka', N'Kolesterol', 85.00),
(N'Lipistat', N'Pravastatin', N'Tablet', 20, N'Bristol-Myers', N'Kolesterol', 92.00),
(N'Lescol', N'Fluvastatin', N'Kapsül', 40, N'Novartis', N'Kolesterol', 105.00),

-- ANTİBİYOTİKLER - ERİTROMİSİN (Statin etkileşimi için)
(N'Eritromisin', N'Eritromisin', N'Tablet', 500, N'Abdi İbrahim', N'Antibiyotik', 68.00),
(N'Erythrocin', N'Eritromisin', N'Tablet', 500, N'Abbott', N'Antibiyotik', 75.00),
(N'Eromycin', N'Eritromisin', N'Süspansiyon', 250, N'Deva', N'Antibiyotik', 65.00),
(N'Clarithromycin', N'Klaritromisin', N'Tablet', 250, N'Sandoz', N'Antibiyotik', 78.00),

-- SSRI ANTİDEPRESANLAR (Serotonin sendromu riski için)
(N'Prozac', N'Fluoksetin', N'Kapsül', 20, N'Eli Lilly', N'Psikiyatri', 125.00),
(N'Depreks', N'Fluoksetin', N'Tablet', 20, N'Abdi İbrahim', N'Psikiyatri', 110.00),
(N'Fluoksetin', N'Fluoksetin', N'Tablet', 20, N'Deva', N'Psikiyatri', 95.00),
(N'Zoloft', N'Sertralin', N'Tablet', 50, N'Pfizer', N'Psikiyatri', 130.00),
(N'Serlift', N'Sertralin', N'Tablet', 50, N'Abdi İbrahim', N'Psikiyatri', 105.00),
(N'Citalopram', N'Sitalopram', N'Tablet', 20, N'Sandoz', N'Psikiyatri', 88.00),
(N'Paroxetine', N'Paroksetin', N'Tablet', 20, N'Sandoz', N'Psikiyatri', 95.00),

-- TRAMADOL (SSRI etkileşimi için)
(N'Tradonal', N'Tramadol', N'Kapsül', 50, N'Pfizer', N'Ağrı Kesici', 88.00),
(N'Tramadol', N'Tramadol', N'Tablet', 50, N'Sandoz', N'Ağrı Kesici', 72.00),
(N'Contramal SR', N'Tramadol', N'Tablet', 100, N'Abdi İbrahim', N'Ağrı Kesici', 92.00),
(N'Contramal Retard', N'Tramadol', N'Tablet', 100, N'İbrahim Etem', N'Ağrı Kesici', 95.00),

-- METFORMİN (Yaşlı hastaların için önemli)
(N'Glucofen', N'Metformin', N'Tablet', 850, N'Deva', N'Diyabet', 30.00),
(N'Diaformin', N'Metformin', N'Tablet', 1000, N'Sandoz', N'Diyabet', 35.00),
(N'Metfogamma', N'Metformin', N'Tablet', 850, N'Wörwag', N'Diyabet', 32.00),
(N'Metformin HCL', N'Metformin', N'Tablet', 500, N'Abdi İbrahim', N'Diyabet', 28.00),

-- ÇOCUK İLAÇLARI (Doz kontrolü için önemli)
(N'Parol Çocuk', N'Parasetamol', N'Şurup', 120, N'Atabay', N'Ağrı Kesici', 22.00),
(N'Calpol 6 Plus', N'Parasetamol', N'Süspansiyon', 250, N'GSK', N'Ağrı Kesici', 28.00),
(N'Aferin Çocuk', N'Ibuprofen', N'Süspansiyon', 100, N'Abdi İbrahim', N'Ağrı Kesici', 32.00),
(N'Nurofen Çocuk', N'Ibuprofen', N'Süspansiyon', 100, N'Reckitt', N'Ağrı Kesici', 38.00),
(N'Augmentin Çocuk', N'Amoksisilin + Klavulanik Asit', N'Süspansiyon', 400, N'GSK', N'Antibiyotik', 68.00),
(N'Cefadroxil Süspansiyon', N'Sefadroksil', N'Süspansiyon', 250, N'Sandoz', N'Antibiyotik', 55.00),

-- ANTİDİYABETİKLER (Çeşitli)
(N'Amaryl', N'Glimepirid', N'Tablet', 2, N'Sanofi', N'Diyabet', 52.00),
(N'Glidiabet', N'Gliklazid', N'Tablet', 30, N'Deva', N'Diyabet', 38.00),
(N'Glucotrol', N'Glipizid', N'Tablet', 5, N'Pfizer', N'Diyabet', 45.00),
(N'Januvia', N'Sitagliptin', N'Tablet', 100, N'MSD', N'Diyabet', 185.00),
(N'Galvus', N'Vildagliptin', N'Tablet', 50, N'Novartis', N'Diyabet', 175.00),
(N'Forxiga', N'Dapagliflozin', N'Tablet', 10, N'AstraZeneca', N'Diyabet', 220.00),

-- PROTON POMPA İNHİBİTÖRLERİ (Klopidogrel etkileşimi için)
(N'Nexium 40', N'Esomeprazol', N'Kapsül', 40, N'AstraZeneca', N'Mide İlacı', 98.00),
(N'Nexium 20', N'Esomeprazol', N'Kapsül', 20, N'AstraZeneca', N'Mide İlacı', 72.00),
(N'Omeprazol', N'Omeprazol', N'Kapsül', 20, N'Sandoz', N'Mide İlacı', 38.00),
(N'Losec Mups', N'Omeprazol', N'Tablet', 20, N'AstraZeneca', N'Mide İlacı', 55.00),
(N'Controloc', N'Pantoprazol', N'Tablet', 40, N'Takeda', N'Mide İlacı', 48.00),
(N'Pantopan', N'Pantoprazol', N'Tablet', 20, N'Deva', N'Mide İlacı', 35.00),
(N'Rabeprazol', N'Rabeprazol', N'Tablet', 20, N'Janssen', N'Mide İlacı', 62.00),

-- DİĞER ÖNEMLİ İLAÇLAR
(N'Allopurinol', N'Allopurinol', N'Tablet', 300, N'Sandoz', N'Gut İlacı', 42.00),
(N'Zyloric', N'Allopurinol', N'Tablet', 300, N'GSK', N'Gut İlacı', 55.00),
(N'Colchicine', N'Kolşisin', N'Tablet', 1, N'Abdi İbrahim', N'Gut İlacı', 38.00),
(N'Demir', N'Demir Sülfat', N'Tablet', 80, N'Sandoz', N'Takviye', 35.00),
(N'Ferro Sanol', N'Demir', N'Kapsül', 100, N'UCB', N'Takviye', 52.00),
(N'Tardyferon', N'Demir Sülfat', N'Tablet', 80, N'Pierre Fabre', N'Takviye', 48.00),

-- TETRASİKLİN (Demir etkileşimi için)
(N'Tetralysal', N'Limesiklin', N'Kapsül', 300, N'Galderma', N'Antibiyotik', 95.00),
(N'Doxycycline', N'Doksisiklin', N'Kapsül', 100, N'Sandoz', N'Antibiyotik', 68.00),
(N'Doksil', N'Doksisiklin', N'Tablet', 100, N'Abdi İbrahim', N'Antibiyotik', 72.00),
(N'Minosin', N'Minosiklin', N'Kapsül', 100, N'Deva', N'Antibiyotik', 88.00),

-- KONTRAST MADDE (Metformin etkileşimi için bilgi amaçlı)
(N'Omnipaque', N'İyoheksol', N'Enjeksiyon', 300, N'GE Healthcare', N'Radyoloji', 450.00),
(N'Ultravist', N'İyopromidum', N'Enjeksiyon', 300, N'Bayer', N'Radyoloji', 420.00),

-- HORMON İLAÇLARI
(N'Synthroid', N'Levotiroksin', N'Tablet', 100, N'Abbott', N'Endokrinoloji', 58.00),
(N'Levotiron 25', N'Levotiroksin', N'Tablet', 25, N'Abdi İbrahim', N'Endokrinoloji', 32.00),
(N'Levotiron 75', N'Levotiroksin', N'Tablet', 75, N'Abdi İbrahim', N'Endokrinoloji', 48.00),
(N'Prednol', N'Prednizolon', N'Tablet', 5, N'Deva', N'Kortikosteroid', 28.00),
(N'Deltacortril', N'Prednizolon', N'Tablet', 5, N'Alliance', N'Kortikosteroid', 32.00),

-- EK NSAID'LER
(N'Indocid', N'İndometasin', N'Kapsül', 25, N'MSD', N'Ağrı Kesici', 45.00),
(N'Celebrex', N'Celecoxib', N'Kapsül', 200, N'Pfizer', N'Ağrı Kesici', 95.00),
(N'Arcoxia', N'Etorikoksib', N'Tablet', 90, N'MSD', N'Ağrı Kesici', 110.00),
(N'Naprosyn', N'Naproksen', N'Tablet', 500, N'Roche', N'Ağrı Kesici', 52.00),
(N'Ketoprofen', N'Ketoprofen', N'Kapsül', 100, N'Sandoz', N'Ağrı Kesici', 48.00),
(N'Meloxicam', N'Meloksikam', N'Tablet', 15, N'Sandoz', N'Ağrı Kesici', 42.00),
(N'Mobic', N'Meloksikam', N'Tablet', 15, N'Boehringer', N'Ağrı Kesici', 58.00),

-- ANTİHİSTAMİNİKLER
(N'Allergodil', N'Azelastin', N'Göz Damlası', NULL, N'Meda', N'Alerji İlacı', 65.00),
(N'Clarinase', N'Loratadin + Pseudoefedrin', N'Tablet', NULL, N'Bayer', N'Alerji İlacı', 42.00),
(N'Telfast', N'Feksofenadin', N'Tablet', 120, N'Sanofi', N'Alerji İlacı', 58.00),
(N'Allegra', N'Feksofenadin', N'Tablet', 180, N'Sanofi', N'Alerji İlacı', 65.00),

-- TİROİD İLAÇLARI
(N'Propylthiouracil', N'Propiltiyourasil', N'Tablet', 50, N'Abdi İbrahim', N'Endokrinoloji', 38.00),
(N'Tapazole', N'Tiamazol', N'Tablet', 5, N'Merck', N'Endokrinoloji', 42.00),

-- AĞRI KESİCİLER (EK)
(N'Novalgin', N'Metamizol', N'Ampul', 500, N'Sanofi', N'Ağrı Kesici', 35.00),
(N'Minoset Fort', N'Metamizol', N'Ampul', 500, N'Bilim', N'Ağrı Kesici', 32.00),
(N'Algocalmin', N'Metamizol', N'Tablet', 500, N'Sandoz', N'Ağrı Kesici', 28.00);

