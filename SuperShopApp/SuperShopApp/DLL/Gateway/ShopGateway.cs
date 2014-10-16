using System;
using System.Collections.Generic;
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
            string conn = "server=BADOL-PC; database=SuperShop; integrated security=true";
            connection = new SqlConnection();
            connection.ConnectionString = conn;
        }

        public string Save(Shop aShop)
        {
            connection.Open();
            string query = string.Format("INSERT INTO t_Shop VALUES('{0}','{1}')", aShop.ShopName, aShop.ShopAddress);
            SqlCommand command = new SqlCommand(query, connection);
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
