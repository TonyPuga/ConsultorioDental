﻿using System.Globalization;
using System.Windows.Controls;

namespace ConsultorioDental.WPF.Resources.ValidationRules;

public class RequeridoValidationRule : ValidationRule
{
    public override ValidationResult Validate(object value, CultureInfo cultureInfo)
    {
        if (String.IsNullOrWhiteSpace(value as String))
            return new ValidationResult(false, "Este campo es requerido");

        Decimal valor = 0;
        if (Decimal.TryParse(value as string, out valor))
            if (valor == 0)
                return new ValidationResult(false, "Este valor ingresado es inválido");

        return new ValidationResult(true, null);
    }
}