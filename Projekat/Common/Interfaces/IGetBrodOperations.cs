using System.ServiceModel;

namespace Common
{
    [ServiceContract]
    public interface IGetBrodOperations : IGetSingleBrodOperations, IGetMultipleBrodOperations
    {

    }
}
