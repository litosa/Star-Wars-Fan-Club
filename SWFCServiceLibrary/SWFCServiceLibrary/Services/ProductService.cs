using System.Collections.Generic;
using System.Linq;

namespace SWFCServiceLibrary
{
    // NOTE: You can use the "Rename" command on the "Refactor" menu to change the class name "ProductService" in both code and config file together.
    public class ProductService : IProductService
    {
        Context db = new Context();
        
        public IList<Product> GetProducts()
        {
            return db.Products.ToList();
        }
    }
}
