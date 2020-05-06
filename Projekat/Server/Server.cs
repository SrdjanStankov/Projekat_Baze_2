using System;
using Common;
using Common.Models;

namespace Server
{
    public class Server : IBrodOperations
    {
        private ModelContext ctx = new ModelContext();

        public bool AddBrod(Common.Models.Brod brod, Guid idBrodogradiliste) => throw new NotImplementedException();
        public bool AddBrodogradiliste(Common.Models.Brodogradiliste brodogradiliste) => new BrodogradilisteRepository(ctx).Add(brodogradiliste);
        public bool AddBrodskaLinija(BrodskaLinija brodskaLinija) => new BrodskaLinijaRepository(ctx).Add(brodskaLinija);
        public bool AddKapetan(Common.Models.Kapetan kapetan, Guid idBrodskaLinija, Guid idBrod) => throw new NotImplementedException();
        public bool AddKormilar(Common.Models.Kormilar kormilar) => new KormilarRepository(ctx).Add(kormilar);

        public bool AddKruzer(Common.Models.Kruzer kruzer, Guid idBrodogradiliste) => throw new NotImplementedException();
        public bool AddMornar(Common.Models.Mornar mornar) => new MornarRepository(ctx).Add(mornar);
        public bool AddPosada(Common.Models.Posada posada, string jmbgKormilar, string jmbgKapetan, Guid idBrod) => throw new NotImplementedException();
        public bool AddTanker(Common.Models.Tanker tanker, Guid idBrodogradiliste) => throw new NotImplementedException();
        public bool AddTeretniBrod(TeretniBrod teretniBrod, Guid idBrodogradilista) => throw new NotImplementedException();
    }
}
