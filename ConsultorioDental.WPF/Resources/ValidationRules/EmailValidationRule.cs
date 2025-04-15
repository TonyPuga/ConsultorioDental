using System.Globalization;
using System.Text.RegularExpressions;
using System.Windows.Controls;

namespace ConsultorioDental.WPF.Resources.ValidationRules;

public class EmailValidationRule : ValidationRule
{
    public override ValidationResult Validate(object value, CultureInfo cultureInfo)
    {
        var input = value as string;
        if (string.IsNullOrWhiteSpace(input))
            return new ValidationResult(false, "El correo es obligatorio");

        string pattern = @"^[^@\s]+@[^@\s]+\.[^@\s]+$";
        bool isValid = Regex.IsMatch(input, pattern);
        return isValid
            ? ValidationResult.ValidResult
            : new ValidationResult(false, "Correo inválido");
    }
}
