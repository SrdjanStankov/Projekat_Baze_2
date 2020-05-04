using System;
using Common;
using Common.Models;

namespace Server
{
    public class Server : IBrodOperations
    {
        public void AddBrod(Common.Models.Brod brod, Guid idBrodogradiliste) => throw new NotImplementedException();
        public void AddBrodogradiliste(Common.Models.Brodogradiliste brodogradiliste) => throw new NotImplementedException();
        public void AddBrodskaLinija(BrodskaLinija brodskaLinija) => throw new NotImplementedException();
        public void AddKapetan(Common.Models.Kapetan kapetan, Guid idBrodskaLinija, Guid idBrod) => throw new NotImplementedException();
        public void AddKormilar(Common.Models.Kormilar kormilar) => throw new NotImplementedException();
        public void AddKruzer(Common.Models.Kruzer kruzer, Guid idBrodogradiliste) => throw new NotImplementedException();
        public void AddMornar(Common.Models.Mornar mornar) => throw new NotImplementedException();
        public void AddPosada(Common.Models.Posada posada, string jmbgKormilar, string jmbgKapetan, Guid idBrod) => throw new NotImplementedException();
        public void AddTanker(Common.Models.Tanker tanker, Guid idBrodogradiliste) => throw new NotImplementedException();
        public void AddTeretniBrod(TeretniBrod teretniBrod, Guid idBrodogradilista) => throw new NotImplementedException();
    }
}
