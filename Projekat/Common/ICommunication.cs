using System.ServiceModel;

namespace Common
{
    [ServiceContract]
    public interface ICommunication
    {
        [OperationContract]
        void Comunicate();
    }
}
