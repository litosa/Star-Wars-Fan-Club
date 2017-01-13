using PagedList;
using SWFC.Models;
using SWFC.WallServiceReference;
using System.Collections.Generic;
using System.Linq;
using System.Web.Mvc;

namespace SWFC.Controllers
{
    [Authorize]
    public class WallController : Controller
    {
        WallServiceClient client = new WallServiceClient();

        // GET: Chat
        public ActionResult Index(int page = 1, int pageSize = 10)
        {
            List<WallData> listMessages = client.GetMessages().ToList();
            PagedList<WallData> messages = new PagedList<WallData>(listMessages, page, pageSize);

            return View(messages);
        }

        [HttpPost]
        public ActionResult Index(MessageViewModel mvm)
        {

            if (mvm.State == "cm")
            {
                WallData newMessage = new WallData();
                newMessage.Username = mvm.Username = User.Identity.Name;
                newMessage.MessageContent = mvm.MessageContent;
                newMessage.MessagePosted = mvm.MessagePosted;

                client.CreateMessage(newMessage);
                    
                List<WallData> listMessages = client.GetMessages().ToList();
                PagedList<WallData> messages = new PagedList<WallData>(listMessages, 1, 10);

                return View(messages);
            }

            else if (mvm.State == "dm")
            {
                WallData selectedMessage = new WallData();

                selectedMessage.MessageId = mvm.MessageId;

                client.DeleteMessage(selectedMessage.MessageId);

                List<WallData> listMessages = client.GetMessages().ToList();
                PagedList<WallData> messages = new PagedList<WallData>(listMessages, 1, 10);

                return View(messages);
            }
            return View();
        }
    }
}