using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Configuration;
using System.Data.SqlClient;

namespace OrderLibary
{
    public class OrderDAO 
    {
        private string strConnection;

        public OrderDAO()
        {
            strConnection = ConfigurationManager.ConnectionStrings["TouchCinemaDB"].ConnectionString;

        }

        public OrderDTO CheckOrder(string orderID)
        {
            OrderDTO output = null;
            SqlConnection conn = new SqlConnection(strConnection);
            if (conn != null)
            {
                if (conn.State == System.Data.ConnectionState.Closed)
                {
                    conn.Open();
                }
                try
                {
                    string sql = "Select scheduleID, phone, email, isCheckOut from Order where orderID=@orderID";
                    SqlCommand cmd = new SqlCommand(sql, conn);
                    cmd.Parameters.AddWithValue("@orderID", orderID);
                    SqlDataReader reader = cmd.ExecuteReader();
                    if (reader.Read())
                    {
                        string scheduleID = reader["scheduleID"].ToString();
                        string phone = reader["phone"].ToString();
                        string email = reader["email"].ToString();
                        bool isCheckOut = (bool) reader["isCheckOut"];
                        OrderDetailDAO dao = new OrderDetailDAO();
                        List<string> listSeat = dao.GetAllSeats(orderID);
                        output = new OrderDTO { OrderID = orderID, Email = email, IsCheckOut = isCheckOut, ListOfSeat = listSeat, Phone = phone, ScheduleID = scheduleID };
                    }
                }
                finally
                {
                    conn.Close();
                }
            }
            return output;
        }

        public bool CheckOutOrder(string orderID)
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
                    string sql = "Update Order set isCheckOut= @check";
                    SqlCommand cmd = new SqlCommand(sql, conn);
                    cmd.Parameters.AddWithValue("@check", true);
                    int count = cmd.ExecuteNonQuery();
                    if(count > 0)
                    {
                        result = true;
                    }
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
