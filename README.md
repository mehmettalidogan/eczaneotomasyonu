# Eczane Otomasyon Sistemi

## Proje Hakkinda

Eczane Otomasyon Sistemi, eczane isletmelerinin ilac stoklarini yonetmek, recete islemlerini takip etmek ve ilac etkilesimlerini kontrol etmek icin gelistirilmis kapsamli bir masaustu uygulamasidir. Sistem, SOLID prensiplerine uygun olarak tasarlanmis, n-katmanli mimari yaklasimi benimsemis ve modern yazilim gelistirme pratiklerini uygulamistir.

## Temel Ozellikler

### 1. Ilac Yonetimi
- Ilac ekleme, guncelleme ve silme operasyonlari
- Etkin madde, barkod ve fiyat bilgileri yonetimi
- Ilac arama ve filtreleme sistemi
- Benzer ilac onerileri

### 2. Recete Yonetimi
- Elektronik recete kayit sistemi
- Hasta bilgileri yonetimi (TC kimlik, yas, ad-soyad)
- Recete maddeleri tanimlama
- Satilan ve bekleyen recete takibi
- Recete satis islemleri ve fis yazdirma

### 3. Ilac Etkilesimi Kontrol Sistemi
- Veritabani tabanli ilac etkilesim kontrolu
- Coklu ilac kombinasyonlarinin analizi
- Uc seviyeli oncelik sistemi (Dusuk, Orta, Yuksek)
- Gercek tibbi bilgilere dayali etkilesim kurallari

### 4. Doz Kontrol Sistemi
- Yasa gore otomatik doz dogrulama
- Pediatrik, eriskin ve geriatrik hasta gruplari icin ozel kurallar
- Maksimum gunluk doz asimi uyarilari
- Guvenligi artiran onleyici kontroller

### 5. Stok Yonetimi
- Gercek zamanli stok takibi
- Dusuk stok uyari sistemi
- Toplu stok guncelleme araclari
- Stok sorgulama ve raporlama

### 6. Barkod Sistemi
- Ilac barkod yonetimi
- Hizli urun arama ve tanimlama
- Otomatik barkod uretimi

## Sistem Mimarisi

Proje, katmanlara ayrilmis (layered architecture) mimari yaklasimini benimsemistir:

### Katmanlar

#### 1. Sunum Katmani (EczaneOtomasyon.UI)
- WinForms tabanli kullanici arayuzu
- DevExpress UI kutuphanesi entegrasyonu
- Dependency Injection ile gevsel baglantili form yapisi
- Responsive ve kullanici dostu tasarim

#### 2. Is Mantigi Katmani (EczaneOtomasyon.Business)
- Is kurallarinin uygulandigi merkezi katman
- Servis tabanli mimari (Service-based Architecture)
- Validator pattern ile veri dogrulama
- Result pattern ile hata yonetimi

Temel Servisler:
- `DrugService`: Ilac yonetim servisi
- `PrescriptionService`: Recete yonetim servisi
- `StockService`: Stok yonetim servisi
- `PrescriptionChecker`: Ilac etkilesimi ve doz kontrol servisi
- `BarcodeService`: Barkod islemleri servisi
- `ReceiptPrinter`: Fis yazdirma servisi

#### 3. Veri Erisim Katmani (EczaneOtomasyon.DataAccess)
- Entity Framework Core ile ORM implementasyonu
- Repository pattern uygulamasi
- Veritabani bagimliligini soyutlama
- Migration destegi

### Varlik Modeli (Entity Model)

```
Drug (Ilac)
├── Id
├── Name
├── ActiveSubstance
├── Barcode
├── Price
├── Stock
└── Manufacturer

Prescription (Recete)
├── Id
├── PrescriptionNumber
├── PatientName, PatientSurname
├── PatientTC
├── PatientAge
├── Date
├── IsSold
├── SaleDate
├── TotalAmount
└── SaleStatus

PrescriptionItem (Recete Maddesi)
├── Id
├── PrescriptionId (FK)
├── DrugId (FK)
└── DailyDoseMg

Contraindication (Ilac Etkilesimi)
├── Id
├── Drug1Id (FK)
├── Drug2Id (FK)
├── Severity
└── Message

DoseRule (Doz Kurali)
├── Id
├── DrugId (FK)
├── MinAge
├── MaxAge
├── MaxDailyDoseMg
└── Message
```

## Teknoloji Yigini

### Backend
- .NET 8.0
- C# 12
- Entity Framework Core 8.0
- SQL Server Express / LocalDB

### Frontend
- Windows Forms (.NET 8.0)
- DevExpress WinForms 24.1.7

### Tasarim Oruntuleri (Design Patterns)
- Repository Pattern
- Dependency Injection
- Service Layer Pattern
- Result Pattern
- Validator Pattern
- Factory Pattern (DI Container)

