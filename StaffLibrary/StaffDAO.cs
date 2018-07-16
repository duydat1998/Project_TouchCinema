using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Configuration;
using System.Data.SqlClient;
using UltilitiesLibrary;

namespace StaffLibrary
{
    public class StaffDAO
    {
        private string strConnection;

        public StaffDAO()
        {
            DatabaseConnection dc = new DatabaseConnection();
            strConnection = dc.GetConnection();
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
                    if (reader.HasRows)
                    {
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
                }
                finally
                {
                    conn.Close();
                }
            }
            return result;
        }
        
        public bool UpdateStaffStatus(string username, int status)
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
                    cmd.Parameters.AddWithValue("@isActive", status);
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

        public List<StaffDTO> GetStaffList()
        {
            List<StaffDTO> listStaff = null;
            SqlConnection con = new SqlConnection(strConnection);
            con.Open();
            try
            {
                string sql = "Select username, firstName, lastName, phone, email, isActive FROM Staff";
                SqlCommand cmd = new SqlCommand(sql, con);
                SqlDataReader reader = cmd.ExecuteReader();
                if (reader.HasRows)
                {
                    listStaff = new List<StaffDTO>();
                    while (reader.Read())
                    {
                        StaffDTO dto = new StaffDTO
                        {
                            Username = reader.GetString(0),
                            FirstName = reader.GetString(1),
                            LastName = reader.GetString(2),
                            Phone = reader.GetString(3),
                            Email = reader.GetString(4),
                            IsActive = reader.GetBoolean(5)
                        };
                        listStaff.Add(dto);
                    }
                }
            }
            catch (Exception)
            {
                listStaff = null;
            }
            finally
            {
                con.Close();
            }
            return listStaff;
        }

        public List<StaffDTO> AdminSearchStaffByUsername(string username)
        {
            List<StaffDTO> listMember = new List<StaffDTO>();
            SqlConnection conn = new SqlConnection(strConnection);
            if (conn.State == System.Data.ConnectionState.Closed)
            {
                conn.Open();
            }
            try
            {
                string sql = "Select username, firstName, lastName, phone, email, isActive FROM Staff WHERE username LIKE @username";
                SqlCommand cmd = new SqlCommand(sql, conn);
                cmd.Parameters.AddWithValue("@username", "%" + username + "%");
                SqlDataReader reader = cmd.ExecuteReader();
                if (reader.HasRows)
                {
                    listMember = new List<StaffDTO>();
                    while (reader.Read())
                    {
                        StaffDTO dto = new StaffDTO
                        {
                            Username = reader.GetString(0),
                            FirstName = reader.GetString(1),
                            LastName = reader.GetString(2),
                            Phone = reader.GetString(3),
                            Email = reader.GetString(4),
                            IsActive = reader.GetBoolean(5)
                        };
                        listMember.Add(dto);
                    }
                }
            }
            finally
            {
                conn.Close();
            }
            return listMember;
        }

    }
}
