using System.Collections.ObjectModel;
using Common.Models;
using WpfUI.Model;

namespace WpfUI.ViewModel
{
    public class KormilarViewModel : BindableBase
    {
        private ObservableCollection<Kormilar> kormilari;

        public ObservableCollection<Kormilar> Kormilari
        {
            get => new ObservableCollection<Kormilar>(DatabaseCommunicationProvider.Instance.GetKormilari());
            set
            {
                kormilari = value;
                OnPropertyChanged(nameof(Kormilari));
            }
        }
        public Command<string> RemoveCommand { get; set; }
        public Command AddCommand { get; set; }

        public KormilarViewModel()
        {
            RemoveCommand = new Command<string>(OnRemove);
            AddCommand = new Command(() => ViewCommunicationProvider.Instance.RaiseAddKormilarEvent());
        }

        private void OnRemove(string jmbg)
        {
            DatabaseCommunicationProvider.Instance.RemoveKormilar(jmbg);
            SnackbarMessageProvider.Instance.Enqueue("Kormilar obrisan", true);
        }
    }
}
