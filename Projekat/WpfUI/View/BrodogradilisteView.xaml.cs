using System;
using System.Windows;
using System.Windows.Controls;
using WpfUI.Model;
using WpfUI.ViewModel;

namespace WpfUI.View
{
    /// <summary>
    /// Interaction logic for BrodogradilisteView.xaml
    /// </summary>
    public partial class BrodogradilisteView : UserControl
    {
        public BrodogradilisteView()
        {
            InitializeComponent();
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            var brodogradiliste = DatabaseCommunicationProvider.Instance.GetBrodogradiliste(((sender as Button).CommandParameter as Guid?).Value);
            _ = new EditBrodogradililsteView
            {
                DataContext = new EditBrodogradilisteViewModel(brodogradiliste),
                Owner = Window.GetWindow(this)
            }.ShowDialog();

            var brodogradilisteViewModel = (DataContext as BrodogradilisteViewModel);
            brodogradilisteViewModel.Brodogradilista = brodogradilisteViewModel.Brodogradilista;
        }
    }
}
