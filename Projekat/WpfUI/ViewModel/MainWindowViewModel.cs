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

        public Command AddBrodCommand { get; set; }
        public Command AddKapetanCommand { get; set; }
        public Command AddTeretniBrodCommand { get; set; }
        public Command AddTankerCommand { get; set; }
        public Command AddKruzerCommand { get; set; }
        public Command AddPosadaCommand { get; set; }

        public Command KormilarCommand { get; set; }
        public Command MornarCommand { get; set; }
        public Command BrodogradilisteCommand { get; set; }
        public Command BrodskaLinijaCommand { get; set; }
        public Command BrodCommand { get; set; }

        public SnackbarMessageQueue MessageQueue { get; set; }

        public BindableBase CurrentViewModel
        {
            get => currentViewModel;
            set => SetProperty(ref currentViewModel, value);
        }

        public MainWindowViewModel()
        {
            CurrentViewModel = addKormilarVewModel;
            AddKapetanCommand = new Command(() => CurrentViewModel = addKapetanViewModel);
            AddTeretniBrodCommand = new Command(() => CurrentViewModel = addTeretniBrodViewModel);
            AddTankerCommand = new Command(() => CurrentViewModel = addTankerViewModel);
            AddKruzerCommand = new Command(() => CurrentViewModel = addKruzerViewModel);
            AddPosadaCommand = new Command(() => CurrentViewModel = addPosadaViewModel);

            KormilarCommand = new Command(() => CurrentViewModel = kormilarViewModel);
            MornarCommand = new Command(() => CurrentViewModel = mornarViewModel);
            BrodogradilisteCommand = new Command(() => CurrentViewModel = brodogradilisteViewModel);
            BrodskaLinijaCommand = new Command(() => CurrentViewModel = brodskaLinijaViewModel);
            BrodCommand = new Command(() => CurrentViewModel = brodViewModel);

            MessageQueue = SnackbarMessageProvider.Instance.MessageQueue;

            ViewCommunicationProvider.Instance.AddKormilarEvent += () => CurrentViewModel = addKormilarVewModel;
            ViewCommunicationProvider.Instance.AddMornarEvent += () => CurrentViewModel = addMornarViewModel;
            ViewCommunicationProvider.Instance.AddBrodogradilisteEvent += () => CurrentViewModel = addBrodogradilisteViewModel;
            ViewCommunicationProvider.Instance.AddBrodskaLinijaEvent += () => CurrentViewModel = addBrodskaLinijaViewModel;
            ViewCommunicationProvider.Instance.AddBrodEvent += () => CurrentViewModel = addBrodViewModel;
        }
    }
}
