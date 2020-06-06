using System;
using System.Collections.ObjectModel;
using Common.Models;
using WpfUI.Model;

namespace WpfUI.ViewModel
{
    public class PosadaViewModel : BindableBase
    {
        private ObservableCollection<Posada> posade;

        public ObservableCollection<Posada> Posade
        {
            get => new ObservableCollection<Posada>(DatabaseCommunicationProvider.Instance.GetPosade());
            set
            {
                posade = value;
                OnPropertyChanged(nameof(Posade));
            }
        }
        public Command<Guid> RemoveCommand { get; set; }
        public Command AddCommand { get; set; }

        public PosadaViewModel()
        {
            RemoveCommand = new Command<Guid>(OnRemove);
            AddCommand = new Command(() => ViewCommunicationProvider.Instance.RaiseAddPosadaEvent());
        }

        private void OnRemove(Guid id)
        {
            if (DatabaseCommunicationProvider.Instance.RemovePosada(id))
            {
                SnackbarMessageProvider.Instance.Enqueue("Posada obrisana");
            }
            else
            {
                SnackbarMessageProvider.Instance.Enqueue("Nemoguce obrisati posadu");
            }
            Posade = Posade;
        }
    }
}