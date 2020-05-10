using System;
using System.Collections.ObjectModel;
using Common.Models;
using WpfUI.Model;

namespace WpfUI.ViewModel
{
    public class KruzerViewModel : BindableBase
    {
        private ObservableCollection<Kruzer> brodovi;

        public ObservableCollection<Kruzer> Brodovi
        {
            get => new ObservableCollection<Kruzer>(DatabaseCommunicationProvider.Instance.GetKruzeri());
            set
            {
                brodovi = value;
                OnPropertyChanged(nameof(Brodovi));
            }
        }
        public Command<Guid> RemoveCommand { get; set; }
        public Command AddCommand { get; set; }

        public KruzerViewModel()
        {
            RemoveCommand = new Command<Guid>(OnRemove);
            AddCommand = new Command(() => ViewCommunicationProvider.Instance.RaiseAddKruzerEvent());
        }

        private void OnRemove(Guid id)
        {
            DatabaseCommunicationProvider.Instance.RemoveKruzer(id);
            SnackbarMessageProvider.Instance.Enqueue("Kruzer obrisan", true);
            Brodovi = Brodovi;
        }
    }
}
