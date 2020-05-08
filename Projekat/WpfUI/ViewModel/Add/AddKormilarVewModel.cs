using System;
using System.Globalization;
using Common.Models;
using WpfUI.Model;
using WpfUI.Model.ValidationRules;

namespace WpfUI.ViewModel
{
    public class AddKormilarVewModel : BindableBase
    {
        private int selectedPol;

        public int SelectedPol
        {
            get => selectedPol;
            set
            {
                selectedPol = value;
                Pol = (value switch
                {
                    0 => "Muski",
                    1 => "Zenski",
                    _ => "",
                });

            }
        }

        public string Jmbg { get; set; }
        public string Ime { get; set; }
        public string Prezime { get; set; }
        public string Pol { get; set; }
        public Command AddCommand { get; set; }

        public AddKormilarVewModel()
        {
            AddCommand = new Command(OnAdd);
            SelectedPol = 0;
        }

        private void OnAdd()
        {
            if (!IsValid())
            {
                return;
            }

            if (!DatabaseCommunicationProvider.Instance.AddKormilar(new Kormilar(Jmbg, Ime, Prezime, Pol)))
            {
                // show error
                SnackbarMessageProvider.Instance.Enqueue($"Kormilar sa jmbg-om: {Jmbg} vec postoji.");
                return;
            }
            // sucess
            SnackbarMessageProvider.Instance.Enqueue("Kormilar dodat.");
        }

        private bool IsValid()
        {
            var notEmptyValidationRule = new NotEmptyOrNullStringValidationRule();
            var jmbgValidationRule = new JmbgValidationRule();
            if (!notEmptyValidationRule.Validate(Jmbg, CultureInfo.CurrentCulture).IsValid)
            {
                return false;
            }

            if (!notEmptyValidationRule.Validate(Ime, CultureInfo.CurrentCulture).IsValid)
            {
                return false;
            }

            if (!notEmptyValidationRule.Validate(Prezime, CultureInfo.CurrentCulture).IsValid)
            {
                return false;
            }

            if (!jmbgValidationRule.Validate(Jmbg, CultureInfo.CurrentCulture).IsValid)
            {
                return false;
            }
            return true;
        }
    }
}
