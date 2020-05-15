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
        public IEnumerable<Common.Models.Kruzer> GetKruzeri() => repository.KruzerRepository.GetAll();
        public IEnumerable<Common.Models.Posada> GetPosade() => repository.PosadaRepository.GetAll();
        public IEnumerable<Common.Models.Tanker> GetTankeri() => repository.TankerRepository.GetAll();
        public IEnumerable<TeretniBrod> GetTeretniBrodovi() => repository.TeretniBrodRepository.GetAll();

        public Common.Models.Mornar GetMornar(string jmbg) => repository.MornarRepository.Get(jmbg);
        public Common.Models.Kormilar GetKormilar(string jmbg) => repository.KormilarRepository.Get(jmbg);
        public Common.Models.Brodogradiliste GetBrodogradiliste(Guid guid) => repository.BrodogradilisteRepository.Get(guid);
        public BrodskaLinija GetBrodskaLinija(Guid id) => repository.BrodskaLinijaRepository.Get(id);
        public Common.Models.Brod GetBrod(Guid id) => repository.BrodRepository.Get(id);
        public Common.Models.Kapetan GetKapetan(string jmbg) => repository.KapetanRepository.Get(jmbg);
        public Common.Models.Kruzer GetKruzer(Guid id) => repository.KruzerRepository.Get(id);
        public Common.Models.Posada GetPosada(Guid id) => repository.PosadaRepository.Get(id);
        public Common.Models.Tanker GetTanker(Guid id) => repository.TankerRepository.Get(id);
        public TeretniBrod GetTeretniBrod(Guid id) => repository.TeretniBrodRepository.Get(id);

        public void RemoveKormilar(string jmbg) => repository.KormilarRepository.Remove(jmbg);
        public void RemoveMornar(string jmbg) => repository.MornarRepository.Remove(jmbg);
        public void RemoveBrodogradiliste(Guid idBrodogradililste) => repository.BrodogradilisteRepository.Remove(idBrodogradililste);
        public void RemoveBrodskaLinija(Guid id) => repository.BrodskaLinijaRepository.Remove(id);
        public void RemoveBrod(Guid id) => repository.BrodRepository.Remove(id);
        public void RemoveKruzer(Guid id) => repository.KruzerRepository.Remove(id);
        public void RemovePosada(Guid id) => repository.PosadaRepository.Remove(id);
        public void RemoveTanker(Guid id) => repository.TankerRepository.Remove(id);
        public void RemoveTeretniBrod(Guid id) => repository.TeretniBrodRepository.Remove(id);
        public void RemoveKapetan(string jmbg) => repository.KapetanRepository.Remove(jmbg);

        public void EditKormilar(Common.Models.Kormilar kormilar) => repository.KormilarRepository.Update(kormilar);
        public void EditMornar(Common.Models.Mornar mornar) => repository.MornarRepository.Update(mornar);
        public void EditBrodogradiliste(Common.Models.Brodogradiliste brodogradiliste) => repository.BrodogradilisteRepository.Update(brodogradiliste);
        public void EditBrodskaLinija(BrodskaLinija brodskaLinija) => repository.BrodskaLinijaRepository.Update(brodskaLinija);
        public void EditBrod(Common.Models.Brod brod) => repository.BrodRepository.Update(brod);
        public void EditKapetan(Common.Models.Kapetan kapetan) => repository.KapetanRepository.Update(kapetan);
        public void EditKruzer(Common.Models.Kruzer kruzer) => repository.KruzerRepository.Update(kruzer);
        public void EditPosada(Common.Models.Posada posada) => repository.PosadaRepository.Update(posada);
        public void EditTanker(Common.Models.Tanker tanker) => repository.TankerRepository.Update(tanker);
        public void EditTeretniBrod(TeretniBrod teretniBrod) => repository.TeretniBrodRepository.Update(teretniBrod);

        public void AddMornarToPosada(string mornarJmbg, Guid selectedPosadaId) => repository.MornarRepository.AddPosada(mornarJmbg, selectedPosadaId);
        public void AddMoranrToTeretniBrod(string mornarJmbg, Guid iD) => repository.MornarRepository.AddTeretniBrod(mornarJmbg, iD);
    }
}
