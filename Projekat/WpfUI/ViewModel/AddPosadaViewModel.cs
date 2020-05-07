using System;
using System.Collections.Generic;
using System.Globalization;
using Common.Models;
using WpfUI.Model;
using WpfUI.Model.ValidationRules;

namespace WpfUI.ViewModel
{
    public class AddPosadaViewModel : BindableBase
    {
        private List<Kormilar> kormilari;
        private List<Kapetan> kapetani;
        private List<Brod> brodovi;

        public string Ime { get; set; }
        public int Kapacitet { get; set; }
        public List<Kormilar> Kormilari { get => new List<Kormilar>(CommunicationProvider.Instance.GetKormilari()); set => kormilari = value; }
        public Kormilar SelectedKormilar { get; set; }
        public List<Kapetan> Kapetani { get => new List<Kapetan>(CommunicationProvider.Instance.GetKapetani()); set => kapetani = value; }
        public Kapetan SelectedKapetan { get; set; }
        public List<Brod> Brodovi { get => new List<Brod>(CommunicationProvider.Instance.GetBrodovi()); set => brodovi = value; }
        public Brod SelectedBrod { get; set; }
        public Command AddCommand { get; set; }

        public AddPosadaViewModel()
        {
            AddCommand = new Command(OnAdd);
        }

        private void OnAdd()
        {
            if (!IsValid())
            {
                return;
            }

            if (!CommunicationProvider.Instance.AddPosada(new Posada(Guid.NewGuid(), Ime, Kapacitet), SelectedKormilar.JMBG, SelectedKapetan.JMBG, SelectedBrod.ID))
            {
                SnackbarMessageProvider.Instance.Enqueue($"Posada vec postoji, pokusaj ponovo.");
                return;
            }
            // sucess
            SnackbarMessageProvider.Instance.Enqueue("Posada dodata.");
        }

        private bool IsValid()
        {
            var notEmptyOrNullStringValidationRule = new NotEmptyOrNullStringValidationRule();
            var notNullValidationRule = new NotNullValidationRule();

            if (!notEmptyOrNullStringValidationRule.Validate(Ime, CultureInfo.CurrentCulture).IsValid)
            {
                return false;
            }

            if (!notEmptyOrNullStringValidationRule.Validate(Kapacitet, CultureInfo.CurrentCulture).IsValid)
            {
                return false;
            }

            if (!notNullValidationRule.Validate(SelectedKormilar, CultureInfo.CurrentCulture).IsValid)
            {
                return false;
            }

            if (!notNullValidationRule.Validate(SelectedKapetan, CultureInfo.CurrentCulture).IsValid)
            {
                return false;
            }

            if (!notNullValidationRule.Validate(SelectedBrod, CultureInfo.CurrentCulture).IsValid)
            {
                return false;
            }
            return true;
        }
    }
}