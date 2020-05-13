using System.Collections.Generic;
using System.ServiceModel;
using Common.Models;

namespace Common
{
    [ServiceContract]
    public interface IGetMultipleBrodOperations
    {
        [OperationContract]
        IEnumerable<BrodskaLinija> GetBrodskeLinije();
        [OperationContract]
        IEnumerable<Brodogradiliste> GetBrodogradilsta();
        [OperationContract]
        IEnumerable<Kormilar> GetKormilari();
        [OperationContract]
        IEnumerable<Kapetan> GetKapetani();
        [OperationContract]
        IEnumerable<Brod> GetBrodovi();
        [OperationContract]
        IEnumerable<Mornar> GetMornari();
        [OperationContract]
        IEnumerable<Kruzer> GetKruzeri();
        [OperationContract]
        IEnumerable<Posada> GetPosade();
        [OperationContract]
        IEnumerable<Tanker> GetTankeri();
        [OperationContract]
        IEnumerable<TeretniBrod> GetTeretniBrodovi();
    }
}
