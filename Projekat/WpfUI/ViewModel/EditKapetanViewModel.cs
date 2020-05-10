using System;
using System.Globalization;
using System.Windows;
using Common.Models;
using WpfUI.Model;
using WpfUI.Model.ValidationRules;

namespace WpfUI.ViewModel
{
    public class EditKapetanViewModel : BindableBase
    {
        private int selectedPol;
        private string jmbg;

        public string Ime { get; set; }
        public string Prezime { get; set; }
        public string Pol { get; set; }
        public DateTime GodRodj { get; set; }
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

        public EditKapetanViewModel()
        {
            EditCommand = new Command<Window>(OnEdit);
        }

        public EditKapetanViewModel(Kapetan kormilar) : this()
        {
            jmbg = kormilar.JMBG;
            Ime = kormilar.Ime;
            Prezime = kormilar.Prezime;
            SelectedPol = kormilar.Pol == "Muski" ? 0 : 1;
        }

        private void OnEdit(Window w)
        {
            if (!IsValid())
            {
                return;
            }

            DatabaseCommunicationProvider.Instance.EditKapetan(new Kapetan(jmbg, Ime, Prezime, Pol, GodRodj));
            w.Close();
        }

        private bool IsValid()
        {
            var notEmptyOrNullStringValidationRule = new NotEmptyOrNullStringValidationRule();

            if (!notEmptyOrNullStringValidationRule.Validate(Ime, CultureInfo.CurrentCulture).IsValid)
            {
                return false;
            }

            if (!notEmptyOrNullStringValidationRule.Validate(Prezime, CultureInfo.CurrentCulture).IsValid)
            {
                return false;
            }

            if (!notEmptyOrNullStringValidationRule.Validate(GodRodj, CultureInfo.CurrentCulture).IsValid)
            {
                return false;
            }

            return true;
        }
    }
}
