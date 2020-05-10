using MaterialDesignThemes.Wpf;
using WpfUI.Model;

namespace WpfUI.ViewModel
{
    public class MainWindowViewModel : BindableBase
    {
        private BindableBase currentViewModel;

        private AddKormilarVewModel addKormilarVewModel = new AddKormilarVewModel();
        private AddMornarViewModel addMornarViewModel = new AddMornarViewModel();
        private AddBrodogradilisteViewModel addBrodogradilisteViewModel = new AddBrodogradilisteViewModel();
        private AddBrodskaLinijaViewModel addBrodskaLinijaViewModel = new AddBrodskaLinijaViewModel();
        private AddBrodViewModel addBrodViewModel = new AddBrodViewModel();
        private AddKapetanViewModel addKapetanViewModel = new AddKapetanViewModel();
        private AddTeretniBrodViewModel addTeretniBrodViewModel = new AddTeretniBrodViewModel();
        private AddTankerViewModel addTankerViewModel = new AddTankerViewModel();
        private AddKruzerViewModel addKruzerViewModel = new AddKruzerViewModel();
        private AddPosadaViewModel addPosadaViewModel = new AddPosadaViewModel();
        private KormilarViewModel kormilarViewModel = new KormilarViewModel();
        private MornarViewModel mornarViewModel = new MornarViewModel();
        private BrodogradilisteViewModel brodogradilisteViewModel = new BrodogradilisteViewModel();
        private BrodskaLinijaViewModel brodskaLinijaViewModel = new BrodskaLinijaViewModel();
        private BrodViewModel brodViewModel = new BrodViewModel();
        private KapetanViewModel kapetanViewModel = new KapetanViewModel();
        private TeretniBrodViewModel teretniBrodViewModel = new TeretniBrodViewModel();
        private TankerViewModel tankerViewModel = new TankerViewModel();
        private KruzerViewModel kruzerViewModel = new KruzerViewModel();

        public Command AddPosadaCommand { get; set; }

        public Command KormilarCommand { get; set; }
        public Command MornarCommand { get; set; }
        public Command BrodogradilisteCommand { get; set; }
        public Command BrodskaLinijaCommand { get; set; }
        public Command BrodCommand { get; set; }
        public Command KapetanCommand { get; set; }
        public Command TeretniBrodCommand { get; set; }
        public Command TankerCommand { get; set; }
        public Command KruzerCommand { get; set; }

        public SnackbarMessageQueue MessageQueue { get; set; }

        public BindableBase CurrentViewModel
        {
            get => currentViewModel;
            set => SetProperty(ref currentViewModel, value);
        }

        public MainWindowViewModel()
        {
            CurrentViewModel = addKormilarVewModel;
            AddPosadaCommand = new Command(() => CurrentViewModel = addPosadaViewModel);

            KormilarCommand = new Command(() => CurrentViewModel = kormilarViewModel);
            MornarCommand = new Command(() => CurrentViewModel = mornarViewModel);
            BrodogradilisteCommand = new Command(() => CurrentViewModel = brodogradilisteViewModel);
            BrodskaLinijaCommand = new Command(() => CurrentViewModel = brodskaLinijaViewModel);
            BrodCommand = new Command(() => CurrentViewModel = brodViewModel);
            KapetanCommand = new Command(() => CurrentViewModel = kapetanViewModel);
            TeretniBrodCommand = new Command(() => CurrentViewModel = teretniBrodViewModel);
            TankerCommand = new Command(() => CurrentViewModel = tankerViewModel);
            KruzerCommand = new Command(() => CurrentViewModel = kruzerViewModel);

            MessageQueue = SnackbarMessageProvider.Instance.MessageQueue;

            ViewCommunicationProvider.Instance.AddKormilarEvent += () => CurrentViewModel = addKormilarVewModel;
            ViewCommunicationProvider.Instance.AddMornarEvent += () => CurrentViewModel = addMornarViewModel;
            ViewCommunicationProvider.Instance.AddBrodogradilisteEvent += () => CurrentViewModel = addBrodogradilisteViewModel;
            ViewCommunicationProvider.Instance.AddBrodskaLinijaEvent += () => CurrentViewModel = addBrodskaLinijaViewModel;
            ViewCommunicationProvider.Instance.AddBrodEvent += () => CurrentViewModel = addBrodViewModel;
            ViewCommunicationProvider.Instance.AddKapetanEvent += () => CurrentViewModel = addKapetanViewModel;
            ViewCommunicationProvider.Instance.AddTeretniBrodEvent += () => CurrentViewModel = addTeretniBrodViewModel;
            ViewCommunicationProvider.Instance.AddTankerEvent += () => CurrentViewModel = addTankerViewModel;
            ViewCommunicationProvider.Instance.AddKruzerEvent += () => CurrentViewModel = addKruzerViewModel;
        }
    }
}
