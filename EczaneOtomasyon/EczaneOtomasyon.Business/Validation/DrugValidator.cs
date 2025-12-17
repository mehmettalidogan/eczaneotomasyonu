using EczaneOtomasyon.DataAccess;

namespace EczaneOtomasyon.Business.Validation
{
    public class DrugValidator : IValidator<Drug>
    {
        public ValidationResult Validate(Drug drug)
        {
            var result = new ValidationResult();

            if (string.IsNullOrWhiteSpace(drug.Name))
                result.AddError("İlaç adı boş olamaz.");

            if (string.IsNullOrWhiteSpace(drug.ActiveSubstance))
                result.AddError("Etken madde boş olamaz.");

            if (string.IsNullOrWhiteSpace(drug.Form))
                result.AddError("İlaç formu boş olamaz.");

            if (drug.Price <= 0)
                result.AddError("Fiyat sıfırdan büyük olmalıdır.");

            if (drug.Stock < 0)
                result.AddError("Stok negatif olamaz.");

            if (!string.IsNullOrWhiteSpace(drug.Barcode) && drug.Barcode.Length < 8)
                result.AddError("Barkod en az 8 karakter olmalıdır.");

            return result;
        }
    }
}

