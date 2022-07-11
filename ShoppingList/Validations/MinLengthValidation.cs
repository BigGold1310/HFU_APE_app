using Microsoft.Extensions.Options;

namespace ShoppingList.Validations;

public class MinLengthValidation : IValidation<string>
{
    private int _lenght;

    public MinLengthValidation(int length)
    {
        _lenght = length;
    }

    public ValidationResult Validate(string value)
    {
        if (value.Length >= _lenght)
        {
            return new ValidationResult(true);
        }

        return new ValidationResult(false, $"Min lenght should be {_lenght}!");
    }
}