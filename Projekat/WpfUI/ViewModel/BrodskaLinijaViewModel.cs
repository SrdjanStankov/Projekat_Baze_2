using System;
using System.Collections.ObjectModel;
using Common.Models;
using WpfUI.Model;

namespace WpfUI.ViewModel
{
    public class BrodskaLinijaViewModel : BindableBase
    {
        private ObservableCollection<BrodskaLinija> linije;

        public ObservableCollection<BrodskaLinija> Linije
        {
            get => new ObservableCollection<BrodskaLinija>(DatabaseCommunicationProvider.Instance.GetBrodskeLinije());
            set
            {
                linije = value;
                OnPropertyChanged(nameof(Linije));
            }
        }
        public Command<Guid> RemoveCommand { get; set; }
        public Command AddCommand { get; set; }

        public BrodskaLinijaViewModel()
        {
            RemoveCommand = new Command<Guid>(OnRemove);
            AddCommand = new Command(() => ViewCommunicationProvider.Instance.RaiseAddBrodskaLinijaEvent());
        }

        private void OnRemove(Guid id)
        {
            DatabaseCommunicationProvider.Instance.RemoveBrodskaLinija(id);
            SnackbarMessageProvider.Instance.Enqueue("Brodska linija obrisana", true);
            Linije = Linije;
        }
    }
}
