using System.Collections.ObjectModel;
using Common.Models;
using WpfUI.Model;

namespace WpfUI.ViewModel
{
    public class MornarViewModel : BindableBase
    {
        private ObservableCollection<Mornar> mornari;

        public ObservableCollection<Mornar> Mornari
        {
            get => new ObservableCollection<Mornar>(DatabaseCommunicationProvider.Instance.GetMornari());
            set
            {
                mornari = value;
                OnPropertyChanged(nameof(Mornari));
            }
        }
        public Command<string> RemoveCommand { get; set; }
        public Command AddCommand { get; set; }

        public MornarViewModel()
        {
            RemoveCommand = new Command<string>(OnRemove);
            AddCommand = new Command(() => ViewCommunicationProvider.Instance.RaiseAddMornarEvent());
        }

        private void OnRemove(string jmbg)
        {
            if (DatabaseCommunicationProvider.Instance.RemoveMornar(jmbg))
            {
                SnackbarMessageProvider.Instance.Enqueue("Mornar obrisan");
            }
            else
            {
                SnackbarMessageProvider.Instance.Enqueue("Nemoguce obrisati mornara");
            }
            Mornari = Mornari;
        }
    }
}
