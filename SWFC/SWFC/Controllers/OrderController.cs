using SWFC.Models;
using SWFC.OrderServiceReference;
using SWFC.ProductServiceReference;
using System.Collections.Generic;
using System.Linq;
using System.Web.Mvc;

namespace SWFC.Controllers
{
    [Authorize]
    public class OrderController : Controller
    {
        OrderServiceClient orderclient = new OrderServiceClient();
        ProductServiceClient productclient = new ProductServiceClient();

        List<Order> orderList = new List<Order>();
        List<OrderProduct> orderProducts = new List<OrderProduct>();
        List<Product> productList = new List<Product>();

        List<OrderViewModel> ovm = new List<OrderViewModel>();
        List<OrderViewModel> ovmOrderByCreated = new List<OrderViewModel>();
        List<OrderProductViewModel> selectedOrderProduct;


        public ActionResult Index()
        {
            orderList = orderclient.GetOrders().ToList();
            productList = productclient.GetProducts().ToList();

            foreach (var selectedOrder in orderList)
            {
                orderProducts = selectedOrder.OrderProduct.ToList();
                selectedOrderProduct = new List<OrderProductViewModel>();

                foreach (var op in orderProducts)
                {
                    if (productList.Any(p => p.ProductId == op.ProductId))
                    {
                        var selectedProduct = productList.Where(p => p.ProductId == op.ProductId).First();
                        selectedOrderProduct.Add(new OrderProductViewModel { ProductTitle = selectedProduct.Title, ProductPrice = selectedProduct.Price });

                    }
                }
                ovm.Add(new OrderViewModel { Username = selectedOrder.Username, TotalPrice = selectedOrder.TotalPrice, CreatedAt = selectedOrder.CreatedAt, OrderProductvm = selectedOrderProduct });

            }

            ovmOrderByCreated = ovm.OrderByDescending(o => o.CreatedAt).ToList();
            return View(ovmOrderByCreated);

        }
    }
}