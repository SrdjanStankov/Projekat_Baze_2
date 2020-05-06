using System;
using System.Collections.Generic;
using System.ServiceModel;
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
        internal bool AddKormilar(Kormilar kormilar) => proxy.AddKormilar(kormilar);
        internal bool AddMornar(Mornar mornar) => proxy.AddMornar(mornar);
        internal bool AddBrodogradiliste(Brodogradiliste brodogradiliste) => proxy.AddBrodogradiliste(brodogradiliste);
        internal bool AddBrodskaLinija(BrodskaLinija brodskaLinija) => proxy.AddBrodskaLinija(brodskaLinija);
        internal bool AddBrod(Brod brod, Guid idBrodogradilista) => proxy.AddBrod(brod, idBrodogradilista);
        internal IEnumerable<Brodogradiliste> GetBrodogradilista() => proxy.GetBrodogradilsta();
    }
}
