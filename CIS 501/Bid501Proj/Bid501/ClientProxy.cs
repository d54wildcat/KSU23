using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bid501
{
    public class ClientProxy
    {

        public List<Product> productList = new List<Product>();

        public List<Product> GetProductList()
        {
            return productList;
        }
    }
}
