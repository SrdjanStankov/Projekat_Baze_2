using System;
using Common;
using Common.Models;

namespace Server
{
    public class Server : IBrodOperations
    {
        private ModelContext ctx = new ModelContext();

        public void AddBrod(Common.Models.Brod brod, Guid idBrodogradiliste) => throw new NotImplementedException();
        public void AddBrodogradiliste(Common.Models.Brodogradiliste brodogradiliste) => throw new NotImplementedException();
        public void AddBrodskaLinija(BrodskaLinija brodskaLinija) => throw new NotImplementedException();
        public void AddKapetan(Common.Models.Kapetan kapetan, Guid idBrodskaLinija, Guid idBrod) => throw new NotImplementedException();
        public bool AddKormilar(Common.Models.Kormilar kormilar) => new KormilarRepository(ctx).Add(kormilar);

        public void AddKruzer(Common.Models.Kruzer kruzer, Guid idBrodogradiliste) => throw new NotImplementedException();
        public bool AddMornar(Common.Models.Mornar mornar) => new MornarRepository(ctx).Add(mornar);
        public void AddPosada(Common.Models.Posada posada, string jmbgKormilar, string jmbgKapetan, Guid idBrod) => throw new NotImplementedException();
        public void AddTanker(Common.Models.Tanker tanker, Guid idBrodogradiliste) => throw new NotImplementedException();
        public void AddTeretniBrod(TeretniBrod teretniBrod, Guid idBrodogradilista) => throw new NotImplementedException();
    }
}
