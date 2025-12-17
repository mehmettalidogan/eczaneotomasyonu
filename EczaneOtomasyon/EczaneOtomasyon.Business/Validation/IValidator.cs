namespace EczaneOtomasyon.Business.Validation
{
    public interface IValidator<T>
    {
        ValidationResult Validate(T entity);
    }
}

