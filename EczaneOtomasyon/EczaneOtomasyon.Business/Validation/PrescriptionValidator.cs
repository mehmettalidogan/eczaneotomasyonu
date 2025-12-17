using System.Text.RegularExpressions;
using EczaneOtomasyon.DataAccess;

namespace EczaneOtomasyon.Business.Validation
{
    public class PrescriptionValidator : IValidator<Prescription>
    {
        public ValidationResult Validate(Prescription prescription)
        {
            var result = new ValidationResult();

            if (string.IsNullOrWhiteSpace(prescription.PrescriptionNumber))
                result.AddError("Reçete numarası boş olamaz.");

            if (string.IsNullOrWhiteSpace(prescription.PatientName))
                result.AddError("Hasta adı boş olamaz.");

            if (string.IsNullOrWhiteSpace(prescription.PatientSurname))
                result.AddError("Hasta soyadı boş olamaz.");

            if (string.IsNullOrWhiteSpace(prescription.PatientTC) || prescription.PatientTC.Length != 11)
                result.AddError("TC Kimlik No 11 haneli olmalıdır.");

            if (!string.IsNullOrWhiteSpace(prescription.PatientTC) && !Regex.IsMatch(prescription.PatientTC, @"^\d{11}$"))
                result.AddError("TC Kimlik No sadece rakamlardan oluşmalıdır.");

            if (prescription.PatientAge <= 0 || prescription.PatientAge > 150)
                result.AddError("Hasta yaşı geçerli aralıkta olmalıdır (1-150).");

            return result;
        }
    }
}

