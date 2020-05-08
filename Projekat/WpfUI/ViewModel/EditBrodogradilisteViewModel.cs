using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using Common.Models;
using WpfUI.Model;
using WpfUI.Model.ValidationRules;

namespace WpfUI.ViewModel
{
    public class EditBrodogradilisteViewModel : BindableBase
    {
        private Guid id;
        private int brNapr;

        public string Naziv { get; set; }
        public string Lokacija { get; set; }
        public int BrPristanista { get; set; }
        public bool PosSuviDok { get; set; }

        public Command<Window> EditCommand { get; set; }


        public EditBrodogradilisteViewModel()
        {
            EditCommand = new Command<Window>(OnEdit);
        }

        public EditBrodogradilisteViewModel(Brodogradiliste brodogradiliste) : this()
        {
            id = brodogradiliste.ID;
            Naziv = brodogradiliste.Naziv;
            Lokacija = brodogradiliste.Lokacija;
            BrPristanista = brodogradiliste.BrPrist;
            brNapr = brodogradiliste.BrNaprBrod;
            PosSuviDok = brodogradiliste.PosedSuvDok;
        }

        private void OnEdit(Window w)
        {
            if (!IsValid())
            {
                return;
            }

            DatabaseCommunicationProvider.Instance.EditBrodogradiliste(new Brodogradiliste(id, Naziv, Lokacija, brNapr, BrPristanista, PosSuviDok));
            w.Close();
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
