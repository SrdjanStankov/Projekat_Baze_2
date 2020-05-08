using System;
using System.Globalization;
using Common.Models;
using WpfUI.Model;
using WpfUI.Model.ValidationRules;

namespace WpfUI.ViewModel
{
    public class AddBrodskaLinijaViewModel : BindableBase
    {
        public string Naziv { get; set; }
        public string Tip { get; set; }
        public string PolaznaTacka { get; set; }
        public string KrajnjaTacka { get; set; }
        public Command AddCommand { get; set; }

        public AddBrodskaLinijaViewModel()
        {
            AddCommand = new Command(OnAdd);
        }

        private void OnAdd()
        {
            if (!IsValid())
            {
                return;
            }

            if (!DatabaseCommunicationProvider.Instance.AddBrodskaLinija(new BrodskaLinija(Guid.NewGuid(), Naziv, Tip, PolaznaTacka, KrajnjaTacka)))
            {
                // show error
                SnackbarMessageProvider.Instance.Enqueue($"Brodogradiliste vec postoji, pokusaj ponovo.");
                return;
            }
            // sucess
            SnackbarMessageProvider.Instance.Enqueue("Brodogradiliste dodato.");
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