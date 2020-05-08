﻿using System;

namespace WpfUI.Model
{
    public class ViewCommunicationProvider
    {
        public static ViewCommunicationProvider Instance { get; } = new ViewCommunicationProvider();

        public event Action AddMornarEvent;
        public event Action AddKormilarEvent;
        public event Action AddBrodogradilisteEvent;
        public event Action AddBrodskaLinijaEvent;

        public void RaiseAddBrodogradilisteEvent() => AddBrodogradilisteEvent?.Invoke();
        public void RaiseAddKormilarEvent() => AddKormilarEvent?.Invoke();
        public void RaiseAddMornarEvent() => AddMornarEvent?.Invoke();
        public void RaiseAddBrodskaLinijaEvent() => AddBrodskaLinijaEvent?.Invoke();
    }
}
