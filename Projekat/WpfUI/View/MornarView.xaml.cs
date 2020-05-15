using System.Windows;
using System.Windows.Controls;
using WpfUI.Model;
using WpfUI.ViewModel;

namespace WpfUI.View
{
    /// <summary>
    /// Interaction logic for MornarView.xaml
    /// </summary>
    public partial class MornarView : UserControl
    {
        public MornarView()
        {
            InitializeComponent();
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            var mornar = DatabaseCommunicationProvider.Instance.GetMornar((sender as Button).CommandParameter as string);
            _ = new EditMornarView
            {
                DataContext = new EditMornarViewModel(mornar),
                Owner = Window.GetWindow(this)
            }.ShowDialog();

            RefreshTable();
        }

        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            var mornar = DatabaseCommunicationProvider.Instance.GetMornar((sender as Button).CommandParameter as string);
            _ = new AddMornarToPosadaView
            {
                DataContext = new AddMornarToPosadaViewModel(mornar.JMBG, mornar.Posada),
                Owner = Window.GetWindow(this)
            }.ShowDialog();

            RefreshTable();
        }

        private void Button_Click_2(object sender, RoutedEventArgs e)
        {
            var mornar = DatabaseCommunicationProvider.Instance.GetMornar((sender as Button).CommandParameter as string);
            _ = new AddMornarToTeretniBrod
            {
                DataContext = new ViewModel.AddMornarToTeretniBrod(mornar.JMBG, mornar.TeretniBrod),
                Owner = Window.GetWindow(this)
            }.ShowDialog();

            RefreshTable();
        }

        private void RefreshTable()
        {
            var mornarViewModel = DataContext as MornarViewModel;
            mornarViewModel.Mornari = mornarViewModel.Mornari;
        }
    }
}
