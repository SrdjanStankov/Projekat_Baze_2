using System;
using System.ServiceModel;

namespace Common
{
    [ServiceContract]
    public interface IRemoveBrodOperations
    {
        [OperationContract]
        bool RemoveKruzer(Guid id);
        [OperationContract]
        bool RemovePosada(Guid id);
        [OperationContract]
        bool RemoveTanker(Guid id);
        [OperationContract]
        bool RemoveTeretniBrod(Guid id);
        [OperationContract]
        bool RemoveMornar(string jmbg);
        [OperationContract]
        bool RemoveKormilar(string jmbg);
        [OperationContract]
        bool RemoveBrodogradiliste(Guid idBrodogradililste);
        [OperationContract]
        bool RemoveKapetan(string jmbg);
        [OperationContract]
        bool RemoveBrod(Guid id);
        [OperationContract]
        bool RemoveBrodskaLinija(Guid id);
    }
}
