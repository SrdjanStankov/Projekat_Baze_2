using System;
using System.ServiceModel;
using Common.Models;

namespace Common
{
    [ServiceContract]
    public interface IBrodOperations
    {
        [OperationContract]
        void AddBrod(Brod brod, Guid idBrodogradiliste);
        [OperationContract]
        void AddBrodogradiliste(Brodogradiliste brodogradiliste);
        [OperationContract]
        void AddBrodskaLinija(BrodskaLinija brodskaLinija);
        [OperationContract]
        void AddKapetan(Kapetan kapetan, Guid idBrodskaLinija, Guid idBrod);
        [OperationContract]
        void AddKormilar(Kormilar kormilar);
        [OperationContract]
        void AddKruzer(Kruzer kruzer, Guid idBrodogradiliste);
        [OperationContract]
        void AddMornar(Mornar mornar);
        [OperationContract]
        void AddPosada(Posada posada, string jmbgKormilar, string jmbgKapetan, Guid idBrod);
        [OperationContract]
        void AddTanker(Tanker tanker, Guid idBrodogradiliste);
        [OperationContract]
        void AddTeretniBrod(TeretniBrod teretniBrod, Guid idBrodogradilista);
    }
}
