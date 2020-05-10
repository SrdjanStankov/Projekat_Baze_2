using System;
using System.Windows;
using System.Windows.Controls;
using WpfUI.Model;
using WpfUI.ViewModel;

namespace WpfUI.View
{
    /// <summary>
    /// Interaction logic for KruzerView.xaml
    /// </summary>
    public partial class KruzerView : UserControl
    {
        public KruzerView()
        {
            InitializeComponent();
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            var Brod = DatabaseCommunicationProvider.Instance.GetKruzer(((sender as Button).CommandParameter as Guid?).Value);
            _ = new EditKruzerView
            {
                DataContext = new EditKruzerViewModel(Brod),
                Owner = Window.GetWindow(this)
            }.ShowDialog();

            var kruzerViewModel = DataContext as KruzerViewModel;
            kruzerViewModel.Brodovi = kruzerViewModel.Brodovi;
        }
    }
}
