using System;
using System.Windows;
using System.Windows.Controls;
using WpfUI.Model;
using WpfUI.ViewModel;

namespace WpfUI.View
{
    /// <summary>
    /// Interaction logic for PosadaView.xaml
    /// </summary>
    public partial class PosadaView : UserControl
    {
        public PosadaView()
        {
            InitializeComponent();
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            var posada = DatabaseCommunicationProvider.Instance.GetPosada(((sender as Button).CommandParameter as Guid?).Value);
            _ = new EditPosadaView
            {
                DataContext = new EditPosadaViewModel(posada),
                Owner = Window.GetWindow(this)
            }.ShowDialog();

            var posadaViewModel = DataContext as PosadaViewModel;
            posadaViewModel.Posade = posadaViewModel.Posade;
        }
    }
}
