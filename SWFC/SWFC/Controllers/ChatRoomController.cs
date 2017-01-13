using System.Web.Mvc;

namespace SWFC.Controllers
{
    [Authorize]
    public class ChatRoomController : Controller
    {
        // GET: ChatRoom
        public ActionResult Index()
        {
            return View();
        }
    }
}