using System.Globalization;
using System.Windows.Controls;
using System.Windows.Data;

namespace WpfUI.Model.ValidationRules
{
    public class NullValidationRule : ValidationRule
    {
        public override ValidationResult Validate(object value, CultureInfo cultureInfo)
        {
            var exp = value as BindingExpression;
            if (value is null)
            {
                return new ValidationResult(false, "Polje je obavezno.");
            }
            if (exp is null)
            {
                return ValidationResult.ValidResult;
            }
            if (exp.DataItem is null)
            {
                return new ValidationResult(false, "Polje je obavezno.");
            }
            var val = exp.DataItem.GetType().GetProperty(exp.ParentBinding.Path.Path).GetValue(exp.DataItem, null);
            return val is null
                ? new ValidationResult(false, "Polje je obavezno.")
                : ValidationResult.ValidResult;
        }
    }
}
