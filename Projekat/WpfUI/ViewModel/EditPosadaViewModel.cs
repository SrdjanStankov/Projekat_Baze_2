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
    public class EditPosadaViewModel : BindableBase
    {
        private Guid id;

        public string Ime { get; set; }
        public int Kapacitet { get; set; }

        public Command<Window> EditCommand { get; set; }

        public EditPosadaViewModel()
        {
            EditCommand = new Command<Window>(OnEdit);
        }

        public EditPosadaViewModel(Posada posada) : this()
        {
            id = posada.ID;
            Ime = posada.Ime;
            Kapacitet = posada.Kapacitet;
        }

        private void OnEdit(Window w)
        {
            if (!IsValid())
            {
                return;
            }

            DatabaseCommunicationProvider.Instance.EditPosada(new Posada(id, Ime, Kapacitet));
            w.Close();
        }

        private bool IsValid()
        {
            var notEmptyOrNullStringValidationRule = new NotEmptyOrNullStringValidationRule();

            if (!notEmptyOrNullStringValidationRule.Validate(Ime, CultureInfo.CurrentCulture).IsValid)
            {
                return false;
            }

            if (!notEmptyOrNullStringValidationRule.Validate(Kapacitet, CultureInfo.CurrentCulture).IsValid)
            {
                return false;
            }

            return true;
        }
    }
}
