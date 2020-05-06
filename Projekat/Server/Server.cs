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

        public bool AddKruzer(Common.Models.Kruzer kruzer, Guid idBrodogradiliste) => throw new NotImplementedException();
        public bool AddMornar(Common.Models.Mornar mornar) => repository.MornarRepository.Add(mornar);
        public bool AddPosada(Common.Models.Posada posada, string jmbgKormilar, string jmbgKapetan, Guid idBrod) => throw new NotImplementedException();
        public bool AddTanker(Common.Models.Tanker tanker, Guid idBrodogradiliste) => repository.TankerRepository.Add(tanker, idBrodogradiliste);
        public bool AddTeretniBrod(TeretniBrod teretniBrod, Guid idBrodogradilista) => repository.TeretniBrodRepository.Add(teretniBrod, idBrodogradilista);
        public IEnumerable<Common.Models.Brodogradiliste> GetBrodogradilsta() => repository.BrodogradilisteRepository.GetAll();
        public IEnumerable<Common.Models.Brod> GetBrodovi() => repository.BrodRepository.GetAll();
        public IEnumerable<BrodskaLinija> GetBrodskeLinije() => repository.BrodskaLinijaRepository.GetAll();
    }
}
