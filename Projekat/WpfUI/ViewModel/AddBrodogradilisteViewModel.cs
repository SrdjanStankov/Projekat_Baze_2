using System;
using System.Globalization;
using Common.Models;
using WpfUI.Model;
using WpfUI.Model.ValidationRules;

namespace WpfUI.ViewModel
{
    public class AddBrodogradilisteViewModel : BindableBase
    {
        public string Naziv { get; set; }
        public string Lokacija { get; set; }
        public int BrPristanista { get; set; }
        public bool PosSuviDok { get; set; }
        public Command AddCommand { get; set; }

        public AddBrodogradilisteViewModel()
        {
            AddCommand = new Command(OnAdd);
        }

        private void OnAdd()
        {
            if (!IsValid())
            {
                return;
            }

            if (!CommunicationProvider.Instance.AddBrodogradiliste(new Brodogradiliste(Guid.NewGuid(), Naziv, Lokacija, 0, BrPristanista, PosSuviDok)))
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

            if (!notEmptyValidationRule.Validate(Lokacija, CultureInfo.CurrentCulture).IsValid)
            {
                return false;
            }

            if (!notEmptyValidationRule.Validate(BrPristanista, CultureInfo.CurrentCulture).IsValid)
            {
                return false;
            }
            return true;
        }
    }
}
