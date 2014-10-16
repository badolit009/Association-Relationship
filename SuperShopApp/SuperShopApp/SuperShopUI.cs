using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using SuperShopApp.BLL;
using SuperShopApp.DLL.DAO;

namespace SuperShopApp
{
    public partial class SuperShopUI : Form
    {
        private Product aProduct;
        private Shop aShop;
        private ShopBLL aShopBll = new ShopBLL();
        private ProductBLL aProductBll = new ProductBLL();
        private List<Product> products = new List<Product>();
        private List<Shop> shops = new List<Shop>();
        public SuperShopUI()
        {
            InitializeComponent();
        }

        private void shopSaveButton_Click(object sender, EventArgs e)
        {
            aShop = new Shop(shopNameTextBox.Text, shopAddressTextBox.Text);
            aShopBll = new ShopBLL();
            string msg = aShopBll.Save(aShop);
            MessageBox.Show(msg);
        }

        private void productSaveButton_Click(object sender, EventArgs e)
        {
            aProduct = new Product(Convert.ToInt16(itemIdTextBox.Text), Convert.ToInt16(quantityTextBox.Text));
            aProductBll = new ProductBLL();
            string msg = aProductBll.Save(aProduct);
            MessageBox.Show(msg);
        }

        private void detailsButton_Click(object sender, EventArgs e)
        {
            shops = aShopBll.Show();
            products = aProductBll.Show();
            string msg = "";
            foreach (Shop shop in shops)
            {
                msg += "Shop Name : " + shop.ShopName + "\nShop Address : " + shop.ShopAddress + "\n";
            }
            msg += "Item ID :\tProduct Quantity :\n";
            foreach (Product product in products)
            {
                msg += "\n " + product.ItemId + "\t" + product.Quantity;
            }
            MessageBox.Show(msg);
        }
    }
}
