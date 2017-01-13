using SWFC.ProductServiceReference;
using System.Collections.Generic;
using System.Linq;
using System.Web.Mvc;

namespace SWFC.Controllers
{
    public class StoreController : Controller
    {
        ProductServiceClient client = new ProductServiceClient();

        // GET: Store
        public ActionResult Index()
        {
            List<Product> products;

            products = client.GetProducts().ToList();
            return View(products);
        }

        public ActionResult ShoppingCart(int id)
        {
            if (User.Identity.Name.Any())
            {
                List<Product> shoppinglist = (List<Product>)Session["shoppinglist"];
                Product product = client.GetProducts().FirstOrDefault(p => p.ProductId == id);

                if (shoppinglist == null)
                {
                    shoppinglist = new List<Product>();
                }
                shoppinglist.Add(product);

                Session["shoppinglist"] = shoppinglist;
                Session["shoppinglistCount"] = shoppinglist.Count;

                return RedirectToAction("Index", "Store");
            }

            return RedirectToAction("Login", "Account");
            
        }
    }
}