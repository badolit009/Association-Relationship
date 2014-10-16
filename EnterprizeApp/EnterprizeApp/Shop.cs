using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Sockets;
using System.Text;
using System.Threading.Tasks;

namespace EnterprizeApp
{
    class Shop
    {
        public string  Name { get; set; }
        public string Address { get; set; }
        public List<Product> Products { get; set; }

        public Shop(string name, string address):this()
        {
            Name = name;
            Address = address;
        }

        public Shop()
        {
            Products = new List<Product>();
        }

        public string AddItem(Product aProduct)
        {

            foreach (Product product in Products)
            {
                if (product.ProductId == aProduct.ProductId)
                {
                    product.Quantity += aProduct.Quantity;
                    return "Quantity Added";
                }
            }
            Products.Add(aProduct);
            return "Product Insert Successfully";
        }
    }

}
