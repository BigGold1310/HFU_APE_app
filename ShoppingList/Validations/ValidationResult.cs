namespace ShoppingList.Validations;

public class ValidationResult
{
    public bool IsValid;
    public string Message;

    public ValidationResult(bool isValid)
    {
        IsValid = isValid;
    }

    public ValidationResult(bool isValid, string message)
    {
        IsValid = isValid;
        Message = message;
    }
}