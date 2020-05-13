using System;
using System.ServiceModel;
using Common.Models;

namespace Common
{
    [ServiceContract]
    public interface IGetSingleBrodOperations
    {
        [OperationContract]
        Brod GetBrod(Guid id);
        [OperationContract]
        Brodogradiliste GetBrodogradiliste(Guid guid);
        [OperationContract]
        BrodskaLinija GetBrodskaLinija(Guid id);
        [OperationContract]
        Mornar GetMornar(string jmbg);
        [OperationContract]
        Kormilar GetKormilar(string jmbg);
        [OperationContract]
        Kapetan GetKapetan(string jmbg);
        [OperationContract]
        Kruzer GetKruzer(Guid id);
        [OperationContract]
        Posada GetPosada(Guid id);
        [OperationContract]
        Tanker GetTanker(Guid id);
        [OperationContract]
        TeretniBrod GetTeretniBrod(Guid id);
    }
}
