using SWFCServiceLibrary.Models;
using System.Collections.Generic;
using System.ServiceModel;

namespace SWFCServiceLibrary
{
    // NOTE: You can use the "Rename" command on the "Refactor" menu to change the interface name "IChatService" in both code and config file together.
    [ServiceContract]
    public interface IChatService
    {
        [OperationContract]
        IList<Chat> GetMessages();

        [OperationContract]
        IList<Chat> CreateMessage(Chat chatData);
    }
}
