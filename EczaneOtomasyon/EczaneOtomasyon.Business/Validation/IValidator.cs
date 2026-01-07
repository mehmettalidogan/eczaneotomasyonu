namespace EczaneOtomasyon.Business.Validation
{
    /// <summary>
    /// Generic validator interface
    /// </summary>
    /// <typeparam name="T">Validate edilecek tip</typeparam>
    public interface IValidator<T>
    {
        /// <summary>
        /// Nesneyi validate eder
        /// </summary>
        /// <param name="entity">Validate edilecek nesne</param>
        /// <returns>Validasyon sonucu</returns>
        ValidationResult Validate(T entity);
    }
}










