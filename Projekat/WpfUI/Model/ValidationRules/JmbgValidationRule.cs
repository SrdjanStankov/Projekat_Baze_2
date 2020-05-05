using System.Globalization;
using System.Windows.Controls;
using System.Windows.Data;

namespace WpfUI.Model.ValidationRules
{
    public class JmbgValidationRule : ValidationRule
    {
        public override ValidationResult Validate(object value, CultureInfo cultureInfo)
        {
            var exp = value as BindingExpression;
            var val = value.ToString();
            if (exp != null)
            {
                val = exp.DataItem.GetType().GetProperty(exp.ParentBinding.Path.Path).GetValue(exp.DataItem, null).ToString() ?? "";
            }
            if (val.Length != 13)
            {
                return new ValidationResult(false, "Jmbg nije ispravan");
            }
            if (!ulong.TryParse(val, out _))
            {
                return new ValidationResult(false, "Jmbg nije u dobrom formatu");
            }

            return ValidationResult.ValidResult;
        }
    }
}
