using System.Globalization;
using System.Windows.Controls;
using System.Windows.Data;

namespace WpfUI.Model.ValidationRules
{
    public class NotEmptyValidationRule : ValidationRule
    {
        public override ValidationResult Validate(object value, CultureInfo cultureInfo)
        {
            var exp = value as BindingExpression;
            if (exp is null)
            {
                return string.IsNullOrWhiteSpace((value ?? "").ToString()) ? new ValidationResult(false, "Polje je obavezno.") : ValidationResult.ValidResult;
            }
            if (exp.DataItem is null)
            {
                return new ValidationResult(false, "Polje je obavezno.");
            }
            var val = exp.DataItem.GetType().GetProperty(exp.ParentBinding.Path.Path).GetValue(exp.DataItem, null) ?? "";
            return string.IsNullOrWhiteSpace(val.ToString()) ? new ValidationResult(false, "Polje je obavezno.") : ValidationResult.ValidResult;
        }
    }
}
