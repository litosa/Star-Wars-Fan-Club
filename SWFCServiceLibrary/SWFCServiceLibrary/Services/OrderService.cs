using System.Collections.Generic;
using System.Linq;

namespace SWFCServiceLibrary
{
    // NOTE: You can use the "Rename" command on the "Refactor" menu to change the class name "OrderService" in both code and config file together.
    public class OrderService : IOrderService
    {
        Context db = new Context();

        public OrderService()
        {
            db.Configuration.LazyLoadingEnabled = false;
            db.Configuration.ProxyCreationEnabled = false;
        }

        public List<Order> GetOrders()
        {
            List<Order> orderList = new List<Order>();

            orderList = db.Orders.Include("OrderProduct").ToList();            

            return orderList;

        }

        public IList<Order> CreateOrder(Order order)
        {
            db.Orders.Add(order);
            db.SaveChanges();
            return db.Orders.ToList();
        }

    }
}

