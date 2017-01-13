using SWFC.OrderServiceReference;
using SWFC.ProductServiceReference;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web.Mvc;

namespace SWFC.Controllers
{
    [Authorize]
    public class ShoppingCartController : Controller
    {
        OrderServiceClient client = new OrderServiceClient();
        List<Product> shoppinglist = new List<Product>();


        // GET: ShoppingCart
        public ActionResult Index()
        {
            double TotalPrice = 0;
            
            shoppinglist = (List<Product>)Session["shoppinglist"];

            if (shoppinglist != null)
            {
                foreach (var item in shoppinglist)
                {
                    TotalPrice += item.Price;
                }
            }            

            Session["TotalPrice"] = TotalPrice;

            return View(shoppinglist);
        }

        public ActionResult Checkout(double totalPrice)
        {
            shoppinglist = (List<Product>)Session["shoppinglist"];
            List<OrderProduct> op = new List<OrderProduct>();


            foreach (var product in shoppinglist)
            {
                op.Add(new OrderProduct { ProductId = product.ProductId, Price = product.Price });
            }

            Order newOrder = new Order { Username = User.Identity.Name, TotalPrice = totalPrice, CreatedAt = DateTime.Now, OrderProduct = op.ToArray() };

            
            client.CreateOrder(newOrder);

            Session["shoppinglist"] = null;
            Session["TotalPrice"] = null;
            Session["shoppinglistCount"] = null;

            return RedirectToAction("Index", "Order");
        }

        public ActionResult DeleteItemFromShoppingcart(int id)
        {
            Product selectedProduct = new Product();

            shoppinglist = (List<Product>)Session["shoppinglist"];

            selectedProduct = shoppinglist.Where(p => p.ProductId == id).First();
            shoppinglist.Remove(selectedProduct);
            Session["shoppinglistCount"] = shoppinglist.Count;

            return RedirectToAction("Index", "ShoppingCart");
        }
    }
}