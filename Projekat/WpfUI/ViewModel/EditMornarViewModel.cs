using System.Globalization;
using System.Windows;
using Common.Models;
using WpfUI.Model;
using WpfUI.Model.ValidationRules;

namespace WpfUI.ViewModel
{
    public class EditMornarViewModel : BindableBase
    {
        private int selectedPol;
        private string jmbg;

        public string Ime { get; set; }
        public string Prezime { get; set; }
        public string Pol { get; set; }
        public string Rank { get; set; }
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
        public Command<Window> EditCommand { get; set; }

        public EditMornarViewModel()
        {
            EditCommand = new Command<Window>(OnEdit);
        }

        public EditMornarViewModel(Mornar mornar) : this()
        {
            jmbg = mornar.JMBG;
            Ime = mornar.Ime;
            Prezime = mornar.Prezime;
            Rank = mornar.Rank;
            SelectedPol = mornar.Pol == "Muski" ? 0 : 1;
        }

        private void OnEdit(Window w)
        {
            if (!IsValid())
            {
                return;
            }

            DatabaseCommunicationProvider.Instance.EditMornar(new Mornar(jmbg, Ime, Prezime, Pol, Rank));
            w.Close();
        }

        private bool IsValid()
        {
            var notEmptyValidationRule = new NotEmptyOrNullStringValidationRule();

            if (!notEmptyValidationRule.Validate(Ime, CultureInfo.CurrentCulture).IsValid)
            {
                return false;
            }

            if (!notEmptyValidationRule.Validate(Prezime, CultureInfo.CurrentCulture).IsValid)
            {
                return false;
            }

            if (!notEmptyValidationRule.Validate(Rank, CultureInfo.CurrentCulture).IsValid)
            {
                return false;
            }

            return true;
        }
    }
}
