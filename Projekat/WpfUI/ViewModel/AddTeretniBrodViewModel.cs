using System.Collections.Generic;
using System.Globalization;
using System;
using WpfUI.Model.ValidationRules;
using WpfUI.Model;
using Common.Models;

namespace WpfUI.ViewModel
{
    public class AddTeretniBrodViewModel : BindableBase
    {
        private List<Brodogradiliste> brodogradilista;

        public string Ime { get; set; }
        public DateTime GodGradnje { get; set; }
        public int MaxBrzina { get; set; }
        public int Duzina { get; set; }
        public int Sirina { get; set; }
        public int KapTereta { get; set; }
        public Brodogradiliste SelectedItem { get; set; }
        public Command AddCommand { get; set; }
        public List<Brodogradiliste> Brodogradilista
        {
            get => new List<Brodogradiliste>(CommunicationProvider.Instance.GetBrodogradilista());
            set => brodogradilista = value;
        }

        public AddTeretniBrodViewModel()
        {
            AddCommand = new Command(OnAdd);
        }

        private void OnAdd()
        {
            if (!IsValid())
            {
                return;
            }

            if (!CommunicationProvider.Instance.AddTeretniBrod(new TeretniBrod(Guid.NewGuid(), Ime, GodGradnje, MaxBrzina, Duzina, Sirina, KapTereta, ""), SelectedItem.ID))
            {
                SnackbarMessageProvider.Instance.Enqueue($"Teretni brod vec postoji, pokusaj ponovo.");
                return;
            }
            // sucess
            SnackbarMessageProvider.Instance.Enqueue("Teretni brod dodat.");
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

            if (!notEmptyValidationRule.Validate(KapTereta, CultureInfo.CurrentCulture).IsValid)
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