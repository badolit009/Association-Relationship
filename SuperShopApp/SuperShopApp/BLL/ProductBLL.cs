using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms.VisualStyles;
using SuperShopApp.DLL.DAO;
using SuperShopApp.DLL.Gateway;

namespace SuperShopApp.BLL
{
    class ProductBLL
    {
        private ProductGateway aProductGateway = new ProductGateway();
        public string Save(Product aProduct)
        {
            if (HasThisItem(aProduct.ItemId))
            {
                UpdateQuantity(aProduct);
                return "Quantity Update Successfully";
            }
            return aProductGateway.Save(aProduct);
        }

        private void UpdateQuantity(Product quantity)
        {
            aProductGateway.UpdateQuantity(quantity);
        }

        private bool HasThisItem(int itemId)
        {
            return aProductGateway.HasThisItem(itemId);
        }

        public List<Product> Show()
        {
            return aProductGateway.Show();
        }
    }
}
