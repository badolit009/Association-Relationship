using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SuperShopApp.DLL.DAO
{
    class Product
    {
        public int ProductID { get; set; }
        public int ItemId { get; set; }
        public int Quantity { get; set; }

        public Product(int productId, int quantity) : this()
        {
            ItemId = productId;
            Quantity = quantity;
        }

        public Product()
        {
        }
    }
}
