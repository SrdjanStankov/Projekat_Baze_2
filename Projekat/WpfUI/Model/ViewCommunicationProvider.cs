using System;

namespace WpfUI.Model
{
    public class ViewCommunicationProvider
    {
        public static ViewCommunicationProvider Instance { get; } = new ViewCommunicationProvider();

        public event Action AddMornarEvent;
        public event Action AddKormilarEvent;
        public event Action AddBrodogradilisteEvent;
        public event Action AddBrodskaLinijaEvent;
        public event Action AddBrodEvent;
        public event Action AddKapetanEvent;
        public event Action AddTeretniBrodEvent;
        public event Action AddTankerEvent;
        public event Action AddKruzerEvent;
        public event Action AddPosadaEvent;
        public event Action<string> AddMornarToPosadaEvent;

        public void RaiseAddBrodogradilisteEvent() => AddBrodogradilisteEvent?.Invoke();
        public void RaiseAddKormilarEvent() => AddKormilarEvent?.Invoke();
        public void RaiseAddMornarEvent() => AddMornarEvent?.Invoke();
        public void RaiseAddBrodskaLinijaEvent() => AddBrodskaLinijaEvent?.Invoke();
        public void RaiseAddBrodEvent() => AddBrodEvent?.Invoke();
        public void RaiseAddKapetanEvent() => AddKapetanEvent?.Invoke();
        public void RaiseAddTeretniBrodEvent() => AddTeretniBrodEvent?.Invoke();
        public void RaiseAddTankerEvent() => AddTankerEvent?.Invoke();
        public void RaiseAddKruzerEvent() => AddKruzerEvent?.Invoke();
        public void RaiseAddPosadaEvent() => AddPosadaEvent?.Invoke();
        public void RaiseAddMornarToPosadaEvent(string mornarJmbg) => AddMornarToPosadaEvent?.Invoke(mornarJmbg);
    }
}
