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
        internal IEnumerable<BrodskaLinija> GetBrodskeLinije() => proxy.GetBrodskeLinije();
        internal IEnumerable<Brodogradiliste> GetBrodogradilista() => proxy.GetBrodogradilsta();
        internal IEnumerable<Brod> GetBrodovi() => proxy.GetBrodovi();
        internal bool AddKapetan(Kapetan kapetan, Guid brojLinije, Guid idBroda) => proxy.AddKapetan(kapetan, brojLinije, idBroda);
        internal bool AddTeretniBrod(TeretniBrod teretniBrod, Guid idBrodogradilista) => proxy.AddTeretniBrod(teretniBrod, idBrodogradilista);
        internal bool AddTanker(Tanker tanker, Guid idBrodogradilista) => proxy.AddTanker(tanker, idBrodogradilista);
    }
}
