using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Configuration;
using System.Data.SqlClient;

namespace OrderLibary
{
    public class OrderDetailDAO
    {
        private string strConnection;

        public OrderDetailDAO()
        {
            strConnection = ConfigurationManager.ConnectionStrings["TouchCinemaDB"].ConnectionString;

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
