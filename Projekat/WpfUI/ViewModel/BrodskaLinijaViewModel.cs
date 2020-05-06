using System;
using System.Globalization;
using Common.Models;
using WpfUI.Model;
using WpfUI.Model.ValidationRules;

namespace WpfUI.ViewModel
{
    public class BrodskaLinijaViewModel : BindableBase
    {
        public string Naziv { get; set; }
        public string Tip { get; set; }
        public string PolaznaTacka { get; set; }
        public string KrajnjaTacka { get; set; }
        public Command AddCommand { get; set; }

        public BrodskaLinijaViewModel()
        {
            AddCommand = new Command(OnAdd);
        }

        private void OnAdd()
        {
            var notEmptyValidationRule = new NotEmptyValidationRule();

            if (!notEmptyValidationRule.Validate(Naziv, CultureInfo.CurrentCulture).IsValid)
            {
                return;
            }

            if (!notEmptyValidationRule.Validate(Tip, CultureInfo.CurrentCulture).IsValid)
            {
                return;
            }

            if (!notEmptyValidationRule.Validate(PolaznaTacka, CultureInfo.CurrentCulture).IsValid)
            {
                return;
            }

            if (!notEmptyValidationRule.Validate(KrajnjaTacka, CultureInfo.CurrentCulture).IsValid)
            {
                return;
            }

            if (!CommunicationProvider.Instance.AddBrodskaLinija(new BrodskaLinija(Guid.NewGuid(), Naziv, Tip, PolaznaTacka, KrajnjaTacka)))
            {
                // show error
                SnackbarMessageProvider.Instance.Enqueue($"Brodogradiliste vec postoji, pokusaj ponovo.");
                return;
            }
            // sucess
            SnackbarMessageProvider.Instance.Enqueue("Brodogradiliste dodato.");
        }
    }
}