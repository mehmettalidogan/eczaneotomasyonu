using System;
using EczaneOtomasyon.DataAccess;

namespace EczaneOtomasyon.Business.Validation
{
    /// <summary>
    /// Reçete validator sınıfı
    /// </summary>
    public class PrescriptionValidator : IValidator<Prescription>
    {
        /// <summary>
        /// Reçeteyi validate eder
        /// </summary>
        /// <param name="entity">Validate edilecek reçete</param>
        /// <returns>Validasyon sonucu</returns>
        public ValidationResult Validate(Prescription entity)
        {
            var result = new ValidationResult();

            if (string.IsNullOrWhiteSpace(entity.PrescriptionNumber))
            {
                result.AddError("Reçete numarası boş olamaz.");
            }

            if (string.IsNullOrWhiteSpace(entity.PatientName))
            {
                result.AddError("Hasta adı boş olamaz.");
            }

            if (string.IsNullOrWhiteSpace(entity.PatientSurname))
            {
                result.AddError("Hasta soyadı boş olamaz.");
            }

            if (string.IsNullOrWhiteSpace(entity.PatientTC) || entity.PatientTC.Length != 11)
            {
                result.AddError("Geçerli bir TC Kimlik No giriniz (11 haneli).");
            }

            if (entity.PatientAge < 0 || entity.PatientAge > 150)
            {
                result.AddError("Hasta yaşı geçerli değil.");
            }

            if (entity.Date > DateTime.Now.AddDays(1))
            {
                result.AddError("Reçete tarihi gelecek bir tarih olamaz.");
            }

            return result;
        }
    }
}










