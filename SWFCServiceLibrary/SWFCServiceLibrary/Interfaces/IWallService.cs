using System.Collections.Generic;
using System.ServiceModel;

namespace SWFCServiceLibrary
{
    // NOTE: You can use the "Rename" command on the "Refactor" menu to change the interface name "IChatService" in both code and config file together.
    [ServiceContract]
    public interface IWallService
    {
        [OperationContract]
        IList<WallData> GetMessages();

        [OperationContract]
        IList<WallData> CreateMessage(WallData message);

        [OperationContract]
        IList<WallData> DeleteMessage(int id);
    }
}
