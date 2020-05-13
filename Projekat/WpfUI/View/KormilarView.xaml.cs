using System.Windows;
using System.Windows.Controls;
using WpfUI.Model;
using WpfUI.ViewModel;

namespace WpfUI.View
{
    /// <summary>
    /// Interaction logic for KormilarView.xaml
    /// </summary>
    public partial class KormilarView : UserControl
    {
        public KormilarView()
        {
            InitializeComponent();
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            var kormilar = DatabaseCommunicationProvider.Instance.GetKormilar((sender as Button).CommandParameter as string);
            _ = new EditKormilarView
            {
                DataContext = new EditKormilarViewModel(kormilar),
                Owner = Window.GetWindow(this)
            }.ShowDialog();

            var kormilarViewModel = (DataContext as KormilarViewModel);
            kormilarViewModel.Kormilari = kormilarViewModel.Kormilari;
        }
    }
}
