using System;
using System.Collections.ObjectModel;
using System.Windows;
using Common.Models;
using WpfUI.Model;

namespace WpfUI.ViewModel
{
    public class AddBrodToLinijaViewModel : BindableBase
    {
        private Guid brodId;

        public ObservableCollection<BrodskaLinija> Linije { get; set; }
        public BrodskaLinija SelectedLinija { get; set; }
        public int Selectedindex { get; set; }

        public Command<Window> EditCommand { get; set; }

        public AddBrodToLinijaViewModel()
        {
            EditCommand = new Command<Window>(OnEdit);
            Linije = new ObservableCollection<BrodskaLinija>(DatabaseCommunicationProvider.Instance.GetBrodskeLinije());
        }

        public AddBrodToLinijaViewModel(Guid brodId, BrodskaLinija selectedLinija) : this()
        {
            SelectedLinija = selectedLinija;
            this.brodId = brodId;
            Selectedindex = Linije.IndexOf(selectedLinija);
        }

        private void OnEdit(Window obj)
        {
            if (SelectedLinija != null)
            {
                DatabaseCommunicationProvider.Instance.AddBrodToLinija(brodId, SelectedLinija.BrojLinije);
                SnackbarMessageProvider.Instance.Enqueue($"Added brod to linija: {SelectedLinija.Naziv}");
            }
            obj.Close();
        }
    }
}
