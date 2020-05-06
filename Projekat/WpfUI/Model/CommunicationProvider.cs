﻿using System.ServiceModel;
using Common;
using Common.Models;

namespace WpfUI.Model
{
    public class CommunicationProvider
    {
        public static CommunicationProvider Instance { get; } = new CommunicationProvider();

        private IBrodOperations proxy;

        private CommunicationProvider()
        {
            proxy = new ChannelFactory<IBrodOperations>("Client").CreateChannel();
        }

        public bool AddKormilar(Kormilar kormilar) => proxy.AddKormilar(kormilar);

        public bool AddMornar(Mornar mornar) => proxy.AddMornar(mornar);
        internal bool AddBrodogradiliste(Brodogradiliste brodogradiliste) => proxy.AddBrodogradiliste(brodogradiliste);
        internal bool AddBrodskaLinija(BrodskaLinija brodskaLinija) => proxy.AddBrodskaLinija(brodskaLinija);
    }
}
