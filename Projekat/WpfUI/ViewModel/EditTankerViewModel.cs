using System;
using System.Globalization;
using System.Windows;
using Common.Models;
using WpfUI.Model;
using WpfUI.Model.ValidationRules;

namespace WpfUI.ViewModel
{
    public class EditTankerViewModel : BindableBase
    {
        private Guid id;

        public string Ime { get; set; }
        public DateTime GodGrad { get; set; }
        public int MaxBrzina { get; set; }
        public int Duzina { get; set; }
        public int Sirina { get; set; }
        public int Nosivost { get; set; }
        public string TipTeret { get; set; }

        public Command<Window> EditCommand { get; set; }

        public EditTankerViewModel()
        {
            EditCommand = new Command<Window>(OnEdit);
        }

        public EditTankerViewModel(Tanker brod) : this()
        {
            id = brod.ID;
            Ime = brod.Ime;
            GodGrad = brod.GodGrad;
            MaxBrzina = brod.MaxBrzina;
            Duzina = brod.Duzina;
            Sirina = brod.Sirina;
            Nosivost = brod.Nosivost;
            TipTeret = brod.TipTeret;
        }

        private void OnEdit(Window w)
        {
            if (!IsValid())
            {
                return;
            }

            DatabaseCommunicationProvider.Instance.EditTanker(new Tanker(id, Ime, GodGrad, MaxBrzina, Duzina, Sirina, Nosivost, TipTeret));
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

            if (!notEmptyOrNullStringValidationRule.Validate(Nosivost, CultureInfo.CurrentCulture).IsValid)
            {
                return false;
            }

            if (!notEmptyOrNullStringValidationRule.Validate(TipTeret, CultureInfo.CurrentCulture).IsValid)
            {
                return false;
            }

            return true;
        }
    }
}
