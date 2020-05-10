using System;
using System.Globalization;
using System.Windows;
using Common.Models;
using WpfUI.Model;
using WpfUI.Model.ValidationRules;

namespace WpfUI.ViewModel
{
    public class EditTeretniBrodViewModel : BindableBase
    {
        private Guid id;

        public string Ime { get; set; }
        public DateTime GodGrad { get; set; }
        public int MaxBrzina { get; set; }
        public int Duzina { get; set; }
        public int Sirina { get; set; }
        public int KapacTeret { get; set; }
        public string StatUtov { get; set; }

        public Command<Window> EditCommand { get; set; }

        public EditTeretniBrodViewModel()
        {
            EditCommand = new Command<Window>(OnEdit);
        }

        public EditTeretniBrodViewModel(TeretniBrod brod) : this()
        {
            id = brod.ID;
            Ime = brod.Ime;
            GodGrad = brod.GodGrad;
            MaxBrzina = brod.MaxBrzina;
            Duzina = brod.Duzina;
            Sirina = brod.Sirina;
            KapacTeret = brod.KapacTeret;
            StatUtov = brod.StatUtov;
        }

        private void OnEdit(Window w)
        {
            if (!IsValid())
            {
                return;
            }

            DatabaseCommunicationProvider.Instance.EditTeretniBrod(new TeretniBrod(id, Ime, GodGrad, MaxBrzina, Duzina, Sirina, KapacTeret, StatUtov));
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

            if (!notEmptyOrNullStringValidationRule.Validate(KapacTeret, CultureInfo.CurrentCulture).IsValid)
            {
                return false;
            }

            if (!notEmptyOrNullStringValidationRule.Validate(StatUtov, CultureInfo.CurrentCulture).IsValid)
            {
                return false;
            }

            return true;
        }
    }
}
