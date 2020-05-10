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
            var Brod = DatabaseCommunicationProvider.Instance.GetBrod(((sender as Button).CommandParameter as Guid?).Value);
            _ = new EditBrodView
            {
                DataContext = new EditBrodViewModel(Brod),
                Owner = Window.GetWindow(this)
            }.ShowDialog();

            var mornarViewModel = (DataContext as BrodViewModel);
            mornarViewModel.Brodovi = mornarViewModel.Brodovi;
        }
    }
}
