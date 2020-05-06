using System.Globalization;
using Common.Models;
using WpfUI.Model;
using WpfUI.Model.ValidationRules;

namespace WpfUI.ViewModel
{
    public class MornarViewModel : BindableBase
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
        public string Rank { get; set; }
        public Command AddCommand { get; set; }

        public MornarViewModel()
        {
            AddCommand = new Command(OnAdd);
            SelectedPol = 0;
        }

        private void OnAdd()
        {
            var notEmptyValidationRule = new NotEmptyValidationRule();
            var jmbgValidationRule = new JmbgValidationRule();
            if (!notEmptyValidationRule.Validate(Jmbg, CultureInfo.CurrentCulture).IsValid)
            {
                return;
            }

            if (!notEmptyValidationRule.Validate(Ime, CultureInfo.CurrentCulture).IsValid)
            {
                return;
            }

            if (!notEmptyValidationRule.Validate(Prezime, CultureInfo.CurrentCulture).IsValid)
            {
                return;
            }

            if (!notEmptyValidationRule.Validate(Rank, CultureInfo.CurrentCulture).IsValid)
            {
                return;
            }

            if (!jmbgValidationRule.Validate(Jmbg, CultureInfo.CurrentCulture).IsValid)
            {
                return;
            }

            if (!CommunicationProvider.Instance.AddMornar(new Mornar(Jmbg, Ime, Prezime, Pol, Rank)))
            {
                // show error
                SnackbarMessageProvider.Instance.Enqueue($"Mornar sa jmbg-om: {Jmbg} vec postoji.");
                return;
            }
            // sucess
            SnackbarMessageProvider.Instance.Enqueue("Mornar dodat.");
        }
    }
}
