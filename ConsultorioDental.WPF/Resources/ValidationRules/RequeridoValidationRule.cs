using System.Diagnostics;
using System.Globalization;
using System.Windows.Controls;

namespace ConsultorioDental.WPF.Resources.ValidationRules;

public class RequeridoValidationRule : ValidationRule
{
    public override ValidationResult Validate(object value, CultureInfo cultureInfo)
    {
        Debug.WriteLine($"Validando: {value}");

        string input = value as string;

        // Validar que el valor no sea nulo ni espacios en blanco
        if (string.IsNullOrWhiteSpace(input))
            return new ValidationResult(false, "Este campo es requerido");

        // Validar si es numérico y si es 0
        if (decimal.TryParse(input, out decimal numero))
        {
            if (numero == 0)
                return new ValidationResult(false, "Este valor ingresado es inválido");
        }

        return ValidationResult.ValidResult;
        //if (String.IsNullOrWhiteSpace(value as String))
        //    return new ValidationResult(false, "Este campo es requerido");

        //Decimal valor = 0;
        //if (Decimal.TryParse(value as string, out valor))
        //    if (valor == 0)
        //        return new ValidationResult(false, "Este valor ingresado es inválido");

        //return new ValidationResult(true, null);
    }
}