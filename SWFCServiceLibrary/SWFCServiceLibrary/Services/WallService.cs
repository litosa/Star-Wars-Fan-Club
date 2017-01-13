using System.Collections.Generic;
using System.Linq;

namespace SWFCServiceLibrary
{
    // NOTE: You can use the "Rename" command on the "Refactor" menu to change the class name "ChatService" in both code and config file together.
    public class WallService : IWallService
    {
        Context db = new Context();

        public IList<WallData> GetMessages()
        {
            IList<WallData> messages = new List<WallData>();
            IList<WallData> messagesdesc = new List<WallData>();

            messages = db.Wall.ToList();
            messagesdesc = messages.OrderByDescending(m => m.MessageId).ToList();

            return messagesdesc;

        }

        public IList<WallData> CreateMessage(WallData message)
        {
            db.Wall.Add(message);
            db.SaveChanges();
            return db.Wall.ToList();
        }

        public IList<WallData> DeleteMessage(int id)
        {
            if (!db.Wall.Any(w => w.MessageId == id))
            {
                return db.Wall.ToList();
            }
            else
            {
                WallData selectedMessage = db.Wall.Where(w => w.MessageId == id).First();
                db.Wall.Remove(selectedMessage);
                db.SaveChanges();
            }
            return db.Wall.ToList();
        }
    }
}
