using System.ServiceModel;

namespace Common
{
    [ServiceContract]
    public interface IBrodOperations : IAddBrodOperations, IGetBrodOperations, IEditBrodOperations, IRemoveBrodOperations
    {

    }
}
