using System;
using System.Collections.Generic;
using System.ServiceModel;
using Common;
using Common.Models;

namespace WpfUI.Model
{
    public class DatabaseCommunicationProvider
    {
        public static DatabaseCommunicationProvider Instance { get; } = new DatabaseCommunicationProvider();

        private IBrodOperations proxy;

        private DatabaseCommunicationProvider()
        {
            proxy = new ChannelFactory<IBrodOperations>("Client").CreateChannel();
        }

        internal IEnumerable<TeretniBrod> GetTeretniBrodovi() => proxy.GetTeretniBrodovi();
        internal Kapetan GetKapetan(string jmbg) => proxy.GetKapetan(jmbg);
        internal bool AddKormilar(Kormilar kormilar) => proxy.AddKormilar(kormilar);
        internal Brod GetBrod(Guid id) => proxy.GetBrod(id);
        internal Brodogradiliste GetBrodogradiliste(Guid guid) => proxy.GetBrodogradiliste(guid);
        internal TeretniBrod GetTeretniBrod(Guid id) => proxy.GetTeretniBrod(id);
        internal bool AddMornar(Mornar mornar) => proxy.AddMornar(mornar);
        internal bool AddBrodogradiliste(Brodogradiliste brodogradiliste) => proxy.AddBrodogradiliste(brodogradiliste);
        internal void RemoveTeretniBrod(Guid id) => proxy.RemoveTeretniBrod(id);
        internal BrodskaLinija GetBrodskaLinija(Guid id) => proxy.GetBrodskaLinija(id);
        internal void RemoveKapetan(string jmbg) => proxy.RemoveKapetan(jmbg);
        internal void EditTeretniBrod(TeretniBrod teretniBrod) => proxy.EditTeretniBrod(teretniBrod);
        internal void RemoveBrod(Guid id) => proxy.RemoveBrod(id);
        internal bool AddBrodskaLinija(BrodskaLinija brodskaLinija) => proxy.AddBrodskaLinija(brodskaLinija);
        internal void EditBrod(Brod brod) => proxy.EditBrod(brod);
        internal void RemoveBrodskaLinija(Guid id) => proxy.RemoveBrodskaLinija(id);
        internal void EditKapetan(Kapetan kapetan) => proxy.EditKapetan(kapetan);
        internal Mornar GetMornar(string jmbg) => proxy.GetMornar(jmbg);
        internal void RemoveMornar(string jmbg) => proxy.RemoveMornar(jmbg);
        internal void EditBrodskaLinija(BrodskaLinija brodskaLinija) => proxy.EditBrodskaLinija(brodskaLinija);
        internal void RemoveKormilar(string jmbg) => proxy.RemoveKormilar(jmbg);
        internal bool AddBrod(Brod brod, Guid idBrodogradilista) => proxy.AddBrod(brod, idBrodogradilista);
        internal void EditBrodogradiliste(Brodogradiliste brodogradiliste) => proxy.EditBrodogradiliste(brodogradiliste);
        internal void RemoveBrodogradiliste(Guid idBrodogradililste) => proxy.RemoveBrodogradiliste(idBrodogradililste);
        internal Kormilar GetKormilar(string jmbg) => proxy.GetKormilar(jmbg);
        internal IEnumerable<BrodskaLinija> GetBrodskeLinije() => proxy.GetBrodskeLinije();
        internal IEnumerable<Brodogradiliste> GetBrodogradilista() => proxy.GetBrodogradilsta();
        internal void EditKormilar(Kormilar kormilar) => proxy.EditKormilar(kormilar);
        internal void EditMornar(Mornar mornar) => proxy.EditMornar(mornar);
        internal IEnumerable<Brod> GetBrodovi() => proxy.GetBrodovi();
        internal IEnumerable<Kormilar> GetKormilari() => proxy.GetKormilari();
        internal IEnumerable<Kapetan> GetKapetani() => proxy.GetKapetani();
        internal IEnumerable<Mornar> GetMornari() => proxy.GetMornari();
        internal bool AddKapetan(Kapetan kapetan, Guid brojLinije, Guid idBroda) => proxy.AddKapetan(kapetan, brojLinije, idBroda);
        internal bool AddTeretniBrod(TeretniBrod teretniBrod, Guid idBrodogradilista) => proxy.AddTeretniBrod(teretniBrod, idBrodogradilista);
        internal bool AddTanker(Tanker tanker, Guid idBrodogradilista) => proxy.AddTanker(tanker, idBrodogradilista);
        internal bool AddKruzer(Kruzer kruzer, Guid idBrodogradilista) => proxy.AddKruzer(kruzer, idBrodogradilista);
        internal bool AddPosada(Posada posada, string jmbgKormilar, string jmbgKapetan, Guid idBrod) => proxy.AddPosada(posada, jmbgKormilar, jmbgKapetan, idBrod);
    }
}
