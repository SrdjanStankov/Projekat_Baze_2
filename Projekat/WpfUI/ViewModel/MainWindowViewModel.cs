using System;
using MaterialDesignThemes.Wpf;
using WpfUI.Model;

namespace WpfUI.ViewModel
{
    public class MainWindowViewModel : BindableBase
    {
        private BindableBase currentViewModel;

        private AddKormilarVewModel kormilarVewModel = new AddKormilarVewModel();
        private AddMornarViewModel mornarViewModel = new AddMornarViewModel();
        private AddBrodogradilisteViewModel brodogradilisteViewModel = new AddBrodogradilisteViewModel();
        private AddBrodskaLinijaViewModel brodskaLinijaViewModel = new AddBrodskaLinijaViewModel();
        private AddBrodViewModel brodViewModel = new AddBrodViewModel();
        private AddKapetanViewModel kapetanViewModel = new AddKapetanViewModel();
        private AddTeretniBrodViewModel teretniBrodViewModel = new AddTeretniBrodViewModel();
        private AddTankerViewModel tankerViewModel = new AddTankerViewModel();
        private AddKruzerViewModel kruzerViewModel = new AddKruzerViewModel();
        private AddPosadaViewModel posadaViewModel = new AddPosadaViewModel();

        public Command KormilarCommand { get; set; }
        public Command MornarCommand { get; set; }
        public Command BrodogradilisteCommand { get; set; }
        public Command BrodskaLinijaCommand { get; set; }
        public Command BrodCommand { get; set; }
        public Command KapetanCommand { get; set; }
        public Command TeretniBrodCommand { get; set; }
        public Command TankerCommand { get; set; }
        public Command KruzerCommand { get; set; }
        public Command PosadaCommand { get; set; }
        public SnackbarMessageQueue MessageQueue { get; set; }

        public BindableBase CurrentViewModel
        {
            get => currentViewModel;
            set => SetProperty(ref currentViewModel, value);
        }

        public MainWindowViewModel()
        {
            CurrentViewModel = kormilarVewModel;
            KormilarCommand = new Command(OnKormilar);
            MornarCommand = new Command(OnMornar);
            BrodogradilisteCommand = new Command(OnBrodogradiliste);
            BrodskaLinijaCommand = new Command(OnBrodskaLinija);
            BrodCommand = new Command(OnBrod);
            KapetanCommand = new Command(OnKapetan);
            TeretniBrodCommand = new Command(OnTeretniBrod);
            TankerCommand = new Command(OnTanker);
            KruzerCommand = new Command(OnKruzer);
            PosadaCommand = new Command(OnPosada);
            MessageQueue = SnackbarMessageProvider.Instance.MessageQueue;
        }

        private void OnPosada() => CurrentViewModel = posadaViewModel;

        private void OnKruzer() => CurrentViewModel = kruzerViewModel;

        private void OnTanker() => CurrentViewModel = tankerViewModel;

        private void OnTeretniBrod() => CurrentViewModel = teretniBrodViewModel;

        private void OnKapetan() => CurrentViewModel = kapetanViewModel;

        private void OnBrod() => CurrentViewModel = brodViewModel;

        private void OnBrodskaLinija() => CurrentViewModel = brodskaLinijaViewModel;

        private void OnBrodogradiliste() => CurrentViewModel = brodogradilisteViewModel;

        private void OnMornar() => CurrentViewModel = mornarViewModel;

        private void OnKormilar() => CurrentViewModel = kormilarVewModel;
    }
}
