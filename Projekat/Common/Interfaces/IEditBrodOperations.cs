using System.ServiceModel;
using Common.Models;

namespace Common
{
    [ServiceContract]
    public interface IEditBrodOperations
    {
        [OperationContract]
        void EditBrod(Brod brod);
        [OperationContract]
        void EditBrodskaLinija(BrodskaLinija brodskaLinija);
        [OperationContract]
        void EditBrodogradiliste(Brodogradiliste brodogradiliste);
        [OperationContract]
        void EditKormilar(Kormilar kormilar);
        [OperationContract]
        void EditMornar(Mornar mornar);
        [OperationContract]
        void EditKapetan(Kapetan kapetan);
        [OperationContract]
        void EditKruzer(Kruzer kruzer);
        [OperationContract]
        void EditPosada(Posada posada);
        [OperationContract]
        void EditTanker(Tanker tanker);
        [OperationContract]
        void EditTeretniBrod(TeretniBrod teretniBrod);
    }
}
