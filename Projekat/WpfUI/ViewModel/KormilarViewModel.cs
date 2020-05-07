using System.Collections.ObjectModel;
using Common.Models;
using WpfUI.Model;
using WpfUI.View;

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
        public Command<string> EditCommand { get; set; }
        public Command<string> RemoveCommand { get; set; }


        public KormilarViewModel()
        {
            EditCommand = new Command<string>(OnEdit);
            RemoveCommand = new Command<string>(OnRemove);
        }

        private void OnRemove(string jmbg)
        {
            DatabaseCommunicationProvider.Instance.RemoveKormilar(jmbg);
            SnackbarMessageProvider.Instance.Enqueue("Kormilar obrisan", true);
        }

        private void OnEdit(string jmbg)
        {
            var kormilar = DatabaseCommunicationProvider.Instance.GetKormilar(jmbg);
            var window = new EditKormilarView
            {
                DataContext = new EditKormilarViewModel(kormilar)
            };
            window.ShowDialog();
            Kormilari = Kormilari;
        }
    }
}
