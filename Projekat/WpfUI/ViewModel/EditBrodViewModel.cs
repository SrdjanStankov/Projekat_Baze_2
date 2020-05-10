using System;
using System.Globalization;
using System.Windows;
using Common.Models;
using WpfUI.Model;
using WpfUI.Model.ValidationRules;

namespace WpfUI.ViewModel
{
    public class EditBrodViewModel : BindableBase
    {
        private Guid id;

        public string Ime { get; set; }
        public DateTime GodGrad { get; set; }
        public int MaxBrzina { get; set; }
        public int Duzina { get; set; }
        public int Sirina { get; set; }

        public Command<Window> EditCommand { get; set; }

        public EditBrodViewModel()
        {
            EditCommand = new Command<Window>(OnEdit);
        }

        public EditBrodViewModel(Brod brod) : this()
        {
            id = brod.ID;
            Ime = brod.Ime;
            GodGrad = brod.GodGrad;
            MaxBrzina = brod.MaxBrzina;
            Duzina = brod.Duzina;
            Sirina = brod.Sirina;
        }

        private void OnEdit(Window w)
        {
            if (!IsValid())
            {
                return;
            }

            DatabaseCommunicationProvider.Instance.EditBrod(new Brod(id, Ime, GodGrad, MaxBrzina, Duzina, Sirina));
            w.Close();
        }

        private bool IsValid()
        {
            var notEmptyOrNullStringValidationRule = new NotEmptyOrNullStringValidationRule();

            if (!notEmptyOrNullStringValidationRule.Validate(Ime, CultureInfo.CurrentCulture).IsValid)
            {
                return false;
            }

            if (!notEmptyOrNullStringValidationRule.Validate(GodGrad, CultureInfo.CurrentCulture).IsValid)
            {
                return false;
            }

            if (!notEmptyOrNullStringValidationRule.Validate(MaxBrzina, CultureInfo.CurrentCulture).IsValid)
            {
                return false;
            }

            if (!notEmptyOrNullStringValidationRule.Validate(Duzina, CultureInfo.CurrentCulture).IsValid)
            {
                return false;
            }

            if (!notEmptyOrNullStringValidationRule.Validate(Sirina, CultureInfo.CurrentCulture).IsValid)
            {
                return false;
            }

            return true;
        }
    }
}
