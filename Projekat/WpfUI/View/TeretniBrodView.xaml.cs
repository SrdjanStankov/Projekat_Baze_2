using System;
using System.Windows;
using System.Windows.Controls;
using WpfUI.Model;
using WpfUI.ViewModel;

namespace WpfUI.View
{
    /// <summary>
    /// Interaction logic for TeretniBrodView.xaml
    /// </summary>
    public partial class TeretniBrodView : UserControl
    {
        public TeretniBrodView()
        {
            InitializeComponent();
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            var Brod = DatabaseCommunicationProvider.Instance.GetTeretniBrod(((sender as Button).CommandParameter as Guid?).Value);
            _ = new EditTeretniBrodView
            {
                DataContext = new EditTeretniBrodViewModel(Brod),
                Owner = Window.GetWindow(this)
            }.ShowDialog();

            var tertniBrodViewModel = (DataContext as TeretniBrodViewModel);
            tertniBrodViewModel.Brodovi = tertniBrodViewModel.Brodovi;
        }
    }
}
