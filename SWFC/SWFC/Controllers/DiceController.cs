using SWFC.DiceServiceReference;
using System.Web.Mvc;

namespace SWFC.Controllers
{
    [Authorize]
    public class DiceController : Controller
    {
        DiceServiceClient dsc = new DiceServiceClient();

        // GET: Dice
        public ActionResult Index(string state)
        {

            if (state == "getdice")
            {
                int diceNumber = dsc.GetNumbers();

                return View(diceNumber);
            }

            return View();
        }
    }
}