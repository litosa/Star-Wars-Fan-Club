using System.Collections.Generic;
using System.Linq;
using SWFCServiceLibrary.Models;

namespace SWFCServiceLibrary
{
    // NOTE: You can use the "Rename" command on the "Refactor" menu to change the class name "ChatService" in both code and config file together.
    public class ChatService : IChatService
    {
        Context db = new Context();

        public IList<Chat> GetMessages()
        {
            IList<Chat> messages = new List<Chat>();
            IList<Chat> messagesdesc = new List<Chat>();

            messages = db.Chat.ToList();
            messagesdesc = messages.OrderByDescending(m => m.MessageId).ToList();

            return messagesdesc;
        }

        public IList<Chat> CreateMessage(Chat chatData)
        {
            db.Chat.Add(chatData);
            db.SaveChanges();

            return db.Chat.ToList();
        }        
    }
}
