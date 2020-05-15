using System;
using System.Windows;
using System.Windows.Controls;
using WpfUI.Model;
using WpfUI.ViewModel;

namespace WpfUI.View
{
    /// <summary>
    /// Interaction logic for BrodView.xaml
    /// </summary>
    public partial class BrodView : UserControl
    {
        public BrodView()
        {
            InitializeComponent();
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            var brod = DatabaseCommunicationProvider.Instance.GetBrod(((sender as Button).CommandParameter as Guid?).Value);
            _ = new EditBrodView
            {
                DataContext = new EditBrodViewModel(brod),
                Owner = Window.GetWindow(this)
            }.ShowDialog();

            RefreshTable();
        }

        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            var brod = DatabaseCommunicationProvider.Instance.GetBrod(((sender as Button).CommandParameter as Guid?).Value);
            _ = new AddBrodToLinija
            {
                DataContext = new AddBrodToLinijaViewModel(brod.ID, brod.BrodskaLinija),
                Owner = Window.GetWindow(this)
            }.ShowDialog();

            RefreshTable();
        }

        private void RefreshTable()
        {
            var mornarViewModel = DataContext as BrodViewModel;
            mornarViewModel.Brodovi = mornarViewModel.Brodovi;
        }
    }
}
