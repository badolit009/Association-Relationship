using System;
using System.Collections.Generic;
using System.Configuration;
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
            string connectionString = ConfigurationManager.ConnectionStrings["SuperShop"].ConnectionString;
            connection = new SqlConnection(connectionString);
        }

        public string Save(Product aProduct)
        {
            connection.Open();
            string query = "INSERT INTO t_Product(ItemId,Quantity) VALUES(@0,@1)";
            SqlCommand command = new SqlCommand(query, connection);
            command.Parameters.AddWithValue("@0", aProduct.ItemId);
            command.Parameters.AddWithValue("@1", aProduct.Quantity);
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
            string query = "SELECT * FROM t_Product WHERE ItemId=@0";
            SqlCommand command = new SqlCommand(query, connection);
            command.Parameters.AddWithValue("@0", itemId);
            SqlDataReader aReader = command.ExecuteReader();
            bool HasRow = aReader.HasRows;
            connection.Close();
            return HasRow;
        }

        public void UpdateQuantity(Product quantity)
        {
            connection.Open();
            string query = string.Format("UPDATE t_Product SET Quantity+=@0 WHERE ItemId=@1");
            SqlCommand command = new SqlCommand(query, connection);
            command.Parameters.AddWithValue("@0", quantity.Quantity);
            command.Parameters.AddWithValue("@1", quantity.ItemId);
            command.ExecuteNonQuery();
            connection.Close();
        }
    }
}
