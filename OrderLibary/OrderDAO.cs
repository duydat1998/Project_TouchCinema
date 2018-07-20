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
    public class OrderDAO 
    {
        private string strConnection;

        public OrderDAO()
        {
            DatabaseConnection dc = new DatabaseConnection();
            strConnection = dc.GetConnection();
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
                    string sql = "Select scheduleID, phone, email from Orders where orderID=@orderID and isCheckOut=@isCheckOut";
                    SqlCommand cmd = new SqlCommand(sql, conn);
                    cmd.Parameters.AddWithValue("@orderID", orderID);
                    cmd.Parameters.AddWithValue("@isCheckOut", false);
                    SqlDataReader reader = cmd.ExecuteReader();
                    if (reader.Read())
                    {
                        string scheduleID = reader["scheduleID"].ToString();
                        string phone = reader["phone"].ToString();
                        string email = reader["email"].ToString();
                        OrderDetailDAO dao = new OrderDetailDAO();
                        List<string> listSeat = dao.GetAllSeatsInOrder(orderID);
                        output = new OrderDTO { OrderID = orderID, Email = email, IsCheckOut = false, ListOfSeat = listSeat, Phone = phone, ScheduleID = scheduleID };
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
                    string sql = "Update Orders set isCheckOut= @check where orderID=@id";
                    SqlCommand cmd = new SqlCommand(sql, conn);
                    cmd.Parameters.AddWithValue("@check", true);
                    cmd.Parameters.AddWithValue("@id", orderID);
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

        public string GenerateCode()
        {
            Random random = new Random();
            const string chars = "ABCDEFGHIJKLMNOPQRSTUVWXYZ0123456789";
            return new string(Enumerable.Repeat(chars, 10)
              .Select(s => s[random.Next(s.Length)]).ToArray());
        }

        private bool IsOrderIDExist(string id)
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
                    string sql = "Select * from Orders where orderID=@orderID";
                    SqlCommand cmd = new SqlCommand(sql, conn);
                    cmd.Parameters.AddWithValue("@orderID", id);
                    SqlDataReader reader = cmd.ExecuteReader();
                    if (reader.HasRows)
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

        public string InsertOrder(OrderDTO order, string username)
        {
            string orderID = "";
            do
            {
                orderID = GenerateCode();
            } while (IsOrderIDExist(orderID));
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
                    string sql = "Insert into Orders values(@orderID, @scheduleID, @orderDate, @username, @phone, @email, @isCheckOut)";
                    SqlCommand cmd = new SqlCommand(sql, conn);
                    cmd.Parameters.AddWithValue("@orderID", orderID);
                    cmd.Parameters.AddWithValue("@scheduleID", order.ScheduleID);
                    cmd.Parameters.AddWithValue("@orderDate", currentDate);
                    cmd.Parameters.AddWithValue("@username", username);
                    cmd.Parameters.AddWithValue("@phone", order.Phone);
                    cmd.Parameters.AddWithValue("@email", order.Email);
                    cmd.Parameters.AddWithValue("@isCheckOut", false);
                    bool result = (cmd.ExecuteNonQuery() > 0);

                    if (result)
                    {
                        OrderDetailDAO detailDAO = new OrderDetailDAO();
                        foreach (string seat in order.ListOfSeat)
                        {
                            result = detailDAO.InsertOrderDetail(orderID, seat);
                        }
                    }
                }
                finally
                {
                    conn.Close();
                }
            }
            return orderID;

        }


    }
}
