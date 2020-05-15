using System.Collections.ObjectModel;
using System.Windows;
using Common.Models;
using WpfUI.Model;

namespace WpfUI.ViewModel
{
    public class AddMornarToPosadaViewModel : BindableBase
    {
        private string mornarJmbg;

        public ObservableCollection<Posada> Posade { get; set; }
        public Posada SelectedPosada { get; set; }
        public int Selectedindex { get; set; }

        public Command<Window> EditCommand { get; set; }

        public AddMornarToPosadaViewModel()
        {
            EditCommand = new Command<Window>(OnEdit);
            Posade = new ObservableCollection<Posada>(DatabaseCommunicationProvider.Instance.GetPosade());
        }

        public AddMornarToPosadaViewModel(string mornarJmbg, Posada selectedPosada) : this()
        {
            SelectedPosada = selectedPosada;
            this.mornarJmbg = mornarJmbg;
            Selectedindex = Posade.IndexOf(selectedPosada);
        }

        private void OnEdit(Window obj)
        {
            if (SelectedPosada != null)
            {
                DatabaseCommunicationProvider.Instance.AddMornarToPosada(mornarJmbg, SelectedPosada.ID);
                SnackbarMessageProvider.Instance.Enqueue($"Added mornar: {mornarJmbg} to posada: {SelectedPosada.Ime}");
            }
            obj.Close();
        }
    }
}
