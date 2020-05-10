using System;
using System.Collections.ObjectModel;
using Common.Models;
using WpfUI.Model;

namespace WpfUI.ViewModel
{
    public class KapetanViewModel : BindableBase
    {
        private ObservableCollection<Kapetan> kapetani;

        public ObservableCollection<Kapetan> Kapetani
        {
            get => new ObservableCollection<Kapetan>(DatabaseCommunicationProvider.Instance.GetKapetani());
            set
            {
                kapetani = value;
                OnPropertyChanged(nameof(Kapetani));
            }
        }
        public Command<string> RemoveCommand { get; set; }
        public Command AddCommand { get; set; }

        public KapetanViewModel()
        {
            RemoveCommand = new Command<string>(OnRemove);
            AddCommand = new Command(() => ViewCommunicationProvider.Instance.RaiseAddKapetanEvent());
        }

        private void OnRemove(string jmbg)
        {
            DatabaseCommunicationProvider.Instance.RemoveKapetan(jmbg);
            SnackbarMessageProvider.Instance.Enqueue("Kapetan obrisan", true);
            Kapetani = Kapetani;
        }
    }
}
