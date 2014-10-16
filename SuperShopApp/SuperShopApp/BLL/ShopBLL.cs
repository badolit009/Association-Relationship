using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SuperShopApp.DLL.DAO;
using SuperShopApp.DLL.Gateway;

namespace SuperShopApp.BLL
{
    class ShopBLL
    {
        private ShopGateway aShopGateway = new ShopGateway();

        public string Save(Shop aShop)
        {
            if (aShop.ShopName == string.Empty || aShop.ShopAddress == string.Empty)
            {
                return "Plz Fill All The Fields";
            }
            else
            {
                aShopGateway = new ShopGateway();
                return aShopGateway.Save(aShop);
            }

        }

        public List<Shop> Show()
        {
            return aShopGateway.Show();
        }
    }
}
