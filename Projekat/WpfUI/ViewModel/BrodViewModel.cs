using System;
using System.Collections.ObjectModel;
using Common.Models;
using WpfUI.Model;

namespace WpfUI.ViewModel
{
    public class BrodViewModel : BindableBase
    {
        private ObservableCollection<Brod> brodovi;

        public ObservableCollection<Brod> Brodovi
        {
            get => new ObservableCollection<Brod>(DatabaseCommunicationProvider.Instance.GetBrodovi());
            set
            {
                brodovi = value;
                OnPropertyChanged(nameof(Brodovi));
            }
        }
        public Command<Guid> RemoveCommand { get; set; }
        public Command AddCommand { get; set; }

        public BrodViewModel()
        {
            RemoveCommand = new Command<Guid>(OnRemove);
            AddCommand = new Command(() => ViewCommunicationProvider.Instance.RaiseAddBrodEvent());
        }

        private void OnRemove(Guid id)
        {
            if(DatabaseCommunicationProvider.Instance.RemoveBrod(id))
            {
                SnackbarMessageProvider.Instance.Enqueue("Brod obrisan");
            }
            else
            {
                SnackbarMessageProvider.Instance.Enqueue("Nemoguce obrisati brod");
            }
            Brodovi = Brodovi;
        }
    }
}
