using System.Threading.Tasks;
using System.Windows;
using WpfUI.Model;

namespace WpfUI
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }

        private async void Window_Activated(object sender, System.EventArgs e)
        {
            SnackbarMessageProvider.Instance.Enqueue("Connecting with server . . .");
            _ = await Task.Run(DatabaseCommunicationProvider.Instance.GetKapetani);
            SnackbarMessageProvider.Instance.Enqueue("Connected!");
        }
    }
}
