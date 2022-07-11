using Microsoft.Extensions.Options;

namespace ShoppingList.Validations;

public class MaxLengthValidation : IValidation<string>
{
    private int _lenght;

    public MaxLengthValidation(int length)
    {
        _lenght = length;
    }

    public ValidationResult Validate(string value)
    {
        if (value.Length <= _lenght)
        {
            return new ValidationResult(true);
        }

        return new ValidationResult(false, $"Max lenght should be {_lenght}!");
    }
}