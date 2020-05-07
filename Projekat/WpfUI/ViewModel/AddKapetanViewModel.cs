using System;
using System.Collections.Generic;
using System.Globalization;
using Common.Models;
using WpfUI.Model;
using WpfUI.Model.ValidationRules;

namespace WpfUI.ViewModel
{
    public class AddKapetanViewModel : BindableBase
    {
        private int selectedPol;
        private List<BrodskaLinija> linije;
        private List<Brod> brodovi;

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
        public List<BrodskaLinija> Linije { get => new List<BrodskaLinija>(CommunicationProvider.Instance.GetBrodskeLinije()); set => linije = value; }
        public BrodskaLinija SelectedLinija { get; set; }
        public List<Brod> Brodovi { get => new List<Brod>(CommunicationProvider.Instance.GetBrodovi()); set => brodovi = value; }
        public Brod SelectedBrod { get; set; }
        public DateTime GodRodj { get; set; }
        public Command AddCommand { get; set; }

        public AddKapetanViewModel()
        {
            AddCommand = new Command(OnAdd);
        }

        private void OnAdd()
        {
            if (!IsValid())
            {
                return;
            }

            if (!CommunicationProvider.Instance.AddKapetan(new Kapetan(Jmbg, Ime, Prezime, Pol, GodRodj), SelectedLinija.BrojLinije, SelectedBrod.ID))
            {
                // show error
                SnackbarMessageProvider.Instance.Enqueue($"Kapetan sa jmbg-om: {Jmbg} vec postoji.");
                return;
            }
            // sucess
            SnackbarMessageProvider.Instance.Enqueue("Kapetan dodat.");
        }

        private bool IsValid()
        {
            var notEmptyValidationRule = new NotEmptyOrNullStringValidationRule();
            var jmbgValidationRule = new JmbgValidationRule();
            var notNullValidationRule = new NotNullValidationRule();

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

            if (!notNullValidationRule.Validate(SelectedLinija, CultureInfo.CurrentCulture).IsValid)
            {
                return false;
            }

            if (!notNullValidationRule.Validate(SelectedBrod, CultureInfo.CurrentCulture).IsValid)
            {
                return false;
            }

            if (!notNullValidationRule.Validate(GodRodj, CultureInfo.CurrentCulture).IsValid)
            {
                return false;
            }
            return true;
        }
    }
}