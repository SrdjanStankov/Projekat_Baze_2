using System;
using System.Windows;
using System.Windows.Controls;
using WpfUI.Model;
using WpfUI.ViewModel;

namespace WpfUI.View
{
    /// <summary>
    /// Interaction logic for BrodskaLinijaView.xaml
    /// </summary>
    public partial class BrodskaLinijaView : UserControl
    {
        public BrodskaLinijaView()
        {
            InitializeComponent();
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            var linija = DatabaseCommunicationProvider.Instance.GetBrodskaLinija(((sender as Button).CommandParameter as Guid?).Value);
            _ = new EditBrodskaLinijaView
            {
                DataContext = new EditBrodskaLinijaViewModel(linija),
                Owner = Window.GetWindow(this)
            }.ShowDialog();

            var brodskaLinijaViewModel = (DataContext as BrodskaLinijaViewModel);
            brodskaLinijaViewModel.Linije = brodskaLinijaViewModel.Linije;
        }
    }
}
