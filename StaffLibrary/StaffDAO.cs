using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Configuration;
using System.Data.SqlClient;

namespace StaffLibrary
{
    public class StaffDAO
    {
        private string strConnection;

        public StaffDAO()
        {
            strConnection = ConfigurationManager.ConnectionStrings["TouchCinemaDB"].ConnectionString;

        }

        public bool CheckLogin(string username, string password , ref StaffDTO dto)
        {
            bool result = false;
            SqlConnection conn = new SqlConnection(strConnection);
            if(conn != null)
            {
                if(conn.State == System.Data.ConnectionState.Closed)
                {
                    conn.Open();
                }
                try
                {
                    string sql = "Select firstName, lastName, phone, email from Staff " +
                        "where username=@username And password=@password and isActive=@isActive";
                    SqlCommand cmd = new SqlCommand(sql, conn);
                    cmd.Parameters.AddWithValue("@username", username);
                    cmd.Parameters.AddWithValue("@password", password);
                    cmd.Parameters.AddWithValue("@isActive", true);
                    SqlDataReader reader = cmd.ExecuteReader();
                    if (reader.Read())
                    {
                        string firstName = reader["firstName"].ToString();
                        string lastName = reader["lastName"].ToString();
                        string phone = reader["phone"].ToString();
                        string email = reader["email"].ToString();
                        result = true;
                        dto = new StaffDTO { Username = username, FirstName = firstName, LastName = lastName, Email = email, Phone = phone };
                    }
                }
                finally
                {
                    conn.Close();
                }
            }
            return result;
        }
        
        public bool RemoveStaff(string username)
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
                    string sql = "Update Staff set isActive=@isActive WHERE username=@username";
                    SqlCommand cmd = new SqlCommand(sql, conn);
                    cmd.Parameters.AddWithValue("@username", username);
                    cmd.Parameters.AddWithValue("@isActive", false);
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

        public bool AddNewStaff(string username, string password, string firstName, string lastName, string phone, string email, bool isActive)
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
                    string sql = "Insert into Staff (username, password, firstName, lastName, phone, email, isActive) values(@username, @password, @firstname, @lastName, @phone, @email, @isActive)";
                    SqlCommand cmd = new SqlCommand(sql, conn);
                    cmd.Parameters.AddWithValue("@username", username);
                    cmd.Parameters.AddWithValue("@password", password);
                    cmd.Parameters.AddWithValue("@firstName", firstName);
                    cmd.Parameters.AddWithValue("@lastName", lastName);
                    cmd.Parameters.AddWithValue("@phone", phone);
                    cmd.Parameters.AddWithValue("@email", email);
                    cmd.Parameters.AddWithValue("@isActive", isActive);
                    int count = cmd.ExecuteNonQuery();
                    if (count > 0)
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
