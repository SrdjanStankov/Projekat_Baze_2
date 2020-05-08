using System;
using System.Collections.Generic;
using System.Globalization;
using Common.Models;
using WpfUI.Model;
using WpfUI.Model.ValidationRules;

namespace WpfUI.ViewModel
{
    public class AddBrodViewModel : BindableBase
    {
        private List<Brodogradiliste> brodogradilista;

        public string Ime { get; set; }
        public DateTime GodGradnje { get; set; }
        public int MaxBrzina { get; set; }
        public int Duzina { get; set; }
        public int Sirina { get; set; }
        public Brodogradiliste SelectedItem { get; set; }
        public Command AddCommand { get; set; }
        public List<Brodogradiliste> Brodogradilista
        {
            get => new List<Brodogradiliste>(DatabaseCommunicationProvider.Instance.GetBrodogradilista());
            set => brodogradilista = value;
        }

        public AddBrodViewModel()
        {
            AddCommand = new Command(OnAdd);
        }

        private void OnAdd()
        {
            if (!IsValid())
            {
                return;
            }

            if (!DatabaseCommunicationProvider.Instance.AddBrod(new Brod(Guid.NewGuid(), Ime, GodGradnje, MaxBrzina, Duzina, Sirina), SelectedItem.ID))
            {
                SnackbarMessageProvider.Instance.Enqueue($"Brod vec postoji, pokusaj ponovo.");
                return;
            }
            // sucess
            SnackbarMessageProvider.Instance.Enqueue("Brod dodat.");
        }

        private bool IsValid()
        {
            var notEmptyValidationRule = new NotEmptyOrNullStringValidationRule();
            var nullValidationRule = new NotNullValidationRule();

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

            if (!nullValidationRule.Validate(SelectedItem, CultureInfo.CurrentCulture).IsValid)
            {
                return false;
            }
            return true;
        }
    }
}