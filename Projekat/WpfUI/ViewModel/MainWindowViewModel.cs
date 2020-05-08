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

        public Command AddKormilarCommand { get; set; }
        public Command AddMornarCommand { get; set; }
        public Command AddBrodogradilisteCommand { get; set; }
        public Command AddBrodskaLinijaCommand { get; set; }
        public Command AddBrodCommand { get; set; }
        public Command AddKapetanCommand { get; set; }
        public Command AddTeretniBrodCommand { get; set; }
        public Command AddTankerCommand { get; set; }
        public Command AddKruzerCommand { get; set; }
        public Command AddPosadaCommand { get; set; }

        public Command KormilarCommand { get; set; }
        public Command MornarCommand { get; set; }
        public SnackbarMessageQueue MessageQueue { get; set; }

        public BindableBase CurrentViewModel
        {
            get => currentViewModel;
            set => SetProperty(ref currentViewModel, value);
        }

        public MainWindowViewModel()
        {
            CurrentViewModel = addKormilarVewModel;
            AddKormilarCommand = new Command(OnAddKormilar);
            AddMornarCommand = new Command(OnAddMornar);
            AddBrodogradilisteCommand = new Command(OnAddBrodogradiliste);
            AddBrodskaLinijaCommand = new Command(OnAddBrodskaLinija);
            AddBrodCommand = new Command(OnAddBrod);
            AddKapetanCommand = new Command(OnAddKapetan);
            AddTeretniBrodCommand = new Command(OnAddTeretniBrod);
            AddTankerCommand = new Command(OnAddTanker);
            AddKruzerCommand = new Command(OnAddKruzer);
            AddPosadaCommand = new Command(OnAddPosada);

            KormilarCommand = new Command(OnKormilar);
            MornarCommand = new Command(OnMornar);
            MessageQueue = SnackbarMessageProvider.Instance.MessageQueue;

            ViewCommunicationProvider.Instance.AddKormilarEvent += OnAddKormilar;
            ViewCommunicationProvider.Instance.AddMornarEvent += OnAddMornar;
        }

        private void OnMornar() => CurrentViewModel = mornarViewModel;
        private void OnKormilar() => CurrentViewModel = kormilarViewModel;

        private void OnAddPosada() => CurrentViewModel = addPosadaViewModel;

        private void OnAddKruzer() => CurrentViewModel = addKruzerViewModel;

        private void OnAddTanker() => CurrentViewModel = addTankerViewModel;

        private void OnAddTeretniBrod() => CurrentViewModel = addTeretniBrodViewModel;

        private void OnAddKapetan() => CurrentViewModel = addKapetanViewModel;

        private void OnAddBrod() => CurrentViewModel = addBrodViewModel;

        private void OnAddBrodskaLinija() => CurrentViewModel = addBrodskaLinijaViewModel;

        private void OnAddBrodogradiliste() => CurrentViewModel = addBrodogradilisteViewModel;

        private void OnAddMornar() => CurrentViewModel = addMornarViewModel;

        private void OnAddKormilar() => CurrentViewModel = addKormilarVewModel;
    }
}
