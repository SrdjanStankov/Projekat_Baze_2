using System;
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

        public SnackbarMessageQueue MessageQueue { get; set; }

        public BindableBase CurrentViewModel
        {
            get => currentViewModel;
            set => SetProperty(ref currentViewModel, value);
        }

        public MainWindowViewModel()
        {
            CurrentViewModel = addKormilarVewModel;
            AddBrodCommand = new Command(OnAddBrod);
            AddKapetanCommand = new Command(OnAddKapetan);
            AddTeretniBrodCommand = new Command(OnAddTeretniBrod);
            AddTankerCommand = new Command(OnAddTanker);
            AddKruzerCommand = new Command(OnAddKruzer);
            AddPosadaCommand = new Command(OnAddPosada);

            KormilarCommand = new Command(OnKormilar);
            MornarCommand = new Command(OnMornar);
            BrodogradilisteCommand = new Command(OnBrodogradiliste);
            BrodskaLinijaCommand = new Command(OnBrodskaLinija);

            MessageQueue = SnackbarMessageProvider.Instance.MessageQueue;

            ViewCommunicationProvider.Instance.AddKormilarEvent += () => CurrentViewModel = addKormilarVewModel;
            ViewCommunicationProvider.Instance.AddMornarEvent += () => CurrentViewModel = addMornarViewModel;
            ViewCommunicationProvider.Instance.AddBrodogradilisteEvent += () => CurrentViewModel = addBrodogradilisteViewModel;
            ViewCommunicationProvider.Instance.AddBrodskaLinijaEvent += () => CurrentViewModel = addBrodskaLinijaViewModel;
        }

        private void OnBrodskaLinija() => CurrentViewModel = brodskaLinijaViewModel;

        private void OnBrodogradiliste() => CurrentViewModel = brodogradilisteViewModel;

        private void OnMornar() => CurrentViewModel = mornarViewModel;

        private void OnKormilar() => CurrentViewModel = kormilarViewModel;

        private void OnAddPosada() => CurrentViewModel = addPosadaViewModel;

        private void OnAddKruzer() => CurrentViewModel = addKruzerViewModel;

        private void OnAddTanker() => CurrentViewModel = addTankerViewModel;

        private void OnAddTeretniBrod() => CurrentViewModel = addTeretniBrodViewModel;

        private void OnAddKapetan() => CurrentViewModel = addKapetanViewModel;

        private void OnAddBrod() => CurrentViewModel = addBrodViewModel;
    }
}
