﻿using System;
using System.Collections.Generic;
using System.Globalization;
using Common.Models;
using WpfUI.Model;
using WpfUI.Model.ValidationRules;

namespace WpfUI.ViewModel
{
    public class AddTankerViewModel : BindableBase
    {
        private List<Brodogradiliste> brodogradilista;

        public string Ime { get; set; }
        public string TipTereta { get; set; }
        public DateTime GodGradnje { get; set; }
        public int MaxBrzina { get; set; }
        public int Duzina { get; set; }
        public int Sirina { get; set; }
        public int Nosivost { get; set; }
        public Brodogradiliste SelectedItem { get; set; }
        public Command AddCommand { get; set; }
        public List<Brodogradiliste> Brodogradilista
        {
            get => new List<Brodogradiliste>(DatabaseCommunicationProvider.Instance.GetBrodogradilista());
            set => brodogradilista = value;
        }

        public AddTankerViewModel()
        {
            AddCommand = new Command(OnAdd);
        }

        private void OnAdd()
        {
            if (!IsValid())
            {
                return;
            }

            if (!DatabaseCommunicationProvider.Instance.AddTanker(new Tanker(Guid.NewGuid(), Ime, GodGradnje, MaxBrzina, Duzina, Sirina, Nosivost, TipTereta), SelectedItem.ID))
            {
                SnackbarMessageProvider.Instance.Enqueue($"Tanker vec postoji, pokusaj ponovo.");
                return;
            }
            // sucess
            SnackbarMessageProvider.Instance.Enqueue("Tanker dodat.");
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

            if (!notEmptyValidationRule.Validate(Nosivost, CultureInfo.CurrentCulture).IsValid)
            {
                return false;
            }

            if (!notEmptyValidationRule.Validate(TipTereta, CultureInfo.CurrentCulture).IsValid)
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