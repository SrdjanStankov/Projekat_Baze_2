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

        internal IEnumerable<Posada> GetPosade() => proxy.GetPosade();
        internal Posada GetPosada(Guid id) => proxy.GetPosada(id);
        internal IEnumerable<Kruzer> GetKruzeri() => proxy.GetKruzeri();
        internal Tanker GetTanker(Guid id) => proxy.GetTanker(id);
        internal IEnumerable<Tanker> GetTankeri() => proxy.GetTankeri();
        internal IEnumerable<TeretniBrod> GetTeretniBrodovi() => proxy.GetTeretniBrodovi();
        internal Kruzer GetKruzer(Guid id) => proxy.GetKruzer(id);
        internal Kapetan GetKapetan(string jmbg) => proxy.GetKapetan(jmbg);
        internal void AddMornarToPosada(string mornarJmbg, Guid selectedPosadaId) => proxy.AddMornarToPosada(mornarJmbg, selectedPosadaId);
        internal void EditPosada(Posada posada) => proxy.EditPosada(posada);
        internal void RemovePosada(Guid id) => proxy.RemovePosada(id);
        internal bool AddKormilar(Kormilar kormilar) => proxy.AddKormilar(kormilar);
        internal Brod GetBrod(Guid id) => proxy.GetBrod(id);
        internal Brodogradiliste GetBrodogradiliste(Guid guid) => proxy.GetBrodogradiliste(guid);
        internal void RemoveKruzer(Guid id) => proxy.RemoveKruzer(id);
        internal void RemoveTanker(Guid id) => proxy.RemoveTanker(id);
        internal TeretniBrod GetTeretniBrod(Guid id) => proxy.GetTeretniBrod(id);
        internal void EditKruzer(Kruzer kruzer) => proxy.EditKruzer(kruzer);
        internal bool AddMornar(Mornar mornar) => proxy.AddMornar(mornar);
        internal void EditTanker(Tanker tanker) => proxy.EditTanker(tanker);
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
