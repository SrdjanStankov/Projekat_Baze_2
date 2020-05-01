using System.ServiceModel;
using System.Windows;
using Common;

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

        private void ConnectBtnClick(object sender, RoutedEventArgs e)
        {
            var factory = new ChannelFactory<ICommunication>("Client");
            var proxy = factory.CreateChannel();

            proxy.Comunicate();
        }
    }
}
