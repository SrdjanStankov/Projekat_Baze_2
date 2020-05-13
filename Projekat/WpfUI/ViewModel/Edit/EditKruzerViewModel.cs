using System;
using System.Globalization;
using System.Windows;
using Common.Models;
using WpfUI.Model;
using WpfUI.Model.ValidationRules;

namespace WpfUI.ViewModel
{
    public class EditKruzerViewModel : BindableBase
    {
        private Guid id;

        public string Ime { get; set; }
        public DateTime GodGrad { get; set; }
        public int MaxBrzina { get; set; }
        public int Duzina { get; set; }
        public int Sirina { get; set; }
        public int BrPutnika { get; set; }
        public int BrOsoblja { get; set; }

        public Command<Window> EditCommand { get; set; }

        public EditKruzerViewModel()
        {
            EditCommand = new Command<Window>(OnEdit);
        }

        public EditKruzerViewModel(Kruzer brod) : this()
        {
            id = brod.ID;
            Ime = brod.Ime;
            GodGrad = brod.GodGrad;
            MaxBrzina = brod.MaxBrzina;
            Duzina = brod.Duzina;
            Sirina = brod.Sirina;
            BrPutnika = brod.BrPutnika;
            BrOsoblja = brod.BrOsoblja;
        }

        private void OnEdit(Window w)
        {
            if (!IsValid())
            {
                return;
            }

            DatabaseCommunicationProvider.Instance.EditKruzer(new Kruzer(id, Ime, GodGrad, MaxBrzina, Duzina, Sirina, BrPutnika, BrOsoblja));
            w.Close();
        }

        private bool IsValid()
        {
            var notEmptyOrNullStringValidationRule = new NotEmptyOrNullStringValidationRule();

            if (!notEmptyOrNullStringValidationRule.Validate(Ime, CultureInfo.CurrentCulture).IsValid)
            {
                return false;
            }

            if (!notEmptyOrNullStringValidationRule.Validate(GodGrad, CultureInfo.CurrentCulture).IsValid)
            {
                return false;
            }

            if (!notEmptyOrNullStringValidationRule.Validate(MaxBrzina, CultureInfo.CurrentCulture).IsValid)
            {
                return false;
            }

            if (!notEmptyOrNullStringValidationRule.Validate(Duzina, CultureInfo.CurrentCulture).IsValid)
            {
                return false;
            }

            if (!notEmptyOrNullStringValidationRule.Validate(Sirina, CultureInfo.CurrentCulture).IsValid)
            {
                return false;
            }

            if (!notEmptyOrNullStringValidationRule.Validate(BrPutnika, CultureInfo.CurrentCulture).IsValid)
            {
                return false;
            }

            if (!notEmptyOrNullStringValidationRule.Validate(BrOsoblja, CultureInfo.CurrentCulture).IsValid)
            {
                return false;
            }

            return true;
        }
    }
}
