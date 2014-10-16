using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SuperShopApp.DLL.DAO
{
    class Shop
    {
        public int ShopID { get; set; }
        public string ShopName { get; set; }
        public string ShopAddress { get; set; }

        public Shop(string shopName, string shopAddress)
            : this()
        {
            ShopName = shopName;
            ShopAddress = shopAddress;
        }

        public Shop()
        {
        }
    }
}
