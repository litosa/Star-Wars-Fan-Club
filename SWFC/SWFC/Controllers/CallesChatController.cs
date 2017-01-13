using SWFC.CallesChatServiceReference;
using System.Web.Mvc;

namespace SWFC.Controllers
{
    [Authorize]
    public class CallesChatController : Controller
    {
        ChatServiceClient csc = new ChatServiceClient();
        // GET: CallesChat
        [HttpGet]
        public ActionResult Index()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Index(string Text)
        {
            csc.SendMessage(new NewMessageViewModel { Writer = User.Identity.Name, Text = Text, ChannelId = 14 });

            return View();
        }
    }
}