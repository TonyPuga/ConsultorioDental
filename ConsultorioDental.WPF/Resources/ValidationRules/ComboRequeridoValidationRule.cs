using System.Globalization;
using System.Windows.Controls;

namespace ConsultorioDental.WPF.Resources.ValidationRules
{
    public class ComboRequeridoValidationRule : ValidationRule
    {
        public override ValidationResult Validate(object value, CultureInfo cultureInfo)
        {
            if (value == null)
                return new ValidationResult(false, "Este campo es requerido");

            if (value is int intValue)
            {
                if (intValue == 0)
                    return new ValidationResult(false, "Este campo es requerido"); 
            }

            return new ValidationResult(true, null);
        }
    }
}
