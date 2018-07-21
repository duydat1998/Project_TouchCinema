using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Configuration;
using System.Data.SqlClient;
using UltilitiesLibrary;

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

        public List<string> GetAllSeats(string scheduleID)
        {
            List<string> listSeat = new List<string>();
            SqlConnection conn = new SqlConnection(strConnection);
            if (conn != null)
            {
                if (conn.State == System.Data.ConnectionState.Closed)
                {
                    conn.Open();
                }
                try
                {
                    string sql = "Select seat " +
                                "from OrderDetail Join Orders on Orders.orderID = OrderDetail.orderID " +
                                "Where scheduleID = @scheduleID";
                    SqlCommand cmd = new SqlCommand(sql, conn);
                    cmd.Parameters.AddWithValue("@scheduleID", scheduleID);
                    SqlDataReader reader = cmd.ExecuteReader();
                    while (reader.Read())
                    {
                        string seat = reader["seat"].ToString();                        
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

        public List<string> GetAllSeatsInOrder(string orderID)
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
                    string sql = "Select seat " +
                                "from OrderDetail  " +
                                "Where orderID = @or";
                    SqlCommand cmd = new SqlCommand(sql, conn);
                    cmd.Parameters.AddWithValue("@or", orderID);
                    SqlDataReader reader = cmd.ExecuteReader();
                    while (reader.Read())
                    {
                        string seat = reader["seat"].ToString();
                        if (listSeat == null)
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

        public bool InsertOrderDetail(string orderID, string seat)
        {
            bool result = false;
            SqlConnection conn = new SqlConnection(strConnection);
            if (conn != null)
            {
                if (conn.State == System.Data.ConnectionState.Closed)
                {
                    conn.Open();
                }
                try
                {
                    DateTime currentDate = DateTime.Now;
                    string sql = "Insert into OrderDetail values(@orderID, @seat)";
                    SqlCommand cmd = new SqlCommand(sql, conn);
                    cmd.Parameters.AddWithValue("@orderID", orderID);
                    cmd.Parameters.AddWithValue("@seat", seat);
                    result = (cmd.ExecuteNonQuery() > 0);
                }
                finally
                {
                    conn.Close();
                }
            }
            return result;
        }
    }
}
