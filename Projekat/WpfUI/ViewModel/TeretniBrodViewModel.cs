using System;
using System.Collections.ObjectModel;
using Common.Models;
using WpfUI.Model;

namespace WpfUI.ViewModel
{
    public class TeretniBrodViewModel : BindableBase
    {
        private ObservableCollection<TeretniBrod> brodovi;

        public ObservableCollection<TeretniBrod> Brodovi
        {
            get => new ObservableCollection<TeretniBrod>(DatabaseCommunicationProvider.Instance.GetTeretniBrodovi());
            set
            {
                brodovi = value;
                OnPropertyChanged(nameof(Brodovi));
            }
        }
        public Command<Guid> RemoveCommand { get; set; }
        public Command AddCommand { get; set; }

        public TeretniBrodViewModel()
        {
            RemoveCommand = new Command<Guid>(OnRemove);
            AddCommand = new Command(() => ViewCommunicationProvider.Instance.RaiseAddTeretniBrodEvent());
        }

        private void OnRemove(Guid id)
        {
            DatabaseCommunicationProvider.Instance.RemoveTeretniBrod(id);
            SnackbarMessageProvider.Instance.Enqueue("Teretni Brod obrisan", true);
            Brodovi = Brodovi;
        }
    }
}
