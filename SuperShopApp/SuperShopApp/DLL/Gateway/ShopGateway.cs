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
    class ShopGateway
    {
        private SqlConnection connection;
        public ShopGateway()
        {
            string connectionString = ConfigurationManager.ConnectionStrings["SuperShop"].ConnectionString;
            connection = new SqlConnection(connectionString);
        }

        public string Save(Shop aShop)
        {
            connection.Open();
            string query = "INSERT INTO t_Shop(Name,Address)VALUES(@0,@1)";
            SqlCommand command = new SqlCommand(query, connection);
            command.Parameters.AddWithValue("@0", aShop.ShopName);
            command.Parameters.AddWithValue("@1", aShop.ShopAddress);
            int affectedrows = command.ExecuteNonQuery();
            connection.Close();
            if (affectedrows > 0)
            {
                return "Insert Success";
            }
            return "Some Problem";
        }

        public List<Shop> Show()
        {
            connection.Open();
            string query = "SELECT * FROM t_Shop";
            SqlCommand command = new SqlCommand(query, connection);
            SqlDataReader aReader = command.ExecuteReader();
            List<Shop> shops = new List<Shop>();
            if (aReader.HasRows)
            {
                while (aReader.Read())
                {
                    Shop aShop = new Shop();
                    aShop.ShopID = (int)aReader[0];
                    aShop.ShopName = aReader[1].ToString();
                    aShop.ShopAddress = aReader[2].ToString();
                    shops.Add(aShop);
                }
            }
            connection.Close();
            return shops;
        }
    }
}
