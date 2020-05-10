using System;
using System.Windows;
using System.Windows.Controls;
using WpfUI.Model;
using WpfUI.ViewModel;

namespace WpfUI.View
{
    /// <summary>
    /// Interaction logic for TankerView.xaml
    /// </summary>
    public partial class TankerView : UserControl
    {
        public TankerView()
        {
            InitializeComponent();
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            var Brod = DatabaseCommunicationProvider.Instance.GetTanker(((sender as Button).CommandParameter as Guid?).Value);
            _ = new EditTankerView
            {
                DataContext = new EditTankerViewModel(Brod),
                Owner = Window.GetWindow(this)
            }.ShowDialog();

            var tankerViewModel = (DataContext as TankerViewModel);
            tankerViewModel.Brodovi = tankerViewModel.Brodovi;
        }
    }
}
