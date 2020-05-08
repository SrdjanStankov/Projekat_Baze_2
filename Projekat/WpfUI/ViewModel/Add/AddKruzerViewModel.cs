using System.Collections.Generic;
using System.Globalization;
using System;
using WpfUI.Model.ValidationRules;
using WpfUI.Model;
using Common.Models;

namespace WpfUI.ViewModel
{
    public class AddKruzerViewModel : BindableBase
    {
        private List<Brodogradiliste> brodogradilista;

        public string Ime { get; set; }
        public DateTime GodGradnje { get; set; }
        public int MaxBrzina { get; set; }
        public int Duzina { get; set; }
        public int Sirina { get; set; }
        public int BrPutnika { get; set; }
        public int BrOsoblja { get; set; }
        public Brodogradiliste SelectedItem { get; set; }
        public Command AddCommand { get; set; }
        public List<Brodogradiliste> Brodogradilista
        {
            get => new List<Brodogradiliste>(DatabaseCommunicationProvider.Instance.GetBrodogradilista());
            set => brodogradilista = value;
        }

        public AddKruzerViewModel()
        {
            AddCommand = new Command(OnAdd);
        }

        private void OnAdd()
        {
            if (!IsValid())
            {
                return;
            }

            if (!DatabaseCommunicationProvider.Instance.AddKruzer(new Kruzer(Guid.NewGuid(), Ime, GodGradnje, MaxBrzina, Duzina, Sirina, BrPutnika, BrOsoblja), SelectedItem.ID))
            {
                SnackbarMessageProvider.Instance.Enqueue($"Kruzer vec postoji, pokusaj ponovo.");
                return;
            }
            // sucess
            SnackbarMessageProvider.Instance.Enqueue("Kruzer dodat.");
        }

        private bool IsValid()
        {
            var notEmptyValidationRule = new NotEmptyOrNullStringValidationRule();
            var notNullValidationRule = new NotNullValidationRule();

            if (!notEmptyValidationRule.Validate(Ime, CultureInfo.CurrentCulture).IsValid)
            {
                return false;
            }

            if (!notEmptyValidationRule.Validate(GodGradnje, CultureInfo.CurrentCulture).IsValid)
            {
                return false;
            }

            if (!notEmptyValidationRule.Validate(MaxBrzina, CultureInfo.CurrentCulture).IsValid)
            {
                return false;
            }

            if (!notEmptyValidationRule.Validate(Duzina, CultureInfo.CurrentCulture).IsValid)
            {
                return false;
            }

            if (!notEmptyValidationRule.Validate(Sirina, CultureInfo.CurrentCulture).IsValid)
            {
                return false;
            }

            if (!notEmptyValidationRule.Validate(BrPutnika, CultureInfo.CurrentCulture).IsValid)
            {
                return false;
            }

            if (!notEmptyValidationRule.Validate(BrOsoblja, CultureInfo.CurrentCulture).IsValid)
            {
                return false;
            }

            if (!notNullValidationRule.Validate(SelectedItem, CultureInfo.CurrentCulture).IsValid)
            {
                return false;
            }
            return true;
        }
    }
}