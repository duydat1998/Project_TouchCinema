using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Configuration;
using System.Data.SqlClient;
using UltilitiesLibrary;
<<<<<<< HEAD

=======
>>>>>>> 857807debe55373a9293987a3516ac29ec120b24
namespace OrderLibary
{
    public class OrderDetailDAO
    {
        private string strConnection;

        public OrderDetailDAO()
        {
            DatabaseConnection dc = new DatabaseConnection();
            strConnection = dc.GetConnection();
        }

        public List<string> GetAllSeats(string orderID)
        {
            List<string> listSeat = null;
            SqlConnection conn = new SqlConnection(strConnection);
            if (conn != null)
            {
                if (conn.State == System.Data.ConnectionState.Closed)
                {
                    conn.Open();
                }
                try
                {
                    string sql = "Select seat from OrderDetail where orderID=@orderID";
                    SqlCommand cmd = new SqlCommand(sql, conn);
                    cmd.Parameters.AddWithValue("@orderID", orderID);
                    SqlDataReader reader = cmd.ExecuteReader();
                    while (reader.Read())
                    {
                        string seat = reader["seat"].ToString();
                        if(listSeat== null)
                        {
                            listSeat = new List<string>();
                        }
                        listSeat.Add(seat);
                    }
                }
                finally
                {
                    conn.Close();
                }
            }
            return listSeat;
        }
    }
}
