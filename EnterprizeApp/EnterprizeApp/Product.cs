using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EnterprizeApp
{
    class Product
    {
        public int ProductId { get; set; }
        public int Quantity { get; set; }

        public Product(int productId,int quantity):this()
        {
            ProductId = productId;
            Quantity = quantity;
        }

        public Product()
        {

        }
    }
}
