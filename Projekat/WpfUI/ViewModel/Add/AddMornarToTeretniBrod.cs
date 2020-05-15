using System.Collections.ObjectModel;
using System.Windows;
using Common.Models;
using WpfUI.Model;

namespace WpfUI.ViewModel
{
    public class AddMornarToTeretniBrod : BindableBase
    {
        private string mornarJmbg;

        public ObservableCollection<TeretniBrod> TeretniBrodovi { get; set; }
        public TeretniBrod SelectedBrod { get; set; }
        public int Selectedindex { get; set; }

        public Command<Window> EditCommand { get; set; }

        public AddMornarToTeretniBrod()
        {
            EditCommand = new Command<Window>(OnEdit);
            TeretniBrodovi = new ObservableCollection<TeretniBrod>(DatabaseCommunicationProvider.Instance.GetTeretniBrodovi());
        }

        public AddMornarToTeretniBrod(string mornarJmbg, TeretniBrod selectedBrod) : this()
        {
            SelectedBrod = selectedBrod;
            this.mornarJmbg = mornarJmbg;
            Selectedindex = TeretniBrodovi.IndexOf(selectedBrod);
        }

        private void OnEdit(Window obj)
        {
            if (SelectedBrod != null)
            {
                DatabaseCommunicationProvider.Instance.AddMoranrToTeretniBrod(mornarJmbg, SelectedBrod.ID);
                SnackbarMessageProvider.Instance.Enqueue($"Added mornar: {mornarJmbg} to brod: {SelectedBrod.Ime}");
            }
            obj.Close();
        }
    }
}
