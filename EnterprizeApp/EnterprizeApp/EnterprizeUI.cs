using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace EnterprizeApp
{
    public partial class EnterprizeUI : Form
    {
        private Shop aShop=new Shop();
        private Product aProduct=new Product();

        public EnterprizeUI()
        {
            InitializeComponent();
        }

        private void shopSaveButton_Click(object sender, EventArgs e)
        {
            aShop = new Shop(nameTextBox.Text,addressTextBox.Text);
            MessageBox.Show(@"Has Been Saved");
        }

        private void productSaveButton_Click(object sender, EventArgs e)
        {
            aProduct = new Product(Convert.ToInt16(productTextBox.Text),Convert.ToInt16(quantityTextBox.Text));
            string msg=aShop.AddItem(aProduct);
            MessageBox.Show(msg);

        }

        private void showDetailsButton_Click(object sender, EventArgs e)
        {
            int noOfProduct = aShop.Products.Count;
            string msg = "";
            msg += "Shop Name : " + aShop.Name + ". Shop Address : " + aShop.Address + ". Total Product : " + noOfProduct+ "\n";
            msg += "Product Id \t Quantity \n";
            foreach (Product aProduct in aShop.Products)
            {
                msg +=  aProduct.ProductId+"\t \t" + aProduct.Quantity+"\n";
            }
            MessageBox.Show(msg);
        }
    }
}

