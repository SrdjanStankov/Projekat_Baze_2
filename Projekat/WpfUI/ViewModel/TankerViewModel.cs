using Common.Models;
using System.Collections.Generic;
using System.Globalization;
using System;
using WpfUI.Model.ValidationRules;
using WpfUI.Model;

namespace WpfUI.ViewModel
{
    public class TankerViewModel : BindableBase
    {
        private List<Brodogradiliste> brodogradilista;

        public string Ime { get; set; }
        public DateTime GodGradnje { get; set; }
        public int MaxBrzina { get; set; }
        public int Duzina { get; set; }
        public int Sirina { get; set; }
        public int Nosivost { get; set; }
        public Brodogradiliste SelectedItem { get; set; }
        public Command AddCommand { get; set; }
        public List<Brodogradiliste> Brodogradilista
        {
            get => new List<Brodogradiliste>(CommunicationProvider.Instance.GetBrodogradilista());
            set => brodogradilista = value;
        }

        public TankerViewModel()
        {
            AddCommand = new Command(OnAdd);
        }

        private void OnAdd()
        {
            var notEmptyValidationRule = new NotEmptyValidationRule();
            var notNullValidationRule = new NotNullValidationRule();

            if (!notEmptyValidationRule.Validate(Ime, CultureInfo.CurrentCulture).IsValid)
            {
                return;
            }

            if (!notEmptyValidationRule.Validate(GodGradnje, CultureInfo.CurrentCulture).IsValid)
            {
                return;
            }

            if (!notEmptyValidationRule.Validate(MaxBrzina, CultureInfo.CurrentCulture).IsValid)
            {
                return;
            }

            if (!notEmptyValidationRule.Validate(Duzina, CultureInfo.CurrentCulture).IsValid)
            {
                return;
            }

            if (!notEmptyValidationRule.Validate(Sirina, CultureInfo.CurrentCulture).IsValid)
            {
                return;
            }

            if (!notEmptyValidationRule.Validate(Nosivost, CultureInfo.CurrentCulture).IsValid)
            {
                return;
            }

            if (!notNullValidationRule.Validate(SelectedItem, CultureInfo.CurrentCulture).IsValid)
            {
                return;
            }

            if (!CommunicationProvider.Instance.AddTanker(new Tanker(Guid.NewGuid(), Ime, GodGradnje, MaxBrzina, Duzina, Sirina, Nosivost, ""), SelectedItem.ID))
            {
                SnackbarMessageProvider.Instance.Enqueue($"Tanker vec postoji, pokusaj ponovo.");
                return;
            }
            // sucess
            SnackbarMessageProvider.Instance.Enqueue("Tanker dodat.");
        }
    }
}