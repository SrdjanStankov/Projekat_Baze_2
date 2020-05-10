using System.Windows;
using System.Windows.Controls;
using WpfUI.Model;
using WpfUI.ViewModel;

namespace WpfUI.View
{
    /// <summary>
    /// Interaction logic for KapetanView.xaml
    /// </summary>
    public partial class KapetanView : UserControl
    {
        public KapetanView()
        {
            InitializeComponent();
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            var kapetan = DatabaseCommunicationProvider.Instance.GetKapetan((sender as Button).CommandParameter as string);
            _ = new EditKapetanView
            {
                DataContext = new EditKapetanViewModel(kapetan),
                Owner = Window.GetWindow(this)
            }.ShowDialog();

            var kapetanViewModel = (DataContext as KapetanViewModel);
            kapetanViewModel.Kapetani = kapetanViewModel.Kapetani;
        }
    }
}
