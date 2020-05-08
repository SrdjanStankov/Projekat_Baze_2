using System;
using System.Globalization;
using System.Windows;
using Common.Models;
using WpfUI.Model;
using WpfUI.Model.ValidationRules;

namespace WpfUI.ViewModel
{
    public class EditBrodskaLinijaViewModel : BindableBase
    {
        private Guid id;

        public string Naziv { get; set; }
        public string Tip { get; set; }
        public string PolaznaTacka { get; set; }
        public string KrajnjaTacka { get; set; }

        public Command<Window> EditCommand { get; set; }

        public EditBrodskaLinijaViewModel()
        {
            EditCommand = new Command<Window>(OnEdit);
        }

        public EditBrodskaLinijaViewModel(BrodskaLinija linija) : this()
        {
            id = linija.BrojLinije;
            Naziv = linija.Naziv;
            Tip = linija.Tip;
            PolaznaTacka = linija.Polazna_tacka;
            KrajnjaTacka = linija.Krajnja_tacka;
        }

        private void OnEdit(Window w)
        {
            if (!IsValid())
            {
                return;
            }

            DatabaseCommunicationProvider.Instance.EditBrodskaLinija(new BrodskaLinija(id, Naziv, Tip, PolaznaTacka, KrajnjaTacka));
            w.Close();
        }

        private bool IsValid()
        {
            var notEmptyValidationRule = new NotEmptyOrNullStringValidationRule();

            if (!notEmptyValidationRule.Validate(Naziv, CultureInfo.CurrentCulture).IsValid)
            {
                return false;
            }

            if (!notEmptyValidationRule.Validate(Tip, CultureInfo.CurrentCulture).IsValid)
            {
                return false;
            }

            if (!notEmptyValidationRule.Validate(PolaznaTacka, CultureInfo.CurrentCulture).IsValid)
            {
                return false;
            }

            if (!notEmptyValidationRule.Validate(KrajnjaTacka, CultureInfo.CurrentCulture).IsValid)
            {
                return false;
            }

            return true;
        }
    }
}
