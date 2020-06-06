using System;
using System.Collections.ObjectModel;
using Common.Models;
using WpfUI.Model;

namespace WpfUI.ViewModel
{
    public class BrodogradilisteViewModel : BindableBase
    {
        private ObservableCollection<Brodogradiliste> brodogradilista;

        public ObservableCollection<Brodogradiliste> Brodogradilista
        {
            get => new ObservableCollection<Brodogradiliste>(DatabaseCommunicationProvider.Instance.GetBrodogradilista());
            set
            {
                brodogradilista = value;
                OnPropertyChanged(nameof(Brodogradilista));
            }
        }
        public Command<Guid> RemoveCommand { get; set; }
        public Command AddCommand { get; set; }

        public BrodogradilisteViewModel()
        {
            RemoveCommand = new Command<Guid>(OnRemove);
            AddCommand = new Command(() => ViewCommunicationProvider.Instance.RaiseAddBrodogradilisteEvent());
        }

        private void OnRemove(Guid idBrodogradiliste)
        {
            if(DatabaseCommunicationProvider.Instance.RemoveBrodogradiliste(idBrodogradiliste))
            {
                SnackbarMessageProvider.Instance.Enqueue("Brodogradiliste obrisano");
            }
            else
            {
                SnackbarMessageProvider.Instance.Enqueue("Nemoguce obrisati brodogradiliste");
            }
            Brodogradilista = Brodogradilista;
        }
    }
}
