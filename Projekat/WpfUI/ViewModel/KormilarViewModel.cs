using System.Collections.ObjectModel;
using System.Windows;
using Common.Models;
using WpfUI.Model;

namespace WpfUI.ViewModel
{
    public class KormilarViewModel : BindableBase
    {
        private ObservableCollection<Kormilar> kormilari;

        public ObservableCollection<Kormilar> Kormilari { get => new ObservableCollection<Kormilar>(CommunicationProvider.Instance.GetKormilari()); set => kormilari = value; }
        public Command<string> EditCommand { get; set; }
        public Command<string> RemoveCommand { get; set; }


        public KormilarViewModel()
        {
            EditCommand = new Command<string>(OnEdit);
            RemoveCommand = new Command<string>(OnRemove);
        }

        private void OnRemove(string jmbg)
        {
            CommunicationProvider.Instance.RemoveKormilar(jmbg);
            SnackbarMessageProvider.Instance.Enqueue("Kormilar obrisan", true);
        }

        private void OnEdit(string jmbg) => MessageBox.Show(jmbg);
    }
}
