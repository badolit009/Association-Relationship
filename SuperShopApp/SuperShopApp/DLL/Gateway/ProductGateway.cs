using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SuperShopApp.DLL.DAO;

namespace SuperShopApp.DLL.Gateway
{
    class ProductGateway
    {
        private SqlConnection connection;

        public ProductGateway()
        {
            string conn = "server=BADOL-PC; database=SuperShop; integrated security=true";
            connection = new SqlConnection();
            connection.ConnectionString = conn;
        }

        public string Save(Product aProduct)
        {
            connection.Open();
            string query = string.Format("INSERT INTO t_Product VALUES('{0}','{1}')", aProduct.ItemId, aProduct.Quantity);
            SqlCommand command = new SqlCommand(query, connection);
            int affectedrows = command.ExecuteNonQuery();
            connection.Close();
            if (affectedrows > 0)
            {
                return "Insert Success";
            }
            return "Some Problem";
        }

        public List<Product> Show()
        {
            connection.Open();
            string query = "SELECT * FROM t_Product";
            SqlCommand command = new SqlCommand(query, connection);
            SqlDataReader aReader = command.ExecuteReader();
            List<Product> products = new List<Product>();
            if (aReader.HasRows)
            {
                while (aReader.Read())
                {
                    Product aProduct = new Product();
                    aProduct.ProductID = (int)aReader[0];
                    aProduct.ItemId = (int)aReader[1];
                    aProduct.Quantity = (int)aReader[2];
                    products.Add(aProduct);
                }
            }
            connection.Close();
            return products;
        }

        public bool HasThisItem(int itemId)
        {
            connection.Open();
            string query = string.Format("SELECT * FROM t_Product WHERE ItemId=('{0}')", itemId);
            SqlCommand command = new SqlCommand(query, connection);
            SqlDataReader aReader = command.ExecuteReader();
            bool HasRow = aReader.HasRows;
            connection.Close();
            return HasRow;
        }

        public void UpdateQuantity(Product quantity)
        {
            connection.Open();
            string query = string.Format("UPDATE t_Product SET Quantity+=" + quantity.Quantity + "WHERE ItemId=" + quantity.ItemId);
            SqlCommand command = new SqlCommand(query, connection);
            command.ExecuteNonQuery();
            connection.Close();
        }
    }
}
