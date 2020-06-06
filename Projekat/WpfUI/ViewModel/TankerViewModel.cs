using System;
using System.Collections.ObjectModel;
using Common.Models;
using WpfUI.Model;

namespace WpfUI.ViewModel
{
    public class TankerViewModel : BindableBase
    {
        private ObservableCollection<Tanker> brodovi;

        public ObservableCollection<Tanker> Brodovi
        {
            get => new ObservableCollection<Tanker>(DatabaseCommunicationProvider.Instance.GetTankeri());
            set
            {
                brodovi = value;
                OnPropertyChanged(nameof(Brodovi));
            }
        }
        public Command<Guid> RemoveCommand { get; set; }
        public Command AddCommand { get; set; }

        public TankerViewModel()
        {
            RemoveCommand = new Command<Guid>(OnRemove);
            AddCommand = new Command(() => ViewCommunicationProvider.Instance.RaiseAddTankerEvent());
        }

        private void OnRemove(Guid id)
        {
            if (DatabaseCommunicationProvider.Instance.RemoveTanker(id))
            {
                SnackbarMessageProvider.Instance.Enqueue("Tanker obrisan");
            }
            else
            {
                SnackbarMessageProvider.Instance.Enqueue("Nemoguce obrisati tanker");
            }
            Brodovi = Brodovi;
        }
    }
}
