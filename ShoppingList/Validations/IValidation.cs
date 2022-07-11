namespace ShoppingList.Validations;

public interface IValidation<in T> 
{
    public ValidationResult Validate(T value);
}