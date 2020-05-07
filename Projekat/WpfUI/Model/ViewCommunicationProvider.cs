using System;

namespace WpfUI.Model
{
    public class ViewCommunicationProvider
    {
        public static ViewCommunicationProvider Instance { get; } = new ViewCommunicationProvider();

        public event Action AddKormilarEvent;

        public void RaiseAddKormilarEvent() => AddKormilarEvent?.Invoke();
    }
}
