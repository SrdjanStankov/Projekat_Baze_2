using System;
using System.ServiceModel;

namespace Common
{
    [ServiceContract]
    public interface IRemoveBrodOperations
    {
        [OperationContract]
        void RemoveKruzer(Guid id);
        [OperationContract]
        void RemovePosada(Guid id);
        [OperationContract]
        void RemoveTanker(Guid id);
        [OperationContract]
        void RemoveTeretniBrod(Guid id);
        [OperationContract]
        void RemoveMornar(string jmbg);
        [OperationContract]
        void RemoveKormilar(string jmbg);
        [OperationContract]
        void RemoveBrodogradiliste(Guid idBrodogradililste);
        [OperationContract]
        void RemoveKapetan(string jmbg);
        [OperationContract]
        void RemoveBrod(Guid id);
        [OperationContract]
        void RemoveBrodskaLinija(Guid id);
    }
}
