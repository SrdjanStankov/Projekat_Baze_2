using System;
using System.Collections.Generic;
using System.ServiceModel;
using Common.Models;

namespace Common
{
    [ServiceContract]
    public interface IBrodOperations
    {
        [OperationContract]
        bool AddBrod(Brod brod, Guid idBrodogradiliste);
        [OperationContract]
        bool AddBrodogradiliste(Brodogradiliste brodogradiliste);
        [OperationContract]
        bool AddBrodskaLinija(BrodskaLinija brodskaLinija);
        [OperationContract]
        bool AddKapetan(Kapetan kapetan, Guid idBrodskaLinija, Guid idBrod);
        [OperationContract]
        bool AddKormilar(Kormilar kormilar);
        [OperationContract]
        bool AddKruzer(Kruzer kruzer, Guid idBrodogradiliste);
        [OperationContract]
        bool AddMornar(Mornar mornar);
        [OperationContract]
        bool AddPosada(Posada posada, string jmbgKormilar, string jmbgKapetan, Guid idBrod);
        [OperationContract]
        bool AddTanker(Tanker tanker, Guid idBrodogradiliste);
        [OperationContract]
        bool AddTeretniBrod(TeretniBrod teretniBrod, Guid idBrodogradilista);
        
        [OperationContract]
        IEnumerable<Brodogradiliste> GetBrodogradilsta();
    }
}
