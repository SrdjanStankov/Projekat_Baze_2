using System;
using System.Collections.Generic;
using Common;
using Common.Models;

namespace Server
{
    public class Server : IBrodOperations
    {
        private MasterRepository repository = new MasterRepository(new ModelContext());

        public bool AddBrod(Common.Models.Brod brod, Guid idBrodogradiliste) => repository.BrodRepository.Add(brod, idBrodogradiliste);
        public bool AddBrodogradiliste(Common.Models.Brodogradiliste brodogradiliste) => repository.BrodogradilisteRepository.Add(brodogradiliste);
        public bool AddBrodskaLinija(BrodskaLinija brodskaLinija) => repository.BrodskaLinijaRepository.Add(brodskaLinija);
        public bool AddKapetan(Common.Models.Kapetan kapetan, Guid idBrodskaLinija, Guid idBrod) => repository.KapetanRepository.Add(kapetan, idBrodskaLinija, idBrod);
        public bool AddKormilar(Common.Models.Kormilar kormilar) => repository.KormilarRepository.Add(kormilar);
        public bool AddKruzer(Common.Models.Kruzer kruzer, Guid idBrodogradiliste) => repository.KruzerRepository.Add(kruzer, idBrodogradiliste);
        public bool AddMornar(Common.Models.Mornar mornar) => repository.MornarRepository.Add(mornar);
        public bool AddPosada(Common.Models.Posada posada, string jmbgKormilar, string jmbgKapetan, Guid idBrod) => repository.PosadaRepository.Add(posada, jmbgKormilar, jmbgKapetan, idBrod);
        public bool AddTanker(Common.Models.Tanker tanker, Guid idBrodogradiliste) => repository.TankerRepository.Add(tanker, idBrodogradiliste);
        public bool AddTeretniBrod(TeretniBrod teretniBrod, Guid idBrodogradilista) => repository.TeretniBrodRepository.Add(teretniBrod, idBrodogradilista);

        public IEnumerable<Common.Models.Brodogradiliste> GetBrodogradilsta() => repository.BrodogradilisteRepository.GetAll();
        public IEnumerable<Common.Models.Brod> GetBrodovi() => repository.BrodRepository.GetAll();
        public IEnumerable<BrodskaLinija> GetBrodskeLinije() => repository.BrodskaLinijaRepository.GetAll();
        public IEnumerable<Common.Models.Kapetan> GetKapetani() => repository.KapetanRepository.GetAll();
        public IEnumerable<Common.Models.Kormilar> GetKormilari() => repository.KormilarRepository.GetAll();
        public IEnumerable<Common.Models.Mornar> GetMornari() => repository.MornarRepository.GetAll();

        public Common.Models.Mornar GetMornar(string jmbg) => repository.MornarRepository.Get(jmbg);
        public Common.Models.Kormilar GetKormilar(string jmbg) => repository.KormilarRepository.Get(jmbg);
        public Common.Models.Brodogradiliste GetBrodogradiliste(Guid guid) => repository.BrodogradilisteRepository.Get(guid);
        public BrodskaLinija GetBrodskaLinija(Guid id) => repository.BrodskaLinijaRepository.Get(id);
        public Common.Models.Brod GetBrod(Guid id) => repository.BrodRepository.Get(id);

        public void RemoveKormilar(string jmbg) => repository.KormilarRepository.Remove(jmbg);
        public void RemoveMornar(string jmbg) => repository.MornarRepository.Remove(jmbg);
        public void RemoveBrodogradiliste(Guid idBrodogradililste) => repository.BrodogradilisteRepository.Remove(idBrodogradililste);
        public void RemoveBrodskaLinija(Guid id) => repository.BrodskaLinijaRepository.Remove(id);
        public void RemoveBrod(Guid id) => repository.BrodRepository.Remove(id);

        public void EditKormilar(Common.Models.Kormilar kormilar) => repository.KormilarRepository.Update(kormilar);
        public void EditMornar(Common.Models.Mornar mornar) => repository.MornarRepository.Update(mornar);
        public void EditBrodogradiliste(Common.Models.Brodogradiliste brodogradiliste) => repository.BrodogradilisteRepository.Update(brodogradiliste);
        public void EditBrodskaLinija(BrodskaLinija brodskaLinija) => repository.BrodskaLinijaRepository.Update(brodskaLinija);
        public void EditBrod(Common.Models.Brod brod) => repository.BrodRepository.Update(brod);
    }
}