### Yazilim Prensipleri
- SOLID Principles
- Separation of Concerns
- DRY (Don't Repeat Yourself)
- Clean Code

## Kurulum

### On Kosullar

1. Visual Studio 2022 veya daha yenisi
2. .NET 8.0 SDK
3. SQL Server Express veya SQL Server LocalDB
4. DevExpress WinForms 24.1.7 (lisansli)

### Kurulum Adimlari

1. Depoyu klonlayin:
```bash
git clone <repository-url>
cd eczaneotomasyonu/EczaneOtomasyon
```

2. Solution dosyasini Visual Studio ile acin:
```bash
EczaneOtomasyon.sln
```

3. NuGet paketlerini geri yukleyin:
```bash
dotnet restore
```

4. Veritabani baglanti dizesini yapilandirin:

`EczaneContext.cs` dosyasinda SQL Server baglanti dizesini duzenleyin:
```csharp
optionsBuilder.UseSqlServer("Server=.\\SQLEXPRESS;Database=EczaneOtomasyonDb;Trusted_Connection=True;TrustServerCertificate=True;");
```

5. Uygulamayi calistirin:
```bash
dotnet run --project EczaneOtomasyon.UI
```

Ilk calistirmada veritabani otomatik olarak olusturulacaktir.

### Veritabani Baslangic Verileri

Sistem ilk calistirmada bos bir veritabani olusturur. Ornek ilac ve kural verilerini yuklemek icin asagidaki SQL scriptlerini calistirin:

1. `SQL_Scripts/eczane_200_ilac_real.sql` - Gercek ilac verileri (200 ilac)
2. `SQL_Scripts/eczane_GERCEK_ILACLAR_EKLEME.sql` - Ek ilac verileri
3. `SQL_Scripts/AI_Kurallar_Yukle.sql` - Ilac etkilesim ve doz kurallari
4. `SQL_Scripts/Update_Initial_Stock.sql` - Baslangic stok degerleri
5. `DatabaseUpdate.sql` - Veritabani guncellemeleri (barkod sistemi)

SQL Management Studio veya Visual Studio SQL Server Object Explorer kullanarak bu scriptleri calistirabilirsiniz.

## Kullanim

### Ana Ekranlar

1. **Ilac Listesi**: Sistemdeki tum ilaclari goruntuler ve yonetir
2. **Ilac Detay/Duzenleme**: Ilac bilgilerini goruntuler ve gunceller
3. **Stok Yonetimi**: Ilac stoklarini takip eder ve gunceller
4. **Recete Listesi**: Tum recetleri goruntuleyin ve yonetin
5. **Recete Olusturma**: Yeni recete girin ve satin
6. **Recete Detayi**: Recete bilgilerini ve ilaclari goruntuler
7. **Uyari Ekrani**: Ilac etkilesimleri ve doz uyarilarini goruntuler

### Ornek Kullanim Senaryosu

1. Yeni bir recete olusturun
2. Hasta bilgilerini girin (ad, soyad, TC, yas)
3. Receteye ilac ekleyin (ilac secimi ve gunluk doz)
4. Sistem otomatik olarak:
   - Ilac etkilesimlerini kontrol eder
   - Doz kurallarina gore dogrulama yapar
   - Stok durumunu kontrol eder
5. Uyarilar varsa, kullaniciya bildirilir
6. Onaylandiginda recete kaydedilir ve stoktan dusulur
7. Satis fisi yazdirilir

## Proje Yapisi

```
EczaneOtomasyon/
│
├── EczaneOtomasyon.DataAccess/
│   ├── Entities.cs                      # Entity modelleri
│   ├── Drug.cs                          # Ilac entity'si
│   ├── EczaneContext.cs                 # DbContext sinifi
│   ├── IEczaneContext.cs                # DbContext interface
│   └── Repositories/
│       ├── IDrugRepository.cs
│       ├── DrugRepository.cs
│       ├── IPrescriptionRepository.cs
│       └── PrescriptionRepository.cs
│
├── EczaneOtomasyon.Business/
│   ├── Common/
│   │   └── Result.cs                    # Result pattern implementasyonu
│   ├── DTOs/
│   │   └── DrugDto.cs
│   ├── Interfaces/
│   │   ├── IDrugService.cs
│   │   ├── IPrescriptionService.cs
│   │   ├── IStockService.cs
│   │   ├── IBarcodeService.cs
│   │   ├── IPrescriptionChecker.cs
│   │   └── IReceiptPrinter.cs
│   ├── Validation/
│   │   ├── IValidator.cs
│   │   ├── ValidationResult.cs
│   │   └── PrescriptionValidator.cs
│   ├── DrugService.cs
│   ├── PrescriptionService.cs
│   ├── StockService.cs
│   ├── BarcodeService.cs
│   ├── PrescriptionChecker.cs          # Etkilesim ve doz kontrolu
│   ├── ReceiptPrinter.cs
│   └── DrugSimilarityService.cs
│
├── EczaneOtomasyon.UI/
│   ├── Program.cs                       # Uygulama giris noktasi ve DI yapisi
│   ├── FrmDrugList.cs                   # Ilac listesi formu
│   ├── FrmDrugEdit.cs                   # Ilac duzenleme formu
│   ├── FrmDrugDetails.cs                # Ilac detay formu
│   ├── FrmStockManagement.cs            # Stok yonetimi formu
│   ├── FrmPrescriptionList.cs           # Recete listesi formu
│   ├── FrmPrescriptionEdit.cs           # Recete olusturma formu
│   ├── FrmPrescriptionDetails.cs        # Recete detay formu
│   ├── FrmPrescriptionWarnings.cs       # Uyari formu
│   ├── Theming/                         # Tema dosyalari
│   └── Resources/                       # Kaynak dosyalar
│
├── SQL_Scripts/
│   ├── eczane_200_ilac_real.sql
│   ├── eczane_GERCEK_ILACLAR_EKLEME.sql
│   ├── AI_Kurallar_Yukle.sql
│   ├── Update_Initial_Stock.sql
│   └── Add_Sales_Fields_To_Prescriptions.sql
│
├── DatabaseUpdate.sql
├── EczaneOtomasyon.sln
├── .gitignore
└── README.md
```

## Guvenlik ve Uyumlu Kullanim

### Onemli Uyarilar

1. Bu sistem egitim ve gelistirme amacliyla olusturulmustur
2. Uretim ortaminda kullanilmadan once saglik otoritelerinden onay alinmalidir
3. Ilac etkilesim ve doz kurallari gercek tibbi kaynaklara dayanmaktadir ancak sistem bir doktorun yerine gecmez
4. Kritik kararlarda mutlaka bir saglik profesyoneline danisilmalidir

### Veri Guvenligi

- Hasta TC kimlik bilgileri sifrelenmemistir (uretim ortami icin sifreleme eklenmelidir)
- Veritabani baglanti dizesi kod icinde sabit olarak tanimlanmistir (production icin secure configuration kullanilmalidir)
- Kullanici kimlik dogrulama sistemi bulunmamaktadir (opsiyonel olarak eklenebilir)

## Gelistirme ve Katki

### Branch Stratejisi

- `main`: Kararli surum
- `develop`: Gelistirme surumleri
- `feature/*`: Yeni ozellikler
- `bugfix/*`: Hata duzeltmeleri

### Kod Standartlari

- C# coding conventions uyulmalidir
- Her public metod icin XML dokumantasyon yazilmalidir
- Unit test coverage minimum %70 olmalidir (gelecek gelistirme)
- SOLID prensiplere uyulmalidir

### Katki Saglamak Icin

1. Projeyi fork edin
2. Yeni bir feature branch olusturun (`git checkout -b feature/YeniOzellik`)
3. Degisikliklerinizi commit edin (`git commit -m 'Yeni ozellik eklendi'`)
4. Branch'inizi push edin (`git push origin feature/YeniOzellik`)
5. Pull Request olusturun

## Test

Proje henuz birim test (unit test) kapsamasi icermemektedir. Gelecek gelistirmelerde asagidaki test kutuphaneleri kullanilarak test altyapisi eklenecektir:

- xUnit veya NUnit
- Moq (mocking framework)
- FluentAssertions

## Bilinen Sorunlar ve Kisitlamalar

1. Coklu kullanici destegi bulunmamaktadir
2. Loglama altyapisi sinirlidir
3. Raporlama ozellikleri gelismektedir
4. Offline calisma modu yoktur
5. Yedekleme sistemi otomatik degildir

## Gelecek Gelistirmeler

- [ ] Kullanici kimlik dogrulama ve yetkilendirme sistemi
- [ ] Gelismis raporlama modulu
- [ ] REST API katmani
- [ ] Mobil uygulama entegrasyonu
- [ ] Bulut veritabani destegi
- [ ] Otomatik yedekleme sistemi
- [ ] Multi-tenant mimari
- [ ] Birim ve entegrasyon testleri
- [ ] CI/CD pipeline kurulumu
- [ ] Docker konteynerizasyonu

## Lisans

Bu proje egitim amacliyla gelistirilmistir. Ticari kullanimdan once gelistirici ile iletisime geciniz.

## Iletisim ve Destek

Sorular, oneriler veya hata bildirimleri icin:

- Issue acarak projeye katki saglayabilirsiniz
- Pull request gonderebilirsiniz

## Referanslar ve Kaynaklar

- Microsoft .NET Documentation: https://docs.microsoft.com/dotnet
- Entity Framework Core Documentation: https://docs.microsoft.com/ef/core
- SOLID Principles: https://en.wikipedia.org/wiki/SOLID
- Repository Pattern: https://docs.microsoft.com/dotnet/architecture/microservices/microservice-ddd-cqrs-patterns/infrastructure-persistence-layer-design
- DevExpress Documentation: https://docs.devexpress.com

## Versiyon Gecmisi

### v1.0.0 (Mevcut)
- Temel CRUD operasyonlari
- Ilac yonetimi
- Recete yonetimi
- Ilac etkilesim kontrolu
- Doz kontrol sistemi
- Stok yonetimi
- Barkod sistemi
- Satis fisi yazdirma
- Turkce karakter desteği

---

**Not**: Bu dokuman projenin akademik standartlara uygun sekilde tanimlanmasi icin hazirlanmistir. Sistem surekli gelistirilmekte olup, guncellemeler duzenli olarak yapilmaktadir.

